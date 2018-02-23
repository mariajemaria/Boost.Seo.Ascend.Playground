using EPiServer.Core;

namespace Boost.Seo.Ascend.Playground.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
