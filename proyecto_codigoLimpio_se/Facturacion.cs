using System;
using System.Collections;

namespace ProyectoAula1_EmanuelGallego_SaraPineda
{
    public class Facturacion
    {
        private const int valor_kilovatio = 850;
        private const double valor_mt3 = 4.600;
        private int valor_parcial;
        private int valor_incentivo;
        private int mt3_por_encima_promedio;
        private int cliente_consumo_mayor_promedio;
        private int total_descuento_clientes;

        public static int Valor_kilovatio => valor_kilovatio;

        public static double Valor_mt3 => valor_mt3;

        public int Valor_parcial { get => valor_parcial; set => valor_parcial = value; }
        public int Valor_incentivo { get => valor_incentivo; set => valor_incentivo = value; }
        public int Mt3_por_encima_promedio { get => mt3_por_encima_promedio; set => mt3_por_encima_promedio = value; }
        public int Cliente_consumo_mayor_promedio { get => cliente_consumo_mayor_promedio; set => cliente_consumo_mayor_promedio = value; }
        public int Total_descuento_clientes { get => total_descuento_clientes; set => total_descuento_clientes = value; }

        public int ValorTotalPorPagar(int pago_energia, int pago_agua)
        {
            return pago_energia + pago_agua;
        }

        public (int, int) ValorParaPagarEnergia(int meta_energia, int consumo_energia)
        {
            Valor_parcial = consumo_energia * Valor_kilovatio;
            Valor_incentivo = (meta_energia - consumo_energia) * Valor_kilovatio;


            if (Valor_incentivo > 0)
            {
                Total_descuento_clientes = Valor_incentivo;
            }
            else
            {
                Total_descuento_clientes = 0;
            }
            return (Valor_parcial - Valor_incentivo, Total_descuento_clientes);
        }

        public (int, int, int) ValorParaPagarAgua(int consumo_agua, int promedio_agua)
        {
            if (consumo_agua >= promedio_agua)
            {
                Valor_parcial = Convert.ToInt32(promedio_agua * Valor_mt3);
                Valor_incentivo = (consumo_agua - promedio_agua) * (2 * Valor_kilovatio);
                Mt3_por_encima_promedio = (consumo_agua - promedio_agua);
                Cliente_consumo_mayor_promedio = 1;
            }
            else
            {
                Valor_parcial = Convert.ToInt32(consumo_agua * Valor_mt3);
            }

            return (Valor_parcial + Valor_incentivo, Mt3_por_encima_promedio, Cliente_consumo_mayor_promedio);
        }
    }

}