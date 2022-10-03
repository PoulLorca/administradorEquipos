using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para ActualizarEquipo.xaml
    /// </summary>
    public partial class ActualizarEquipo : Window
    {
        public ActualizarEquipo( Models.Equipo equipoEditar, int index)
        {
            InitializeComponent();
            txtNombre.Text = equipoEditar.NombreEquipo;
            txtCantidad.Text = equipoEditar.CantidadJugadores.ToString();
            txtNombreDt.Text = equipoEditar.NombreDt;
            txtTipoEquipo.Text = equipoEditar.TipoEquipo;
            txtCapitanEquipo.Text = equipoEditar.CapitanEquipo;
            chkSub21.IsChecked = equipoEditar.TieneSub21;
            txtIndex.Text = index.ToString();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombreEquipo = txtNombre.Text;
                int cantidadJugadores = int.Parse(txtCantidad.Text);
                string nombreDt = txtNombreDt.Text;
                string tipoEquipo = txtTipoEquipo.Text;
                string capitanEquipo = txtCapitanEquipo.Text;
                Boolean sub21 = chkSub21.IsChecked ?? false;

                int index = int.Parse(txtIndex.Text);

                Models.Equipo nuevoEquipo = new(nombreEquipo, cantidadJugadores, nombreDt, tipoEquipo, capitanEquipo, sub21);

                Models.EquipoCollection.Equipos[index] = nuevoEquipo;

                MessageBox.Show("Equipo Actualizado");

                ListarEquipos ventanaListar = new ListarEquipos();
                ventanaListar.Show();

                Close();
            }
            catch
            {
                MessageBox.Show("Error: " + e);
            }
        }

        private static Regex n_regex = new Regex("[^0-9]+");

        private void txtCantidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = n_regex.IsMatch(e.Text);
        }
    }
}
