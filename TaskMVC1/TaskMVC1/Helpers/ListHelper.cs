﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskMVC1.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString CreateList(this HtmlHelper html, string[] values,bool isUl)
        {
            var group = new TagBuilder("div");
            var list = new TagBuilder(isUl?"ul":"ol");
            foreach (var i in values)
            {
                var li = new TagBuilder("li");
                li.InnerHtml += i;
                list.InnerHtml += li;
            }
            group.InnerHtml += list;
            return new MvcHtmlString(group.ToString());
        }
    }
}