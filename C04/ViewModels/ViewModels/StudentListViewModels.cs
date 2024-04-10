using System.Collections.Generic;

namespace ViewModels
{
    public class StudentListViewModel
    {
        public IEnumerable<StudentListItemViewModel> Students { get; set; }
    }

    public class StudentListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassCount { get; set; }
    }
}
