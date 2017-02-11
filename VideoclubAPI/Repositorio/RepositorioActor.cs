using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoclubAPI.Models.EF;
using VideoclubAPI.Models.EF.Views;
using VideoclubAPI.Repositorio.Base;

namespace VideoclubAPI.Repositorio
{
    public class RepositorioActor : Repositorio<ActorViewModel, Actor>
    {
        public RepositorioActor_Pelicula _repoActorPelicula { get; set; }

        public RepositorioActor(pruebatajamarjrEntities context) : base(context)
        {

        }
        public List<ActorViewModel> ObtenerActoresPorPelicula(int idPelicula)
        {
            var listaIdActoresPorPelicula =
                new RepositorioActor_Pelicula(
                    new pruebatajamarjrEntities()).Find(bd => bd.idPelicula == idPelicula);

            var listaActores = new List<ActorViewModel>();

            foreach (var idActoresPorPelicula in listaIdActoresPorPelicula)
            {
                var actor = Get(idActoresPorPelicula.idActor);
                actor.SueldoActorEnPelicula = idActoresPorPelicula.Sueldo;
                listaActores.Add(actor);
            }

            return listaActores;
        }

        //Aquí se incluirá el método reescrito "Add" y "Update"
        //public override ActoresViewModel ... (ActoresViewModel model)
        public override ActorViewModel Add(ActorViewModel model)
        {
            //Al llegar a esta función acude al método "Add" original
            //en "Repositorio.cs" y lo ejecuta punto por punto
            var actor = base.Add(model);

            if (model.idPelicula != 0)
            {
                //var tablaIntermediaIncremental = new Actor_PeliculaViewModel() { idActor = actor.idActor, idPelicula = model.idPelicula, Sueldo = model.SueldoActorEnPelicula };
                //new RepositorioActor_Pelicula(new pruebatajamarjrEntities()).Add(tablaIntermediaIncremental);

                var tablaIntermediaIncremental = new Actor_PeliculaViewModel() { idActor = actor.idActor, idPelicula = model.idPelicula, Sueldo = model.SueldoActorEnPelicula };
                new RepositorioActor_Pelicula(new pruebatajamarjrEntities()).Add(tablaIntermediaIncremental);
            }

            return actor;
        }

        public override ActorViewModel Update(ActorViewModel model)
        {
            var actor = base.Update(model);

            if (model.idPelicula != 0)
            {
                //var tablaIntermediaIncremental = new Actor_PeliculaViewModel() { idActor = actor.idActor, idPelicula = model.idPelicula, Sueldo = model.SueldoActorEnPelicula };
                //new RepositorioActor_Pelicula(new pruebatajamarjrEntities()).Update(tablaIntermediaIncremental);

                var tablaIntermediaIncremental = new RepositorioActor_Pelicula(new pruebatajamarjrEntities()).Find(bd => bd.idActor == model.idActor && bd.idPelicula == model.idPelicula);
                tablaIntermediaIncremental[0].Sueldo = model.SueldoActorEnPelicula;
                new RepositorioActor_Pelicula(new pruebatajamarjrEntities()).Update(tablaIntermediaIncremental[0]);
            }

            return actor;
        }

        public override int Delete(int id)
        {
            var lista = new RepositorioActor_Pelicula(new pruebatajamarjrEntities()).Find(bd => bd.idActor == id);
            foreach (var relacion in lista)
            {
                new RepositorioActor_Pelicula(new pruebatajamarjrEntities()).Delete(relacion.idActor_Pelicula);
            }
            var actor = base.Delete(id);
            return actor;
        }
    }
}