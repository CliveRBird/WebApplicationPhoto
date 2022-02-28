﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using System.IO;

// See
// https://docs.microsoft.com/en-us/sql/relational-databases/security/encryption/develop-using-always-encrypted-with-net-framework-data-provider?view=sql-server-ver15

/*

Use Photo
go

// Tip: Run as Admin the SQL Server Management studio. This then creates the certificate on the local computer.
// MMC with the certificate snap in. Personal>Certificates folder has the certificate present.

CREATE COLUMN MASTER KEY MyCMK  
WITH (  
     KEY_STORE_PROVIDER_NAME = 'MSSQL_CERTIFICATE_STORE',   
     KEY_PATH = 'Current User/Personal/f2260f28d909d21c642a3d8e0b45a830e79a1420'  
   );  
---------------------------------------------  
CREATE COLUMN ENCRYPTION KEY MyCEK   
WITH VALUES  
(  
    COLUMN_MASTER_KEY = MyCMK,   
    ALGORITHM = 'RSA_OAEP',   
    ENCRYPTED_VALUE = 0x01700000016C006F00630061006C006D0061006300680069006E0065002F006D0079002F003200660061006600640038003100320031003400340034006500620031006100320065003000360039003300340038006100350064003400300032003300380065006600620063006300610031006300284FC4316518CF3328A6D9304F65DD2CE387B79D95D077B4156E9ED8683FC0E09FA848275C685373228762B02DF2522AFF6D661782607B4A2275F2F922A5324B392C9D498E4ECFC61B79F0553EE8FB2E5A8635C4DBC0224D5A7F1B136C182DCDE32A00451F1A7AC6B4492067FD0FAC7D3D6F4AB7FC0E86614455DBB2AB37013E0A5B8B5089B180CA36D8B06CDB15E95A7D06E25AACB645D42C85B0B7EA2962BD3080B9A7CDB805C6279FE7DD6941E7EA4C2139E0D4101D8D7891076E70D433A214E82D9030CF1F40C503103075DEEB3D64537D15D244F503C2750CF940B71967F51095BFA51A85D2F764C78704CAB6F015EA87753355367C5C9F66E465C0C66BADEDFDF76FB7E5C21A0D89A2FCCA8595471F8918B1387E055FA0B816E74201CD5C50129D29C015895CD073925B6EA87CAF4A4FAF018C06A3856F5DFB724F42807543F777D82B809232B465D983E6F19DFB572BEA7B61C50154605452A891190FB5A0C4E464862CF5EFAD5E7D91F7D65AA1A78F688E69A1EB098AB42E95C674E234173CD7E0925541AD5AE7CED9A3D12FDFE6EB8EA4F8AAD2629D4F5A18BA3DDCC9CF7F352A892D4BEBDC4A1303F9C683DACD51A237E34B045EBE579A381E26B40DCFBF49EFFA6F65D17F37C6DBA54AA99A65D5573D4EB5BA038E024910A4D36B79A1D4E3C70349DADFF08FD8B4DEE77FDB57F01CB276ED5E676F1EC973154F86  
);  
---------------------------------------------  
CREATE TABLE Customers (  
    CustName nvarchar(60)   
        COLLATE  Latin1_General_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = MyCEK,  
        ENCRYPTION_TYPE = RANDOMIZED,  
        ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'),   
    SSN varchar(11)   
        COLLATE  Latin1_General_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = MyCEK,  
        ENCRYPTION_TYPE = DETERMINISTIC ,  
        ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'),   
    Age int NULL  
);  
GO  

CREATE TABLE [dbo].[Patients]
(
[PatientId]     [int] IDENTITY(1,1), 
[SSN]           [char](11) COLLATE Latin1_General_BIN2 ENCRYPTED WITH (ENCRYPTION_TYPE = DETERMINISTIC, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256', COLUMN_ENCRYPTION_KEY = MyCEK) NOT NULL,
[FirstName]     [nvarchar](50) NULL,
[LastName]      [nvarchar](50) NULL, 
[BirthDate]     [date] ENCRYPTED WITH (ENCRYPTION_TYPE = RANDOMIZED, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256', COLUMN_ENCRYPTION_KEY = MyCEK) NOT NULL
PRIMARY KEY CLUSTERED ([PatientId] ASC) ON [PRIMARY]
);
 GO
 
 */


