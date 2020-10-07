using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public class GenderProcessor
    {
        public static List<GenderModel> LoadGenders()
        {
            string sql = @"select Id, Gender
                        from dbo.Genders;";

            return SqlDataAccess.LoadData<GenderModel>(sql);
        }
    }
}
