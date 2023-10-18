using System.Text.Json;

namespace WebSite.Utils
{
    public class Deserializer
    {
        /// <summary>
        /// Deserializa el objeto json y retorna la llave solicitada
        /// </summary>
        /// <param name="Json">String json</param>
        /// <param name="key">LLave dentro del json</param>
        /// <returns>El dato dentro del json que coincide con la llave key</returns>
        public static string getData(string Json, string key)
        {
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(Json);
            var data = jsonElement.GetProperty(key).ToString();
            return data;
        }

    }
}
