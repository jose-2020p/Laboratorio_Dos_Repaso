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
    public partial class Form1 : Form
    {
        List<DATOS_VEHICULO> DVDDOS = new List<DATOS_VEHICULO>();
        public Form1()
        {
            InitializeComponent();
        }
        void cargar_datos_Combobox() {

            comboBox1.DataSource = null;
            comboBox1.DataSource = DVDDOS;
            comboBox1.Refresh();

            //comboBox1.DisplayMember = "DVDDOS";
            //comboBox1.ValueMember = "NoEmpleado";
            //comboBox1.DataSource = null;
            //comboBox1.DataSource = empleados;
            //comboBox1.Refresh();

            //dataGridViewAsistencia.DataSource = null;
            //dataGridViewAsistencia.DataSource = asistencias;
            //dataGridViewAsistencia.Refresh();
        }
        void leerdatos() {
            FileStream canal = new FileStream("Hoja_de_vehiculos.txt", FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader (canal);

            while (leer.Peek() > -1) {
                DATOS_VEHICULO vehiculotemp = new DATOS_VEHICULO();
                vehiculotemp.Numero_de_vehiculo = Int32.Parse(leer.ReadLine());
                vehiculotemp.Placa = leer.ReadLine();
                vehiculotemp.Marca = leer.ReadLine();
                vehiculotemp.Modelo = leer.ReadLine();
                vehiculotemp.Color = leer.ReadLine();
                vehiculotemp.Precio_kilometro = double.Parse(leer.ReadLine());
                DVDDOS.Add(vehiculotemp);
            }
            leer.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Ingreso_A AN = new Ingreso_A();
            AN.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leerdatos();
            cargar_datos_Combobox();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
