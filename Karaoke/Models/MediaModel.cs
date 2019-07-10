using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace B3.Models
{
    public class MediaModel
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public string Image { get; set; }
        public byte Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? EditedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
