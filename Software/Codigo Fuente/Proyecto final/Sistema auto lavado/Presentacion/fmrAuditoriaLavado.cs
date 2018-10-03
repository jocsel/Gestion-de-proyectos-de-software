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
    public partial class fmrAuditoriaLavado : Form
    {
        public List<EAuditoriaLavado> lista;
        public void ActualizarGrid()
        {
            try
            {
                NAuditoriaLavado gestion = new NAuditoriaLavado();
                lista = gestion.SelectRow();
                var list = (from AL in lista
                            select new
                            {
                                AL.fecha,
                                AL.accion,
                                Atendido_por = AL.empleado.nombres,
                                Vehiculo =  AL.VehiculoLavado.vehiculoLavado,
                                AL.placa,
                                Grupo_Asignado = AL.GrupoTrabajadores.grupoTrabajadores,
                                Servivio_aplicado = AL.ServicioLavado.servicioLavado,
                                AL.total,
                                AL.fechaCreada,
                                AL.fechaModificado,
                                AL.idLavadoAL,
                                AL.Lavado.idLavado,
                                AL.usuario.idUsuario,
                                AL.GrupoTrabajadores.idGrupo,
                                AL.ServicioLavado.idServicioLavado,
                                AL.VehiculoLavado.idVehiculoLavado,
                                AL.empleado.idEmpleado,
                                AL.LavadoVehiculo.idLavadoVehiculo
                            }).ToList();
                dgvAuditoriaLavado.DataSource = list;
                dgvAuditoriaLavado.Columns["idLavadoAL"].Visible = false;
                dgvAuditoriaLavado.Columns["idLavado"].Visible = false;
                dgvAuditoriaLavado.Columns["idUsuario"].Visible = false;
                dgvAuditoriaLavado.Columns["idGrupo"].Visible = false;
                dgvAuditoriaLavado.Columns["idServicioLavado"].Visible = false;
                dgvAuditoriaLavado.Columns["idVehiculoLavado"].Visible = false;
                dgvAuditoriaLavado.Columns["idEmpleado"].Visible = false;
                dgvAuditoriaLavado.Columns["idLavadoVehiculo"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public fmrAuditoriaLavado()
        {
            InitializeComponent();
        }

        private void fmrAuditoriaLavado_Load(object sender, EventArgs e)
        {
            rbempleado.Checked = true;
            ActualizarGrid();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAuditoriaMan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void filtro()
        {
            if (rbempleado.Checked)
            {
                var resultado = (from AuditoriaLavado in lista
                                 where AuditoriaLavado.empleado.nombres.ToUpper().StartsWith(textBox1.Text.ToUpper())
                                 select new
                                 {
                                     AuditoriaLavado.fecha,
                                     AuditoriaLavado.accion,
                                     Atendido_por = AuditoriaLavado.empleado.nombres,
                                     Vehiculo = AuditoriaLavado.VehiculoLavado.vehiculoLavado,
                                     AuditoriaLavado.placa,
                                     Grupo_Asignado = AuditoriaLavado.GrupoTrabajadores.grupoTrabajadores,
                                     Servicio_aplicado = AuditoriaLavado.ServicioLavado.servicioLavado,
                                     AuditoriaLavado.total,
                                     AuditoriaLavado.fechaCreada,
                                     AuditoriaLavado.fechaModificado,
                                     AuditoriaLavado.idLavadoAL,
                                     AuditoriaLavado.Lavado.idLavado,
                                     AuditoriaLavado.usuario.idUsuario,
                                     AuditoriaLavado.GrupoTrabajadores.idGrupo,
                                     AuditoriaLavado.ServicioLavado.idServicioLavado,
                                     AuditoriaLavado.VehiculoLavado.idVehiculoLavado,
                                     AuditoriaLavado.empleado.idEmpleado,
                                     AuditoriaLavado.LavadoVehiculo.idLavadoVehiculo
                                 }).ToList();
                dgvAuditoriaLavado.DataSource = resultado;
                dgvAuditoriaLavado.Columns["idLavadoAL"].Visible = false;
                dgvAuditoriaLavado.Columns["idLavado"].Visible = false;
                dgvAuditoriaLavado.Columns["idUsuario"].Visible = false;
                dgvAuditoriaLavado.Columns["idGrupo"].Visible = false;
                dgvAuditoriaLavado.Columns["idServicioLavado"].Visible = false;
                dgvAuditoriaLavado.Columns["idVehiculoLavado"].Visible = false;
                dgvAuditoriaLavado.Columns["idEmpleado"].Visible = false;
                dgvAuditoriaLavado.Columns["idLavadoVehiculo"].Visible = false;
            }

            if (rbplaca.Checked)
            {
                var resultado = (from AuditoriaLavado in lista
                                 where AuditoriaLavado.placa.ToUpper().StartsWith(textBox1.Text.ToUpper())
                                 select new
                                 {
                                     AuditoriaLavado.fecha,
                                     AuditoriaLavado.accion,
                                     Atendido_por = AuditoriaLavado.empleado.nombres,
                                     Vehiculo = AuditoriaLavado.VehiculoLavado.vehiculoLavado,
                                     AuditoriaLavado.placa,
                                     Grupo_Asignado = AuditoriaLavado.GrupoTrabajadores.grupoTrabajadores,
                                     Servicio_aplicado = AuditoriaLavado.ServicioLavado.servicioLavado,
                                     AuditoriaLavado.total,
                                     AuditoriaLavado.fechaCreada,
                                     AuditoriaLavado.fechaModificado,
                                     AuditoriaLavado.idLavadoAL,
                                     AuditoriaLavado.Lavado.idLavado,
                                     AuditoriaLavado.usuario.idUsuario,
                                     AuditoriaLavado.GrupoTrabajadores.idGrupo,
                                     AuditoriaLavado.ServicioLavado.idServicioLavado,
                                     AuditoriaLavado.VehiculoLavado.idVehiculoLavado,
                                     AuditoriaLavado.empleado.idEmpleado,
                                     AuditoriaLavado.LavadoVehiculo.idLavadoVehiculo
                                 }).ToList();
                dgvAuditoriaLavado.DataSource = resultado;
                dgvAuditoriaLavado.Columns["idLavadoAL"].Visible = false;
                dgvAuditoriaLavado.Columns["idLavado"].Visible = false;
                dgvAuditoriaLavado.Columns["idUsuario"].Visible = false;
                dgvAuditoriaLavado.Columns["idGrupo"].Visible = false;
                dgvAuditoriaLavado.Columns["idServicioLavado"].Visible = false;
                dgvAuditoriaLavado.Columns["idVehiculoLavado"].Visible = false;
                dgvAuditoriaLavado.Columns["idEmpleado"].Visible = false;
                dgvAuditoriaLavado.Columns["idLavadoVehiculo"].Visible = false;
            }
            if (rbtFecha.Checked)
            {
                var resultado = (from AuditoriaLavado in lista
                                 where AuditoriaLavado.fecha.ToString().StartsWith(textBox1.Text.ToUpper())
                                 select new
                                 {
                                     AuditoriaLavado.fecha,
                                     AuditoriaLavado.accion,
                                     Atendido_por = AuditoriaLavado.empleado.nombres,
                                     Vehiculo = AuditoriaLavado.VehiculoLavado.vehiculoLavado,
                                     AuditoriaLavado.placa,
                                     Grupo_Asignado = AuditoriaLavado.GrupoTrabajadores.grupoTrabajadores,
                                     Servicio_aplicado = AuditoriaLavado.ServicioLavado.servicioLavado,
                                     AuditoriaLavado.total,
                                     AuditoriaLavado.fechaCreada,
                                     AuditoriaLavado.fechaModificado,
                                     AuditoriaLavado.idLavadoAL,
                                     AuditoriaLavado.Lavado.idLavado,
                                     AuditoriaLavado.usuario.idUsuario,
                                     AuditoriaLavado.GrupoTrabajadores.idGrupo,
                                     AuditoriaLavado.ServicioLavado.idServicioLavado,
                                     AuditoriaLavado.VehiculoLavado.idVehiculoLavado,
                                     AuditoriaLavado.empleado.idEmpleado,
                                     AuditoriaLavado.LavadoVehiculo.idLavadoVehiculo
                                 }).ToList();
                dgvAuditoriaLavado.DataSource = resultado;
                dgvAuditoriaLavado.Columns["idLavadoAL"].Visible = false;
                dgvAuditoriaLavado.Columns["idLavado"].Visible = false;
                dgvAuditoriaLavado.Columns["idUsuario"].Visible = false;
                dgvAuditoriaLavado.Columns["idGrupo"].Visible = false;
                dgvAuditoriaLavado.Columns["idServicioLavado"].Visible = false;
                dgvAuditoriaLavado.Columns["idVehiculoLavado"].Visible = false;
                dgvAuditoriaLavado.Columns["idEmpleado"].Visible = false;
                dgvAuditoriaLavado.Columns["idLavadoVehiculo"].Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }
    }
}


