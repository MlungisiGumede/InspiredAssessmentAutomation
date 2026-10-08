using Microsoft.Playwright;
using NUnit.Framework;
using Reqnroll;
using InspiredAssessment.UI.Pages;
using InspiredAssessment.UI.Support;

namespace InspiredAssessment.UI.StepDefinitions;

[Binding]
public sealed class ShoppingCartStepDefinitions
{
    // Framework objects
    private readonly BrowserSession _browserSession;

    // Page objects
    private IPage _page = null!;
    private HomePage _homePage = null!;
    private ProductsPage _productsPage = null!;
    private CartPage _cartPage = null!;

    // Constructor
    public ShoppingCartStepDefinitions(BrowserSession browserSession)
    {
        _browserSession = browserSession;
    }

    [BeforeScenario(Order = 1)]
    public void InitialisePages()
    {
        _page = _browserSession.Page;

        _homePage = new HomePage(_page);
        _productsPage = new ProductsPage(_page);
        _cartPage = new CartPage(_page);
    }

    [Given("the customer is on the shopping website")]
    public async Task GivenTheCustomerIsOnTheShoppingWebsite()
    {
        await _homePage.NavigateAsync();
    }

    [Then("the shopping website should be displayed")]
    public async Task ThenTheShoppingWebsiteShouldBeDisplayed()
    {
        var isLoaded = await _homePage.IsLoadedAsync();

        Assert.That(
            isLoaded,
            Is.True,
            "The shopping website should be displayed.");
    }

    [When("the customer navigates to the products page")]
    public async Task WhenTheCustomerNavigatesToTheProductsPage()
    {
        await _homePage.NavigateToProductsPageAsync();
    }

    [When("the customer adds {string} to the cart")]
    public async Task WhenTheCustomerAddsToTheCart(string productName)
    {
        await _productsPage.SearchProductAsync(productName);
        await _productsPage.AddProductToCartAsync(productName);
        
    }

    [When("the customer continues shopping")]
    public async Task ThenTheCustomerContinuesShopping()
    {
        await _productsPage.ClickContinueShoppingAsync();
    }



    [When("the customer opens the shopping cart")]
    public async Task WhenTheCustomerOpensTheShoppingCart()
    {
        // We will implement this next.
        await _productsPage.ClickCartButtonAsync();
        
    }

    [Then("{string} should be displayed in the cart")]
    public async Task ThenTheProductShouldBeDisplayedInTheCart(string productName)
    {
        // We will implement this next.
        await _cartPage.GetCartItemsAsync();
        Assert.That(
            await _cartPage.GetCartItemsAsync(),
            Does.Contain(productName),
            $"The product '{productName}' should be displayed in the cart.");
            
            //await _page.PauseAsync();
    }


    [Given("the customer has {string} in the shopping cart")]
    public async Task GivenTheCustomerHasProductInTheShoppingCart(string productName)
    {
        await _homePage.NavigateAsync();
        await _homePage.NavigateToProductsPageAsync();
        await _productsPage.SearchProductAsync("Blue Top");
        await _productsPage.AddProductToCartAsync("Blue Top");
        await _productsPage.ClickContinueShoppingAsync();
        await _productsPage.ClickCartButtonAsync();
        await _cartPage.GetCartItemsAsync();
      //  await _cartPage.RemoveItemFromCartAsync();
       
    }   

    [When("the customer removes {string} from the cart")]
    public async Task WhenTheCustomerRemovesProductFromTheCart(string productName)
    {
        await _cartPage.RemoveItemFromCartAsync(productName);
      await _page.PauseAsync();
    }       


    [Then("{string} should not be displayed in the cart")]
    public async Task ThenTheProductShouldNotBeDisplayedInTheCart(string productName)
    {
        var cartItems = await _cartPage.GetCartItemsAsync();        
        Assert.That(
            cartItems,
            Does.Not.Contain(productName),
            $"The product '{productName}' should not be displayed in the cart.");
    }
}