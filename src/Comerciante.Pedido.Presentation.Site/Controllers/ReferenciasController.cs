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
        private readonly IReferencia_CorAppService _referencia_CorAppService;
        private readonly IReferencia_TamanhoAppService _referencia_TamanhoAppService;

        public ReferenciasController(IReferenciaAppService referenciaAppService, ITamanhoAppService tamanhoAppService, ICorAppService corAppService, IReferencia_CorAppService referencia_CorAppService, IReferencia_TamanhoAppService referencia_TamanhoAppService)        {
            _referenciaAppService = referenciaAppService;
            _corAppService = corAppService;
            _tamanhoAppService = tamanhoAppService;
            _referencia_CorAppService = referencia_CorAppService;
            _referencia_TamanhoAppService = referencia_TamanhoAppService;
        }

        [HttpGet]
        public IActionResult Form(Guid? id = null)
        {
            var tamanhos = _tamanhoAppService.TrazerAtivos();
            var cores = _corAppService.TrazerAtivos();
            var tipos = Enum.GetNames(typeof(TipoReferenciaViewModel));
            ReferenciaFormViewModel form = new ReferenciaFormViewModel { Referencia =  new ReferenciaViewModel(), Cores = cores, Tamanhos = tamanhos };

            if (id != null)
            {
                ReferenciaViewModel referencia = _referenciaAppService.TrazerPorId(id.Value);
                referencia.Referencia_Cores = _referencia_CorAppService.TrazerPorReferencia(referencia.Id.Value).ToList();
                referencia.Referencia_Tamanhos = _referencia_TamanhoAppService.TrazerPorReferencia(referencia.Id.Value).ToList();
                if (referencia == null) return NotFound();
                form.Referencia = referencia;
            }
        
            return View(form);
        }

        [HttpPost]
        public JsonResult Criar([FromBody]ReferenciaViewModel referencia)
        {
            if (referencia == null) return null;
            var referenciaCriada = _referenciaAppService.Criar(referencia);
            return Json(referenciaCriada);
        }

        [HttpPut]
        public JsonResult Atualizar([FromBody]ReferenciaViewModel referencia)
        {
            if (referencia == null) return null;

            foreach (var referencia_cor in referencia.Referencia_Cores)
                referencia_cor.Id_referencia = referencia.Id;

            foreach (var referencia_tamanho in referencia.Referencia_Tamanhos)
                referencia_tamanho.Id_referencia = referencia.Id;

            var referenciaAtualizada = _referenciaAppService.Atualizar(referencia);
            return Json(referenciaAtualizada);
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