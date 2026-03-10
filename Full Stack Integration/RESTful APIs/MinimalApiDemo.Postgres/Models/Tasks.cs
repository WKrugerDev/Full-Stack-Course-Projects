using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApiDemo.Postgres.Models
{
    public class TaskItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get ; set; }
        public string Name {get ; set; } = string.Empty;
        public bool IsCompleted {get ; set ;}
    }
}