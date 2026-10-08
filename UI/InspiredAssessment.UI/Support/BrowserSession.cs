using Microsoft.Playwright;

namespace InspiredAssessment.UI.Support;

public sealed class BrowserSession
{
    public IPlaywright Playwright { get; private set; } = null!;
    public IBrowser Browser { get; private set; } = null!;
    public IBrowserContext Context { get; private set; } = null!;
    public IPage Page { get; private set; } = null!;

    public async Task StartAsync()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        Browser = await Playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 100
            });

        Context = await Browser.NewContextAsync(
            new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1440,
                    Height = 900
                }
            });

        Page = await Context.NewPageAsync();
    }

    public async Task StopAsync()
    {
        if (Context is not null)
            await Context.CloseAsync();

        if (Browser is not null)
            await Browser.CloseAsync();

        Playwright?.Dispose();
    }
}