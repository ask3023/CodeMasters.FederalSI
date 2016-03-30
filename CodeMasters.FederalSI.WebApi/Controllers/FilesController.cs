using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace CodeMasters.FederalSI.WebApi.Controllers
{
    public class FilesController : ApiController
    {
        public HttpResponseMessage GetDocument(string solution, string title)
        {
            if (!string.IsNullOrEmpty(title))
                return FileAsStream(solution, title);
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        public static HttpResponseMessage FileAsStream(string solution, string title)
        {


            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

            //var document = new SolutionController().GetByName(solution);
            //var stream = document.GetFileByTitle(solution ,title);
            ////if (stream != null)
            ////{
            //    result.Content = new StreamContent(stream);
            //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                //result.Content.Headers.ContentDisposition.FileName = title;
                return result;
            //}
            //else
            //{
            //    return new HttpResponseMessage(HttpStatusCode.NotFound);
            //}
            
            
        }
    }
}
