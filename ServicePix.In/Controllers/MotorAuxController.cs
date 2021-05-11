using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServicePix.In.Model;
using ServicePix.Repositorio;
using ServicePix.In.Repositorio.Interfaces;
using ServicePix.In.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.Swagger;
using RestSharp;
using System.Net.Http;
using System;
using Microsoft.OpenApi.Readers;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi;
using ServicePix.In.Helper;

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


        [HttpPost]
        public async System.Threading.Tasks.Task PostJsonSwaggerAsync([FromBody]string swaggerDoc)
        {

            var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync(swaggerDoc);

            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var User = UserLocation.GetUserLocation(currentUser.Identity.Name);
            var openApiDocument = new OpenApiStreamReader().Read(stream, out var diagnostic);
            List<Acao> lsacao = new List<Acao>();
            foreach(var acao in openApiDocument.Paths)
            {
                List<Parametro> paramsls = new List<Parametro>();
                int ordem = 0;
                foreach (var param in acao.Value.Operations[0].Parameters)
                {
                   
                    //Type Get
                    Parametro objParam = new Parametro
                    {
                        Ativo = true,
                        DataCriacao = DateTime.Now,
                        DateAlteracao = DateTime.Now,
                        Descricao = "",
                        idCliente = 0,
                        Nome = param.Name,
                        Ordem = ordem++,
                        Status = 1,
                        Tipo = "param",
                        UsuarioCriacao = User.Id,
                        UsuarioEdicao = User.Id
                    };
                    paramsls.Add(objParam);
                }
                if(acao.Value.Operations[0].RequestBody != null)
                {
                    foreach (var param in acao.Value.Operations[0].RequestBody.Content)
                    {

                        //Type Get
                        Parametro objParam = new Parametro
                        {
                            Ativo = true,
                            DataCriacao = DateTime.Now,
                            DateAlteracao = DateTime.Now,
                            Descricao = "",
                            idCliente = 0,
                            Nome = acao.Value.Operations[0].Description,
                            Ordem = ordem++,
                            Status = 1,
                            Tipo = "body",
                            UsuarioCriacao = User.Id,
                            UsuarioEdicao = User.Id
                        };
                        paramsls.Add(objParam);
                    }
                }
                Acao obj = new Acao
                {
                    Ativo = true,
                    Caminho = acao.Key,
                    DataCriacao = DateTime.Now,
                    DateAlteracao = DateTime.Now,
                    Descricao = "",
                    Nome = acao.Value.Operations[0].Summary,
                    idCliente = 0,
                    parametro = paramsls,
                    Status = 1,
                    UsuarioCriacao = User.Id,
                    UsuarioEdicao = User.Id,
                    idTipoAcao = 3
                };
                lsacao.Add(obj);
            }

            MotorAuxiliar motor = new MotorAuxiliar
            {
                acao = lsacao,
                Ativo = true,
                UsuarioEdicao = User.Id,
                DataCriacao = DateTime.Now,
                DateAlteracao = DateTime.Now,
                Descricao = "",
                idCliente = 0,
                Nome = "In",
                Status = 1,
                Url = "http://localhost:5000",
                UsuarioCriacao = User.Id
            };
        }
    }
}
