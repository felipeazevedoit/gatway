using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicePix.In.Model;
using ServicePix.In.Repositorio;
using ServicePix.Repositorio;
using Swashbuckle.AspNetCore.Annotations;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicePix.In.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class AcaoController : ControllerBase
    {
        IBase<Acao> rep;

        [HttpGet]
        [SwaggerOperation(Summary ="RetornarTodos")]
        public IEnumerable<Acao> RetornarTodos()
        {
            return rep.GetAll().Where(x => x.Ativo == true).ToList();
        }

        // GET api/<AcaoController>/5
        [HttpGet("{id}")]
        public Acao Get(int id)
        {
            return rep.GetSingle(x => x.ID == id);
        }

        // POST api/<AcaoController>
        [HttpPost]
        [SwaggerOperation(Summary = "RetornarTodos",Description = "Acao")]
        public void Post([FromBody] Acao value)
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
