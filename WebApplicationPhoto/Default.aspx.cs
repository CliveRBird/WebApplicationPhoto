using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;

using WebApplicationPhoto;

namespace WebApplicationPhoto
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindData();
                if (DetailsView1.Rows.Count == 0)
                {
                    DetailsView1.ChangeMode(DetailsViewMode.Insert);
                }
            }

        }

        private void BindData()
        {
            List<Photo> photos = PhotoHelper.GetAll();
            DetailsView1.DataSource = photos;
            DetailsView1.DataBind();
        }


        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            DetailsView1.PageIndex = e.NewPageIndex;
            BindData();
        }
        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            DetailsView1.ChangeMode(e.NewMode);
            BindData();
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            Photo p = new Photo();

            TextBox t1 = ((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]);
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert t1:" + t1 + "');", true   );
            TextBox t2 = ((TextBox)DetailsView1.Rows[2].Cells[1].Controls[0]);
            FileUpload fu = ((FileUpload)DetailsView1.Rows[3].Cells[1].Controls[1]);

            p.Title = t1.Text;
            p.Description = t2.Text;

            Stream imgdatastream = fu.PostedFile.InputStream;
            int imgdatalen = fu.PostedFile.ContentLength;
            byte[] imgdata = new byte[imgdatalen];
            int n = imgdatastream.Read(imgdata, 0, imgdatalen);

            p.PhotoData = imgdata;

            PhotoHelper.Insert(p);
            BindData();
        }


        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            Photo p = new Photo();

            TextBox t0 = ((TextBox)DetailsView1.Rows[0].Cells[1].Controls[0]);
            TextBox t1 = ((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]);
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert t1:" + t1 + "');", true   );
            TextBox t2 = ((TextBox)DetailsView1.Rows[2].Cells[1].Controls[0]);
            FileUpload fu = ((FileUpload)DetailsView1.Rows[3].Cells[1].Controls[1]);

            ////p.PhotoID = Convert.ToInt32(DetailsView1.DataKey[0]);
            p.PhotoID = Convert.ToInt32(t0.Text);
            p.Title = t1.Text;
            p.Description = t2.Text;

            Stream imgdatastream = fu.PostedFile.InputStream;
            int imgdatalen = fu.PostedFile.ContentLength;
            byte[] imgdata = new byte[imgdatalen];
            int n = imgdatastream.Read(imgdata, 0, imgdatalen);

            p.PhotoData = imgdata;

            PhotoHelper.Update(p);
            BindData();
        }

        protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.RowIndex);
           
            int photoid = rowIndex;
            PhotoHelper.Delete(photoid);
            BindData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                Encryption encryptedPatient = new Encryption();

                encryptedPatient.insert();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message.ToString();
            }

        }


    }
}