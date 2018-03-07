using Boost.Seo.Ascend.Playground.Models.Pages;
using EPiServer.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Boost.Seo.Ascend.Playground.Business
{
    public class WarningDescriptionEmpty : IValidate<SitePageData>
    {
        public IEnumerable<ValidationError> Validate(SitePageData instance)
        {
            return Enumerable.Empty<ValidationError>();
        }
    }
}