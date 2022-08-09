using Microsoft.AspNetCore.Mvc;
using QueueSystem.Services;

namespace QueueSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllAppointments()
        {
            var allAppointments = _unitOfWork.Appointment.GetAll().ToList();
            return View(allAppointments);
        }
    }
}
