using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Report.Models
{
    public class Project
    {
        public Project()
        {
            Questions = new List<Question>();
            Reports = new List<Report>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Question> Questions { get; set; }
        public List<Report> Reports { get; set; }
        public bool IsActive
        {
            get { return StartDate < DateTime.Now && EndDate > DateTime.Now; }
        }
        public string ToJson()
        {
            var jasonSerializer = JsonSerializer.Create(new JsonSerializerSettings());
            var jasonWriter = new StringWriter();
            jasonSerializer.Serialize(jasonWriter, this);
            return jasonWriter.ToString();
        }

    }
}
