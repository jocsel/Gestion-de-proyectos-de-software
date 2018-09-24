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
    public partial class frmReporteLavado : Form
    {
        public List<ELavado> listaLavado;
        public void actualizarGrid()
        {
            try
            {
                NLavado listar = new NLavado();
                listaLavado = listar.selectRow();
                var lista = (from lavado in listaLavado
                             select new
                             {
                                 lavado.idLavado,
                                 lavado.fecha,
                                 lavado.usuario.usuario,
                                 Atendido_por = lavado.empleado.nombres,
                                 lavado.grupoTrabajadores.idGrupo,
                                 Grupo_Asignado = lavado.grupoTrabajadores.grupoTrabajadores,
                                 lavado.vehiculoLavado.idVehiculoLavado,
                                 lavado.vehiculoLavado.vehiculoLavado,
                                 lavado.servicioLavado.idServicioLavado,
                                 lavado.servicioLavado.servicioLavado,
                                 Grupo = lavado.grupoTrabajadores.idGrupo,
                                 lavado.LavadoVehiculo.idLavadoVehiculo,
                                 lavado.LavadoVehiculo.precio,
                                 lavado.placa,
                                 lavado.total,
                             }).ToList();
                dgvLavado.DataSource = lista;
                dgvLavado.Columns["idLavado"].Visible = false;
                dgvLavado.Columns["usuario"].Visible = false;
                dgvLavado.Columns["idGrupo"].Visible = false;
                dgvLavado.Columns["idVehiculoLavado"].Visible = false;
                dgvLavado.Columns["idServicioLavado"].Visible = false;
                dgvLavado.Columns["idLavadoVehiculo"].Visible = false;
                dgvLavado.Columns["precio"].Visible = false;
                dgvLavado.Columns["Grupo"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public frmReporteLavado()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReporteLavado_Load(object sender, EventArgs e)
        {
            rbtEmpleadp.Checked = true;
            btnFecha.Enabled = false;
            // btnFecha.Text = "";
            label1.Text = "";
            try
            {
                actualizarGrid();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        public void Filtro() {
            if (rbtEmpleadp.Checked ) {
                btnFecha.Enabled = true;
                //btnFecha.Text = "Empleado";
                label1.Text = "Empleado";
                var busqueda = (
                    from reporte in listaLavado where reporte.empleado.nombres.ToUpper().StartsWith(txtFiltro.Text.ToUpper())
                    select new {
                            reporte.idLavado,
                            reporte.fecha,
                            reporte.usuario.usuario,
                            Atendido_por = reporte.empleado.nombres,
                            reporte.grupoTrabajadores.idGrupo,
                            Grupo_Asignado = reporte.grupoTrabajadores.grupoTrabajadores,
                            reporte.vehiculoLavado.idVehiculoLavado,
                            reporte.vehiculoLavado.vehiculoLavado,
                            reporte.servicioLavado.idServicioLavado,
                            reporte.servicioLavado.servicioLavado,
                            Grupo = reporte.grupoTrabajadores.idGrupo,
                            reporte.LavadoVehiculo.idLavadoVehiculo,
                            reporte.LavadoVehiculo.precio,
                            reporte.placa,
                            reporte.total,
                             }).ToList();
                dgvLavado.DataSource = busqueda;
                dgvLavado.Columns["idLavado"].Visible = false;
                dgvLavado.Columns["usuario"].Visible = false;
                dgvLavado.Columns["idGrupo"].Visible = false;
                dgvLavado.Columns["idVehiculoLavado"].Visible = false;
                dgvLavado.Columns["idServicioLavado"].Visible = false;
                dgvLavado.Columns["idLavadoVehiculo"].Visible = false;
                dgvLavado.Columns["precio"].Visible = false;
                dgvLavado.Columns["Grupo"].Visible = false;
                                             
            }
            if (rbtServicio.Checked)
            {
               btnFecha.Enabled = true;
                //btnFecha.Text = "Servicio";
                label1.Text = "Servicio";
                var busqueda = (
                    from reporte in listaLavado
                    where reporte.servicioLavado.servicioLavado.ToUpper().StartsWith(txtFiltro.Text.ToUpper())
                    select new
                    {
                        reporte.idLavado,
                        reporte.fecha,
                        reporte.usuario.usuario,
                        Atendido_por = reporte.empleado.nombres,
                        reporte.grupoTrabajadores.idGrupo,
                        Grupo_Asignado = reporte.grupoTrabajadores.grupoTrabajadores,
                        reporte.vehiculoLavado.idVehiculoLavado,
                        reporte.vehiculoLavado.vehiculoLavado,
                        reporte.servicioLavado.idServicioLavado,
                        reporte.servicioLavado.servicioLavado,
                        Grupo = reporte.grupoTrabajadores.idGrupo,
                        reporte.LavadoVehiculo.idLavadoVehiculo,
                        reporte.LavadoVehiculo.precio,
                        reporte.placa,
                        reporte.total,
                    }).ToList();
                dgvLavado.DataSource = busqueda;
                dgvLavado.Columns["idLavado"].Visible = false;
                dgvLavado.Columns["usuario"].Visible = false;
                dgvLavado.Columns["idGrupo"].Visible = false;
                dgvLavado.Columns["idVehiculoLavado"].Visible = false;
                dgvLavado.Columns["idServicioLavado"].Visible = false;
                dgvLavado.Columns["idLavadoVehiculo"].Visible = false;
                dgvLavado.Columns["precio"].Visible = false;
                dgvLavado.Columns["Grupo"].Visible = false;
            }

            if (rbtVehiculo.Checked)
            {
               btnFecha.Enabled = true;
                //btnFecha.Text = "Vehiculo";
                label1.Text = "Vehiculo";
                var busqueda = (
                    from reporte in listaLavado
                    where reporte.vehiculoLavado.vehiculoLavado.ToUpper().StartsWith(txtFiltro.Text.ToUpper())
                    select new
                    {
                        reporte.idLavado,
                        reporte.fecha,
                        reporte.usuario.usuario,
                        Atendido_por = reporte.empleado.nombres,
                        reporte.grupoTrabajadores.idGrupo,
                        Grupo_Asignado = reporte.grupoTrabajadores.grupoTrabajadores,
                        reporte.vehiculoLavado.idVehiculoLavado,
                        reporte.vehiculoLavado.vehiculoLavado,
                        reporte.servicioLavado.idServicioLavado,
                        reporte.servicioLavado.servicioLavado,
                        Grupo = reporte.grupoTrabajadores.idGrupo,
                        reporte.LavadoVehiculo.idLavadoVehiculo,
                        reporte.LavadoVehiculo.precio,
                        reporte.placa,
                        reporte.total,
                    }).ToList();
                dgvLavado.DataSource = busqueda;
                dgvLavado.Columns["idLavado"].Visible = false;
                dgvLavado.Columns["usuario"].Visible = false;
                dgvLavado.Columns["idGrupo"].Visible = false;
                dgvLavado.Columns["idVehiculoLavado"].Visible = false;
                dgvLavado.Columns["idServicioLavado"].Visible = false;
                dgvLavado.Columns["idLavadoVehiculo"].Visible = false;
                dgvLavado.Columns["precio"].Visible = false;
                dgvLavado.Columns["Grupo"].Visible = false;
            }
            if (rbtFecha.Checked == true)
            {
                btnFecha.Enabled = true;
                ///btnFecha.Text = "Fecha";
                label1.Text = "Fecha";
                var busqueda = (
                    from reporte in listaLavado
                    where reporte.fecha.ToString().StartsWith(txtFiltro.Text.ToUpper())
                    select new
                    {
                        reporte.idLavado,
                        reporte.fecha,
                        reporte.usuario.usuario,
                        Atendido_por = reporte.empleado.nombres,
                        reporte.grupoTrabajadores.idGrupo,
                        Grupo_Asignado = reporte.grupoTrabajadores.grupoTrabajadores,
                        reporte.vehiculoLavado.idVehiculoLavado,
                        reporte.vehiculoLavado.vehiculoLavado,
                        reporte.servicioLavado.idServicioLavado,
                        reporte.servicioLavado.servicioLavado,
                        Grupo = reporte.grupoTrabajadores.idGrupo,
                        reporte.LavadoVehiculo.idLavadoVehiculo,
                        reporte.LavadoVehiculo.precio,
                        reporte.placa,
                        reporte.total,
                    }).ToList();
                dgvLavado.DataSource = busqueda;
                dgvLavado.Columns["idLavado"].Visible = false;
                dgvLavado.Columns["usuario"].Visible = false;
                dgvLavado.Columns["idGrupo"].Visible = false;
                dgvLavado.Columns["idVehiculoLavado"].Visible = false;
                dgvLavado.Columns["idServicioLavado"].Visible = false;
                dgvLavado.Columns["idLavadoVehiculo"].Visible = false;
                dgvLavado.Columns["precio"].Visible = false;
                dgvLavado.Columns["Grupo"].Visible = false;
                
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            Filtro();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnReporteLavado_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text == "")
                {
                    MessageBox.Show("Por favor seleccione una opcion y escriba el filtro solicitado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnFecha.Enabled = false;
                    label1.Text = "";
                }
                if (label1.Text == "Fecha")
                {
                    btnFecha.Enabled = true;
                    frmMostrarReporteLavado reporteFecha = new frmMostrarReporteLavado();
                    reporteFecha.fecha = Convert.ToDateTime(txtFiltro.Text);
                    reporteFecha.ShowDialog();
                }
                if(label1.Text == "Empleado") {
                    btnFecha.Enabled = true;
                    frmMostrarReporteLavadoEmpleado reporteEmpleado = new frmMostrarReporteLavadoEmpleado();
                    reporteEmpleado.Empleado = txtFiltro.Text;
                    reporteEmpleado.ShowDialog();
                }
                if (label1.Text == "Vehiculo") {
                    btnFecha.Enabled = true;
                    frmMostrarReporteLavadoVehiculo reporteVehiculo = new frmMostrarReporteLavadoVehiculo();
                    reporteVehiculo.vehiculo = txtFiltro.Text;
                    reporteVehiculo.ShowDialog();
                }
                if (label1.Text == "Servicio")
                {
                    btnFecha.Enabled = true;
                    frmMostrarReporteLavadoServicio reporteServicio = new frmMostrarReporteLavadoServicio();
                    reporteServicio.servicio = txtFiltro.Text;
                    reporteServicio.ShowDialog();
                }
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
