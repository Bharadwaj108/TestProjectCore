using System;
using System.Reflection;
using TestFrameworkCore.Base;
using TestFrameworkCore.Utils.Logger;
using TestFrameworkCore.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestFrameworkCore.Config;
using WebTestsCore.Utils;
using Bogus;
using WebTestsCore.Context;

namespace WebTestsCore.Pages.SecurePay
{
    public class SecurePayContactUsPage : BasePage
    {
        internal bool ISContactUsPageLoaded()
        {
            try
            {
                //Waiting for the page to load completely
                DriverContext.Driver.WaitWebPageLoad();

                //Now look for some element on the page to make sure
                //we are on the right page
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(DriverContext.Driver);
                fluentWait.Timeout = TimeSpan.FromMilliseconds(Settings.Timeout);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(1000);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                IWebElement txtFirstName = fluentWait.Until(x => x.FindElement(By.Name("first-name")));
                if (txtFirstName is null)
                {
                    throw new TestException("Failed to load the Contact Us Page", CustomLogType.Error, null, null, null);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteToLog(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
                return false;
            }
            return true;
        }

        internal bool FillContactDetails(ContactUs contactUs)
        {
            string logMessage = "The following Contact Details have been aded \n";
            try
            {
                //First Name
                IWebElement txtFirstName = DriverContext.Driver.FindElement(By.Name("first-name"));
                txtFirstName.SendKeys(contactUs.FirstName);
                logMessage = logMessage + "First Name : " + contactUs.FirstName + "\n";

                //Last Name
                IWebElement txtLastName = DriverContext.Driver.FindElement(By.Name("last-name"));
                txtLastName.SendKeys(contactUs.LastName);
                logMessage = logMessage + "Last Name : " + contactUs.LastName + "\n";

                //Email
                IWebElement txtEmail = DriverContext.Driver.FindElement(By.Name("email-address"));
                txtEmail.SendKeys(contactUs.Email);
                logMessage = logMessage + "Email : " + contactUs.Email + "\n";

                //Phone
                IWebElement txtPh = DriverContext.Driver.FindElement(By.Name("phone-number"));
                txtPh.SendKeys(contactUs.Phone);
                logMessage = logMessage + "Phone : " + contactUs.Phone + "\n";

                //Website URL
                IWebElement txtUrl = DriverContext.Driver.FindElement(By.Name("website-url"));
                txtUrl.SendKeys(contactUs.WebSiteUrl);
                logMessage = logMessage + "Web Site URL : " + contactUs.WebSiteUrl + "\n";

                //Company
                IWebElement txtCompany = DriverContext.Driver.FindElement(By.Name("business-name"));
                txtCompany.SendKeys(contactUs.Company);
                logMessage = logMessage + "Company : " + contactUs.Company + "\n";

                //Reason of Enquiry                
                IWebElement dropdownReason = DriverContext.Driver.FindElement(By.Name("reason-for-enquiry"));
                var selectOption = new SelectElement(dropdownReason);
                selectOption.SelectByValue(contactUs.ReasonOfEnquiry);
                logMessage = logMessage + "Reason for Enquiry : " + contactUs.ReasonOfEnquiry + "\n";

                LogHelper.WriteToLog(logMessage, CustomLogType.Info, "ContactUsDetails");
            }
            catch (Exception ex)
            {

                LogHelper.WriteToLog(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
                return false;
            }
            return true;
        }

        internal ContactUs PrepareRandomTestData()
        {           
            ContactUs contactUs = null;
            try
            {
                var testData = new Faker<ContactUs>()
                    //Optional: Call for objects that have complex initialization
                    .CustomInstantiator(f => new ContactUs())

                    //Basic rules using built-in generators
                    .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                    .RuleFor(u => u.LastName, f => f.Name.LastName())
                    .RuleFor(u => u.Phone, f => f.Person.Phone)
                    .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                    .RuleFor(u => u.WebSiteUrl, f => f.Internet.Url())
                    .RuleFor(u => u.Company, f => f.Company.CompanyName());
                contactUs = testData.Generate();
                contactUs.ReasonOfEnquiry = "Support";
            }
            catch (Exception ex)
            {
                LogHelper.WriteToLog(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
                return null ;
            }
            return contactUs;
        }
    }
}
