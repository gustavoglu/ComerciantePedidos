using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comerciante.Pedido.Presentation.Site.Controllers.VComponents
{
    public class TotalPedidoViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return View("");
        }
    }
}
