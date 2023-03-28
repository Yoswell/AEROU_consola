using System;

//Autor: Yoswel Badilla Toruño

namespace ConsoleApp_Tarea1 {
    class Program {
        //Creamos los arreglos de 20 posiciones cada uno
        public static Cliente[] clientes = new Cliente[20];
        public static Aeropuerto[] aeropuertos = new Aeropuerto[20];
        static Aerolinea[] aerolineas = new Aerolinea[20];
        static Vuelo[] vuelos = new Vuelo[20];

        //Creamos los objetos de tipo aeropuerto y de tipo aerolinea
        static Aerolinea Aerolinea = null;
        static Aeropuerto Origen = null;
        static Aeropuerto Destino = null;

        //Declaracion de variable a utilizar
        public static int contadorClientes = 0, contadorAerolineas = 0, contadorAeropuertos = 0, contadorVuelos = 0, Vacio = 0;
        public static string id, nombre, primerApellido, segundoApellido;
        public static string codigo, nombrea, pais, ciudad, telefono;
        public static int idAero;
        public static string nombreAero, telefonoAero;
        public static int numero, capacidad;
        public static string nombreAerolinea, codigoOrigen, codigoDestino, duracionIngresada;
        public static string idStr, numeroStr, capacidadStr;
        public static bool validarDuracion;
        public static bool estado, estadoValido, estadoAero, estadoValidoAero;
        public static bool Nombre = true, Start = true, Finaly = true;

        //Los try catch son para evitar excepciones que no llegamo a cubrir y asi evitar que el programa no se caiga
        //Lista de metodos y que hace cada uno de ellos
        /*
         * LISTA DE METODOS INSTANCIADOS
            Metodos.Menu            (); Este metodo muestra las opciones del menu
            Metodos.Opcion          (); Este metodo muestra la opcion que el usuario eligio
            Metodos.IdRegistrado    (); Este metodo muestra si el ID ya se a registrado
            Metodos.HayEspacios     (); Este metodo muestra si hay espacios en blanco en algun dato
            Metodos.RegistroExitoso (); Este metodo muestra si los registros fueron exitosos
            Metodos.RegistroSinExito(); Este metodo muestra si los registros no fueron exitosos
            Metodos.Ecepciones      (); Este metodo muestra distintas excepciones

        * LISTA DE METODOS LOCALES
            ValidarId               (); Este metodo valida si el ID del cliente ya se encuentra en el arreglo
            ValidarIdAerolinea      (); Este metodo valida si el ID de la aerolinea ya se encuentra en el arreglo
            ValidarCodigo           (); Este metodo valida si el Codigo del aeropuerto ya se encuentra en el arreglo
            ValidarNumeroVuelo      (); Este metodo valida si el el numero de vuelo ya se encuantra en el arreglo
            MostrarClientes         (); Este metodo muestra los objetos dentro del arreglo clientes
            MostrarAeropuertos      (); Este metodo muestra los objetos dentro del arreglo aeropuertos
            MostrarAerolineas       (); Este metodo muestra los objetos dentro del arreglo aerolineas
            MostrarVuelos           (); Este metodo muestra los objetos dentro del arreglo Vuelos
        */

