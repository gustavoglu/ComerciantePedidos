using System.ComponentModel.DataAnnotations;

namespace Comerciante.Pedido.Infra.Identity.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
