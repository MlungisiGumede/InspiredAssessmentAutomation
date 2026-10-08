using Microsoft.Playwright;

namespace InspiredAssessment.UI.Pages;

public sealed class HomePage : BasePage
{
    private const string BaseUrl = "https://automationexercise.com";


private readonly IPage _page;

    public HomePage(IPage page) : base(page)
    {
        _page = page;
    }

    private ILocator productsLink => _page.GetByRole(AriaRole.Link, new() { Name = "Products" });

    public async Task NavigateAsync()
    {
        await NavigateToAsync(BaseUrl);
        await WaitForPageToLoadAsync();
    }

    public async Task<bool> IsLoadedAsync()
    {
        var title = await GetPageTitleAsync();

        return title.Contains(
            "Automation Exercise",
            StringComparison.OrdinalIgnoreCase);
    }


    public async Task NavigateToProductsPageAsync()
    {
        await productsLink.ClickAsync();
        await WaitForPageToLoadAsync();
    }
}