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
            throw new System.NotImplementedException();
        }

        public object RoutePartial(NewsListPage content, SegmentContext segmentContext)
        {
            throw new System.NotImplementedException();
        }
    }
}