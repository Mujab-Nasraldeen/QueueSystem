using QueueSystem.Models;

namespace QueueSystem.Services.Repository
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {

    }

    #region Implementation
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
    #endregion
}
