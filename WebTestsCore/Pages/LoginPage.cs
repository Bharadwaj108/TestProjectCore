using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using TestFrameworkCore.Base;
using TestFrameworkCore.Config;
using TestFrameworkCore.Utils;
using TestFrameworkCore.Utils.Logger;

namespace WebTestsCore.Pages
{
    public class LoginPage : BasePage
    {
        IWebElement txtUserName = DriverContext.Driver.FindElement(By.Name("username"));
        IWebElement txtPassword = DriverContext.Driver.FindElement(By.XPath("//input[@data-ref='home-login-password']"));
        IWebElement btnLogin = DriverContext.Driver.FindElement(By.XPath("//button[@data-ref='home-login-button']"));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public HomePage Login(string userName)
        {
            string password = "";
            try
            {
                ExcelUtil.PopulateInCollection(Settings.TestDataLocation + "UserLogin.xlsx", "Login");
                //Read the column from the excel data file for the userName
                int rowIndex = ExcelUtil.GetRowNumber("UserName", userName);
                password = ExcelUtil.ReadData(rowIndex, "Password");
                txtUserName.SendKeys(userName);
                txtPassword.SendKeys(password);
                btnLogin.Click();
                //ToDo:Check for successful login
                LogHelper.WriteToLog("Login Successful",CustomLogType.Info, "SuccessfulLogin");
                Thread.Sleep(2000);
            }
            catch (System.Exception ex)
            {
                CurrentPage = null;
                //Log Error
                LogHelper.WriteToLog(MethodBase.GetCurrentMethod().Name, CustomLogType.Error, ex.StackTrace);
                return null;
            }
            return GetInstance<HomePage>();
        }

        public HomePage Login(string userName,string password)
        {            
            try
            {                
                txtUserName.SendKeys(userName);
                txtPassword.SendKeys(password);
                btnLogin.Click();
                //ToDo:Check for successful login
                LogHelper.WriteToLog("Login Successful", CustomLogType.Info, "SuccessfulLogin");
                Thread.Sleep(2000);
            }
            catch (System.Exception ex)
            {
                CurrentPage = null;
                //Log Error
                LogHelper.WriteToLog(MethodBase.GetCurrentMethod().Name, CustomLogType.Error, ex.StackTrace);
                return null;
            }
            return GetInstance<HomePage>();
        }

    }
}
