using System.ComponentModel.DataAnnotations;

namespace Comerciante.Pedido.Infra.Identity.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
