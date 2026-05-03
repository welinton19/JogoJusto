using System.Text;
using FluentAssertions;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace JogoJustoTestes.BDD.StepDefinitions;

[Binding]
public class EmpresaSteps
{
    private readonly HttpClient _client;
    private readonly ScenarioContext _scenarioContext;

    public EmpresaSteps(HttpClient client, ScenarioContext scenarioContext)
    {
        _client = client;
        _scenarioContext = scenarioContext;
    }

    [When(@"ele envia uma requisição POST para ""(.*)"" com o seguinte payload:")]
    public async Task QuandoEnviaPostComPayload(string url, Table tabela)
    {
        var payload = new
        {
            Nome = tabela.Rows[0]["nome"],
            CNPJ = tabela.Rows[0]["cnpj"],
            Endereco = tabela.Rows[0]["endereco"],
            InscricaoEstadual = "",
            Telefone = ""
        };
        var jsonPayload = JsonConvert.SerializeObject(payload);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(url, content);
        _scenarioContext["response"] = response;
    }

    [When(@"ele envia uma requisição GET para ""(.*)""")]
    public async Task QuandoEnviaGetPara(string url)
    {
        var response = await _client.GetAsync(url);
        _scenarioContext["response"] = response;
    }

    [Then(@"ele deve receber uma resposta com status code (\d+)")]
    public void EntaoDeveReceberStatusCode(int statusCode)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        ((int)response.StatusCode).Should().Be(statusCode);
    }

    [Then(@"a resposta deve conter uma lista de empresas")]
    public async Task EntaoRespostaDeveConterListaDeEmpresas()
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        var json = await response.Content.ReadAsStringAsync();                  
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("items");

        SharedSteps.ValidarJsonSchema(json, "empresa-lista.json");
    }

    [Then(@"o corpo da resposta deve conter o campo ""(.*)""")]
    public async Task EntaoCorpoDeveConterCampo(string campo)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        var json = await response.Content.ReadAsStringAsync(); json.Should().NotBeNullOrEmpty();
        json.Should().Contain(campo);

        SharedSteps.ValidarJsonSchema(json, "empresa-por-id.json");
    }

    [Then(@"o corpo da resposta deve conter a mensagem ""(.*)""")]
    public async Task EntaoCorpoDeveConterMensagem(string mensagem)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        var json = await response.Content.ReadAsStringAsync();
        json.Should().Contain(mensagem);
    }
}