﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Model.App_Model
{

    public class Attendance
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ComId { get; set; }

        public Guid EmpId { get; set; }

        [Required, StringLength(20)]
        public string AttStatus { get; set; }

        public DateTime InTime { get; set; }

        public DateTime OutTime { get; set; }

        [ForeignKey("ComId")]
        public virtual Company? Companyeeee { get; set; }

        [ForeignKey("EmpId")]
        public virtual Employee? Employeeeeeeeeeeeee { get; set; }
    }

}