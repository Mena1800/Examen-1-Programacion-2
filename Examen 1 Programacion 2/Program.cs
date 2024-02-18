// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using System.Net.Http.Headers;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Paciente
{
    public double Cedula { get; set; }
    public string Nombre { get; set; }
    public double Telefono { get; set; }
    public string Direccion { get; set; }
    public string Tipodesangre { get; set; }
    public double Fechanacimiento { get; set; }
    public List<treatment> Treatments { get; set; }

    public Paciente(double cedula, string nombre,double telefono,string direccion, string tipodesangre, double fechanacimiento) 
    {
        cedula= Cedula;
        nombre= Nombre;
        telefono= Telefono;
        direccion= Direccion;
        tipodesangre= Tipodesangre;
        fechanacimiento = Fechanacimiento;
        Treatments = new List<treatment>();
    }
    public void Asigntreatment(treatment Treatment)
    {
        Treatments.Add(Treatment);
    }

}

public class Medicamento
{
    public double Codigo { get; set; }
    public string Nombmed { get; set; }
    public double Canmed { get; set; }

    public Medicamento(double codigo, string nombmed, double canmed)
    {
        codigo= Codigo;
        nombmed= Nombmed;
        canmed= Canmed;

    }

    public void Reducirinventario(int canmed)
    {
        Canmed -= canmed;

    }
    public ArrayList codigomed = new ArrayList();
    public ArrayList Nombremed = new ArrayList();
    public ArrayList cantidadmed = new ArrayList();
}

public class treatment
{
    public Medicamento Medicamento { get; set; }
    public double Canmed { get; set; }


    public treatment(Medicamento medicamento, double canmed)
    {
        Medicamento = medicamento;
        Canmed = canmed;
    }
}

