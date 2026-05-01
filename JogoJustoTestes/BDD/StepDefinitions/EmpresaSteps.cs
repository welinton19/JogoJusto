using System.Net.Http.Headers;
using System.Text;
using FluentAssertions;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace JogoJustoTestes.BDD.StepDefinitions;

[Binding]
public class EmpresaSteps
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response = null!;

    public EmpresaSteps(HttpClient client)
    {
        _client = client;
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
        _response = await _client.PostAsync(url, content);
    }

    [When(@"ele envia uma requisição GET para ""(.*)""")]
    public async Task QuandoEnviaGetPara(string url)
    {
        _response = await _client.GetAsync(url);
    }

    [Then(@"ele deve receber uma resposta com status code (\d+)")]
    public void EntaoDeveReceberStatusCode(int statusCode)
    {
        ((int)_response.StatusCode).Should().Be(statusCode);
    }

    [Then(@"a resposta deve conter uma lista de empresas")]
    public async Task EntaoRespostaDeveConterListaDeEmpresas()
    {
        var json = await _response.Content.ReadAsStringAsync();
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("items");
    }

    [Then(@"o corpo da resposta deve conter o campo ""(.*)""")]
    public async Task EntaoCorpoDeveConterCampo(string campo)
    {
        var json = await _response.Content.ReadAsStringAsync();
        json.Should().Contain(campo);
    }

    [Then(@"o corpo da resposta deve conter a mensagem ""(.*)""")]
    public async Task EntaoCorpoDeveConterMensagem(string mensagem)
    {
        var json = await _response.Content.ReadAsStringAsync();
        json.Should().Contain(mensagem);
    }
}