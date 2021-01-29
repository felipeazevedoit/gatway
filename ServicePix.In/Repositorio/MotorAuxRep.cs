using Microsoft.EntityFrameworkCore;
using ServicePix.In.Model;
using ServicePix.In.Repositorio.Interfaces;
using ServicePix.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePix.In.Repositorio
{
    public class MotorAuxRep : IMotorAuxiliar
    {
        public MotorAuxiliar GetMotorAuxiliar(string aux)
        {
            using (var context = new spContext())
            {
                var motor = context.MotorAuxiliar
                    .Include(motor => motor.acao).ThenInclude(acao => acao.parametro)
                    .ToList().Where(x => x.Nome == aux).FirstOrDefault();
                return motor;

            }
        }
    }
}
