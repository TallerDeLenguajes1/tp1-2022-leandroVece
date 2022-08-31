using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace Manejo_de_errores
{
    class Program
    {
        static void Main(string[] args)
        {
            float entero1, entero2;


            //problema 4
            Console.WriteLine("Lista de provincias obtenidas por una api");
            try
            {
                List<Provincia> lista = apiJson();

                foreach (var item in lista)
                {
                    Console.WriteLine("id: {0} - nombre: {1}", item.id, item.nombre);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }


            //problema 1
            Console.WriteLine("Cargue un numero entrero");
            try{
                entero1 = float.Parse(Console.ReadLine());
                float a = cuadrado(entero1);
                Console.WriteLine("cuadrado del numero ingresado es {0}", a);
            }catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }

            //problema 2
            Console.WriteLine("Cargue 2 números entreros");
            try {
                Console.WriteLine("cargue el primer numero");
                entero1 = float.Parse(Console.ReadLine());
                Console.WriteLine("cargue el segundo numero");
                entero2 = float.Parse(Console.ReadLine());

                float b = dividir(Convert.ToInt32(entero1),(entero2));
                Console.WriteLine("la division de {0} entre {1} es {2}", entero1,entero2, b);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            //problema 3
            Console.WriteLine("Calculadora de combustible");
            try
            {
                Console.WriteLine("ingrese los kilometros recorridos");
                entero1 = float.Parse(Console.ReadLine());
                Console.WriteLine("ingrese litros consumidos");
                entero2 = float.Parse(Console.ReadLine());

                float c = dividir(Convert.ToInt32(entero1), (entero2));
                Console.WriteLine("los Km/Lts conducidos son {0}", c);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }


          

        }

        static float cuadrado(float a)
        {
            return a * a;
        }

        static float dividir(float a, float b)
        {
            return a/b;
        }

        public static List<Provincia> apiJson()
        {
            var url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            Root ListProvincias;

            try
            {

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader((strReader)))
                        {
                            string responseBody = objReader.ReadToEnd();
                            ListProvincias = JsonSerializer.Deserialize<Root>(responseBody);
                            return ListProvincias.provincias;
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Parametros
        {
            public List<string> campos { get; set; }
        }

        public class Provincia
        {
            public string id { get; set; }
            public string nombre { get; set; }
        }

        public class Root
        {
            public int cantidad { get; set; }
            public int inicio { get; set; }
            public Parametros parametros { get; set; }
            public List<Provincia> provincias { get; set; }
            public int total { get; set; }
        }


    }

}
