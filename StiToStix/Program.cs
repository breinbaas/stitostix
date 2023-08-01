using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;

namespace StiToStix
{
    public class StiToStix
    {
        private static WindowsDriver<WindowsElement>? _winDriver;
        public string stiDir = @"C:\Users\brein\Documents\Deltares\sti";
        //public string stixDir = @"C:\Users\brein\Documents\Deltares\stix";
        public string dstabExe = "C:\\Program Files (x86)\\Deltares\\D-GEO Suite\\D-Stability 2023.01\\bin\\D-Stability.exe";

        public void execute(string filePath) {
            var newFileName = filePath + "x";
            var options = new AppiumOptions();
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            // Set the path of the D-Stability executable.
            options.AddAdditionalCapability("app", dstabExe);

            _winDriver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);

            try
            {
                // Close the start screen and go to the import sti button
                _winDriver.Keyboard.PressKey(Keys.Escape);
                _winDriver.FindElementByAccessibilityId("FileTab").Click();
                _winDriver.FindElementByAccessibilityId("ImportStiButton").Click();

                Thread.Sleep(1000);

                // Type the input file path and press enter
                _winDriver.FindElementByName("Import").SendKeys(filePath);
                _winDriver.FindElementByName("Import").SendKeys(Keys.Enter);

                Thread.Sleep(1000);

                // Open the save menu
                _winDriver.FindElementByAccessibilityId("FileTab").Click();
                _winDriver.FindElementByAccessibilityId("SaveAsButton").Click();

                Thread.Sleep(1000);

                // Type the output file path and press enter                
                _winDriver.FindElementByName("Save Project As").SendKeys(newFileName);
                _winDriver.FindElementByName("Save Project As").SendKeys(Keys.Enter);

                Thread.Sleep(1000);
            }
            finally
            {
                // Close the application
                _winDriver.Quit();
            }
        }


        public static void Main()
        {
            var stiToStix = new StiToStix();

            // get files
            string[] filePaths = Directory.GetFiles(stiToStix.stiDir, "*.sti", SearchOption.AllDirectories);

            foreach(var filePath in filePaths)
            {
                stiToStix.execute(filePath);
            }          
        }
    }
}
