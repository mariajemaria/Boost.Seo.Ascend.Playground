using System.Web.Routing;
using Boost.Seo.Ascend.Playground.Models.Pages;
using EPiServer.Web.Routing;
using EPiServer.Web.Routing.Segments;

namespace Boost.Seo.Ascend.Playground.Business
{
    public class ParameterPartialRouter : IPartialRouter<NewsListPage, NewsListPage>
    {
        public PartialRouteData GetPartialVirtualPath(NewsListPage content, string language, RouteValueDictionary routeValues, RequestContext requestContext)
        {
            return null;
        }

        public object RoutePartial(NewsListPage content, SegmentContext segmentContext)
        {
            var remainingPath = segmentContext.RemainingPath;

            var nextValue = segmentContext.GetNextValue(remainingPath);

            if (int.TryParse(nextValue.Next, out int pageNumber))
            {
                segmentContext.RouteData.Values["nextPage"] = pageNumber;
                segmentContext.RemainingPath = nextValue.Remaining;
            }

            return content;
        }
    }
}