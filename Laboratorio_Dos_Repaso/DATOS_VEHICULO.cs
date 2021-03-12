using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Dos_Repaso
{
    class DATOS_VEHICULO
    {
        int numero_de_vehiculo;
        string placa;
        string marca;
        string modelo;
        string color;
        double precio_kilometro;

        public int Numero_de_vehiculo { get => numero_de_vehiculo; set => numero_de_vehiculo = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public double Precio_kilometro { get => precio_kilometro; set => precio_kilometro = value; }
    }
}
