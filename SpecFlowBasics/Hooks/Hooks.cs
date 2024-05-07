using BoDi;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

[Binding]
public sealed class Hooks
{
    private readonly IObjectContainer _container;

    public Hooks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync();
        var page = await browser.NewPageAsync();

        // Register Playwright objects with the dependency injection container
        _container.RegisterInstanceAs(playwright);
        _container.RegisterInstanceAs(browser);
        _container.RegisterInstanceAs(page);
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        
        var browser = _container.Resolve<IBrowser>();
        var page = _container.Resolve<IPage>();

        // Close the browser and dispose Playwright
        await browser.CloseAsync();
        await page.CloseAsync();

    }
}

[Binding]
public class MyStepDefinitions
{
    private readonly IBrowser _browser;
    private readonly IPage _page;

    public MyStepDefinitions(IBrowser browser, IPage page)
    {
        _browser = browser;
        _page = page;
    }

    // Define your SpecFlow step definitions here
}