using System.Diagnostics;
using System.Web.Mvc;
using Meetcore.Feature.Events.Services;
using Sitecore.Abstractions;
using Sitecore.Mvc.Presentation;
using Sitecore.Data;

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
            var eventRoot = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
            var events = EventRepository.GetEvents(eventRoot);
            return View(events);
        }
    }
}