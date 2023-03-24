using OpenQA.Selenium;

// https://blog.testproject.io/2020/11/09/page-object-model-in-selenium-using-c-sharp-nunit-reporting/

namespace csharp_cucumber_selenium_framework.Pages
{
    public class LoginPage : BasePage
    {
        private readonly IWebDriver driver;

        public string URL = "/index.php?action=form4";

        private string inputUserName = "//input[@name='user']";
        private string inputPassWord = "//input[@name='pw']";
        private string btnLogin = "//input[@name='Login']";

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetUrl()
        {
            return this.GetBaseUrl() + this.URL;
        }

        public void ProvideUsername(string userName)
        {
            this.FillField(driver, inputUserName, userName);
        }

        public void ProvidePassword(string password)
        {
            this.FillField(driver, inputPassWord, password);
        }

        public void ClickLogin()
        {
            this.ClickOn(driver, btnLogin);
        }
    }
}
