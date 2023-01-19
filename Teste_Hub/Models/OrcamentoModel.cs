
using System.ComponentModel.DataAnnotations;

namespace Teste_Hub.Models
{
	public class OrcamentoModel
	{
		[Key]
		[Required]
		public long Id { get; set; }
		
		public double ValorFrete { get; set; }
		
		public double ValorFinal { get; set; }
		public virtual ProdutoModel Produto { get; set; }
		
		public DateTime DataEntrega { get; set; }
		public bool Aprovado { get; set; }

		
	}
}
