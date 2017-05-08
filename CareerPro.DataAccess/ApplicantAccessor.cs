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
    public class ApplicantAccessor
    {
        public static List<User> RetrieveApplicants()
        {

            var users = new List<User>();
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_applicants";
            var cmd = new SqlCommand(cmdText, conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Phone = reader.GetString(3),
                            AddressLineOne = reader.GetString(4),
                            AddressLineTwo = reader.GetString(5),
                            City = reader.GetString(6),
                            State = reader.GetString(7),
                            Zip = reader.GetString(8),
                            EmailAddress = reader.GetString(9),
                            UserName = reader.GetString(10),
                            Active = reader.GetBoolean(11)
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
            return users;
        }

        public static int CreateApplicant(User user)
        {
            int rowsAffected = 0; 

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_insert_applicant";
            var cmd = new SqlCommand(cmdText, conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Phone", user.Phone);
            cmd.Parameters.AddWithValue("@AddressLine1", user.AddressLineOne);
            cmd.Parameters.AddWithValue("@AddressLine2", user.AddressLineTwo);
            cmd.Parameters.AddWithValue("@City", user.City);
            cmd.Parameters.AddWithValue("@State", user.State);
            cmd.Parameters.AddWithValue("@Zip", user.Zip);
            cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
            cmd.Parameters.AddWithValue("@Username", user.UserName);
            cmd.Parameters.AddWithValue("@Active", user.Active = true);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected;
        }

        public static int CreateResponse(Question response, int applicantId, int jobId)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_insert_response";
            var cmd = new SqlCommand(cmdText, conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@QuestionId", response.Id);
            cmd.Parameters.AddWithValue("@Answer", response.TextAnswer);
            cmd.Parameters.AddWithValue("@ApplicantId", applicantId);
            cmd.Parameters.AddWithValue("@JobId", jobId);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected;
        }
    }
}
