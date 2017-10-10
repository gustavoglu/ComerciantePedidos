using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comerciante.Pedido.Presentation.Site.AutoMap
{
    public class ConfigAutoMapper
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelProfile>();
                cfg.AddProfile<ViewModelToDomainProfile>();
            });
        }
    }
}
