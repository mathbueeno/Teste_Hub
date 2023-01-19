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
		public ActionResult<IEnumerable<CsvModel>> CSV(IFormFile planilha)
		{

			List<dynamic> csv = _leitorCSV.LeituraCSV();
			List<CsvModel> pedidos = new List<CsvModel>();

			return Ok();

	



			
		}

		
		 

	}
}
