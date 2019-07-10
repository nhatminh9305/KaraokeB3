using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace B3.Models
{
    public class SlideModel
    {
        public int Id { get; set; }
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        public string Title { get; set; }
        [StringLength(100, ErrorMessage = "Description cannot be longer than 100 characters.")]
        public string Description { get; set; }
        [StringLength(200, ErrorMessage = "Image cannot be longer than 100 characters.")]
        public string Image { get; set; }
        public byte Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? EditedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
