using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoTask
{
    internal class AddingList
    {
        public int Id { get; set; }
        public Guid ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DuedDate { get; set; }
        public string PriorityLevel { get; set; }
    }
}
