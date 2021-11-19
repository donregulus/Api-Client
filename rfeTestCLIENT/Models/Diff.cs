using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rfeTestCLIENT.Models
{
    public class Diff
    {
        [Required (ErrorMessage ="Required")]
        public string Left  { set; get; }

        [Required(ErrorMessage = "Required")]
        public string Right { set; get; }

        [Required(ErrorMessage = "Required")]
        public string Id    { set; get; }
    }
}