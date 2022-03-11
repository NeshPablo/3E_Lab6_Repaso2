using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _3E_Lab6_Repaso2
{
    public partial class Form1 : Form
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Dato> datos = new List<Dato>();
        List<DatosCliente> DatosClient = new List<DatosCliente>();

        public Form1()
        {
            InitializeComponent();
        }
        void CargarDatosVehiculo()
        {
            FileStream stream = new FileStream("Vehiculos.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.Nombre1 = reader.ReadLine();
                vehiculo.Placa = Convert.ToInt16(reader.ReadLine());
                vehiculo.Marca = (reader.ReadLine());
                vehiculo.Modelo = Convert.ToInt16(reader.ReadLine());
                vehiculo.Color = (reader.ReadLine());
                vehiculo.PrecioPorKm = Convert.ToInt16(reader.ReadLine());
                vehiculo.krecorridos = Convert.ToInt16(reader.ReadLine());

                vehiculos.Add(vehiculo);
            }
            reader.Close();
        }
        void CargarDatosClientes()
        {
            FileStream stream = new FileStream("Clientes.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Dato dato = new Dato();
                dato.Nit = Convert.ToInt16(reader.ReadLine());
                dato.Nombre = reader.ReadLine();
                dato.Direccion = reader.ReadLine();
                dato.Fechaalquiler = reader.ReadLine();
                dato.Fechadevolucion = reader.ReadLine();
                dato.krecorridos = Convert.ToInt16(reader.ReadLine());

                datos.Add(dato);
            }
            reader.Close();
        }
        void CargarGrid()
        {

            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = vehiculos;
            dataGridView2.Refresh();

        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            CargarDatosVehiculo();
            CargarDatosClientes();
           
         
        }

        private void btn_mostrar_Click(object sender, EventArgs e)
        {
            CargarGrid();
            for (int i = 0; i < datos.Count; i++)
            {
                for (int j = 0; j < vehiculos.Count; j++)
                {
                    if (vehiculos[i].Nombre1 == datos[j].Nombre)
                    {
                        DatosCliente cliente = new DatosCliente();
                        cliente.Name = datos[i].Nombre;
                        cliente.Placa = vehiculos[j].Placa;
                        cliente.Marca = vehiculos[j].Marca;
                        cliente.Modelo = vehiculos[j].Modelo;
                        cliente.Color = vehiculos[j].Color;
                        cliente.Fechadev = datos[i].Fechadevolucion;
                        cliente.PagoTotal = datos[i].krecorridos * vehiculos[j].PrecioPorKm;

                        DatosClient.Add(cliente);

                    }
                }
            }
        
            dataGridView1.DataSource = DatosClient;
            dataGridView1.Refresh();
        }
    }
}
