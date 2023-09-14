using System.ComponentModel.DataAnnotations;

namespace MVCRestaurant.Models
{
    public class BaseEntity
    {
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        //TODO: add last deleted date

        [Required]
        public string CreatedBy { get; set; }

        public string? LastModifiedBy { get; set; }
        public string? LastDeletedBy { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsDisable { get; set; }

        public string? Description { get; set; }
    }
}