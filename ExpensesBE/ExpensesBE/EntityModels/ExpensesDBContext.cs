using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExpensesBE.EntityModels
{
    public partial class ExpensesDBContext : DbContext
    {
        public ExpensesDBContext()
        {
        }

        public ExpensesDBContext(DbContextOptions<ExpensesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entry> Entries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PAVANACER\\SQLEXPRESS;uid=PAVANACER\\POTTA_PAVAN_KUMAR;pwd=;Database=ExpensesDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>(entity =>
            {
                entity.ToTable("Entry");

                entity.Property(e => e.EntryId).HasColumnName("EntryID");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
