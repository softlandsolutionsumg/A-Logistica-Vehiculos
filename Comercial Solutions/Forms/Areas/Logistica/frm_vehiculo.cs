using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comercial_Solutions.Clases;
using i3nRiqJSON;

namespace Comercial_Solutions.Forms.Areas.Logistica
{
    public partial class frm_vehiculo : Form

    {
        int inteditmode = 0;
        i3nRiqJson db = new i3nRiqJson();
        int X = 0;
        int Y = 0;
        public frm_vehiculo()
        {
            X = Propp.X;
            Y = Propp.Y;
            InitializeComponent();
        }

        private void frm_vehiculo_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
        }
        public void combovehiculo(string tipo)
        {

            string query = "";
            try
            {
                if (tipo.Equals("1"))
                {

                    query = "select modelo_vehiculo as Modelo, cilindros_vehiculo as Cilindros, puertas_vehiculo as Puertas, nochasis_vehiculo as Nochasis, nollantas_vehiculo as Nollantas, placa_vehiculo as Placa, capacidad as Capacidad, tx_marca as Marca from tbt_vehiculos ";

                }
             
                dataGridView1.DataSource = (db.consulta_DataGridView(query));
                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 42;
                dataGridView1.Columns[3].Width = 42;
                dataGridView1.Columns[4].Width = 42;
                dataGridView1.Columns[5].Width = 42;
                dataGridView1.Columns[6].Width = 42;
                dataGridView1.Columns[7].Width = 42;
            }
            catch (Exception e)
            {


            }
        }
        public int verificarprev()
        {
            string query = "select modelo_vehiculo from tbt_vehiculos where modelo_vehiculo='" + txtmodelo.Text + "'";
            System.Collections.ArrayList array = db.consultar(query);
            int intamanoarray = array.Count;

            return intamanoarray;
        }

         public void guardarvehiculo()
        {

            if ((txtmodelo.Text.Equals("")) || (txtcilindros.Text.Equals("")) || (txtpuertas.Text.Equals("")) || (txtchasis.Text.Equals("")) || (txtllantas.Text.Equals("")) || (txtplaca.Text.Equals("")) || (txtcapacidad.Text.Equals("")) || (txtmarca.Text.Equals("")))
            {

                MessageBox.Show("Ingrese todos los datos requeridos");

            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Desea realizar el registro", "Registro de vehiculos", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string tabla = "tbt_vehiculo";
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("modelo_vehiculo", txtmodelo.Text);
                    dict.Add("cilindros_vehiculo", txtcilindros.Text);
                    dict.Add("puertas_vehiculo",txtpuertas.Text);
                    dict.Add("nochasis_vehiculo", txtchasis.Text);
                    dict.Add("nollantas_vehiculo", txtllantas.Text);
                    dict.Add("placa_vehiculo", txtplaca.Text);
                    dict.Add("capacidad", txtcapacidad.Text);
                    dict.Add("tx_marca", txtmarca.Text);
               
                    db.insertar("1", tabla, dict);
                    if (i3nRiqJson.RespuestaConexion.ToString().Equals("0"))
                    {
                        MessageBox.Show("Registro Realizado exitosamente");
                      //  Resetear();
                    }
                    else
                    {

                        MessageBox.Show("Registro no se ah realizado consulte con su administrador");

                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                }
        }
            

             
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
            if (inteditmode == 0)
            {
                if (verificarprev() == 0) {
                     guardarvehiculo();
                    txtmodelo.Text ="";
                     txtcilindros.Text="";
                   txtpuertas.Text="";
                   txtchasis.Text="";
                     txtllantas.Text="";
                    txtplaca.Text="";
                   txtcapacidad.Text="";
                     txtmarca.Text="";
               
 
                }
                else
                {
                    MessageBox.Show("Ya existe un modelo con ese nombre");
                    txtmodelo.Text = "";
                }
            }
            else
            {
                try
                {
                   
                }
                catch (Exception f)
                {
                    MessageBox.Show("Los cambios no se guardaron");

                }
            }

        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
