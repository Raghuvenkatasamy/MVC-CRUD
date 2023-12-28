using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace DataAccessLayer
{
   public class MobileDetailsRepository:IMobileDetailsRepository
    {
        public string connectionString;
        public MobileDetailsRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConnection");
        }
        public MobileDetail InsertMVC(MobileDetail MD)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                con.Execute($"exec InsertMobileDetail '{MD.Name}','{MD.ManufactureName}','{MD.DateofMaufacture.ToString("M/d/y")}',{MD.YearofMaufacture},{MD.Quantity}");

                con.Close();

            }
            catch (SqlException sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }
            return MD;

        }
        public IEnumerable<MobileDetail> ReadMVC()
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var products = con.Query<MobileDetail>($"exec ReadMobileDetail");
                con.Close();

                return products.ToList();

            }
            catch (SqlException sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public MobileDetail ReadbynumberSP(long id)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var Details = con.QueryFirstOrDefault<MobileDetail>($"exec ReadbynumMobileDetail {id}");
                con.Close();
                return Details;

            }
            catch (SqlException sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public MobileDetail DeleteRecordMVC(long id)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                var Details = con.QueryFirstOrDefault<MobileDetail>($"exec DeleteMobileDetail {id}");
                con.Close();
                return Details;

            }
            catch (SqlException sql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public MobileDetail UpdateMVC(long id, MobileDetail MDS)
        {
            try
            {
                var sql = new SqlConnection(connectionString);
                sql.Open();
                var product = sql.QueryFirstOrDefault<MobileDetail>($"exec UpdateMobileDetail {id},'{MDS.Name}','{MDS.ManufactureName}','{MDS.DateofMaufacture.ToString("M/d/y")}',{MDS.YearofMaufacture},{MDS.Quantity}");
                sql.Close();
                return product;
            }
            catch (SqlException mssql)
            {
                throw;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
