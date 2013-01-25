using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EFMVC.Web.Core.ActionFilters
{
    /// <summary>
    /// Provides global cover for all controllers that take HTTP POSTs, by adding an anti forgery token.
    /// If the view does not have one, the POST will fail.
    /// </summary>
    public class AntiForgeryTokenFilterProvider : IFilterProvider
    {
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var result = new List<Filter>();

            string incomingVerb = controllerContext.HttpContext.Request.HttpMethod;

            if (String.Equals(incomingVerb, "POST", StringComparison.OrdinalIgnoreCase))
            {
                result.Add(new Filter(new ValidateAntiForgeryTokenAttribute(), FilterScope.Global, null));
            }

            return result;
        }
    }
}
