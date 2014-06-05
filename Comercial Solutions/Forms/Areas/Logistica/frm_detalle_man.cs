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
    public partial class frm_detalle_man : Form
    {
        int inteditmode = 0;
        i3nRiqJson db = new i3nRiqJson();
        int X = 0;
        int Y = 0;
        string stef;
        string stef2;
        string EditCod = "";
      
        bool editar = false;
        string id;
        string stef3;
        string stef4;
        public frm_detalle_man()
        {
            X = Propp.X;
            Y = Propp.Y;
            InitializeComponent();
        }


        public void actualizar()
        {
      

            i3nRiqJson x = new i3nRiqJson();
          //  string query = "SELECT  tbt_detalle_mantenimiento.gastos as Gastos, tbt_detalle_mantenimiento.total as Total, tbt_vehiculo. placa_vehiculo as Vehiculo, tbm_acpro.nombre_proveedor as Proveedor from   tbt_detalle_mantenimiento.idtbm_proveedor = tbm_acpro.idtbm_proveedor, tbt_detalle_mantenimiento.idtbt_mantenimiento_vehiculo = tbt_mantenimiento_vehiculo.idtbt_mantenimiento_vehiculo ";
           // dataGridView1.DataSource = ((x.consulta_DataGridView(query)));

            dataGridView1.DataSource = db.consulta_DataGridView("SELECT * FROM tbt_detalle_mantenimiento");
            dataGridView1.Columns[1].HeaderText = "Gastos";
            dataGridView1.Columns[2].HeaderText = "Total";
            dataGridView1.Columns[3].HeaderText = "Codigo mantenimiento";
            dataGridView1.Columns[4].HeaderText = "Proveedor";
            this.dataGridView1.Columns[0].Visible = false;

           
            
            
            
            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select cod_vehiculo, placa_vehiculo from tbt_vehiculo";


            cmb_man.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_man.ValueMember = "cod_vehiculo";
            cmb_man.DisplayMember = "placa_vehiculo";

           /* i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select idtbt_mantenimiento_vehiculo from tbt_mantenimiento_vehiculo";


            cmb_man.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_man.ValueMember = "idtbt_mantenimiento_vehiculo";
            cmb_man.DisplayMember = "idtbt_mantenimiento_vehiculo";*/


            i3nRiqJson x3 = new i3nRiqJson();

            string query3 = "select idtbm_proveedor, nombre_proveedor from tbm_acpro";


            cmb_prov.DataSource = ((x3.consulta_DataGridView(query3)));
            cmb_prov.ValueMember = "idtbm_proveedor";
            cmb_prov.DisplayMember = "nombre_proveedor";


        }



        public void ingresovehiculo()
        {

            if ((txtgastos.Text.Equals("")) || (txttotal.Text.Equals("")))
            {

                MessageBox.Show("Algun campo esta vacio");
            }
            else
            {

                string tabla = "tbt_detalle_mantenimiento";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("gastos", txtgastos.Text);
                dict.Add("total", txttotal.Text);



                i3nRiqJson x1 = new i3nRiqJson();
                string query1 = "select cod_vehiculo, placa_vehiculo from tbt_vehiculo where placa_vehiculo='" + cmb_man.Text + "'";
                System.Collections.ArrayList array1 = x1.consultar(query1);
                foreach (Dictionary<string, string> dic in array1)
                {
                    stef = (dic["cod_vehiculo"] + "\n");

                }

                textBox1.Text = stef;

                i3nRiqJson x4 = new i3nRiqJson();
                string query4 = "select idtbt_mantenimiento_vehiculo from tbt_mantenimiento_vehiculo where cod_vehiculo='" + textBox1.Text + "'";
                System.Collections.ArrayList array3 = x4.consultar(query4);
                foreach (Dictionary<string, string> dic in array3)
                {
                    stef2 = (dic["idtbt_mantenimiento_vehiculo"] + "\n");

                }


 
                dict.Add("idtbt_mantenimiento_vehiculo", stef2);

                i3nRiqJson x5 = new i3nRiqJson();
                string query5 = "select idtbm_proveedor from tbm_acpro where nombre_proveedor='" + cmb_prov.Text + "'";
                System.Collections.ArrayList array2 = x5.consultar(query5);




                foreach (Dictionary<string, string> dic in array2)
                {
                    stef3 = (dic["idtbm_proveedor"] + "\n");

                }
                
                dict.Add("idtbm_proveedor", stef3);


                i3nRiqJson x = new i3nRiqJson();
                x.insertar("1", tabla, dict);
                MessageBox.Show("Datos ingresados en detalle mantenimiento  " + i3nRiqJson.RespuestaConexion.ToString());



                i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select cod_vehiculo, placa_vehiculo from tbt_vehiculo";


            cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_eliminar.ValueMember = "cod_vehiculo";
            cmb_eliminar.DisplayMember = "placa_vehiculo";

                actualizar();
              /*  i3nRiqJson x2 = new i3nRiqJson();

                string query2 = "select idtbt_detalle_mantenimiento from tbt_detalle_mantenimiento";

                
                cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
                cmb_eliminar.ValueMember = "idtbt_detalle_mantenimiento";
                cmb_eliminar.DisplayMember = "idtbt_detalle_mantenimiento";*/
            }
        }

 
       


        private void frm_detalle_man_Load(object sender, EventArgs e)
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
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ingresovehiculo();
            txtgastos.Text = "";
            txttotal.Text = "";
        }

        private void cmb_man_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbt_detalle_mantenimiento";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("gastos", txtgastos.Text);
            dict.Add("total", txttotal.Text);
            
           
          string condicion = "idtbt_detalle_mantenimiento= " + cmb_eliminar.SelectedValue.ToString();
            //  Console.WriteLine("INICIA");
            x.actualizar("3", tabla, dict, condicion);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txtgastos.ReadOnly = false;
            txtgastos.Text = "";
            txttotal.ReadOnly = false;
            txttotal.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            
       
        




            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbt_detalle_mantenimiento";
            string condicion = "idtbt_detalle_mantenimiento=" + cmb_eliminar.SelectedValue;


            //string condicion = "idtbt_ingreso_vehiculo=" + id;
            x.eliminar("4", tabla, condicion);
            MessageBox.Show("Dato eliminado en detalle mantenimiento " + i3nRiqJson.RespuestaConexion.ToString());
            //ºº  x.eliminar("4", "tbt_bancos", condicion);

            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select idtbt_detalle_mantenimiento from tbt_detalle_mantenimiento";


            cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_eliminar.ValueMember = "idtbt_detalle_mantenimiento";
            cmb_eliminar.DisplayMember = "idtbt_detalle_mantenimiento";

            actualizar();
                
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string busca = cmb_eliminar.SelectedValue.ToString();
            dataGridView1.DataSource = db.consulta_DataGridView("select *from tbt_detalle_mantenimiento where idtbt_detalle_mantenimiento =" + busca + ";");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            editar = true;
            txtgastos.ReadOnly = false;
            txttotal.ReadOnly = false;
            int i = dataGridView1.CurrentRow.Index;
            id = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtgastos.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txttotal.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }
    }
}
