using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace csharp_cucumber_selenium_framework
{
    public class BrowserSelector
    {
        public IWebDriver browser;
          
        public BrowserSelector(string browserName, string[] options) {

            switch (browserName)
            {
                case "chrome":
                    this.browser = this.SetChrome(options);
                    break;
                case "firefox":
                    this.browser = this.SetFirefox(options);
                    break;
                case "edge":
                    this.browser = this.SetEdge(options);
                    break;
                case "safari":
                    this.browser = this.SetSafari();
                    break;
                default:
                    this.browser = null;
                    break;
            }
        }


        private ChromeDriver SetChrome(string[] optionsArg)
        {
            var options = new ChromeOptions();
            options.AddArguments(optionsArg);
            return new ChromeDriver(options);
        }



        private FirefoxDriver SetFirefox(string[] optionsArg)
        {
            var options = new FirefoxOptions();
            options.AddArguments(optionsArg);
            return new FirefoxDriver(options);
        }

        private EdgeDriver SetEdge(string[] optionsArg)
        {
            var options = new EdgeOptions();
            options.AddArguments(optionsArg);
            return new EdgeDriver(options);
        }

        private SafariDriver SetSafari()
        {
            var options = new SafariOptions();
            return new SafariDriver(options);
        }
    }
}
