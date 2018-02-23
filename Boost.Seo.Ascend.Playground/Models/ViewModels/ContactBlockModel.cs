using System.ComponentModel.DataAnnotations;
using System.Web;
using Boost.Seo.Ascend.Playground.Models.Pages;
using EPiServer.Core;
using EPiServer.Web;

namespace Boost.Seo.Ascend.Playground.Models.ViewModels
{
    public class ContactBlockModel
    {
        [UIHint(UIHint.Image)]
        public ContentReference Image { get; set; }
        public string Heading { get; set; }
        public string LinkText { get; set; }
        public IHtmlString LinkUrl { get; set; }
        public bool ShowLink { get; set; }
        public ContactPage ContactPage { get; set; }
    }
}
