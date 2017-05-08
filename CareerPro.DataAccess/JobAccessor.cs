using CareerPro.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPro.DataAccess
{
    public class JobAccessor
    {
        public static List<Job> RetrieveJobs()
        {

            var jobs = new List<Job>();
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_jobs";
            var cmd = new SqlCommand(cmdText, conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        jobs.Add(new Job
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2)
                        });
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return jobs;
        }
    }
}
