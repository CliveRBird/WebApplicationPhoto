using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/*

USE [Photo]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Photos](

[PhotoID][int] IDENTITY(1, 1) NOT NULL,

[Title] [varchar](255) NULL,
	[Description] [varchar](max)NULL,
	[Photo] [varbinary](max)NULL,
PRIMARY KEY CLUSTERED 
(
    [PhotoID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
GO

 */

namespace WebApplicationPhoto
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] PhotoData { get; set; }

    }

    public class Person
    {
        public int PersonID { get; set; } 
        public string NationalInsuranceNumber { get; set; }
        public string FirstName { get; set; }                 
        public string LastName { get; set; }
        public byte Photo { get; set; }
    }

}