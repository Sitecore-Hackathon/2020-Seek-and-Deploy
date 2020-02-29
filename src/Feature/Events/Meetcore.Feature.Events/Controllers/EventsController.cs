using System.Diagnostics;
using System.Web.Mvc;
using Meetcore.Feature.Events.Model;
using Meetcore.Feature.Events.Services;
using Sitecore.Abstractions;
using Sitecore.Mvc.Presentation;
using Sitecore.Data;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using Sitecore.Mvc.Configuration;

namespace Meetcore.Feature.Events.Controllers
{
    public class EventsController : Controller
    {
        protected readonly IEventRepository EventRepository;
        protected readonly BaseItemManager ItemManager;

        public EventsController(IEventRepository eventRepository, BaseItemManager itemManager)
        {
            Debug.Assert(eventRepository != null);
            EventRepository = eventRepository;
            ItemManager = itemManager;
        }

        public ActionResult List()
        {
            var dataSourceId = RenderingContext.Current.Rendering.DataSource;
            Session["EventsDataSourceId"] = dataSourceId;
            var eventRoot = Sitecore.Context.Database.GetItem(dataSourceId);
            var events = EventRepository.GetEvents(eventRoot);
            return View(events);
        }

        [HttpPost]
        public ActionResult SearchEvents(string searchValue)
        {
            var resultPageId = "{A5652A84-60AE-4F99-AEE4-41DFE573098D}";
            var item = Sitecore.Context.Database.GetItem(ID.Parse(resultPageId));
            var pathInfo = LinkManager.GetItemUrl(item, new ItemUrlBuilderOptions());
            return RedirectToRoute(MvcSettings.SitecoreRouteName, new { pathInfo = pathInfo.TrimStart(new char[] { '/' }), keyword = searchValue });
        }


        public ActionResult ResultList(string keyword)
        {
            var dataSourceId = Session["EventsDataSourceId"].ToString();
            var eventRoot = Sitecore.Context.Database.GetItem(dataSourceId);
            var events = EventRepository.GetEvents(eventRoot, keyword);
            return View("../Events/List", events);
        }


        public ActionResult CreationForm()
        {
            return View(new EventViewModel());
        }

        [HttpPost]
        public ActionResult SaveEvent(EventViewModel model)
        {
            var parentId = Session["EventsDataSourceId"].ToString();
            var pathInfo = EventRepository.SaveNewEvent(parentId,model);
            return RedirectToRoute(MvcSettings.SitecoreRouteName, new { pathInfo = pathInfo.TrimStart(new char[] { '/' })});
        }
    }
}