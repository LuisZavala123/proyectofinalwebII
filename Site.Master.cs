using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectofinalwebII
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                agProducto.Visible = false;
                agUsuario.Visible = false;
                Reporte.Visible = false;
                Login.Visible = true;
            }
        }
        
    }
}