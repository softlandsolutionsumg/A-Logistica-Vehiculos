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

        string stef2;
        string stef3;
        public frm_mantenimiento()
        {
            X = Propp.X;
            Y = Propp.Y;
            InitializeComponent();
        }

        private void frm_mantenimiento_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
            actualizar();
            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select cod_vehiculo, placa_vehiculo from tbt_vehiculo";


            cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_eliminar.ValueMember = "cod_vehiculo";
            cmb_eliminar.DisplayMember = "placa_vehiculo";
        }



        public void actualizar()
        {



            i3nRiqJson x = new i3nRiqJson();
           // SELECT  tbt_mantenimiento_vehiculo.fecha as Fecha, tbt_mantenimiento_vehiculo.motivo as Motivo, tbt_vehiculo. placa_vehiculo as Vehiculo from tbt_mantenimiento_vehiculo,tbt_vehiculo where tbt_mantenimiento_vehiculo.cod_vehiculo = tbt_vehiculo.cod_vehiculo";
           // string query = "select fecha, motivo from tbt_mantenimiento_vehiculo";
           string query = "SELECT  tbt_mantenimiento_vehiculo.fecha as Fecha, tbt_mantenimiento_vehiculo.motivo as Motivo, tbt_vehiculo. placa_vehiculo as Vehiculo from tbt_mantenimiento_vehiculo,tbt_vehiculo where tbt_mantenimiento_vehiculo.cod_vehiculo = tbt_vehiculo.cod_vehiculo";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query)));



            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select cod_vehiculo, placa_vehiculo from tbt_vehiculo";


            cmb_vehiculo.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_vehiculo.ValueMember = "cod_vehiculo";
            cmb_vehiculo.DisplayMember = "placa_vehiculo";


          /*  dataGridView1.DataSource = db.consulta_DataGridView("SELECT * FROM tbt_mantenimiento_vehiculo");
            dataGridView1.Columns[1].HeaderText = "Fecha ";
            dataGridView1.Columns[2].HeaderText = "Motivo";
            dataGridView1.Columns[3].HeaderText = "Codigo vehiculo";
            this.dataGridView1.Columns[0].Visible = false;
            //this.dataGridView1.Columns[4].Visible = false;*/



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
                string query4 = "select cod_vehiculo, placa_vehiculo  from tbt_vehiculo where placa_vehiculo='" + cmb_vehiculo.Text + "'";
                System.Collections.ArrayList array = x4.consultar(query4);



                foreach (Dictionary<string, string> dic in array)
                {
                    stef = (dic["cod_vehiculo"] + "\n");

                }
                dict.Add("cod_vehiculo", stef);


                i3nRiqJson x = new i3nRiqJson();
                x.insertar("1", tabla, dict);
                MessageBox.Show("Datos ingresados en mantenimiento " + i3nRiqJson.RespuestaConexion.ToString());


                i3nRiqJson x2 = new i3nRiqJson();

                string query2 = "select cod_vehiculo, placa_vehiculo from tbt_vehiculo";


                cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
                cmb_eliminar.ValueMember = "cod_vehiculo";
                cmb_eliminar.DisplayMember = "placa_vehiculo";

                actualizar();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txttotal.ReadOnly = false;
            txttotal.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ingresovehiculo();
            txttotal.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            i3nRiqJson x3 = new i3nRiqJson();
            string query = "select cod_vehiculo from tbt_vehiculo where placa_vehiculo='" + cmb_eliminar.Text + "'";
            System.Collections.ArrayList array = x3.consultar(query);

            foreach (Dictionary<string, string> dic in array)
            {
                stef2 = (dic["cod_vehiculo"] + "\n");
                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }



            textBox1.Text = stef2;

            i3nRiqJson x4 = new i3nRiqJson();
            string query2 = "select idtbt_mantenimiento_vehiculo from tbt_mantenimiento_vehiculo where cod_vehiculo='" + textBox1.Text + "'";
            System.Collections.ArrayList array2 = x4.consultar(query2);

            foreach (Dictionary<string, string> dic in array2)
            {
                stef3 = (dic["idtbt_mantenimiento_vehiculo"] + "\n");

                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }


            textBox2.Text = stef3;



            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbt_mantenimiento_vehiculo";
            string condicion = "idtbt_mantenimiento_vehiculo=" + stef3;

            //string condicion = "idtbt_ingreso_vehiculo=" + id;
            x.eliminar("4", tabla, condicion);
            MessageBox.Show("Dato eliminado de mantenimiento " + i3nRiqJson.RespuestaConexion.ToString());

            //ºº  x.eliminar("4", "tbt_bancos", condicion);


            actualizar();

            
                
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            i3nRiqJson x3 = new i3nRiqJson();
            string query = "select cod_vehiculo from tbt_vehiculo where placa_vehiculo='" + cmb_eliminar.Text + "'";
            System.Collections.ArrayList array = x3.consultar(query);

            foreach (Dictionary<string, string> dic in array)
            {
                stef2 = (dic["cod_vehiculo"] + "\n");
                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }



            textBox1.Text = stef2;

            i3nRiqJson x4 = new i3nRiqJson();
            string query2 = "select idtbt_mantenimiento_vehiculo from tbt_mantenimiento_vehiculo where cod_vehiculo='" + textBox1.Text + "'";
            System.Collections.ArrayList array2 = x4.consultar(query2);

            foreach (Dictionary<string, string> dic in array2)
            {
                stef3 = (dic["idtbt_mantenimiento_vehiculo"] + "\n");

                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }


            textBox2.Text = stef3;



            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbt_mantenimiento_vehiculo";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("fecha", dtpfecha.Value.Date.ToString("yyyy-MM-dd HH:mm"));
            dict.Add("motivo", txttotal.Text);



            i3nRiqJson x5 = new i3nRiqJson();
            string query5 = "select cod_vehiculo from tbt_vehiculo where placa_vehiculo='" + cmb_vehiculo.Text + "'";
            System.Collections.ArrayList array5 = x5.consultar(query5);



            foreach (Dictionary<string, string> dic in array5)
            {
                stef = (dic["cod_vehiculo"] + "\n");

            }
            dict.Add("cod_vehiculo", stef);





            string condicion = "idtbt_mantenimiento_vehiculo=" + stef3;

            x.actualizar("3", tabla, dict, condicion);
            txttotal.Text = "";
            actualizar();

            MessageBox.Show("Datos editados en mantenimiento de vehiculos",
        "Editar vehiculos",
        MessageBoxButtons.OK);

            actualizar();

            
                

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            actualizar();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            i3nRiqJson x3 = new i3nRiqJson();
            string query = "select cod_vehiculo from tbt_vehiculo where placa_vehiculo='" + cmb_eliminar.Text + "'";
            System.Collections.ArrayList array = x3.consultar(query);

            foreach (Dictionary<string, string> dic in array)
            {
                stef2 = (dic["cod_vehiculo"] + "\n");
                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }



            textBox1.Text = stef2;

            i3nRiqJson x4 = new i3nRiqJson();
            string query2 = "select idtbt_mantenimiento_vehiculo from tbt_mantenimiento_vehiculo where cod_vehiculo='" + textBox1.Text + "'";
            System.Collections.ArrayList array2 = x4.consultar(query2);

            foreach (Dictionary<string, string> dic in array2)
            {
                stef3 = (dic["idtbt_mantenimiento_vehiculo"] + "\n");

                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }


            textBox2.Text = stef3;

            dataGridView1.DataSource = db.consulta_DataGridView("select *from tbt_mantenimiento_vehiculo where idtbt_mantenimiento_vehiculo =" + stef3 + ";");
        }






    }
}
