using TestFrameworkCore.Config;
using TestFrameworkCore.Utils.Logger;

namespace TestFrameworkCore.Base
{
    public class BaseStep : Base
    {
        public virtual void NaviateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelper.WriteToLog("Opened the browser !!!");
        }
    }
}
