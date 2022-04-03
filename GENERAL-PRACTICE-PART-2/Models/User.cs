using System;
using System.Collections.Generic;
using GENERAL_PRACTICE_PART_2.Exceptions;

namespace GENERAL_PRACTICE_PART_2.Models
{
    internal class User
    {
        private static int _id;
        private List<Status> _statuses;
        //List<Status> _statuses = new List<Status>();
        public int Id { get; set; }
        public string Username { get; set; }


        public User(string username)
        {
            _id++;
            Id = _id;
            _statuses = new List<Status>();
            Username = username;
        }

        public void ShareStatus(Status status)
        {
            if (status == null)
                throw new NullReferenceException("Null ola bilmez");
            _statuses.Add(status);
            return;
        }

        public Status GetStatusById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("Id null ola bilmez");
            return _statuses.Find(x => x.Id == id);
            throw new NotFoundException("Tapilmadi");
        }

        public List<Status> GetAllStatuses()
        {
            return _statuses;
        }

        public List<Status> FilterStatusByDate(int? id,DateTime dateTime)
        {
            List<Status> statusCopy=new List<Status>();
            if (id==null)
            {
                throw new NullReferenceException("Null ola bilmez!");
            }
            foreach (var item in _statuses)
            {
                if (item.Id==id)
                {
                    statusCopy.AddRange(_statuses.FindAll(b => b.SharedDate > dateTime));
                    return statusCopy;
                }               
            }
            throw new NotFoundException("Tapilmadi");
        }
    }
}
