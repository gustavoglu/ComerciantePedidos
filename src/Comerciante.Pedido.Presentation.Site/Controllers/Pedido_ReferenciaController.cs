using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Comerciante.Pedido.Application.ViewModels;
using Comerciante.Pedido.Application.Interfaces;
using System;
using System.Linq;

namespace Comerciante.Pedido.Presentation.Site.Controllers
{
    public class Pedido_ReferenciaController : Controller
    {

        private readonly IPedido_ReferenciaAppService _pedido_refenreciaAppService;

        public Pedido_ReferenciaController(IPedido_ReferenciaAppService pedido_refenreciaAppService)
        {
            _pedido_refenreciaAppService = pedido_refenreciaAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEditPedidoReferencia()
        {
            return PartialView("_ModalAddRef");
        }

        [HttpPost]
        public JsonResult Deletar([FromBody]Guid id)
        {
            bool deletado = _pedido_refenreciaAppService.Deletar(id) > 0;
            if (!deletado) return Json(null);
            return Json(id);
        }

        [HttpPost]
        public JsonResult CriarReferenciaPedido([FromBody]Pedido_ReferenciaViewModel pedidoReferencia)
        {
            var pedido_referenciaCriado = _pedido_refenreciaAppService.Criar(pedidoReferencia);
            return Json(pedidoReferencia);
        }

        public IActionResult Referencias(EditarPedidoViewModel editarPedidoViewModel)
        {
            editarPedidoViewModel.AddEditReferencias = AddEditRefMockList();
            return View(editarPedidoViewModel);
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