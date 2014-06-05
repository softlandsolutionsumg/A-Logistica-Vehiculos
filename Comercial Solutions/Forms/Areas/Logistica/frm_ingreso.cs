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
    public partial class frm_ingreso : Form
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
        public frm_ingreso()
        {
            X = Propp.X;
            Y = Propp.Y;

           
            InitializeComponent();
        }

        public void actualizar()
 {



  
               //  string query = "select fecha, total from tbt_ingreso_vehiculo";
                // dataGridView1.DataSource = ((x.consulta_DataGridView(query)));



                 i3nRiqJson x2 = new i3nRiqJson();

                 string query2 = "SELECT  tbt_ingreso_vehiculo.fecha as Fecha, tbt_ingreso_vehiculo.total as Total, tbt_vehiculo. placa_vehiculo as Vehiculo from tbt_ingreso_vehiculo,tbt_vehiculo where tbt_ingreso_vehiculo.tbt_vehiculo_cod_vehiculo = tbt_vehiculo.cod_vehiculo";
                 dataGridView1.DataSource = ((x2.consulta_DataGridView(query2)));



                 i3nRiqJson x1 = new i3nRiqJson();

                 string query = "select cod_vehiculo, placa_vehiculo from tbt_vehiculo";


                 cmb_vehiculo.DataSource = ((x1.consulta_DataGridView(query)));
                 cmb_vehiculo.ValueMember = "cod_vehiculo";
                 cmb_vehiculo.DisplayMember = "placa_vehiculo";

              
          

           
 }

        public void ingresovehiculo()
        {

            if ((txttotal.Text.Equals("")) )
            {

                MessageBox.Show("Algun campo esta vacio");
            }
            else
            {

                string tabla = "tbt_ingreso_vehiculo";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("fecha", dtpfecha.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                dict.Add("total", txttotal.Text);
              
                i3nRiqJson x4 = new i3nRiqJson();
                string query4 = "select cod_vehiculo, placa_vehiculo  from tbt_vehiculo where placa_vehiculo='" + cmb_vehiculo.Text + "'";
                System.Collections.ArrayList array = x4.consultar(query4);



                foreach (Dictionary<string, string> dic in array)
                {
                    stef = (dic["cod_vehiculo"] + "\n");
                
                }
                dict.Add("tbt_vehiculo_cod_vehiculo", stef);


                i3nRiqJson x = new i3nRiqJson();
                x.insertar("1", tabla, dict);
                MessageBox.Show("Datos ingresados en  vehiculo " + i3nRiqJson.RespuestaConexion.ToString());


                i3nRiqJson x2 = new i3nRiqJson();

                string query2 = "select cod_vehiculo, placa_vehiculo from tbt_vehiculo";


                cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
                cmb_eliminar.ValueMember = "cod_vehiculo";
                cmb_eliminar.DisplayMember = "placa_vehiculo";

                actualizar();
            }
        }

 
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txttotal.ReadOnly = false;
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
            string query2 = "select idtbt_ingreso_vehiculo from tbt_ingreso_vehiculo where tbt_vehiculo_cod_vehiculo='" + textBox1.Text +"'";
            System.Collections.ArrayList array2 = x4.consultar(query2);

            foreach (Dictionary<string, string> dic in array2)
            {
                stef3 = (dic["idtbt_ingreso_vehiculo"] + "\n");

                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }

          
            textBox2.Text = stef3;



            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbt_ingreso_vehiculo";
            string condicion = "idtbt_ingreso_vehiculo=" + stef3;

            //string condicion = "idtbt_ingreso_vehiculo=" + id;
            x.eliminar("4", tabla, condicion);
            MessageBox.Show("Dato eliminado en ingreso vehiculo " + i3nRiqJson.RespuestaConexion.ToString());

            //ºº  x.eliminar("4", "tbt_bancos", condicion);


            actualizar();

            
                
           
       
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {


         



       /*     i3nRiqJson x4 = new i3nRiqJson();
            string query4 = "select idtbt_ingreso_vehiculo, total from tbt_ingreso_vehiculo where  total='" + cmb_eliminar.Text + "'";
            System.Collections.ArrayList array = x4.consultar(query4);
            foreach (Dictionary<string, string> dic in array)
            {
                stef = (dic["idtbt_ingreso_vehiculo"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);
            }
            i3nRiqJson x = new i3nRiqJson();
            string tabla = "ttbt_ingreso_vehiculo";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("total", txttotal.Text);





            string condicion = "idtbt_ingreso_vehiculo= " + stef;
            x.actualizar("3", tabla, dict, condicion);
            actualizar();

            MessageBox.Show("Datos Actualizados de vehiculos",
        "Editar vehiculos",
        MessageBoxButtons.OK);

            */




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
            string query2 = "select idtbt_ingreso_vehiculo from tbt_ingreso_vehiculo where tbt_vehiculo_cod_vehiculo='" + textBox1.Text + "'";
            System.Collections.ArrayList array2 = x4.consultar(query2);

            foreach (Dictionary<string, string> dic in array2)
            {
                stef3 = (dic["idtbt_ingreso_vehiculo"] + "\n");

                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }


            textBox2.Text = stef3;



            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbt_ingreso_vehiculo";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("fecha", dtpfecha.Value.Date.ToString("yyyy-MM-dd HH:mm"));
            dict.Add("total", txttotal.Text);


            i3nRiqJson x5 = new i3nRiqJson();
            string query5 = "select cod_vehiculo from tbt_vehiculo where placa_vehiculo='" + cmb_vehiculo.Text + "'";
            System.Collections.ArrayList array5 = x5.consultar(query5);



            foreach (Dictionary<string, string> dic in array5)
            {
                stef = (dic["cod_vehiculo"] + "\n");

            }
            dict.Add("tbt_vehiculo_cod_vehiculo", stef);

            string condicion = "idtbt_ingreso_vehiculo=" + stef3;

            x.actualizar("3", tabla, dict, condicion);
            txttotal.Text = "";
            actualizar();

            MessageBox.Show("Datos editados de ingreso de vehiculos",
        "Editar vehiculos",
        MessageBoxButtons.OK);
       
            actualizar();

            
                



        }

    
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ingresovehiculo();
            txttotal.Text = "";
           
        }

        private void frm_ingreso_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
           // i3nRiqJson x = new i3nRiqJson();
            actualizar();


           i3nRiqJson x2 = new i3nRiqJson();
            string query2 = "select cod_vehiculo, placa_vehiculo from tbt_vehiculo";


            cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_eliminar.ValueMember = "cod_vehiculo";
            cmb_eliminar.DisplayMember = "placa_vehiculo";

          /*  i3nRiqJson x3 = new i3nRiqJson();

            string query3 = "select idtbt_ingreso_vehiculo from tbt_ingreso_vehiculo";


            cmb_ac.DataSource = ((x3.consulta_DataGridView(query3)));
            cmb_ac.ValueMember = "idtbt_ingreso_vehiculo";
            cmb_ac.DisplayMember = "idtbt_ingreso_vehiculo";*/
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bp_inset_bancos_Click(object sender, EventArgs e)
        {

        }

        private void cmb_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //editar = true;
            //txttotal.ReadOnly = false;
           // actualizar();

           //dataGridView1.DataSource = db.consulta_DataGridView("SELECT * FROM tbt_ingreso_vehiculo ;");
         
           // this.dataGridView1.Columns[0].Visible = false;

          

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
            string query2 = "select idtbt_ingreso_vehiculo from tbt_ingreso_vehiculo where tbt_vehiculo_cod_vehiculo='" + textBox1.Text + "'";
            System.Collections.ArrayList array2 = x4.consultar(query2);

            foreach (Dictionary<string, string> dic in array2)
            {
                stef3 = (dic["idtbt_ingreso_vehiculo"] + "\n");

                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }


            textBox2.Text = stef3;


            //string busca = cmb_eliminar.SelectedValue.ToString();
            dataGridView1.DataSource = db.consulta_DataGridView("select *from tbt_ingreso_vehiculo where idtbt_ingreso_vehiculo =" + stef3 + ";");
        }
    }
}
