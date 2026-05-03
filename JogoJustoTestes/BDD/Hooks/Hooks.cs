using BoDi;
using TechTalk.SpecFlow;

namespace JogoJustoTestes.BDD.Hooks;

[Binding]
public class Hooks
{
    private readonly IObjectContainer _objectContainer;
    private HttpClient _client = null!;

    public Hooks(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        _client = new HttpClient()
        {
           BaseAddress = new Uri("http://localhost:5000/")
        };

        _objectContainer.RegisterInstanceAs(_client);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _client?.Dispose();
    }
}

