using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace B3.Models
{
    public class ConfigModel
    {
        public ConfigModel()
        {
            this.CreatedTime = DateTime.Now;
            this.UpdatedTime = DateTime.Now;
        }
        public int Id { get; set; }
    
        [StringLength(30, ErrorMessage = "Title cannot be longer than 30 characters.")]
        [Required]
        public string Title { get; set; }
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        [Required]
        public string Address { get; set; }
        [Phone]
        public string HotLine { get; set; }
        [StringLength(100, ErrorMessage = "Open Time cannot be longer than 50 characters.")]
        public String OpenTime { get; set; }
        public byte Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? EditedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
