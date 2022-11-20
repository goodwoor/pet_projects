using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Антикварный_магазин.Model
{
    public partial class AntiqueStore : DbContext
    {
        public AntiqueStore()
            : base("name=AntiqueStore")
        {
        }

        public virtual DbSet<Антиквариат> Антиквариат { get; set; }
        public virtual DbSet<Букинистика> Букинистика { get; set; }
        public virtual DbSet<Клиент> Клиент { get; set; }
        public virtual DbSet<Оружие> Оружие { get; set; }
        public virtual DbSet<Покупка> Покупка { get; set; }
        public virtual DbSet<Произведение_исскуства> Произведение_исскуства { get; set; }
        public virtual DbSet<Сотрудник> Сотрудник { get; set; }
        public virtual DbSet<Часы> Часы { get; set; }
        public virtual DbSet<Экспертиза> Экспертиза { get; set; }
        public virtual DbSet<Ювелирное_изделие> Ювелирное_изделие { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Антиквариат>()
                .Property(e => e.Стоимость)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Антиквариат>()
                .HasOptional(e => e.Букинистика)
                .WithRequired(e => e.Антиквариат)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Антиквариат>()
                .HasOptional(e => e.Оружие)
                .WithRequired(e => e.Антиквариат)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Антиквариат>()
                .HasOptional(e => e.Произведение_исскуства)
                .WithRequired(e => e.Антиквариат)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Антиквариат>()
                .HasOptional(e => e.Часы)
                .WithRequired(e => e.Антиквариат)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Антиквариат>()
                .HasOptional(e => e.Ювелирное_изделие)
                .WithRequired(e => e.Антиквариат)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Сотрудник>()
                .Property(e => e.Зарплата)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Экспертиза>()
                .Property(e => e.Оценочная_стоимость)
                .HasPrecision(19, 4);
        }
    }
}
