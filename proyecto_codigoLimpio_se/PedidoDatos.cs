using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula1_EmanuelGallego_SaraPineda
{
    public class PedidoDeDatos
    {
        Facturacion Factura = new Facturacion();
        Interfaz ListaInterfaz = new Interfaz();

        private (int, int) ValorApagarEnergia;
        private (int, int, int) ValorApagarAgua;
        private int ValorTotalApagar;
        private int TotalConceptoDeDescuentos;
        private int Totalm3EncimaDelPromedio;
        private int ClientesGastoAguaMayorAlPromedio;
        private int PromedioConsumoDeEnergia;
        private int ConsumoDeEnergia;

        public int ConsumoEnergia { get => ConsumoDeEnergia; set => ConsumoDeEnergia = value; }
        public int PromedioConsumoEnergia { get => PromedioConsumoDeEnergia; set => PromedioConsumoDeEnergia = value; }
        public int ClientesGastoAguaMayorPromedio { get => ClientesGastoAguaMayorAlPromedio; set => ClientesGastoAguaMayorAlPromedio = value; }
        public int Totalm3EncimaPromedio { get => Totalm3EncimaDelPromedio; set => Totalm3EncimaDelPromedio = value; }
        public int TotalConceptoDescuentos { get => TotalConceptoDeDescuentos; set => TotalConceptoDeDescuentos = value; }
        public (int total, int M3EncimaPromedio, int ClienteConsumoMayorPromedio) ValorPagarAgua { get => ValorApagarAgua; set => ValorApagarAgua = value; }
        public int ValorTotalPagar { get => ValorTotalApagar; set => ValorTotalApagar = value; }
        public (int total, int TotalDescuentoClientes) ValorPagarEnergia { get => ValorApagarEnergia; set => ValorApagarEnergia = value; }

        public (int, int, int) FacturaServiciosConCedula(int CedulaCliente)
        {
            for (int i = 0; i < ListaInterfaz.DatosDeUsuarios.Count; i++)
            {
                if (ListaInterfaz.DatosDeUsuarios[i].Cedula == CedulaCliente)
                {
                    ValorPagarEnergia = Factura.ValorParaPagarEnergia(ListaInterfaz.DatosDeUsuarios[i].MetaAhorroEnergia1, ListaInterfaz.DatosDeUsuarios[i].ConsumoEnergia1);
                    ValorPagarAgua = Factura.ValorParaPagarAgua(ListaInterfaz.DatosDeUsuarios[i].ConsumoAgua1, ListaInterfaz.DatosDeUsuarios[i].PromedioConsumoAgua1);
                    ValorTotalPagar = Factura.ValorTotalPorPagar(ValorPagarEnergia.total, ValorPagarAgua.total);

                }
            }
            return (ValorTotalPagar, ValorPagarEnergia.total, ValorPagarAgua.total);

        }

        public (int, int, int, int, int) FacturaServiciosSinCedula()
        {

            for (int i = 0; i < ListaInterfaz.DatosDeUsuarios.Count; i++)
            {
                ValorPagarEnergia = Factura.ValorParaPagarEnergia(ListaInterfaz.DatosDeUsuarios[i].MetaAhorroEnergia1, ListaInterfaz.DatosDeUsuarios[i].ConsumoEnergia1);
                ValorPagarAgua = Factura.ValorParaPagarAgua(ListaInterfaz.DatosDeUsuarios[i].ConsumoAgua1, ListaInterfaz.DatosDeUsuarios[i].PromedioConsumoAgua1);

                ConsumoDeEnergia += ListaInterfaz.DatosDeUsuarios[i].ConsumoEnergia1;

                TotalConceptoDescuentos += ValorPagarEnergia.TotalDescuentoClientes;

                Totalm3EncimaPromedio += ValorPagarAgua.M3EncimaPromedio;

                ClientesGastoAguaMayorPromedio += ValorPagarAgua.ClienteConsumoMayorPromedio;

                //Hacer medidas por estrato
            }
            if (ListaInterfaz.IngresarUsuarios != 0)
            {
                PromedioConsumoEnergia = ConsumoDeEnergia / ListaInterfaz.IngresarUsuarios;
            }
            else
            {
                PromedioConsumoEnergia = 0;
            }
            return (PromedioConsumoEnergia, TotalConceptoDescuentos, Totalm3EncimaPromedio, 5, ClientesGastoAguaMayorPromedio);
        }



    }
}
