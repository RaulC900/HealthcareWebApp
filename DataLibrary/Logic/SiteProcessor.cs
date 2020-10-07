using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{

    public static class SiteProcessor
    {
        public static int CreateSite(int siteNumber, string address, string siteDoctor)
        {
            SiteModel data = new SiteModel
            {
                SiteNumber = siteNumber,
                Address = address,
                SiteDoctor = siteDoctor
            };

            string sql = @"insert into dbo.Site (SiteNumber, Address, SiteDoctor)
                        values (@SiteNumber, @Address, @SiteDoctor);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<SiteModel> LoadSites()
        {
            string sql = @"select SiteNumber, Address, SiteDoctor  
                        from dbo.Site;";

            return SqlDataAccess.LoadData<SiteModel>(sql);
        }

        public static int UpdateSite(int siteNumber, string address, string siteDoctor)
        {
            SiteModel data = new SiteModel
            {
                SiteNumber = siteNumber,
                Address = address,
                SiteDoctor = siteDoctor
            };

            string sql = @"update dbo.Site 
                        set Address = @Address,
                        SiteDoctor = @SiteDoctor
                        where SiteNumber = @SiteNumber;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteSiteFromTable(int siteNumber)
        {
            SiteModel data = new SiteModel
            {
                SiteNumber = siteNumber
            };

            string sql = @"delete from dbo.Site
                        where SiteNumber = @SiteNumber;";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
