# csharp-cucumber-selenium-example
A sample implementation of BDD UI tests with C# / SpecFlow

## Application under test
The feature files, step definitions and page objects were written for https://github.com/andreasneuber/automatic-test-sample-site.
Readme in that repo has further details how to set it up.

### IDE used
Microsoft Visual Studio Community 2022

### Setup 
- git clone 
- Double-click file `csharp-cucumber-selenium-framework.sln`
- Solution opens in Visual Studio
- Go to "Extensions" > "Manage Extensions" and get "SpecFlow for Visual Studio 2022"
- Right-click on solution, build solution
- Go to "View" and open the "Test Explorer" window
- Click green "Run All Tests In View" button

### Updating
Especially ChromeDriver needs frequent updating.
- Go to "Tools > NuGet Package Manager > Manage NuGet Packages for Solution..."
- Go to tab "Updates"
- Update
- Right-click on solution, build solution
- Close and reopen solution

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


### FAQ
#### Error "csharp-cucumber-selenium-framework\bin\Debug\chromedriver.exe". Access to the path 'csharp-cucumber-selenium-framework\bin\Debug\chromedriver.exe' is denied.
- Run `taskkill /f /im chromedriver.exe`
- Clean solution
