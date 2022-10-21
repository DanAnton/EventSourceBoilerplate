using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Beersender.API.Read_store
{
    public class ReadContext : DbContext
    {
        public ReadContext(DbContextOptions<ReadContext> options) : base(options)
        {
            
        }

        public DbSet<PackageStatus> PackageStatuses { get; set; }
    }

    public class PackageStatus
    {
        [Key]
        public Guid PackageId { get; set; }

        public string Status { get; set; }
    }
}
