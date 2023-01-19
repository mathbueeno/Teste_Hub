using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Teste_Hub.Models
{
	public class ClienteModel
	{
		
		[Key]
		public long CpfCnpj { get; set; }
		public string Nome { get; set; }
	}
}
