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
        string EditCod = "";
        public frm_detalle_man()
        {
            X = Propp.X;
            Y = Propp.Y;
            InitializeComponent();
        }


       
       


        private void frm_detalle_man_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
