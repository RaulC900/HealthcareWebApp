using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public class SubjectMedicationProcessor
    {
        public static int AddSubjectMedication(int medicationId, int quantity, int subjectId, int siteId)
        {
            SubjectMedicationModel data = new SubjectMedicationModel
            {
                MedicationId = medicationId,
                Quantity = quantity,
                SubjectId = subjectId,
                SiteId = siteId
            };

            string sql = @"insert into dbo.SubjectsInventory (MedicationId, Quantity, SubjectId, SiteId)
                        values (@MedicationId, @Quantity, @SubjectId, @SiteId);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<SubjectMedicationModel> LoadSubjectMedication(int subjectId)
        {
            SubjectMedicationModel data = new SubjectMedicationModel
            {
                MedicationId = 0,
                Quantity = 0,
                SubjectId = subjectId
            };

            string sql = @"select MedicationId, Quantity, SubjectId, SiteId
                        from dbo.SubjectsInventory
                        where SubjectId = @SubjectId;";

            return SqlDataAccess.LoadSpecificData<SubjectMedicationModel>(sql, data);
        }

        public static int UpdateSubjectMedicationQuantity(int medicationId, int quantity, int subjectId)
        {
            SubjectMedicationModel data = new SubjectMedicationModel
            {
                MedicationId = medicationId,
                Quantity = quantity,
                SubjectId = subjectId
            };

            string sql = @"update dbo.SubjectsInventory
                        set Quantity = Quantity + @Quantity 
                        where MedicationId = @MedicationId
                            and SubjectId = @SubjectId;";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
