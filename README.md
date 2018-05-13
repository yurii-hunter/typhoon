[![Build status](https://ci.appveyor.com/api/projects/status/lm7wvebmdfp57d67/branch/master?svg=true)](https://ci.appveyor.com/project/yurii_hunter/macro-specflow/branch/master)

# typhoon
Automation Framework

# Installation
Install **Typhoon NuGet** package into your project.

> PS> Install-Package Typhoon

After installing NuGet package your project will be modified. *Typhoon.dll.config* file will be added.

# Configuration
All settings are stored in *Typhoon.dll.config* file which was added into your project by nuget installation.

```xml
<configuration>
	<configSections>
		<section name="typhoon" type="Typhoon.Configuration.TyphoonSection, Typhoon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"/>
	</configSections>
	<typhoon>
		<timeout explicitWait="25" implicitWait="5" existsWait="2"/>
		<webDriver name="chrome"/>
		<application baseUrl="https://aqa.works"/>
	</typhoon>
</configuration>
```

## Configuration Elements
**\<timeout\>**

| Property|                  Description               |
|---------|--------------------------------------------|
|explicitWait|The max time that page factory waits for an element|
|implicitWait|Retry time for finding an element  |
|existsWait|The max time that factory waits for checking that element exists  |

**\<webDriver\>**
| Property|                  Description               |
|---------|--------------------------------------------|
|name| Type of web driver. Could be one of *chrome*, *firefox*, *iexploler* |

**\<application\>**
| Property|                  Description               |
|---------|--------------------------------------------|
|baseUrl| |The base URL of your application|

# Example
Sample project you can download [here](https://github.com/yurii-hunter/typhoon-sample). The custom page factory can resolve nested items. It means you can declare web elements inside another.

Let's implement simple login page where you can see how yo use it.
```csharp
class LoginForm : HtmlElement
{
    [FindBy(How.CssSelector, "#username")]
    public TextBox UserName { get; set; }

    [FindBy(How.CssSelector, "#password")]
    public TextBox Password { get; set; }

    [FindBy(How.CssSelector, ".login")]
    public Button Login { get; set; }
}

[Url("/")]
class HomePage : WebPage
{
    [FindBy(How.CssSelector, ".login-form")]
    public LoginForm LoginForm { get; set; }
}

var home = = PageFactory.Get<HomePage>();
home.Open();
home.LoginForm.UserName.SetText("login");
home.LoginForm.Password.SetText("password");
home.LoginForm.Login.Click();
```