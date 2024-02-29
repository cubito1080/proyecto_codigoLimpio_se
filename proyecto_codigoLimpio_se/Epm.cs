using ProyectoAula1_EmanuelGallego_SaraPineda;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula1_EmanuelGallego_SaraPineda
{
    internal class Epm
    {
        private double valor_kilovatio;
        private double valor_mt3;
        private List<Usuario> DatosDeUsuario;

        public List<Usuario> DatosDeUsuarios { get => DatosDeUsuario; set => DatosDeUsuario = value; }
        public double Valor_kilovatio { get => valor_kilovatio; set => valor_kilovatio = value; }
        public double Valor_mt3 { get => valor_mt3; set => valor_mt3 = value; }

        public Epm()
        {
            this.Valor_kilovatio = 80;
            this.Valor_mt3 = 4600;
            this.DatosDeUsuario = new List<Usuario>();
        }

        public void AgregarCliente(Usuario usuario)
        {
            DatosDeUsuario.Add(usuario);
        }

        public double CalcularValorParcialEnergia(double kilovatios_consumidos)
        {
            double valor_parcial_energia = kilovatios_consumidos * Valor_kilovatio;
            return valor_parcial_energia;
        }

        public double CalcularValorIncentivoEnergia(double meta_energia, double kilovatios_consumidos)
        {
            double valor_incentivo = (meta_energia - kilovatios_consumidos) * Valor_kilovatio;
            return valor_incentivo;
        }

        public double CalcularValorAPagarEnergia(Usuario usuario)
        {
            double valor_parcial = CalcularValorParcialEnergia(usuario.ConsumoEnergia1);
            double valor_incentivo = CalcularValorIncentivoEnergia(usuario.MetaAhorroEnergia1, usuario.ConsumoEnergia1);

            double valor_total_a_pagar = valor_parcial - valor_incentivo;
            return valor_total_a_pagar;
        }

        public double CalcularValorParcialAgua(double mt3_consumidos)
        {
            double valor_parcial_agua = mt3_consumidos * Valor_mt3;
            return valor_parcial_agua;
        }

        public double CalcularValorExcesoAgua(double mt3_consumidos, double promedio_consumo_agua)
        {
            double valor_exceso_agua = (mt3_consumidos - promedio_consumo_agua) * (2 * 4600);
            return valor_exceso_agua;
        }

        public double CalcularValorAPagarAgua(Usuario usuario)
        {
            double valor_parcial = CalcularValorParcialAgua(usuario.ConsumoAgua1);
            double valor_exceso = CalcularValorExcesoAgua(usuario.ConsumoAgua1, usuario.PromedioConsumoAgua1);

            double valor_total_a_pagar = valor_parcial + valor_exceso;
            return valor_total_a_pagar;
        }

        public double CalcularValorTotalAPagar(Usuario usuario)
        {
            double valor_total = CalcularValorAPagarEnergia(usuario) + CalcularValorAPagarAgua(usuario);
            return valor_total;
        }

        public double CacularPromedioConsumoDeEnergia()
        {
            double sumatoria = 0;

            for (int i = 0; i < DatosDeUsuario.Count; i++)
            {
                sumatoria = sumatoria + DatosDeUsuario[i].ConsumoEnergia1;
            }

            double promedio = sumatoria / DatosDeUsuario.Count;
            return promedio;
        }

        public double CalcularTotalDescuentosPorIncentivoDeEnergia()
        {
            double descuento_total_incentivo = 0;
            foreach (Usuario usuario in DatosDeUsuario)
            {
                if (usuario.MetaAhorroEnergia1 > usuario.ConsumoEnergia1)
                {
                    descuento_total_incentivo += CalcularValorIncentivoEnergia(usuario.MetaAhorroEnergia1, usuario.ConsumoEnergia1);
                }

            }

            return descuento_total_incentivo;
        }

        public double CalcularTotalM3AguaEncimaPromedio()
        {
            double m3_agua_encima_promedio = 0;

            foreach (Usuario usuario in DatosDeUsuario)
            {
                if (usuario.ConsumoAgua1 > usuario.PromedioConsumoAgua1)
                {
                    m3_agua_encima_promedio += usuario.ConsumoAgua1 - usuario.PromedioConsumoAgua1;
                }

            }
            return m3_agua_encima_promedio;
        }

        public double CalcularClientesConConsumoAguaMayorAlPromedio()
        {
            double clientes_consumo_agua_encima_promedio = 0;

            foreach (Usuario usuario in DatosDeUsuario)
            {
                if (usuario.ConsumoAgua1 > usuario.PromedioConsumoAgua1)
                {
                    clientes_consumo_agua_encima_promedio += 1;
                }

            }
            return clientes_consumo_agua_encima_promedio;
        }

        public double ConusltarPorcentajeConsumoAguaPorEstrato(int estrato)
        {
            double suma_total_exceso_agua_ = CalcularTotalM3AguaEncimaPromedio();
            double suma_exceso_agua_por_estrato = 0;

            foreach (Usuario usuario in DatosDeUsuario)
            {
                if (usuario.Estrato == estrato)
                {
                    suma_exceso_agua_por_estrato += CalcularValorExcesoAgua(usuario.ConsumoAgua1, usuario.PromedioConsumoAgua1);
                }

            }

            return (suma_total_exceso_agua_ / suma_exceso_agua_por_estrato) * 100;
        }


    }

 
}
