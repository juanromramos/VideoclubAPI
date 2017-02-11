using VideoclubAPI.Models.EF.Views;
using VideoclubAPI.Repositorio;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VideoclubAPI.Controllers
{
    public class PeliculasController : ApiController
    {
        [Dependency]
        //public Repositorio<PeliculaViewModel, Pelicula> _repoPelicula { get; set; }
        // !!!! si en UnityConfig nos hemos 'ahorrado' la clase RepositorioPelicula
        public RepositorioPelicula _repoPelicula { get; set; }

        [Dependency]
        public RepositorioActor _repoActor { get; set; }

        // GET: api/Peliculas
        public IEnumerable<PeliculaViewModel> Get()
        {
            return _repoPelicula.Get();
        }

        // GET: api/Peliculas/7
        public PeliculaViewModel Get(int id)
        //El parámetro debe tener el mismo nombre que aparece
        //en su ruta en "Web.config"
        {
            var pelicula = _repoPelicula.Get(id);
            pelicula.ActoresPelicula = _repoActor.ObtenerActoresPorPelicula(pelicula.idPelicula);
            return pelicula;
        }

        // POST: api/Peliculas
        public void Post([FromBody] PeliculaViewModel mimodelo)
        {
            _repoPelicula.Add(mimodelo);
        }

        // PUT: api/Peliculas/5
        public void Put([FromBody] PeliculaViewModel modeloActualizar)
        {
            _repoPelicula.Update(modeloActualizar);
        }

        // DELETE: api/Peliculas/5
        public void Delete(int id)
        {
            _repoPelicula.Delete(id);
        }

        [HttpGet]
        public List<PeliculaViewModel> PeliculasLibres(string peliculasSinALquilar)
        {
            return _repoPelicula.Find(bd => bd.idCliente == null);
        }

        [HttpGet]
        public List<PeliculaViewModel> BuscarPeliculas(string txtBusquedaPelicula, string anoPelicula)
        {
            //Recibe dos parámetros, la cadena del
            //cuadro de búsqueda y el año seleccionado
            var anoPeli = Convert.ToInt32(anoPelicula);

            //Si recibe "anoPelicula" y "txtBusquedaPelicula"
            if (!string.IsNullOrEmpty(anoPelicula) && !string.IsNullOrEmpty(txtBusquedaPelicula))
                return _repoPelicula.Find(bd => bd.Ano == anoPeli && bd.Nombre.ToLower().Contains(txtBusquedaPelicula.ToLower()));

            //Si solamente recibe "anoPelicula"
            if (!string.IsNullOrEmpty(anoPelicula))
                return _repoPelicula.Find(bd => bd.Ano == anoPeli);

            return _repoPelicula.Find(bd => bd.Nombre.ToLower().Contains(txtBusquedaPelicula.ToLower()));
        }
    }
}
