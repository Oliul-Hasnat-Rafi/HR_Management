﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{
    public class AttendanceSummary
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EmpId { get; set; }
        public Guid ComId { get; set; }
        [Required]
        public int DtYear { get; set; }
        [Required]
        public int DtMonth { get; set; }
        public int Present { get; set; }
        public int Late { get; set; }
        public int Absent { get; set; }
        public Company Company { get; set; }
        public Employee Employee { get; set; }
    }

}