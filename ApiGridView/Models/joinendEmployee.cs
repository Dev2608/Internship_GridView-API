//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiGridView.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class joinendEmployee
    {        
        public int emp_id { get; set; }

        [Required]
        public string emp_name { get; set; }
        public string emp_email { get; set; }
        public System.DateTime join_date { get; set; }

        [NotMapped]
        public System.DateTime end_date { get; set; }
    }
}
