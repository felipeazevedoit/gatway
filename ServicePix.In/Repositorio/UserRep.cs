using ServicePix.In.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePix.In.Repositorio.Interfaces
{
    public class UserRep : IUser
    {
        public User GetUserLogin(string user, string password)
        {
            try
            {
                using (var context = new spContext())
                {
                    var retornoUser = context.User.Where(x => x.Username == user && x.Password == password).FirstOrDefault();
                    return retornoUser;

                }
            }catch(Exception e )
            {
                return null;
            }
        }
    }
}
