using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.MvcWebUI.Areas.Admin.ViewModels
{
    public class MessageViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string CssClass { get; set; }
        public string Url { get; set; }
        public string LinkText { get; set; }
    }
}