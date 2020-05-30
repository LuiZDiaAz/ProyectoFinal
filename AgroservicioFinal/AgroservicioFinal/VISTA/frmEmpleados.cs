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

namespace AgroservicioFinal.VISTA
{
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        void CargarDatos()
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                var trabajadores = db.Trabajador;

                dgvEmpleados.DataSource = db.Trabajador.ToList();
            }
        }

        void LimpiarDatos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtDUI.Text = "";
            txtSalario.Text = "";
            txtClave.Text = "";
        }

        Trabajador tra = new Trabajador();

        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                tra.Nombre = txtNombre.Text;
                tra.Apellido = txtApellido.Text;
                tra.Email = txtEmail.Text;
                tra.Dui = int.Parse(txtDUI.Text);
                tra.Salario = Convert.ToDouble(txtSalario.Text);
                tra.Clave = txtClave.Text;

                db.Trabajador.Add(tra);
                db.SaveChanges();
            }
            CargarDatos();
            LimpiarDatos();
        }

        private void bttnEditar_Click(object sender, EventArgs e)
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                string Id = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
                int IdC = int.Parse(Id);
                tra = db.Trabajador.Where(VerificarId => VerificarId.Id == IdC).First();
                tra.Nombre = txtNombre.Text;
                tra.Apellido = txtApellido.Text;
                tra.Email = txtEmail.Text;
                tra.Dui = int.Parse(txtDUI.Text);
                tra.Salario = Convert.ToDouble(txtSalario.Text);
                tra.Clave = txtClave.Text;
                db.Entry(tra).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            CargarDatos();
            LimpiarDatos();
        }

        private void bttnEliminar_Click(object sender, EventArgs e)
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                String Id = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();

                tra = db.Trabajador.Find(int.Parse(Id));
                db.Trabajador.Remove(tra);
                db.SaveChanges();
            }
            CargarDatos();
            LimpiarDatos();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            CargarDatos();
            LimpiarDatos();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
