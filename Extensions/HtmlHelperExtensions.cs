using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Extensions
{
     // TBD: HTML helpers in ASP.NET -> TAG helpers in Core
    public static class HtmlHelperExtensions
    {
        public static HtmlString HtmlConvertToJson(this IHtmlHelper htmlHelper, object model)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };
            return new HtmlString(
                JsonConvert.SerializeObject(model, settings)
            );
        }

        ////public static MvcHtmlString BuildSortableLink(this HtmlHelper htmlHelper,
        ////    string fieldName, string actionName, string sortField, QueryOptions queryOptions)
        ////{
        ////    var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
        ////    var isCurrentSortField = queryOptions.SortField == sortField;
        ////    return new MvcHtmlString(
        ////        string.Format("<a href=\"{0}\">{1} {2}</a>", 
        ////            urlHelper.Action(
        ////                actionName,
        ////                new
        ////                {
        ////                    SortField = sortField,
        ////                    SortOrder = (isCurrentSortField && queryOptions.SortOrder == SortOrder.ASC) ? SortOrder.DESC : SortOrder.ASC
        ////                }
        ////            ),
        ////            fieldName,
        ////            BuildSortIcon(isCurrentSortField, queryOptions)
        ////        )
        ////    );
        ////}

        ////private static string BuildSortIcon(bool isCurrentSortField, QueryOptions queryOptions)
        ////{
        ////    string sortIcon = "sort";
        ////    if (isCurrentSortField)
        ////    {
        ////        sortIcon += "-by-alphabet";
        ////        if (queryOptions.SortOrder == SortOrder.DESC)
        ////            sortIcon += "-alt";
        ////    }

        ////    return string.Format("<span class=\"{0} {1}{2}\"></span>", "glyphicon", "glyphicon-", sortIcon);
        ////}

        ////public static MvcHtmlString BuildNextPreviousLinks(this HtmlHelper htmlHelper, QueryOptions queryOptions, string actionName)
        ////{
        ////    var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
        ////    return new MvcHtmlString(
        ////        string.Format(
        ////            "<nav>" +
        ////            " <ul class=\"pager\">" +
        ////            " <li class=\"previous {0}\">{1}</li>" +
        ////            " <li class=\"next {2}\">{3}</li>" +
        ////            " </ul>" +
        ////            "</nav>",
        ////            IsPreviousDisabled(queryOptions),
        ////            BuildPreviousLink(urlHelper, queryOptions, actionName),
        ////            IsNextDisabled(queryOptions),
        ////            BuildNextLink(urlHelper, queryOptions, actionName)
        ////        )
        ////    );
        ////}

        ////private static string IsPreviousDisabled(QueryOptions queryOptions)
        ////{
        ////    return (queryOptions.CurrentPage > 1) ? string.Empty : "disabled";
        ////}

        ////private static string IsNextDisabled(QueryOptions queryOptions)
        ////{
        ////    return (queryOptions.CurrentPage < queryOptions.TotalPages) ? string.Empty : "disabled";
        ////}

        ////private static string BuildPreviousLink(UrlHelper urlHelper, QueryOptions queryOptions, string actionName)
        ////{
        ////    return string.Format(
        ////        "<a href=\"{0}\"><span aria-hidden=\"true\">&larr;</span> Previous</a>",
        ////        urlHelper.Action(actionName, new QueryOptions(queryOptions).DecPage())
        ////    );
        ////}

        ////private static string BuildNextLink(UrlHelper urlHelper, QueryOptions queryOptions, string actionName)
        ////{
        ////    return string.Format(
        ////        "<a href=\"{0}\">Next <span aria-hidden=\"true\">&rarr;</span></a>",
        ////        urlHelper.Action(actionName, new QueryOptions(queryOptions).IncPage())
        ////    );
        ////}


        ////// For WebAPI:

        //public static MvcHtmlString BuildKnockoutSortableLink(this HtmlHelper htmlHelper, string fieldName, string actionName, string sortField)
        //{
        //    var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
        //    return new MvcHtmlString(
        //        string.Format(
        //            "<a href=\"{0}\" data-bind=\"click: pagingService.sortEntitiesBy\"" +
        //            " data-sort-field=\"{1}\">{2} " +
        //            "<span data-bind=\"css: pagingService.buildSortIcon('{1}')\"></span></a>",
        //            urlHelper.Action(actionName),
        //            sortField,
        //            fieldName
        //        )
        //    );
        //}

        //public static MvcHtmlString BuildKnockoutNextPreviousLinks(this HtmlHelper htmlHelper, string actionName)
        //{
        //    var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
        //    return new MvcHtmlString(
        //        string.Format(
        //            "<nav>" +
        //            " <ul class=\"pager\">" +
        //            " <li data-bind=\"css: pagingService.buildPreviousClass()\">" +
        //            " <a href=\"{0}\" data-bind=\"click: pagingService.previousPage\">Previous </ a ></ li > " +
        //            " <li data-bind=\"css: pagingService.buildNextClass()\">" +
        //            " <a href=\"{0}\" data-bind=\"click: pagingService.nextPage\">Next</ a ></ li >" +
        //            " </ul>" +
        //            "</nav>",
        //            @urlHelper.Action(actionName)
        //        )
        //    );
        //}
    }
}