using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace SpecFlowBasics.StepDefinitions
{
    [Binding]
    public class BBCProjectStepDefinitions
    {
        private readonly IBrowser browser;
        private readonly IPage page;

        public BBCProjectStepDefinitions(IBrowser browser, IPage page)
        {
            this.browser = browser;
            this.page = page;
        }

        [Given("I navigate to the BBC website")]
        public async Task GivenINavigateToTheBBCWebsite()
        {
            await page.GotoAsync("https://www.bbc.co.uk/sport");
            await page.WaitForTimeoutAsync(6000);
            //await page.WaitForSelectorAsync("text=Scores & Fixtures", new WaitForSelectorOptions { Timeout = 60000 }); // Set timeout to 60 seconds
        }

        [When("I navigate to Scores & Fixtures - Football")]
        public async Task WhenINavigateToScoresFixturesFootball()
        {
            await page.ClickAsync("text=Scores & Fixtures");
            await page.ClickAsync("text=Football");
            await page.WaitForTimeoutAsync(6000);
            //await page.WaitForSelectorAsync("text=Scores & Fixtures", new WaitForSelectorOptions { Timeout = 60000 }); // Set timeout to 60 seconds
        }

        [Then("I record all team names playing today")]
        public async Task ThenIRecordAllTeamNamesPlayingToday()
        {
            var matches = await page.QuerySelectorAllAsync(".sp-c-fixture__wrapper");
            if (matches.Count > 0)
            {
                List<string> teamNames = new List<string>();
                foreach (var match in matches)
                {
                    teamNames.Add(await match.TextContentAsync());
                }
                // Output team names
                Console.WriteLine("Teams playing today: " + string.Join(", ", teamNames));
            }
            else
            {
                // Output message if no matches today
                Console.WriteLine("No matches today.");
            }
        }
    }
}
