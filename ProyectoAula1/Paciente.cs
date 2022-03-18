using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAula1
{
    internal class Paciente
    {
        private string enfermedadRelevante;
        private string historiaClinica;
        private int cantidadEnfermedades;
        double costoTratamientos;
        private string id;
        private string nombres;
        private string apellido;
        private DateTime fechaNacimientoStr;
        private DateTime fechaIngresoEpsStr;
        private DateTime fechaIngresoSistemasStr;
        private string eps;
        private string regimen;
        private string afiliacion;
        private int semanasCotizadas;

        public Paciente(string enfermedadRelevante, string historiaClinica, int cantidadEnfermedades, double costoTratamientos, string id,
            string nombres, string apellido, DateTime fechaNacimientoStr, DateTime fechaIngresoEpsStr, DateTime fechaIngresoSistemasStr, string eps,
            string regimen, string afiliacion, int semanasCotizadas)
        {
            this.EnfermedadRelevante = enfermedadRelevante;
            this.HistoriaClinica = historiaClinica;
            this.CantidadEnfermedades = cantidadEnfermedades;
            this.CostoTratamientos = costoTratamientos;
            this.Id = id;
            this.Nombres = nombres;
            this.Apellido = apellido;
            this.FechaNacimientoStr = fechaNacimientoStr;
            this.FechaIngresoEpsStr = fechaIngresoEpsStr;
            this.FechaIngresoSistemasStr = fechaIngresoSistemasStr;
            this.Eps = eps;
            this.Regimen = regimen;
            this.Afiliacion = afiliacion;
            this.SemanasCotizadas = semanasCotizadas;
        }

        public string EnfermedadRelevante { get => enfermedadRelevante; set => enfermedadRelevante = value; }
        public string HistoriaClinica { get => historiaClinica; set => historiaClinica = value; }
        public int CantidadEnfermedades { get => cantidadEnfermedades; set => cantidadEnfermedades = value; }
        public double CostoTratamientos { get => costoTratamientos; set => costoTratamientos = value; }
        public string Id { get => id; set => id = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaNacimientoStr { get => fechaNacimientoStr; set => fechaNacimientoStr = value; }
        public DateTime FechaIngresoEpsStr { get => fechaIngresoEpsStr; set => fechaIngresoEpsStr = value; }
        public DateTime FechaIngresoSistemasStr { get => fechaIngresoSistemasStr; set => fechaIngresoSistemasStr = value; }
        public string Eps { get => eps; set => eps = value; }
        public string Regimen { get => regimen; set => regimen = value; }
        public string Afiliacion { get => afiliacion; set => afiliacion = value; }
        public int SemanasCotizadas { get => semanasCotizadas; set => semanasCotizadas = value; }



        //private int edad;
        //private DateTime fechaNacimientoDate;
        //private DateTime fechaIngresoEpsDate;
        //private DateTime fechaIngresoSistema;
        //private DateTime fechaActual;



        //public int calcularEdadPaciente()
        //{
        //    FechaNacimientoDate = DateTime.ParseExact(FechaNacimientoStr, "dd/MM/yyyy", null);
        //    FechaActual = DateTime.Now;
        //    Edad = FechaActual.Year - FechaNacimientoDate.Year;

        //    return Edad;

        //}
    }



}
