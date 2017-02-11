using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoclubAPI.Models.EF.Views.Base;

namespace VideoclubAPI.Models.EF.Views
{
    public class ClienteViewModel : IViewModel<Cliente>
    {
        public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        //Externas al Modelo
        public List<PeliculaViewModel> PeliculasCliente { get; set; }

        public void FromModel(Cliente model)
        {
            idCliente = model.idCliente;
            Nombre = model.Nombre;
            Apellidos = model.Apellidos;

            try
            {
                var temp = new List<PeliculaViewModel>();
                foreach (var pelicula in model.Pelicula)
                {
                    var temp1 = new PeliculaViewModel();
                    temp1.FromModel(pelicula);
                    temp.Add(temp1);
                }
                PeliculasCliente = temp;
            }
            catch (Exception)
            {
                PeliculasCliente = null;
            }
        }

        public int[] GetPk()
        {
            return new[] { idCliente };
        }

        public Cliente ToModel()
        {
            return new Cliente
            {
                idCliente = idCliente,
                Nombre = Nombre,
                Apellidos = Apellidos
            };
        }

        public void UpdateModel(Cliente model)
        {
            model.idCliente = idCliente;
            model.Nombre = Nombre;
            model.Apellidos = Apellidos;
        }
    }
}