        static Metodos instancia = new Metodos(); //Instanciamos la clase Metodos a el archivo principal para usar sus metodos
        static void Main() {
            while (true) {
                Metodos.Menu();
                string opcion = Console.ReadLine();

                switch (opcion) {
/// Case numero 1 oooooooooooooooooooooooooo
                    case "1":
                        Metodos.Opcion("1");
                        do {
                            try {
                                Console.Write("Ingrese su número de identificación: ");
                                id = Console.ReadLine();
                                    if (ValidarId(id)) {
                                        Metodos.IdRegistrado("ID");
                                    }
                                Metodos.HayEspaios(id);
                            } catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al solicitar su ID. Detalles: " + ex.Message); }   
                        } while (!ValidarId(id) && string.IsNullOrEmpty(id));
                        //El ciclo do while terminara cuando el ID sea unico y no tenga espacios en blanco

                        do {
                            try {
                                Console.Write("Ingrese su nombre: ");
                                nombre = Console.ReadLine();
                                Metodos.HayEspaios(nombre);
                            }
                            catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar su nombre. Detalles: " + ex.Message); }
                        } while (string.IsNullOrEmpty(nombre));
                        //El ciclo do while terminara cuando el nombre no tenga espacios en blanco

                        do {
                            try {
                                Console.Write("Ingrese su primer apellido: ");
                                primerApellido = Console.ReadLine();
                                Metodos.HayEspaios(primerApellido);
                            }
                            catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar su primer apellido. Detalles: " + ex.Message); }
                        } while (string.IsNullOrEmpty(primerApellido));
                        //El ciclo do while terminara cuando el primer apellido no tenga espacios en blanco

                        do {
                            try {
                                Console.Write("Ingrese su segundo apellido: ");
                                segundoApellido = Console.ReadLine();
                                Metodos.HayEspaios(segundoApellido);
                            }
                            catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar su segundo apellido. Detalles: " + ex.Message); }
                        } while (string.IsNullOrEmpty(segundoApellido));
                        //El ciclo do while terminara cuando el primer apellido no tenga espacios en blanco

                        DateTime fechaNacimiento;
                        while (true) {
                            try {
                                Console.Write("Ingrese su fecha de nacimiento (DD/MM/AAAA): ");
                                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaNacimiento)) {
                                    break;
                                }
                                else {
                                    Metodos.Ecepciones("Formato de fecha incorrecto, intente de nuevo");
                                }
                            } catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar su fecha de nacimiento. Detalles: " + ex.Message); }
                        } //El ciclo while terminara cuando la fecha de nacimiento tenga un formato valido

                        char genero;
                        while (true) {
                            try {
                                Console.Write("Ingrese su género (M = Masculino, F = Femenino, N = No especifica): ");
                                if (char.TryParse(Console.ReadLine().ToUpper(), out genero) && (genero == 'M' || genero == 'F' || genero == 'N')) { //Usamos ToUpper para convertir el caracter en mayuscula
                                    break;
                                }
                                else {
                                    Metodos.Ecepciones("Género inválido, intente de nuevo");
                                }
                            } catch (Exception ex) {
                                Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar su genero. Detalles: " + ex.Message); }
                        } //El ciclo while terminara cuando el genero tenga un formato valido

                        /*Instancia de la clase Cliente, a la que le pasamos las variables para cargarlas en el array de 20
                            Si en el arreglo Clientes todavia hay espacios guardamos el nuevo objeto en la posicion que ocupa el contador
                            Mostramos un mensaje de exito y incrmentamos el contador para la proxima
                            Si en el arreglo no hay espacio se mostrara un mensaje de registro sin exito
                        */
                        if (contadorClientes < 20) {
                            Cliente cliente = new Cliente(id, nombre, primerApellido, segundoApellido, fechaNacimiento, genero);
                            clientes[contadorClientes] = cliente;
                            Metodos.RegistroExitoso();
                            contadorClientes++;
                        }
                        else if (contadorClientes >= 20) {
                            Metodos.RegistroSinExito();
                        }
                        break;

/// Case numero 2 oooooooooooooooooooooooooo
                    case "2":
                        if (contadorClientes > 0) {
                            Metodos.Opcion("2");
                            do {
                                try {
                                    Console.Write("Ingrese el codigo del aeropuerto: ");
                                    codigo = Console.ReadLine();
                                    if (ValidarCodigo(codigo)) {
                                        Metodos.IdRegistrado("Codigo");
                                    }
                                    Metodos.HayEspaios(codigo);
                                }
                                catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar el codigo del aeropuerto. Detalles: " + ex.Message); }
                            } while (!ValidarCodigo(codigo) && string.IsNullOrEmpty(codigo));
                            //El ciclo do while terminara cuando el ID sea unico y no tenga espacios en blanco

                            do {
                                try {
                                    Console.Write("Ingrese el nombre del aeropuerto: ");
                                    nombrea = Console.ReadLine();
                                    Metodos.HayEspaios(nombrea);
                                }
                                catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar el nombre del aeropuerto. Detalles: " + ex.Message); }
                            } while (string.IsNullOrEmpty(nombrea));
                            //El ciclo do while terminara cuando el nombre del aeropuerto no tenga espacios en blanco

                            do {
                                try {
                                    Console.Write("Ingrese el pais al que desea viajar: ");
                                    pais = Console.ReadLine();
                                    Metodos.HayEspaios(pais);
                                }
                                catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar el pais de destino. Detalles: " + ex.Message); }
                            } while (string.IsNullOrEmpty(pais));
                            //El ciclo do while terminara cuando el pais no tenga espacios en blanco

                            do {
                                try {
                                    Console.Write("Ingrese la cuidad en la que hara su estadia: ");
                                    ciudad = Console.ReadLine();
                                    Metodos.HayEspaios(ciudad);
                                }
                                catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar la ciudad. Detalles: " + ex.Message); }
                            } while (string.IsNullOrEmpty(ciudad));
                            //El ciclo do while terminara cuando la ciudad no tenga espacios en blanco

                            do {
                                try {
                                    Console.Write("Ingrese un numero telefonico: ");
                                    telefono = Console.ReadLine();
                                    Metodos.HayEspaios(telefono);
                                }
                                catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar el telefono. Detalles: " + ex.Message); }
                            } while (string.IsNullOrEmpty(telefono));
                            //El ciclo do while terminara cuando el telefono no tenga espacios en blanco

                            do {
                                Console.Write("Ingrese el estado del aeropuerto (A = Activo, I = Inactivo): ");
                                try {
                                    string vaEsAero = Console.ReadLine().ToUpper(); //Usamos ToUpper para convertir el caracter en mayuscula
                                    if (vaEsAero == "A") {
                                        estado = true;
                                        estadoValido = true;
                                    }
                                    else if (vaEsAero == "I") {
                                        estado = false;
                                        estadoValido = true;
                                    }
                                    else {
                                        Metodos.Ecepciones("Estado no válido. Por favor ingrese (A = Activo, I = Inactivo)");
                                    }
                                }
                                catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar el estado. Detalles: " + ex.Message); }
                            } while (!estadoValido);
                            //El ciclo do while terminara cuando el estado del aeropuerto sea valido

                            /*Instancia de la clase Aeropuerto, a la que le pasamos las variables para cargarlas en el array de 20
                                Si en el arreglo Aeropuertos todavia hay espacios guardamos el nuevo objeto en la posicion que ocupa el contador
                                Mostramos un mensaje de exito y incrmentamos el contador para la proxima
                                Si en el arreglo no hay espacio se mostrara un mensaje de registro sin exito
                            */
                            if (contadorAeropuertos < 20) {
                                Aeropuerto aeropuerto = new Aeropuerto(codigo, nombre, pais, ciudad, telefono, estado);
                                aeropuertos[contadorAeropuertos] = aeropuerto;
                                Metodos.RegistroExitoso();
                                contadorAeropuertos++;
                            }
                            else if (contadorAeropuertos >= 20) {
                                Metodos.RegistroSinExito();
                            }
                        }
                        else {
                            Console.Write("Para ingresar a esta opcion de menu antes debe de registar al menos un cliente ");
                            Console.ReadLine();
                        }
                        break;

/// Case numero 3 oooooooooooooooooooooooooo
                    case "3":
                        if (contadorClientes > 0 && contadorAeropuertos > 0) {
                            Metodos.Opcion("3");
                            do {
                                try {
                                    Console.Write("Ingrese el ID de la aerolinea: ");
                                    idStr = Console.ReadLine();
                                    idAero = int.Parse(idStr);
                                    if (ValidarIdAerolinea(idAero)) {
                                        Metodos.IdRegistrado("ID");
                                    }
                                    Metodos.HayEspaios(idStr);
                                }
                                catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar el ID. Detalles: " + ex.Message); }
                            } while (!ValidarIdAerolinea(idAero) && string.IsNullOrEmpty(idStr));
                            //El ciclo do while terminara cuando el ID de la aerolinea sea unico y no tenga espacios en blanco

                            do {
                                try {
                                    Console.Write("Ingrese el nombre de la aerolinea: ");
                                    nombreAero = Console.ReadLine();
                                    Metodos.HayEspaios(nombreAero);
                                }
                                catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar el nombre. Detalles: " + ex.Message); }
                            } while (string.IsNullOrEmpty(nombreAero));
                            //El ciclo do while terminara cuando el nombre de la aerolinea no tenga espacios en blanco

                            do {
                                try {
                                    Console.Write("Ingrese un numero telefonico: ");
                                    telefonoAero = Console.ReadLine();
                                    Metodos.HayEspaios(telefonoAero);
                                }
                                catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar el numero telefonico. Detalles: " + ex.Message); }
                            } while (string.IsNullOrEmpty(telefonoAero));
                            //El ciclo do while terminara cuando el telefono no tenga espacios en blanco

                            do {
                                try {
                                    Console.Write("Ingrese el estado de la aerolinea (A = Activo, I = Inactivo): ");
                                    string vaEsA = Console.ReadLine().ToUpper(); //Usamos ToUpper para convertir el caracter en mayuscula
                                    if (vaEsA == "A") {
                                        estadoAero = true;
                                        estadoValidoAero = true;
                                    }
                                    else if (vaEsA == "I") {
                                        estadoAero = false;
                                        estadoValidoAero = true;
                                    }
                                    else {
                                        Metodos.Ecepciones("Estado no válido. Por favor ingrese (A = Activo, I = Inactivo)");
                                    }
                                }
                                catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar el estado. Detalles: " + ex.Message); }
                            } while (!estadoValidoAero);
                            //El ciclo do while terminara cuando el estado de la aerolinea sea valido

                            /*Instancia de la clase Aerolinea, a la que le pasamos las variables para cargarlas en el array de 20
                                Si en el arreglo Aerolineas todavia hay espacios guardamos el nuevo objeto en la posicion que ocupa el contador
                                Mostramos un mensaje de exito y incrmentamos el contador para la proxima
                                Si en el arreglo no hay espacio se mostrara un mensaje de registro sin exito
                            */
                            if (contadorAerolineas < 20) {
                                Aerolinea aerolinea = new Aerolinea(idAero, nombreAero, telefonoAero, estadoAero);
                                aerolineas[contadorAerolineas] = aerolinea;
                                Metodos.RegistroExitoso();
                                contadorAerolineas++;
                            }
                            else if (contadorAerolineas >= 20) {
                                Metodos.RegistroSinExito();
                            }
                        }
                        else {
                            Console.Write("Para ingresar a esta opcion de menu antes debe de registar al menos un cliente y un aeropuerto ");
                            Console.ReadLine();
                        }
                        break;

/// Case numero 4 oooooooooooooooooooooooooo
                    case "4":
                        if (contadorClientes > 0 && contadorAeropuertos > 0 && contadorAerolineas > 0) {
                            Metodos.Opcion("4");
                            do {
                                try {
                                    Console.Write("Ingrese el numero del vuelo: ");
                                    numeroStr = Console.ReadLine();
                                    if (ValidarNumeroVuelo(numero)) {
                                        Metodos.IdRegistrado("numero");
                                    }
                                    Metodos.HayEspaios(numeroStr);
                                }
                                catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar el número. Detalles: " + ex.Message); }
                            } while (!ValidarNumeroVuelo(numero) && string.IsNullOrEmpty(numeroStr));
                            //El ciclo do while terminara cuando el numero del vuelo sea unico y no tenga espacios en blanco

                            do {
                                try {
                                    Console.Write("Ingrese el nombre de la aerolínea: ");
                                    nombreAerolinea = Console.ReadLine();
                                    Metodos.HayEspaios(nombreAerolinea);
                                    /*Recorrido del arreglo de 20 posiciones mediante un for
                                        Con un for recorremos la todas las posiciones que contenga el arreglo
                                        Comprobamos que las posiciones no esten vacias y si no estan vacias en esa posicion del arreglo
                                        Accedemos al nombre de la aerolinea mediante su propiedad y la comparamos con el dato que estamos ingresando
                                        Si son iguales significa que ya se registro esa aerolinea entonces le asignamos al objeto de tipo aerolinea ese objeto
                                        Y con un brake detenemos el for
                                    */
                                    for (int i = 0; i < aerolineas.Length; i++) {
                                        if (aerolineas[i] != null && aerolineas[i].NombreAero == nombreAerolinea) {
                                            Aerolinea = aerolineas[i];
                                            break;
                                        }
                                        else {
                                            Nombre = false;
                                        }
                                    }
                                    if (Aerolinea == null) {
                                        Metodos.Ecepciones("La aerolínea que ingresaste no existe");
                                    }
                                }
                                catch (Exception ex) { Console.WriteLine(" "); Console.WriteLine("Ha ocurrido un error al ingresar el nombre. Detalles: " + ex.Message); }
                            } while (string.IsNullOrEmpty(nombreAerolinea) && Aerolinea == null);
                            //El ciclo do while terminara cuando el nombre de la aerolinea no tenga espacios en blanco

                            if (Nombre == false) {
                                Console.Write("La aerolínea que ingresaste no se encuentra en los datos almacenados, intentalo de nuevo");
                                Console.ReadLine();
                                break;
                            }

                            do {
                                try {
                                    Console.Write("Ingrese el aeropuerto de origen: ");
                                    codigoOrigen = Console.ReadLine();
                                    Metodos.HayEspaios(codigoOrigen);
                                    /*Recorrido del arreglo de 20 posiciones mediante un for
                                        Con un for recorremos la todas las posiciones que contenga el arreglo
                                        Comprobamos que las posiciones no esten vacias y si no estan vacias en esa posicion del arreglo
                                        Accedemos al aeropuerto de origen mediante su propiedad y la comparamos con el dato que estamos ingresando
                                        Si son iguales significa que ya se registro esa ese aeropuerto entonces le asignamos al objeto de tipo aeropuerto ese objeto
                                        Y con un brake detenemos el for
                                    */
                                    for (int i = 0; i < aeropuertos.Length; i++) {
                                        if (aeropuertos[i] != null && aeropuertos[i].NombreA == codigoOrigen) {
                                            Origen = aeropuertos[i];
                                            break;
                                        }
                                        else {
                                            Start = false;
                                        }
                                    }
                                    if (Origen == null) {
                                        Metodos.Ecepciones("El aeropuerto de origen que ingresaste no existe");
                                    }
                                }
                                catch (Exception ex) { Console.WriteLine("Ha ocurrido un error al ingresar el aeropuerto de origen. Detalles: " + ex.Message); }
                            } while (string.IsNullOrEmpty(codigoOrigen) && Origen == null);

                            if (Start == false) {
                                Console.Write("El aeropuerto de origen que ingresaste no se encuentra en los datos almacenados, intentalo de nuevo");
                                Console.ReadLine();
                                break;
                            }

                            do {
                                try {
                                    Console.WriteLine("Ingrese el país de destino: ");
                                    codigoDestino = Console.ReadLine();
                                    Metodos.HayEspaios(codigoDestino);
                                    /*Recorrido del arreglo de 20 posiciones mediante un for
                                        Con un for recorremos la todas las posiciones que contenga el arreglo
                                        Comprobamos que las posiciones no esten vacias y si no estan vacias en esa posicion del arreglo
                                        Accedemos al aeropuerto de destino mediante su propiedad y la comparamos con el dato que estamos ingresando
                                        Si son iguales significa que ya se registro esa ese aeropuerto entonces le asignamos al objeto de tipo aeropuerto ese objeto
                                        Y con un brake detenemos el for
                                    */
                                    for (int i = 0; i < aeropuertos.Length; i++) {
                                        if (aeropuertos[i] != null && aeropuertos[i].NombreA == codigoDestino) {
                                            Destino = aeropuertos[i];
                                            break;
                                        }
                                        else {
                                            Finaly = false;
                                        }
                                    }
                                    if (Destino == null) {
                                        Console.WriteLine("El aeropuerto de destino que ingresaste no existe.");
                                    }
                                    if (Origen == Destino) {
                                        Metodos.Ecepciones("El aeropuerto de origen y el aeropuerto de destino no pueden ser el mismo");
                                    }
                                }
                                catch (Exception ex) { Console.WriteLine("Ha ocurrido un error al ingresar el aeropuerto de destino. Detalles: " + ex.Message); }
                            } while (string.IsNullOrEmpty(codigoDestino) && (Destino == null) && (Origen != Destino));

                            if (Finaly == false) {
                                Console.Write("El aeropuerto de destino que ingresaste no se encuentra en los datos almacenados, intentalo de nuevo");
                                Console.ReadLine();
                                break;
                            }

                            do {
                                try {
                                    Console.WriteLine("Ingrese la duración del vuelo (hh:mm): ");
                                    duracionIngresada = Console.ReadLine();
                                    Metodos.HayEspaios(duracionIngresada);
                                    TimeSpan duracion;
                                    validarDuracion = TimeSpan.TryParseExact(duracionIngresada, @"hh\:mm", null, out duracion);
                                        if (!validarDuracion) {
                                            Console.WriteLine("La duración del vuelo no es válida.");
                                            validarDuracion = false;
                                        }
                                }
                                catch (Exception ex) { Console.WriteLine("Ha ocurrido un error al ingresar la duración del vuelo. Detalles: " + ex.Message); }
                            } while (string.IsNullOrEmpty(duracionIngresada) && (validarDuracion != false));

                            do {
                                try {
                                    Console.WriteLine("Ingrese la cantidad de pasajeros: ");
                                    capacidad = int.Parse(Console.ReadLine());
                                    capacidadStr = capacidad.ToString();
                                    Metodos.HayEspaios(capacidadStr);
                                        if (capacidadStr.Length > 3) {
                                            Metodos.Ecepciones("La cantidad maxima de caracteres en este campo es de 3");
                                        }
                                }
                                catch (Exception ex) { Console.WriteLine("Ha ocurrido un error al ingresar la cantidad. Detalles: " + ex.Message); }
                            } while (string.IsNullOrEmpty(capacidadStr) && (capacidadStr.Length <= 3));

                            /*Instancia de la clase Vuelo, a la que le pasamos las variables para cargarlas en el array de 20
                                Si en el arreglo Vuelos todavia hay espacios guardamos el nuevo objeto en la posicion que ocupa el contador
                                Mostramos un mensaje de exito y incrmentamos el contador para la proxima
                                Si en el arreglo no hay espacio se mostrara un mensaje de registro sin exito
                            */
                            if (contadorVuelos < 20) {
                                Vuelo vuelo = new Vuelo(numero, Aerolinea, Origen, Destino, duracionIngresada, capacidad);
                                vuelos[contadorVuelos] = vuelo;
                                Metodos.RegistroExitoso();
                                contadorVuelos++;
                            }
                            else if (contadorVuelos >= 20) {
                                Metodos.RegistroSinExito();
                            }
                        } 
                        else {
                            Console.Write("Para ingresar a esta opcion de menu antes debe de registar al menos un cliente, un aeropuerto y una aerolinea ");
                            Console.ReadLine();
                        }
                        break;

/// Case numero 5 y posteriores donde se muestran los datos
                    case "5":
                        char mostrarClientesSN;
                        if (contadorClientes > 0) {
                            while (true) {
                                Console.WriteLine("¿Desea consultar los clientes? (S = Si, N = No)");
                                if (char.TryParse(Console.ReadLine().ToUpper(), out mostrarClientesSN) && (mostrarClientesSN == 'S' || mostrarClientesSN == 'N')) { //Usamos ToUpper para convertir el caracter en mayuscula
                                    if (mostrarClientesSN == 'S') { //Si el usuario desea mostrar los datos los mostramos y detenemos el while
                                        MostrarClientes(); //Mostramos los clientes almacenados mediante este metodo
                                        Console.ReadLine();
                                        break;
                                    }
                                    else if (mostrarClientesSN == 'N') {
                                        break;
                                    }
                                }
                                else {
                                    Metodos.Ecepciones("Estado no válido. Por favor ingrese (S = Si, N = No)");
                                }
                            }
                        }
                        else {
                            Console.WriteLine(" ");
                            Console.Write("Para ingresar a esta opcion primero debe de registrar al manos un cliente ");
                            Console.ReadLine();
                        }
                        break;

                    case "6":
                        char mostrarAeropuertosSN;
                        if (contadorAeropuertos > 0) {
                            while (true) {
                                Console.WriteLine("¿Desea consultar los clientes? (S = Si, N = No)");
                                if (char.TryParse(Console.ReadLine().ToUpper(), out mostrarAeropuertosSN) && (mostrarAeropuertosSN == 'S' || mostrarAeropuertosSN == 'N')) { //Usamos ToUpper para convertir el caracter en mayuscula
                                    if (mostrarAeropuertosSN == 'S') { //Si el usuario desea mostrar los datos los mostramos y detenemos el while
                                        MostrarAeropuertos(); //Mostramos los aeropuertos almacenados mediante este metodo
                                        Console.ReadLine();
                                        break;
                                    }
                                    else if (mostrarAeropuertosSN == 'N') {
                                        break;
                                    }
                                }
                                else {
                                    Metodos.Ecepciones("Estado no válido. Por favor ingrese (S = Si, N = No)");
                                }
                            }
                        } else {
                            Console.WriteLine(" ");
                            Console.Write("Para ingresar a esta opcion primero debe de registrar al manos un aeropuerto ");
                            Console.ReadLine();
                        }
                        break;

                    case "7":
                        char mostrarAerolineasSN;
                        if (contadorAerolineas > 0) {
                            while (true) {
                                Console.WriteLine("¿Desea consultar los clientes? (S = Si, N = No)");
                                if (char.TryParse(Console.ReadLine().ToUpper(), out mostrarAerolineasSN) && (mostrarAerolineasSN == 'S' || mostrarAerolineasSN == 'N')) { //Usamos ToUpper para convertir el caracter en mayuscula
                                    if (mostrarAerolineasSN == 'S') { //Si el usuario desea mostrar los datos los mostramos y detenemos el while
                                        MostrarAerolineas(); //Mostramos las aerolineas almacenadas mediante este metodo
                                        Console.ReadLine();
                                        break;
                                    }
                                    else if (mostrarAerolineasSN == 'N') {
                                        break;
                                    }
                                }
                                else {
                                    Metodos.Ecepciones("Estado no válido. Por favor ingrese (S = Si, N = No)");
                                }
                            }
                        }
                        else {
                            Console.WriteLine(" ");
                            Console.Write("Para ingresar a esta opcion primero debe de registrar al manos una aerolinea ");
                            Console.ReadLine();
                        }
                        break;

                    case "8":
                        char mostrarVuelosSN;
                        if (contadorVuelos > 0) {
                            while (true) {
                                Console.WriteLine("¿Desea consultar los clientes? (S = Si, N = No)");
                                if (char.TryParse(Console.ReadLine().ToUpper(), out mostrarVuelosSN) && (mostrarVuelosSN == 'S' || mostrarVuelosSN == 'N')) { //Usamos ToUpper para convertir el caracter en mayuscula
                                    if (mostrarVuelosSN == 'S') { //Si el usuario desea mostrar los datos los mostramos y detenemos el while
                                        MostrarVuelos(); //Mostramos los vuelos almacenadas mediante este metodo
                                        Console.ReadLine();
                                        break;
                                    }
                                    else if (mostrarVuelosSN == 'N') {
                                        break;
                                    }
                                }
                                else {
                                    Metodos.Ecepciones("Estado no válido. Por favor ingrese (S = Si, N = No)");
                                }
                            }
                        } else {
                            Console.WriteLine(" ");
                            Console.Write("Para ingresar a esta opcion primero debe de registrar al manos un vuelo ");
                            Console.ReadLine();
                        }
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                        Metodos.Ecepciones("Esta opción no esválida, intentalo nuevamente");
                        break;
                }
                Console.WriteLine();
            }
        }

