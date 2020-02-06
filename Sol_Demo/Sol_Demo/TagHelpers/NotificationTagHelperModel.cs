using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.TagHelpers
{
    public class NotificationTagHelperModel
    {
        public String Id { get; set; }

        public String Message { get; set; }

        public NotificationType NotificationTypes { get; set; }
    }
}