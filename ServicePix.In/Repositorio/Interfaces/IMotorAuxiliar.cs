using ServicePix.In.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePix.In.Repositorio.Interfaces
{
    interface IMotorAuxiliar
    {
        MotorAuxiliar GetMotorAuxiliar(string id);
    }
}
