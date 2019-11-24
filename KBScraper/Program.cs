using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace KBScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the Chrome Driver
            using (var driver = new ChromeDriver())
            {
                // Go to the login page
                driver.Navigate().GoToUrl("");

                // Test Location @ login
                Console.WriteLine(driver.Title);

                // Get the login page input elements
                var userNameField = driver.FindElementById("username");
                var userPasswordField = driver.FindElementById("password");
                var loginButton = driver.FindElementByXPath("//input[@name='login']");

                // Enter user name and password
                userNameField.SendKeys("");
                userPasswordField.SendKeys("");

                // click the login button
                loginButton.Click();

                // Test Location post login
                Console.WriteLine(driver.Title);
                

                //test grabber
                //varbase
                Dictionary<string, string> articles = new Dictionary<string, string>();
                List<string> completed = new List<string>();
                string title;
                string url;
                Console.ReadLine();
                //navigate to just the single article kb category
                IWebElement link = driver.FindElement(By.XPath("//a[@name,'How to log in and use this Knowledge Base']"));
                link.Click();
                Console.ReadLine();




            }
        }
    }
}
