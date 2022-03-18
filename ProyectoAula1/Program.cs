using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoAula1
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            List<Paciente> pacientes = new List<Paciente>();
            menu(pacientes);
            
        }
        public static void menu(List<Paciente> pacientes)
        {
           int opcion;  
          

            Console.WriteLine("Bienvenid@ \n Menu de opciones: \n 1.Ingresar persona \n 2.Cambiar de EPS \n 3. Mostrar estadisticas \n" +
                " 4. Salir \n Digite su opcion:" );
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ingresarPersona(pacientes);
                    break;
                case 2:
                    cambiarEps(pacientes);
                    break;
                case 3:
                    total_y_PorcentajeCostosPorEps(pacientes);
                    porcentajeSinEnfermedades(pacientes);
                    pacienteMayorCostos(pacientes);
                    porcentajePacientesPorEdad(pacientes);
                    porcentajePorRegimen(pacientes);
                    porcentajePorAfiliacion(pacientes);
                    porcentajeEnfermedadCancer(pacientes);

                    break;
                case 4:
                    Console.WriteLine("Hasta luego");
                    break;
                default:
                    Console.WriteLine("No ingresó una opcion valida");
                    menu(pacientes);
                    break;
            }
        }
        public static void ingresarPersona(List<Paciente> pacientes)
        {
             string enfermedadRelevante;
             string historiaClinica;
             int cantidadEnfermedades;
             double costoTratamientos;
             string id;
             string nombres;
             string apellido;
             DateTime fechaNacimientoStr;
            DateTime fechaIngresoEpsStr;
            DateTime fechaIngresoSistemasStr;
             string eps;
             string regimen;
             string afiliacion;
             int semanasCotizadas;
            

            Console.WriteLine("Ingrese los nombres: ");
            nombres = Console.ReadLine();
            

            Console.WriteLine("Ingrese los apellidos: ");
            apellido = Console.ReadLine();

            Console.WriteLine("Ingrese la identificacion: ");
            id = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento de la manera dia,mes, año: dd/MM/yyy/ ");
            fechaNacimientoStr = Convert.ToDateTime(Console.ReadLine());        

            Console.WriteLine("Ingrese el tipo de regimen: \n 1.Contributivo \n 2.Subsidiado ");
            regimen = Console.ReadLine();

            Console.WriteLine("Ingrese las Semanas cotizadas en el sistema de salud: ");
            semanasCotizadas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese la fecha de ingreso al sistema de salud la manera dia,mes, año dd/MM/yyy/ ");
            fechaIngresoSistemasStr = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Ingrese la fecha de ingreso a la eps de la manera dia,mes, año: dd/MM/yyy/   ");
            fechaIngresoEpsStr = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Ingrese la EPS: 1.Sura \n 2.Nueva Eps \n 3.Salud Total \n 4.Sanitas \n 5.Savia");
            eps = Console.ReadLine();   

            Console.WriteLine("Ingrese la historia clinica: ");
            historiaClinica= Console.ReadLine();

            Console.WriteLine("Ingrese cantidad de enfermedades que padece: ");
            cantidadEnfermedades = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Ingrese la enfermedad mas relevante: ");
            enfermedadRelevante = Console.ReadLine().ToLower();

            Console.WriteLine("Ingrese el tipo de afiliacion a la EPS \n 1.Cotizante \n 2.Beneficiario ");
            afiliacion = Console.ReadLine();

            Console.WriteLine("Ingrese los costos de tratamientos: ");
            costoTratamientos = Convert.ToSingle(Console.ReadLine());

            Paciente paciente = new Paciente(enfermedadRelevante, historiaClinica, cantidadEnfermedades, costoTratamientos, id, nombres, apellido,
                fechaNacimientoStr, fechaIngresoEpsStr, fechaIngresoSistemasStr, eps, regimen, afiliacion, semanasCotizadas);

            pacientes.Add(paciente);
            menu(pacientes);

        }

        public static void cambiarEps(List<Paciente> pacientes)

        {
            string identificacion;
            Console.WriteLine("Ingrese la identificacion: ");
            identificacion = Console.ReadLine();

            Paciente pacienteEncontrado;
            

            for (int i = 0; i < pacientes.Count; i++)
            {
                if (pacientes[i].Id == identificacion)
                {   
                    
                    pacienteEncontrado = pacientes[i];
                    bool tiempo = calcularTiempoEnEps(pacienteEncontrado,pacienteEncontrado.FechaIngresoEpsStr);
                    if (tiempo == true)
                    {
                        Console.WriteLine("Ingrese la nueva eps 1.Sura \n 2.Nueva Eps \n 3.Salud Total \n 4.Sanitas \n 5.Savia ");
                        string nuevaEps = Console.ReadLine();
                        pacienteEncontrado.Eps = nuevaEps;
                        menu(pacientes);

                    }
                    else
                    {
                        Console.WriteLine("El paciente no ha superado el tiempo de 3 meses en su actual eps");
                        menu(pacientes);
                        
                        
                    }
                }
                
            }
            Console.WriteLine("No se encontro la id");
            menu(pacientes);
        }
        public static bool calcularTiempoEnEps(Paciente paciente, DateTime fechaIngresoPaciente)
        {
            DateTime fechaActual;
            int tiempoEnEps;

            
            fechaActual = DateTime.Now;

            tiempoEnEps = fechaIngresoPaciente.Month - fechaActual.Month;

            if (tiempoEnEps > 3)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static void total_y_PorcentajeCostosPorEps(List<Paciente> pacientes)
        {
            double costosSura, costosNuevaEps, costosSaludTotal, costosSanitas, costosSavia,costosTotales;

            costosSura = calcularCostosPorEps("1", pacientes);
            costosNuevaEps = calcularCostosPorEps("2", pacientes);
            costosSaludTotal = calcularCostosPorEps("3", pacientes);
            costosSanitas = calcularCostosPorEps("4", pacientes);
            costosSavia = calcularCostosPorEps("5", pacientes);

            Console.WriteLine("Total de costos de Sura: " + costosSura + "\nTotal costos de Nueva Eps: " + costosNuevaEps +
                "\nTotal de costos de Salud Total:" + costosSaludTotal + "\nTotal de costos de Sanitas: " + costosSanitas +
                "\nTotal de costos de Savia: " + 
                costosSavia);

            costosTotales = costosSura + costosNuevaEps + costosSaludTotal + costosSanitas + costosSavia;

            Console.WriteLine("El porcentaje de costos de Sura es: " + (costosSura / costosTotales) * 100 + "%");
            Console.WriteLine("El porcentaje de costos de Nueva Eps es: " + (costosNuevaEps / costosTotales) * 100 + "%");
            Console.WriteLine("El porcentaje de costos de Salud Total es: " + (costosSaludTotal / costosTotales) * 100 + "%");
            Console.WriteLine("El porcentaje de costos de Sanitas es: " + (costosSanitas / costosTotales) * 100 + "%");
            Console.WriteLine("El porcentaje de costos de Savia es: " + (costosSavia / costosTotales) * 100 + "%");
        }   
            


        public static double calcularCostosPorEps(string Eps, List<Paciente> pacientes)
        {
            double suma;
            var pacientesConEpsACalcular = pacientes.Where(x => x.Eps == Eps).ToList();
            suma = pacientesConEpsACalcular.Sum(x => x.CostoTratamientos);

            return suma;
        }   
            

 
        public static void porcentajeSinEnfermedades(List<Paciente> pacientes)
        {
            
            double totalPacientes = 0;
          
            int totalPacientesSinEnfermedades = 0;
            foreach (Paciente paciente in pacientes)
            {
                if (paciente.CantidadEnfermedades == 0)
                {
                    totalPacientesSinEnfermedades +=1;
                }
                totalPacientes += 1;
            }  

           Console.WriteLine("El porcentaje de pacientes sin enfermedades son: " + (totalPacientesSinEnfermedades / totalPacientes)
               * 100 + "%");
        }

        public static void pacienteMayorCostos(List<Paciente> pacientes)
        {
            var pacientesOrdenadosPorCostoDeTratamiento = pacientes.OrderByDescending(x=> x.CostoTratamientos).ToList();
            var primero = pacientesOrdenadosPorCostoDeTratamiento.First();
            
            Console.WriteLine("El paciente con mayor costos es: " + primero.Nombres + " " + primero.Apellido + " con Id: " + primero.Id);
            
        }

        public static int calcularEdad(DateTime FechaNacimiento)
        {
            int edad;
            edad = DateTime.Now.Year - FechaNacimiento.Year;
            return edad;
        }

        public static void porcentajePacientesPorEdad(List<Paciente> pacientes)
        {
            int edad;
            double totalPacientes = 0;
            int contNiños = 0, contAdolescentes = 0, contJovenes = 0, contAdultos = 0, contAdultoMayor = 0, contAncianos = 0;

            foreach(Paciente paciente in pacientes)
            {
                edad = calcularEdad(paciente.FechaNacimientoStr);
                if ((edad >= 0 && edad < 12))
                {
                    contNiños += 1;
                }
                else if ((edad >= 12 && edad < 17))
                {
                    contJovenes += 1;
                }
                else if ((edad >= 18 && edad < 30))
                {
                    contAdolescentes += 1;
                }
                else if ((edad >= 30 && edad < 55))
                {
                    contAdultos += 1;   
                }
                else if ((edad >= 55 && edad < 75))
                {
                    contAdultoMayor +=1;
                }
                else if ((edad >= 75))
                {
                    contAncianos += 1;
                }

                totalPacientes += 1;
            }

            Console.WriteLine("El porcentaje de niños es: " + (contNiños / totalPacientes) * 100 + "%");
            Console.WriteLine("El porcentaje de jovenes es: " + (contJovenes / totalPacientes) * 100 + "%");
            Console.WriteLine("El porcentaje de Adolescentes es: " + (contAdolescentes / totalPacientes) * 100 + "%");
            Console.WriteLine("El porcentaje de Adultos es: " + (contAdultos / totalPacientes) * 100 + "%");
            Console.WriteLine("El porcentaje de Adultos mayores es: " + (contAdultoMayor / totalPacientes) * 100 + "%");
            Console.WriteLine("El porcentaje de Ancianos es: " + (contAncianos / totalPacientes) * 100 + "%");

        }

        public static void porcentajePorRegimen(List<Paciente> pacientes)
        {
            int contContributivos = 0;
            int contSubsidiados = 0;
            double totalPacientes = 0;

            foreach (Paciente paciente in pacientes)
            {
                if (paciente.Regimen == "1")
                {
                    contContributivos+=1;
                }
                else if (paciente.Regimen == "2")   
                {
                    contSubsidiados +=1;
                }

                totalPacientes += 1;
            }
            
            Console.WriteLine("El porcentaje de contributivos es: " + (contContributivos / totalPacientes) * 100 + "%");
            Console.WriteLine("El porcentaje de subsidiados es: " + (contSubsidiados / totalPacientes) * 100 + "%");
        }

        public static void porcentajePorAfiliacion(List<Paciente> pacientes)
        {
            int contCotizantes = 0;
            int contBeneficiarios = 0;
            double totalPacientes = 0;

            foreach (Paciente paciente in pacientes)
            {
                if (paciente.Afiliacion == "1")
                {
                    contCotizantes += 1;
                }
                else if (paciente.Afiliacion == "2")
                {
                    contBeneficiarios += 1;
                }
                totalPacientes += 1;
            }  

            
            Console.WriteLine("El porcentaje de Beneficiarios es: " + (contBeneficiarios / totalPacientes) * 100 + "%");
            Console.WriteLine("El porcentaje de Cotizantes es: " + (contCotizantes / totalPacientes) * 100 + "%");
        }

        public static void porcentajeEnfermedadCancer(List<Paciente> pacientes)
        {
            int contPacientesCancer = 0;
            double totalPacientes = 0;
            double porcentajeEnfermedadCancer;
            foreach (Paciente paciente in pacientes)
            {
                if ((paciente.EnfermedadRelevante == "cancer" || paciente.EnfermedadRelevante == "cáncer"))
                {
                    contPacientesCancer += 1;
                    
                }
                totalPacientes += 1;
            }
           
            porcentajeEnfermedadCancer = (contPacientesCancer / totalPacientes) * 100;
            Console.WriteLine("El porcentaje de pacientes con cancer es: " + porcentajeEnfermedadCancer + " %");

            menu(pacientes);
        }

        

    }   



   
}
