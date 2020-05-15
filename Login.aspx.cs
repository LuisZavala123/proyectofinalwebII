using proyectofinalwebII.DAOS;
using proyectofinalwebII.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectofinalwebII
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            UsuarioDAO userdao = new UsuarioDAO();
            MUsuarios user = userdao.Getbycorreo(txtEmail.Text);
            if (user!=null) {
                if(user.Contraseña.Equals(BitConverter.ToString(hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(txtPassword.Text))))){
                    Response.Redirect("Principal.aspx");
                }
            }
        }
    }
}