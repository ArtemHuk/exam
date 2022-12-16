using Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class Interview
{
    [Key]
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public long CandidateId { get; set; }
    public Candidate? Candidate { get; set; }
    public long InterviewerId { get; set; }
    public Interviewer? Interviewer { get; set; }
    public DateTime InterviewDate { get; set; }

}
