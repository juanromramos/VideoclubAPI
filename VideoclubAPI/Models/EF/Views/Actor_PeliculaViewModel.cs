using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoclubAPI.Models.EF.Views.Base;

namespace VideoclubAPI.Models.EF.Views
{
    public class Actor_PeliculaViewModel : IViewModel<Actor_Pelicula>
    {
        public int idActor_Pelicula { get; set; }
        public int idActor { get; set; }
        public int idPelicula { get; set; }
        public int Sueldo { get; set; }
        //public virtual ActorViewModel Actor { get; set; }
        //public virtual PeliculaViewModel Pelicula { get; set; }

        public Actor_Pelicula ToModel()
        {
            return new Actor_Pelicula()
            {
                idActor_Pelicula = idActor_Pelicula,
                idActor = idActor,
                idPelicula = idPelicula,
                Sueldo = Sueldo
            };
        }

        public void FromModel(Actor_Pelicula model)
        {
            idActor_Pelicula = model.idActor_Pelicula;
            idActor = model.idActor;
            idPelicula = model.idPelicula;
            Sueldo = model.Sueldo;

            //try
            //{
            //    var temp1 = new ActorViewModel();
            //    temp1.FromModel(model.Actor);
            //    Actor = temp1;

            //    var temp2 = new PeliculaViewModel();
            //    temp2.FromModel(model.Pelicula);
            //    Pelicula = temp2;
            //}
            //catch
            //{
            //    Actor = null;
            //    Pelicula = null;
            //}
        }

        public void UpdateModel(Actor_Pelicula model)
        {
            model.idActor_Pelicula = idActor_Pelicula;
            model.idActor = idActor;
            model.idPelicula = idPelicula;
            model.Sueldo = Sueldo;
        }

        public int[] GetPk()
        {
            return new[] { idActor_Pelicula };
        }
    }
}