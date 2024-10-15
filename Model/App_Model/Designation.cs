using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class Designation
    {
        [Key]
        public Guid DesigId { get; set; } 
        public Guid ComId { get; set; } 
        public string ?DesigName { get; set; }
    }

}