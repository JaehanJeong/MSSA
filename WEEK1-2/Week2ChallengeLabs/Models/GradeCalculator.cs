using System;
using System.Collections.Generic;
using System.Text;

namespace Week2ChallengeLabs.Models
{
    public class GradeCalculator
    {
        public double CalculateAverage(List<SubjectGrade> grades)
        {
            return grades.Average(g => g.Grade);
        }
        public string GetDivision(double average)
        {
            return average switch
            {
                >= 93 => "First Division",
                >= 85 => "Second Division",
                >= 70 => "Third Division",
                _ => "Fail"
            };
        }
    }
}
