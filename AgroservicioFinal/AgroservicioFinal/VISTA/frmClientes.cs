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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        Cliente cli = new Cliente();

        void CargarDatos()
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                var clientes = db.Cliente;

                dgvClientes.DataSource = db.Cliente.ToList();
            }
        }

        void LimpiarDatos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtDirreccion.Text = "";
            txtDUI.Text = "";
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
            LimpiarDatos();
        }

        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                cli.Nombre = txtNombre.Text;
                cli.Apellidos = txtApellido.Text;
                cli.Email = txtEmail.Text;
                cli.Dirreccion = txtDirreccion.Text;
                cli.Dui = int.Parse(txtDUI.Text);

                db.Cliente.Add(cli);
                db.SaveChanges();
            }
            CargarDatos();
            LimpiarDatos();
        }

        private void bttnEditar_Click(object sender, EventArgs e)
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                string Id = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                int IdC = int.Parse(Id);
                cli = db.Cliente.Where(VerificarId => VerificarId.Id == IdC).First();
                cli.Nombre = txtNombre.Text;
                cli.Apellidos = txtApellido.Text;
                cli.Email = txtEmail.Text;
                cli.Dirreccion = txtDirreccion.Text;
                cli.Dui = int.Parse(txtDUI.Text);
                db.Entry(cli).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            CargarDatos();
            LimpiarDatos();
        }

        private void bttnEliminar_Click(object sender, EventArgs e)
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                String Id = dgvClientes.CurrentRow.Cells[0].Value.ToString();

                cli = db.Cliente.Find(int.Parse(Id));
                db.Cliente.Remove(cli);
                db.SaveChanges();
            }
            CargarDatos();
            LimpiarDatos();
        }
    }
}
