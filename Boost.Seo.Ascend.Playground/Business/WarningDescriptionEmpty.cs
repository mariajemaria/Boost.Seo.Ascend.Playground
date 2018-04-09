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
            if (string.IsNullOrEmpty(instance.MetaDescription))
            {
                var error = new ValidationError
                {
                    PropertyName = "MetaDescription",
                    ErrorMessage = "SEO advise: Description shouldn't be empty.",
                    Severity = ValidationErrorSeverity.Warning
                };

                return new List<ValidationError> { error };
            }

            return Enumerable.Empty<ValidationError>();
        }
    }
}