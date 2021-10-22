using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiroSite.Models
{
    public class UsuarioLoginBD
    {
        public static Response ExceptionGet(Exception e)
        {
            if (ConnectionString.Connection.State == System.Data.ConnectionState.Open)
            {
                ConnectionString.Connection.Close();
            }

            return new Response
            {
                Executed = false,
                ErrorMessage = e.Message,
                Exception = e
            };
        }

        internal static Response Select(UsuarioLogin user)
        {
            throw new NotImplementedException();
        }

        public static Response Select(string email, out UsuarioLogin user)
        {
            user = new UsuarioLogin();
            string select = $"SELECT * from dbo.Paciente WHERE Email = '{email}'";
            SqlCommand cmd = new SqlCommand(select, ConnectionString.Connection);

            try
            {
                ConnectionString.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    user.idPaciente = Convert.ToInt32(dr[0]);
                    user.Email = dr[3].ToString();
                    user.Senha = dr[4].ToString();
                }
                dr.Close();
                ConnectionString.Connection.Close();
                return new Response
                {
                    Executed = true
                };
            }
            catch (Exception e)
            {
                return ExceptionGet(e);
            }
        }

        internal static Response Select(string userName, out UsuarioCadastro user)
        {
            throw new NotImplementedException();
        }
    }
}
