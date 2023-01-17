using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Teste_Hub.Data;
using Teste_Hub.Interface;
using Teste_Hub.Models;
using Teste_Hub.Repositorio;

namespace Teste_Hub.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CsvController : ControllerBase
	{
		private  ILeituraCSV _leitorCSV;
		private  DataContext _dataContext;

		
		public CsvController(ILeituraCSV leitorCSV, DataContext data)
		{
			_leitorCSV = leitorCSV;
			_dataContext = data;
		}


		[HttpGet]
		public ActionResult<IEnumerable<CsvModel>> CSV()
		{

			var csv = _leitorCSV.Leitura_CSV().OfType<LeitorCSV>().ToList();
			List<CsvModel> pedidos = new List<CsvModel>();

			int[] array = { 1, 2, 3, 4, 5 };

			return pedidos;

			//return Ok(csv);
		}

		
		 

	}
}
