using System.Collections.Generic;

namespace ViewModels.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}
