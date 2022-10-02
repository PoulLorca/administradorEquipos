using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica de interacción para AgregarEquipo.xaml
    /// </summary>
    public partial class AgregarEquipo : Window
    {
        public AgregarEquipo()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try { 
                string nombreEquipo = txtNombre.Text;
                int cantidadJugadores = int.Parse(txtCantidad.Text);
                string nombreDt = txtNombreDt.Text;
                string tipoEquipo = txtTipoEquipo.Text;
                string capitanEquipo = txtCapitanEquipo.Text;
                Boolean sub21 = chkSub21.IsChecked ?? false;

                Models.Equipo nuevoEquipo = new(nombreEquipo, cantidadJugadores, nombreDt, tipoEquipo, capitanEquipo, sub21);

                Models.EquipoCollection.Equipos.Add(nuevoEquipo);        

                MessageBox.Show("Nuevo equipo agregado");

                clearForm();

            }
            catch
            {
                MessageBox.Show("Error: " + e);
            }
        }

        private void clearForm()
        {
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtNombreDt.Text = "";
            txtTipoEquipo.Text = "";
            txtCapitanEquipo.Text = "";
            chkSub21.IsChecked = false;
        }

        private static Regex n_regex = new Regex("[^0-9]+");

        private void txtCantidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = n_regex.IsMatch(e.Text);
        }
    }
}
