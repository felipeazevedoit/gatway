using ServicePix.In.Model;
using ServicePix.In.Repositorio;
using ServicePix.In.Repositorio.Interfaces;
using ServicePix.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePix.In.Helper
{
    public static class UserLocation
    {
        public static User GetUserLocation(string login)
        {
            IBase<User> rep = new Base<User>();
            return rep.GetSingle(x => x.Username == login);
        }
    }
}
