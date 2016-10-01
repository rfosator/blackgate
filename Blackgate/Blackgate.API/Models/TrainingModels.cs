using System;

namespace Blackgate.API.Models
{
    public class CourseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsEnabled { get; set; }
    }   

    public class CourseIdModel : CourseModel
    {
        public int Id { get; set; }
    }

    public class TopicModel
    {        
        public int? ParentId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public byte Progress { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class TopicIdModel : TopicModel
    {
        public int Id { get; set; }
    }
}