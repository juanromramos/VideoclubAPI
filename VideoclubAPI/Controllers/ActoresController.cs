using VideoclubAPI.Models.EF.Views;
using VideoclubAPI.Repositorio;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoclubAPI.Repositorio.Base;
using VideoclubAPI.Models.EF;
using System.Diagnostics;

namespace VideoclubAPI.Controllers
{
    public class ActoresController : ApiController
    {
        [Dependency]
        public RepositorioActor _repoActor { get; set; }

        [Dependency]
        public RepositorioPelicula _repoPelicula { get; set; }

        // GET: api/Actores
        public IEnumerable<ActorViewModel> Get()
        {
            return _repoActor.Get();
        }

        // GET: api/Actores/7
        public ActorViewModel Get(int id)
        {
            var actor = _repoActor.Get(id);
            actor.PeliculasActor = _repoPelicula.ObtenerPeliculasPorActor(actor.idActor);
            return actor;
            //return _repoActor.Get(id);
            //sobra porque no queremos el listado de películas de un actor
            //en la vista detalle del actor
            //actor.Peliculas = _repoPelicula.ObtenerPeliculasPorActor(actor.idActor);
        }

        // POST: api/Actores
        public void Post([FromBody] ActorViewModel modelo)
        {
            _repoActor.Add(modelo);
        }

        // PUT: api/Actores/5
        public void Put([FromBody] ActorViewModel modeloActualizar)
        {
            _repoActor.Update(modeloActualizar);
        }

        // DELETE: api/Actores/5
        public void Delete(int id)
        {
            _repoActor.Delete(id);
        }

        [HttpGet]
        public List<ActorViewModel> BuscarActores(string busqueda)
        {
            return _repoActor.Find(bd =>
            bd.Nombre.ToLower().Contains(busqueda.ToLower())
            || bd.Apellidos.ToLower().Contains(busqueda.ToLower()));
        }
    }
}