        /*Metodo que valida si el ID del cliente ya se encuentra en el arreglo
            Con un for recorremos la cantidad de objetos del arreglo mediante un contador que incrementa cada vez que se registre un objeto
            si durante ese proceso se encuentra un ID igual al que se esta por registrar retornara un resultado booleano
        */
        static bool ValidarId(string id) {
            for (int i = 0; i < contadorClientes; i++) {
                if (clientes[i].Id == id) {
                    return true;
                }
            }
            return false;
        }

        /*Metodo que valida si el ID de la aerolinea ya se encuentra en el arreglo
            Con un for recorremos la cantidad de objetos del arreglo mediante un contador que incrementa cada vez que se registre un objeto
            si durante ese proceso se encuentra un ID igual al que se esta por registrar retornara un resultado booleano
        */
        static bool ValidarIdAerolinea(int id) {
            for (int i = 0; i < contadorAerolineas; i++) {
                if (aerolineas[i].IdAero == id) {
                    return true;
                }
            }
            return false;
        }

        /*Metodo que valida si el Codigo del aeropuerto ya se encuentra en el arreglo
            Con un for recorremos la cantidad de objetos del arreglo mediante un contador que incrementa cada vez que se registre un objeto
            si durante ese proceso se encuentra un ID igual al que se esta por registrar retornara un resultado booleano
        */
        static bool ValidarCodigo(string codigo) {
            for (int i = 0; i < contadorAeropuertos; i++) {
                if (aeropuertos[i].Codigo == codigo) {
                    return true;
                }
            }
            return false;
        }

