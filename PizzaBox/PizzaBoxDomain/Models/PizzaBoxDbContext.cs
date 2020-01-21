using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBoxDomain.Models
{
    public partial class PizzaBoxDbContext : DbContext
    {
        public PizzaBoxDbContext()
        {
        }

        public PizzaBoxDbContext(DbContextOptions<PizzaBoxDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaOrder> PizzaOrder { get; set; }
        public virtual DbSet<PizzaStore> PizzaStore { get; set; }
        public virtual DbSet<PizzaUser> PizzaUser { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=johnf;trusted_connection=true;");
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Pizza__DD37D91A1361FB4F");

                entity.ToTable("Pizza", "PizzaBox");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Bacon).HasColumnName("bacon");

                entity.Property(e => e.Cheese)
                    .HasColumnName("cheese")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Chicken).HasColumnName("chicken");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("money");

                entity.Property(e => e.Crust)
                    .IsRequired()
                    .HasColumnName("crust")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ExtraCheese).HasColumnName("extra_cheese");

                entity.Property(e => e.Mozzerella).HasColumnName("mozzerella");

                entity.Property(e => e.Onion).HasColumnName("onion");

                entity.Property(e => e.Pepper).HasColumnName("pepper");

                entity.Property(e => e.Pepperoni).HasColumnName("pepperoni");

                entity.Property(e => e.Pineapple).HasColumnName("pineapple");

                entity.Property(e => e.Sauce)
                    .HasColumnName("sauce")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Sausage).HasColumnName("sausage");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnName("size")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("PK__PizzaOrd__080E37751948B26F");

                entity.ToTable("PizzaOrder", "PizzaBox");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("money");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PizzaEight).HasColumnName("pizza_eight");

                entity.Property(e => e.PizzaFive).HasColumnName("pizza_five");

                entity.Property(e => e.PizzaFour).HasColumnName("pizza_four");

                entity.Property(e => e.PizzaNine).HasColumnName("pizza_nine");

                entity.Property(e => e.PizzaOne).HasColumnName("pizza_one");

                entity.Property(e => e.PizzaSeven).HasColumnName("pizza_seven");

                entity.Property(e => e.PizzaSix).HasColumnName("pizza_six");

                entity.Property(e => e.PizzaTen).HasColumnName("pizza_ten");

                entity.Property(e => e.PizzaThree).HasColumnName("pizza_three");

                entity.Property(e => e.PizzaTwo).HasColumnName("pizza_two");

                entity.Property(e => e.Storename)
                    .IsRequired()
                    .HasColumnName("storename")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PizzaEightNavigation)
                    .WithMany(p => p.PizzaOrderPizzaEightNavigation)
                    .HasForeignKey(d => d.PizzaEight)
                    .HasConstraintName("FK__PizzaOrde__pizza__6D0D32F4");

                entity.HasOne(d => d.PizzaFiveNavigation)
                    .WithMany(p => p.PizzaOrderPizzaFiveNavigation)
                    .HasForeignKey(d => d.PizzaFive)
                    .HasConstraintName("FK__PizzaOrde__pizza__6A30C649");

                entity.HasOne(d => d.PizzaFourNavigation)
                    .WithMany(p => p.PizzaOrderPizzaFourNavigation)
                    .HasForeignKey(d => d.PizzaFour)
                    .HasConstraintName("FK__PizzaOrde__pizza__693CA210");

                entity.HasOne(d => d.PizzaNineNavigation)
                    .WithMany(p => p.PizzaOrderPizzaNineNavigation)
                    .HasForeignKey(d => d.PizzaNine)
                    .HasConstraintName("FK__PizzaOrde__pizza__6E01572D");

                entity.HasOne(d => d.PizzaOneNavigation)
                    .WithMany(p => p.PizzaOrderPizzaOneNavigation)
                    .HasForeignKey(d => d.PizzaOne)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaOrde__pizza__66603565");

                entity.HasOne(d => d.PizzaSevenNavigation)
                    .WithMany(p => p.PizzaOrderPizzaSevenNavigation)
                    .HasForeignKey(d => d.PizzaSeven)
                    .HasConstraintName("FK__PizzaOrde__pizza__6C190EBB");

                entity.HasOne(d => d.PizzaSixNavigation)
                    .WithMany(p => p.PizzaOrderPizzaSixNavigation)
                    .HasForeignKey(d => d.PizzaSix)
                    .HasConstraintName("FK__PizzaOrde__pizza__6B24EA82");

                entity.HasOne(d => d.PizzaTenNavigation)
                    .WithMany(p => p.PizzaOrderPizzaTenNavigation)
                    .HasForeignKey(d => d.PizzaTen)
                    .HasConstraintName("FK__PizzaOrde__pizza__6EF57B66");

                entity.HasOne(d => d.PizzaThreeNavigation)
                    .WithMany(p => p.PizzaOrderPizzaThreeNavigation)
                    .HasForeignKey(d => d.PizzaThree)
                    .HasConstraintName("FK__PizzaOrde__pizza__68487DD7");

                entity.HasOne(d => d.PizzaTwoNavigation)
                    .WithMany(p => p.PizzaOrderPizzaTwoNavigation)
                    .HasForeignKey(d => d.PizzaTwo)
                    .HasConstraintName("FK__PizzaOrde__pizza__6754599E");

                entity.HasOne(d => d.StorenameNavigation)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.Storename)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaOrde__store__656C112C");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaOrde__usern__6477ECF3");
            });

            modelBuilder.Entity<PizzaStore>(entity =>
            {
                entity.HasKey(e => e.Storename)
                    .HasName("PK__PizzaSto__AEF30AB5EA29D05B");

                entity.ToTable("PizzaStore", "PizzaBox");

                entity.Property(e => e.Storename)
                    .HasColumnName("storename")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cell)
                    .IsRequired()
                    .HasColumnName("cell")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PresetPizzaId).HasColumnName("preset_pizza_ID");

                entity.Property(e => e.PresetSpecial)
                    .HasColumnName("preset_special")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StoreAddress)
                    .IsRequired()
                    .HasColumnName("store_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreJoinDate)
                    .HasColumnName("store_join_date")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StorePassword)
                    .IsRequired()
                    .HasColumnName("store_password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PresetPizza)
                    .WithMany(p => p.PizzaStore)
                    .HasForeignKey(d => d.PresetPizzaId)
                    .HasConstraintName("FK__PizzaStor__prese__59063A47");
            });

            modelBuilder.Entity<PizzaUser>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__PizzaUse__F3DBC573D8DA55E9");

                entity.ToTable("PizzaUser", "PizzaBox");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cell)
                    .IsRequired()
                    .HasColumnName("cell")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastOrderStore)
                    .HasColumnName("last_order_store")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastOrderTime)
                    .HasColumnName("last_order_time")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.UserAddress)
                    .IsRequired()
                    .HasColumnName("user_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserJoinDate)
                    .HasColumnName("user_join_date")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("user_password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.LastOrderStoreNavigation)
                    .WithMany(p => p.PizzaUser)
                    .HasForeignKey(d => d.LastOrderStore)
                    .HasConstraintName("FK__PizzaUser__last___5EBF139D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
