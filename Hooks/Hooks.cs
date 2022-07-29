using Selenium.Intilaizer;
using System;
using Selenium.Support.Extensions;
using TechTalk.SpecFlow;
using Selenium.Configuration;
using BoDi;
using System.IO;
using System.Reflection;

namespace Specflow_BDD_UI_Test_Automation_Framwork.Hooks
{
    [Binding]
    public sealed class Hooks
    {


        private readonly ScenarioContext _scenarioContext;

        private readonly IObjectContainer _objectContainer;
        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }
        //------------------------------------------------------------------


        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {

        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            outPutDirectory = outPutDirectory.Substring(0, outPutDirectory.IndexOf("bin"));

            outPutDirectory = outPutDirectory.Substring(outPutDirectory.IndexOf("\\") + 1);
            String path = Path.Combine(outPutDirectory, "TestResults\\index.html");
        
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
          
        }

        [BeforeScenario]
        public void BeforeScenario()
        {

            Driver.Init(Browser.Chrome);

        }
        [AfterTestRun]
        public static void TearDownReport()
        {
        }
        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Current.Quit();
        }
    }
}
