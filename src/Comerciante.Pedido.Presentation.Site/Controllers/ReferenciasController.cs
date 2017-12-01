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
        private readonly ICorAppService _corAppService;
        private readonly ITamanhoAppService _tamanhoAppService;

        public ReferenciasController(IReferenciaAppService referenciaAppService, ITamanhoAppService tamanhoAppService, ICorAppService corAppService)        {
            _referenciaAppService = referenciaAppService;
            _corAppService = corAppService;
            _tamanhoAppService = tamanhoAppService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var tamanhos = _tamanhoAppService.TrazerAtivos();
            var cores = _corAppService.TrazerAtivos();
            var tipos = Enum.GetNames(typeof(TipoReferenciaViewModel));
            ReferenciaFormViewModel form = new ReferenciaFormViewModel { Referencia = new ReferenciaViewModel(), Cores = cores,Tamanhos = tamanhos };
            return View(form);
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