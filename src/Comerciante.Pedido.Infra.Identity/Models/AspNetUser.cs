using Comerciante.Pedido.Domain.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Comerciante.Pedido.Infra.Identity.Extensions;

namespace Comerciante.Pedido.Infra.Identity.Models
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _acessor;
        public AspNetUser(IHttpContextAccessor acessor)
        {
            _acessor = acessor;
        }

        public string UserName => _acessor.HttpContext.User.Identity.Name;

        public string UserId => IsAuthenticated() ? _acessor.HttpContext.User.GetUserId() : string.Empty;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _acessor.HttpContext.User.Claims;
        }

        public bool IsAuthenticated()
        {
            return _acessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
