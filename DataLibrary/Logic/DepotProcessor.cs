using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public class DepotProcessor
    {
        public static int AddToDepot(int medicationId, int quantity)
        {
            DepotModel data = new DepotModel
            {
                MedicationId = medicationId,
                Quantity = quantity
            };

            string sql = @"insert into dbo.Depot (MedicationId, Quantity)
                        values (@MedicationId, @Quantity);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<DepotModel> LoadDepot()
        {
            string sql = @"select MedicationId, Quantity 
                        from dbo.Depot;";

            return SqlDataAccess.LoadData<DepotModel>(sql);
        }
        
        public static List<DepotModel> LoadDepotMedication(int id)
        {
            DepotModel data = new DepotModel
            {
                MedicationId = id,
                Quantity = 0
            };

            string sql = @"select MedicationId, Quantity 
                        from dbo.Depot
                        where MedicationId = @MedicationId;";

            return SqlDataAccess.LoadSpecificData<DepotModel>(sql, data);
        }

        public static int AddMedicationQuantity(int id, int quantity)
        {
            DepotModel data = new DepotModel
            {
                MedicationId = id,
                Quantity = quantity
            };

            string sql = @"update dbo.Depot 
                        set Quantity = Quantity + @Quantity 
                        where MedicationId = @MedicationId;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DecreaseMedicationQuantity(int id, int quantity)
        {
            DepotModel data = new DepotModel
            {
                MedicationId = id,
                Quantity = quantity
            };

            string sql = @"update dbo.Depot 
                        set Quantity = Quantity - @Quantity 
                        where MedicationId = @MedicationId;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int EditMedQuantity(int id, int quantity)
        {
            DepotModel data = new DepotModel
            {
                MedicationId = id,
                Quantity = quantity
            };

            string sql = @"update dbo.Depot 
                        set Quantity = @Quantity 
                        where MedicationId = @MedicationId;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteDepotMed(int id)
        {
            DepotModel data = new DepotModel
            {
                MedicationId = id
            };

            string sql = @"delete from dbo.Depot
                        where MedicationId = @MedicationId;";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
