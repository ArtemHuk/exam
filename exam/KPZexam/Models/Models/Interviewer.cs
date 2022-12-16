using Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class Interviewer
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string DeveloperDirection { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
}
