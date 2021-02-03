using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServicePix.In.Model;
using ServicePix.Repositorio;
using ServicePix.In.Repositorio.Interfaces;
using ServicePix.In.Repositorio;
using Microsoft.AspNetCore.Authorization;

namespace ServicePix.In.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class MotorAuxController : Controller
    {
        IBase<MotorAuxiliar> rep = new Base<MotorAuxiliar>();
        IMotorAuxiliar motorRep = new MotorAuxRep();

        [HttpGet]
        public IEnumerable<MotorAuxiliar> GetAll()
        {
            return rep.GetAll().Where(x => x.Ativo == true).ToList();
        }

        // GET api/<AcaoController>/5
        [HttpGet("{id}")]
        public MotorAuxiliar Get(int id)
        {
            return rep.GetSingle(x => x.ID == id);
        }

        // POST api/<AcaoController>
        [HttpPost]
        public void Post([FromBody] MotorAuxiliar value)
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


        [HttpGet("{aux}")]
        [ActionName("acessarmotor")]
        public MotorAuxiliar acessarmotor(string aux)
        {
            return motorRep.GetMotorAuxiliar(aux);
            
        }
    }
}
