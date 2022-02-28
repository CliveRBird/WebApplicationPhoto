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

            return i;

        }

        public static int Update(Person p)
        {
            int i = 0;

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