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
    public class ProcessRepo : I_InventoryGeneric<ProcessVM>
    {

        #region Ctor
        private readonly IConfiguration configuration;

        public ProcessRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion


        #region CURD
        public void Creat(ProcessVM obj)
        {
            SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("Insert Into Process Values ('" + obj.CstName + "', '" + obj.Date + "' , '" + obj.ProcessType + "') ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(string id)
        {
            SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("Delete From Process Where Id ='" + id + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<ProcessVM> GetAllData()
        {
            throw new NotImplementedException();
        }

        public ProcessVM GetById(int id)
        {
            throw new NotImplementedException();
        }


        public ProcessVM MyLastId()
        {
            ProcessVM obj = new ProcessVM();
            SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Process ORDER BY ID DESC", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                obj.Id = (int)dt.Rows[i]["Id"];
            }
            return obj;
        }

        public void Update(ProcessVM obj)
        {
            SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand(" update Process Set CstName ='" + obj.CstName + "' , Date ='" + obj.Date + "' , ProcessType ='" + obj.ProcessType + "'  Where Id = '" + obj.Id + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        

    }
}
