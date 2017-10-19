﻿using System.Collections.Generic;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class Pedido_ReferenciaRepository : Repository<Pedido_Referencia>, IPedido_ReferenciaRepository
    {
        public Pedido_ReferenciaRepository(ContextPedidos context) : base(context)
        {

        }

        public IEnumerable<Pedido_Referencia> TrazerAtivosIncludePedido_Referencia_TamanhosPorPedido(Guid id_pedido)
        {
            return DbSet.Where(pr => pr.Deletado == false && pr.Id_pedido == id_pedido)
                .Include(pr => pr.Pedido_Referencia_Tamanhos);
        }
    }
}
