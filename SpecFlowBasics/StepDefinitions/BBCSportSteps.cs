using Microsoft.Playwright;
using TechTalk.SpecFlow;
using System;
using System.Threading.Tasks;

[Binding]
public class BBCSportSteps
{
    private readonly IPage _page;

    public BBCSportSteps(IPage page)
    {
        _page = page;
    }

    [Given("I navigate to the BBC Sport website")]
    public async Task GivenINavigateToTheBBCSportWebsite()
    {
        await _page.GotoAsync("https://www.bbc.co.uk/sport");
        await _page.WaitForTimeoutAsync(5000);
    }

    [When("I search for articles related to '(.*)'")]
    public async Task WhenISearchForArticlesRelatedTo(string keyword)
    {
        await _page.FillAsync("input[id='orb-search-q']", keyword);
        await _page.WaitForTimeoutAsync(5000);
        //await _page.WaitForSelectorAsync("input[id='orb-search-q']");
        await _page.PressAsync("input[id='orb-search-q']", "Enter");
        await _page.WaitForTimeoutAsync(5000);
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    [Then("I output the first and last headings returned on the page")]
    public async Task ThenIOutputTheFirstAndLastHeadingsReturnedOnThePage()
    {
        var headings = await _page.QuerySelectorAllAsync("h3");

        if (headings.Count > 0)
        {
            var firstHeading = await headings[0].TextContentAsync();
            var lastHeading = await headings[headings.Count - 1].TextContentAsync();

            Console.WriteLine($"First Heading: {firstHeading}");
            Console.WriteLine($"Last Heading: {lastHeading}");
        }
        else
        {
            Console.WriteLine("No articles found related to sports.");
        }
    }
}