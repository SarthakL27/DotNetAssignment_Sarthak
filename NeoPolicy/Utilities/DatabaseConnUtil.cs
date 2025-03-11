using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoPolicy.Utilities
{
     static class DatabaseConnUtil
    {
        static IConfiguration _iConfiguration;

        static DatabaseConnUtil()
        {
            GetAppSettingsFile();
        }



        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        }

        public static string GetConnectionString()
        {
            return _iConfiguration.GetConnectionString("DbString");
        }
    }
}
