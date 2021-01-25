# TestTask_P
`.NET 5` `NUnit` `Allure` `Selenium`

This App was created in Microsoft Visual Studio, I recommend to use this IDE for running tests locally.

## Get Started
1) download the Project
2) install or update NuGet packages listed below:
* Allure.Commons ^3.5.0.4 - version
* NUnit ^3.13.0 - version
* NUnit.Allure ^1.0.11 - version
* NUnit.Allure.Steps ^1.0.9 - version
* NUnit3TestAdapter ^3.17.0 - version
* Selenium.Support ^3.141.0 - version
* Selenium.WebDriver ^3.141.0 - version
* Selenium.WebDriver.ChromeDriver (The version must match the version of your Chrome browser)
3) install allure-report ^2.13.8 - version 

For Windows, Allure is available from the Scoop commandline-installer.
To install Allure, download and install Scoop and then execute in the Powershell: 
```
scoop install allure

```
* move `allureConfig.json` file from the root folder to `...\bin\Debug\net5.0`

##To run test cases locally
 
1) Open project in Microsoft Visual Studio
2) Open Test Explorer
3) Select any TestCase in the Test Explorer window 
4) Click on the "Run" button
 
 
##Generate allure report
 
1) Open terminal in the project start folder 
2) Use the following scripts one by one:
```
allure generate --clean 
allure open
```
