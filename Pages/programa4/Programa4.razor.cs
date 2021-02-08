using System.Linq;

namespace tarea2.Pages.programa4
{
    public partial class Programa4
    {
        public float[] Lados { get; set; } = new float[3];
        public string Tipo { get; set; }

        public void GetTipo()
        {
            if ((Lados[0] + Lados[1]) <= Lados[2] ||
                (Lados[2] + Lados[0]) <= Lados[1] ||
                (Lados[2] + Lados[1]) <= Lados[0] ||
                Lados.Sum() <= 0)
            {
                Tipo = "Los lados ingresados no corresponden a un triangulo";
                return;
            }

            int ladosIguales = 0;

            for (int i = 0; i < Lados.Length; i++)
            {
                if (Lados[i] == Lados[(i + 1) % Lados.Length])
                    ladosIguales++;
            }

            switch (ladosIguales)
            {
                case 0:
                    Tipo = "Escaleno";
                    break;
                
                case 1:
                    Tipo = "Isosceles";
                    break;

                case 2:
                case 3:
                    Tipo = "Equilatero";
                    break;

                default:
                    Tipo = "\nError al obtener tipo";
                    break;
            }
        }
    }
}