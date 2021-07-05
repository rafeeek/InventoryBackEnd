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
    public class InventoryProcRepo : I_InventoryGeneric<InventoryProcVM>
    {

        #region Ctor
        private readonly IConfiguration configuration;

        public InventoryProcRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region CURD
        public void Creat(InventoryProcVM obj)
        {
            SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("Insert Into InventoryProc Values ('" + obj.Date + "', '" + obj.Cost + "' , '" + obj.Count + "', '" + obj.ProcessId + "', '" + obj.GoodsId + "') ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(string id)
        {
            SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("Delete From InventoryProc Where Id='" + id + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<InventoryProcVM> GetAllData()
        {
            List<InventoryProcVM> MyList = new List<InventoryProcVM>();

            SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand(
                "Select * From InventoryProc join Goods on InventoryProc.GoodsId = Goods.Id join Process on InventoryProc.ProcessID = Process.Id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                InventoryProcVM obj = new InventoryProcVM();
                obj.Id = (int)dt.Rows[i]["Id"];
                obj.Date = (DateTime)dt.Rows[i]["Date"];
                obj.Count = (int)dt.Rows[i]["Count"];
                obj.Cost = (int)(double)dt.Rows[i]["Cost"];
                obj.GoodsId = (int)dt.Rows[i]["GoodsId"];
                obj.ProcessId = (int)dt.Rows[i]["ProcessId"];
                obj.GoodsName = (string)dt.Rows[i]["GoodsName"];
                obj.ProcessType = (string)dt.Rows[i]["ProcessType"];
                obj.CstName = (string)dt.Rows[i]["CstName"];
                MyList.Add(obj);
            }
            return MyList;
        }

        public InventoryProcVM GetById(int id)
        {
            InventoryProcVM obj = new InventoryProcVM();

            SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand(
            "Select * From InventoryProc join Goods on InventoryProc.GoodsID = Goods.Id join Process on InventoryProc.ProcessID = Process.Id where InventoryProc.Id = '" + id +"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            for (int i = 0; i < dt.Rows.Count; i++)
            {

                obj.Id = (int)dt.Rows[i]["Id"];
                obj.Date = (DateTime)dt.Rows[i]["Date"];
                obj.Count = (int)dt.Rows[i]["Count"];
                obj.Cost = (int)(double)dt.Rows[i]["Cost"];
                obj.ProcessId = (int)dt.Rows[i]["ProcessId"];
                obj.GoodsName = (string)dt.Rows[i]["GoodsName"];
                obj.GoodsId = (int)dt.Rows[i]["GoodsId"];
                obj.ProcessType = (string)dt.Rows[i]["ProcessType"];
                obj.CstName = (string)dt.Rows[i]["CstName"];

            }
            return obj;
        }

        public InventoryProcVM MyLastId()
        {
            throw new NotImplementedException();
        }

        public void Update(InventoryProcVM obj)
        {
            SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("update InventoryProc Set Date ='" + obj.Date + "' , Cost ='" + obj.Cost + "' , Count ='" + obj.Count + "' , ProcessID ='" + obj.ProcessId + "' , GoodsID ='" + obj.GoodsId + "'  Where Id = '" + obj.Id + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
    }
}
