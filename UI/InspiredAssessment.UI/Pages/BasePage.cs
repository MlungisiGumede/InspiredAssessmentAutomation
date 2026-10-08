using Microsoft.Playwright;

namespace InspiredAssessment.UI.Pages;

public abstract class BasePage
{
    protected readonly IPage Page;

    protected BasePage(IPage page)
    {
        Page = page;
    }

    public async Task NavigateToAsync(string url)
    {
        await Page.GotoAsync(url);
    }

    public async Task WaitForPageToLoadAsync()
    {
        await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    }

    public async Task<string> GetPageTitleAsync()
    {
        return await Page.TitleAsync();
    }

    public async Task<bool> IsVisibleAsync(ILocator locator)
    {
        return await locator.IsVisibleAsync();
    }
}