﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Comerciante.Pedido.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Comerciante.Pedido.Application.Interfaces;
using Microsoft.AspNetCore.Routing;
using Comerciante.Pedido.Application.ViewModels.Enums;
using Comerciante.Pedido.Application.Services;

namespace Comerciante.Pedido.Presentation.Site.Controllers
{
    [Authorize]
    public class PedidosController : Controller
    {
        private readonly IPedidoAppService _pedidoAppService;
        private readonly IPedido_ReferenciaAppService _pedido_ReferenciaAppService;
        private readonly IReferenciaAppService _referenciaAppService;
        private readonly IEmailAppService _emailAppService;
        public PedidosController(IPedidoAppService pedidoAppService, IReferenciaAppService referenciaAppService, IPedido_ReferenciaAppService pedido_ReferenciaAppService, IEmailAppService emailAppService)
        {
            _pedido_ReferenciaAppService = pedido_ReferenciaAppService;
            _referenciaAppService = referenciaAppService;
            _pedidoAppService = pedidoAppService;
            _emailAppService = emailAppService;
        }

        [HttpGet]
        public IActionResult MeusPedidos()
        {
            var meusPedidos = (from pedido in _pedidoAppService.TrazerAtivos()
                               select new MeusPedidosViewModel { Pedido = pedido, TotalPedido = _pedidoAppService.TrazerTotais(pedido.Id.Value) }).ToList();

            return View(meusPedidos.OrderByDescending(mp => mp.Pedido.Numero).ToList());
        }

        [HttpPost]
        public JsonResult ReferenciasJaAdicionadas([FromBody]Guid id)
        {
            var pedidoReferencias = _pedido_ReferenciaAppService.TrazerAtivosPorPedido(id);
            return Json(pedidoReferencias.OrderByDescending(pr => pr.Referencia.Codigo));
        }

        [Route("Pedidos/ReferenciasAdicionadas/{id:Guid}")]
        public IActionResult ReferenciasAdicionadas(Guid id)
        {
            var pedidoReferencias = _pedido_ReferenciaAppService.TrazerAtivos();
            var pedido = _pedidoAppService.TrazerPorId(id);
            return View(new PedidoReferenciaJaAddViewModel { Pedido = pedido, Pedido_Referencias = pedidoReferencias.ToList() });
        }

        public IActionResult Criar()
        {
            var pedidoCriado = _pedidoAppService.Criar(new PedidoViewModel());
            var editarPedidoViewModel = new EditarPedidoViewModel { Pedido = pedidoCriado, AddEditReferencias = AddEditRefMockList() };
            return RedirectToAction("Editar", new { id_pedido = pedidoCriado.Id });
        }

        [HttpGet]
        [Route("Pedidos/Editar/{id_pedido:Guid}")]
        public IActionResult Editar(Guid? id_pedido)
        {
            if (!id_pedido.HasValue || id_pedido == Guid.Empty) return RedirectToAction("MeusPedidos");
            var pedido = _pedidoAppService.TrazerPorId(id_pedido.Value);

            if (pedido.Finalizado)
            {
                var pedidoReaberto = _pedidoAppService.Reabrir(id_pedido.Value);
                pedido = pedidoReaberto;
            }

            var tipoReferencias = Enum.GetValues(typeof(TipoReferenciaViewModel)).Cast<TipoReferenciaViewModel>().Select(e => e.ToString());

            var referencias = _referenciaAppService.TrazerAtivos().ToList();
            var addEditReferencias = from referencia in referencias select new AddEditReferenciaViewModel(referencia);
            return View("Editar", new EditarPedidoViewModel { Pedido = pedido, AddEditReferencias = addEditReferencias.ToList(), TipoReferencias = tipoReferencias.ToList() });
        }

        [HttpDelete]
        [Route("Pedidos/Deletar/{id_pedido:Guid}")]
        public IActionResult Deletar(Guid id_pedido)
        {
            bool okDelete = _pedidoAppService.Deletar(id_pedido) > 0;
            if (!okDelete)
                return null;

            return Json(id_pedido);
        }

        [HttpGet]
        [Route("Pedidos/TotalPedido/{id:Guid}")]
        public JsonResult TotalPedido(Guid? id)
        {
            if (!id.HasValue || id.Value == Guid.Empty) return null;
            var totalPedido = _pedidoAppService.TrazerTotais(id.Value);
            return Json(totalPedido);
        }

        [HttpPost]
        public JsonResult FinalizarPedido([FromBody]Guid id_pedido)
        {
            if (id_pedido == null || id_pedido == Guid.Empty) return Json(null);
            var pedidoFinalizado = _pedidoAppService.Finalizar(id_pedido);

            _emailAppService.EnviaEmail(id_pedido);
            return Json(pedidoFinalizado);
        }


        private List<AddEditReferenciaViewModel> AddEditRefMockList()
        {
            List<AddEditReferenciaViewModel> list = new List<AddEditReferenciaViewModel>();
            for (int i = 0; i < 15; i++)
            {
                list.Add(new AddEditReferenciaViewModel(RefMock()));
            }
            return list;
        }

        private ReferenciaViewModel RefMock()
        {
            List<Referencia_CorViewModel> cores = new List<Referencia_CorViewModel>
            {
                new Referencia_CorViewModel{ Cor = new CorViewModel{ Id =  Guid.NewGuid(), Descricao = "Azul"}},
                new Referencia_CorViewModel{ Cor = new CorViewModel{ Id =  Guid.NewGuid(),Descricao = "Amarelo"}},
                new Referencia_CorViewModel{ Cor = new CorViewModel{ Id =  Guid.NewGuid(),Descricao = "Vermelho"}},
                new Referencia_CorViewModel{ Cor = new CorViewModel{ Id =  Guid.NewGuid(),Descricao = "Verde"}},
            };

            List<Referencia_TamanhoViewModel> tamanhos = new List<Referencia_TamanhoViewModel>
            {
                new Referencia_TamanhoViewModel{ Tamanho =  new TamanhoViewModel{ Id =  Guid.NewGuid(),Descricao = "P"}},
                new Referencia_TamanhoViewModel{ Tamanho =  new TamanhoViewModel{ Id =  Guid.NewGuid(),Descricao = "M"}},
                new Referencia_TamanhoViewModel{ Tamanho =  new TamanhoViewModel{ Id =  Guid.NewGuid(),Descricao = "G"}},
                new Referencia_TamanhoViewModel{ Tamanho =  new TamanhoViewModel{ Id =  Guid.NewGuid(),Descricao = "GG"}},
            };

            List<Referencia_ImagemViewModel> imagens = new List<Referencia_ImagemViewModel>
            {
                new Referencia_ImagemViewModel { Uri = "https://dafitistatic-a.akamaihd.net/p/Rovitex-Vestido-Rovitex-Print-Multicolorido-9862-3673481-1-zoom.jpg"},
                new Referencia_ImagemViewModel { Uri = "https://dafitistatic-a.akamaihd.net/p/Rovitex-Vestido-Rovitex-Po%C3%A1s-Azul-7058-7773481-1-zoom.jpg"},
            };

            ReferenciaViewModel referencia = new ReferenciaViewModel
            {
                Id = Guid.NewGuid(),
                Codigo = "30654",
                Descricao = "CAMISA REGATA",
                Preco = 15.50,
                Referencia_Cores = cores,
                Referencia_Tamanhos = tamanhos,
                Referencia_Imagens = imagens
            };

            return referencia;
        }
    }
}