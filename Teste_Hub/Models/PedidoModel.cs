using System.ComponentModel.DataAnnotations;

namespace Teste_Hub.Models
{
	public class PedidoModel
	{
		[Key]
		public long Id { get; set; }
		public long Numero { get; set; }
		
		public double Valor { get; set; }
		
		public DateTime Data { get; set; }
		public string CEP { get; set; }
		public virtual ClienteModel Cliente { get; set; }
		public virtual ProdutoModel Produto { get; set; }
	}
}
