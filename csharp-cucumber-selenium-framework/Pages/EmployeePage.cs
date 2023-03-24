using OpenQA.Selenium;

namespace csharp_cucumber_selenium_framework.Pages
{
    public class EmployeePage : BasePage
    {
        private readonly IWebDriver driver;

        public string URL = "/index.php?action=employee";

        private string titleFindEmployee = "//h2[contains(text(),'Human Resources - Find employee')]";
        private string inputEmployeeName = "//input[@id='employee-name']";
        private string btnSearch = "//input[@id='btnSearch']";
        private string tableEmployeeDetails = "//table[@id='employee-details']";
        private string txtDepartment = "//td[@class='employee department']";
        private string txtEmployeeName = "//td[@class='employee name']";


        public EmployeePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool EmployeePageIsDisplayed()
        {
            return IsDisplayed(driver, titleFindEmployee);
        }

        public void FillEmployeeNameInput(string employeeName)
        {
            FillField(driver, inputEmployeeName, employeeName);
        }

        public void ClickSearchBtn()
        {
            ClickOn(driver, btnSearch);
        }

        public bool EmployeeRecordIsDisplayed()
        {
            return IsDisplayed(driver, tableEmployeeDetails);
        }

        public string GrabEmployeeName()
        {
            return GrabTextFromElement(driver, txtEmployeeName);
        }

        public string GrabDepartmentName()
        {
            return GrabTextFromElement(driver, txtDepartment);
        }
    }
}
