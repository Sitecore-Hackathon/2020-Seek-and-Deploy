using System.Diagnostics;
using System.Web.Mvc;
using Meetcore.Feature.Events.Services;
using Sitecore.Mvc.Presentation;

namespace Meetcore.Feature.Events.Controllers
{
    public class EventsController : Controller
    {
        protected readonly IEventRepository EventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            Debug.Assert(eventRepository != null);
            EventRepository = eventRepository;
        }

        public ActionResult List()
        {
            var eventRoot = RenderingContext.Current.ContextItem;
            var events = EventRepository.GetEvents(eventRoot);
            return View(events);
        }
    }
}