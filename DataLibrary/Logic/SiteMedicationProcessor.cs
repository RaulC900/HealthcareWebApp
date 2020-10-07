using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public class SiteMedicationProcessor
    {
        public static int AddSiteMedication(int medicationId, int quantity, int siteId)
        {
            SiteMedicationModel data = new SiteMedicationModel
            {
                MedicationId = medicationId,
                Quantity = quantity,
                SiteId = siteId
            };

            string sql = @"insert into dbo.SitesInventory (medicationId, quantity, siteId)
                        values (@medicationId, @quantity, @siteId);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<SiteMedicationModel> LoadSiteMedication(int siteId)
        {
            SiteMedicationModel data = new SiteMedicationModel
            {
                MedicationId = 0,
                Quantity = 0,
                SiteId = siteId
            };

            string sql = @"select MedicationId, Quantity, SiteId  
                        from dbo.SitesInventory
                        where SiteId = @SiteId;";

            return SqlDataAccess.LoadSpecificData<SiteMedicationModel>(sql, data);
        }

        public static int UpdateSiteMedicationQuantity(int medicationId, int quantity, int siteId)
        {
            SiteMedicationModel data = new SiteMedicationModel
            {
                MedicationId = medicationId,
                Quantity = quantity,
                SiteId = siteId
            };

            string sql = @"update dbo.SitesInventory
                        set Quantity = Quantity + @Quantity 
                        where MedicationId = @MedicationId
                            and SiteId = @SiteId;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DecreaseSiteMedicationQuantity(int medicationId, int quantity, int siteId)
        {
            SiteMedicationModel data = new SiteMedicationModel
            {
                MedicationId = medicationId,
                Quantity = quantity,
                SiteId = siteId
            };

            string sql = @"update dbo.SitesInventory
                        set Quantity = Quantity - @Quantity 
                        where MedicationId = @MedicationId
                            and SiteId = @SiteId;";

            return SqlDataAccess.SaveData(sql, data);
        }

    }
}
