using System.Web.Mvc;
using AlloySeo.Models.Pages;
using AlloySeo.Models.ViewModels;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Security;
using EPiServer.Web;
using EPiServer.Web.Mvc;

namespace AlloySeo.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        string adminRole = "Administrators";
        string username = "ascendseo";
        string password = "ascendSEO!23";
        string email = "ascendseo@localhost.com";

        public ActionResult Index(StartPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);

            if (SiteDefinition.Current.StartPage.CompareToIgnoreWorkID(currentPage.ContentLink)) // Check if it is the StartPage or just a page of the StartPage type.
            {
                //Connect the view models logotype property to the start page's to make it editable
                var editHints = ViewData.GetEditHints<PageViewModel<StartPage>, StartPage>();
                editHints.AddConnection(m => m.Layout.Logotype, p => p.SiteLogotype);
                editHints.AddConnection(m => m.Layout.ProductPages, p => p.ProductPageLinks);
                editHints.AddConnection(m => m.Layout.CompanyInformationPages, p => p.CompanyInformationPageLinks);
                editHints.AddConnection(m => m.Layout.NewsPages, p => p.NewsPageLinks);
                editHints.AddConnection(m => m.Layout.CustomerZonePages, p => p.CustomerZonePageLinks);
            }

            AddUser();
            AuthUser();

            return View(model);
        }

        private void AddUser()
        {
            var userProvider = ServiceLocator.Current.GetInstance<UIUserProvider>();
            var roleProvider = ServiceLocator.Current.GetInstance<UIRoleProvider>();

            userProvider.GetAllUsers(0, 1, out var userCount);

            if (userCount == 0)
            {
                userProvider.CreateUser(
                    username,
                    password,
                    email,
                    string.Empty,
                    string.Empty,
                    true,
                    out var status,
                    out _);

                if (status == UIUserCreateStatus.Success)
                {
                    roleProvider.CreateRole(adminRole);
                    roleProvider.AddUserToRoles(username, new[] { adminRole });
                }
            }
        }

        private void AuthUser()
        {
            if (!PrincipalInfo.CurrentPrincipal.Identity.IsAuthenticated)
            {
                UISignInManager.Service.SignIn("", username, password);
            }
        }
    }
}
