using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.Persistence
{
    class UsuarioDAL : Conexao
    {

        public void Adicionar(Usuario u)
        {
            try
            {
                if (AbreConexao())
                {
                    Cmd = new SqlCommand("insert into Usuario (Nome, Email, Empresa) values (@name, @email, @empresa)", Con);
                    Cmd.Parameters.AddWithValue("name", u.Nome);
                    Cmd.Parameters.AddWithValue("email", u.Email);
                    Cmd.Parameters.AddWithValue("empresa", u.Empresa);

                    Cmd.ExecuteNonQuery();
                }
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

        public void Excluir(int Codigo)
        {
            try
            {
                if (AbreConexao())
                {
                    Cmd = new SqlCommand("delete from Usuario where Codigo=@codigo", Con);
                    Cmd.Parameters.AddWithValue("@codigo", Codigo);

                    Cmd.ExecuteNonQuery();
                }
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

        public void Atualizar(Usuario u)
        {
            try
            {
                if (AbreConexao())
                {
                    Cmd = new SqlCommand("update Usuario set Nome=@nome, Email=@email, Empresa=@empresa where Codigo=@codigo", Con);
                    Cmd.Parameters.AddWithValue("@codigo", u.Codigo);
                    Cmd.Parameters.AddWithValue("@nome", u.Nome);
                    Cmd.Parameters.AddWithValue("@email", u.Email);
                    Cmd.Parameters.AddWithValue("@empresa", u.Empresa);

                    Cmd.ExecuteNonQuery();
                }
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

        public List<Usuario> Listar()
        {
            try
            {
                if (AbreConexao())
                {
                    Cmd = new SqlCommand("select * from Usuario", Con);
                    Dr = Cmd.ExecuteReader();

                    List<Usuario> lista = new List<Usuario>();
                    Usuario u = new Usuario();

                    while (Dr.Read())
                    {
                        u.Codigo = Convert.ToInt32(Dr["Codigo"]);
                        u.Nome = Convert.ToString(Dr["Nome"]);
                        u.Email = Convert.ToString(Dr["Email"]);
                        u.Empresa = Convert.ToString(Dr["Empresa"]);

                        lista.Add(u);
                    }
                    return lista;


                }
                return null;
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
