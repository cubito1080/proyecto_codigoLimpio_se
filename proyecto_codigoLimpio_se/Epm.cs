using ProyectoAula1_EmanuelGallego_SaraPineda;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_codigoLimpio_se
{
    internal class Epm
    {
        private double valor_kilovatio;
        private double valor_mt3;
        private List<Usuario> DatosDeUsuario = new();

        public List<Usuario> DatosDeUsuarios { get => DatosDeUsuario; set => DatosDeUsuario = value; }
        
        public Epm()
        {
            this.valor_kilovatio = 80;
            this.valor_mt3 = 4600;
        }

        public void AgregarCliente(Usuario usuario)
        {
            DatosDeUsuario.Add(usuario);
        }

        public double CalcularValorParcialEnergia(double kilovatios_consumidos)
        {
            double valor_parcial_energia = kilovatios_consumidos * valor_kilovatio;
            return valor_parcial_energia;
        }

        public double CalcularValorIncentivoEnergia(double meta_energia, double kilovatios_consumidos)
        {
            double valor_incentivo = (meta_energia - kilovatios_consumidos) * valor_kilovatio;
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
            double valor_parcial_agua = mt3_consumidos * valor_mt3;
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

        public double CacularPromedioConsumoDeEnergia(Usuario usuario)
        {
            double sumatoria = 0;

            for (int i = 0; i < DatosDeUsuario.Count; i++)
            {
                sumatoria = sumatoria + DatosDeUsuario[i].ConsumoEnergia1;
            }

            double promedio = sumatoria / DatosDeUsuario.Count;
            return promedio;
        }

        
        }

    }
}
