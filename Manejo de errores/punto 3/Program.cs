using System;
using System.Collections.Generic;
using System.Reflection;

namespace punto_3
{
    class Program
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            List<empleado> lista = new List<empleado>();
            int resp;
            try
            {

                do{

                    Console.WriteLine("ingrese Datos del empleado");
                    lista.Add(SetDatosEmpleado());
                    Console.WriteLine("Desea cargar otro empleado");
                    resp = int.Parse(Console.ReadLine());

                }while(resp == 1);

                foreach (var item in lista)
                {
                    empleado.getDatos(item);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                Console.WriteLine(e.Message);
            }

        }

        public static empleado SetDatosEmpleado()
        {
            string nombre;
            int dni, edad, antiguedad, hijos;
            DateTime FNacimiento, FIngreso, fDivorcio;
            float salario;
            string EstadoCivil, titulo, lugarEstudio;

            Console.WriteLine("Nombre");
            nombre = Console.ReadLine();

            FNacimiento = ingresarFecha("nacimiento");

            FIngreso = ingresarFecha("Ingreso");

            Console.WriteLine("Dni");
            dni = int.Parse(Console.ReadLine());

            Console.WriteLine("Estado civil");
            EstadoCivil = Console.ReadLine();

            Console.WriteLine("Tituloi");
            titulo = Console.ReadLine();

            Console.WriteLine("Lugar de estudio");
            lugarEstudio = Console.ReadLine();

            Console.WriteLine("Salario");
            salario = float.Parse(Console.ReadLine());

            antiguedad = calcularTime.Time(FIngreso);
            edad = calcularTime.Time(FNacimiento);

            Console.WriteLine("¿Tiene hijos? 1- si 2 - no");
            int resp = int.Parse(Console.ReadLine());
            if (resp == 1)
            {
                Console.WriteLine("¿cuantos tiene?");
                hijos = int.Parse(Console.ReadLine());
            }
            else
            {
                hijos = 0;
            }

            if (EstadoCivil == "divorciado")
                fDivorcio = ingresarFecha("divorcio");
            else
                fDivorcio = DateTime.Parse($"{00}/{00} /{0000}");
            empleado ep = new empleado(nombre, dni, edad, antiguedad,
                FNacimiento, FIngreso, salario, EstadoCivil, titulo, lugarEstudio, hijos, fDivorcio);
            return ep;
        }

        public static DateTime ingresarFecha(string mensaje)
        {
            Console.WriteLine("Dia de {0}",mensaje);
            int dia = int.Parse(Console.ReadLine());

            Console.WriteLine("Mes de {0}(numero)", mensaje);
            int mes = int.Parse(Console.ReadLine());

            Console.WriteLine("Año de {0}", mensaje);
            int anio = int.Parse(Console.ReadLine());
            return DateTime.Parse($"{dia}/{mes} /{anio}");
        }
        


    }
}
