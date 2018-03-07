using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Boost.Seo.Ascend.Playground.Models.Pages
{
    [ContentType(GUID = "A31FB83C-502E-423B-BD2D-2A232AB10EF1")]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new[] { typeof(NewsYearPage) })]
    public class NewsListPage : SitePageData
    {
    }
}