﻿using Microsoft.EntityFrameworkCore;

namespace Comerciante.Pedido.Infra.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<T>(this ModelBuilder modelbuilder, EntityTypeConfiguration<T> configuration) where T : class
        {
            configuration.Map(modelbuilder.Entity<T>());
        }
    }
}
