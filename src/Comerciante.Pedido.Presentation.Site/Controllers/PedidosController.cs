using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Comerciante.Pedido.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Comerciante.Pedido.Application.Interfaces;
using Microsoft.AspNetCore.Routing;

namespace Comerciante.Pedido.Presentation.Site.Controllers
{
    [Authorize]
    public class PedidosController : Controller
    {
        private readonly IPedidoAppService _pedidoAppService;
        public PedidosController(IPedidoAppService pedidoAppService)
        {
            _pedidoAppService = pedidoAppService;
        }

        [HttpGet]
        public IActionResult MeusPedidos()
        {
            var pedidos = _pedidoAppService.TrazerAtivos();
            return View(pedidos);
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
            return View("Editar", new EditarPedidoViewModel { Pedido = pedido, AddEditReferencias = AddEditRefMockList() });
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

        List<PedidoViewModel> PedidosMock()
        {
            return new List<PedidoViewModel>
            {
                new PedidoViewModel { Numero  = 1, Total = 500},
                new PedidoViewModel { Numero  = 2, Total = 5450},
                new PedidoViewModel { Numero  = 3, Total = 100},
                new PedidoViewModel { Numero  = 4, Total = 5600},
                new PedidoViewModel { Numero  = 5, Total = 700},
            };
        }


        private List<AddEditReferenciaViewModel> AddEditRefMockList()
        {
            List<AddEditReferenciaViewModel> list = new List<AddEditReferenciaViewModel>();
            for (int i = 0; i < 15; i++)
            {
                list.Add(new AddEditReferenciaViewModel { Referencia = RefMock() });
            }
            return list;
        }

        private ReferenciaViewModel RefMock()
        {
            List<Referencia_CorViewModel> cores = new List<Referencia_CorViewModel>
            {
                new Referencia_CorViewModel{ Cor = new CorViewModel{ Descricao = "Azul"}},
                new Referencia_CorViewModel{ Cor = new CorViewModel{ Descricao = "Amarelo"}},
                new Referencia_CorViewModel{ Cor = new CorViewModel{ Descricao = "Vermelho"}},
                new Referencia_CorViewModel{ Cor = new CorViewModel{ Descricao = "Verde"}},
            };

            List<Referencia_TamanhoViewModel> tamanhos = new List<Referencia_TamanhoViewModel>
            {
                new Referencia_TamanhoViewModel{ Tamanho =  new TamanhoViewModel{ Descricao = "P"}},
                new Referencia_TamanhoViewModel{ Tamanho =  new TamanhoViewModel{ Descricao = "M"}},
                new Referencia_TamanhoViewModel{ Tamanho =  new TamanhoViewModel{ Descricao = "G"}},
                new Referencia_TamanhoViewModel{ Tamanho =  new TamanhoViewModel{ Descricao = "G"}},
            };

            List<Referencia_ImagemViewModel> imagens = new List<Referencia_ImagemViewModel>
            {
                new Referencia_ImagemViewModel { Uri = "https://dafitistatic-a.akamaihd.net/p/Rovitex-Vestido-Rovitex-Print-Multicolorido-9862-3673481-1-zoom.jpg"},
                new Referencia_ImagemViewModel { Uri = "https://dafitistatic-a.akamaihd.net/p/Rovitex-Vestido-Rovitex-Po%C3%A1s-Azul-7058-7773481-1-zoom.jpg"},
            };

            ReferenciaViewModel referencia = new ReferenciaViewModel
            {
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