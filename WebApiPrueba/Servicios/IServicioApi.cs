using WebApiPrueba.Models;

namespace WebApiPrueba.Servicios
{
    public interface IServicioApi
    {
        Task<List<Post>> Lista();
        Task<Post> Obtener(int id);
    }
}
