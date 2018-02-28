using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BangazonWebApp.Views.Profile
{
    public static class ProfileNavPages
    {
        public static string ActivePageKey => "ActivePage";

        public static string Index => "Index";

        public static string Edit => "Edit";

        public static string PaymentOption => "PaymentOption";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string EditNavClass(ViewContext viewContext) => PageNavClass(viewContext, Edit);

        public static string PaymentOptionNavClass(ViewContext viewContext) => PageNavClass(viewContext, PaymentOption);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}

