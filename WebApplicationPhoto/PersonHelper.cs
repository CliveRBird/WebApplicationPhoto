using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using System.IO;

namespace WebApplicationPhoto
{
    public class PersonHelper
    {
        private static string strConn;

        static PersonHelper()
        {
            strConn = ConfigurationManager.ConnectionStrings["connstr_encrypted"].ConnectionString;
        }

        public static int Insert(Person p)
        {
            int i = 0;

            SqlConnection cnn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "insert into person([NationalInsuranceNumber],[FirstName],[LastName],[Photo]) values (@NationalInsuranceNumber, @FirstName, @LastName, @photo)";

            SqlParameter NationalInsuranceNumber = new SqlParameter("@NationalInsuranceNumber", p.NationalInsuranceNumber);
            SqlParameter FirstName = new SqlParameter("@FirstName", p.FirstName);
            SqlParameter LastName = new SqlParameter("@LastName", p.LastName);
            SqlParameter photo = new SqlParameter("@photo", SqlDbType.VarBinary);
            photo.Value = p.Photo;
            cmd.Parameters.Add(NationalInsuranceNumber);
            cmd.Parameters.Add(FirstName);
            cmd.Parameters.Add(LastName);
            cmd.Parameters.Add(photo);

            cnn.Open();
            i = cmd.ExecuteNonQuery();
            cnn.Close();

            return i;

        }

        public static int Update(Person p)
        {
            int i = 0;

            SqlConnection cnn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "update person set NationalInsuranceNumber=@NationalInsuranceNumber,FirstName=@FirstName,Lastname=@LastName,photo.write(@photo, @offset, @length) where personid = @personid";

            SqlParameter NationalInsuranceNumber = new SqlParameter("@NationalInsuranceNumber", p.NationalInsuranceNumber);
            SqlParameter FirstName = new SqlParameter("@FirstName", p.FirstName);
            SqlParameter LastName = new SqlParameter("@LastName", p.LastName);
            SqlParameter photo = new SqlParameter("@photo", SqlDbType.VarBinary);
            photo.Value = p.Photo;
            SqlParameter offset = new SqlParameter("@offset", SqlDbType.BigInt);
            offset.Value = 0;
            SqlParameter length = new SqlParameter("@length", p.Photo.Length);
            SqlParameter personid = new SqlParameter("@personid", p.PersonID);

            cmd.Parameters.Add(NationalInsuranceNumber);
            cmd.Parameters.Add(FirstName);
            cmd.Parameters.Add(LastName);
            cmd.Parameters.Add(photo);
            cmd.Parameters.Add(offset);
            cmd.Parameters.Add(length);
            cmd.Parameters.Add(personid);

            cnn.Open();
            i = cmd.ExecuteNonQuery();
            cnn.Close();

            return i;
        }

        public static int Delete(int p)
        {
            int i = 0;

            return i;

        }

        public static List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();

            return persons;
        }

        public static Person GetByID(int personid)
        {
            Person p = new Person();

            return p;
        }

    }


}