using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UsersAccess
    {
        public bool TestConnection()
        {
            using (var db = new BaseUsuariosEntities())
            {
                DbConnection conn = db.Database.Connection;
                try
                {
                    conn.Open();   // check the database connection
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public Users ListarUnUsuario()
        {
            BaseUsuariosEntities db = new BaseUsuariosEntities();
            Users usuario;
            usuario = (from users in db.Users select users).First();
            return usuario;
        }
        public List<Users> ListarUsuarios()
        {
            BaseUsuariosEntities db = new BaseUsuariosEntities();
            List<Users> usuariosList = (from users in db.Users select users).ToList();
            return usuariosList;
        }
    }
}
