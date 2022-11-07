using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Negocio
{
    public class Equipo : ObservableObject, IPersistente
    {
        public int Id { get; set; }

        public string _nombreEquipo;
        public int _cantidadJugadores;
        public string _nombreDT;
        public string _capitanEquipo;

        [Required(ErrorMessage = "El campo es requerido")]
        [IsValidNombreEquipo(ErrorMessage = "El nombre ingresado no es valido")]
        public string NombreEquipo
        { 
            get { return _nombreEquipo; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))                
                    throw new ArgumentNullException(null,"El nombre es obligatorio");

                if(value.ToString().Length <= 8 || value.ToString().Length >= 25)
                    throw new ArgumentNullException(null, "El largo no corresponde");

                //ValidateProperty(value);
                OnPropertyChanged(ref _nombreEquipo, value);
            }
        }

        [IsValidCantidadJugadores(ErrorMessage = "La cantidad ingresada no es valida")]
        public int CantidadJugadores 
        { 
            get { return _cantidadJugadores; }
            set
            {
                //ValidateProperty(value);
                OnPropertyChanged(ref _cantidadJugadores, value);
            } 
        }

        [Required(ErrorMessage = "El campo es requerido")]
        [IsValidNombreDT(ErrorMessage = "El nombre ingresado no es valido")]
        public string NombreDt 
        {
            get { return _nombreDT; }
            set
            {
                //ValidateProperty(value);
                OnPropertyChanged(ref _nombreDT, value);
            }
        }
        public string TipoEquipo { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [IsValidCapitanEquipo(ErrorMessage = "El nombre ingresado no es valido")]
        public string CapitanEquipo
        {
            get { return _capitanEquipo; }
            set
            {
                //ValidateProperty(value);
                OnPropertyChanged(ref _capitanEquipo, value);
            }
        }
        public bool TieneSub21 { get; set; }

        /*
        private void ValidateProperty<T>(T value, [CallerMemberName] string name = "")
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }
        */

        public bool Create()
        {
            try
            {
                CommonBC.ModeloEquipo.spEquipoSave(
                this.NombreEquipo,
                this.CantidadJugadores,
                AES_Helper.EncryptString(this._nombreDT),
                this.TipoEquipo,
                AES_Helper.EncryptString(this._capitanEquipo),
                this.TieneSub21
                );

                CommonBC.ModeloEquipo.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }

        }

        public bool Read(int EquipoId)
        {
            try
            {
                Equipo_DALC.vwEquipo equipo = CommonBC.ModeloEquipo.vwEquipo.First(e => e.EquipoId == EquipoId);

                this.NombreEquipo = equipo.NombreEquipo;
                this.CantidadJugadores = equipo.CantidadJugadores;
                this.NombreDt = AES_Helper.DecryptString(equipo.NombreDT);
                this.TipoEquipo = equipo.TipoEquipo;
                this.CapitanEquipo = AES_Helper.DecryptString(equipo.CapitanEquipo);
                this.TieneSub21 = equipo.TieneSub21;

                return true;

            }
            catch 
            {
                return false;
            }

        }

        public bool Update()
        {
            try
            {                                                
                CommonBC.ModeloEquipo.spEquipoUpdateById(
                    this.Id,
                    this.NombreEquipo,
                    this.CantidadJugadores,
                    AES_Helper.EncryptString(this.NombreDt),
                    this.TipoEquipo,
                    AES_Helper.EncryptString(this.CapitanEquipo),
                    this.TieneSub21
                    );

                CommonBC.ModeloEquipo.SaveChanges();

                return true;

            }
            catch 
            {
                return false;
            }
        }

        public bool Delete(int EquipoId)
        {
            try
            {
                CommonBC.ModeloEquipo.spEquipoDeleteById(EquipoId);
                CommonBC.ModeloEquipo.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
