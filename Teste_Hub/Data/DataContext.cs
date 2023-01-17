using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Teste_Hub.Enum;
using Teste_Hub.Models;

namespace Teste_Hub.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<ClienteModel> Clientes { get; set; }
		public DbSet<PedidoModel> Pedidos { get; set; }
		public DbSet<ProdutoModel> Produtos { get; set; }
		public DbSet<OrcamentoModel> Orcamentos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProdutoModel>().HasData(
				new ProdutoModel
				{
					Id = 1,
					Descricao = "Celular",
					Valor = 1.000,
					Categoria = CategoriaEnum.Leve
				},
				new ProdutoModel
				{
					Id = 2,
					Descricao = "Notebook",
					Valor = 3.000,
					Categoria = CategoriaEnum.Medio
				},
				new ProdutoModel
				{
					Id = 3,
					Descricao = "Televisão",
					Valor = 5.000,
					Categoria = CategoriaEnum.Pesado
				});
		}
	}
}
