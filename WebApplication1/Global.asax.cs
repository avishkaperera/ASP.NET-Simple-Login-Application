using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace DemoLoginApplication
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptResourceDefinition def = new ScriptResourceDefinition();
            def.Path = "~/Scripts/jquery-3.0.0.min.js";
            def.ResourceName = "jquery";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", def);
        }
    }
}