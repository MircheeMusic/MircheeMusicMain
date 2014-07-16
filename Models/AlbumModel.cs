using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using MircheeMusic.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MircheeMusic.Models
{
    public class AlbumModel
    {
        [DataType(DataType.Text)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Display(Name = "Album Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Album Genre")]
        public string Genre { get; set; }

    }
 

}
