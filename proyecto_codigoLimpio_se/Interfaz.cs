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
        private int IngresarUsuario;
        private int SeleccionarLaOpcion;
        private int CedulaDelCliente;
        private (double total, double energia, double agua) TotalFacturaServicio;
        private (double total, double energia, double agua) ValorApagarPorServiciosDeEnergia;
        private (double total, double energia, double agua) ValorApagarPorServiciosDeAgua;
        private (int promedio_energia, double concepto_descuentos, int m3_encima_promedio, int estrato, int clientes_gasto_agua_mayor_promedio) FacturaServiciosSinCedula;
        private int IngresaOpcion;
        private List<Usuario> DatosDeUsuario = new();

        public List<Usuario> DatosDeUsuarios { get => DatosDeUsuario; set => DatosDeUsuario = value; }
        public int OpcionIngresada { get => IngresaOpcion; set => IngresaOpcion = value; }
        public (int promedio_energia, double concepto_descuentos, int m3_encima_promedio, int estrato, int clientes_gasto_agua_mayor_promedio) FacturaServicioSinCedula { get => FacturaServiciosSinCedula; set => FacturaServiciosSinCedula = value; }
        public (double total, double energia, double agua) ValorApagarServiciosAgua { get => ValorApagarPorServiciosDeAgua; set => ValorApagarPorServiciosDeAgua = value; }
        public (double total, double energia, double agua) ValorApagarServiciosEnergia { get => ValorApagarPorServiciosDeEnergia; set => ValorApagarPorServiciosDeEnergia = value; }
        public (double total, double energia, double agua) TotalFacturaServicios { get => TotalFacturaServicio; set => TotalFacturaServicio = value; }
        public int CedulaCliente { get => CedulaDelCliente; set => CedulaDelCliente = value; }
        public int SeleccionarOpcion { get => SeleccionarLaOpcion; set => SeleccionarLaOpcion = value; }
        public int IngresarUsuarios { get => IngresarUsuario; set => IngresarUsuario = value; }

        public void Bienvenida()
        {
            Console.Write("=============================================================\n");
            Console.Write("\nBienvenido al portal de ingreso de usuarios.\n");
            Console.Write("\n=============================================================\n");

            Console.WriteLine("\n¿Cuántos usuarios desea ingresar?:");
            IngresarUsuarios = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= IngresarUsuarios; i++)
            {
                Console.WriteLine("\nIngresa la cédula del cliente {0}", i);
                int cedula = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nIngresa el estrato del cliente {0}", i);
                int estrato = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nIngresa la meta de ahorro de energía del cliente {0}", i);
                int MetaAhorroEnergia = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nIngresa el consumo de energía del cliente {0}", i);
                int ConsumoEnergia = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nIngresa el promedio en consumo actual de agua del cliente {0}", i);
                int PromedioConsumoAgua = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nIngresa el consumo actual de agua del cliente {0}", i);
                int ConsumoAgua = Convert.ToInt32(Console.ReadLine());

                Usuario usuario = new Usuario(cedula, estrato, MetaAhorroEnergia, ConsumoEnergia, PromedioConsumoAgua, ConsumoAgua);
                DatosDeUsuarios.Add(usuario);
            }

            MostrarMenu();
        }

        public void MostrarMenu()
        {
            Console.Write("\n===============================================");
            Console.Write("\nBienvenido al menú\n");
            Console.Write("===============================================\n");
            Console.Write("1. Mirar el total de la factura de servicios \n \n");
            Console.Write("2. Mirar valor a pagar por servicios de energía \n \n");
            Console.Write("3. Mirar valor a pagar por servicos de agua \n \n");
            Console.Write("4. Mirar el promedio del consumo actual de energía \n \n");
            Console.Write("5. Mirar el valor total por concepto de descuentos a los clientes \n \n");
            Console.Write("6. Mirar la cantidad total de m3 de agua que se consumieron por encima del promedio \n \n");
            Console.Write("7. Mirar porcentajes de consumo excesivo de agua por estrato \n \n"); // Me falta
            Console.Write("8. Mirar cantidad de clientes que tuvieron un consumo de agua mayor al promedio \n \n");
            Console.Write("9. Salir. \n \n");
            Console.WriteLine("Ingresa tu opción:");

            SeleccionarOpcion = Convert.ToInt32(Console.ReadLine());

            PedidoDeDatos DatosPedidos = new PedidoDeDatos();

            if (0 < SeleccionarOpcion && SeleccionarOpcion < 4)
            {
                Console.WriteLine("\nIngresa la cédula del cliente:");
                CedulaCliente = Convert.ToInt32(Console.ReadLine());

                if (SeleccionarOpcion == 1)
                {
                    TotalFacturaServicios = DatosPedidos.FacturaServiciosConCedula(CedulaCliente);

                    Console.Write("\n\n El total a pagar por la factura de servicios del cliente con cédula {0}, es: {1} \n \n", CedulaCliente, TotalFacturaServicios.total);
                }
                else if (SeleccionarOpcion == 2)
                {
                    ValorApagarServiciosEnergia = DatosPedidos.FacturaServiciosConCedula(CedulaCliente);

                    Console.Write("\n\n El valor a pagar por los servicios de energía del cliente con cédula {0}, es: {1} \n\n", CedulaCliente, ValorApagarServiciosEnergia.energia);
                }
                else if (SeleccionarOpcion == 3)
                {
                    ValorApagarServiciosAgua = DatosPedidos.FacturaServiciosConCedula(CedulaCliente);

                    Console.Write("\n\n El valor a pagar por los servicios de agua del cliente con cédula {0}, es: {1}", CedulaCliente, ValorApagarServiciosAgua.agua);
                }

            }

            else if (3 < SeleccionarOpcion && SeleccionarOpcion < 10)
            {
                FacturaServicioSinCedula = DatosPedidos.FacturaServiciosSinCedula();

                if (SeleccionarOpcion == 4)
                {
                    Console.Write("\n\n El promedio actual de gasto energía de los clientes es: {0} \n\n", FacturaServicioSinCedula.promedio_energia);
                }
                else if (SeleccionarOpcion == 5)
                {
                    Console.Write("\n\n El total por concepto de descuentos a los clientes es: {0}", FacturaServicioSinCedula.concepto_descuentos);
                }
                else if (SeleccionarOpcion == 6)
                {
                    Console.Write("\n\n La cantidad de m3 de agua por encima del promedio es: {0}", FacturaServicioSinCedula.m3_encima_promedio);
                }
                else if (SeleccionarOpcion == 7)
                {
                    Console.Write("\n\n El estrato es: {0}", FacturaServicioSinCedula.estrato);
                }
                else if (SeleccionarOpcion == 8)
                {
                    Console.Write("\n\n Cantidad de clientes que gastaron agua por encima del promedio: {0}", FacturaServicioSinCedula.clientes_gasto_agua_mayor_promedio);
                }
                else
                {
                    Console.Write("\n\n Fue un gusto servirte.");
                    Console.ReadKey();
                }
            }

            else
            {
                Console.Write("\n\n Ingresa una opción válida.");
                MostrarMenu();
            }

            MostrarMenuDeNuevo();

        }
        public void MostrarMenuDeNuevo()
        {
            Console.Write("\n\n1. Volver al menú. \n");
            Console.Write("0. Salir. \n \n");
            Console.WriteLine("Ingresa una opción: ");
            OpcionIngresada = Convert.ToInt32(Console.ReadLine());

            if (OpcionIngresada == 1)
            {
                MostrarMenu();
            }
            else if (OpcionIngresada == 0)
            {
                Console.Write("\n\n Fue un gusto prestarte nuestros servicios.\n");
                Console.Write("\nHasta pronto.");
                Console.ReadKey();
            }
            else
            {
                Console.Write("\nIngresa una opción válida.");
                MostrarMenuDeNuevo();
            }

        }


    }
}

