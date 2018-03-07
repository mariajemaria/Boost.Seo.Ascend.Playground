using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Filters;
using Boost.Seo.Ascend.Playground.Business.Rendering;

namespace Boost.Seo.Ascend.Playground.Models.Pages
{
    [ContentType(GUID = "D46C680F-60C2-4C1E-BB81-316EE95B8AE7")]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new[] { typeof(NewsPage) })]
    [SiteImageUrl]
    public class NewsYearPage : PageData, IContainerPage
    {
        [Display(Order = 50)]
        [Required]
        [Searchable]
        public virtual int Year { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            this[MetaDataProperties.PageChildOrderRule] = FilterSortOrder.PublishedDescending;
        }
    }
}