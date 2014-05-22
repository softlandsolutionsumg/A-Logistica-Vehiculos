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
using System.Net;
using System.IO;

using System.Collections;

namespace Comercial_Solutions.Forms.Areas.Logistica
{
    public partial class frm_mantenimiento : Form
    {
        int inteditmode = 0;
        i3nRiqJson db = new i3nRiqJson();
        int X = 0;
        int Y = 0;
        string stef;
        string EditCod = "";
        bool editar = false;
        string id;
        public frm_mantenimiento()
        {
            X = Propp.X;
            Y = Propp.Y;
            InitializeComponent();
        }


        public void actualizar()
        {



            i3nRiqJson x = new i3nRiqJson();
            string query = "select fecha, motivo from tbt_mantenimiento_vehiculo";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query)));



            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select cod_vehiculo,modelo_vehiculo from tbt_vehiculo";


            cmb_vehiculo.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_vehiculo.ValueMember = "cod_vehiculo";
            cmb_vehiculo.DisplayMember = "modelo_vehiculo";


        }

        public void ingresovehiculo()
        {

            if ((txttotal.Text.Equals("")))
            {

                MessageBox.Show("Algun campo esta vacio");
            }
            else
            {

                string tabla = "tbt_mantenimiento_vehiculo";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("fecha", dtpfecha.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                dict.Add("motivo", txttotal.Text);

                i3nRiqJson x4 = new i3nRiqJson();
                string query4 = "select cod_vehiculo from tbt_vehiculo where modelo_vehiculo='" + cmb_vehiculo.Text + "'";
                System.Collections.ArrayList array = x4.consultar(query4);



                foreach (Dictionary<string, string> dic in array)
                {
                    stef = (dic["cod_vehiculo"] + "\n");

                }
                dict.Add("tbt_vehiculo_cod_vehiculo", stef);


                i3nRiqJson x = new i3nRiqJson();
                x.insertar("1", tabla, dict);
                MessageBox.Show("Datos ingresados de vehiculo " + i3nRiqJson.RespuestaConexion.ToString());
            }
        }

 
        private void frm_mantenimiento_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
            actualizar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ingresovehiculo();
        }
    }
}
