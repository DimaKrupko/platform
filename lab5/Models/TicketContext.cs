using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System;
using Microsoft.EntityFrameworkCore;


namespace lab5.Models
{
    public partial class TicketContext : DbContext
    {
        public virtual DbSet<Train> Trains { get; set; } = null;
        public virtual DbSet<User> Users { get; set; } = null;
        public virtual DbSet<Ticket> Tickets { get; set; } = null;

        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot conf = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
                optionsBuilder.UseSqlServer(connectionString: conf.GetConnectionString("Data"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.userId).HasColumnName("UserId");

                entity.HasKey(e => e.userId);

            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.Property(e => e.train_id).HasColumnName("train_id");
                entity.HasKey(e => e.train_id);

            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.ticket_id).HasColumnName("ticket_id");
                entity.HasKey(e => e.ticket_id);


                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ticket_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userId");

                entity.HasOne(d => d.TrainsNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ticket_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("train_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

