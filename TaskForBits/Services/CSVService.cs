using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TaskForBits.Models;

namespace TaskForBits.Services
{
    public class CSVService
    {




        public List<User> GetUsersFromCsv(string path)
        {
            List<User> users = new List<User>();
            using (var reader = new StreamReader(path))
            {
                string header =  reader.ReadLine();
                for (int i = 0; !reader.EndOfStream; i++)
                {
                    var line = reader.ReadLine();
                    string[] values = line.Split(',');
                    users.Add(new User(values));

                }
            }
            return users;
        }
    }
}