        /*Metodo que valida si el Numero de vuelo de los vuelos ya se encuentra en el arreglo
            Con un for recorremos la cantidad de objetos del arreglo mediante un contador que incrementa cada vez que se registre un objeto
            si durante ese proceso se encuentra un ID igual al que se esta por registrar retornara un resultado booleano
        */
        static bool ValidarNumeroVuelo(int numero) {
            for (int i = 0; i < contadorVuelos; i++) {
                if (vuelos[i].Numero == numero) {
                    return true;
                }
            }
            return false;
        }

        /*Metodo que muestra los objetos del arreglo Clientes
            Con un for recorremos la cantidad de objetos del arreglo mediante un contador que incrementa cada vez que se registre un objeto
            si el contador es mayor a 0 osea cuando tenga el arreglo tenga al menos un objeto se mostraran los datos
            mediante el uso de propiedades de la clase Cliente
        */
        public static void MostrarClientes() {
            for (int i = 0; i < contadorClientes; i++) {
                if (contadorClientes > 0) {
                    Console.WriteLine("Identificación      :" + clientes[i].Id);
                    Console.WriteLine("Nombre              :" + clientes[i].Nombre);
                    Console.WriteLine("Primer Apellido     :" + clientes[i].PrimerApellido);
                    Console.WriteLine("Segundo Apellido    :" + clientes[i].SegundoApellido);
                    Console.WriteLine("Fecha de Nacimiento :" + clientes[i].FechaNacimiento.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Género              :" + clientes[i].Genero);
                    Console.WriteLine(" ");
                }
            }
        }

        /*Metodo que muestra los objetos del arreglo Aeropuertos
            Con un for recorremos la cantidad de objetos del arreglo mediante un contador que incrementa cada vez que se registre un objeto
            si el contador es mayor a 0 osea cuando tenga el arreglo tenga al menos un objeto se mostraran los datos
            mediante el uso de propiedades de la clase Aeropuertos
        */
        public static void MostrarAeropuertos() {
            for (int i = 0; i < contadorAeropuertos; i++) {
                if (contadorAeropuertos > 0) {
                    Console.WriteLine("Codigo del aeropuerto :" + aeropuertos[i].Codigo);
                    Console.WriteLine("Nombre del aeropuerto :" + aeropuertos[i].NombreA);
                    Console.WriteLine("Pais                  :" + aeropuertos[i].Pais);
                    Console.WriteLine("Ciudad                :" + aeropuertos[i].Ciudad);
                    Console.WriteLine("Telefono              :" + aeropuertos[i].Telefono);
                    Console.WriteLine("Estado                :" + aeropuertos[i].Estado);
                    Console.WriteLine(" ");
                }
            }
        }

        /*Metodo que muestra los objetos del arreglo Aerolineas
            Con un for recorremos la cantidad de objetos del arreglo mediante un contador que incrementa cada vez que se registre un objeto
            si el contador es mayor a 0 osea cuando tenga el arreglo tenga al menos un objeto se mostraran los datos
            mediante el uso de propiedades de la clase Aerolineas
        */
        public static void MostrarAerolineas() {
            for (int i = 0; i < contadorAerolineas; i++) {
                if (contadorAeropuertos > 0) {
                    Console.WriteLine("Identificación         :" + aerolineas[i].IdAero);
                    Console.WriteLine("Nombre de la aerolinea :" + aerolineas[i].NombreAero);
                    Console.WriteLine("Teléfono               :" + aerolineas[i].TelefonoAero);
                    Console.WriteLine("Estado                 :" + aerolineas[i].EstadoAero);
                    Console.WriteLine(" ");
                }
            }
        }

        /*Metodo que muestra los objetos del arreglo Vuelos
            Con un for recorremos la cantidad de objetos del arreglo mediante un contador que incrementa cada vez que se registre un objeto
            si el contador es mayor a 0 osea cuando tenga el arreglo tenga al menos un objeto se mostraran los datos
            mediante el uso de propiedades de la clase Vuelos
        */
        public static void MostrarVuelos() {
            for (int i = 0; i < contadorVuelos; i++) {
                if (contadorVuelos > 0) {
                    Console.WriteLine("Numero de vuelo        :" + vuelos[i].Numero);
                    Console.WriteLine("Nombre de la aerolinea :" + vuelos[i].Aerolinea);
                    Console.WriteLine("Origen                 :" + vuelos[i].Origen);
                    Console.WriteLine("Destino                :" + vuelos[i].Destino);
                    Console.WriteLine("Duración del vuelo     :" + vuelos[i].DuracionSrt);
                    Console.WriteLine("Cantidad de pasajeros  :" + vuelos[i].Capacidad);
                    Console.WriteLine(" ");
                }
            }
        }
    }

