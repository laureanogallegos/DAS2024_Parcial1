using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public static class ConnectionString
    {
        public static string GetConnectionString()
        {
            var _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            var cs = _configuration.GetSection("Connectionstrings");
            var a = cs.GetSection("PARCIAL1");
            return a.Value;
        }
    }
}

