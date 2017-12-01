using Comerciante.Pedido.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class ReferenciaFormViewModel
    {
        public ReferenciaViewModel Referencia { get; set; }

        public IEnumerable<TamanhoViewModel> Tamanhos { get; set; }

        public IEnumerable<CorViewModel> Cores { get; set; }

        public IEnumerable<string> Tipos = Enum.GetNames(typeof(TipoReferenciaViewModel));
    }
}
