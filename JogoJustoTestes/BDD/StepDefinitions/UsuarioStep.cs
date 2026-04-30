using Newtonsoft.Json;
using System.Text;
using TechTalk.SpecFlow;

namespace JogoJustoTestes.BDD.StepDefinitions;

[Binding]
public class UsuarioStep
{
    private readonly ScenarioContext _scenarioContext;
    private readonly HttpClient _httpClient;
    private HttpResponseMessage _httpMessageResponse;

    public UsuarioStep(ScenarioContext scenarioContext)  
    {
        _scenarioContext = scenarioContext;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://jogojusto-dev-h0e9bsesfjgkeydd.eastus2-01.azurewebsites.net/");
    }

    [Given("que o usuário tem dados válidos")]
    public void GivenDadoQueOUsuarioTemDadosValidos()
    {
        _scenarioContext["tipo"] = "Admin";
        _scenarioContext["email"] = "teste12@gmail.com";
        _scenarioContext["password"] = "Jogo14725";
    }

    [When("enviar os dados para criar um novo usuário")]
    public async Task WhenEnviarOsDadosParaCriarUmNovoUsuario()
    {
        var usuarionew = new
        {
            tipo = _scenarioContext["tipo"].ToString(),
            email = _scenarioContext["email"].ToString(),
            password = _scenarioContext["password"].ToString()
        };

        
        _httpMessageResponse = await _httpClient.PostAsync("api/usuario/criar",
            new StringContent(JsonConvert.SerializeObject(usuarionew),
            Encoding.UTF8, "application/json"));
        _scenarioContext["response"] = _httpMessageResponse;
    }

    [Then("deve receber status {int} usuário criado com sucesso")]
    public async Task ThenDeveReceberStatusEMensagemDeSucesso(int statusCode)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        Assert.Equal(statusCode, (int)response.StatusCode);
    }

    [Given("que o usuário tem dados inválidos")]
    public void GivenDadoQueOUsuarioTemDadosInvalidos()
    {
        _scenarioContext["tipo"] = "";
        _scenarioContext["email"] = "invalido@gmail.com";
        _scenarioContext["password"] = "123";
    }

    [When("enviar os dados para criar um novo usuário com dados inválidos")]
    public async Task WhenEnviarOsDadosParaCriarUmNovoUsuarioComDadosInvalidos()
    {
        var usuarionew = new
        {
            tipo = _scenarioContext["tipo"].ToString(),
            email = _scenarioContext["email"].ToString(),
            password = _scenarioContext["password"].ToString()
        };

        
        _httpMessageResponse = await _httpClient.PostAsync("api/usuario/criar",
            new StringContent(JsonConvert.SerializeObject(usuarionew),
            Encoding.UTF8, "application/json"));
        _scenarioContext["response"] = _httpMessageResponse;
    }

    [Then("deve receber status {int} usuário já existente ou dados inválidos")]
    public async Task ThenDeveReceberStatusEMensagemDeErro(int statusCode)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        Assert.Equal(statusCode, (int)response.StatusCode);
    }

    


}
