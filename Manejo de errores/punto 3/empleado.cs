using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace punto_3
{
    class empleado
    {
        private string nombre;
        private int dni, edad, antiguedad;
        private DateTime FNacimiento, FIngreso, fDivorcio;
        private double salario;
        private string EstadoCivil, titulo, lugarEstudio;
        private int hijos;

        public empleado(string nombre, int dni, int edad, int antiguedad,
            DateTime fn, DateTime fi, float salario, string estadoC, string titulo, string lugar, int hijos, DateTime fDivorcio)
        {

            Nombre = nombre;
            FNacimiento1 = fn;
            FIngreso1 = fi;
            Dni = dni;
            EstadoCivil = estadoC;
            Titulo = titulo;
            LugarEstudio = lugar;
            Salario = getSalario(salario, antiguedad);
            Antiguedad = antiguedad;
            Edad = edad;
            this.Hijos = hijos;
            this.FDivorcio = fDivorcio;
        }

        public empleado(string nombre, int dni, int edad, int antiguedad,
            DateTime fn, DateTime fi, float salario, string estadoC, string titulo, string lugar, int hijos)
        {

            Nombre = nombre;
            FNacimiento1 = fn;
            FIngreso1 = fi;
            Dni = dni;
            EstadoCivil = estadoC;
            Titulo = titulo;
            LugarEstudio = lugar;
            Salario = getSalario(salario, antiguedad);
            Antiguedad = antiguedad;
            Edad = edad;
            this.Hijos = hijos;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Dni { get => dni; set => dni = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Antiguedad { get => antiguedad; set => antiguedad = value; }
        public DateTime FNacimiento1 { get => FNacimiento; set => FNacimiento = value; }
        public DateTime FIngreso1 { get => FIngreso; set => FIngreso = value; }
        public double Salario { get => salario; set => salario = value; }
        public string EstadoCivil1 { get => EstadoCivil; set => EstadoCivil = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string LugarEstudio { get => lugarEstudio; set => lugarEstudio = value; }
        public int Hijos { get => hijos; set => hijos = value; }
        public DateTime FDivorcio { get => fDivorcio; set => fDivorcio = value; }

        public static void getDatos(empleado a)
        {
            PropertyInfo[] lst = typeof(empleado).GetProperties();
            foreach (PropertyInfo oProperty in lst)
            {
                string NombreAtributo = oProperty.Name;
                string Valor = oProperty.GetValue(a).ToString();

                Console.WriteLine("El atributo " + NombreAtributo + " tiene el valor: " + Valor);
            }
        }
        public double getSalario(float salario, int antiguedad)
        {
            float descuento = 15;
            return antiguedad < 20 ? (salario*descuento/100 + salario*antiguedad/100) : (salario * descuento/100 + salario * 0.25);
        }
    }
}
