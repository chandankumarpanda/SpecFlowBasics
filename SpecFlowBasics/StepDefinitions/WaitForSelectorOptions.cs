using Microsoft.Playwright;

namespace SpecFlowBasics.StepDefinitions
{
    internal class WaitForSelectorOptions : PageWaitForSelectorOptions
    {
        public int Timeout { get; set; }
    }
}