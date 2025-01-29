using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Reservation
{
    public int ReserveID { get; set; }
    public int TiD { get; set; }
    public DateOnly resDate { get; set; }
    public TimeOnly startTime { get; set; }
    public TimeOnly endTime { get; set; }
    public string persFirst { get; set; }
    public string persLast { get; set; }
    public string persEmail { get; set; }
}

