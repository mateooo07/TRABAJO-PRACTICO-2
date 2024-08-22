class TrabajoPractico2
{
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
        Inicio();
        Menú();
    }
    static void Inicio()
    {
        Console.CursorVisible = false;
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("|¡Bienvenido a Aerolíneas Argentinas!|");
        Console.WriteLine("--------------------------------------");
        ConsoleColor colorCeleste = ConsoleColor.Cyan;
        ConsoleColor colorBlanco = ConsoleColor.White;
        ConsoleColor colorAmarillo = ConsoleColor.Yellow;
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
    static void Menú()
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
                    Console.ForegroundColor = ConsoleColor.Gray; // Restaurar al color original
                }
                else
                {
                    // Mostrar las otras opciones en el color normal
                    Console.WriteLine($" {MenuNumeros(i)}");
                }
            }

            //Console.WriteLine((opcion == 0 ? "> " : "  ") + "Ver vuelos disponibles.");
            //Console.WriteLine((opcion == 1 ? "> " : "  ") + "Agregar al carrito.");
            //Console.WriteLine((opcion == 2 ? "> " : "  ") + "Pagar pasajes.");
            //Console.WriteLine((opcion == 3 ? "> " : "  ") + "Registrarse.");
            //Console.WriteLine((opcion == 4 ? "> " : "  ") + "Iniciar sesión.");
            //Console.WriteLine((opcion == 5 ? "> " : "  ") + "Borrar datos cargados.");
            //Console.WriteLine((opcion == 6 ? "> " : "  ") + "Salir del sistema.");

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

    static string MenuNumeros(int indice)
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
                return "Iniciar sesion";
            case 5:
                return "Borrar datos cargados";
            case 6:
                return "Salir del sistema";
            default:
                return "";
        }
    }

    static void EsperarYVolverAlMenu()
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



    static void VueloDisponible()
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

    static bool AgregarCarrito(bool agregoCarritoVuelo)
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
                Console.WriteLine("\nElija un número de vuelo existente.");
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
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSe ha agregado al carrito, con exito!...");
            Console.BackgroundColor = ConsoleColor.Gray;
            precioTotal = cantidadPasajes * precioVuelo1;

            return true;
        }
        else if (numeroViajeUsuario == codigoVuelo2 && fechaActual <= fechaViaje && cantidadPasajes > 0)
        {
            Console.WriteLine("\nCarga realizada.");
            precioTotal = cantidadPasajes * precioVuelo2;

            return true;


        }
        else if (numeroViajeUsuario == codigoVuelo3 && fechaActual <= fechaViaje && cantidadPasajes > 0)
        {
            Console.WriteLine("\nCarga realizada.");
            precioTotal = cantidadPasajes * precioVuelo3;

            return true;

        }
        else if (numeroViajeUsuario == codigoVuelo4 && fechaActual <= fechaViaje && cantidadPasajes > 0)
        {
            Console.WriteLine("\nCarga realizada.");
            precioTotal = cantidadPasajes * precioVuelo4;

            return true;


        }
        else if (numeroViajeUsuario == codigoVuelo5 && fechaActual <= fechaViaje && cantidadPasajes > 0)
        {
            Console.WriteLine("\nCarga realizada.");
            precioTotal = cantidadPasajes * precioVuelo5;

            return true;


        }
        else if (numeroViajeUsuario == codigoVuelo6 && fechaActual <= fechaViaje && cantidadPasajes > 0)
        {
            Console.WriteLine("\nCarga realizada.");
            //precioTotal = cantidadPasajes * precioVuelo5;
            precioTotal = cantidadPasajes * precioVuelo6;

            return true;
        }
        else if (cantidadPasajes == 0 || fechaActual > fechaViaje)
        {
            Console.WriteLine("No se cargo nada al carrito.");
            Console.WriteLine("Revise la cantidad de pasajes o la fecha del viaje.");
            return false;


        }
        else
        {
            return false;
        }

        Thread.Sleep(3000);
    }

    static bool PagarVuelo(bool agregoCarritoVuelo)
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
            Console.WriteLine("\nSu compra ha sido confirmada.");
            Thread.Sleep(1500);
            return true;

        }
        else
        {
            Console.WriteLine("\nEl carrito ha sido vaciado.");
            Thread.Sleep(1500);
            return false;
        }
        Thread.Sleep(1500);
    }

    static bool Registro(bool registro)
    {
        Console.Clear();
        Console.CursorVisible = true;

        Console.Write("Ingrese su nombre completo: ");
        nombreCompleto = Console.ReadLine();
        Console.Write("\nIngrese su telefóno: ");
        telefono = Console.ReadLine();
        while (DocumentoValido == false)
        {
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

        while (correoElectronicoValido == false)
        {
            Console.Write("\nIngrese su correo electronico: ");
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

    static bool InicioDeSesión(bool sesiónIniciada)
    {
        Console.Clear();
        Console.CursorVisible = true;

        while (sesiónIniciada == false && contadorIntentos > 0)
        {
            Console.Write("Ingrese el nombre de usuario registrado: ");
            string nombreUsuarioRegistrado = Console.ReadLine();


            if (nombreUsuario != nombreUsuarioRegistrado)
            {
                contadorIntentos--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nEl usuario que ingresó es incorrecto o no existe. Le quedan {contadorIntentos} intentos.");
                Console.ForegroundColor = colorOriginalLetra;

                if (contadorIntentos == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Se quedó sin intentos. Inténtelo de nuevo más tarde.");
                    Console.ForegroundColor = colorOriginalLetra;
                    return false;
                }



                continue;
            }

            Console.Write("\nIngrese la contraseña: ");
            string contraseñaRegistrada = Console.ReadLine();


            if (contraseña != contraseñaRegistrada)
            {
                contadorIntentos--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nLa contraseña es incorrecta. Le quedan {contadorIntentos} intentos. Ingrese los datos nuevamente.");
                Console.ForegroundColor = colorOriginalLetra;

                if (contadorIntentos == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Se quedó sin intentos. Inténtelo de nuevo más tarde.");
                    Console.ForegroundColor = colorOriginalLetra;
                    return false;
                }


                continue;
            }

            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nInicio de sesion exitoso!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(1000);
            
            return true;
        }

        return false;
    }
    static void BorrarDatos()
    {
        Console.Clear();
        Console.CursorVisible = true;

        Console.Write("\nEsta seguro de querer borrar sus datos? (S/N): ");
        string datosBorrar = Console.ReadLine().ToLower();

        if (datosBorrar == "s")
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
        else
        {
            Console.WriteLine("\nNo se borraran sus datos.");
            Thread.Sleep(1000);
        }

        

        
        
    }




}