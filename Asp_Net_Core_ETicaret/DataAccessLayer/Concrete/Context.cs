using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-2PUE7SMB\\;database=ASP_Net_Core_MVC_E_Ticaret_Database_New;integrated security=true;TrustServerCertificate=True;");
        }
        public DbSet<UserAdminTable> UserAdminTables { get; set; }
        public DbSet<GenderTable> GenderTables { get; set; }
        public DbSet<CategoryTable> CategoryTables { get; set; }
        public DbSet<ProductTable> ProductTables { get; set; }
        public DbSet<CommentTable> CommentTables { get; set; }
        public DbSet<MessageTable> MessageTables { get; set; }
        public DbSet<OrderTable> OrderTables { get; set; }
        public DbSet<BestSellersTable> BestSellersTables { get; set; }
        public DbSet<CargoTable> CargoTables { get; set; }
    }
}
