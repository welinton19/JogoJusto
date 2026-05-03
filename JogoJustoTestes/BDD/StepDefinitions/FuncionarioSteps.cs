using System.Text;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace JogoJustoTestes.BDD.StepDefinitions;

[Binding]
public class FuncionarioSteps
{
    private readonly HttpClient _client;
    private readonly ScenarioContext _scenarioContext;

    public FuncionarioSteps(HttpClient client, ScenarioContext scenarioContext)
    {
        _client = client;
        _scenarioContext = scenarioContext;
    }

    [When(@"ele envia uma requisição POST para ""(.*)"" com os dados do funcionário:")]
    public async Task QuandoEnviaPostFuncionario(string url, Table tabela)
    {
        var payload = new
        {
            Nome = tabela.Rows[0]["nome"],
            Cargo = tabela.Rows[0]["cargo"],
            DepartamentoId = int.Parse(tabela.Rows[0]["departamentoId"]),
            Genero = tabela.Rows[0]["genero"],
            Raca = tabela.Rows[0]["raca"],
            Cpf = tabela.Rows[0]["cpf"],
            StPcd = false,
            TipoPcd = (string?)null,
            Salario = 3000.00m,
            DataNascimento = new DateTime(1990, 5, 15),
            DataContratacao = new DateTime(2026, 5, 02),
            MentorId = (int?)null
        };

        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(url, content);
        _scenarioContext["response"] = response;
    }

    [When(@"ele solicita a lista de funcionários cadastrados enviando uma requisição GET para ""(.*)""")]
    public async Task QuandoSolicitaListaComGet(string url)
    {
        var response = await _client.GetAsync(url);
        _scenarioContext["response"] = response;
    }

    [When(@"ele envia uma requisição GET para ""(.*)"" para buscar um funcionário existente por ID")]
    public async Task QuandoBuscaFuncionarioExistente(string url)
    {
        var response = await _client.GetAsync(url);
        _scenarioContext["response"] = response;
    }

    [When(@"ele envia uma requisição GET para ""(.*)"" para buscar um funcionário inexistente por ID")]
    public async Task QuandoBuscaFuncionarioInexistente(string url)
    {
        var response = await _client.GetAsync(url);
        _scenarioContext["response"] = response;
    }

    [Then(@"a resposta deve conter uma lista de funcionários")]
    public async Task EntaoRespostaDeveConterListaDeFuncionarios()
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        var json = await response.Content.ReadAsStringAsync();
        Assert.Equal(200, (int)response.StatusCode);
        Assert.Contains("items", json, StringComparison.OrdinalIgnoreCase);
    }

    [Then(@"ele deve receber uma resposta com status code (\d+) para funcionario")]
    public void EntaoDeveReceberStatusCodeFuncionario(int statusCode)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        Assert.Equal(statusCode, (int)response.StatusCode);
    }

    [Then(@"o corpo da resposta do funcionario deve conter a mensagem ""(.*)""")]
    public async Task EntaoCorpoFuncionarioContemMensagem(string mensagem)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        var json = await response.Content.ReadAsStringAsync();
         
        Assert.Contains(mensagem, json, StringComparison.OrdinalIgnoreCase);
    }

    [Then(@"o corpo da resposta do funcionario deve conter o campo ""(.*)""")]
    public async Task EntaoCorpoFuncionarioContemCampo(string campo)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        var json = await response.Content.ReadAsStringAsync();
        Assert.Contains(campo, json, StringComparison.OrdinalIgnoreCase);
    }
}