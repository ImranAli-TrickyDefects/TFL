using System;
using TechTalk.SpecFlow;
using Selenium.Intilaizer;
using NUnit.Framework;
using Selenium.Configuration;
using Specflow_BDD_UI_Test_Automation_Framwork.Contexts;
using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace Specflow_BDD_UI_Test_Automation_Framwork.Steps_Defination
{
    [Binding]
    public class TFLSteps
    {
        readonly UserContext context;
        public TFLSteps(UserContext context)
        {
            this.context = context;
        }

      

        [Given(@"the user navigates to the TFL app")]
        [When(@"the user navigates to the TFL app")]
        public void GivenTheUserNavigatesToTheTFLApp()
        {
            Driver.Current.Navigate().GoToUrl("https://tfl.gov.uk/");
        }

        [When(@"the user provides valid ""(.*)"" and ""(.*)""")]
        public void WhenTheUserProvidesValidAnd(string from, string to)
        {
            Driver.Current.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")).Click();
            Driver.Current.SwitchTo().Window(Driver.Current.WindowHandles.Last());
            Driver.Current.FindElement(By.XPath("//button[@class='cb-button']")).Click();
            Driver.Current.SwitchTo().Window(Driver.Current.WindowHandles.Last());
            Driver.Current.FindElement(By.Id("InputFrom")).SendKeys(from);
            Driver.Current.FindElement(By.Id("InputTo")).SendKeys(to);
            Driver.Current.FindElement(By.Id("plan-journey-button")).Click();
        }

        [When(@"the user provides valid ""(.*)"" and ""(.*)"" for arrival time")]
        public void WhenTheUserProvidesValidAndForArrivalTime(string from, string to)
        {
            Driver.Current.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")).Click();
            Driver.Current.SwitchTo().Window(Driver.Current.WindowHandles.Last());
            Driver.Current.FindElement(By.XPath("//button[@class='cb-button']")).Click();
            Driver.Current.SwitchTo().Window(Driver.Current.WindowHandles.Last());
            Driver.Current.FindElement(By.Id("InputFrom")).SendKeys(from);
            Driver.Current.FindElement(By.Id("InputTo")).SendKeys(to);
        }

        [Then(@"a valid journey is planned for them")]
        public void ThenAValidJourneyIsPlannedForThem()
        {

           Assert.That(Driver.Current.PageSource.Contains("We found more than one location matching"));
        }

        [Then(@"a valid journey cannot be planned")]
        public void ThenAValidJourneyCannotBePlanned()
        {
            Assert.That(Driver.Current.PageSource.Contains("Journey planner could not find any results to your search. Please try again"));
        }

        [Then(@"journey input validation messages appear")]
        public void ThenJourneyInputValidationMessagesAppear()
        {
            Assert.That(Driver.Current.PageSource.Contains("The From field is required."));
            Assert.That(Driver.Current.PageSource.Contains("The To field is required."));
        }

        [When(@"changes the arrival time")]
        public void WhenChangesTheArrivalTime()
        {
            Driver.Current.FindElement(By.ClassName("change-departure-time")).Click();
            Assert.That(Driver.Current.PageSource.Contains("Arriving"));
            Driver.Current.FindElement(By.XPath("//label[@for='arriving']")).Click();
            SelectElement arrivingTime = new SelectElement(Driver.Current.FindElement(By.Id("Time")));
            arrivingTime.SelectByText("00:45");
            Driver.Current.FindElement(By.Id("plan-journey-button")).Click();
        }




        [Then(@"the journey can be edited")]
        public void ThenTheJourneyCanBeEdited()
        {
            Driver.Current.FindElement(By.XPath("//span[contains(text(),'Edit journey')]")).Click();
            Driver.Current.FindElement(By.Id("InputFrom")).SendKeys("Liverpool Street");
            Driver.Current.FindElement(By.Id("plan-journey-button")).Click();
        }

        [Then(@"the recent journeys are displayed")]
        public void ThenTheRecentJourneysAreDisplayed()
        {
           
        }


        
    }
}
