using Microsoft.Playwright;

namespace InspiredAssessment.UI.Pages;

public sealed class CartPage : BasePage
{
    public CartPage(IPage page) : base(page)
    {
    }


    private ILocator CartItems =>
        Page.Locator(".cart_info");

    private ILocator cartquantitydeletebutton =>
        Page.Locator(".cart_quantity_delete");

    public async Task<string> GetCartItemsAsync()
    {
        await CartItems.WaitForAsync(new()
        {
            State = WaitForSelectorState.Visible
        });

        return await CartItems.InnerTextAsync();
    }
        
    public async Task RemoveItemFromCartAsync(string productName)
    {
        var cartItem = CartItems.Filter(new()
        {
            HasText = productName
        }).First;

        await cartItem.WaitForAsync(new()
        {
            State = WaitForSelectorState.Visible
        });
    {
        await cartquantitydeletebutton.ClickAsync();
    }

    }

}