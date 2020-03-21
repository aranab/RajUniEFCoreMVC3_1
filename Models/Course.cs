﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajUniEFCoreMVC3_1.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; private set; }
    }
}