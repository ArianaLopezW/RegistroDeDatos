using System;
using System.IO;
using System.Collections.Generic;

namespace Registro_Official
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];

            if(!File.Exists(path))
            {
                string header = "Cedula,Nombre,Apellido,Edad";
                File.WriteAllText(path, header + Environment.NewLine);
            }
            
            string ID, name, lastName, age, resp;
            Console.WriteLine("REGISTRO");
            do
            {
                Console.WriteLine("Introduzca los siguientes datos:");
                Console.Write("Cedula: ");
                ID = Console.ReadLine();
                Console.Write("Nombre: ");
                name = Console.ReadLine();
                Console.Write("Apellido: ");
                lastName = Console.ReadLine();
                Console.Write("Edad: ");
                age = Console.ReadLine();

                Console.WriteLine("Desea: guardar (G), continuar (C), o salir (S)");
                resp = Console.ReadLine();

                switch(resp)
                {
                    case "G":
                        try{
                            using(StreamWriter file = new StreamWriter(path, true))
                            {
                                file.WriteLine(ID + "," + name + "," + lastName + "," + age);
                            }
                        } catch(Exception e) {
                            Console.Write(e);
                        }
                        continue;
                    case "C":
                        continue;
                    case "S":
                        Environment.Exit(0);
                        break;
                }
            } while (resp != "S");
        }
    }
}
