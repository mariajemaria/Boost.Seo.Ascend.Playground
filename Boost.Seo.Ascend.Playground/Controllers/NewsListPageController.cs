using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using EPiServer.ServiceLocation;
using Boost.Seo.Ascend.Playground.Models.Pages;
using Boost.Seo.Ascend.Playground.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Routing;

namespace Boost.Seo.Ascend.Playground.Controllers
{
    public class NewsListPageController : PageControllerBase<NewsListPage>
    {
        private Injected<UrlResolver> UrlResolver;
        private Injected<IContentLoader> ContentLoader;

        public ViewResult Index(NewsListPage currentPage, int nextPage = 0)
        {
            var chunk = GetListChunk(currentPage.ContentGuid, currentPage.Language.Name, nextPage);

            // nextPage = 3
            // /news-list/2
            // /news-list/4

            var url = UrlResolver.Service.GetUrl(currentPage);

            var viewModel = new NewsListPageViewModel(currentPage)
            {
                Chunk = chunk
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult More(Guid contentGuid, string languageCode, int nextPage)
        {
            if (contentGuid == Guid.Empty || string.IsNullOrEmpty(languageCode))
            {
                return null;
            }

            var viewModel = GetListChunk(contentGuid, languageCode, nextPage);

            return PartialView("NewsListChunk", viewModel);
        }

        private ListChunk GetListChunk(Guid contentGuid, string languageCode, int currentChunk)
        {
            var currentCulture = CultureInfo.GetCultureInfo(languageCode);
            var currentPage = ContentLoader.Service.Get<NewsListPage>(contentGuid, currentCulture);

            var years = ContentLoader.Service.GetChildren<PageData>(currentPage.ContentLink, currentCulture);

            var allPages = new List<PageData>();

            foreach (var year in years)
            {
                var yearPage = ContentLoader.Service.Get<PageData>(year.ContentLink, currentCulture);
                var listPages = ContentLoader.Service.GetChildren<PageData>(yearPage.ContentLink, currentCulture).ToList();

                foreach (var listPage in listPages)
                {
                    allPages.Add(listPage);
                }
            }

            var pageSize = 2;
            var totalNoOfItems = allPages.Count;
            var chunkedListPages = allPages.Skip(currentChunk * pageSize).Take(pageSize).ToList();

            var list = new ContentArea();
            foreach (var newsPage in chunkedListPages)
            {

                list.Items.Add(new ContentAreaItem { ContentLink = newsPage.ContentLink });
            }

            var nextPage = currentChunk + 1;
            var viewModel = new ListChunk
            {
                List = list,
                ShowNextPage = totalNoOfItems > nextPage * pageSize,
                NextPage = nextPage,
                LanguageCode = currentPage.Language.Name,
                ContentGuid = currentPage.ContentGuid,
                ReadMoreNewsListText = "Show more",
                FallbackUrl = $"{UrlResolver.Service.GetUrl(currentPage.ContentLink)}?nextPage={nextPage}",
                LoadMoreUrl = $"{UrlResolver.Service.GetUrl(currentPage.ContentLink)}more"
            };

            return viewModel;
        }
    }
}
