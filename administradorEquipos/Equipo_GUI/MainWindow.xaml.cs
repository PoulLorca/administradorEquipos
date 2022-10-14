using Equipo_Negocio;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Equipo_GUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Equipo_Negocio.EquiposCollection equipoCollection;
        Equipo_Negocio.EquipoReportes equipoReportes;
        public MainWindow()
        {
            InitializeComponent();
            equipoCollection = new Equipo_Negocio.EquiposCollection();
            CargarGrilla();
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            Views.AgregarEquipo ventanaAgregar = new Views.AgregarEquipo();
            ventanaAgregar.ShowDialog();

        }

        private void ListarTodos_Click(object sender, RoutedEventArgs e)
        {
            Views.ListarEquipos ventanaListar = new Views.ListarEquipos();
            ventanaListar.ShowDialog();

        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Views.AcercaDe ventanaAbout = new Views.AcercaDe();
            ventanaAbout.ShowDialog();
        }   

        private void Window_Activated(object sender, EventArgs e)
        {
            CargarGrilla();
        }
        
        private void CargarGrilla()
        {
            dgEquipos.ItemsSource = equipoCollection.ReadAll();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            equipoReportes = new Equipo_Negocio.EquipoReportes();
            int equiposMasculinos = equipoReportes.ReporteEquiposMasculinos();
            int equiposFemeninos = equipoReportes.ReporteEquiposFemeninos();
            string message = string.Format(
                "Equipos Masculinos: {0} \n" +
                "Equipos Femeninos: {1}",
                equiposMasculinos,
                equiposFemeninos
                );
            MessageBox.Show(message);
        }
    }
}
