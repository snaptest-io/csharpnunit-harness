using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;

public class SnapConfig {

	public IWebDriver driver;

	public IWebDriver getDriver(DesiredCapabilities capabilities) {
		driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
		return driver;
	}

	public DesiredCapabilities getCapabilities() {
    DesiredCapabilities capabilities = new DesiredCapabilities();
    capabilities = DesiredCapabilities.Chrome();
    capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
    capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
    return capabilities;
  }

	public IConfigurationRoot getTestData() {

		// Add your environment/test data here.
		var dict = new Dictionary<string, string>
    {
	    {"baseUrl", "https://www.snaptest.io"}
    };

		var testData = new ConfigurationBuilder().AddInMemoryCollection(dict).Build();

    return testData;

  }

  public void StartSuite(String suiteName) {
    TestContext.Progress.WriteLine($"**** STARTING SUITE: {suiteName} ****");
  }

  public void EndSuite(String suiteName) {
    TestContext.Progress.WriteLine($"**** ENDING SUITE: {suiteName} ****");
  }

  public void StartTest(String testName) {
    TestContext.Progress.WriteLine("Starting test: " + testName);
  }

  public void EndTest(String testName) {
    TestContext.Progress.WriteLine("Ending test: " + testName);
  }

  public void reportAction(String description) {
    TestContext.Progress.WriteLine("Action: " + description);
  }

}