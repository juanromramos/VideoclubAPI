using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using VideoclubAPI.Models.EF;
using VideoclubAPI.Models.EF.Views;
using VideoclubAPI.Repositorio.Base;

namespace VideoclubAPI.Repositorio
{
    public class RepositorioPelicula : Repositorio<PeliculaViewModel, Pelicula>
    {
        public RepositorioPelicula(pruebatajamarjrEntities context) : base(context)
        {

        }

        public List<PeliculaViewModel> ObtenerPeliculasPorActor(int idActor)
        {
            var listaIdPeliculasPorActor =
                new RepositorioActor_Pelicula(
                    new pruebatajamarjrEntities()).Find(bd => bd.idActor == idActor);

            var listaPeliculas = new List<PeliculaViewModel>();

            foreach (var idPeliculaPorActor in listaIdPeliculasPorActor)
            {
                var pelicula = Get(idPeliculaPorActor.idPelicula);
                listaPeliculas.Add(pelicula);
            }
            return listaPeliculas;
        }

        // Sobreescribir método "Update" para eliminar (o crear) filas en la tabla "Actor_Pelicula"
        public override PeliculaViewModel Update(PeliculaViewModel model)
        {
            var pelicula = base.Update(model);
            if (pelicula.ActoresPelicula != null)
            {
                var tablaActoresPeliculas =
                    new RepositorioActor_Pelicula(new pruebatajamarjrEntities()).Find(
                        bd => bd.idPelicula == model.idPelicula);
                List<int> listaIdActores = new List<int>();
                foreach (ActorViewModel a in pelicula.ActoresPelicula)
                {
                    listaIdActores.Add(a.idActor);
                }
                foreach (Actor_PeliculaViewModel t in tablaActoresPeliculas)
                {
                    if (listaIdActores.IndexOf(t.idActor) < 0)
                    {
                        Debug.WriteLine("JACKPOT - " + t.idActor);
                        var relacionActorPelicula =
                            new RepositorioActor_Pelicula(new pruebatajamarjrEntities()).Find(
                                bd => bd.idActor == t.idActor && bd.idPelicula == model.idPelicula);
                        new RepositorioActor_Pelicula(new pruebatajamarjrEntities()).Delete(
                            relacionActorPelicula[0].idActor_Pelicula);
                    }
                }
            }
            return pelicula;
        }

    }
}