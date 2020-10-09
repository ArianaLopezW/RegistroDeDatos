using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Registro_Official
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!File.Exists(args[0]))
            {
                string[] header = {"Cedula,Nombre,Apellido,Ahorros,Datos,Contraseña"};
                File.AppendAllLines(args[0], header);
            }
            MENU(args[0]);
        }
        static void MENU(string fileName)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("         [1] - Guardar Datos            ");
            Console.WriteLine("     [2] - Mostrar todos los datos      ");
            Console.WriteLine("       [3] - Buscar por cedula          ");
            Console.WriteLine("         [4] - Editar datos             ");
            Console.WriteLine("         [5] - Eliminar datos           ");
            Console.WriteLine("             [6] - Salir                ");
            Console.WriteLine("----------------------------------------");
            char caso = Console.ReadKey().KeyChar;
            Console.Clear();
            switch (caso) 
            {
                case '1': 
                    Add(fileName);
                    Console.WriteLine("Presione cualquier tecla para volver al menu: ");
                    Console.ReadKey();
                    MENU(fileName);
                    break;
                case '2':
                    List(fileName);
                    Console.WriteLine("Presione cualquier tecla para volver al menu: ");
                    Console.ReadKey();
                    MENU(fileName);
                    break;
                case '3':
                    Search(fileName);
                    Console.WriteLine("Presione cualquier tecla para volver al menu: ");
                    Console.ReadKey();
                    MENU(fileName);
                    break;
                case '4':
                    Edit(fileName);
                    Console.WriteLine("Presione cualquier tecla para volver al menu: ");
                    Console.ReadKey();
                    MENU(fileName);
                    break;
                case '5':
                    Delete(fileName);
                    Console.WriteLine("Presione cualquier tecla para volver al menu: ");
                    Console.ReadKey();
                    MENU(fileName);
                    break;
                case '6':
                    return;
                default: 
                    Console.WriteLine("Usted no ha ingresado un parametro valido...");
                    Console.WriteLine("Presione cualquier tecla para volver al menu: ");
                    Console.ReadKey();
                    MENU(fileName);
                    break;
            }
        }
        static void Search(string fileName)
        {
            Person rg = new Person();
            Console.Write("Introduzca la cedula que desea buscar: ");
            rg.ID = Console.ReadLine();
            using (StreamReader file = File.OpenText(fileName))
            {
                string line = "";
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith(rg.ID))
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
        static void List(string fileName)
        {
            using (StreamReader file = File.OpenText(fileName))
            {
                string line = "";
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        static void Edit(string fileName)
        {
            Person rg = new Person();
            Console.Write("Introduzca la cedula del registro que desea editar: ");
            rg.ID = Console.ReadLine();
            List<string> newFile = File.ReadAllLines(fileName).ToList();
            int i = 0;
            foreach (var line in newFile)
            {
                var value = line.Split(',');
                if (value[0] == rg.ID)
                {
                    Console.WriteLine(newFile[i]);
                    Console.Write("Desea editar este registro? S|N");
                    char answ = Console.ReadKey().KeyChar;
                    if (answ == 's')
                    {
                        rg = dataRegister();
                        rg.personalData = Encoding(rg.age, rg.gr, rg.cS, rg.aL);
                        if (rg.password1 == rg.password2)
                        {
                            string pInfo = rg.ID + "," + rg.name +"," + rg.lastName + "," + rg.savings + "," + rg.personalData + "," + rg.password1;
                            newFile.RemoveAt(i);
                            newFile.Insert(i, pInfo);
                            Console.WriteLine("\nEl registro ha sido editado con exito!");
                            break;
                        }
                        else 
                        {
                            Console.WriteLine("\nLas contraseñas no coinciden...");
                        }
                    }
                    else {
                        Console.WriteLine("\nPresione cualquier tecla para volver al menu: ");
                        Console.ReadKey();
                        MENU(fileName);
                        break;
                    }
                }
                else 
                {
                    i++;
                }
            }
            File.WriteAllLines(fileName, newFile);
        }
        static void Delete(string fileName)
        {
            Person rg = new Person();
            Console.Write("Introduzca la cedula que desea eliminar: ");
            rg.ID = Console.ReadLine();
            List<string> newFile = File.ReadAllLines(fileName).ToList();
            int i = 0;
            foreach (var line in newFile)
            {
                var value = line.Split(',');
                if (value[0] == rg.ID)
                {
                    Console.WriteLine(newFile[i]);
                    Console.WriteLine("Desea eliminar este registro? S|N");
                    char answ = Console.ReadKey().KeyChar;
                    if (answ == 's')
                    {
                        Console.Write("\nIntroduzca su contraseña: ");
                        rg.password1 = passwordRegister();
                        Console.Write("\nConfirme su contraseña: ");
                        rg.password2 = passwordRegister();
                        if (rg.password1 == rg.password2)
                        {
                            newFile.RemoveAt(i);
                            Console.WriteLine("\nEste registro ha sido eliminado...");
                            break;
                        }
                        else 
                        {
                            Console.WriteLine("Las contraseñas no coinciden...");
                        }
                    }
                    else 
                    {
                        Console.WriteLine("\nPresione cualquier tecla para volver al menu: ");
                        Console.ReadKey();
                        MENU(fileName);
                        break;
                    }
                }
                else 
                {
                    i++;
                }
            }
            File.WriteAllLines(fileName, newFile);
        }
        static void Add(string fileName)
        {
            List<Person> people = new List<Person>();
            Person rg = dataRegister();
            if (rg.password1 == rg.password2)
            {
                Console.WriteLine("\nDesea guardar, continuar, o salir: G|C|S");
                char answ = Console.ReadKey().KeyChar;
                switch(answ)
                {
                    case 'g':
                        people.Add(rg);
                        rg.personalData = Encoding(rg.age, rg.gr, rg.cS, rg.aL);
                        foreach (var item in people)
                        {
                            string pInfo = rg.ID + "," + rg.name +"," + rg.lastName + "," + rg.savings + "," + rg.personalData + "," + rg.password1;
                            File.AppendAllText(fileName, pInfo + Environment.NewLine);
                        }
                        Add(fileName);
                        break;
                    case 'c':
                        Add(fileName);
                        break;
                    case 's':
                        MENU(fileName);
                        break;
                    default:
                        Console.WriteLine("Usted no ha ingresado un parametro valido...");
                        Console.WriteLine("Presione cualquier tecla para volver al menu: ");
                        Console.ReadKey();
                        MENU(fileName);
                        break;
                }
            }
            else 
            {
                Console.WriteLine("\nLas contraseñas no coinciden...");
                Console.WriteLine("Presione cualquier tecla para volver al menu: ");
                Console.ReadKey();
                MENU(fileName);
            }
        }
        static Person dataRegister()
        {
            Person rg = new Person();
            Console.Write("\nIntroduzca su numero de cedula: ");
            rg.ID = idRegister().Trim();
            Console.Write("\nIntroduzca su nombre: ");
            rg.name = nameRegister().Trim();
            Console.Write("\nIntroduzca su apellido: ");
            rg.lastName = lastNameRegister().Trim();
            Console.Write("\nIntroduzca su edad: ");
            rg.age = Convert.ToInt32(ageRegister().Trim());
            do {
                Console.Write("\nIntroduzca su genero: M|F");
                rg.gr = Console.ReadKey().KeyChar;
            } while (rg.gr != 'm' & rg.gr != 'f');
            do {
                Console.Write("\nIntroduzca su estado civil: S|C");
                rg.cS = Console.ReadKey().KeyChar;
            } while (rg.cS != 's' & rg.cS != 'c');
            do {
                Console.Write("\nIntroduzca su nivel academico: I|M|G|P");
                rg.aL = Console.ReadKey().KeyChar;
            } while (rg.aL != 'i' & rg.aL != 'm' & rg.aL != 'g' & rg.aL != 'p');
            Console.Write("\nIntroduzca su monto de ahorros: ");
            rg.savings = Convert.ToDecimal(savingsRegister().Trim());
            Console.Write("\nIntroduzca su contraseña: ");
            rg.password1 = passwordRegister();
            Console.Write("\nConfirme su contraseña: ");
            rg.password2 = passwordRegister();
            return rg;
        }
        static int Encoding(int age, char gender, char civilS, char acadL)
        {
            int data = age << 4;
            if (gender == 'f') data = data | 0b1000;
            if (civilS == 'c') data = data | 0b100;
            if (acadL == 'm') data = data | 0b01;
            else if (acadL == 'g') data = data | 0b10;
            else if (acadL == 'p') data = data | 0b11;

            return data; 
        }
        static void Decoding(int data, out int age, out char gender, out char civilS, out char acadL)
        {
            age = data >> 4;
            data = data & 0b1000;
            if((data >> 3) == 0b01) gender = 'F';
            else gender = 'M'; 

            data = data & 0b100;
            if((data >> 2) == 0b01) civilS = 'C';
            else civilS = 'S'; 
            data = data & 0b11;
            if(data == 0b00) acadL = 'I';
            else if (data == 0b01) acadL = 'M'; 
            else if (data == 0b10) acadL = 'G';
            else acadL = 'P';
        }
        static string nameRegister()
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

        static string lastNameRegister()
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
        
        static string ageRegister()
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

        static string idRegister()
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
        static string savingsRegister()
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

        static string passwordRegister()
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
    }
}
