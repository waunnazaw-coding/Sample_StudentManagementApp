using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_StudentManagementApp.Models
{
    public class StudentDataModelDapper
    {
        public int StuentId { get; set; }
        public string StuentName { get; set; }
        public string PhoneNum { get; set; }
        public string ClassName { get; set; }
    }

    [Table("StudentTable")]
    public class StudentDataModel
    {
        [Key]
        [Column("StudentId ")]
        public int StudentId { get; set; }

        [Column("StudentName ")]
        public string StudentName { get; set; }

        [Column("PhoneNum ")]
        public string PhoneNum { get; set; }

        [Column("ClassName ")]
        public string ClassName { get; set; }

        public bool DeleteFlag { get; set; }
    }
}
