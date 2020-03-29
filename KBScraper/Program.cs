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
                driver.Navigate().GoToUrl("https://kb.xcentric.com/auth/login");

                // Test Location @ login
                Console.WriteLine(driver.Title);
                Thread.Sleep(300);

                // Get the login page input elements
                var userNameField = driver.FindElementById("username");
                var userPasswordField = driver.FindElementById("password");
                var loginButton = driver.FindElementByXPath("//input[@name='login']");

                // Enter user name and password
                userNameField.SendKeys("pzivojinovic@xcentric.com");
                userPasswordField.SendKeys("Z!v985214736912");

                // click the login button
                loginButton.Click();

                // Test Location post login
                Console.WriteLine(driver.Title);


                //test grabber
                //varbase
                Dictionary<string, string> articles = new Dictionary<string, string>();
                List<string> completed = new List<string>();


                //Pause to load 
                Thread.Sleep(500);

                //navigate to just the specified kb category
                IWebElement link = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/ul/a[4]"));
                link.Click();

                //Pause to load
                Thread.Sleep(500);



                IWebElement DocSelect = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[3]/div[1]/ul"));

                IList<IWebElement> documents = DocSelect.FindElements(By.XPath(".//li"));

                Console.WriteLine(documents.Count);

                foreach (var li in documents)
                {
                    string t = li.FindElement(By.XPath(".//a//div[1]")).GetAttribute("textContent");
                    string u = li.FindElement(By.TagName("a")).GetAttribute("href");
                    

                    articles.Add(t, u);


                };
                
                
                                
                foreach (KeyValuePair<string, string> kvp in articles)
                {
                    Console.WriteLine(kvp);
                }

                driver.Navigate().Back(); 

                Console.WriteLine("exit");
                Console.ReadLine();
            }
        }
    }
}
