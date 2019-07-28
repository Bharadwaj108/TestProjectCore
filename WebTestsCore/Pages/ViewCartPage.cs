using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestFrameworkCore.Base;
using TestFrameworkCore.Utils.Logger;
using WebTestsCore.Utils;

namespace WebTestsCore.Pages
{
    public class ViewCartPage: BasePage
    {
        IWebElement cartContainer = DriverContext.Driver.FindElement(By.Id("itemDetails"));
        public bool CheckCartItems(string cartItems)
        {
            bool flag = true;
            try
            {
                List<string> cartItemsList = new List<string>(cartItems.Split('|'));
                IList<IWebElement> containerItems = cartContainer.FindElements(By.TagName("a"));
                List<string> missingCartItems = new List<string>();
                foreach (var item in cartItemsList)
                {
                    foreach (var anchors in containerItems)
                    {
                        string anchorText = anchors.Text;
                        if (string.Compare(anchorText, item, true) == 0)
                        {
                            if (flag)
                                flag = true;
                            break;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if (!flag)//record the missing cart items
                    {
                        missingCartItems.Add(item);
                    }
                }
                if (!flag)
                {
                    throw new TestException("Add Items To Cart - Positive test", CustomLogType.Error, "Item " + cartItems + " not found in the shopping cart",null,null);
                }
            }
            catch (System.Exception ex)
            {
                flag = false;
                LogHelper.WriteToLog(MethodBase.GetCurrentMethod().Name, CustomLogType.Error, ex.StackTrace);
            }
            return flag;
        }

    }
}
