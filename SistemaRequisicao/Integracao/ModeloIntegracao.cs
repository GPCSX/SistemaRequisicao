namespace SistemaRequisicao.Integracao
{
    public class ModeloIntegracao
    {
        public string Data { get; set; } // Agora, a data é uma string

        public async Task VerificarEProcessarFeriado()
        {
            FeriadoService feriadoService = new FeriadoService();

            // Converta a string para DateOnly
            DateOnly dataDateOnly = DateOnly.Parse(Data);

            bool ehFeriado = await feriadoService.VerificarFeriado(dataDateOnly);

            if (ehFeriado)
            {
                Console.WriteLine("A data é um feriado!");
                // Execute as ações necessárias para uma data de feriado
            }
            else
            {
                Console.WriteLine("A data não é um feriado.");
                // Execute as ações necessárias para uma data que não é feriado
            }
        }
    }
}
