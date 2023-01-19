using Swashbuckle.AspNetCore.SwaggerGen;
using Teste_Hub.Data;
using Teste_Hub.Enum;
using Teste_Hub.Interface;
using Teste_Hub.Models;

namespace Teste_Hub.Repositorio
{
	public class RegrasNegocio
	{
		private DatasEnum _datasEnum = DatasEnum.OutrasDatas;
		private LocalidadesEnum _localidadesEnum = LocalidadesEnum.Outras;
		private readonly DataContext _context;

		public DateTime Inicio { get; private set; }
		public DateTime Fim { get; private set; }


		public RegrasNegocio(DataContext context, DatasEnum datasEnum)
		{
			_context = context;
			_datasEnum = datasEnum;
		}

		private void DescontoPorData(OrcamentoModel orcamento, PedidoModel pedido)
		{
			dynamic datas = DataFeriado();

			if (datas.dataNatal.Includes(pedido.Data))
			{
				_datasEnum = DatasEnum.Natal;
				orcamento.ValorFinal = pedido.Valor * 0.9;
			}
			else if (datas.dataBlackFriday.Includes(pedido.Data))
			{
				_datasEnum = DatasEnum.BlackFriday;
				orcamento.ValorFinal = pedido.Valor * 0.7;
			}
			else if (datas.dataDiaPais.Includes(pedido.Data))
			{
				_datasEnum = DatasEnum.DiaDosPais;
				orcamento.ValorFinal = pedido.Valor * 0.95;
			}
			else if (datas.dataDiaMaes.Includes(pedido.Data))
			{
				_datasEnum = DatasEnum.DiaDosPais;
				orcamento.ValorFinal = pedido.Valor * 0.95;
			}
			else
				orcamento.ValorFinal = pedido.Valor;
		}


		private void PrazoDeEntrega(OrcamentoModel orcamento, PedidoModel pedido)
		{
			switch (_datasEnum)
			{
				case (DatasEnum)LocalidadesEnum.NorteNordeste:
					orcamento.DataEntrega = pedido.Data.AddDays(4);
					break;
				case (DatasEnum)LocalidadesEnum.CentroOesteSul:
					orcamento.DataEntrega = pedido.Data.AddDays(3);
					break;
				case (DatasEnum)LocalidadesEnum.Sudeste:
					orcamento.DataEntrega = pedido.Data.AddDays(2);
					break;
			}


			switch (_datasEnum)
			{
				case DatasEnum.Natal:
					orcamento.DataEntrega = orcamento.DataEntrega.AddDays(10);
					break;
				case DatasEnum.BlackFriday:
					orcamento.DataEntrega = orcamento.DataEntrega.AddDays(15);
					break;
				case DatasEnum.DiaDosPais:
					orcamento.DataEntrega = orcamento.DataEntrega.AddDays(3);
					break;
				case DatasEnum.DiaDasMaes:
					orcamento.DataEntrega = orcamento.DataEntrega.AddDays(3);
					break;
			}
		}

		private dynamic DataFeriado(int ano)
		{
			DateTime dataNatalInicio = new DateTime(ano, 12, 1);
			DateTime dataNatalFim = new DateTime(ano, 12, 31);
			DateTime dataBlackFridayInicio = new DateTime(ano, 11, 25);
			DateTime dataBlackFridayFim = new DateTime(ano, 11, 30);
			DateTime dataDiaPaisInicio = new DateTime(ano, 8, 1);
			DateTime dataDiaPaisFim = new DateTime(ano, 8, 15);
			DateTime dataDiaMaesInicio = new DateTime(ano, 5, 1);
			DateTime dataDiaMaesFim = new DateTime(ano, 5, 15);

			return new
			{
				dataNatal = new DateRange(dataNatalInicio, dataNatalFim),
				dataBlackFriday = new DateRange(dataBlackFridayInicio, dataBlackFridayFim),
				dataDiaPais = new DateRange(dataDiaPaisInicio, dataDiaPaisFim),
				dataDiaMaes = new DateRange(dataDiaMaesInicio, dataDiaMaesFim)
			};
		}

		public class DateRange : IRange<DateTime>
		{
			public DateRange(DateTime inicio, DateTime fim)
			{
				Inicio = inicio;
				Fim = fim;
			}

			public DateTime Inicio { get; }
			public DateTime Fim { get; }
			public bool IsValid => Inicio <= Fim;

			public bool Includes(DateTime value)
			{
				return value >= Inicio && value <= Fim;
			}

			public bool Includes(IRange<DateTime> range)
			{
				return range.Inicio >= Inicio && range.Fim <= Fim;
			}

			public bool Overlaps(IRange<DateTime> range)
			{
				return Includes(range.Inicio) || Includes(range.Fim) || range.Includes(this);
			}
		}

	}
}

	



