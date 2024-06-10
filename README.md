# C# BDD Automation Framework
* Note:
This is a basic automation framework that can be expanded upon as needed. It provides a solid foundation for building comprehensive test suites using SpecFlow and Allure.

### IDE used
Microsoft Visual Studio Community 2022 (with .NET desktop development workload)

### Setup 
- git clone 
- Double-click file `csharp-cucumber-selenium-framework.sln`
- Solution opens in Visual Studio
- Go to "Extensions" > "Manage Extensions" and get "SpecFlow for Visual Studio 2022"
- Right-click on solution, build solution
- Go to "View" and open the "Test Explorer" window
- Click green "Run All Tests In View" button

### Running Tests from Terminal:
To execute the example test, use the following command:

```Bash
dotnet test -e browser=edge -e options=--headless
``` 
### Explanation:
#### Specifies the browser to use:
```Bash
-e browser=edge 
``` 
 Supported browsers include firefox, chrome, safari, and edge. Default is edge.

#### Specify options capabilities:
```Bash
-e options=--headless
``` 
```Bash
-e options=--option1, --option2, optionN...
```

### SpecFlow LivingDocs reports locally
[Step-by-step guide for LivingDoc Generator](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/sbsguides/sbscli.html)

### SpecFlow LivingDocs reports on Azure DevOps
To view the "SpecFlow LivingDocs" comfortably [an extension is required](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/Installation/Installation.html).

Step `SpecFlow+ build step.` in file `azure-pipelines.yml` will generate and upload the report.

Report will appear under menu item "Overview > SpecFlow+ LivingDoc".

### Helpful VS keyboard shortcuts
- Duplicate line: `CTRL + E + V`
- Go to definition: `F12`
- Quick code formatting: `Ctrl + K , Ctrl + D`


#### Error "csharp-cucumber-selenium-framework\bin\Debug\chromedriver.exe". Access to the path 'csharp-cucumber-selenium-framework\bin\Debug\chromedriver.exe' is denied.
- Run `taskkill /f /im chromedriver.exe`
- Clean solution
