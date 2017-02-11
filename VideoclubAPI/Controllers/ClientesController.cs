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
    public class ClientesController : ApiController
    {
        [Dependency]
        public RepositorioCliente _repoCliente { get; set; }

        // GET: api/Clientes
        public IEnumerable<ClienteViewModel> Get()
        {
            return _repoCliente.Get();
        }

        // GET: api/Clientes/5
        public ClienteViewModel Get(int id)
        {
            return _repoCliente.Get(id);
        }

        // POST: api/Clientes
        public void Post([FromBody] ClienteViewModel modelo)
        {
            _repoCliente.Add(modelo);
        }

        // PUT: api/Clientes/5
        public void Put([FromBody] ClienteViewModel modeloActualizar)
        {
            _repoCliente.Update(modeloActualizar);
        }

        // DELETE: api/Clientes/5
        public void Delete(int idCliente)
        {
            _repoCliente.Delete(idCliente);
        }
    }
}
