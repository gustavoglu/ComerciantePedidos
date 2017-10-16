using System.ComponentModel.DataAnnotations;

namespace Comerciante.Pedido.Infra.Identity.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Informe um Email válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Informe seu Nome Completo")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} precisa ser no minimo {2} e no maximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação Senha")]
        [Compare("Password", ErrorMessage = "As Senhas precisam ser iguáis.")]
        public string ConfirmPassword { get; set; }
    }
}
