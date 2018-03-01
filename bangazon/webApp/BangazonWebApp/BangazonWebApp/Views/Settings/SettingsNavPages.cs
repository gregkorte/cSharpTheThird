using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BangazonWebApp.Views.Settings
{
    public static class SettingsNavPages
    {
        public static string ActivePageKey => "ActivePage";

        public static string PaymentOptions => "PaymentOptions";

        public static string PaymentOptionsNavClass(ViewContext viewContext) => PageNavClass(viewContext, PaymentOptions);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}

