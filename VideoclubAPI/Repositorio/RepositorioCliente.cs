using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoclubAPI.Models.EF;
using VideoclubAPI.Models.EF.Views;
using VideoclubAPI.Repositorio.Base;

namespace VideoclubAPI.Repositorio
{
    public class RepositorioCliente : Repositorio<ClienteViewModel, Cliente>
    {
        public RepositorioCliente(pruebatajamarjrEntities context) : base(context)
        {

        }

        //public ClienteViewModel ObtenerClientePorPelicula(int idCliente)
        //{
        //    var cliente = new ClienteViewModel();
        //    if (idCliente != 0)
        //    {
        //        cliente = Get(idCliente);
        //    }
        //    return cliente;
        //}
    }
}