    class Cliente { // Clase que contiene las propiedades de los clientes
        public string Id                { get; set; }
        public string Nombre            { get; set; }
        public string PrimerApellido    { get; set; }
        public string SegundoApellido   { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Genero              { get; set; }

        // Metodo Clientes que almacena todas las variables relacionadas a los Clientes que luego se usara para crear el objeto
        public Cliente(string id, string nombre, string primerApellido, string segundoApellido, DateTime fechaNacimiento, char genero) {
            Id = id;
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacimiento = fechaNacimiento;
            Genero = genero;
        }
    }
    class Aeropuerto { // Clase que contiene las propiedades de los Aeropuestos
        public string Codigo   { get; set; }
        public string NombreA  { get; set; }
        public string Pais     { get; set; }
        public string Ciudad   { get; set; }
        public string Telefono { get; set; }
        public bool Estado     { get; set; }

        // Metodo Aeropuerto que almacena todas las variables relacionadas a los Aeropuertos que luego se usara para crear el objeto
        public Aeropuerto(string codigo, string nombrea, string pais, string ciudad, string telefono, bool estado) {
            Codigo = codigo;
            NombreA = nombrea;
            Pais = pais;
            Ciudad = ciudad;
            Telefono = telefono;
            Estado = estado;
        }
    }
    class Aerolinea { // Clase que contiene las propiedades de los Aerolineas
        public int IdAero          { get; set; }
        public string NombreAero   { get; set; }
        public string TelefonoAero { get; set; }
        public bool EstadoAero     { get; set; }

        // Metodo Aerolinea que almacena todas las variables relacionadas a los Aerolineas que luego se usara para crear el objeto
        public Aerolinea(int idAero, string nombreAero, string telefonoAero, bool estadoAero) {
            IdAero = idAero;
            NombreAero = nombreAero;
            TelefonoAero = telefonoAero;
            EstadoAero = estadoAero;
        }
    }
    class Vuelo { // Clase que contiene las propiedades de los Vuelos
        public int Numero          { get; set; }
        public Aerolinea Aerolinea { get; set; }
        public Aeropuerto Origen   { get; set; }
        public Aeropuerto Destino  { get; set; }
        public string DuracionSrt  { get; set; }
        public int Capacidad       { get; set; }

        // Metodo Vuelo que almacena todas las variables relacionadas a los Vuelos que luego se usara para crear el objeto
        public Vuelo(int numero, Aerolinea aerolinea, Aeropuerto origen, Aeropuerto destino, string duracionStr, int capacidad) {
            Numero = numero;
            Aerolinea = aerolinea;
            Origen = origen;
            Destino = destino;
            DuracionSrt = duracionStr;
            Capacidad = capacidad;
        }
    }
} 