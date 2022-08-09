using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueueSystem.Models;
using QueueSystem.Resources;
using QueueSystem.Services;
using QueueSystem.ViewModels;

namespace QueueSystem.Controllers
{
    public class PatientAppointmentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientAppointmentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var pAppointments = await _unitOfWork.PatientAppointment.GetAll()
                .Include(p => p.Patient)
                .ToListAsync();
           
            var response = _mapper.Map<List<PatientAppointment>, List<PatientAppointmentRespDto>>(pAppointments);

            return View(response);
        }

        public async Task<IActionResult> CallingPatientAgain()
        {
            var callPatients = await _unitOfWork.PatientAppointment.GetMany(p => p.IsPresent == false)
                .Include(p => p.Patient)
                .ToListAsync();

            var response = _mapper.Map<List<PatientAppointment>, List<PatientAppointmentRespDto>>(callPatients);

            return View(response);
        }

        public async Task<IActionResult> AssignPatientsToDoctors()
        {
            var viewModel = new AppointmentsFormViewModel
            {
                Appointments = await _unitOfWork.Appointment.GetAllAsync(),
                Patients = await _unitOfWork.Patient.GetAllAsync(),
                Doctors = await _unitOfWork.Doctor.GetAllAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignPatientsToDoctors(AppointmentsFormViewModel model)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    model.Appointments = await _unitOfWork.Appointment.GetAllAsync();
                //    model.Patients = await _unitOfWork.Patient.GetAllAsync();
                //    model.Doctors = await _unitOfWork.Doctor.GetAllAsync();
                //    return View(model);
                //}

                var pAppointment = new PatientAppointment
                {
                    //TicketReferenceId = model.TicketReferenceId,
                    AppointmentId = model.AppointmentId,
                    PatientId = model.PatientId,
                    DoctorId = model.DoctorId,
                };

                await _unitOfWork.PatientAppointment.AddAsync(pAppointment);
                await _unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            
        }
    }
}
