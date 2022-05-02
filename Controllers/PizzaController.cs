using System;
using Microsoft.AspNetCore.Mvc;
using Projects.Models;
using Projects.Services;

namespace Projects.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PizzaController:ControllerBase
	{
		public PizzaController()
		{
		}

		// crud create read update delete


		[HttpGet]
		public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();
		//{ return PizzaService.GetAll(); }


		[HttpGet("{id_pizza}")]
		public ActionResult<Pizza> Get(int id_pizza)
		{
			var pizza_tmp = PizzaService.Get(id_pizza);
			if (pizza_tmp == null)
            {
				// return error 404
				return NotFound();
            }
			return pizza_tmp;

		}








	} // class
} // namespace

