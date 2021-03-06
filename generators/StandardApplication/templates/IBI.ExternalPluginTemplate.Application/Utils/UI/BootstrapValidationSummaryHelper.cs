﻿using System.Web.Mvc;

/// <summary>
/// Created by Genie <%= TodaysDate %> by verion <%= Version %>
/// </summary>
namespace IBI.<%= Name %>.Application.Utils.UI
{
    public static class BootstrapValidationSummaryHelper
    {
        #region Methods

        /// <summary>
        /// A bootstrap panel to show the jQuery form validation errors
        /// </summary>
        /// <param name="helper">The HtmlHelper</param>
        /// <param name="validationMessage">The message header of the panel</param>
        /// <returns>MvcHtmlString</returns>
        public static MvcHtmlString BootstrapValidationPanel(this HtmlHelper helper, string validationMessage = "Please correct the errors below")
        {
            var retVal = string.Empty;

            retVal += string.Format("<div class=\"{0} panel panel-danger\" data-valmsg-summary=\"true\">", helper.ViewData.ModelState.IsValid ? "validation-summary-valid" : "validation-summary-errors");
            retVal += string.Format("<div class=\"panel-heading\">{0}</div>", validationMessage);
            retVal += string.Format("<div class=\"panel-body\"><ul>");
            foreach (var key in helper.ViewData.ModelState.Keys)
            {
                foreach (var err in helper.ViewData.ModelState[key].Errors)
                    retVal += "<li>" + helper.Encode(err.ErrorMessage) + "</li>";
            }
            retVal += string.Format("</ul></div></div>");
            return new MvcHtmlString(retVal);
        }

        #endregion Methods
    }
}