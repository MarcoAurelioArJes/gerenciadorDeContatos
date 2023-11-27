using System.Text.Json;

namespace GerenciadorDeContatos.API.Services
{
    public static class SerializerService
    {
        public static string ObterStringDoJsonSerializado<T>(this T obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static T ObterJsonDesserializado<T>(this string jsonSerializado)
        {
            return JsonSerializer.Deserialize<T>(jsonSerializado);
        }
    }
}
