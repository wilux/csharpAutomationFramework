using OpenQA.Selenium;

// https://blog.testproject.io/2020/11/09/page-object-model-in-selenium-using-c-sharp-nunit-reporting/

namespace csharp_cucumber_selenium_framework.Pages
{
    public class SalesPage : BasePage
    {
        private readonly IWebDriver driver;

        public string URL = "/index.php?action=sales";

        private readonly string titleSalesStatistics = "//h2[contains(text(),'Sales - Statistics')]";
        // private readonly string tableSalesDetails = "//table[@id='sales-details']";
        private readonly string salesYearMonthHeader = "//th[@class='sales header-year-month']";
        private readonly string monthCell = "//td[contains(text(), '{0}')]";
        private readonly string monthSalesCell = "//td[contains(text(), '{0}')]/following-sibling::td";


        public SalesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetUrl()
        {
            return this.GetBaseUrl() + this.URL;
        }

        public bool SalesStatisticsPageIsDisplayed()
        {
            return IsDisplayed(driver, titleSalesStatistics);
        }

        public string GrabYearMonthHeader()
        {
            return GrabTextFromElement(driver, salesYearMonthHeader);
        }

        public bool MonthCellIsDisplayed(string month)
        {
            string completeXpath = string.Format(monthCell, month);
            return IsDisplayed(driver, completeXpath);
        }

        public string GrabSalesAmountFromMonth(string month)
        {
            string completeXpath = string.Format(monthSalesCell, month);
            return GrabTextFromElement(driver, completeXpath);
        }
    }
}
