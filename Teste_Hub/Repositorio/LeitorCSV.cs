using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using Teste_Hub.Interface;
using Teste_Hub.Models;

namespace Teste_Hub.Repositorio
{
	public class LeitorCSV : ILeituraCSV
	{
		public List<dynamic> LeituraCSV()
		{
			try
			{
				List<dynamic> lista = new List<dynamic>();
				using (var reader = new StreamReader("E:\\Projetos\\Teste_Hub\\Teste_Hub\\teste.csv"))
				using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
				{
					var records = csv.GetRecords<CsvModel>();
					while (reader.EndOfStream)
					{
						var linha = reader.ReadLine();
						var coluna = linha.Split(";");

						lista.Add(
							new
							{
								CpfCnpj = coluna[0],
								Nome = coluna[1],
								CEP = coluna[2],
								Produto = coluna[3],
								NumeroPedido = coluna[4],
								Data = coluna[5]
							});

					}
					return lista;
				}
			}
			catch (DirectoryNotFoundException ex)
			{
				throw ex;
			}

		}

		//public List<CsvModel> Leitura_CSV()
		//{
		//	var path = "E:\\Projetos\\Teste_Hub\\Teste_Hub\\teste.csv";
		//	var reader = new StreamReader(File.OpenRead(path));
		//	var line = reader.ReadLine();
		//	var column = line.Split(";");
		//	(int indexCpfCnpj, int indexNome, int indexCEP, int indexProduto, int indexNumeroPedido, int indexData) =
		//		SetColumnIndex(column);
		//	var lista = ListaCsv(reader, indexCpfCnpj, indexNome, indexCEP, indexProduto, indexNumeroPedido, indexData);

		//	foreach (var person in lista)
		//	{
		//		Console.WriteLine($"CPF: {person.CpfCnpj} / Nome: {person.Nome}, / Cep: {person.CEP}, Produto: {person.Produto}, Numero Pedido: {person.NumeroPedido}, Data: {person.Data} ");
		//	}

		//	return lista;
		//}

		//public (int , int , int , int , int , int ) SetColumnIndex(string[] column)
		//{
		//	int indexCpfCnpj = -1;
		//	int indexNome = -1;
		//	int indexCEP = -1;
		//	int indexProduto = -1;
		//	int indexNumeroPedido = -1;
		//	int indexData = -1;

		//	for(int i = 0; i < column.Length; i++)
		//	{
		//		if (string.IsNullOrEmpty(column[i]))
		//			continue;

		//		if (column[i].ToLower() == "CpfCnpj")
		//		{
		//			indexCpfCnpj = i;
		//		}

		//		if (column[i].ToLower() == "nome")
		//		{
		//			indexNome = i;
		//		}
		//		if (column[i].ToLower() == "CEP")
		//		{
		//			indexCEP = i;
		//		}
		//		if (column[i].ToLower() == "Produto")
		//		{
		//			indexProduto = i;
		//		}
		//		if (column[i].ToLower() == "NumeroPedido")
		//		{
		//			indexNumeroPedido = i;
		//		}
		//		if (column[i].ToLower() == "Data")
		//		{
		//			indexData = i;
		//		}

		//	}
		//	return(indexCpfCnpj, indexNome, indexCEP, indexProduto, indexNumeroPedido, indexData);

		//}

		//public static List<CsvModel> ListaCsv(StreamReader reader, int indexCpfCnpj, int indexNome, int indexCEP, int indexProduto, int indexNumeroPedido, int indexData)
		//{
		//	string line;
		//	var lista = new List<CsvModel>();
		//	CsvModel csvModel;
		//	while ((line = reader.ReadLine()) != null)
		//	{
		//		var values = line.Split(',');
		//		csvModel = new CsvModel();

		//		if (indexCpfCnpj != -1)
		//			csvModel.CpfCnpj = values[indexCpfCnpj];

		//		if (indexCEP != -1)
		//			csvModel.CEP = values[indexCEP];

		//		if (indexProduto != -1)
		//			csvModel.Produto = values[indexProduto];

		//		if (indexNumeroPedido != -1)
		//			csvModel.NumeroPedido = values[indexNumeroPedido];

		//		if (indexData != -1)
		//			csvModel.Data = values[indexData];

		//		lista.Add(csvModel);	
		//	}
		//	return lista;
		//}

	}
}
