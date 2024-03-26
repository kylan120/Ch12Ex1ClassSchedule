using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ClassSchedule.Models
{
    public interface IClassScheduleUnitOfWork
    {
        Repository<Class> Classes { get; }
        Repository<Teacher> Teachers { get; }
        Repository<Day> Days { get; }
        void Save();

    }

    
}
