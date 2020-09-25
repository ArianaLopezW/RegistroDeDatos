using System;
using System.IO;
using System.Collections.Generic;

namespace Registro_Official
{
    class Program
    {
        static string RegistrarNombre()
        {
            char[] character = new char [30];
            char x;
            for (int i = 0; i < character.Length;)
            {
                x = Console.ReadKey(true).KeyChar;
                if(x >= 65 && x<= 122)
                {
                    character[i] = x;
                    i++;
                    Console.Write(x);
                }
                if (x == 13)
                {
                    for (int e = i; e < character.Length; e++)
                    {
                        character[e] = ' ';

                    }
                    break;
                }
                if(x == 8 && i >= 1)
                {
                    Console.Write("\b \b");
                    i--;
                }
            }
            return new string (character);
        }

        static string RegistrarApellido()
        {
            char[] character = new char [30];
            char x;
            for (int i = 0; i < character.Length;)
            {
                x = Console.ReadKey(true).KeyChar;
                if (x >= 65 && x <= 122)
                {
                    character[i] = x;
                    i++;
                    Console.Write(x);
                }
                if (x == 13)
                {
                    for(int e = i; e < character.Length; e++)
                    {
                        character[e] = ' ';
                    }
                    break;
                }
                if (x == 8 && i >=1)
                {
                    Console.Write("\b \b");
                    i--;
                }
            }
            return new string(character);
        }
        
        static string RegistrarEdad()
        {
            char[] character = new char[5];
            char x;

            for (int i = 0; i < character.Length;)
            {
                x = Console.ReadKey(true).KeyChar;
                if(x >= 48 && x <= 57)
                {
                    character[i] = x;
                    i++;
                    Console.Write(x);
                }
                if (x == 13)
                {
                    for (int e = i; e < character.Length; e++)
                    {
                        character[e] = ' ';
                    }
                    break;
                }
                if (x == 8 && i >= 1)
                {
                    Console.Write("\b \b");
                    i--;
                }
            }
            return new string(character);       
        }

        static string RegistrarCedula()
        {
            char[] character = new char[30];
            char x;
            for(int i = 0; i < character.Length;)
            {
                x = Console.ReadKey(true).KeyChar;
                if((x >= 48 && x <= 57) || (x == 45))
                {
                    character[i] = x;
                    i++;
                    Console.Write(x);
                }
                if (x == 13)
                {
                    for (int e = i; e < character.Length; e++)
                    {
                        character[e] = ' ';
                    }
                    break;
                }
                if (x == 8 && i >= 1)
                {
                    Console.Write("\b \b");
                    i--;
                }
            }
            return new string(character);      
        }
        static string RegistrarMonto()
        {
            char[] character = new char[30];
            char x;
            for(int i = 0; i < character.Length;)
            {
                x = Console.ReadKey(true).KeyChar;
                if((x >= 48 && x <= 57) || (x == 46))
                {
                    character[i] = x;
                    i++;
                    Console.Write(x);
                }
                if (x == 13)
                {
                    for (int e = i; e < character.Length; e++)
                    {
                        character[e] = ' ';
                    }
                    break;
                }
                if (x == 8 && i >= 1)
                {
                    Console.Write("\b \b");
                    i--;
                }
            }
            return new string(character);      
        }

        static string RegistrarPassword()
        {
            char[] character = new char[30];
            char x;
            for (int i = 0; i < character.Length;)
            {
                x = Console.ReadKey(true).KeyChar;
                if (x >= 48 && x <= 128) 
                {
                    character[i] = x;
                    i++;
                    Console.Write("*");
                }
                if (x == 13)
                {
                    for (int e = i; e < character.Length; e++)
                    {
                        character[e] = ' ';
                    }
                    break;
                }
                if (x == 8 && i >= 1)
                {
                    Console.Write("\b \b");
                    i--;
                }
            }
            return new string(character);
        }

