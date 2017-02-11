using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoclubAPI.Models.EF.Views.Base;

namespace VideoclubAPI.Models.EF.Views
{
    public class ActorViewModel : IViewModel<Actor>
    {
        public int idActor { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        //Externas al modelo
        public int SueldoActorEnPelicula { get; set; }
        public List<PeliculaViewModel> PeliculasActor { get; set; }

        //Necesaria para el uso de MVC
        public int idPelicula { get; set; }

        public void FromModel(Actor model)
        {
            idActor = model.idActor;
            Nombre = model.Nombre;
            Apellidos = model.Apellidos;
        }

        public int[] GetPk()
        {
            return new[] { idActor };
        }

        public Actor ToModel()
        {
            return new Actor
            {
                idActor = idActor,
                Nombre = Nombre,
                Apellidos = Apellidos
            };
        }

        public void UpdateModel(Actor model)
        {
            model.idActor = idActor;
            model.Nombre = Nombre;
            model.Apellidos = Apellidos;
        }
    }
}