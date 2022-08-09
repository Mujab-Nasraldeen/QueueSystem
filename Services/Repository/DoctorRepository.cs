using QueueSystem.Models;

namespace QueueSystem.Services.Repository
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {

    }

    #region Implementation
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
    #endregion
}
