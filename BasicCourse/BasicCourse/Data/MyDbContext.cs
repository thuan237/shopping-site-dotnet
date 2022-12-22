using Microsoft.EntityFrameworkCore;

namespace BasicCourse.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet 
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<DetailOrder> DetailOrders { get; set; }
        
        public DbSet<User> Users { get; set; }
        #endregion

        //định nghĩa fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("order");
                e.HasKey(or => or.order_id);
                e.Property(or => or.order_date).HasDefaultValueSql("getutcdate()");
                e.Property(or => or.receiver).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<DetailOrder>(e_detail =>
            {
                e_detail.ToTable("order_details");
                e_detail.HasKey(e => new
                {
                    e.product_id, e.order_id
                });
                e_detail.HasOne(e_detail => e_detail.Order)
                        .WithMany(e => e.detailOrders)
                        .HasForeignKey(e => e.order_id)
                        .HasConstraintName("FK_OrderDetail_Order");

                e_detail.HasOne(e_detail => e_detail.Product)
                        .WithMany(e => e.detailOrders)
                        .HasForeignKey(e => e.product_id)
                        .HasConstraintName("FK_OrderDetail_Product");
            });

            modelBuilder.Entity<User>(e => {
                e.HasIndex(e => e.username).IsUnique();
                e.Property(e => e.full_name).IsRequired().HasMaxLength(150);
                e.Property(e => e.email).IsRequired().HasMaxLength(150);
            });
        }
    }
}
