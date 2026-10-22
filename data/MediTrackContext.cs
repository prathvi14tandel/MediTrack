
using Microsoft.EntityFrameworkCore;
using MediTrack.Models;

namespace MediTrack.Data
{
    public class MediTrackContext : DbContext
    {
        public MediTrackContext(
            DbContextOptions<MediTrackContext> options)
            : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }
    }
}
