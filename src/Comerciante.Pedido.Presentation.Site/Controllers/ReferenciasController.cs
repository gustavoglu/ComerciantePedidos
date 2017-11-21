using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Comerciante.Pedido.Application.Interfaces;
using Comerciante.Pedido.Application.ViewModels.Enums;
using Comerciante.Pedido.Application.ViewModels;

namespace Comerciante.Pedido.Presentation.Site.Controllers
{
    public class ReferenciasController : Controller
    {

        private readonly IReferenciaAppService _referenciaAppService;

        public ReferenciasController(IReferenciaAppService referenciaAppService)
        {
            _referenciaAppService = referenciaAppService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Criar([FromBody]ReferenciaViewModel referencia)
        {
            if (referencia == null) return null;
            var referenciaCriada = _referenciaAppService.Criar(referencia);
            return Json(referenciaCriada);
        }

        [HttpPost]
        public JsonResult TrazerPorTipo([FromBody]TipoReferenciaViewModel? tipo)
        {
            if (!tipo.HasValue)
            {
                return Json(from referencia in _referenciaAppService.TrazerAtivos() select new AddEditReferenciaViewModel(referencia));
            }
            var referencias = _referenciaAppService.TrazerAtivoPorTipo(tipo);
            var addEditReferencias = from referencia in referencias select new AddEditReferenciaViewModel(referencia);
            return Json(addEditReferencias);
        }

    }
}