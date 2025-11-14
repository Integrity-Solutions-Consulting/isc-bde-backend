using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Utils.Peticiones
{
    public class HttpUtils
    {
        public async Task<T?> SendRequest<T>(string url, HttpMethod method, object? body = null)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(method, url);

                // Agregar body solo si corresponde
                if (body != null && (method == HttpMethod.Post || method == HttpMethod.Put))
                {
                    request.Content = JsonContent.Create(body);
                }

                var response = await httpClient.SendAsync(request);

                // Manejo de errores
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();

                    Console.WriteLine($"[HTTP ERROR] URL: {url}");
                    Console.WriteLine($"StatusCode: {response.StatusCode}");
                    Console.WriteLine($"Response Body: {errorContent}");

                    throw new Exception(
                        $"La solicitud HTTP falló. Código: {(int)response.StatusCode} - {response.StatusCode}. Contenido: {errorContent}"
                    );
                }

                // Si la respuesta no tiene contenido
                if (response.Content.Headers.ContentLength == 0)
                {
                    return default;
                }

                // Si T es string, devolver contenido como texto
                if (typeof(T) == typeof(string))
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    return (T)(object)stringContent; // casting seguro
                }

                // De lo contrario, deserializar JSON
                return await response.Content.ReadFromJsonAsync<T>();
            }
        }
    }

}
