using FluentAssertions;
using Newtonsoft.Json;
using System.Text;
using TechTalk.SpecFlow;

namespace JogoJustoTestes.BDD.StepDefinitions;

[Binding]
public class MetaStep
{
    private readonly HttpClient _client;
    private readonly ScenarioContext _scenarioContext;

    public MetaStep(HttpClient client, ScenarioContext scenarioContext)
    {
        _client = client;
        _scenarioContext = scenarioContext;
    }

    [When(@"ele envia uma requisição POST para criar ""(.*)"" com o seguinte payload:")]
    public async Task QuandoEleEnviaUmaRequisicaoPOSTParaCriar(string endpoint, Table table)
    {
        var row = table.Rows[0];
        var body = JsonConvert.SerializeObject(new
        {
            tipoMetaEsg = row["tipoMetaEsg"],
            descricaoMetaEsg = row["descricaoMetaEsg"],
            valorReferenciaMetaEsg = decimal.Parse(row["valorReferenciaMetaEsg"]), 
            valorAtualMetaEsg = decimal.Parse(row["valorAtualMetaEsg"]),           
            prazoMetaEsg = row["prazoMetaEsg"],
            empresaId = int.Parse(row["empresaId"])
        });

        var response = await _client.PostAsync(endpoint,
            new StringContent(body, Encoding.UTF8, "application/json"));

        var content = await response.Content.ReadAsStringAsync();
      
        _scenarioContext["response"] = response;
    }

    [When(@"ele envia uma requisição GET para listarS ""(.*)""")]
    public async Task QuandoEleEnviaUmaRequisicaoGETParaListar(string endpoint)
    {
        var response = await _client.GetAsync(endpoint);
        _scenarioContext["response"] = response; 
    }

    [When(@"ele envia uma requisição PUT para  ""(.*)"" com o seguinte payload:")]
    public async Task QuandoEleEnviaUmaRequisicaoPUTPara(string endpoint, Table table)
    {
        var row = table.Rows[0];
        var body = JsonConvert.SerializeObject(new
        {
            idMetaEsg = int.Parse(endpoint.Split('/').Last()), 
            tipoMetaEsg = row["tipoMetaEsg"],
            descricaoMetaEsg = row["descricaoMetaEsg"],
            valorAtualMetaEsg = decimal.Parse(row["valorAtualMetaEsg"]),
            prazoMetaEsg = row["prazoMetaEsg"]
            
        });

        var response = await _client.PutAsync(endpoint,
            new StringContent(body, Encoding.UTF8, "application/json"));

        var content = await response.Content.ReadAsStringAsync();
        _scenarioContext["response"] = response;
    }

    [Then(@"ele envia uma requisição GET para obter por ID ""(.*)""")]
    public async Task EntaoEleEnviaUmaRequisicaoGETParaObterPorID(string endpoint)
    {
        var response = await _client.GetAsync(endpoint);
        var content = await response.Content.ReadAsStringAsync();
        _scenarioContext["response"] = response; 
    }

    [Then(@"ele deve enviara uma requisição DELETE para ""(.*)""")]
    public async Task EntaoEleDeveEnviarUmaRequisicaoDELETEPara(string endpoint)
    {
        var response = await _client.DeleteAsync(endpoint);
        var content = await response.Content.ReadAsStringAsync();
        _scenarioContext["response"] = response; 
    }

    [Then(@"o corpo da resposta deve conter a lista de metas cadastradas")]
    public async Task EntaoOCorpoDaRespostaDeveConterAListaDeMetasCadastradas()
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        var json = await response.Content.ReadAsStringAsync();
        json.Should().NotBeNullOrEmpty();
    }

    [Then(@"o corpo da resposta deve conter os detalhes da meta com ID (\d+)")]
    public async Task EntaoOCorpoDaRespostaDeveConterOsDetalhes(int id)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        var json = await response.Content.ReadAsStringAsync();
        json.Should().NotBeEmpty();
    }
}