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
        List<Vehiculo> vehiculos1 = new List<Vehiculo>();

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
                vehiculo.Placa = Convert.ToInt16(reader.ReadLine());
                vehiculo.Marca = (reader.ReadLine());
                vehiculo.Modelo = Convert.ToInt16(reader.ReadLine());
                vehiculo.Color = (reader.ReadLine());
                vehiculo.PrecioKilometro = Convert.ToInt16(reader.ReadLine());
                
                vehiculos1.Add(vehiculo);
            }
            reader.Close();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {

        }
    }
}
