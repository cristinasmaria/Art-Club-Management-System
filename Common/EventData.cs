// Code written by Balana Ovidiu
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class EventData
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public decimal ParticipationFee { get; set; }
        public int NrParticipants { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int RoomId { get; set; }
        public string RoomName { get; set; }
        
        public bool IsApproved { get; set; }
    }
}
