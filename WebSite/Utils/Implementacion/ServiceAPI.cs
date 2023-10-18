using DAL.Models;
using DAL.Models.ViewModels;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using WebSite.Utils.Interface;

namespace WebSite.Utils.Implementacion
{
    public class ServiceAPI : IServiceAPI
    {
        private static string _baseUrl;
        public ServiceAPI()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<bool> EditarCompra(Compra compra)
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);

                var response = await cliente.PutAsJsonAsync("Compras", compra);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    string comprasString = Deserializer.getData(data, "data");
                    bool actualizado = bool.Parse(comprasString);
                    return actualizado;
                }
                
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al acceder al endpoint Compras");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> EliminarDetalle(int idDetalle)
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);

                var response = await cliente.DeleteAsync($"DetalleCompra/{idDetalle}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    string comprasString = Deserializer.getData(data, "data");
                    bool eliminado = bool.Parse(comprasString);
                    return eliminado;
                }

                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al acceder al endpoint DetalleCompras");
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<Compra?> ObtenerCompra(int id)
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);

                var response = await cliente.GetAsync($"Compras/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    string comprasString = Deserializer.getData(data, "data");
                    Compra? compra = JsonSerializer.Deserialize<Compra>(comprasString,
                        new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });
                    return compra;
                }
                return new();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al acceder al endpoint Compras");
                Console.WriteLine(ex.Message);
                return new();
            }
            
        }
        public async Task<List<Compra>?> ObtenerCompras()
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);

                var response = await cliente.GetAsync("Compras");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    string comprasString = Deserializer.getData(data, "data");
                    List<Compra>? compras = JsonSerializer.Deserialize<List<Compra>>(comprasString,
                        new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });
                    return compras;
                }
                return new();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al acceder al endpoint Compras");
                Console.WriteLine(ex.Message);
                return new();
            }
            
        }
        public async Task<List<DetalleMostrarVM>> ObtenerDetallesCompra(int idCompra)
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);

                var response = await cliente.GetAsync($"DetalleCompra/GetPorCompra/{idCompra}");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    string comprasString = Deserializer.getData(data, "data");
                    List<DetalleMostrarVM>? detallesCompras = JsonSerializer.Deserialize<List<DetalleMostrarVM>>(comprasString,
                        new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });
                    return detallesCompras;
                }
                return new();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al acceder al endpoint Compras");
                Console.WriteLine(ex.Message);
                return new();
            }
            
        }
    }
}
