using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicePix.In.Model;
using ServicePix.In.Repositorio;
using ServicePix.Repositorio;

namespace ServicePix.In.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ParametroController : ControllerBase
    {
        IBase<Parametro> rep = new Base<Parametro>();

        [HttpGet]
        public IEnumerable<Parametro> GetAll()
        {
            return rep.GetAll().Where(x => x.Ativo == true).ToList();
        }

        // GET api/<AcaoController>/5
        [HttpGet("{id}")]
        public Parametro Get(int id)
        {
            return rep.GetSingle(x => x.ID == id);
        }

        // POST api/<AcaoController>
        [HttpPost]
        public void Post([FromBody]Parametro value)
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
            var acao = rep.GetSingle(x => x.ID == id);
            rep.Remove(acao);
        }
    }
}
