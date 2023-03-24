using csharp_cucumber_selenium_framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace csharp_cucumber_selenium_framework.StepDefinitions
{
    [Binding]
    public class AdminPrivilegesStepDefinitions
    {
        private readonly IWebDriver chromeDriver;
        private readonly LoginPage loginPage;
        private readonly UserAccountPage userAccountPage;
        private readonly EmployeePage employeePage;
        private readonly SalesPage salesPage;


        public AdminPrivilegesStepDefinitions(IWebDriver driver)
        {
            this.chromeDriver = driver;

            this.loginPage = new LoginPage(driver);
            this.userAccountPage = new UserAccountPage(driver);
            this.employeePage = new EmployeePage(driver);
            this.salesPage = new SalesPage(driver);
        }


        [Given(@"I navigate to login page")]
        public void GivenINavigateToLoginPage()
        {
            string url = loginPage.GetUrl();
            chromeDriver.Navigate().GoToUrl(url);
        }

        [When(@"I submit username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenISubmitUsernameAndPassword(string user, string pw)
        {
            loginPage.ProvideUsername(user);
            loginPage.ProvidePassword(pw);
            loginPage.ClickLogin();
        }

        [Then(@"I will be logged into the Admin Dashboard")]
        public void ThenIWillBeLoggedIntoTheAdminDashboard()
        {
            UserAccountPage userAccountPage = new UserAccountPage(chromeDriver);
            Assert.IsTrue(userAccountPage.displayAdminDashboard(), "Admin Dashboard is not displayed");
        }

        [When(@"Admin searches for employee ""([^""]*)""")]
        public void WhenAdminSearchesForEmployee(string employeeName)
        {
            userAccountPage.navigateToHumanResourcesSection();

            Assert.IsTrue(employeePage.EmployeePageIsDisplayed(), "Employee Page is not displayed");

            employeePage.FillEmployeeNameInput(employeeName);
            employeePage.ClickSearchBtn();
        }

        [Then(@"information appears that employee ""([^""]*)"" belongs to department ""([^""]*)""")]
        public void ThenInformationAppearsThatEmployeeBelongsToDepartment(string expectedEmployeeName, string expectedDepartmentName)
        {
            Assert.IsTrue(employeePage.EmployeeRecordIsDisplayed(), "No employee record is displayed");

            string actualEmployeeName = employeePage.GrabEmployeeName();
            Assert.AreEqual(expectedEmployeeName, actualEmployeeName, "Expected employee name not found");

            string actualDepartmentName = employeePage.GrabDepartmentName();
            Assert.AreEqual(expectedDepartmentName, actualDepartmentName, "Expected department name not found");
        }

        [When(@"Admin looks up total sales amount for month ""([^""]*)"" in year ""([^""]*)""")]
        public void WhenAdminLooksUpTotalSalesAmountForMonthInYear(string month, string year)
        {
            userAccountPage.NavigateToSalesSection();

            Assert.IsTrue(salesPage.SalesStatisticsPageIsDisplayed(), "Sales statistics Page is not displayed");
            Assert.IsTrue(salesPage.GrabYearMonthHeader().Contains(year), "Year " + year + " was not found.");
            Assert.IsTrue(salesPage.MonthCellIsDisplayed(month), "Month " + month + " was not found.");
        }

        [Then(@"the total ""([^""]*)"" sales amount is ""([^""]*)""")]
        public void ThenTheTotalSalesAmountIs(string month, string expectedSalesAmount)
        {
            string actualSalesAmount = salesPage.GrabSalesAmountFromMonth(month);

            Assert.AreEqual(expectedSalesAmount, actualSalesAmount,
                "Actual and expected sales amount for month of " + month + "do not match.");
        }
    }
}
