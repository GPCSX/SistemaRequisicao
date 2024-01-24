namespace SistemaRequisicao.Integracao
{
    public class FeriadoIntegracao
    {
        private readonly string apiUrl = "https://api.invertexto.com/api-feriados";
        private readonly string token = "5828|PJpmDxLsDPxAVxqLdHNy76J3c3pKShY8";

        public async Task<bool> VerificarFeriado(DateOnly data)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{apiUrl}?token={token}&ano={data.Year}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    // Converta a data da API para o formato DateOnly
                    DateOnly dataFormatada = DateOnly.Parse(content);

                    // Compare as datas
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
