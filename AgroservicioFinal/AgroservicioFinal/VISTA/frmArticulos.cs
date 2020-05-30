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
    public partial class frmArticulos : Form
    {
        public frmArticulos()
        {
            InitializeComponent();
        }

        void CargarDatos()
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                var articulos = db.Articulo;

                dgvArticulos.DataSource = db.Articulo.ToList();
            }
        }

        void LimpiarDatos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtEstado.Text = "";
        }

        Articulo Art = new Articulo();
        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                Art.Codigo = int.Parse(txtCodigo.Text);
                Art.Nombre = txtNombre.Text;
                Art.Precio = Convert.ToDouble(txtPrecio.Text);
                Art.Estado = txtEstado.Text;

                db.Articulo.Add(Art);
                db.SaveChanges();
            }
            CargarDatos();
            LimpiarDatos();
        }

        private void bttnEditar_Click(object sender, EventArgs e)
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                string Id = dgvArticulos.CurrentRow.Cells[0].Value.ToString();
                int IdC = int.Parse(Id);
                Art = db.Articulo.Where(VerificarId => VerificarId.Id == IdC).First();
                Art.Codigo = int.Parse(txtPrecio.Text);
                Art.Nombre = txtNombre.Text;
                Art.Precio = Convert.ToInt32(txtPrecio.Text);
                Art.Estado = txtEstado.Text;
                db.Entry(Art).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            CargarDatos();
            LimpiarDatos();
        }

        private void bttnEliminar_Click(object sender, EventArgs e)
        {
            using (AgroserviciosEntities db = new AgroserviciosEntities())
            {
                String Id = dgvArticulos.CurrentRow.Cells[0].Value.ToString();

                Art = db.Articulo.Find(int.Parse(Id));
                db.Articulo.Remove(Art);
                db.SaveChanges();
            }
            CargarDatos();
            LimpiarDatos();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            LimpiarDatos();
        }
    }
}
