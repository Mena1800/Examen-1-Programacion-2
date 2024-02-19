// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using System.Net.Http.Headers;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.Common;
using System.Net.Quic;

public class Paciente
{
    public List<treatment> Treatments { get; set; }
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
    public string Tipodesangre { get; set; }
    public int Fechanacimiento { get; set; }
    

    public Paciente(string cedula, string nombre, string telefono,string direccion, string tipodesangre, int fechanacimiento) 
    {
        Treatments = new List<treatment>();
        Cedula = cedula;
        Nombre= nombre;
        Telefono= telefono;
        Direccion= direccion;
        Tipodesangre = tipodesangre;
        Fechanacimiento= fechanacimiento;
        
    }
    public void Asigntreatment(treatment Treatment)
    {
        Treatments.Add(Treatment);
    }

}

public class Medicamento
{
    public int Codigomeds { get; set; }
    public string Nombmed { get; set; }
    public int Canmed { get; set; }

    public Medicamento(int codigomeds, string nombmed, int canmed)
    {
        Codigomeds=  codigomeds;
        Nombmed= nombmed;
        Canmed= canmed;

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
    public int Canmed { get; set; }


    public treatment(Medicamento medicamento, int canmed)
    {
        Medicamento = medicamento;
        Canmed = canmed;
    }
}

class Program
{
    static List<Paciente> Pacientes = new List<Paciente>();
    static List<Medicamento> AsigMedicamentos = new List<Medicamento>();
    static List<treatment> Treatments = new List<treatment>();
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
                        asigmed();
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
                        Console.WriteLine("Saliendo del programa!");
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


        } while (salir == false);
    }




    static void agregpaci()

    {
        Console.WriteLine("Ingrese los datos del paciente:");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Telefono: ");
        string telefono = Console.ReadLine(); ;
        Console.Write("Cedula: ");
        string cedula = Console.ReadLine(); ;
        Console.Write("Tipo de sangre: ");
        string tipodesangre = Console.ReadLine();
        Console.WriteLine("Dirección: ");
        string direccion = Console.ReadLine();
        Console.WriteLine("Fecha de nacimiento: ");
        int fechanacimiento = int.Parse(Console.ReadLine());

        Paciente paciente = new Paciente(cedula, nombre, telefono, direccion, tipodesangre, fechanacimiento);
        Pacientes.Add(paciente);
        Console.WriteLine("Paciente agregado");
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

    }
    static void asigmed()
    {

        Console.WriteLine("Ingrese los datos del medicamento:");
        Console.Write("Codigo del medicamento: ");
        int codigo = int.Parse(Console.ReadLine());
        Console.Write("Nombre del medicamento: ");
        string nombmed = Console.ReadLine();
        Console.Write("Cantidad de medicamentos: ");
        int canmed = int.Parse(Console.ReadLine());


        Medicamento medicamentos = new Medicamento(codigo, nombmed, canmed);
        AsigMedicamentos.Add(medicamentos);
        Console.WriteLine("Medicamento agregado");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();


    }

    static void asigtratpac()
    {

        if (AsigMedicamentos.Count == 0 || Pacientes.Count == 0)
        {
            Console.WriteLine("No se han agregado pacientes");
            Console.WriteLine("Será redireccionado al menu principal");
            return;
        }
        Console.WriteLine("Estos son los Pacientes ingresados: ");
        for (int i = 0; i < Pacientes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Pacientes[i].Nombre}");
        }
        Console.WriteLine("Seleccione el numero de paciente que desea utilizar");
        int numpaciente = int.Parse(Console.ReadLine()) - 1;
        if (numpaciente >= Pacientes.Count)
        {
            Console.WriteLine("El paciente seleccionado no esta disponible en la lista");
        }
        Paciente paciente = Pacientes[numpaciente];
        Console.WriteLine("Estos son los Medicamentos ingresados: ");
        foreach (var medicamentoscons in AsigMedicamentos)
        {
            Console.WriteLine($"{medicamentoscons.Codigomeds}, {medicamentoscons.Nombmed},  Cantidad: {medicamentoscons.Canmed}");
        }
        Console.WriteLine("Seleccione el codigo del medicamento a utilizar: ");
        int Codmedica = int.Parse(Console.ReadLine()) - 1;
        Medicamento medicamentos = AsigMedicamentos.FirstOrDefault(me => me.Codigomeds == Codmedica);
        Console.WriteLine("Ingrese la cantidad a ingresar en inventario");
        int canasigmed = Convert.ToInt32(Console.ReadLine())-1;
        

        Paciente Paciente = Pacientes[numpaciente];
        paciente.Asigntreatment(new treatment(medicamentos, canasigmed));
        Console.WriteLine("Medicamento agregado al paciente");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();


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
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();


    }
    static void recetados()
    {
        List<System.String> MedsRecetados = new List<System.String>();
        Console.WriteLine("Los siguientes son los medicamentos que fueron recetados a los pacientes: ");
       
        foreach (var Medicamento in Treatments)
        {
            Console.WriteLine(Medicamento);
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

    }
    

    static void recetadosxedad()
    {
        Console.WriteLine("Los siguientes son los datos de los Pacientes segun su rango de edad: ");
        int[] yearold = {0,0,0,0 };
        foreach (var Paciente in Pacientes)
        {
            int edad = 2024- (Paciente.Fechanacimiento);
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
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

    }

    static void recetadosxnombre()
    {
        var xnombre = Pacientes.OrderBy(p => p.Nombre);
        Console.WriteLine("Los siguientes son los pacientes ingresados ordenados por nombre: ");
        foreach (var Paciente in xnombre)
        {
            Console.WriteLine($"Nombre del paciente: {Paciente.Nombre}");
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();


    }


    static void Consultas()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
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

                recetadosxedad();
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



