using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using TechTalk.SpecFlow;

namespace JogoJustoTestes.BDD.StepDefinitions;

[Binding]
public class SharedSteps
{
    private readonly HttpClient _client;
    private readonly ScenarioContext _scenarioContext;

    public SharedSteps(HttpClient client, ScenarioContext scenarioContext)
    {
        _client = client;
        _scenarioContext = scenarioContext;
    }

    [Given(@"que o administrador está autenticado com email ""(.*)"" e password ""(.*)""")]
    public async Task DadoQueOAdministradorEstaAutenticado(string email, string password)
    {
        var body = JsonConvert.SerializeObject(new { email, password });
        var content = new StringContent(body, Encoding.UTF8, "application/json");

        var loginResponse = await _client.PostAsync("/api/usuario/login", content);
        var json = await loginResponse.Content.ReadAsStringAsync();

        if (!loginResponse.IsSuccessStatusCode)
            throw new Exception($"Login falhou [{loginResponse.StatusCode}]:{json} ");

        var result = JsonConvert.DeserializeObject<dynamic>(json);

        string token = result!.token;

        _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
    }

    public static void ValidarJsonSchema(string json, string nomeArquivoSchema)
    {
        var caminhoSchema = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, 
            "Schemas", 
            nomeArquivoSchema
        );

        var schemaJson = File.ReadAllText(caminhoSchema);
        var schema = JSchema.Parse(schemaJson);
        var jsonObject = JObject.Parse(json);

        var isValid = jsonObject.IsValid(schema, out IList<string> errorMessages);

        Assert.True(isValid,
            $"JSON Schema inválido para '{nomeArquivoSchema}': {string.Join(", ", errorMessages)}");
    }
}
