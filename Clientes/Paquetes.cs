﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_de_proyectos
{
    public class Paquetes 
    {
        public Paquetes()
        {

        }

        public string Nombre;
        public double precio, impuestos;
        public int Cant_dias;
        public DateTime Fecha_Viaje;
        public bool Vigencia; //existencia del paquete
        public int CuotasContadas;
        public double Cotizacion_Dolar;
        public bool visa;
        public int IDpaquetes;
        public string Lugares;

        


        //Paquetes Nacionales
        public Paquetes(string Nombre, double precio, double impuestos, int Cant_dias, DateTime Fecha_Viaje, bool Vigencia, int CuotasContadas)
        {
            this.Nombre = Nombre;
            this.precio = precio;
            this.impuestos = impuestos;
            this.Cant_dias = Cant_dias;
            this.Fecha_Viaje = Fecha_Viaje;
            this.Vigencia = Vigencia;
            this.CuotasContadas = CuotasContadas;
            IDpaquetes++;
        }

        //Paquete Internacionales   cot dolar y visa
        public Paquetes(string Nombre, double precio, double impuestos, int Cant_dias, DateTime Fecha_Viaje, bool Vigencia, int CuotasContadas, double Cotizacion_Dolar, bool visa)
        {
            this.Nombre = Nombre;
            this.precio = precio;
            this.impuestos = impuestos;
            this.Cant_dias = Cant_dias;
            this.Fecha_Viaje = Fecha_Viaje;
            this.Vigencia = Vigencia;
            this.CuotasContadas = CuotasContadas;
            this.Cotizacion_Dolar = Cotizacion_Dolar;
            this.visa = visa;
            IDpaquetes++;
        }
        public void Destinos()
        {
            ConsoleKeyInfo opcion;
            bool loopBoolean = true;
                    
            int orden = 0;

            List<string> Destinos = new List<string>();

            #region Destinos por defecto
            Destinos.Add("Argentina");
            Destinos.Add("Brasil");
            Destinos.Add("USA");
            Destinos.Add("Peru");
            Destinos.Add("Portugal");
            Destinos.Add("Chile");
            Destinos.Add("Japon");
            Destinos.Add("Uruguay");
            Destinos.Add("Australia");
            Destinos.Add("China");
            #endregion

            while(loopBoolean = true) 
            {

                Console.WriteLine("Seleccione su Destino");
                foreach (string Pais in Destinos)
                {
                    orden++;
                    Console.WriteLine("  ***" + orden + " - " + Pais + "***");
                }

                Console.WriteLine("¿Desea Seleccionar o agregar un país nuevo?");
                Console.WriteLine("[1] --> Continuar");
                Console.WriteLine("[2] --> Agregar un destino nuevo");
                Console.WriteLine(" ");

                do
                {
                    opcion = Console.ReadKey(true);
                } while (opcion.KeyChar < '1' || opcion.KeyChar > '2');
                switch (opcion.KeyChar)
                {
                    case '1':
                        break;

                    case '2':
                        Console.WriteLine("Ingrese el nombre de su destino nuevo");
                        Destinos.Add(Console.ReadLine());

                        break;
                }



            }
            

        }

        public void MostrarPaquetesNac()
        {
            Console.WriteLine("********* PAQUETE ********* ");
            Console.WriteLine("Fecha y hora de inicio de viaje: " + Fecha_Viaje);
            Console.WriteLine("Valor del Paquete : " + precio + "$");
            Console.WriteLine("Impuesto Aplicado: " + impuestos + "%");
            Console.WriteLine("Duracion del Paquete : " + Cant_dias + " dias");
            if (Vigencia == true)
                Console.WriteLine("El paquete se encuentra Vigente");
            if (Vigencia == false)
                Console.WriteLine("El paquete esta Vencido");
            if (CuotasContadas == 1)
                Console.WriteLine("El Paquete se paga al contado");
            else if (CuotasContadas == 3)
                Console.WriteLine("El Paquete se financia en 3 cuotas");
            else if (CuotasContadas == 6)
                Console.WriteLine("El Paquete se financia en 6 cuotas");
            else if (CuotasContadas == 12)
                Console.WriteLine("El Paquete se financia en 12 cuotas");

        }
        public void MostrarPaquetesInterNac()
        {
            Console.WriteLine("********* PAQUETE ********* ");
            Console.WriteLine("Fecha y hora: " + Fecha_Viaje);
            Console.WriteLine("Precio: " + precio);
            Console.WriteLine("impuestos: " + impuestos + "%");
            Console.WriteLine("Cantidad de Dias: " + Cant_dias);
            Console.WriteLine("Vigencia: " + Vigencia);
            Console.WriteLine("Cantidad de cuotas: " + CuotasContadas);
            Console.WriteLine("Cotizacion del Dolar: " + Cotizacion_Dolar);
            Console.WriteLine("Requiere visa: " + visa);
        }

        
    }
}
