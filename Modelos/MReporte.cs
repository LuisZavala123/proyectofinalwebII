using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectofinalwebII
{
    public class MReporte
    {
        public string Tipo { get; set; }
        public int Cantidad { get; set; }
        public Double Total { get; set; }

        public MReporte()
        {
        }

        public MReporte(string tipo, int cantidad, double total)
        {
            Tipo = tipo;
            Cantidad = cantidad;
            Total = total;
        }
    }
}