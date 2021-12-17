﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_de_proyectos;


namespace TP_FINAL___Grupo_8___Neoris_x_UTN
{
    class Program
    {
       

        #region CONSIGNA:
        // -----Empresa de Viajes------
        //Una empresa de viajes quiere registrar las ventas de los paquetes a sus clientes.Dicha empresa suele
        //realizar bonificaciones en función del importe acumulado por las ventas de sus clientes.
        //Dicho software debe administrar:
        //●	Cliente: Debe contener mínimamente nacionalidad, provincia, dirección y teléfono de contacto.Existen clientes particulares que tendrán dni, apellido y nombre, y corporativo que ademas del apellido, nombre y dni del viajante tiene cuit y razón social de la empresa
        //●	Paquetes vendidos: Hay 2 tipos de paquetes: Nacionales, internacionales, Los paquetes internacionales tienen cotización del dolar y una marca indicando si se requiere visa.Ambos tipos de paquetes tienen nombre, precio, lista de lugares (entre 1 y 10), cantidad de días, fecha de viaje, si esta vigente o vencido.Los nacionales tienen impuestos en %, los internacionales en valor fijo.Los nacionales se venden contado y hasta 12 cuotas, los internacionales hasta 6 cuotas.Los paquetes pueden estar activos o inactivos porque ya vencieron.
        //●	Facturación: El sistema tiene registro de las facturas de sus clientes. 
        //Especificaciones de diseño:
        //La empresa conoce todas las facturas realizadas, sus clientes y los paquetes.Cada paquete “conoce” la lista de lugares que se visitan.Cada factura tiene una referencia al cliente al que se le factura.
        //Realizar un sistema que permita:
        // 1.Crear un nuevo cliente validando todos los datos de ingreso.
        // 2.Listar todas las facturas de un cliente y el total de sus ventas
        // 3.Inactivar un paquete.
        // 4.Actualizar el precio de un paquete.
        // 5.Listar los clientes que han tenido al menos dos ventas.
        // Todo lo que puedan/quieran agregar sobre ésto será bienvenido.
        #endregion

