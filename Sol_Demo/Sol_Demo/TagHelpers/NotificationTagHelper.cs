using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sol_Demo.TagHelpers
{
    public enum NotificationType
    {
        success = 0,
        error = 1,
        warning = 2
    };

    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("notification")]
    public class NotificationTagHelper : TagHelper
    {
        #region Delcaration

        private readonly IHtmlHelper htmlHelper = null;

        private const string notificationIdAttributeName = "id";
        private const string MessageAttributeName = "message";
        private const string NotificationTypeAttributeName = "notification-type";

        #endregion Delcaration

        #region Constructor

        public NotificationTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        #endregion Constructor

        #region Property

        [HtmlAttributeName(notificationIdAttributeName)]
        public String Id { get; set; }

        [HtmlAttributeName(MessageAttributeName)]
        public String Message { get; set; }

        [HtmlAttributeName(NotificationTypeAttributeName)]
        public NotificationType NotificationTypes { get; set; }

        #endregion Property

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            // Bind Model
            var notificationTagHelperModel = new NotificationTagHelperModel()
            {
                Id = Id,
                Message = Message,
                NotificationTypes = NotificationTypes
            };

            var content = await htmlHelper?.PartialAsync("~/Views/Shared/_NotificationPartialView.cshtml", notificationTagHelperModel);

            output.Content.SetHtmlContent(content);
        }
    }
}