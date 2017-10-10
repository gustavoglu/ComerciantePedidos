﻿using System.Threading.Tasks;

namespace Comerciante.Pedido.Infra.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
