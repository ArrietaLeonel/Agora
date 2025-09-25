using System.Data;
using System.Threading.Tasks;
using System.Windows.Controls;
using Service.Interfaces;
using Service.Models;
using Service.Services;

namespace Desktop.Views
{
    public partial class CapacitacionesView : Form
    {
        GenericService<Capacitacion> capacitacionService = new GenericService<Capacitacion>();
        Capacitacion currentCapacitacion;
        List<Capacitacion>? capacitaciones;

        public CapacitacionesView()
        {
            InitializeComponent();
            _ = GetAllData();
            checkVerEliminados.CheckedChanged += DisplayHideControlsRestoreButton;
        }
        private void DisplayHideControlsRestoreButton(object? sender, EventArgs e)
        {
            btnRestaurar.Visible = checkVerEliminados.Checked;
            TxtBuscar.Enabled = !checkVerEliminados.Checked;
            BtnModificar.Enabled = !checkVerEliminados.Checked;
            BtnEliminar.Enabled = !checkVerEliminados.Checked;
            BtnAgregar.Enabled = !checkVerEliminados.Checked;
            BtnBuscar.Enabled = !checkVerEliminados.Checked;
        }

        private async Task GetAllData()
        {
            if (checkVerEliminados.Checked)
            {
                capacitaciones = await capacitacionService.GetAllDeletedsAsync("");

            }
            else
            {
                capacitaciones = await capacitacionService.GetAllAsync();
            }
            GridCapacitaciones.DataSource = capacitaciones;
            GridCapacitaciones.Columns["Id"].Visible = false;
            GridCapacitaciones.Columns["IsDeleted"].Visible = false;

        }

        private void GridPeliculas_SelectionChanged_1(object sender, EventArgs e)
        {
            // currentCapacitacion = (Capacitacion)GridPeliculas.CurrentRow?.DataBoundItem;
        }

        private async void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            //checheamos que haya peliculas seleccionadas
            if (GridCapacitaciones.RowCount > 0 && GridCapacitaciones.SelectedRows.Count > 0)
            {
                Capacitacion entitySelected = (Capacitacion)GridCapacitaciones.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que desea eliminar la capacitación {entitySelected.Nombre}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (await capacitacionService.DeleteAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Capacitación {entitySelected.Nombre} eliminada correctamente";
                        TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la capacitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una capacitación para eliminarla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControlesAgregarEditar();
            TabControl.SelectTab("TabPageAgregarEditar");
        }

        private void LimpiarControlesAgregarEditar()
        {
            txtNombre.Clear();
            txtOrador.Clear();
            dateTimePFechayHora.Value = DateTime.Now;
            checkBoxInscripicionAbierta.Checked = false;
            numericCupo.Value = 0;
            txtDetalle.Clear();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TabControl.SelectTab("TabPageLista");

        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            Capacitacion capacitacionModificada = new Capacitacion
            {
                Id = currentCapacitacion?.Id ?? 0,
                Nombre = txtNombre.Text,
                Detalle = txtDetalle.Text,
                Ponente = txtOrador.Text,
                FechaHora = dateTimePFechayHora.Value,
                Cupo = (int)numericCupo.Value,
            };

            bool response;
            if (capacitacionModificada != null)
            {
                response = await capacitacionService.UpdateAsync(capacitacionModificada);
            }
            else
            {
                var nuevaCapacitacion = await capacitacionService.AddAsync(capacitacionModificada);
                response = nuevaCapacitacion != null;
            }
            if (response)
            {
                currentCapacitacion = null; // Reset the modified movie after saving
                LabelStatusMessage.Text = $"Capacitación {capacitacionModificada.Nombre} guardada correctamente";
                TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                await GetAllData();
                LimpiarControlesAgregarEditar();
                TabControl.SelectTab("TabPageLista");
            }
            else
            {
                MessageBox.Show("Error al agregar la capacitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //checheamos que haya peliculas seleccionadas
            if (GridCapacitaciones.RowCount > 0 && GridCapacitaciones.SelectedRows.Count > 0)
            {
                currentCapacitacion = (Capacitacion)GridCapacitaciones.SelectedRows[0].DataBoundItem;
                txtNombre.Text = currentCapacitacion.Nombre;
                txtDetalle.Text = currentCapacitacion.Detalle;
                txtOrador.Text = currentCapacitacion.Ponente;
                dateTimePFechayHora.Value = currentCapacitacion.FechaHora;
                numericCupo.Value = currentCapacitacion.Cupo;
                checkBoxInscripicionAbierta.Checked = currentCapacitacion.InscripcionAbierta;


                TabControl.SelectedTab = TabPageAgregarEditar;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una capacitación para modificarla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            GridCapacitaciones.DataSource = await capacitacionService.GetAllAsync(TxtBuscar.Text);

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            BtnBuscar.PerformClick();
        }

        private void TimerStatusBar_Tick(object sender, EventArgs e)
        {
            LabelStatusMessage.Text = string.Empty;
            TimerStatusBar.Stop(); // Detener el temporizador después de mostrar el mensaje
        }

        private async void checkVerEliminados_CheckedChanged(object sender, EventArgs e)
        {
            await GetAllData();
        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            if(!checkVerEliminados.Checked)return;

            if (GridCapacitaciones.RowCount > 0 && GridCapacitaciones.SelectedRows.Count > 0)
            {
                Capacitacion entitySelected = (Capacitacion)GridCapacitaciones.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que desea restaurar la capacitación {entitySelected.Nombre}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (await capacitacionService.RestoreAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Capacitación {entitySelected.Nombre} restaurada correctamente";
                        TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al restaurar la capacitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una capacitación para restaurar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
