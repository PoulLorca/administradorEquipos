using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace administradorEquipos.Views
{
    /// <summary>
    /// Lógica de interacción para ListarEquipos.xaml
    /// </summary>
    public partial class ListarEquipos : Window
    {
        public ListarEquipos()
        {
            InitializeComponent();

            dgListaEquipos.ItemsSource = Models.EquipoCollection.Equipos;
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            int index = dgListaEquipos.SelectedIndex;
            Models.Equipo equipoEditar = Models.EquipoCollection.Equipos[index];
            ActualizarEquipo ventanaActualizar = new ActualizarEquipo(equipoEditar, index);
            ventanaActualizar.ShowDialog();
            Close();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            int index = dgListaEquipos.SelectedIndex;
            Models.EquipoCollection.Equipos.RemoveAt(index);
            dgListaEquipos.Items.Refresh();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            dgListaEquipos.Items.Refresh();
        }
    }
}
