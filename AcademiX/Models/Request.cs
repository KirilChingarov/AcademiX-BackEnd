using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademiX.Models
{
    public enum RequestStatus
    {
        Draft,
        Send,
        Waiting,
        Accepted,
        Rejected
    }

    public class Request
    { 
            public int Id { get; set; }
            public int StudentId { get; set; }
            public int DegreeSupervisorId { get; set; }
            public int DegreeId { get; set; }
            public RequestStatus Status { get; set; }
     }
}
