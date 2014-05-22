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
        string EditCod = "";
        bool editar = false;
        string d;
        
        public frm_vehiculo()
        {
            X = Propp.X;
            Y = Propp.Y;
            
            InitializeComponent();
        
        }
        string id;
        
        private void frm_vehiculo_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
            actualizar();

            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select cod_vehiculo from tbt_vehiculo";


            cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_eliminar.ValueMember = "cod_vehiculo";
            cmb_eliminar.DisplayMember = "cod_vehiculo";
          
        }
        public void actualizar()
        {
             i3nRiqJson x = new i3nRiqJson();
            string query = "select modelo_vehiculo, cilindros_vehiculo, puertas_vehiculo, nochasis_vehiculo,nollantas_vehiculo, placa_vehiculo, capacidad, tx_marca   from tbt_vehiculo";


            dataGridView1.DataSource = ((x.consulta_DataGridView(query)));
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {

           // i3nRiqJson x = new i3nRiqJson();
           // string tabla = "tbt_vehiculo";
           // string condicion = "cod_vehiculo=" + txtmodelo.Text + txtcilindros.Text + txtpuertas.Text + txtchasis.Text + txtllantas.Text + txtplaca.Text + txtcapacidad.Text + txtmarca.Text;
            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbt_vehiculo";
            string condicion = "cod_vehiculo=" + cmb_eliminar.SelectedValue;


            //string condicion = "idtbt_ingreso_vehiculo=" + id;
            x.eliminar("4", tabla, condicion);
            //ºº  x.eliminar("4", "tbt_bancos", condicion);

            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select cod_vehiculo from tbt_vehiculo";


            cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_eliminar.ValueMember = "cod_vehiculo";
            cmb_eliminar.DisplayMember = "cod_vehiculo";

         
        
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txtmodelo.ReadOnly = false;
            txtmodelo.Text = "";
            txtcilindros.ReadOnly = false;
            txtcilindros.Text = "";

            txtpuertas.ReadOnly = false;
            txtpuertas.Text = "";

            txtchasis.ReadOnly = false;
            txtchasis.Text = "";

            txtllantas.ReadOnly = false;
            txtllantas.Text = "";

            txtplaca.ReadOnly = false;
            txtplaca.Text = "";

            txtcapacidad.ReadOnly = false;
            txtcapacidad.Text = "";

            txtmarca.ReadOnly = false;
            txtmarca.Text = "";



            

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            editar = true;
            txtmodelo.ReadOnly = false;
            txtcilindros.ReadOnly = false;
            txtpuertas.ReadOnly = false;
            txtchasis.ReadOnly = false;
            txtllantas.ReadOnly = false;
            txtplaca.ReadOnly = false;
            txtcapacidad.ReadOnly = false;
            txtmarca.ReadOnly = false;

            int i = dataGridView1.CurrentRow.Index;
            d = dataGridView1.Rows[i].Cells[0].Value.ToString();

            txtmodelo.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
           txtcilindros.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
           txtpuertas.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
           txtchasis.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
           txtllantas.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
           txtplaca.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
           txtcapacidad.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
           txtmarca.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();


         

           
        }



    


        private void txtmodelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            editar = true;
            txtmodelo.ReadOnly = false;
            txtcilindros.ReadOnly = false;
            txtpuertas.ReadOnly = false;
            txtchasis.ReadOnly = false;
            txtllantas.ReadOnly = false;
            txtplaca.ReadOnly = false;
            txtcapacidad.ReadOnly = false;
            txtmarca.ReadOnly = false;
            
            dataGridView1.DataSource = db.consulta_DataGridView("SELECT * FROM tbt_vehiculo ;");
            // cmb_vehiculo.DataSource = db.consulta_ComboBox("select cod_vehiculo, modelo_vehiculo from tbt_vehiculo;");
            // cmb_vehiculo.DisplayMember = "modelo_vehiculo";
            // cmb_vehiculo.ValueMember = "cod_vehiculo";

           
            this.dataGridView1.Columns[0].Visible = false;


           
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string busca = cmb_eliminar.SelectedValue.ToString();
            dataGridView1.DataSource = db.consulta_DataGridView("select *from tbt_vehiculo where cod_vehiculo =" + busca + ";");
        }
    }
}
