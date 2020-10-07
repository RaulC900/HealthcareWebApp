using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{

    public static class SubjectProcessor
    {
        public static int CreateSubject(string gender, DateTime dateOfBirth, int siteNumber)
        {
            SubjectModel data = new SubjectModel
            {
                Gender = gender,
                DateOfBirth = dateOfBirth,
                SiteNumber = siteNumber
            };

            string sql = @"insert into dbo.Subject (Gender, DateOfBirth, SiteNumber)
                        values (@Gender, @DateOfBirth, @SiteNumber);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<SubjectModel> LoadSubjects()
        {
            string sql = @"select SubjectNumber, Gender, DateOfBirth, SiteNumber 
                        from dbo.Subject;";

            return SqlDataAccess.LoadData<SubjectModel>(sql);
        }

        public static int UpdateSubject(int subjectNumber, string gender, DateTime dateOfBirth, int siteNumber)
        {
            SubjectModel data = new SubjectModel
            {
                SubjectNumber = subjectNumber,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                SiteNumber = siteNumber
            };

            string sql = @"update dbo.Subject
                        set Gender = @Gender, 
                        DateOfBirth = @DateOfBirth, 
                        SiteNumber = @SiteNumber
                        where SubjectNumber = @SubjectNumber;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteSubjectFromTable(int subjectNumber)
        {
            SubjectModel data = new SubjectModel
            {
                SubjectNumber = subjectNumber
            };

            string sql = @"delete from dbo.Subject
                        where SubjectNumber = @SubjectNumber;";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
