using System;
using System.Collections.Generic;

namespace ResumeProgram
{
    public class Resume
    {
        private string _name;
        private List<Job> _jobs = new List<Job>();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Job> Jobs
        {
            get { return _jobs; }
        }

        public void Display()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine("Jobs:");
            foreach (Job job in _jobs)
            {
                job.Display();
            }
        }
    }
}
