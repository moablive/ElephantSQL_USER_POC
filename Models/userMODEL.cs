using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElephantSQL.Models
{
    [Table("user")]  // Ensure this matches the actual table name in the database
    public class userMODEL
    {
        [Key]
        [Column("Id")] 
        public int? id { get; set; }

        [Column("Name")]  
        public string? name { get; set; }

        [Column("Email")]  
        public string? email { get; set; }
    }
}