class Program
{
    static List<Paciente> Pacientes = new List<Paciente>();
    static int numpacientes = 0;
    static List<Medicamento> Medicamentos = new List<Medicamento>();
    static int nummedicamentos = 0;
    static List<treatment> Treatments= new List<treatment>();
    static void Main(string[] args)
    {
        bool salir = false;
        int opcion;
        do
        {
            
            Console.WriteLine("Bienvenido al Sistema de Gestión de Pacientes y Consultas Médicas");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Menu principal");
            Console.WriteLine("1. Agregar paciente");
            Console.WriteLine("2. Agregar medicamento al catálogo");
            Console.WriteLine("3. Asignar tratamiento médico a un paciente");
            Console.WriteLine("4. Consultas");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una de las opciones: ");
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        agregpaci();
                        break;
                        salir = false;
                    case 2:
                        catalmed();
                        break;
                        salir = false;
                    case 3:
                        asigtratpac();
                        break;
                        salir = false;
                    case 4:
                        Consultas();
                        break;
                        salir = false;

                    case 5:
                        Console.WriteLine("Saliendo del programa, muchas gracias!");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opcion invalida, por favor, seleccione una opcion valida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("digito invalida, por favor, ingrese un numero dentro del rango");
            }


        } while (salir==false);
    }


       

    static void agregpaci()

    {
        bool Seguimos = true;
        int seguir = 0;
        do
        {
            if (nummedicamentos < 10)
            {
                Console.WriteLine("Ingrese los datos del paciente:");
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Telefono: ");
                double telefono;
                if (!double.TryParse(Console.ReadLine(), out telefono))
                {
                    Console.WriteLine("Numero de telefono invalido, ingrese un numero de telefono valido");
                    Console.WriteLine("Será redireccionado al menu principal");
                    return;
                }
                Console.Write("Cedula: ");
                double cedula;
                if (!double.TryParse(Console.ReadLine(), out cedula))
                {
                    Console.WriteLine("Numero de cedula invalido, ingrese un numero de cedula valido");
                    Console.WriteLine("Será redireccionado al menu principal");
                    return;
                }
                Console.Write("Tipo de sangre: ");
                string tipodesangre = Console.ReadLine();
                Console.WriteLine("Dirección: ");
                string direccion = Console.ReadLine();
                Console.WriteLine("Fecha de nacimiento: ");
                double fechanacimiento;
                if (!double.TryParse(Console.ReadLine(), out fechanacimiento))
                {
                    Console.WriteLine("Fecha de nacimiento invalida, ingrese una fecha de nacimiento valida");
                    Console.WriteLine("Será redireccionado al menu principal");
                    return;
                }

                Paciente paciente = new Paciente(cedula,nombre,telefono,direccion,tipodesangre, fechanacimiento );
                Pacientes.Add(paciente);
                numpacientes++;
                Console.WriteLine("Paciente agregado");
                Console.WriteLine("Desea agregar otro paciente: 1/Si 2/No");
                seguir = int.Parse(Console.ReadLine());
                if (seguir==1)
                {
                    Seguimos = true;
                }
                else
                {
                    Seguimos = false;
                    Console.Clear();
                }


            }
            else
            {
                Console.WriteLine("No se pueden incluir mas pacientes ya el limite de 10 pacientes ha sido alcanzado");
            }
        } while (Seguimos==true);
    }
    static void catalmed()
    {
        bool seguiremos = true;
        int seguire = 0;
        do
        {
            if (nummedicamentos < 10)
            {
                Console.WriteLine("Ingrese los datos del medicamento:");
                Console.Write("Codigo del medicamento: ");
                double codigo;
                if (!double.TryParse(Console.ReadLine(), out codigo))
                {
                    Console.WriteLine("Codigo invalido, ingrese un Codigo valido");
                    Console.WriteLine("Será redireccionado al menu principal");
                    return;
                }
                Console.Write("Nombre del medicamento: ");
                string nombmed = Console.ReadLine();
                Console.Write("Cantidad de medicamentos: ");
                double canmed;
                if (!double.TryParse(Console.ReadLine(), out canmed))
                {
                    Console.WriteLine("Cantidad invalida, ingrese una cantidad valida");
                    Console.WriteLine("Será redireccionado al menu principal");
                    return;
                }

                Medicamento medicamentos = new Medicamento(codigo, nombmed, canmed);
                Medicamentos.Add(medicamentos);
                nummedicamentos++;


                Console.WriteLine("Medicamento agregado");
                Console.WriteLine("Desea agregar otro medicamento: 1/Si 2/No");
                seguire = int.Parse(Console.ReadLine());
                if (seguire == 1)
                {
                    seguiremos = true;
                }
                else
                {
                    seguiremos = false;
                    Console.Clear();
                }


            }
            else
            {
                Console.WriteLine("No se pueden agregar mas Medicamentos ya el limite de 10 medicamentos ha sido alcanzado");
            }
        } while (seguiremos == true);

    }

    static void asigtratpac()
    {
        int Cedulaasignar = 0;
        bool encontrados = false;
        //int codigoasignar = 0;
        int cantidadmedic = 0;
        if (Medicamentos.Count == 0 || Pacientes.Count == 0)
        {
            Console.WriteLine("No se han agregado pacientes");
            Console.WriteLine("Será redireccionado al menu principal");
            return;
        }
        Console.WriteLine("Ingrese el numero de cedula del paciente al cual desea agregar un tratamiento: ");
        Cedulaasignar = int.Parse(Console.ReadLine());
        foreach (var Paciente in Pacientes)
        {
            if (Paciente != null && Paciente.Cedula == Cedulaasignar)
            {
                Console.WriteLine($"Cedula: {Paciente.Cedula}, Nombre: {Paciente.Nombre}");
                encontrados = true;
                break;
            }
           // if (!encontrados)
            //{
              //  Console.WriteLine("Paciente no encontrado.");
                //return;
            //}
        }
        Console.WriteLine("Ingrese el codigo del medicamento que desea agregar: ");
        int codigoasignar = Convert.ToInt32(Console.ReadLine());
        Medicamento medicamento = Medicamentos.FirstOrDefault(m => m.Codigo == codigoasignar);
        Paciente paciente = Pacientes[codigoasignar];
        foreach (var Medicamento in Medicamentos)
        {
            if (Medicamento != null && Medicamento.Codigo == codigoasignar)
            {
                Console.WriteLine($"El Medicamento ha sido encontrado, el medicamento {Medicamento.codigomed} contiene una cantidad en inventario de {Medicamento.cantidadmed}");
                Console.WriteLine("Cuanta cantidad de medicamento desea agregar al paciente?: ");
                cantidadmedic = int.Parse(Console.ReadLine());
                if (cantidadmedic <= medicamento.Canmed)
                {
                    paciente.Asigntreatment(new treatment(Medicamento, cantidadmedic));
                    medicamento.Reducirinventario(cantidadmedic);
                    Console.WriteLine("Medicamento agregado al paciente");

                }
                else
                {
                    Console.WriteLine("La cantidad ingresada no puede ser asignada ya que no hay suficiente inventario");
                }

            }
            else
            {
                Console.WriteLine("El Medicamento ingresado no existe");
                Console.WriteLine("Será redireccionado al menu principal");
                return;
            }
            
        }
        

    }
    static void Registrados()
    {
        Console.WriteLine("Estos son los pacientes que fueron registrados: ");
        foreach (var Paciente in Pacientes)
        {
            if (Paciente != null)
            {
                Console.WriteLine($"Nombre: {Paciente.Nombre}, Cedula: {Paciente.Cedula}, Telefono: {Paciente.Telefono}, Tipo de Sangre: {Paciente.Tipodesangre}, Direccion: {Paciente.Direccion}, Fecha de nacimiento: {Paciente.Fechanacimiento}");
            }
            else
            {
                Console.WriteLine("No hay pacientes registrados");
                Console.WriteLine("Será redireccionado al menu principal");
                return;

            }
        }

    }
    static void recetados()
    {
        List<System.String> MedsRecetados = new List<System.String>();
        Console.WriteLine("Los siguientes son los medicamentos que fueron recetados a los pacientes: ");
        foreach (var Paciente in Pacientes)
        {
            foreach (var treatment in Paciente.Treatments)
            {
                MedsRecetados.Add(treatment.Medicamento.Nombmed);
            }
        }
        foreach (var Medicamento in MedsRecetados)
        {
            Console.WriteLine(Medicamento);
        }

    }

    static void recetadosxedad(double Fechanacimiento)
    {
        Console.WriteLine("Los siguientes son los datos de los Pacientes segun su rango de edad: ");
        double[] yearold = {0,0,0,0 };
        foreach (var Paciente in Pacientes)
        {
            double edad = 2024 - Fechanacimiento;
            if (edad >= 0 || edad <= 10)
            {
                yearold[0]++;
            }
            else if (edad >= 11 || edad <= 30)
            {
                yearold[1]++;
            }
            else if (edad >= 31 || edad <= 50)
            {
                yearold[2]++;
            }
            else if (edad >= 51)
            {
                yearold[3]++;
            }


        }
        Console.WriteLine($"Pacientes con edades de 0 a 10: {yearold[0]}");
        Console.WriteLine($"Pacientes con edades de 11 a 30: {yearold[1]}");
        Console.WriteLine($"Pacientes con edades de 31 a 50: {yearold[2]}");
        Console.WriteLine($"Pacientes con edades mayores a los 51 años: {yearold[3]}");
    }

    static void recetadosxnombre()
    {
        var xnombre = Pacientes.OrderBy(p => p.Nombre);
        Console.WriteLine("Los siguientes son los pacientes ingresados ordenados por nombre: ");
        foreach (var Paciente in xnombre)
        {
            Console.WriteLine($"Nombre: {Paciente.Nombre}");
        }


    }


    static void Consultas()
    {
        double cedulacon = double.Parse(Console.ReadLine());
        bool encontrado = false;
        bool error = false;
        
        Console.WriteLine("Bienvenido al menu de consultas");
        Console.WriteLine("1. Cantidad total de pacientes registrados");
        Console.WriteLine("2. Reporte de todos los medicamentos recetados sin repetirlos");
        Console.WriteLine("3. Reporte de cantidad de pacientes agrupados por edades: 0-10 años, 11-30 años, 31-50 años y mayores de 51 años.");
        Console.WriteLine("4. Reporte Pacientes y consultas ordenado por nombre");
        Console.WriteLine("5. Volver al menu principal");
        int optioncon = int.Parse(Console.ReadLine());
        switch (optioncon)
        {
            case 1:
                Registrados();
                break;
            case 2:
                
                recetados();
                break;
            case 3:
                
                recetadosxnombre();
                break;
            case 4:
                recetadosxnombre();
                break;
            case 5:
                Console.WriteLine("Será redireccionado al menu principal");
                return;
            default:
                Console.WriteLine("opcion no encontrada, ingrese una opcion valida");
                break;
        }


    }

}



