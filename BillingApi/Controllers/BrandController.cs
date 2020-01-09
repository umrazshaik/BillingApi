using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillingClasses.Product;
using BillingLayer.Dao;
using System.Web;
using BillingClasses.Common;

namespace BillingApi.Controllers
{
    [RoutePrefix("api/brands")]
    public class BrandController : ApiController
    {
        private readonly BrandsDao dao;

        public BrandController()
        {
            dao = new BrandsDao();
        }

        [HttpGet,Route("getb")]
        public IHttpActionResult GetBrands(int retailerId)
        {
            try
            {
                var brands = dao.GetBrands(retailerId);
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost,Route("addb")]
        public IHttpActionResult AddBrand([FromBody] Brand objbrand)
        {
            try
            {
                int isAdded = dao.AddBrand(objbrand);
                return Ok(isAdded);
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost,Route("updateb")]
        public IHttpActionResult UpdateBrand([FromBody] Brand objbrand)
        {
            try
            {
                int isUpdated = dao.UpdateBrand(objbrand);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete,Route("deleteb")]
        public IHttpActionResult DeleteBrand(int brandId)
        {
            try
            {
                int isDeleted = dao.DeleteBrand(brandId);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost, Route("import")]
        public IHttpActionResult ImportBrands(int retailId)
        {
            int isImport = 0;
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var dt = Converter.GetDataTableFromExcel(postedFile.InputStream);
                        List<Brand> lstpords = Converter.ConvertDataTableToList<Brand>(dt, Constants.Brands, retailId);
                        if (lstpords?.Count > 0)
                            isImport = dao.ImportBrands(lstpords);
                    }
                }
                return Ok(isImport);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet, Route("export")]
        public IHttpActionResult ExportBrands(int retailerId)
        {
            try
            {
                var brands = dao.GetBrands(retailerId);
                var datatable = Converter.ExportDataTable(Constants.Brands, brands.ToList());
                if (datatable?.Rows?.Count > 0)
                {
                    //convert to
                    return Ok(Converter.WritingDataTableToExcel(datatable));
                }
                return Ok("");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
