
using System.ComponentModel.DataAnnotations;

namespace Teste_Hub.Models
{
	public class OrcamentoModel
	{
		[Key]
		[Required]
		public long Id { get; set; }
		[DisplayFormat(DataFormatString = "{0:C}")]
		public double ValorFrete { get; set; }
		[DisplayFormat(DataFormatString = "{0:C}")]
		public double ValorFinal { get; set; }
		public virtual ProdutoModel Produto { get; set; }
		[DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
		public DateTime DataEntrega { get; set; }
		public bool Aprovado { get; set; }

		public bool Entregue
		{
			get { return DataEntrega < DateTime.Now ? true : false; }

		}
	}
}
