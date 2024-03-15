using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ClassSchedule.Models.DataLayer
{
    public class ClassScheduleUnitOfWork
    {
        private ClassScheduleContext context {  get; set; }

        public ClassScheduleUnitOfWork(ClassScheduleContext ctx) => context = ctx;

        private Repository<Class> classData;
        public Repository<Class> Class
        {
            get{
                if (classData == null)
                    classData = new Repository<Class>(context);
                return classData;
            }
        }

        private Repository<Teacher> teacherData;
        public Repository<Teacher> Teacher
        {
            get
            {
                if (teacherData == null)
                    teacherData = new Repository<Teacher>(context);
                return teacherData;
            }
        }

        private Repository<Day> dayData;
        public Repository<Day> Day
        {
            get
            {
                if (dayData == null)
                    dayData = new Repository<Day>(context);
                return dayData;
            }
        }

        public void Save() => context.SaveChanges();

    }
}
