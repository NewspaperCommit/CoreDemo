using Microsoft.EntityFrameworkCore;
using NewspaperArchive.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static NewspaperArchive.Application.Model.ShoppingCartModel;

namespace NewspaperArchive.Infrastructure.Persistence.Contexts
{
    public class PaymentInformationDbContext:DbContext
    {
        public PaymentInformationDbContext(DbContextOptions<PaymentInformationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ShoppingCartItemsCount> GetItemCount { get; set; }
        public virtual DbSet<ShoppingCartContainerInfo> GetShoppingCartAndContainerDetails { get; set; }
        public virtual DbSet<ShoppingCartItemsCount> StatusValue { get; set; }
    }
}
