using Busines_Layer.InterFaces;
using Busines_Layer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busines_Layer.Repository
{
    public class GoodsRepo : I_InventoryGeneric<GoodsVM>
    {

        #region Ctor
        private readonly IConfiguration configuration;

        public GoodsRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion


        #region CURD
        public void Creat(GoodsVM obj)
        {

        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<GoodsVM> GetAllData()
        {
            List<GoodsVM> MyList = new List<GoodsVM>();

            SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("Select * from Goods", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                GoodsVM obj = new GoodsVM();
                obj.Id = (int)dt.Rows[i]["Id"];
                obj.GoodsName = dt.Rows[i]["GoodsName"].ToString();
                obj.Count = (int)dt.Rows[i]["Count"];
                MyList.Add(obj);
            }
            return MyList;
        }

        public GoodsVM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public GoodsVM MyLastId()
        {
            throw new NotImplementedException();
        }

        public void Update(GoodsVM obj)
        {
            throw new NotImplementedException();
        }
        #endregion



    }
}