// TODO
// https://docs.microsoft.com/en-us/sql/relational-databases/security/encryption/develop-using-always-encrypted-with-net-framework-data-provider?view=sql-server-ver15

namespace WebApplicationPhoto
{
    public class Encryption
    {

        private static string connstr_encrypted;

        static Encryption()
        {
            //connstr_encrypted = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            connstr_encrypted = ConfigurationManager.ConnectionStrings["connstr_encrypted"].ConnectionString;
        }
        public int insert() 
        {
            int i=0;


            using (SqlConnection connection = new SqlConnection(connstr_encrypted))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = @"INSERT INTO [dbo].[Patients] ([SSN], [FirstName], [LastName], [BirthDate]) VALUES (@SSN, @FirstName, @LastName, @BirthDate);";
                        connection.Open();
                        SqlParameter paramSSN = cmd.CreateParameter();
                        paramSSN.ParameterName = @"@SSN";
                        paramSSN.DbType = DbType.AnsiStringFixedLength;
                        paramSSN.Direction = ParameterDirection.Input;
                        paramSSN.Value = "795-73-9838";
                        paramSSN.Size = 11;
                        cmd.Parameters.Add(paramSSN);

                        SqlParameter paramFirstName = cmd.CreateParameter();
                        paramFirstName.ParameterName = @"@FirstName";
                        paramFirstName.DbType = DbType.String;
                        paramFirstName.Direction = ParameterDirection.Input;
                        paramFirstName.Value = "Catherine";
                        paramFirstName.Size = 50;
                        cmd.Parameters.Add(paramFirstName);

                        SqlParameter paramLastName = cmd.CreateParameter();
                        paramLastName.ParameterName = @"@LastName";
                        paramLastName.DbType = DbType.String;
                        paramLastName.Direction = ParameterDirection.Input;
                        paramLastName.Value = "Abel";
                        paramLastName.Size = 50;
                        cmd.Parameters.Add(paramLastName);

                        SqlParameter paramBirthdate = cmd.CreateParameter();
                        paramBirthdate.ParameterName = @"@BirthDate";
                        paramBirthdate.SqlDbType = SqlDbType.Date;
                        paramBirthdate.Direction = ParameterDirection.Input;
                        paramBirthdate.Value = new DateTime(1996, 09, 10);
                        cmd.Parameters.Add(paramBirthdate);

                        cmd.ExecuteNonQuery();
                    }
                }


            return i;
        }


        public int fetch()
        {
            int i = 0;

            using (SqlConnection connectionString = new SqlConnection(connstr_encrypted))
            {
                using (SqlCommand cmd = connectionString.CreateCommand())
                {

                    cmd.Connection = connectionString;
                    cmd.CommandText = @"SELECT [SSN], [FirstName], [LastName], [BirthDate] FROM [dbo].[Patients] WHERE SSN=@SSN";
                    SqlParameter paramSSN = cmd.CreateParameter();
                    paramSSN.ParameterName = @"@SSN";
                    paramSSN.DbType = DbType.AnsiStringFixedLength;
                    paramSSN.Direction = ParameterDirection.Input;
                    paramSSN.Value = "795-73-9838";
                    paramSSN.Size = 11;
                    cmd.Parameters.Add(paramSSN);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //Console.WriteLine(@"{0}, {1}, {2}, {3}", reader[0], reader[1], reader[2], ((DateTime)reader[3]).ToShortDateString());
                            }
                        }

                    }
                }
            }
            return i;
        }

    }
}