using proyectofinalwebII.DAOS;
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
                if (Session["Usuario"] != null)
                {
                    if (Session["Usuario"].ToString().Equals("SI"))
                    {
                        agUsuario.Visible = true;
                        Reporte.Visible = true;
                        agProducto.Visible = true;
                        exit.Visible = true;
                        orden.Visible = true;
                        Login.Visible = false;
                    }
                    else {
                        agUsuario.Visible = false;
                        Reporte.Visible = false;
                        agProducto.Visible = false;
                        exit.Visible = false;
                        orden.Visible = false;
                        Login.Visible = true;
                    }
                }
                else
                {
                    agUsuario.Visible = false;
                    Reporte.Visible = false;
                    agProducto.Visible = false;
                    exit.Visible = false;
                    orden.Visible = false;
                    Login.Visible = true;
                }
            }
        }
      

    }
}