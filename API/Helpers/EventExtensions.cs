// Code written by Balana Ovidiu
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public static class EventExtensions
    {
        public static void UpdateIsApproved(this Event eventToUpdate, bool isApproved)
        {
            eventToUpdate.IsApproved = isApproved;
        }

    }
}
