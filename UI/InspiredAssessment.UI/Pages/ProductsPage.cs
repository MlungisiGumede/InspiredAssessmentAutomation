using Microsoft.Playwright;

namespace InspiredAssessment.UI.Pages;

public sealed class ProductsPage : BasePage
{
    public ProductsPage(IPage page) : base(page)
    {
    }

    private ILocator SearchInput =>
        Page.Locator("#search_product");

    private ILocator SearchButton =>
        Page.Locator("#submit_search");

    private ILocator SearchResults =>
        Page.GetByRole(
            AriaRole.Heading,
            new() { Name = "Searched Products" });

    private ILocator SuccessMessage =>
        Page.GetByText("Added!");

    private ILocator continueShoppingButton =>
        Page.GetByRole(
            AriaRole.Button,
            new() { Name = "Continue Shopping" });

           private ILocator ViewCartLink =>
    Page.Locator("#header a[href='/view_cart']");
    
    public async Task SearchProductAsync(string productName)
    {
        await SearchInput.FillAsync(productName);
        await SearchButton.ClickAsync();

        await SearchResults.WaitForAsync(new()
        {
            State = WaitForSelectorState.Visible
        });
    }

    public async Task AddProductToCartAsync(string productName)
    {
        var productCard = Page
            .Locator(".productinfo")
            .Filter(new()
            {
                HasText = productName
            })
            .First;

        await productCard.WaitForAsync(new()
        {
            State = WaitForSelectorState.Visible
        });

        await productCard
            .Locator("a.add-to-cart")
            .ClickAsync();

        await SuccessMessage.WaitForAsync(new()
        {
            State = WaitForSelectorState.Visible
        });
    }

    public async Task ClickContinueShoppingAsync()
    {
        await continueShoppingButton.ClickAsync();
    }

    public async Task ClickCartButtonAsync()
    {
      await ViewCartLink.ClickAsync();
        
    }

}