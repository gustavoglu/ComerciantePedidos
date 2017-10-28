using Comerciante.Pedido.Application.Interfaces;
using Comerciante.Pedido.Domain.Interfaces;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Comerciante.Pedido.Application.Services
{
    public class EmailAppService : IEmailAppService
    {

        private readonly IPedido_ReferenciaRepository _pedido_ReferenciaRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoAppService _pedidoAppService;
        private readonly IUser _user;

        public EmailAppService(IPedido_ReferenciaRepository pedido_ReferenciaRepository, IPedidoRepository pedidoRepository, IPedidoAppService pedidoAppService, IUser user)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoAppService = pedidoAppService;
            _pedido_ReferenciaRepository = pedido_ReferenciaRepository;
            _user = user;
        }

        public async Task<string> CriaTabela(Guid id_pedido)
        {
            var pedido_referencias = await _pedido_ReferenciaRepository.TrazerAtivosPorPedidoAllInclude(id_pedido);
            if (!pedido_referencias.Any()) return string.Empty;

            string tds = "";
            foreach (var pedido_referencia in pedido_referencias)
                tds = tds + CriaTdPedidoRef(pedido_referencia);

            string table =
                "<table border='1'>" +
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
                    foreach (var Pedido_Referencia_Tamanho in pedido_referencia.Pedido_Referencia_Tamanhos.Where(prt => prt.Quantidade > 0))
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

        public async void EnviaEmail(Guid id_pedido)
        {
            string table = await this.CriaTabela(id_pedido);
            var pedido = _pedidoRepository.TrazerPorId(id_pedido);
            var totaisViewModel = _pedidoAppService.TrazerTotais(id_pedido);
            string usuario = _user.UserName;
            string totais = $"TOTAL : {totaisViewModel.TotalPedido} R$ | TOTAL PEÇAS : {totaisViewModel.TotalPecas} | TOTAL REFERENCIAS : { totaisViewModel.TotalReferencias}";
            string body = totais + "\n\n" + table;

            var message = new MailMessage();

            message.To.Add(new MailAddress("gustavoglu@gmail.com"));
            message.From = (new MailAddress("gustavoglu@hotmail.com"));
            message.Body = body;
            message.IsBodyHtml = true;
            message.Subject = $"Pedido { pedido.Numero} / Usuario { usuario } Finalizado ";

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

        public void Dispose()
        {
            this._pedidoAppService.Dispose();
            this._pedidoRepository.Dispose();
            _pedido_ReferenciaRepository.Dispose();
        }
    }
}
