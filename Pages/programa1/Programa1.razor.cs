using System.Text.RegularExpressions;

namespace tarea2.Pages.programa1
{
    public partial class Programa1
    {
        public string Content { get; set; }
        public Result Result { get; set; }

        public void Count()
        {
            // Almaceno las ocurrencias usando expresiones regulares
            var espacios = Regex.Matches(Content, "([ ])", RegexOptions.IgnoreCase);
            var vocales = Regex.Matches(Content, "([aeiouáéíóú])", RegexOptions.IgnoreCase);
            var consonantes = Regex.Matches(Content, "([b-df-hj-nñp-tv-z])", RegexOptions.IgnoreCase);

            Result = new Result
            {
                Vocales = vocales.Count,
                Consonantes = consonantes.Count,
                Espacios = espacios.Count
            };
        }

    }
}