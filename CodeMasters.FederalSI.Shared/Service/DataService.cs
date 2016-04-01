using CodeMasters.FederalSI.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeMasters.FederalSI.Shared.Service
{
    public class DataService
    {
        public List<Solution> GetSolutions()
        {
            Task<List<Solution>> solutions = GetSolutionsFromAPI();
            var retSolutions = solutions.Result;
            // var retSolutions = this.BuildSolutions();

            return retSolutions;
        }

        private async Task<List<Solution>> GetSolutionsFromAPI()
        {
            string apiUrl = "http://federalsi.azurewebsites.net/api/solution";
            // string apiUrl = "http://23.96.103.159:80/api/solution";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            string solutionJson = await response.Content.ReadAsStringAsync();

            var solutions = JsonHelper.Deserialize<List<Solution>>(solutionJson);

            return solutions;
        }

        private List<Solution> BuildSolutions()
        {
            List<Solution> solutions = new List<Solution>();
            Solution dConnect = new Solution()
            {
                Id = 2,
                Name = "DConnect"
            };
            dConnect.EVDCollection.Add(BuildEVDItem(EVDType.Code));
            dConnect.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            dConnect.EVDCollection.Add(BuildEVDItem(EVDType.Requirement));
            dConnect.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));

            solutions.Add(dConnect);

            Solution dotAgile = new Solution()
            {
                Id = 1,
                Name = "DotAgile"
            };

            dotAgile.Contacts.Add(new Pointofcontact { Name = "Brian Breit", Email = @"bbreit@deloitte.com", Designation = "Partner" });
            dotAgile.Contacts.Add(new Pointofcontact { Name = "Azunna Anyanwu", Email = @"aanyanwu@deloitte.com", Designation = "Manager" });
            dotAgile.Contacts.Add(new Pointofcontact { Name = "Jason Bowers", Email = @"Jbowers@deloitte.com", Designation = "Director" });

            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Project));
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Code));
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Requirement));
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));

            solutions.Add(dotAgile);


            Solution legacyModernization = new Solution()
            {
                Id = 4,
                Name = "Legacy Modernization"
            };

            legacyModernization.EVDCollection.Add(BuildEVDItem(EVDType.ProjectHealthMetrics));
            legacyModernization.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            legacyModernization.EVDCollection.Add(BuildEVDItem(EVDType.TrainingAndChange));
            legacyModernization.EVDCollection.Add(BuildEVDItem(EVDType.KeyImpactDeliverables));

            solutions.Add(legacyModernization);


            Solution solution01 = new Solution()
            {
                Id = 3,
                Name = "Solution01"
            };

            solution01.EVDCollection.Add(BuildEVDItem(EVDType.Code));
            solution01.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            solution01.EVDCollection.Add(BuildEVDItem(EVDType.Requirement));
            solution01.EVDCollection.Add(BuildEVDItem(EVDType.KeyImpactDeliverables));

            solutions.Add(solution01);

            Solution solution02 = new Solution()
            {
                Id = 5,
                Name = "Solution02"
            };

            solution02.EVDCollection.Add(BuildEVDItem(EVDType.Code));
            solution02.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            solution02.EVDCollection.Add(BuildEVDItem(EVDType.Project));
            solution02.EVDCollection.Add(BuildEVDItem(EVDType.ProjectHealthMetrics));
            solution02.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));

            solutions.Add(solution02);

            Solution solution03 = new Solution()
            {
                Id = 6,
                Name = "Solution03"
            };

            solution03.EVDCollection.Add(BuildEVDItem(EVDType.Code));
            solution03.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            solution03.EVDCollection.Add(BuildEVDItem(EVDType.Project));
            solution03.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));

            solutions.Add(solution03);


            Solution solution04 = new Solution()
            {
                Id = 7,
                Name = "Solution04"
            };

            solution04.EVDCollection.Add(BuildEVDItem(EVDType.Requirement));
            solution04.EVDCollection.Add(BuildEVDItem(EVDType.KeyImpactDeliverables));
            solution04.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));

            solutions.Add(solution04);


            Solution solution05 = new Solution()
            {
                Id = 8,
                Name = "Solution05"
            };

            solution05.EVDCollection.Add(BuildEVDItem(EVDType.Requirement));
            solution05.EVDCollection.Add(BuildEVDItem(EVDType.KeyImpactDeliverables));
            solution05.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));
            solution05.EVDCollection.Add(BuildEVDItem(EVDType.ProjectHealthMetrics));
            solution05.EVDCollection.Add(BuildEVDItem(EVDType.Support));
            solution05.EVDCollection.Add(BuildEVDItem(EVDType.TrainingAndChange));

            solutions.Add(solution05);

            Solution solution06 = new Solution()
            {
                Id = 9,
                Name = "Solution06"
            };

            solution06.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));
            solution06.EVDCollection.Add(BuildEVDItem(EVDType.ProjectHealthMetrics));
            solution06.EVDCollection.Add(BuildEVDItem(EVDType.Support));
            solution06.EVDCollection.Add(BuildEVDItem(EVDType.TrainingAndChange));

            solutions.Add(solution06);

            Solution solution07 = new Solution()
            {
                Id = 10,
                Name = "Solution07"
            };

            solution07.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));
            solution07.EVDCollection.Add(BuildEVDItem(EVDType.ProjectHealthMetrics));
            solution07.EVDCollection.Add(BuildEVDItem(EVDType.TrainingAndChange));

            solutions.Add(solution07);

            Solution solution08 = new Solution()
            {
                Id = 11,
                Name = "Solution08"
            };

            solution08.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));
            solution08.EVDCollection.Add(BuildEVDItem(EVDType.TrainingAndChange));
            solution08.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            solution08.EVDCollection.Add(BuildEVDItem(EVDType.Code));
            solution08.EVDCollection.Add(BuildEVDItem(EVDType.Requirement));

            solutions.Add(solution08);

            return solutions;
        }

        private EVDItem BuildEVDItem(EVDType evdType)
        {
            EVDItem evdItem = new EVDItem();
            evdItem.Id = (int)evdType;

            switch (evdType)
            {
                case EVDType.Project:
                    evdItem.Name = "Project";
                    evdItem.Description = "EVD for Project";
                    break;

                case EVDType.Requirement:
                    evdItem.Name = "Requirement";
                    evdItem.Description = "EVD for Requirement";
                    break;

                case EVDType.Code:
                    evdItem.Name = "Code";
                    evdItem.Description = "EVD for Code";
                    break;

                case EVDType.Test:
                    evdItem.Name = "Test";
                    evdItem.Description = "EVD for Test";
                    break;

                case EVDType.Deployment:
                    evdItem.Name = "Deployment";
                    evdItem.Description = "EVD for Deployment";
                    break;

                case EVDType.Support:
                    evdItem.Name = "Support";
                    evdItem.Description = "EVD for Support";
                    break;

                case EVDType.KeyImpactDeliverables:
                    evdItem.Name = "Key Impact Deliverables";
                    evdItem.Description = "EVD for Key Impact Deliverables";
                    break;

                case EVDType.ProjectHealthMetrics:
                    evdItem.Name = "Project Health Metrics";
                    evdItem.Description = "EVD for Project Health Metrics";
                    break;

                case EVDType.TrainingAndChange:
                    evdItem.Name = "Training and Change";
                    evdItem.Description = "EVD for Training and Change";
                    break;

            }

            return evdItem;
        }
    }

    public enum EVDType
    {
        Project = 1,

        Requirement,

        Code,

        Test,

        Deployment,

        Support,

        KeyImpactDeliverables,

        ProjectHealthMetrics,

        TrainingAndChange
    }
}
