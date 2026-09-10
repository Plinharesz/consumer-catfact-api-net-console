using static System.Console;
using System.Text.Json;
using System.Net.Http;
using System;
using ConsumerGatinho.Models; // Importa a pasta Models onde está a sua classe

var apiUrl = "https://catfact.ninja/fact";
var cliente = new HttpClient();

try
{
    // Faz a requisição GET para a API de gatos
    HttpResponseMessage response = await cliente.GetAsync(apiUrl);
    response.EnsureSuccessStatusCode();

    // Lê o retorno da API como string
    string respostaApi = await response.Content.ReadAsStringAsync();

    // Configuração para ignorar letras maiúsculas/minúsculas no mapeamento do JSON
    var opcoes = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    // Desserializa o JSON para o nosso objeto CatFacts
    CatFacts? catFact = JsonSerializer.Deserialize<CatFacts>(respostaApi, opcoes);

    if (catFact != null)
    {
        // Imprime no console no formato exigido pelo exercício (letra b)
        WriteLine("Fato sobre Gatos:");
        WriteLine(catFact.Fact);
    }
}
catch (Exception ex)
{
    WriteLine($"Ocorreu um erro ao consultar a API: {ex.Message}");
}