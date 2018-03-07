using Boost.Seo.Ascend.Playground.Models.Pages;
using EPiServer.Core;
using System;

namespace Boost.Seo.Ascend.Playground.Models.ViewModels
{
    public class NewsListPageViewModel : PageViewModel<NewsListPage>
    {
        public NewsListPageViewModel(NewsListPage currentPage) : base(currentPage)
        {
        }

        public ListChunk Chunk { get; set; }
    }

    public class ListChunk
    {
        public ContentArea List { get; set; }

        public Guid ContentGuid { get; set; }

        public string LanguageCode { get; set; }

        public int NextPage { get; set; }

        public bool ShowNextPage { get; set; }

        public string ReadMoreNewsListText { get; set; }

        public string FallbackUrl { get; set; }

        public string LoadMoreUrl { get; set; }
    }
}