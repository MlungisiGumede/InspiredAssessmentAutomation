using Reqnroll;
using InspiredAssessment.UI.Support;

namespace InspiredAssessment.UI.Hooks;

[Binding]
public sealed class BrowserHooks
{
    private readonly BrowserSession _browserSession;

    public BrowserHooks(BrowserSession browserSession)
    {
        _browserSession = browserSession;
    }

    [BeforeScenario(Order = 0)]
    public async Task BeforeScenario()
    {
        await _browserSession.StartAsync();
    }

    [AfterScenario(Order = 100)]
    public async Task AfterScenario()
    {
        await _browserSession.StopAsync();
    }
}