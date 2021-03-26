using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary1.Utility
{
    public static class ScreenShots
    {
		public static void TakeScreenshot(this IWebDriver driver, string path)
		{
			Directory.CreateDirectory(path);

			var testName = TestContext.CurrentContext.Test.Name;
			TestContext.WriteLine(testName);
			var join = string.Join("", testName);
			TestContext.WriteLine(join);
			var correctTestName = string.Join("", testName.Split(Path.GetInvalidFileNameChars()));
			var fileName = $"{Path.Combine(path, correctTestName)}_{DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss")}.png";
			TestContext.WriteLine(fileName);
			var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
			screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);

			//AllureLifecycle cycle = AllureLifecycle.Instance;
			//cycle.AddAttachment(fileName, $"{correctTestName}");
		}
	}
}