        static void Main(string[] args)
        { 
            string nombre, apellido, cedula, password;
            int edad;
            decimal monto;
            string Decision;
            char caso, caso1;
            bool rep = true;
            if(!File.Exists(args[0]))
            {
                string header = "Cedula,Nombre,Apellido,Edad";
                File.WriteAllText(args[0], header + Environment.NewLine);
            }
            
            do
            {
            Console.Clear();
            rep = true;
            System.Console.WriteLine("----------------------------------------");
            System.Console.WriteLine("         [1] - Guardar Datos            ");
            System.Console.WriteLine("     [2] - Mostrar todos los datos      ");
            System.Console.WriteLine("       [3] - Buscar por cedula          ");
            System.Console.WriteLine("         [4] - Editar datos             ");
            System.Console.WriteLine("         [5] - Eliminar datos           ");
            System.Console.WriteLine("             [6] - Salir                ");
            System.Console.WriteLine("----------------------------------------");
            caso = Console.ReadKey().KeyChar;
            Console.Clear();
            switch (caso)
            {
                case '1':
                do
                {

                    System.Console.WriteLine("Ingrese sus nombre: ");
                    nombre = RegistrarNombre().Trim();
                    System.Console.WriteLine("\nIngrese sus apellido: ");
                    apellido = RegistrarApellido().Trim();
                    System.Console.WriteLine("\nIngrese su cedula: ");
                    cedula = RegistrarCedula().Trim();
                    System.Console.WriteLine("\nIngrese su edad: ");
                    edad = int.Parse(RegistrarEdad().Trim());
                    System.Console.WriteLine("\nIngrese su monto: ");
                    monto = decimal.Parse(RegistrarMonto().Trim());
                    System.Console.WriteLine("\nIngrese su contraseña: ");
                    password = RegistrarPassword().Trim();
                    Console.WriteLine("\nDatos ingresados: {0},{1},{2},{3},{4}",cedula,nombre,apellido,edad,monto);
                    Console.WriteLine("Desea Guardar(G), Continuar(C), Salir(S)");
                    Decision = Console.ReadLine().ToUpper();
                     switch(Decision)  
                     {  
                        case "G":
                                try{
                                    Console.Write("Ingrese la contraseña antes digitada para guardar: ");
                                    string password2 = RegistrarPassword().Trim();
                                    Console.WriteLine();
                                    if (password2 == password)
                                    {
                                      using(StreamWriter file = new StreamWriter(args[0], true))
                                    {
                                        file.WriteLine(cedula + "," + nombre + "," + apellido + "," + edad + "," + monto + "," + password);
                                    }
                                    Console.WriteLine("Datos Guardados, presione cualquier tecla para continuar"); 
                                    Console.ReadKey();
                                    Console.Clear();                               
                                    } 
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Contraseña incorrecta - Datos no guardados");
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
                } while (Decision != "S");
                continue;
                    
                case '2':
                using(StreamReader Archivo1 = new StreamReader (args[0]))
                {
                    Console.WriteLine(Archivo1.ReadToEnd());
                    Console.ReadKey();
                }
                continue;

                case '3':
                string cadena, cedula1;
                bool encontrado = false;
                string[] campos = new string[4];
                char[] separador = {','};

                try
                {
                    using(StreamReader Archivo2 = new StreamReader (args[0]))
                    {
                        System.Console.Write("Introduzca la cedula: ");
                        cedula1 = Console.ReadLine();
                        cadena = Archivo2.ReadLine();
                    while (cadena != null && encontrado == false)
                    {
                        campos = cadena.Split(separador);
                        if (campos[0].Trim().Equals(cedula1))
                        {
                            System.Console.WriteLine("Cedula: {0}",campos[0]);
                            System.Console.WriteLine("Nombres: {0}",campos[1]);
                            System.Console.WriteLine("Apellidos: {0}",campos[2]);
                            System.Console.WriteLine("Edad: {0}",campos[3]);
                            encontrado = true;
                        }
                        else
                        {
                            cadena = Archivo2.ReadLine();
                        }
                        

                    }
                    
                    if(encontrado == false)
                        {
                            System.Console.WriteLine("La cedula {0} no se encontró en el archivo", cedula1);
                        }
                    }

                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e);
                }
                Console.ReadKey();
                continue;

                case '4':
                string cadena1, cedula2;
                bool encontrado1 = false;
                string[] campos1 = new string[4];
                string[] nuevosDatos = new string[4];
                char[] separador1 = {','};

                try 
                {
                    using (StreamReader Archivo3 = new StreamReader(args[0], true))
                    {
                        using (StreamWriter file1 = File.CreateText("temp.csv"))
                        {
                            Console.Write("Introduzca la cedula:");
                            cedula2 = Console.ReadLine();
                            cadena1 = Archivo3.ReadLine();
                            while (cadena1 != null)
                            {
                                campos1 = cadena1.Split(separador1);
                                if (campos1[0].Trim().Equals(cedula2))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Registro encontrado con estos datos: ");
                                    Console.WriteLine();
                                    Console.WriteLine("--------------------------------");
                                    Console.WriteLine("Cedula: {0}", campos1[0]);
                                    Console.WriteLine("Nombre: {0}", campos1[1]);
                                    Console.WriteLine("Apellido: {0}", campos1[2]);
                                    Console.WriteLine("Edad: {0}", campos1[3]);
                                    Console.WriteLine("--------------------------------");
                                    encontrado1 = true;
                                    Console.WriteLine("Ingresa la nueva cedula: ");
                                    nuevosDatos[0] = Console.ReadLine();
                                    Console.WriteLine("Ingresa la nueva nombre: ");
                                    nuevosDatos[1] = Console.ReadLine();
                                    Console.WriteLine("Ingresa la nueva apellido: ");
                                    nuevosDatos[2] = Console.ReadLine();
                                    Console.WriteLine("Ingresa la nueva edad: ");
                                    nuevosDatos[3] = Console.ReadLine();

                                    file1.WriteLine(nuevosDatos[0] + "," + nuevosDatos[1]+ "," + nuevosDatos[2] + "," + nuevosDatos[3]);

                                    Console.Clear();
                                    Console.WriteLine("Su registro ha sido modificado");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    file1.WriteLine(cadena1);
                                }
                                cadena1 = Archivo3.ReadLine();    
                            }
                                if (encontrado1 == false)
                                {
                                    Console.WriteLine("La cedula {0} no se encontró en el archivo", cedula2);
                                    Console.ReadKey();
                                }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                File.Delete(args[0]);
                File.Move("temp.csv",args[0]);
                continue;

                case '5':
                string cadena2, cedula3;
                bool encontrado2 = false;
                string[] campos2 = new string[4];
                char[] separador2 = {','};
                try 
                {
                    using (StreamReader Archivo4 = new StreamReader(args[0], true))
                    {
                        using (StreamWriter File2 = File.CreateText("temp.csv"))
                        {
                            Console.Write("Introduzca la cedula: ");
                            cedula3 = Console.ReadLine();
                            cadena2 = Archivo4.ReadLine();
                            while(cadena2 != null)
                            {
                                campos2 = cadena2.Split(separador2);
                                if (campos2[0].Trim().Equals(cedula3))
                                {
                                    encontrado2 = true;
                                }
                                else
                                {
                                    File2.WriteLine(cadena2);
                                }
                                cadena2 = Archivo4.ReadLine();
                            }
                            if(encontrado2 == false)
                            {
                                Console.WriteLine("La cedula {0} no se encontró en el archivo", cedula3);
                            }
                            else
                            {
                                Console.WriteLine("Registro Eliminado");
                            }
                        }
                    }

                }
                catch (Exception e) {
                    Console.WriteLine(e);
                }
                File.Delete(args[0]);
                File.Move("temp.csv",args[0]);
                Console.ReadKey();
                continue;

                case '6':
                rep = false;
                break;

                
                default: 
                System.Console.WriteLine("Usted no ha ingresado el numero correcto");
                System.Console.WriteLine("Desea Repetir el programa o cerrarlo?");
                System.Console.WriteLine("Presione S para repetir o cualquier otra tecla para cerrar");
                caso1 = Console.ReadKey().KeyChar;
                if (caso1.ToString().ToUpper() != "S")
                {
                    rep = false;
                }
                Console.Clear();
                break;
            }
        }
        while (rep == true);
            
            
        }
    }
}
