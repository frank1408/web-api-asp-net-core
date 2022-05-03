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

			// https://docs.microsoft.com/en-us/learn/modules/build-web-api-aspnet-core/7-crud

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


		[HttpPost]
		public IActionResult Create(Pizza new_pizza)
        {
			PizzaService.Add(new_pizza);
			return CreatedAtAction( nameof(Create) , new { id=new_pizza.Id }, new_pizza );
        }


		[HttpPut("{id}")]
		public IActionResult Update(int id_pizza, Pizza updated_pizza)
		{
            if ( id_pizza != updated_pizza.Id )
            {
				return BadRequest();
            }
			var already_exist_pizza = PizzaService.Get(id_pizza);
			if (already_exist_pizza == null) // if (already_exist_pizza is null)
			{
				return NotFound();
            }
			PizzaService.Update(updated_pizza);
			return NoContent();
		}


		[HttpDelete]
		public IActionResult Delete(int id_pizza)
		{
			var already_exist_pizza = PizzaService.Get(id_pizza);
			if(already_exist_pizza == null)
            {
				return NotFound();
            }
			PizzaService.Delete(id_pizza);
			return NoContent();
		}




	} // class
} // namespace

