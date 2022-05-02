using System;
using System.Runtime.CompilerServices;
using Projects.Models;

namespace Projects.Services
{
    public static class PizzaService
    {

        static List<Pizza> Pizzas { get; }

        static int nextId = 5;

        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza{ Id=1, Name="Hawaiana", IsGlutenFree=false },
                new Pizza{ Id=2, Name="5 Carnes", IsGlutenFree=false },
                new Pizza{ Id=3, Name="Peperoni", IsGlutenFree=false },
                new Pizza{ Id=4, Name="ExtraVaganza", IsGlutenFree=false },
            };
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza? Get(int id_pizza) => Pizzas.FirstOrDefault(p => p.Id == id_pizza);

        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        public static void Delete(int id_pizza )
        {
            // en este caso uso, var como tipo
            // y no Pizza porque el valor devuelto por Get(id_pizza)
            // podria ser null, debido a la declaracion del tipo devuelto
            // public static Pizza? Get(int id_pizza)
            var pizza_tmp = Get(id_pizza);

            if (pizza_tmp == null)
            {
                return;
            }

            Pizzas.Remove(pizza_tmp);

        }


        public static void Update(Pizza pizza_tmp )
        {
            int id_tmp = Pizzas.FindIndex(p => p.Id == pizza_tmp.Id );
            if(id_tmp == -1)
            {
                return;
            }
            Pizzas[id_tmp] = pizza_tmp;


        }






    }
}

