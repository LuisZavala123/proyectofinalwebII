﻿using proyectofinalwebII.DAOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectofinalwebII
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            WSArticulo.WebService1SoapClient servicio = new WSArticulo.WebService1SoapClient();
            servicio.Agregar(servicio.nId()+"",txtNombre.Text, double.Parse(txtCosto.Text), txtDescripcion.Text, CboxTipo.SelectedValue);
            Response.Redirect("Principal.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
           Response.Redirect("Principal.aspx");
        }
    }
}