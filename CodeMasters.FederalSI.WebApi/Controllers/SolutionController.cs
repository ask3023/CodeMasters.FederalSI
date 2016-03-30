using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeMasters.FederalSI.Repository.Model;
using CodeMasters.FederalSI.Repository;
using System.Web;
using System.IO;
using System.Net.Http.Headers;

namespace CodeMasters.FederalSI.WebApi.Controllers
{
    public class SolutionController : ApiController
    {
        public Solution mySolution { get; private set; } = new Solution();//default
        private MockDataService mockDataService = new MockDataService();
        // GET: api/Solution
        public IHttpActionResult Get()
        {
            // var localsol = new Solution();
            // return Ok<IList<Solution>>(mySolution.GetAllSolutions());
            return Ok<List<SolutionMock>>(mockDataService.BuildSolutions());
        }

        [Route("api/solution/{solutionId}/pager")]
        public HttpResponseMessage GetPager(int solutionId)
        {
            HttpResponseMessage result = null;
            var localFilePath = HttpContext.Current.Server.MapPath("~/App_Data/" + solutionId + "/pager.pdf");

            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition.FileName = string.Format("Pager{0}.pdf", solutionId);

            return result;
        }

        [Route("api/solution/{solutionId}/infoCard")]
        public HttpResponseMessage GetInfoCard(int solutionId)
        {
            HttpResponseMessage result = null;
            var localFilePath = HttpContext.Current.Server.MapPath("~/App_Data/" + solutionId + "/infocard.pdf");

            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition.FileName = string.Format("Pager{0}.pdf", solutionId);

            return result;
        }

        // GET: api/Solution/5
        public IHttpActionResult Get(string id)
        {
            return Ok<Solution>(mySolution.FindSolutionById(id));
        }

        // GET: api/Solution/name
        [Route("api/Solution/{name}")]
        public IHttpActionResult GetByName(string name)
        {
            //var localsol = new Solution();
            return Ok<Solution>(mySolution.FindSolutionByName(name));
        }
        // POST: api/Solution
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Solution/5
        public void Put(string id, [FromBody]string value)
        {
        }

        // DELETE: api/Solution/5
        public void Delete(int id)
        {
        }
    }
}
