using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicePix.In.Model;
using ServicePix.In.Repositorio;
using ServicePix.Repositorio;

namespace ServicePix.In.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        IBase<Cliente> rep = new Base<Cliente>();

        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            return rep.GetAll().Where(x => x.Ativo == true).ToList();
        }

        // GET api/<AcaoController>/5
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return rep.GetSingle(x => x.ID == id);
        }

        // POST api/<AcaoController>
        [HttpPost]
        public void Post([FromBody] Cliente value)
        {
            if (value.ID == 0)
            {
                rep.Add(value);
            }
            else
            {
                rep.Update(value);
            }
        }

        // DELETE api/<AcaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cliente = rep.GetSingle(x => x.ID == id);
            rep.Remove(cliente);
        }
    }
}
