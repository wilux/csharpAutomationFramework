Feature: Testing DEMO global SQA site
 #dotnet test -e browser=edge
  Scenario: The user opens successfully DEMO global SQA site
    Given The user opens https://www.globalsqa.com/demo-site/
    Then The user sees 'Automate Selenium/Protractor Automation  Scripts' title