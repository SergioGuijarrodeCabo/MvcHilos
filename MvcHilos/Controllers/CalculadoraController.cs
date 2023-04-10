using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcHilos.Models;


namespace MvcHilos.Controllers
{
    public class CalculadoraController : Controller
    {
        public ListaNumeros numeros;
        public CalculadoraController()
        {
            this.numeros = new ListaNumeros();
            this.numeros.Multiplos = new List<int>();
            this.numeros.Potencias = new List<int>();
        }
        
        public ActionResult Index()
        {
            return View();
        }

      


        public void Multiplos(int num1)
        {
      
            for (int i = 0; i < 9; i++)
            {
                this.numeros.Multiplos.Add(num1 * i);
            }
         
        }

        public void Potencias(int num1)
        {
          
            for (int i = 0; i < 9; i++)
            {
                this.numeros.Potencias.Add(1);
                for (int j = 0; j < i; j++)
                {
                    this.numeros.Potencias[i] = this.numeros.Potencias[i] * num1;
                }
            }
        }


        [HttpPost]
        public ActionResult Index(int num1)
        {
            ViewData["NUMERO"] = num1;

            Thread hilo1 = new Thread(() => Multiplos(num1));
            Thread hilo2 = new Thread(() => Potencias(num1));

            hilo1.Start();
            hilo2.Start();

            return View(this.numeros);
        }
    }
}
