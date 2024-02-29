using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ProyectoAula1_EmanuelGallego_SaraPineda
{
    public class Interfaz
    {
        private Epm epm;

        internal Epm Epm { get => epm; set => epm = value; }

        public Interfaz() 
        { 
            this.epm = new Epm();
        }

        public static int MostrarMenu()
        {
            Console.Write("\n===============================================");
            Console.Write("\nBIENVENIDO AL MENÚ\n");
            Console.Write("===============================================\n");
            Console.Write("1. Agregar clente \n \n");
            Console.Write("2. Mirar el total de la factura de servicios \n \n");
            Console.Write("3. Mirar valor a pagar por servicios de energía \n \n");
            Console.Write("4. Mirar valor a pagar por servicos de agua \n \n");
            Console.Write("5. Mirar el promedio del consumo actual de energía \n \n");
            Console.Write("6. Mirar el valor total por concepto de descuentos a los clientes \n \n");
            Console.Write("7. Mirar la cantidad total de m3 de agua que se consumieron por encima del promedio \n \n");
            Console.Write("8. Mirar porcentajes de consumo excesivo de agua por estrato \n \n");
            Console.Write("9. Mirar cantidad de clientes que tuvieron un consumo de agua mayor al promedio \n \n");
            Console.WriteLine("Ingresa tu opción:");

            int seleccionarOpcion = Convert.ToInt32(Console.ReadLine());
            return seleccionarOpcion;
        }

        public void Consola()
        {
            
            int seleccionarOpcion = MostrarMenu();

            if ((0 > seleccionarOpcion) && (seleccionarOpcion > 9))
            {
                MostrarMenu();
            }

            if (seleccionarOpcion == 1)
            {
                Console.WriteLine("\n¿Cuántos clentes desea ingresar?:");
                int cantidad_clentes = Convert.ToInt32(Console.ReadLine());

                int cedula;
                int estrato;
                int MetaAhorroEnergia;
                int ConsumoEnergia;
                int PromedioConsumoAgua;
                int ConsumoAgua;

                for (int i = 1; i <= cantidad_clentes; i++)
                {
                    Console.WriteLine("\nIngresa la cédula del cliente {0}", i);
                    cedula = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nIngresa el estrato del cliente {0}", i);
                    estrato = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nIngresa la meta de ahorro de energía del cliente {0}", i);
                    MetaAhorroEnergia = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nIngresa el consumo de energía del cliente {0}", i);
                    ConsumoEnergia = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nIngresa el promedio en consumo actual de agua del cliente {0}", i);
                    PromedioConsumoAgua = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nIngresa el consumo actual de agua del cliente {0}", i);
                    ConsumoAgua = Convert.ToInt32(Console.ReadLine());

                    Usuario usuario = new Usuario(cedula, estrato, MetaAhorroEnergia, ConsumoEnergia, PromedioConsumoAgua, ConsumoAgua);
                    epm.AgregarCliente(usuario);
                }
            }

            if (seleccionarOpcion == 2)
            {
                Console.WriteLine("\nIngrese el ID del cliente a facturar: ");
                int cedula = Convert.ToInt32(Console.ReadLine());

                foreach (Usuario usuario in epm.DatosDeUsuarios)
                {
                    if (usuario.Cedula == cedula)
                    {
                        epm.CalcularValorTotalAPagar(usuario);
                    }
                }
            }

            if (seleccionarOpcion == 3)
            {
                Console.WriteLine("\nIngrese el ID del cliente a facturar energia: ");
                int cedula = Convert.ToInt32(Console.ReadLine());

                foreach (Usuario usuario in epm.DatosDeUsuarios)
                {
                    if (usuario.Cedula == cedula)
                    {
                        epm.CalcularValorAPagarEnergia(usuario);
                    }
                }
            }

            if (MostrarMenu() == 4)
            {
                Console.WriteLine("\nIngrese el ID del cliente a facturar: ");
                int cedula = Convert.ToInt32(Console.ReadLine());

                foreach (Usuario usuario in epm.DatosDeUsuarios)
                {
                    if (usuario.Cedula == cedula)
                    {
                        epm.CalcularValorAPagarAgua(usuario);
                    }
                }
            }

            if (seleccionarOpcion == 5)
            {
                Console.WriteLine("\nEl promedio del consum actual de energia es: {0}", epm.CacularPromedioConsumoDeEnergia());        
            }

            if (seleccionarOpcion == 6)
            {
                Console.WriteLine("\nEl valor total por concepto de descuento es: {0}", epm.CalcularTotalDescuentosPorIncentivoDeEnergia());
            }

            if (seleccionarOpcion == 7)
            {
                Console.WriteLine("\nLa cantidad de agua que se consumio por encima del promedio fue: {0}", epm.CalcularTotalM3AguaEncimaPromedio());
            }

            if (seleccionarOpcion == 8)
            {
                Console.WriteLine("\nIngrese el estrato a consultar: ");
                int estrato = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nEl porcentaje de consumo excesivo del estarto {0} de agua es: {0}", estrato, epm.ConusltarPorcentajeConsumoAguaPorEstrato(estrato));
    
            }

            if (seleccionarOpcion == 9)
            {
                Console.WriteLine("\nLa cantidad de clientes que consumio agua por encima del promedio es: {0}", epm.CalcularClientesConConsumoAguaMayorAlPromedio());
            }

        }

        public static void Main(string[] args)
        {
            Interfaz interfaz = new Interfaz();
            interfaz.Consola();
        }
        

    }

}

