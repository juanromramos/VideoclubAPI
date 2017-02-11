using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoclubAPI.Models.EF.Views.Base;

namespace VideoclubAPI.Models.EF.Views
{
    public class PeliculaViewModel : IViewModel<Pelicula>
    {
        public int idPelicula { get; set; }
        public string Nombre { get; set; }
        public int Ano { get; set; }
        public string Formato { get; set; }
        public string Descripcion { get; set; }
        public int? idCliente { get; set; }

        //Externas al modelo
        public List<ActorViewModel> ActoresPelicula { get; set; }

        //Necesaria para el uso de MVC
        public int idActor { get; set; }

        public void FromModel(Pelicula model)
        {
            idPelicula = model.idPelicula;
            Nombre = model.Nombre;
            Ano = model.Ano;
            Formato = model.Formato;
            Descripcion = model.Descripcion;
            idCliente = model.idCliente;
        }

        public int[] GetPk()
        {
            return new[] { idPelicula };
        }

        public Pelicula ToModel()
        {
            return new Pelicula()
            {
                idPelicula = idPelicula,
                Nombre = Nombre,
                Ano = Ano,
                Formato = Formato,
                Descripcion = Descripcion,
                idCliente = idCliente
            };
        }

        public void UpdateModel(Pelicula model)
        {
            model.idPelicula = idPelicula;
            model.Nombre = Nombre;
            model.Ano = Ano;
            model.Descripcion = Descripcion;
            model.idCliente = idCliente;
        }
    }
}