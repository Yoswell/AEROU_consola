using System;

namespace ConsoleApp_Tarea1 {
    internal class Metodos {
        //Estemetodo lo usamos para mostrar las opciones del menu
        public static void Menu() {
            Console.WriteLine(":----------------------------------:");
            Console.WriteLine("|          INSTRUCCIONES           |");
            Console.WriteLine("| 1. No ingrese espacios en blanco |");
            Console.WriteLine("| 2. No ingrese datos erroneos     |");
            Console.WriteLine("| 3. Al momento de registrar los   |");
            Console.WriteLine("|    aeropuertos ingrese tanto el  |");
            Console.WriteLine("|    aeropuerto de origen como el  |");
            Console.WriteLine("|    aeropuerto de destino         |");
            Console.WriteLine(":----------------------------------:");
            Console.WriteLine(" ");
            Console.WriteLine(":----------------------------------:");
            Console.WriteLine("| Bienvenido al menú de opciones   |");
            Console.WriteLine("| 1. Registro de Cliente           |");
            Console.WriteLine("| 2. Registro de Aeropuerto        |");
            Console.WriteLine("| 3. Registro de Aerolínea         |");
            Console.WriteLine("| 4. Registro de Vuelo             |");
            Console.WriteLine("| 5. Consulta de Clientes          |");
            Console.WriteLine("| 6. Consulta de Aeropuertos       |");
            Console.WriteLine("| 7. Consulta de Aerolíneas        |");
            Console.WriteLine("| 8. Consulta de Vuelos            |");
            Console.WriteLine("| 0. Salir                         |");
            Console.WriteLine(":----------------------------------:");
            Console.WriteLine(" ");
            Console.Write("Seleccione una opción: ");
        }

        //Este metodo lo usamos para mostrar la opcion que eligio el usuario
        public static void Opcion(string op) {
            Console.WriteLine(" ");
            Console.WriteLine(":----------------------------------:"); //  |");
            Console.WriteLine("| Has seleccionado la opción " + op + "     |");
            Console.WriteLine("| Registro de clientes             |"); //  |");
            Console.WriteLine(":----------------------------------:"); //  |");
            Console.WriteLine(" ");
        }

        //Este metodo lo usamos para mostrar si los ID ya han sido registrados
        public static void IdRegistrado(string str) {
            Console.WriteLine(" ");
            Console.WriteLine("Este " + str + " ya ha sido previamente registrado");
            Console.WriteLine(" ");
        }

        //Este metodo lo usamos para mostrar si el registro tuvo exito
        public static void RegistroExitoso() {
            Console.WriteLine(" ");
            Console.WriteLine(":----------------------------------:");
            Console.WriteLine("| El registro ha sido muy exitoso  |");
            Console.WriteLine(":----------------------------------:");
            Console.WriteLine(" ");
        }

        //Este metodo lo usamos para mostrar si el registro tuvo exito
        public static void RegistroSinExito() {
            Console.WriteLine(" ");
            Console.WriteLine("No hay espacio disponible para agregar el registro");
            Console.WriteLine(" ");
        }

        //Este metodo lo usamos para mostrar ecepciones por ejmplo cuando un dato es invalido para el sistema
        public static void Ecepciones(string str) {
            Console.WriteLine(" ");
            Console.WriteLine(str);
        }

        //Este metodo lo usamos para mostrar si los datos ingresados por el usuario contienen espacios
        public static void HayEspaios(string cadena) {
            if (cadena.Contains(" ")) { //Si este metodo retorna false significa que hay espacios en blanco entonces le mostramos el siguiente mensaje
                Console.WriteLine(" ");
                Console.WriteLine("El valor ingresado contiene espacios");
                Console.WriteLine(" ");
            }
        }
    }
}