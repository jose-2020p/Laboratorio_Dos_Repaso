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
        List<Alquiler> alquiler_carro = new List<Alquiler>();
        public Form1()
        {
            InitializeComponent();
        }
        void cargar_datos_Combobox() {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DVDDOS;
            dataGridView1.Refresh();

            comboBox1.DisplayMember = "Marca";
            comboBox1.ValueMember = "Precio_kilometro";
            comboBox1.DataSource = null;
            comboBox1.DataSource = DVDDOS;
            comboBox1.Refresh();

        }
        void leerdatos() {
            FileStream canal = new FileStream("Hoja_de_vehiculos.txt", FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader(canal);

            while (leer.Peek() > -1) {
                DATOS_VEHICULO vehiculotemp = new DATOS_VEHICULO();
                vehiculotemp.Numero_de_vehiculo = Convert.ToInt32(leer.ReadLine());
                vehiculotemp.Placa = leer.ReadLine();
                vehiculotemp.Marca = leer.ReadLine();
                vehiculotemp.Modelo = leer.ReadLine();
                vehiculotemp.Color = leer.ReadLine();
                vehiculotemp.Precio_kilometro = double.Parse(leer.ReadLine());
                DVDDOS.Add(vehiculotemp);
            }
            leer.Close();
        }
        void guardar_alquiler() {
            int valor_combo = Convert.ToInt32(comboBox1.SelectedValue);

            Alquiler alquitempo = new Alquiler();
            alquitempo.Nit = Convert.ToInt32(textBox1.Text);
            alquitempo.Nombre_cliente = textBox2.Text;
            alquitempo.Direccion = textBox3.Text;
            alquitempo.Datos_auto = comboBox1.Text;
            alquitempo.Dia_alquiler = monthCalendar1.TodayDate;
            alquitempo.Devolucion = monthCalendar1.SelectionStart;
            alquitempo.Total_kilometros = double.Parse(textBox4.Text);
            alquitempo.Total_a_pagar = valor_combo * alquitempo.Total_kilometros;
            alquiler_carro.Add(alquitempo);
        }
        void escribir_alquiler()
        {
            FileStream canal = new FileStream("Hoja_Alquiler.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter acceso = new StreamWriter(canal);
            foreach (var p in alquiler_carro)
            {
                acceso.WriteLine(p.Nit);
                acceso.WriteLine(p.Nombre_cliente);
                acceso.WriteLine(p.Direccion);
                acceso.WriteLine(p.Datos_auto);
                acceso.WriteLine(p.Dia_alquiler);
                acceso.WriteLine(p.Devolucion);
                acceso.WriteLine(p.Total_kilometros);
                acceso.WriteLine(p.Total_a_pagar);
            }
            acceso.Close();
        }
        void mostrar_alquiler (){
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = alquiler_carro;
            dataGridView2.Refresh();
        }

        void leer_alquiler() {
            FileStream abrir = new FileStream("Hoja_Alquiler.txt", FileMode.Open, FileAccess.Read);
            StreamReader leerr = new StreamReader(abrir);
            while (leerr.Peek() > -1) {
                Alquiler alquitempo = new Alquiler();
                alquitempo.Nit = Convert.ToInt32(leerr.ReadLine());
                alquitempo.Nombre_cliente = leerr.ReadLine();
                alquitempo.Direccion = leerr.ReadLine();
                alquitempo.Datos_auto = leerr.ReadLine();
                alquitempo.Dia_alquiler = Convert.ToDateTime(leerr.ReadLine());
                alquitempo.Devolucion = Convert.ToDateTime(leerr.ReadLine());
                alquitempo.Total_kilometros = double.Parse(leerr.ReadLine());
                alquitempo.Total_a_pagar = double.Parse(leerr.ReadLine());
                alquiler_carro.Add(alquitempo);
            }
            leerr.Close();
        }
        void mayor_kilometros() {
            double mayor = alquiler_carro.Max(k => k.Total_kilometros);
            label8.Text = "El recorrido mas largo por un auto fue de "+mayor+" kilometros";
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
            leer_alquiler();
            mostrar_alquiler();
            mayor_kilometros();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.SelectedIndex > -1)
            {
                guardar_alquiler();
                escribir_alquiler();
                mostrar_alquiler();


            }
            else {
                MessageBox.Show("Complete los campos");
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = -1;
            mayor_kilometros();
        }

    }
}
