using DataConnection;
using DataModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class QuestionsDA
    {

        public void AddExam(QuestionsModel qts)
        {
            DBUtilities utility = new DBUtilities();
            utility.cn.Open();
        
           
            utility.cmd.CommandText = "INSERT INTO Questions(Topic, Description, Question1, Question2, Question3, Question4,A1, A2, A3, A4, B1, B2, B3, B4,C1, C2, C3, C4, D1, D2, D3, D4,True1, True2, True3, True4, InsertedDate) VALUES ('" + qts.Topic.Replace("'", " ") + "', '"+ qts.Description.Replace("'"," ") + "', '"
                + qts.Questions1 + "', '"+ qts.Questions2 + "', '"+ qts.Questions3 + "', '"+ qts.Questions4 + "', '"+ qts.ReplyA1 + "', '"+ qts.ReplyA2 + "', '"+ qts.ReplyA3 + "', '"+ qts.ReplyA4 + "', '"+ qts.ReplyB1 + "', '"+ qts.ReplyB2 + "', '"+ qts.ReplyB3 + "', '"+ qts.ReplyB4 + "', '"+ qts.ReplyC1 +"', '"+ qts.ReplyC2 +"', '"+ qts.ReplyC3 +"', '"+qts.ReplyC4 +"', '"+ qts.ReplyD1+"', '"+ qts.ReplyD2 + "', '"+ qts.ReplyD3 + "', '"+ qts.ReplyD4  + "', '"+ qts.TrueReply1 + "', '"+ qts.TrueReply2 + "', '"+ qts.TrueReply3 + "', '"+ qts.TrueReply4 + "', '"+ DateTime.Now +"' )";
            
            utility.cmd.ExecuteScalar();

            utility.endC();
        }

        public List<QuestionsModel> ListQuestions()
        {
            List<QuestionsModel> QuestList = new List<QuestionsModel>();
            DBUtilities utility = new DBUtilities();
            utility.cn.Open();
            utility.cmd.CommandText = "select * from Questions";
            utility.cmd.ExecuteScalar();
            SqliteDataReader dr = utility.cmd.ExecuteReader();

            while (dr.Read())
            {
                QuestionsModel tdm = new QuestionsModel();
                tdm.ID = Convert.ToInt32(dr["ID"]);
                tdm.Topic = dr["Topic"].ToString();
                tdm.InsertedDate = Convert.ToDateTime(dr["InsertedDate"]);
                QuestList.Add(tdm);
            }

            dr.Close();
            utility.endC();
            return QuestList;
        }

        public void DeleteExam(int ID)
        {

            DBUtilities utility = new DBUtilities();
            utility.cn.Open();
            utility.cmd.CommandText = "DELETE FROM Questions WHERE ID = "+ ID;
            utility.cmd.ExecuteScalar();
            utility.endC();
        }

        public QuestionsModel DetailExam(int ID)
        {
            DBUtilities utility = new DBUtilities();
            utility.cn.Open();
            utility.cmd.CommandText = "Select * From Questions WHERE ID = " + ID;
            utility.cmd.ExecuteScalar();
            SqliteDataReader dr = utility.cmd.ExecuteReader();
            QuestionsModel odm = new QuestionsModel();

            while (dr.Read())
            {
                odm.ID = Convert.ToInt32(dr["ID"]);
                odm.Topic = dr["Topic"].ToString().Trim();
                odm.Description = dr["Description"].ToString().Trim();
                odm.Questions1 = dr["Question1"].ToString().Trim();
                odm.Questions2 = dr["Question1"].ToString().Trim();
                odm.Questions3 = dr["Question1"].ToString().Trim();
                odm.Questions4 = dr["Question1"].ToString().Trim();


                odm.ReplyA1 = dr["A1"].ToString().Trim();
                odm.ReplyA2 = dr["A2"].ToString().Trim();
                odm.ReplyA3 = dr["A3"].ToString().Trim();
                odm.ReplyA4 = dr["A4"].ToString().Trim();


                odm.ReplyB1 = dr["B1"].ToString().Trim();
                odm.ReplyB2 = dr["B2"].ToString().Trim();
                odm.ReplyB3 = dr["B3"].ToString().Trim();
                odm.ReplyB4 = dr["B4"].ToString().Trim();


                odm.ReplyC1 = dr["C1"].ToString().Trim();
                odm.ReplyC2 = dr["C2"].ToString().Trim();
                odm.ReplyC3 = dr["C3"].ToString().Trim();
                odm.ReplyC4 = dr["C4"].ToString().Trim();


                odm.ReplyD1 = dr["D1"].ToString().Trim();
                odm.ReplyD2 = dr["D2"].ToString().Trim();
                odm.ReplyD3 = dr["D3"].ToString().Trim();
                odm.ReplyD4 = dr["D4"].ToString().Trim();


                odm.TrueReply1 = dr["True1"].ToString().Trim();
                odm.TrueReply2 = dr["True2"].ToString().Trim();
                odm.TrueReply3 = dr["True3"].ToString().Trim();
                odm.TrueReply4 = dr["True4"].ToString().Trim();



            }

            utility.endC();

            return odm;
        }

    }
}
