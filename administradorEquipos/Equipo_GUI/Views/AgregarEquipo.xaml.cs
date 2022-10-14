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

namespace Equipo_GUI.Views
{
    /// <summary>
    /// Lógica de interacción para AgregarEquipo.xaml
    /// </summary>
    public partial class AgregarEquipo : Window
    {
        private static Regex n_regex = new Regex("[^0-9]+");

        public AgregarEquipo()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Equipo_Negocio.Equipo equipo = new Equipo_Negocio.Equipo();
                equipo.NombreEquipo = txtNombre.Text;
                equipo.CantidadJugadores = Convert.ToInt32(txtCantidad.Text);
                equipo.NombreDt = txtNombreDt.Text;
                equipo.TipoEquipo = txtTipoEquipo.Text;
                equipo.CapitanEquipo = txtCapitanEquipo.Text;
                equipo.TieneSub21 = (chkSub21.IsChecked.Value) ? true : false;

                bool response = equipo.Create();

                if (response)
                {
                    MessageBox.Show("Equipo agregado correctamente");
                    AgregarOtroEquipo();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error intente más tarde");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AgregarOtroEquipo()
        {
            string title = "Agregar otro equipo";
            string message = "¿Desea agregar otro equipo";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message,title, buttons);

            if(result == MessageBoxResult.No)
            {
                this.Close();
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = String.Empty;
            txtCantidad.Text = String.Empty;
            txtNombreDt.Text = String.Empty;
            txtTipoEquipo.Text = String.Empty;
            chkSub21.IsChecked = false;

        }
        
        private void txtCantidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = n_regex.IsMatch(e.Text);
        }
    }
}
