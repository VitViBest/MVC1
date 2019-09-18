using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskMVC1.Helpers
{
    public static class InputListHelper
    {
        public static MvcHtmlString CreateRadioList(this HtmlHelper html, List<string> values, string name)
        {
            var group = new TagBuilder("div");
            group.MergeAttribute("class", " btn-group btn-group-toggle");
            group.MergeAttribute("data-toggle", "buttons");
            foreach (var i in values)
            {
                var label = new TagBuilder("label");
                label.MergeAttribute("class","btn btn-light");
                var input = new TagBuilder("input");
                input.MergeAttribute("type","radio");
                input.MergeAttribute("name",name);
                input.MergeAttribute("autocomplete", "off");
                input.MergeAttribute("value",i);
                label.InnerHtml += input.ToString();
                label.InnerHtml += i;
                group.InnerHtml += label.ToString();
            }
            return new MvcHtmlString(group.ToString());
        }

        public static MvcHtmlString CreateCheckList(this HtmlHelper html, List<string> values, string name)
        {
            var result = new TagBuilder("div");
            int c = 0;
            foreach (var i in values)
            {
                var item = new TagBuilder("div");
                item.MergeAttribute("class", "custom-control custom-switch");
                var label = new TagBuilder("label");
                label.MergeAttribute("class", "custom-control-label");
                label.MergeAttribute("for", $"switch{c}");
                label.InnerHtml += i;
                var input = new TagBuilder("input");
                input.MergeAttribute("type", "checkbox");
                input.MergeAttribute("name", name);
                input.MergeAttribute("class", "custom-control-input");
                input.MergeAttribute("id", $"switch{c++}");
                input.MergeAttribute("value", i);
                item.InnerHtml += input.ToString();
                item.InnerHtml += label.ToString();
                result.InnerHtml += item.ToString();
            }
            return new MvcHtmlString(result.ToString());
        }
    }
}