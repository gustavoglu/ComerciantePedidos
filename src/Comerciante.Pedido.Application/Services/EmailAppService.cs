using Comerciante.Pedido.Application.Interfaces;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Comerciante.Pedido.Application.Services
{
    public class EmailAppService : IEmailAppService
    {

        private readonly IPedido_ReferenciaRepository _pedido_ReferenciaRepository;

        public EmailAppService(IPedido_ReferenciaRepository pedido_ReferenciaRepository)
        {
            _pedido_ReferenciaRepository = pedido_ReferenciaRepository;
        }

        public string CriaTabela(Guid id_pedido)
        {
            var pedido_referencias = _pedido_ReferenciaRepository.TrazerAtivosPorPedidoAllInclude(id_pedido);
            if (!pedido_referencias.Any()) return string.Empty;

            string tds = "";
            foreach (var pedido_referencia in pedido_referencias)
                tds = tds + CriaTdPedidoRef(pedido_referencia);

            string table =
                "<table>" +
                    "<thead>" +
                        "<tr>" +
                            "<th>Ref.</th>" +
                            "<th>Qtd.</th>" +
                            "<th>Cor.</th>" +
                            "<th>Tam.</th>" +
                            "<th>Grade.</th>" +
                        "</tr>" +
                    "</thead>" +
                    "<tbody>" +
                            tds +
                    "</tbody>"
                 + "</table>";

            return table;
        }

        private string CriaTdPedidoRef(Pedido_Referencia pedido_referencia)
        {
            string tds = "";

            if (pedido_referencia.Referencia.Grade)
            {
                tds =
                    "<tr>" +
                        $"<td>{pedido_referencia.Referencia.Codigo}</td>" +
                        $"<td>{pedido_referencia.Quantidade}</td>" +
                        $"<td>Nenhuma</td>" +
                        $"<td>Nenhum</td>" +
                        $"<td>Sim</td>" +
                    "</tr>";
            }
            else
            {
                if (pedido_referencia.Pedido_Referencia_Tamanhos.Any())
                {
                    foreach (var Pedido_Referencia_Tamanho in pedido_referencia.Pedido_Referencia_Tamanhos)
                    {
                        string td =
                              "<tr>" +
                                    $"<td>{pedido_referencia.Referencia.Codigo}</td>" +
                                    $"<td>{Pedido_Referencia_Tamanho.Quantidade}</td>" +
                                    $"<td>{Pedido_Referencia_Tamanho.Referencia_Cor.Cor.Descricao}</td>" +
                                    $"<td>{Pedido_Referencia_Tamanho.Referencia_Tamanho.Tamanho.Descricao}</td>" +
                                    $"<td>Não</td>" +
                              "</tr>";
                        tds = tds + td;
                    }
                }
            }

            return tds;
        }

        public async void EnviaEmail(string body, string usuario, int pedidoNumero)
        {
            var message = new MailMessage();

            message.To.Add(new MailAddress("gustavoglu@gmail.com"));
            message.From = (new MailAddress("gustavoglu@hotmail.com"));
            message.Body = body;
            message.IsBodyHtml = true;
            message.Subject = $"Pedido { pedidoNumero} / Usuario { usuario } Finalizado ";

            using (var smtp = new SmtpClient())
            {
                var credenciais = new NetworkCredential()
                {
                    UserName = "gustavoglu@hotmail.com",
                    Password = "giroldinhufenix"
                };

                smtp.Credentials = credenciais;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }
    }
}