        static void Main(string[] args)
        {
            ConsoleKeyInfo opcion;
            
            

            string nombreCliente, apellido, telefono, nacionalidad, provincia, direccion, razon_social, cuit;
            int DNI;
            string nombrePaquete, lugares;
            bool vigencia, visa;
            double precio, impuestos, Cotizacion_Dolar;
            int Cant_dias, CuotasContadas;
            DateTime Fecha_Viaje;

            Clientes c;
            Paquetes p;

            List<Paquetes> lPaquetesNac  = new List<Paquetes>();
            List<Paquetes> lPaquetesInterNac = new List<Paquetes>();

            List<Clientes> lclientes_ConsFinal = new List<Clientes>();
            List<Clientes> lclientes_Corporativos = new List<Clientes>();

            do
            {

                Introduccion();

                do
                {
                    opcion = Console.ReadKey(true);
                } while (((int)opcion.KeyChar != 27) && opcion.KeyChar < '1' || opcion.KeyChar > '4');  //Si el usuario Presiona ESC, saldra del programa
                switch (opcion.KeyChar)
                {
                    //falta vinculo con la factura (ID)
                    #region caso_Clientes
                    case '1':

                        Console.WriteLine("*** ¡Agregue un cliente nuevo! ***");
                        Console.WriteLine(" ");
                        Console.WriteLine("Indicar tipo de Cliente");
                        Console.WriteLine("[1] --> Cliente de Consumidor Final");
                        Console.WriteLine("[2] --> Cliente Corporativo");
                        Console.WriteLine("[0] --> Regresar al Menu");
                        do
                        {
                            opcion = Console.ReadKey(true);
                        } while (opcion.KeyChar < '0' || opcion.KeyChar > '2');
                        switch (opcion.KeyChar) 
                        {
                            case '0':
                                Console.WriteLine(" ");
                                Console.WriteLine("Regresando al Menu... ");
                                Console.WriteLine(" ");
                                break;

                            case '1':

                                Ingreso_data_clientes();
                                Clientes NewClienteConsFinal = new Clientes(nombreCliente, apellido, DNI, telefono,  nacionalidad,  provincia,  direccion);
                                lclientes_ConsFinal.Add(NewClienteConsFinal);
                                Console.WriteLine("------DATOS INGRESADOS------");
                                NewClienteConsFinal.MostrarClientesConsFinal();
                                Console.WriteLine(" ");
                                break;

                            case '2':

                                Ingreso_data_clientes();
                                #region Datos Clientes Corporativos
                                Console.WriteLine("Ingrese su razon social ");
                                razon_social = Console.ReadLine();
                                Console.WriteLine("Ingrese su CUIT");
                                cuit = Console.ReadLine();
                                #endregion
                                Console.WriteLine(" ");
                                Clientes NewClientecorp = new Clientes(nombreCliente, apellido,  DNI,  telefono,  nacionalidad,  provincia,  direccion, razon_social, cuit);
                                lclientes_Corporativos.Add(NewClientecorp);
                                Console.WriteLine("------DATOS INGRESADOS------");
                                NewClientecorp.MostrarClientesCorp();
                                Console.WriteLine(" ");
                                break;
                        }

                        
                        break;
                    #endregion      


                    //falta determinar los BOOL y tambien el vinculo con la factura (ID)
                    #region caso_Paquetes
                    case '2':
                        Console.WriteLine("*** ¡Agregue un paquete nuevo! ***");
                        Console.WriteLine(" ");
                        Console.WriteLine("Indicar tipo de paquete");
                        Console.WriteLine("[1] --> Paquete Nacional");
                        Console.WriteLine("[2] --> Paquete Internacional");
                        Console.WriteLine("[0] --> Regresar al Menu");

                        do
                        {
                            opcion = Console.ReadKey(true);
                        } while (opcion.KeyChar < '0' || opcion.KeyChar > '2');
                        switch (opcion.KeyChar)
                        {
                            case '0':
                                Console.WriteLine(" ");
                                Console.WriteLine("Regresando al Menu... ");
                                Console.WriteLine(" ");
                                break;

                            case '1':

                                Ingreso_data_paquetes();
                                Paquetes PaqueteNac = new Paquetes(nombrePaquete, precio, impuestos, Cant_dias, Fecha_Viaje, vigencia, CuotasContadas);
                                PaqueteNac.Destinos();
                                lPaquetesNac.Add(PaqueteNac);
                                Console.WriteLine("------DATOS INGRESADOS------");
                                PaqueteNac.MostrarPaquetesNac();
                                Console.WriteLine(" ");
                                break;

                            case '2':

                                Ingreso_data_paquetes();
                                #region Datos Paquetes Internacionales
                                Console.WriteLine("¿Es necesario VISA?");
                                visa = Convert.ToBoolean(Console.ReadLine());
                                Console.WriteLine("Ingrese la Cotizacion del dolar");
                                Cotizacion_Dolar = Convert.ToDouble(Console.ReadLine());
                                #endregion

                                Paquetes PaqueteInterNac = new Paquetes(nombrePaquete, precio, impuestos, Cant_dias, Fecha_Viaje, vigencia, CuotasContadas, Cotizacion_Dolar, visa);
                                lPaquetesNac.Add(PaqueteInterNac);
                                Console.WriteLine("------DATOS INGRESADOS------");
                                PaqueteInterNac.MostrarPaquetesNac();
                                Console.WriteLine(" ");
                                break;
                        }

                        
                        break;
                    #endregion


                    #region caso_Asignacion_de_Paquetes
                    case '3':
                        Console.WriteLine("*** ¡Asignar Paquetes a un Cliente! ***");

                        break;
                    #endregion


                    #region caso_Ajustes
                    case '4':
                        Console.WriteLine("*** ¿Que desea Modificar? ***");
                        Console.WriteLine("[1] --> Clientes");
                        Console.WriteLine("[2] --> Paquetes");
                        Console.WriteLine("[0] --> Regresar al Menu");
                        Console.WriteLine(" ");
                        do
                        {
                            opcion = Console.ReadKey(true);
                        } while (opcion.KeyChar < '0' || opcion.KeyChar > '2');
                        switch (opcion.KeyChar)
                        {
                            case '0':
                                Console.WriteLine(" ");
                                Console.WriteLine("Regresando al Menu... ");
                                Console.WriteLine(" ");
                                
                                break;

                            case '1':
                                Console.WriteLine("***¡Editando un Cliente!*** ");
                                Console.WriteLine(" ");
                                Console.WriteLine("[1] --> Cliente Consumidor Final");
                                Console.WriteLine("[2] --> Cliente Corporativo");
                                do
                                {
                                    opcion = Console.ReadKey(true);
                                } while (opcion.KeyChar < '0' || opcion.KeyChar > '2');
                                switch (opcion.KeyChar) 
                                {
                                    case '1':
                                        Console.WriteLine(" Ingrese el DNI de su Cliente ");
                                        int.TryParse(Console.ReadLine(), out DNI);
                                        c = lclientes_ConsFinal.Find(x => x.DNI == DNI);

                                        if (c != null)
                                        {
                                            Console.WriteLine("EDITANDO CLIENTE: " + c.nombre + " " + c.apellido);
                                            Console.WriteLine("*******************");
                                            c.MostrarClientesConsFinal();
                                            Console.WriteLine("*******************");
                                            Console.WriteLine(" ");

                                            Ajustes_Seleccion();
                                            do
                                            {
                                                opcion = Console.ReadKey(true);
                                            } while (opcion.KeyChar < '1' || opcion.KeyChar > '7');

                                            Ajustes_Edicion();
                                            
                                            c.MostrarClientesConsFinal();

                                        }
                                        else { Console.WriteLine("el DNI que ingreso no pertenece a un Cliente de Consumidor Final existente :("); }

                                            break;

                                    case '2':

                                        Console.WriteLine(" Ingrese el DNI de su Cliente ");
                                        int.TryParse(Console.ReadLine(), out DNI);
                                        c = lclientes_Corporativos.Find(x => x.DNI == DNI);

                                        if (c != null)
                                        {
                                            Console.WriteLine("EDITANDO CLIENTE: " + c.nombre + " " + c.apellido);
                                            Console.WriteLine("*******************");
                                            c.MostrarClientesConsFinal();
                                            Console.WriteLine("*******************");
                                            Console.WriteLine(" ");

                                            Ajustes_Seleccion();
                                            #region Seleccion datos Corp
                                            Console.WriteLine("[8] --> razon social: " + c.razon_social);
                                            Console.WriteLine("[9] --> cuit: " + c.cuit);
                                            #endregion

                                            do
                                            {
                                                opcion = Console.ReadKey(true);
                                            } while (opcion.KeyChar < '1' || opcion.KeyChar > '9');

                                            Ajustes_Edicion();

                                            c.MostrarClientesCorp();

                                        }
                                        else { Console.WriteLine("el DNI que ingreso no pertenece a un Cliente Corporativo existente :("); }



                                        break;
                                }




                                break;

                            case '2':
                                Console.WriteLine("***¡Editar un Paquete! ");
                                break;
                        }



                        break;
                    #endregion

                    #region caso_Factura
                    case '5':
                        Console.WriteLine("*** ¡Ver Facturas de Clientes! ***");
                        break;
                        #endregion
                }


            } while ((int)opcion.KeyChar != 27);

            void Introduccion()
            {
                Console.WriteLine(" ");
                Console.WriteLine("*****¡Bienvenidos a Epico-Aerolineas! ******");
                Console.WriteLine(" ");
                Console.WriteLine("1 - Agregar Clientes");
                Console.WriteLine("2 - Agregar Paquetes");
                Console.WriteLine("3 - Asignar Paquetes a un Cliente");
                Console.WriteLine("4 - Ajustes");
                Console.WriteLine("5 - Ver Factura");
                Console.WriteLine("ESC - Salir");
                Console.WriteLine(" ");
            }

            void Ingreso_data_clientes() 
            {
                Console.WriteLine("Indique su Nombre ");
                nombreCliente = Console.ReadLine();
                Console.WriteLine("Indique su Apellido ");
                apellido = Console.ReadLine();
                Console.WriteLine("Indique su DNI");
                int.TryParse(Console.ReadLine(), out DNI);
                Console.WriteLine("Indique su Telefono ");
                telefono = Console.ReadLine();
                Console.WriteLine("Indique su Nacionalidad");
                nacionalidad = Console.ReadLine();
                Console.WriteLine("Indique su Provincia ");
                provincia = Console.ReadLine();
                Console.WriteLine("Indique su direccion");
                direccion = Console.ReadLine();
            }

            void Ingreso_data_paquetes() 
            {
                Console.WriteLine("Introduzca el nombre del nuevo paquete");
                nombrePaquete = Console.ReadLine();
                Console.WriteLine("Indique su valor en pesos $");
                Double.TryParse(Console.ReadLine(), out precio);
                //precio = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("agregar impuesto a cobrar en %");
                impuestos = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("introduzca la cantidad de dias");
                Cant_dias = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Indique la fecha del viaje");
                Fecha_Viaje = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Indique si se encuentra vigente el nombre");
                vigencia = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("Indique la cantidad de cuotas contadas");
                CuotasContadas = Convert.ToInt32(Console.ReadLine());
            }

            void Ajustes_Seleccion() 
            {
                Console.WriteLine("**¿Que desea Editar?**");
                Console.WriteLine("[1] --> nombre: " + c.nombre);
                Console.WriteLine("[2] --> apellido: " + c.apellido);
                Console.WriteLine("[3] --> DNI: " + c.DNI);
                Console.WriteLine("[4] --> telefono: " + c.telefono);
                Console.WriteLine("[5] --> nacionalidad: " + c.nacionalidad);
                Console.WriteLine("[6] --> provincia: " + c.provincia);
                Console.WriteLine("[7] --> direccion: " + c.direccion);
            }

            void Ajustes_Edicion() 
            {
                
                switch (opcion.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Indique su Nombre ");
                        c.nombre = Console.ReadLine();
                        break;

                    case '2':
                        Console.WriteLine("Indique su Apellido ");
                        c.apellido = Console.ReadLine();
                        break;

                    case '3':
                        Console.WriteLine("Indique su DNI");
                        int.TryParse(Console.ReadLine(), out c.DNI);
                        break;

                    case '4':
                        Console.WriteLine("Indique su Telefono ");
                        c.telefono = Console.ReadLine();
                        break;

                    case '5':
                        Console.WriteLine("Indique su Nacionalidad");
                        c.nacionalidad = Console.ReadLine();
                        break;

                    case '6':
                        Console.WriteLine("Indique su Provincia ");
                        c.provincia = Console.ReadLine();
                        break;

                    case '7':
                        Console.WriteLine("Indique su direccion");
                        c.direccion = Console.ReadLine();
                        break;

                    case '8':
                        Console.WriteLine("Ingrese su razon social ");
                        c.razon_social = Console.ReadLine();
                        break;

                    case '9':
                        Console.WriteLine("Ingrese su CUIT");
                        c.cuit = Console.ReadLine();
                        break;
                }
            }

            

            





        }
    }
}
