using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using System.Collections;
using System.Globalization;

namespace Experis_movie.Models
{
    internal class CurrentUserSession
    {


        public CurrentUserSession(string currentUserId, string currentProductId)
        {

            this.currentUserId = currentUserId;
            this.currentProductId = currentProductId;            

        }

        [Index(0)]
        public string currentUserId { get; set; }
        [Index(1)]
        public string currentProductId { get; set; }
        
    }
}
