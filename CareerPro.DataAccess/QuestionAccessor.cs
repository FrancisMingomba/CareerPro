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
    /// <summary>
    /// Retrieves Questions from database
    /// </summary>
    public class QuestionAccessor
    {
        public static List<Question> RetrieveQuestions()
        {

            var questions = new List<Question>();
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_questions";
            var cmd = new SqlCommand(cmdText, conn){ CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        questions.Add(new Question
                        {
                            Id = reader.GetInt32(0),
                            QxnString = reader.GetString(1)
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
            return questions;
        }
    }
}
