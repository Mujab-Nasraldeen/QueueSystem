using QueueSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace QueueSystem.ViewModels
{
    public class AppointmentsFormViewModel
    {
        //[Required, StringLength(50)]
        //public string TicketReferenceId { get; set; }

        [Display(Name = "Patient")]
        public Guid PatientId { get; set; }

        public IEnumerable<Patient> Patients { get; set; }

        [Display(Name = "Doctor")]
        public Guid DoctorId { get; set; }

        public IEnumerable<Doctor> Doctors { get; set; }

        [Display(Name = "Appointment")]
        public int AppointmentId { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
