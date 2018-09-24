using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidades;


namespace Presentacion
{
    public partial class frmMantenimineto : Form
    {
        public readonly NGrupoTrabajadores _NGrupoTrabajadores = new NGrupoTrabajadores();
        public  readonly NServicioVehiculo NServicioVehiculo = new NServicioVehiculo();

        List<EMantenimineto> Listamantenimiento;
        
        public frmMantenimineto()
        {
            InitializeComponent();
            Deshabilitar();
        }

        private void frmMantenimineto_Load(object sender, EventArgs e)
        {
            lblusuario.Visible = false;
            actualizargrid();
            LlenarCombo();
            txtfecha.Text = DateTime.Now.ToString();
            lblusuario.Text = Global.usuarioSesion.usuario;
        }
        private void actualizargrid()
        {
            try
            {
                NMantenimiento listaman = new NMantenimiento();
                Listamantenimiento = listaman.selectRow();

                var lista = (from man in Listamantenimiento
                             select new
                             {
                                 Servicio = man.idservicioVehiculo.idServicioMantenimiento.servicioMantenimiento,
                                 Vehiculo = man.idservicioVehiculo.idVehiculoMantenimiento.vehiculoMantenimiento,
                                 Lavadores = man.idgrupo.grupoTrabajadores,
                                 Placa = man.placa,
                                 Fecha = man.fecha,
                                
                                 man.idMantenimiento,
                                 Total=man.total,
                                 man.usuario.usuario,
                                 Empleado = (man.usuario.Empleado.nombres + ' ' + man.usuario.Empleado.apellidos),
                                 man.idgrupo.idGrupo,
                                 man.idservicioVehiculo.idServicioVehiculo,
                                 man.idservicioVehiculo.idServicioMantenimiento.idServicioMantenimiento,
                                 man.idservicioVehiculo.idVehiculoMantenimiento.idVehiculoMantenimiento,
                        
                             }).ToList();
                dgvman.DataSource = lista;
                dgvman.Columns["idServicioMantenimiento"].Visible = false;
                dgvman.Columns["idVehiculoMantenimiento"].Visible = false;
                dgvman.Columns["idMantenimiento"].Visible = false;
                dgvman.Columns["usuario"].Visible = false;
                dgvman.Columns["idServicioVehiculo"].Visible = false;
                dgvman.Columns["idgrupo"].Visible = false;

                ActualizarServicioV();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ActualizarServicioV()
        {
            NMantenimiento gestionarman = new NMantenimiento();
            Listamantenimiento = gestionarman.selectRow();

        }

        public void LlenarCombo()
        {
            List<EGrupoTrabajadores> gt = new List<EGrupoTrabajadores>();
            gt = _NGrupoTrabajadores.obtenerLista();
            cmbgrupo.DataSource = gt;
            cmbgrupo.DisplayMember = "grupoTrabajadores";
            cmbgrupo.ValueMember = "idgrupo";


        }

        private void cmbgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Deshabilitar()
        {
            btnBuscar.Enabled = false;
            txtfecha.Enabled = false;
            txtplaca.Enabled = false;
            txttotal.Enabled = false;
            cmbgrupo.Enabled = false;
            cmbservicio.Enabled = false;
            btnguardar.Enabled = false;
            //btnmodificar.Enabled = false;
        }

        private void Habilitar()
        {
            txtfecha.Enabled = true;
            txtplaca.Enabled = true;
            txttotal.Enabled = true;
            cmbgrupo.Enabled = true;
            cmbservicio.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void Limpiar()
        {

          //  txtfecha.Text = "";
            txttotal.Text = "";
            txtplaca.Text = "";
            cmbgrupo.Text = "";
            cmbgrupo.Tag = "";
            cmbservicio.Text = "";
            cmbservicio.Tag = "";
            
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnnuevo.Enabled = true;
            btnguardar.Enabled = false;
            //btnmodificar.Enabled = false;
            dgvman.Enabled = true;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            
            Limpiar();
            txtfecha.Text = DateTime.Now.ToString();
            Habilitar();
            txttotal.Focus();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            //btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
           dgvman.Enabled = false;
            txttotal.Enabled = false;
            cmbservicio.Enabled = false;
            txtfecha.Enabled = false;
            
        }

       

        private void btnguardar_Click(object sender, EventArgs e)
        {
             try
            {
                                        
                    EMantenimineto newman = new EMantenimineto();
                    newman.fecha = Convert.ToDateTime(txtfecha.Text);
                    newman.total = Convert.ToDecimal(txttotal.Text);
                    newman.placa = txtplaca.Text;
                    newman.idgrupo.idGrupo = Convert.ToInt32(cmbgrupo.SelectedValue);
                    newman.idservicioVehiculo.idServicioVehiculo=Convert.ToInt32(cmbservicio.Tag);
                    newman.usuario.usuario = lblusuario.Text;
               
                    NMantenimiento gestionarMan = new NMantenimiento();
                    gestionarMan.InsertRow(newman);
                    MessageBox.Show("Se guardo correctamente", " Mantenimineto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //dgvVehiculoM.Enabled = true;

                frmMostrarReporteMantenimiento mantenimiento = new frmMostrarReporteMantenimiento();
                mantenimiento.idMatenimiento = newman.idMantenimiento;
                mantenimiento.ShowDialog();

                ActualizarServicioV();
                actualizargrid();
                Limpiar();
               
                Deshabilitar();
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
                //btnmodificar.Enabled = false;
                btnnuevo.Enabled = true;
               // modificar = false;
                dgvman.Enabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarServicioMan SV = new frmBuscarServicioMan();
            if (SV.ShowDialog() == DialogResult.OK)
            {
                cmbservicio.Text = SV.nombre.ToString();
                txttotal.Text = SV.precio.ToString();
                cmbservicio.Tag = SV.idservicioVehiculo.ToString();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        
    }
}
