using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApiPrueba.Models;
using WebApiPrueba.Servicios;

namespace WebApiPrueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicioApi _servicioApi;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IServicioApi servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
            List<Post> lista = await _servicioApi.Lista();

            return View(lista);
        }
        public IActionResult ObtenerForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Obtener(int id)
        {
            Post post = new Post();
            post = await _servicioApi.Obtener(id);

            return View(post);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
