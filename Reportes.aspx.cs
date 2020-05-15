using proyectofinalwebII.DAOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectofinalwebII
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                actualizar();
            }
        }
        protected void actualizar()
        {
            var nu = new VentaDAO();
            grvLista.AutoGenerateColumns = false;
            grvLista.DataSource = nu.GetAll();
            grvLista.DataBind();
        }
    }
}