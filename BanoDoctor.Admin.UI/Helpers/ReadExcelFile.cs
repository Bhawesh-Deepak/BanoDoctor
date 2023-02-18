using BanoDoctor.Admin.UI.Domains;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;


namespace BanoDoctor.Admin.UI.Helpers
{
    public static class ReadExcelFile
    {
        public static List<CandidateDetailModel> ReadExcelData(IFormFile uploadFile)
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            DataSet dsexcelRecords = new DataSet();
            IExcelDataReader reader = null;
            string message = string.Empty;
            Stream stream = uploadFile.OpenReadStream();

            var models = new List<CandidateDetailModel>();

            try
            {
                if (uploadFile != null)
                {
                    if (uploadFile.FileName.EndsWith(".xls"))
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    else if (uploadFile.FileName.EndsWith(".xlsx"))
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    else
                        message = "The file format is not supported.";

                    dsexcelRecords = reader.AsDataSet();
                    reader.Close();

                    if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                    {
                        DataTable inputVatInvoiceDetail = dsexcelRecords.Tables[0];

                        for (int i = 1; i < inputVatInvoiceDetail.Rows.Count; i++)
                        {
                            var model = new CandidateDetailModel();
                            model.RollCode = Convert.ToString(inputVatInvoiceDetail.Rows[i][0]).RemoveNullWithEmptyString();
                            model.RLRW = Convert.ToString(inputVatInvoiceDetail.Rows[i][1]).RemoveNullWithEmptyString();
                            model.ApplicationNumber = Convert.ToString(inputVatInvoiceDetail.Rows[i][2]).RemoveNullWithEmptyString();
                            model.CandidateName = Convert.ToString(inputVatInvoiceDetail.Rows[i][3]).RemoveNullWithEmptyString();
                            model.MotherName = Convert.ToString(inputVatInvoiceDetail.Rows[i][4]).RemoveNullWithEmptyString();
                            model.FatherName = Convert.ToString(inputVatInvoiceDetail.Rows[i][5]).RemoveNullWithEmptyString();
                            model.StatusCode = Convert.ToString(inputVatInvoiceDetail.Rows[i][6]).RemoveNullWithEmptyString();
                            model.MobileNumber = Convert.ToString(inputVatInvoiceDetail.Rows[i][7]).RemoveNullWithEmptyString();
                            model.Nationality = Convert.ToString(inputVatInvoiceDetail.Rows[i][8]).RemoveNullWithEmptyString();
                            model.DateOfBirth = Convert.ToString(inputVatInvoiceDetail.Rows[i][9]).RemoveNullWithEmptyString();
                            model.Gender = Convert.ToString(inputVatInvoiceDetail.Rows[i][10]).RemoveNullWithEmptyString();
                            model.CategoryName = Convert.ToString(inputVatInvoiceDetail.Rows[i][11]).RemoveNullWithEmptyString();
                            model.PH = Convert.ToString(inputVatInvoiceDetail.Rows[i][12]).RemoveNullWithEmptyString();
                            model.Total = Convert.ToString(inputVatInvoiceDetail.Rows[i][13]).RemoveNullWithEmptyString();
                            model.NEETRank = Convert.ToString(inputVatInvoiceDetail.Rows[i][14]).RemoveNullWithEmptyString();
                            model.NEET_CAT_RANK = Convert.ToString(inputVatInvoiceDetail.Rows[i][15]).RemoveNullWithEmptyString();
                            model.APPState = Convert.ToString(inputVatInvoiceDetail.Rows[i][16]).RemoveNullWithEmptyString();
                            model.AppState_N = Convert.ToString(inputVatInvoiceDetail.Rows[i][17]).RemoveNullWithEmptyString();
                            model.CenterNumber = Convert.ToString(inputVatInvoiceDetail.Rows[i][18]).RemoveNullWithEmptyString();
                            models.Add(model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return models;
        }
    }

    public static class StringHelper
    {
        public static string RemoveNullWithEmptyString(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            return value;
        }

    }
}
