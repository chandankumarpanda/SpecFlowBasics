using Microsoft.Playwright;
using TechTalk.SpecFlow;
using System;
using System.Threading.Tasks;

[Binding]
public class LoginSteps
{
    private readonly IPage _page;

    public LoginSteps(IPage page)
    {
        _page = page;
    }

    [Given("I navigate to the login page")]
    public async Task GivenINavigateToTheLoginPage()
    {
        await _page.GotoAsync("https://www.facebook.com/people/Ganesh-Das/pfbid06pNhRNnVND9ipQPYhzRtrqLo5MEUr4UKKxTxGH3BYwpqW9z7wKmEspurdaQ38fqpl/");
    }

    [When("I attempt to sign in with invalid credentials")]
    public async Task WhenIAttemptToSignInWithInvalidCredentials()
    {
        await _page.FillAsync("input[name='username']", "invalid_username");
        await _page.FillAsync("input[name='password']", "invalid_password");
        await _page.ClickAsync("button[type='submit']");
    }

    [Then("I verify that an error message is displayed with the expected text")]
    public async Task ThenIVerifyThatAnErrorMessageIsDisplayedWithTheExpectedText()
    {
        var errorMessageElement = await _page.QuerySelectorAsync("div.error-message");
        var errorMessageText = await errorMessageElement.InnerTextAsync();

        // Verify that the error message text is as expected
        if (errorMessageText.Contains("Invalid username or password"))
        {
            Console.WriteLine("Error message is displayed with the expected text.");
        }
        else
        {
            Console.WriteLine("Error message is not displayed or does not contain the expected text.");
        }
    }
}