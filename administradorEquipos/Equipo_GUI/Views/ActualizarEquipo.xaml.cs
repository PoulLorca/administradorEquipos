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
    /// Lógica de interacción para ActualizarEquipo.xaml
    /// </summary>
    public partial class ActualizarEquipo : Window
    {
        private static Regex n_regex = new Regex("[^0-9]+");
        Equipo_Negocio.Equipo equipo;

        public ActualizarEquipo(int id)
        {
            InitializeComponent();
            this.Title = String.Format("Actualizar equipo {0}", id);

            equipo = new Equipo_Negocio.Equipo();

            CargarFormulario(id);
        }

        private void CargarFormulario(int id)
        {
            bool response = equipo.Read(id);
            if (response)
            {
                txtIndex.Text = id.ToString();
                txtNombre.Text = equipo.NombreEquipo;
                txtCantidad.Text = equipo.CantidadJugadores.ToString();
                txtNombreDt.Text = equipo.NombreDt;
                txtTipoEquipo.Text = equipo.TipoEquipo;
                txtCapitanEquipo.Text = equipo.CapitanEquipo;
                chkSub21.IsChecked = (equipo.TieneSub21) ? true : false;

            }
            else
            {
                MessageBox.Show(string.Format("El equipo {0} no fue encotrado"), id.ToString());
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
                equipo.Id = Convert.ToInt32(txtIndex.Text);
                equipo.NombreEquipo = txtNombre.Text;
                equipo.CantidadJugadores = Convert.ToInt32(txtCantidad.Text);
                equipo.NombreDt = txtNombreDt.Text;
                equipo.TipoEquipo = txtTipoEquipo.Text;
                equipo.CapitanEquipo = txtCapitanEquipo.Text;
                equipo.TieneSub21 = (chkSub21.IsChecked.Value) ? true : false;

                bool response = equipo.Update();

                if (response)
                {
                    MessageBox.Show(String.Format("Equipo {0} actualizado correctamente", equipo.NombreEquipo));             
                }
                else
                {
                    MessageBox.Show(String.Format("No se pudo actualizar el equipo {0}", equipo.NombreEquipo));
                    this.Close();
                }          

        }        

        private void txtCantidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = n_regex.IsMatch(e.Text);
        }
    }
}
