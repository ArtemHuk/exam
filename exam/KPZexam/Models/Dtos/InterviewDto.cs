using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos;

public class InterviewDto
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public long CandidateId { get; set; }
    public long InterviewerId { get; set; }
    public DateTime InterviewDate { get; set; }
}
