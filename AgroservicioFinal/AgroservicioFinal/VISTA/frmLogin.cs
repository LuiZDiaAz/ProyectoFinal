using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroservicioFinal.MODEL;
using AgroservicioFinal.VISTA;

namespace AgroservicioFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bttnIniciarSesion_Click(object sender, EventArgs e)
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                var lista = from trabajador in db.Trabajador
                            where trabajador.Email == txtCorreo.Text
                            && trabajador.Clave == txtContraseña.Text
                            select trabajador;

                if (lista.Count() > 0)
                {
                    this.Hide();
                    frmPantalladeCarga Bienvenido = new frmPantalladeCarga();
                    Bienvenido.ShowDialog();
                    frmMenu f = new frmMenu();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Informacion Incorrecta");
                }
            }
        }
    }
}
