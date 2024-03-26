using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ClassSchedule.Models
{
    public class ClassScheduleUnitOfWork : IClassScheduleUnitOfWork
    {
        private ClassScheduleContext context {  get; set; }
        public ClassScheduleUnitOfWork(ClassScheduleContext context)
        {
            this.context = context;
        }

        private Repository<Teacher> TeacherData {  get; set; }
        public Repository<Teacher> Teachers 
        {
            get
            {
                if (TeacherData == null)
                {
                    TeacherData = new Repository<Teacher>(context);
                }
                return TeacherData;
            }
        }
        private Repository<Class> ClassData { get; set; }
        public Repository<Class> Classes
        {
            get
            {
                if (ClassData == null)
                {
                    ClassData = new Repository<Class>(context);
                }
                return ClassData;
            }
        }
        private Repository<Day> DayData { get; set; }
        public Repository<Day> Days
        {
            get
            {
                if (DayData == null)
                {
                    DayData = new Repository<Day>(context);
                }
                return DayData;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }


    }
}
