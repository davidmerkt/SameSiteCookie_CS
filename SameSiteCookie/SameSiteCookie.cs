using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SameSiteCookie
{
    class SameSiteCookie
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("http://www.example.com");

                var cookie1Dictionary = new System.Collections.Generic.Dictionary<string, object>()
                {
                    { "name", "test1" }, { "value", "cookie1" }, { "sameSite", "Strict" }
                };
                var cookie1 = Cookie.FromDictionary(cookie1Dictionary);

                var cookie2Dictionary = new System.Collections.Generic.Dictionary<string, object>()
                {
                    { "name", "test2" }, { "value", "cookie2" }, { "sameSite", "Lax" }
                };
                var cookie2 = Cookie.FromDictionary(cookie2Dictionary);

                driver.Manage().Cookies.AddCookie(cookie1);
                driver.Manage().Cookies.AddCookie(cookie2);

                System.Console.WriteLine(cookie1.SameSite);
                System.Console.WriteLine(cookie2.SameSite);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
