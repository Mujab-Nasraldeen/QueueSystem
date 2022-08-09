using QueueSystem.Services.Repository;

namespace QueueSystem.Services
{
    public interface IUnitOfWork
    {
        IAppointmentRepository Appointment { get; }
        IPatientRepository Patient { get; }
        IDoctorRepository Doctor { get; }
        IPatientAppointmentRepository PatientAppointment { get; }
        Task Commit();
    }
}
