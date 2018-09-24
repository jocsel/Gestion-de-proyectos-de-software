using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;


namespace Presentacion
{
    public partial class frmServicioVehiculo : Form
    {
        private readonly NServicioMantenimiento _NServicioMan = new NServicioMantenimiento();
        private readonly NVehiculoMan _NVehiculoMan = new NVehiculoMan();
        List<EServicioVehiculo> ListaServicioV;
        bool modificar;
        public frmServicioVehiculo()
        {
            InitializeComponent();
            Deshabilitar();
        }
        private void actualizargrid()
        {
            try
            {
                NServicioVehiculo listaSV = new NServicioVehiculo();
                ListaServicioV = listaSV.ObtenerServicioV();

                var lista = (from sv in ListaServicioV
                             select new
                             {
                                 sv.idServicioVehiculo,
                                 sv.idServicioMantenimiento.servicioMantenimiento,
                                 sv.idVehiculoMantenimiento.vehiculoMantenimiento,
                                 sv.precio,
                                 sv.estado,
                                 sv.idServicioMantenimiento.idServicioMantenimiento,
                                 sv.idVehiculoMantenimiento.idVehiculoMantenimiento,
                             }).ToList();
                dgvServicioV.DataSource = lista;
                dgvServicioV.Columns["idServicioVehiculo"].Visible = false;
                dgvServicioV.Columns["idServicioMantenimiento"].Visible = false;
                dgvServicioV.Columns["idVehiculoMantenimiento"].Visible = false;
                dgvServicioV.Columns["estado"].Visible = true;

                ActualizarServicioV();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ActualizarServicioV()
        {
            NServicioVehiculo gestionarSV = new NServicioVehiculo();
            ListaServicioV = gestionarSV.ObtenerServicioV();

        }

        private void frmServicioVehiculo_Load(object sender, EventArgs e)
        {
            actualizargrid();
            LlenarCombo();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            cmservicio.Focus();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            dgvServicioV.Enabled = false;
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            modificar = true;
            dgvServicioV.Enabled = false;
        }
        private void Deshabilitar()
        {
            cmservicio.Enabled = false;
            cmvehiculo.Enabled = false;
            txtprecio.Enabled = false;
            rbActivo.Enabled = false;
            rbInactivo.Enabled = false;
           btnguardar.Enabled = false;
            btnmodificar.Enabled = false;
           
        }

        private void Habilitar()
        {
            cmservicio.Enabled = true;
            cmvehiculo.Enabled = true;
            txtprecio.Enabled = true;
            rbActivo.Checked = true;
            //rbInactivo.Checked = false;
            txtprecio.Enabled = true;         
            rbInactivo.Enabled = true;
            rbActivo.Enabled = true;
        }

        private void Limpiar()
        {

            cmservicio.Text = "";
            cmvehiculo.Text = "";
            txtprecio.Text = "";
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnnuevo.Enabled = true;
            dgvServicioV.Enabled = true;
            btnguardar.Enabled = false;
            btnmodificar.Enabled = false;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {
                    EServicioVehiculo modSV = new EServicioVehiculo();
                    modSV.idServicioVehiculo = Convert.ToInt32(txtprecio.Tag);

                    modSV.idServicioMantenimiento.idServicioMantenimiento = Convert.ToInt32(cmservicio.SelectedValue);
                    modSV.idVehiculoMantenimiento.idVehiculoMantenimiento = Convert.ToInt32(cmvehiculo.SelectedValue);
                    modSV.precio = Convert.ToDecimal(txtprecio.Text);
                    if (rbActivo.Checked == true) { modSV.estado = true; } else { modSV.estado = false; }
                    NServicioVehiculo gestionarSV = new NServicioVehiculo();
                    gestionarSV.Modificar(modSV);

                    MessageBox.Show("Se modifico correctamente", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvServicioV.Enabled = true;
                }
                else
                {
                    EServicioVehiculo newSV = new EServicioVehiculo();                   
                    newSV.idServicioMantenimiento.idServicioMantenimiento = Convert.ToInt32(cmservicio.SelectedValue);
                    newSV.idVehiculoMantenimiento.idVehiculoMantenimiento = Convert.ToInt32(cmvehiculo.SelectedValue);
                    newSV.precio = Convert.ToDecimal(txtprecio.Text);
                    if (rbActivo.Checked == true) { newSV.estado = true; } else { newSV.estado = false; }


                    NServicioVehiculo gestionarSV = new NServicioVehiculo();
                    gestionarSV.Agregar(newSV);

                    MessageBox.Show("Se guardo correctamente", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ActualizarServicioV();
                //dgvProveedor.DataSource = ListaProveedor;
                actualizargrid();
                Limpiar();
                Deshabilitar();
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
                btnmodificar.Enabled = false;
                btnnuevo.Enabled = true;
                modificar = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void LlenarCombo()
        {
            List<EServicioMantenimiento> sv = new List<EServicioMantenimiento>();
            sv = _NServicioMan.ObtenerListaServicioM();
            cmservicio.DataSource = sv;
            cmservicio.DisplayMember = "ServicioMantenimiento";
            cmservicio.ValueMember = "idServicioMantenimiento";


            List<EVehiculoMantenimiento> sm = new List<EVehiculoMantenimiento>();
            sm = _NVehiculoMan.ObtenerListaVehiculoMan();
            cmvehiculo.DataSource = sm;
            cmvehiculo.DisplayMember = "VehiculoMantenimiento";
            cmvehiculo.ValueMember = "idVehiculoMantenimiento";

        }

        private void dgvServicioV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtprecio.Tag = Convert.ToInt32(dgvServicioV.Rows[e.RowIndex].Cells["idServicioVehiculo"].Value.ToString());

                if (dgvServicioV.Rows[e.RowIndex].Cells["precio"].Value == null)
                    txtprecio.Text = "";
                else
                    txtprecio.Text = dgvServicioV.Rows[e.RowIndex].Cells["precio"].Value.ToString();

                if (dgvServicioV.Rows[e.RowIndex].Cells["estado"].Value == null)
                    rbInactivo.Checked = false;
                else
                    rbActivo.Checked = bool.Parse(dgvServicioV.Rows[e.RowIndex].Cells["estado"].Value.ToString());


                if (dgvServicioV.Rows[e.RowIndex].Cells["idVehiculoMantenimiento"].Value == null)
                {
                    cmvehiculo.Text = "";
                    cmvehiculo.ValueMember = "";
                }
                else
                {
                    cmvehiculo.SelectedValue = dgvServicioV.Rows[e.RowIndex].Cells["idVehiculoMantenimiento"].Value.ToString();
                   cmvehiculo.Text = dgvServicioV.Rows[e.RowIndex].Cells["VehiculoMantenimiento"].Value.ToString();

                }

                if (dgvServicioV.Rows[e.RowIndex].Cells["idServicioMantenimiento"].Value == null)
                {
                    cmservicio.ValueMember = "";
                    cmservicio.Text = "";
                }
                else
                {
                    cmservicio.SelectedValue = dgvServicioV.Rows[e.RowIndex].Cells["idServicioMantenimiento"].Value.ToString();
                   cmservicio.Text = dgvServicioV.Rows[e.RowIndex].Cells["ServicioMantenimiento"].Value.ToString();
                }


                btnmodificar.Enabled = true;
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
         
            this.Close();
        }

        


    }
}
