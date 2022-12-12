using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WebApplication7.Models;

namespace WebApplication7.Data
{
    public class StudentRepository 
    {
        private readonly UniversityContext _context;
        public StudentRepository(UniversityContext c)
        {
            this._context = c;
        } 

        public IEnumerable<string> CoursesUniques()
        {
            return _context.Student.Select(s => s.course).Distinct().ToList();
                             


        }
        public IEnumerable<Student> StudentsbyCourse(string x)
            
        {
            List<Student> liste = new List<Student>();
            try
            {
                liste = _context.Student.Where(s => s.course.ToLower() == x.ToLower()).ToList();
                    
                
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
              
            }
            return liste;

        }
    }
}
