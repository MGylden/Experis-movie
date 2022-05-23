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
    public class CurrentUserSession
    {
        public CurrentUserSession(int currentUserId, int currentProductId)
        {
            this.currentUserId = currentUserId;
            this.currentProductId = currentProductId;            
        }

        [Index(0)]
        public int currentUserId { get; set; }
        [Index(1)]
        public int currentProductId { get; set; }
     
        public CurrentUserSession()
        {
        }
    }
}
