using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Model;

namespace DAL.Persistence
{
    public class LoginDAL : Conexao
    {
        public bool AbreLogin(string Nome, string Email)
        {
            try
            {
                if (AbreConexao())
                {
                    Cmd = new SqlCommand("select * from Admin where (Nome=@nome and Email=@email)", Con);
                    Cmd.Parameters.AddWithValue("@nome", Nome);
                    Cmd.Parameters.AddWithValue("@email", Email);

                    Dr = Cmd.ExecuteReader();
                    


                    
                    if (Dr.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                FechaConexao();
            }
        }
    }
}
