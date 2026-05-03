using System.Text;
using System.Text.Json;
using TechTalk.SpecFlow;


namespace JogoJustoTestes.BDD.StepDefinitions;

[Binding]
public class LoginStep
{
    private readonly ScenarioContext _scenarioContext;
    private readonly HttpClient _httpClient;

    public LoginStep(ScenarioContext scenarioContext, HttpClient httpClient)
    {
        _scenarioContext = scenarioContext;
        _httpClient = httpClient;        
    }

    [Given("que o usuário tem um login válido")]
    public void DadoQueOUsuarioTemUmLoginValido()
    {
        
        _scenarioContext["email"] = "isabella@example.com";
        _scenarioContext["password"] = "SenhaForte123";
    }

    [When("enviar Email e Senha corretos")]
    public async Task QuandoEnviarEmailESenhaCorretos()
    {
        var email = _scenarioContext["email"].ToString();
        var password = _scenarioContext["password"].ToString();

        var body = new StringContent(
            JsonSerializer.Serialize(new { email, password }),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync("api/usuario/login", body);
        _scenarioContext["response"] = response;
    }

    [Then("deve receber status {int} de login com sucesso")]
    public async Task EntaoDeveReceberStatusEMensagemDeSucesso(int statusCode)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];

        
        Assert.Equal(statusCode, (int)response.StatusCode);

        
        var content = await response.Content.ReadAsStringAsync();
        Assert.NotEmpty(content);
    }

    [Given("que o usuário tem um login inválido")]
    public void DadoQueOUsuarioTemUmLoginInvalido()
    {
        _scenarioContext["email"] = "teste9@gmail.com";
        _scenarioContext["password"] = "SenhaIncorreta123";
    }

    [When("enviar Email e Senha incorretos")]
    public async Task QuandoEnviarEmailESenhaIncorretos()
    {
        var email = _scenarioContext["email"].ToString();
        var password = _scenarioContext["password"].ToString();

        var body = new StringContent(
            JsonSerializer.Serialize(new { email, password }),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync("api/usuario/login", body);
        _scenarioContext["response"] = response;
    }

    [Then("deve receber status {int} erro de login")]
    public async Task EntaoDeveReceberStatusEMensagemDeErro(int statusCode)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];

        Assert.Equal(statusCode, (int)response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        Assert.NotEmpty(content);
    }
}