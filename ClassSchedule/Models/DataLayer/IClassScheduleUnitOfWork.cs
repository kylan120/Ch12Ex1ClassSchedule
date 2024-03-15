using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ClassSchedule.Models.DataLayer
{
    public interface IClassScheduleUnitOfWork
    {
        Repository<Class> ClassRepository { get; }
        Repository<Teacher> TeacherRepository { get; }
        Repository<Day> DayRepository { get; }
        void Save();

    }

    
}
