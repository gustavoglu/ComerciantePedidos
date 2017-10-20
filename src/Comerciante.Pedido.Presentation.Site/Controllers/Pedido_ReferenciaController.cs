using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Comerciante.Pedido.Application.ViewModels;

namespace Comerciante.Pedido.Presentation.Site.Controllers
{
    public class Pedido_ReferenciaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEditPedidoReferencia()
        {
            return PartialView("_ModalAddRef");
        }

        //public JsonResult CriarReferenciaPedido(Pedido_ReferenciaViewModel pedidoReferencia)
        //{
        
        //}

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