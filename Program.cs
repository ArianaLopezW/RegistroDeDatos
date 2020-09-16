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
            
            string ID, name, lastName, age, resp, proc;
            Console.WriteLine("REGISTRO");
            do {
            Console.WriteLine("Elija el proceso que desea ejecutar: " + "\n1. Registrar datos" + "\n2. Listado de datos" + "\n3. Busqueda de datos" + "\n4. Salir");
            proc = Console.ReadLine();

            switch (proc)
            {
                case "1":
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
                        resp = Console.ReadLine().ToUpper();

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
                                break;
                        }
                        } while (resp != "S");
                    break; 
                
                case "2":
                    try{
                        using(StreamReader reader = new StreamReader(path, true))
                        {
                            Console.WriteLine(reader.ReadToEnd());
                        }

                    } catch (Exception e) {
                        Console.WriteLine(e);
                    }
                    continue; 
                case "3":
                    Console.Write("Introduzca el numero de cedula: ");
                    ID = Console.ReadLine();
                    var lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        if(line.Contains(ID))
                        {
                            Console.WriteLine(line);
                        }
                    }
                    Console.WriteLine("");
                    continue; 
                }    
            } while (proc != "4");
        }
    }
}
