// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Paciente
{
    public double Cedula { get; set; }
    public string Nombre { get; set; }
    public double Telefono { get; set; }
    public string Direccion { get; set; }
    public string Tipodesangre { get; set; }
    public double Fechanacimiento { get; set; }
    public double Codigo { get; set; }
    public string Nombmed { get; set; }
    public double Canmed { get; set; }
}

class Medicamento
{
    public ArrayList codigomed = new ArrayList();
    public ArrayList Nombremed = new ArrayList();
    public ArrayList cantidadmed = new ArrayList();
}

class Program
{
    static Paciente[] Pacientes = new Paciente[10];
    static int numpacientes = 0;
    static Medicamento[] Medicamentos = new Medicamento[10];
    static int nummedicamentos = 0;
    static void Main(string[] args)


    {
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
            Console.WriteLine("5. Inicializar herramienta");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una de las opciones: ");
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        agregpaci();
                        break;
                    case 2:
                        catalmed();
                        break;
                    case 3:
                        asigtratpac();
                        break;
                    case 4:
                        Consultas();
                        break;
                    case 5:
                        inicializarherramienta();
                        break;

                    case 6:
                        Console.WriteLine("Saliendo del programa, muchas gracias!");
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


        } while (opcion != 6);
    }


        static void inicializarherramienta() 
    {
        Pacientes = new Paciente[10];
        numpacientes = 0;
        Console.WriteLine("Herramienta Iniciada");

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

                Pacientes[numpacientes] = new Paciente { Nombre = nombre, Telefono = telefono, Cedula = cedula, Tipodesangre = tipodesangre, Direccion = direccion, Fechanacimiento = fechanacimiento };
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
            if (numpacientes < 10)
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

                Medicamentos[nummedicamentos] = new Medicamento { };
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
                Console.WriteLine("No se pueden incluir mas pacientes ya el limite de 10 pacientes ha sido alcanzado");
            }
        } while (seguiremos == true);

    }

    static void asigtratpac()
    {


    }

    static void Consultas()
    {


    }

}



