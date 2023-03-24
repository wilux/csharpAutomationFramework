using OpenQA.Selenium;

namespace csharp_cucumber_selenium_framework.Pages
{
    public class UserAccountPage : BasePage
    {
        private readonly IWebDriver driver;

        public string URL = "/index.php?action=useraccount";

        private string titleUserForm = "//h2[contains(text(),'User Account')]";
        private string titleAdminDashboard = "//h2[contains(text(),'Admin Dashboard')]";
        private string linkHumanResources = "//a[@id='hr-resources-link']";
        private string linkSalesStatistics = "//a[@id='sales-statistics-link']";

        public UserAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool displayTitleForm()
        {
            return IsDisplayed(driver, titleUserForm);
        }

        public bool displayAdminDashboard()
        {
            return IsDisplayed(driver, titleAdminDashboard);
        }

        public void navigateToHumanResourcesSection()
        {
            this.ClickOn(driver, linkHumanResources);
        }

        public void NavigateToSalesSection()
        {
            this.ClickOn(driver, linkSalesStatistics);
        }
    }
}
