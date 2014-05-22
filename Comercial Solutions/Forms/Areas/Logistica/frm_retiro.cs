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
    public partial class frm_retiro : Form
    {
        int inteditmode = 0;
        i3nRiqJson db = new i3nRiqJson();
        int X = 0;
        int Y = 0;
        string stef;
        string EditCod = "";
        bool editar = false;
        string id;
        public frm_retiro()
        {
            X = Propp.X;
            Y = Propp.Y;
            InitializeComponent();
        }
        public void actualizar()
        {



            i3nRiqJson x = new i3nRiqJson();
            string query = "select causa, fecha from retiro_vehiculo";
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

                string tabla = "retiro_vehiculo";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("fecha", dtpfecha.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                dict.Add("causa", txttotal.Text);

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





        private void frm_retiro_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
            actualizar();

            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select idretiro_vehiculo from retiro_vehiculo";


            cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_eliminar.ValueMember = "idretiro_vehiculo";
            cmb_eliminar.DisplayMember = "idretiro_vehiculo";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ingresovehiculo();
           
            txttotal.Text = "";

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            editar = true;
            txttotal.ReadOnly = false;

            dataGridView1.DataSource = db.consulta_DataGridView("SELECT * FROM retiro_vehiculo ;");
            // cmb_vehiculo.DataSource = db.consulta_ComboBox("select cod_vehiculo, modelo_vehiculo from tbt_vehiculo;");
            // cmb_vehiculo.DisplayMember = "modelo_vehiculo";
            // cmb_vehiculo.ValueMember = "cod_vehiculo";
            this.dataGridView1.Columns[0].Visible = false;


            // int i = dataGridView1.CurrentRow.Index;
            // id = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //txttotal.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();
            string tabla = "retiro_vehiculo";
            string condicion = "idretiro_vehiculo=" + cmb_eliminar.SelectedValue;


            //string condicion = "idtbt_ingreso_vehiculo=" + id;
            x.eliminar("4", tabla, condicion);
            //ºº  x.eliminar("4", "tbt_bancos", condicion);

            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select idretiro_vehiculo from retiro_vehiculo";


            cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_eliminar.ValueMember = "idretiro_vehiculo";
            cmb_eliminar.DisplayMember = "idretiro_vehiculo";
                
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txttotal.ReadOnly = false;
            txttotal.Text = "";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            editar = true;
            txttotal.ReadOnly = false;
            int i = dataGridView1.CurrentRow.Index;
            id = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txttotal.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string busca = cmb_eliminar.SelectedValue.ToString();
            dataGridView1.DataSource = db.consulta_DataGridView("select *from retiro_vehiculo where idretiro_vehiculo =" + busca + ";");
        }
    }
}
