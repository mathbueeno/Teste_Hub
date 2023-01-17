using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Teste_Hub.Models
{
	public class ClienteModel
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Key]
		public long CpfCnpj { get; set; }
		public string Nome { get; set; }
	}
}
