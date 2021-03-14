using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Dos_Repaso
{
    class Alquiler
    {
        int nit;
        String nombre_cliente;
        string direccion;
        String datos_auto;
        DateTime dia_alquiler;
        DateTime devolucion;
        double total_kilometros;
        double total_a_pagar;

        public int Nit { get => nit; set => nit = value; }
        public string Nombre_cliente { get => nombre_cliente; set => nombre_cliente = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Datos_auto { get => datos_auto; set => datos_auto = value; }
        public DateTime Dia_alquiler { get => dia_alquiler; set => dia_alquiler = value; }
        public DateTime Devolucion { get => devolucion; set => devolucion = value; }
        public double Total_kilometros { get => total_kilometros; set => total_kilometros = value; }
        public double Total_a_pagar { get => total_a_pagar; set => total_a_pagar = value; }
    }
}
