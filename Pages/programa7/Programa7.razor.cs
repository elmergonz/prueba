using System;

namespace tarea2.Pages.programa7
{
    public partial class Programa7
    {
        public int Nota { get; set; }

        public string Letra { get; set; }

        public int[] Prop { get; set; }

        public void Literal()
        {
            if (Nota >= 90 && Nota <= 100)
            {
                Letra = "A";
            }
            else if (Nota >= 80)
            {
                Letra = "B";
            }
            else if (Nota >= 70)
            {
                Letra = "C";
            }
            else if (Nota >= 0)
            {
                Letra = "F";
            }
            Letra = "Nota invalida";
        }

        public void Proporcion()
        {
            int prop40 = (int) Math.Round(Nota * 0.4);
            int prop30_1 = (int) Math.Round((Nota - prop40) * 0.5);
            int prop30_2 = Nota - prop40 - prop30_1;

            while ((prop40 + prop30_1 + prop30_2) > Nota)
            {
                prop30_1--;
            }

            Prop = new int[] {prop40, prop30_1, prop30_2};
        }
    
        public void DoStuff()
        {
            Literal();
            Proporcion();
        }
    }
}