using System.ComponentModel.DataAnnotations.Schema;

namespace RepairOfMachine.Models.Entities
{
    public class News
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public User User { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
