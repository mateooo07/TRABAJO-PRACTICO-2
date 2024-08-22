class TrabajoPractico2
{
    // Definición de variables.
    static int codigoVuelo1 = 1;
    static int codigoVuelo2 = 2;
    static int codigoVuelo3 = 3;
    static int codigoVuelo4 = 4;
    static int codigoVuelo5 = 5;
    static int codigoVuelo6 = 6;

    static int precioVuelo1 = 43700;
    static int precioVuelo2 = 43700;
    static int precioVuelo3 = 52000;
    static int precioVuelo4 = 52000;
    static int precioVuelo5 = 183000;
    static int precioVuelo6 = 183000;

   
    static bool numeroVueloCorrecto = false;
    static int cantidadPasajes = -1;
    static int precioTotal = 0;

    static bool registrado = false;
    static bool sesiónIniciada = false;

    static string nombreCompleto = "";
    static string telefono = "";
    static string documento = "";
    static string correoElectronico = "";
    static string nombreUsuario = "";
    static string contraseña = "";

    static bool tieneArrobaCorreo = false;
    static bool tienePuntoCorreo = false;
    static int contadorCaracteresCorreo = 0;
    static bool correoElectronicoValido = false;
    static int contadorCaracteresDocumento = 0;
    static int contadorPuntosDocumento = 0;
    static bool DocumentoValido = false;
    static int contadorIntentos = 3;
    static int opcion = -1;
    static bool agregoCarritoVuelo = false;
    static ConsoleKeyInfo volverMenu;

    static DateTime fechaActual = DateTime.Now;

    static ConsoleColor colorOriginalLetra = Console.ForegroundColor;
    static ConsoleColor colorOriginalFondo = ConsoleColor.Black;

    static void Main()
    {
        Inicio();// Muestra una pantalla de bienvenida inicial
        Menú();// Muestra el menú principal y maneja la selección del usuario.
    }
    static void Inicio() // Función correspondiente a la pantalla de bienvenida.
    {
        Console.CursorVisible = false;
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("|¡Bienvenido a Aerolíneas Argentinas!|");
        Console.WriteLine("--------------------------------------");
        ConsoleColor colorCeleste = ConsoleColor.Cyan;
        ConsoleColor colorBlanco = ConsoleColor.White;
        int ancho = 40;
        int alto = 9;

        for (int i = 0; i < alto; i++)
        {

            if (i < 3)
            {
                Console.BackgroundColor = colorCeleste;
            }
            else if (i >= 3 && i < 6)
            {
                Console.BackgroundColor = colorBlanco;
            }
            else
            {
                Console.BackgroundColor = colorCeleste;
            }


            Console.WriteLine(new string(' ', ancho));
        }



        Console.BackgroundColor = colorOriginalFondo;
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();


    }
    static void Menú()//Función correspondiente al menu principal del programa.
    {
        ConsoleKeyInfo Flecha;
        Console.CursorVisible = false;
        do
        {

            Console.Clear();
            Console.WriteLine("Use las flechas para moverse y Enter para seleccionar:\n");

            for (int i = 0; i <= 6; i++)
            {
                if (opcion == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Cambia el color de la opcion seleccionada.
                    Console.WriteLine($"> {MenuNumeros(i)}");
                    Console.ForegroundColor = colorOriginalLetra; // Restaurar al color original.
                }
                else
                {
                    // Mostrar las otras opciones en el color normal.
                    Console.WriteLine($" {MenuNumeros(i)}");
                }
            }

            Flecha = Console.ReadKey(true);

            if (Flecha.Key == ConsoleKey.UpArrow && opcion > 0) opcion--;
            if (Flecha.Key == ConsoleKey.DownArrow && opcion < 6) opcion++;


        } while (Flecha.Key != ConsoleKey.Enter);


        switch (opcion)
        {
            case 0:
                Console.Clear();
                VueloDisponible();
                EsperarYVolverAlMenu();
                break;
            case 1:
                if (sesiónIniciada)
                {
                    agregoCarritoVuelo = AgregarCarrito(agregoCarritoVuelo);
                    Thread.Sleep(1500);
                    Menú();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Usted debe iniciar sesión para poder agregar algo a su carrito.");
                    EsperarYVolverAlMenu();
                }
                break;
            case 2:
                if (agregoCarritoVuelo)
                {
                    agregoCarritoVuelo = PagarVuelo(agregoCarritoVuelo);
                    Menú();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Usted no tiene ningún pasaje de vuelo en su carrito.");
                    EsperarYVolverAlMenu();
                }
                break;
            case 3:
                registrado = Registro(registrado);
                Menú();
                break;
            case 4:
                if (registrado == true)
                {
                    sesiónIniciada = InicioDeSesión(sesiónIniciada);
                    Menú();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Usted debe registrarse primero.");
                    EsperarYVolverAlMenu();
                }
                break;
            case 5:
                if (registrado == true)
                {
                    BorrarDatos();
                    EsperarYVolverAlMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Usted debe registrarse primero.");
                    EsperarYVolverAlMenu();
                }
                break;
            case 6:
                Console.Clear();
                Console.WriteLine("Saliendo del sistema.");
                Console.WriteLine("\nEspero no haya tenido inconvenientes con el programa. ¡Hasta luego!");
                Thread.Sleep(2000);
                return; // Salir del programa.
        }
    }

    static string MenuNumeros(int indice)// Devuelve el texto de las opciones del menú según el índice.
    {
        switch (indice)
        {
            case 0:
                return "Ver vuelos disponibles";
            case 1:
                return "Agregar al carrito";
            case 2:
                return "Pagar pasajes";
            case 3:
                return "Registrarse";
            case 4:
                return "Iniciar sesión";
            case 5:
                return "Borrar datos cargados";
            case 6:
                return "Salir del sistema";
            default:
                return "";
        }
    }

    static void EsperarYVolverAlMenu()// Espera que el usuario presione 'M' para volver al menú.
    {
        bool volverValido = false;
        while (volverValido != true)
        {
            Console.WriteLine("\nPresiona 'M' para volver al menú.");
            volverMenu = Console.ReadKey(true);

            if (volverMenu.Key == ConsoleKey.M)
            {
                volverValido = true;
            }
            else
            {
                volverValido = false;
            }
        }
        Menú();
    }



    static void VueloDisponible()// Muestra una tabla con los vuelos disponibles
    {

        Console.Clear();
        Console.WriteLine("------------------------------------------------------------------------------------------");
        Console.WriteLine("|Numero|       Origen        |       Destino       |Hora de Salida|Hora de llegada|Precio|");
        Console.WriteLine("------------------------------------------------------------------------------------------");
        Console.WriteLine("| " + codigoVuelo1 + "    |Córdoba              |Buenos Aires(Ezeiza) |21:50         |23:10          |" + precioVuelo1 + " |");
        Console.WriteLine("------------------------------------------------------------------------------------------");
        Console.WriteLine("| " + codigoVuelo2 + "    |Buenos Aires(Ezeiza) |Córdoba              |19:50         |21:10          |" + precioVuelo2 + " |");
        Console.WriteLine("------------------------------------------------------------------------------------------");
        Console.WriteLine("| " + codigoVuelo3 + "    |Córdoba              |Mendoza              |16:45         |17:55          |" + precioVuelo3 + " |");
        Console.WriteLine("------------------------------------------------------------------------------------------");
        Console.WriteLine("| " + codigoVuelo4 + "    |Mendoza              |Córdoba              |21:50         |23:10          |" + precioVuelo4 + " |");
        Console.WriteLine("------------------------------------------------------------------------------------------");
        Console.WriteLine("| " + codigoVuelo5 + "    |Córdoba              |Bariloche            |21:50         |7:35           |" + precioVuelo5 + "|");
        Console.WriteLine("------------------------------------------------------------------------------------------");
        Console.WriteLine("| " + codigoVuelo6 + "    |Bariloche            |Córdoba              |13:00         |15:00          |" + precioVuelo6 + "|");
        Console.WriteLine("------------------------------------------------------------------------------------------");
        Thread.Sleep(1500);



    }

    static bool AgregarCarrito(bool agregoCarritoVuelo)// Permite al usuario agregar un vuelo al carrito.
    {
        Console.CursorVisible = true;

        numeroVueloCorrecto = false;
        cantidadPasajes = -1;
        int numeroViajeUsuario = 0;
        Console.Clear();
        while (numeroVueloCorrecto == false)
        {
            Console.Write("Ingrese el número del viaje: ");
            numeroViajeUsuario = int.Parse(Console.ReadLine());
            if (numeroViajeUsuario >= 1 && numeroViajeUsuario <= 6)
            {
                numeroVueloCorrecto = true;
            }
            else
            {
                Console.WriteLine("Elija un número de vuelo existente.\n");
            }
        }
        Console.Write("Ingrese la fecha del viaje(dd/mm/YYYY/): ");
        string fechaIngresada = Console.ReadLine();
        DateTime fechaViaje = DateTime.Parse(fechaIngresada);
        while (cantidadPasajes > 10 || cantidadPasajes < 0)
        {
            Console.Write("Ingrese la cantidad de pasajes: ");
            cantidadPasajes = int.Parse(Console.ReadLine());
            if (cantidadPasajes > 10 || cantidadPasajes < 0)
            {
                Console.WriteLine("\nElija una cantidad adecuada.");
            }
        }

        if (numeroViajeUsuario == codigoVuelo1 && fechaActual <= fechaViaje && cantidadPasajes > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCarga realizada con exito!...");
            Console.ForegroundColor = colorOriginalLetra;
            precioTotal = cantidadPasajes * precioVuelo1;

            return true;
        }
        else if (numeroViajeUsuario == codigoVuelo2 && fechaActual <= fechaViaje && cantidadPasajes > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCarga realizada con exito!...");
            Console.ForegroundColor = colorOriginalLetra;
            precioTotal = cantidadPasajes * precioVuelo2;

            return true;


        }
        else if (numeroViajeUsuario == codigoVuelo3 && fechaActual <= fechaViaje && cantidadPasajes > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCarga realizada con exito!...");
            Console.ForegroundColor = colorOriginalLetra;
            precioTotal = cantidadPasajes * precioVuelo3;

            return true;

        }
        else if (numeroViajeUsuario == codigoVuelo4 && fechaActual <= fechaViaje && cantidadPasajes > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCarga realizada con exito!...");
            Console.ForegroundColor = colorOriginalLetra;
            precioTotal = cantidadPasajes * precioVuelo4;

            return true;


        }
        else if (numeroViajeUsuario == codigoVuelo5 && fechaActual <= fechaViaje && cantidadPasajes > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCarga realizada con exito!...");
            Console.ForegroundColor = colorOriginalLetra;
            precioTotal = cantidadPasajes * precioVuelo5;

            return true;


        }
        else if (numeroViajeUsuario == codigoVuelo6 && fechaActual <= fechaViaje && cantidadPasajes > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCarga realizada con exito!...");
            Console.ForegroundColor = colorOriginalLetra;
            precioTotal = cantidadPasajes * precioVuelo6;

            return true;
        }
        else if (cantidadPasajes == 0 || fechaActual > fechaViaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNo se cargo nada al carrito.");
            Console.WriteLine("Revise la cantidad de pasajes o la fecha del viaje.");
            Console.ForegroundColor = colorOriginalLetra;
            Thread.Sleep(1500);
            return false;


        }
        else
        {
            return false;
        }

        Thread.Sleep(3000);
    }

    static bool PagarVuelo(bool agregoCarritoVuelo)// Calcula el precio total según el vuelo seleccionado y le permite al usuario pagar el/los vuelo/s.
    {
        Console.Clear();
        Console.CursorVisible = true;

        Console.WriteLine($"El costo del viaje total con los pasajes seleccionados sin IVA es de: {precioTotal}$.");
        Console.WriteLine($"\nLa cantidad de pasajes comprados fue de: {cantidadPasajes}");
        double precioConIVA = precioTotal + ((precioTotal / 100) * 10.5);
        Console.WriteLine($"\nLa suma total incluyendo el IVA es de {precioConIVA}$.");
        Console.Write("\nEscriba '1' si quiere confirmar su compra o '0' si quiere cancelar la carga: ");
        int cargaUsuario = int.Parse(Console.ReadLine());
        if (cargaUsuario == 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSu compra ha sido confirmada.");
            Console.ForegroundColor = colorOriginalLetra;
            Thread.Sleep(1500);
            return true;

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nEl carrito ha sido vaciado.");
            Console.ForegroundColor = colorOriginalLetra;
            Thread.Sleep(1500);
            return false;
        }
        Thread.Sleep(1500);
    }

    static bool Registro(bool registro)// Permite al usuario registrarse en el sistema.
    {
        Console.Clear();
        Console.CursorVisible = true;
        if(registro == false)
        {
            Console.Write("Ingrese su nombre completo: ");
            nombreCompleto = Console.ReadLine();
            Console.Write("\nIngrese su telefóno: ");
            telefono = Console.ReadLine();
            while (DocumentoValido == false) // Valida el formato del número de documento.
            {
                contadorCaracteresDocumento = 0;
                contadorPuntosDocumento = 0;
                Console.Write("\nIngrese su documento(xx.xxx.xxx):");
                documento = Console.ReadLine();
                foreach (char caracterDocumento in documento)
                {
                    if (caracterDocumento == '.')
                    {
                        contadorPuntosDocumento++;
                    }
                    contadorCaracteresDocumento++;
                }
                if (contadorPuntosDocumento == 2 && contadorCaracteresDocumento == 10)
                {
                    DocumentoValido = true;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El documento no es valido. Escribalo de nuevo.");
                    Console.ForegroundColor = colorOriginalLetra;
                    contadorCaracteresDocumento = 0;
                    contadorPuntosDocumento = 0;
                }
            }

            while (correoElectronicoValido == false)// Valida el formato del correo electrónico.
            {
                tieneArrobaCorreo = false;
                tienePuntoCorreo = false;
                contadorCaracteresCorreo = 0;
                Console.Write("\nIngrese su correo electrónico: ");
                correoElectronico = Console.ReadLine();
                foreach (char caracter in correoElectronico)
                {
                    if (caracter == '@')
                    {
                        tieneArrobaCorreo = true;
                    }
                    if (caracter == '.')
                    {
                        tienePuntoCorreo = true;
                    }
                    contadorCaracteresCorreo++;
                }
                if (tieneArrobaCorreo == true && tienePuntoCorreo == true && contadorCaracteresCorreo > 10)
                {
                    correoElectronicoValido = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Su correo es invalido. Escribalo de nuevo.");
                    Console.ForegroundColor = colorOriginalLetra;
                    contadorCaracteresCorreo = 0;
                }

            }
            Console.Write("\nIngrese su nombre de usuario: ");
            nombreUsuario = Console.ReadLine();
            Console.Write("\nIngrese su contraseña: ");
            contraseña = Console.ReadLine();
            return true;
            Thread.Sleep(1500);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Usted ya se registró.");
            Thread.Sleep(1500);
            return true;


        }

        
    }

    static bool InicioDeSesión(bool sesiónIniciada)// Permite al usuario iniciar sesión en el sistema.
    {
        if (sesiónIniciada == false)
        {
            Console.Clear();
            Console.CursorVisible = true;

            contadorIntentos = 3;

            while (sesiónIniciada == false && contadorIntentos > 0)// Verifica si los datos de inicio de sesión son correctos.
            {
                Console.Write("Ingrese el nombre de usuario registrado: ");
                string nombreUsuarioRegistrado = Console.ReadLine();


                if (nombreUsuario != nombreUsuarioRegistrado)
                {
                    contadorIntentos--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nEl usuario que ingresó es incorrecto o no existe. Le queda/n {contadorIntentos} intento/s.");
                    Console.ForegroundColor = colorOriginalLetra;

                    if (contadorIntentos == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Se quedó sin intentos. Inténtelo de nuevo más tarde.");
                        Console.ForegroundColor = colorOriginalLetra;
                        Thread.Sleep(2000);
                        return false;
                    }



                    continue;
                }

                Console.Write("\nIngrese la contraseña: ");
                string contraseñaRegistrada = Console.ReadLine();


                if (contraseña != contraseñaRegistrada)// Verifica si los datos de inicio de sesión son correctos.
                {
                    contadorIntentos--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nLa contraseña es incorrecta. Le queda/n {contadorIntentos} intento/s. Ingrese los datos nuevamente.");
                    Console.ForegroundColor = colorOriginalLetra;

                    if (contadorIntentos == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Se quedó sin intentos. Inténtelo de nuevo más tarde.");
                        Console.ForegroundColor = colorOriginalLetra;
                        Thread.Sleep(2000);
                        return false;
                    }


                    continue;
                }

                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nInicio de sesión exitoso!");
                Console.ForegroundColor = colorOriginalLetra;
                Thread.Sleep(1000);

                return true;
            }
            return false;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Usted ya inicio sesión.");
            Thread.Sleep(1500);
            return true;
        }

    }     
    static void BorrarDatos()// Borra los datos del usuario.
    {
        Console.Clear();
        Console.CursorVisible = true;

        Console.Write("\nEsta seguro de querer borrar sus datos? (S/N): ");
        string datosBorrar = Console.ReadLine().ToLower();

        if (datosBorrar == "s"||datosBorrar=="S")
        {
            nombreCompleto = "";
            telefono = "";
            documento = "";
            correoElectronico = "";
            nombreUsuario = "";
            contraseña = "";

            registrado = false;
            sesiónIniciada = false;
            tieneArrobaCorreo = false;
            tienePuntoCorreo = false;
            contadorCaracteresDocumento = 0;
            contadorPuntosDocumento = 0;
            contadorCaracteresCorreo = 0;
            correoElectronicoValido = false;
            agregoCarritoVuelo = false;
            numeroVueloCorrecto = false;
            DocumentoValido = false;
            contadorIntentos = 3;

            Console.WriteLine("\nSus datos han sido borrados correctamente.");
            Thread.Sleep(1500);

        }
        else if(datosBorrar =="n"||datosBorrar=="N")
        {
            Console.WriteLine("\nNo se borraran sus datos.");
            Thread.Sleep(1000);
        }
    }
}