using Microsoft.EntityFrameworkCore;
using SistemaRequisicao.Data;
using SistemaRequisicao.Models;
using SistemaRequisicao.Repositorios.Interfaces;

namespace SistemaRequisicao.Repositorios
{
    public class FeriadoService : IFeriadoService
    {
        private readonly string apiUrl = "https://api.invertexto.com/api-feriados";
        private readonly string token = "5828|PJpmDxLsDPxAVxqLdHNy76J3c3pKShY8";

        public async Task<bool> VerificarFeriado(string data)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{apiUrl}?token={token}&ano={data.Substring(0, 4)}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    // Converta a data da API para o formato DateOnly
                    string dataFormatada = content.Trim('"'); // Remova as aspas da resposta
                    return data == dataFormatada;
                }
                else
                {
                    Console.WriteLine($"Erro na requisição à API: {response.StatusCode}");
                    return false;
                }
            }
        }
    }
}