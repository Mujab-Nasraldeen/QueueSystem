using QueueSystem.Models;

namespace QueueSystem.Services.Repository
{
    public interface IPatientAppointmentRepository : IBaseRepository<PatientAppointment>
    {

    }

    #region Implementation
    public class PatientAppointmentRepository : BaseRepository<PatientAppointment>, IPatientAppointmentRepository
    {
        public PatientAppointmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
    #endregion
}
