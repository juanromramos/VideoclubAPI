using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoclubAPI.Models.EF;
using VideoclubAPI.Models.EF.Views;
using VideoclubAPI.Repositorio.Base;

namespace VideoclubAPI.Repositorio
{
    public class RepositorioActor_Pelicula : Repositorio<Actor_PeliculaViewModel, Actor_Pelicula>
    {
        public RepositorioActor_Pelicula(pruebatajamarjrEntities context) : base(context)
        {

        }
    }
}