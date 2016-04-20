using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;
using DAL.Persistence;

namespace Site
{
    public partial class Master : System.Web.UI.MasterPage
    {
        LoginDAL lgDAL;
        DAL.Model.Login lg;
        protected void Page_Load(object sender, EventArgs e)
        {
           if(Session["username"] == null)
            {
                //Response.Redirect("/Pages/Default.aspx");
                label1.Text = "";
                loginName.Visible = true;
                loginEmail.Visible = true;
                btnLogin.Visible = true;
                btnDeslogar.Visible = false;


            }
            else
            {
                loginName.Visible = false;
                loginEmail.Visible = false;
                btnLogin.Visible = false;
                btnDeslogar.Visible = true;
                label1.Text = Session["username"].ToString();
            }
        }

        protected void logarClick(object sender, EventArgs e)
        {
            try
            {
                lg = new DAL.Model.Login();
                lgDAL = new LoginDAL();

                lg.Email = loginEmail.Text;
                lg.Nome = loginName.Text;

                if (lgDAL.AbreLogin(loginName.Text, loginEmail.Text))
                {
                    Session["username"] = loginName.Text;
                    Response.Redirect("/Pages/Controle.aspx", false);
                }
                else
                {
                    label1.Text = "Dados incorretos";
                }
            }
            catch (Exception ex)
            {

                label1.Text = ex.Message;
            }
        }

        protected void btnDeslogar_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("/Pages/Default.aspx");
        }
    }
}