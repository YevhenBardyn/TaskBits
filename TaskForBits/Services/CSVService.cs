using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using TaskForBits.Models;

namespace TaskForBits.Services
{
    public class CSVService
    {
        private readonly DBService dBService = new DBService();
        public void GetUsersFromCsvToDB(HttpPostedFileBase upload)
        {
            using (var reader = new StreamReader(upload.InputStream))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                foreach (BaseUser baseUser in csvReader.GetRecords<BaseUser>().ToList())
                {
                    dBService.SetUserIntoDB(new User(baseUser));
                }
            }
        }
    }
}