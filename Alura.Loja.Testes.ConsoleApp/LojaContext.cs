﻿using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public LojaContext()
        { }

        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PromocaoProduto>().HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });

            modelBuilder.Entity<Endereco>().ToTable("Enderecos");
            modelBuilder.Entity<Endereco>().Property<int>("ClienteId");
            modelBuilder.Entity<Endereco>().HasKey("ClienteId");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=LojaDB;User ID=sa;Password=b4AO9t2p6HAw");
        }
    }
}