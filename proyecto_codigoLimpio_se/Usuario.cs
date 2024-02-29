using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace ProyectoAula1_EmanuelGallego_SaraPineda
{
    public class Usuario
    {
        private int cedula;
        private int estrato;
        private int MetaAhorroEnergia;
        private int ConsumoEnergia;
        private int PromedioConsumoAgua;
        private int ConsumoAgua;

        public int Cedula { get => cedula; set => cedula = value; }
        public int Estrato { get => estrato; set => estrato = value; }
        public int MetaAhorroEnergia1 { get => MetaAhorroEnergia; set => MetaAhorroEnergia = value; }
        public int ConsumoEnergia1 { get => ConsumoEnergia; set => ConsumoEnergia = value; }
        public int PromedioConsumoAgua1 { get => PromedioConsumoAgua; set => PromedioConsumoAgua = value; }
        public int ConsumoAgua1 { get => ConsumoAgua; set => ConsumoAgua = value; }

        public Usuario(int cedula, int estrato, int MetaAhorroEnergia, int ConsumoEnergia, int PromedioConsumoAgua, int ConsumoAgua)
        {
            this.Cedula = cedula;
            this.Estrato = estrato;
            this.MetaAhorroEnergia1 = MetaAhorroEnergia;
            this.ConsumoEnergia1 = ConsumoEnergia;
            this.PromedioConsumoAgua1 = PromedioConsumoAgua;
            this.ConsumoAgua1 = ConsumoAgua;
        }

        public static void Main()
        {
            Interfaz NuevaInterfaz = new Interfaz();
            NuevaInterfaz.Bienvenida();
        }
    }
}

