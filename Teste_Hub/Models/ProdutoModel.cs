using System.ComponentModel.DataAnnotations;
using Teste_Hub.Enum;

namespace Teste_Hub.Models
{
	public class ProdutoModel
	{
		[Key]
		public long Id { get; set; }
		public string Descricao { get; set; }
		[DisplayFormat(DataFormatString = "{0:C}")]
		public double Valor { get; set; }
		public CategoriaEnum Categoria { get; set; }
	}
}
