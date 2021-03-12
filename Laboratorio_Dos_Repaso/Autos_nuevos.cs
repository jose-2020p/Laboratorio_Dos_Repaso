using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_Dos_Repaso
{
    public partial class Ingreso_A : Form
    {
        List<DATOS_VEHICULO> vEHICULOs = new List<DATOS_VEHICULO>();
        public Ingreso_A()
        {
            InitializeComponent();
        }
        void guardar_Vehiculo()
        {
            DATOS_VEHICULO agregarVehiculo = new DATOS_VEHICULO();
            agregarVehiculo.Numero_de_vehiculo = Convert.ToInt32(textBox1.Text);
            agregarVehiculo.Placa = textBox2.Text;
            agregarVehiculo.Marca = textBox3.Text;
            agregarVehiculo.Modelo = textBox4.Text;
            agregarVehiculo.Color = textBox5.Text;
            agregarVehiculo.Precio_kilometro = double.Parse(textBox6.Text);
            vEHICULOs.Add(agregarVehiculo);
        }

        void Escribir_Vehiculo_Hoja()
        {
            FileStream canal = new FileStream("Hoja_de_vehiculos.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter escribir_en_HojaV = new StreamWriter(canal);
            foreach (var p in vEHICULOs)
            {
                escribir_en_HojaV.WriteLine(p.Numero_de_vehiculo);
                escribir_en_HojaV.WriteLine(p.Placa);
                escribir_en_HojaV.WriteLine(p.Marca);
                escribir_en_HojaV.WriteLine(p.Modelo);
                escribir_en_HojaV.WriteLine(p.Color);
                escribir_en_HojaV.WriteLine(p.Precio_kilometro);
            }
            escribir_en_HojaV.Close();
        }

        void leer_datos() {
            FileStream abrirArch = new FileStream("Hoja_de_vehiculos.txt", FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader(abrirArch);
            while (leer.Peek() > -1) {
                DATOS_VEHICULO vehiculotemp = new DATOS_VEHICULO();
                vehiculotemp.Numero_de_vehiculo = Convert.ToInt32(leer.ReadLine());
                vehiculotemp.Placa = leer.ReadLine();
                vehiculotemp.Marca = leer.ReadLine();
                vehiculotemp.Modelo = leer.ReadLine();
                vehiculotemp.Color = leer.ReadLine();
                vehiculotemp.Precio_kilometro = double.Parse(leer.ReadLine());
                vEHICULOs.Add(vehiculotemp);
            }
            leer.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" &&
                textBox4.Text != "" && textBox5.Text != "")
            {
                for (int i = 0; i < vEHICULOs.Count; i++)
                {

                    if (textBox2.Text != vEHICULOs[i].Placa)
                    {
                        guardar_Vehiculo();
                        Escribir_Vehiculo_Hoja();
                        break;
                    }
                    if (textBox2.Text == vEHICULOs[i].Placa)
                    {
                        MessageBox.Show("Datos repetido");
                    }
                }
            }
            else { 
            MessageBox.Show("Complete los campos requeridos");
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ingreso_A_Load(object sender, EventArgs e)
        {
            leer_datos();
        }
    }
}
