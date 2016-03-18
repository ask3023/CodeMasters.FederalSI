using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeMasters.FederalSI.Repository.Model;

namespace CodeMasters.FederalSI.WebApi.Controllers
{
    public class SolutionController : ApiController
    {
        public Solution mySolution { get; private set; } = new Solution();//default

        // GET: api/Solution
        public IEnumerable<Solution> Get()
        {
            //var localsol = new Solution();
            return mySolution.GetAllSolutions();
        }

        // GET: api/Solution/5
        public Solution Get(string id)
        {
            return mySolution.FindSolutionById(id);
        }

        // GET: api/Solution/name
        [Route("api/Solution/{name}")]
        public Solution GetByName(string name)
        {
            //var localsol = new Solution();
            return mySolution.FindSolutionByName(name);
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
