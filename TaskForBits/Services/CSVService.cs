using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            using (StreamReader reader = new StreamReader(path))
            using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                foreach(BaseUser baseUser in csv.GetRecords<BaseUser>().ToList())
                {
                    users.Add(new User(baseUser));
                }
                return users;
            }
        }
    }
}