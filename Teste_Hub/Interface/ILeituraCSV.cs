using Teste_Hub.Models;

namespace Teste_Hub.Interface
{
	public interface ILeituraCSV
	{
		//List<dynamic> LeituraCSV();
		public List<CsvModel> Leitura_CSV();
	}
}
