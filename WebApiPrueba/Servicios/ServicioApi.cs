using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebApiPrueba.Models;

namespace WebApiPrueba.Servicios
{
    public class ServicioApi : IServicioApi
    {
        private static string _baseurl;

        public ServicioApi() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<List<Post>> Lista()
        {
            List<Post> lista = new List<Post>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Post>>(json_respuesta);
                lista = resultado;
            }
            return lista;
        }

        public async Task<Post> Obtener(int id)
        {
            Post post = new Post();
            var client = new HttpClient();
            var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Post>(json_respuesta);
                post = resultado;
            }
            return post;
        }
    }
}
