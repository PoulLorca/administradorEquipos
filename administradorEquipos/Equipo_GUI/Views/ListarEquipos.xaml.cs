using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Equipo_GUI.Views
{
    /// <summary>
    /// Lógica de interacción para ListarEquipos.xaml
    /// </summary>
    public partial class ListarEquipos : Window
    {
        Equipo_Negocio.EquiposCollection equipoCollection;
        public ListarEquipos()
        {
            InitializeComponent();
            CargarGrilla();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            var filaSeleccionada = (Equipo_Negocio.Equipo)dgListaEquipos.SelectedItem;
            ActualizarEquipo actualizarEquipo = new ActualizarEquipo(filaSeleccionada.Id);
            actualizarEquipo.ShowDialog();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            EliminarRegistroSeleccionado();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            equipoCollection = new Equipo_Negocio.EquiposCollection();
            dgListaEquipos.ItemsSource = equipoCollection.ReadAll();
        }

        private void EliminarRegistroSeleccionado()
        {
            var filaSeleccionada = (Equipo_Negocio.Equipo)dgListaEquipos.SelectedItem;
            int id = filaSeleccionada.Id;
            string title = "Eliminar Equipo";
            string message = string.Format("¿Estas seguro de eliminar el equipo {0} ?", filaSeleccionada.NombreEquipo);

            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message, title, button);

            if(result == MessageBoxResult.Yes)
            {
                var res = filaSeleccionada.Delete(id) ?
                MessageBox.Show(string.Format("Equipo {0} eliminado", filaSeleccionada.NombreEquipo)) :
                MessageBox.Show("El equipo no pudo ser eliminado");
            }

        }
    }
}
