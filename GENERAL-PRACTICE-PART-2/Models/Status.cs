using System;
using System.Collections.Generic;
using System.Text;

namespace GENERAL_PRACTICE_PART_2.Models
{
    internal class Status
    {
        private static int _id;
        public int Id { get; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SharedDate { get; set; }
        public Status(string title,string content) 
        {
            _id++;
            Id = _id;
            Title = title;
            Content = content;
            SharedDate = DateTime.Now;
        }


        public void GetStatusInfo()
        {
            Console.WriteLine($"Id: {Id} - Title: {Title} - Content: {Content} - Shared {(int)(DateTime.Now - SharedDate).TotalSeconds} seconds ago.");
        }
    }
}
