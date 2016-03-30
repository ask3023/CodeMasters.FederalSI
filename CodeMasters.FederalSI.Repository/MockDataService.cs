using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMasters.FederalSI.Repository
{
    public class MockDataService
    {
        public List<SolutionMock> BuildSolutions()
        {
            List<SolutionMock> solutions = new List<SolutionMock>();
            SolutionMock dConnect = new SolutionMock()
            {
                Id = 2,
                Name = "DConnect",
                DetailedDescription = "Details descrition about the solution...Issue to impact",
                Overview = "Basic description of the solution",
                PagerUrl = "",
                InfoCardUrl = ""
            };

            dConnect.EVDCollection.Add(BuildEVDItem(EVDType.Code));
            dConnect.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            dConnect.EVDCollection.Add(BuildEVDItem(EVDType.Requirement));
            dConnect.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));

            dConnect.Contacts.Add(new Pointofcontact() {
                Name = "John Madden",
                Designation = "Senior Solution Architect",
                Description = "Champion in DConnect",
                Email = "John.Madden@deloitt.com"
            } );

            solutions.Add(dConnect);

            SolutionMock dotAgile = new SolutionMock()
            {
                Id = 1,
                Name = "DotAgile"
            };
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Project));
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Code));
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Requirement));
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));

            solutions.Add(dotAgile);


            SolutionMock legacyModernization = new SolutionMock()
            {
                Id = 4,
                Name = "Legacy Modernization"
            };

            legacyModernization.EVDCollection.Add(BuildEVDItem(EVDType.ProjectHealthMetrics));
            legacyModernization.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            legacyModernization.EVDCollection.Add(BuildEVDItem(EVDType.TrainingAndChange));
            legacyModernization.EVDCollection.Add(BuildEVDItem(EVDType.KeyImpactDeliverables));

            solutions.Add(legacyModernization);


            SolutionMock solution01 = new SolutionMock()
            {
                Id = 3,
                Name = "Solution01"
            };

            solution01.EVDCollection.Add(BuildEVDItem(EVDType.Code));
            solution01.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            solution01.EVDCollection.Add(BuildEVDItem(EVDType.Requirement));
            solution01.EVDCollection.Add(BuildEVDItem(EVDType.KeyImpactDeliverables));

            solutions.Add(solution01);

            SolutionMock solution02 = new SolutionMock()
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

            SolutionMock solution03 = new SolutionMock()
            {
                Id = 6,
                Name = "Solution03"
            };

            solution03.EVDCollection.Add(BuildEVDItem(EVDType.Code));
            solution03.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            solution03.EVDCollection.Add(BuildEVDItem(EVDType.Project));
            solution03.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));

            solutions.Add(solution03);


            SolutionMock solution04 = new SolutionMock()
            {
                Id = 7,
                Name = "Solution04"
            };

            solution04.EVDCollection.Add(BuildEVDItem(EVDType.Requirement));
            solution04.EVDCollection.Add(BuildEVDItem(EVDType.KeyImpactDeliverables));
            solution04.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));

            solutions.Add(solution04);


            SolutionMock solution05 = new SolutionMock()
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

            SolutionMock solution06 = new SolutionMock()
            {
                Id = 9,
                Name = "Solution06"
            };

            solution06.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));
            solution06.EVDCollection.Add(BuildEVDItem(EVDType.ProjectHealthMetrics));
            solution06.EVDCollection.Add(BuildEVDItem(EVDType.Support));
            solution06.EVDCollection.Add(BuildEVDItem(EVDType.TrainingAndChange));

            solutions.Add(solution06);

            SolutionMock solution07 = new SolutionMock()
            {
                Id = 10,
                Name = "Solution07"
            };

            solution07.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));
            solution07.EVDCollection.Add(BuildEVDItem(EVDType.ProjectHealthMetrics));
            solution07.EVDCollection.Add(BuildEVDItem(EVDType.TrainingAndChange));

            solutions.Add(solution07);

            SolutionMock solution08 = new SolutionMock()
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

        public EVDItem BuildEVDItem(EVDType evdType)
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

    public class SolutionMock
    {
        public SolutionMock()
        {
            this.EVDCollection = new List<EVDItem>();
            this.Contacts = new List<Pointofcontact>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Overview { get; set; }

        // Contain issue to impact or any other text related to solution
        public string DetailedDescription { get; set; }

        public List<Pointofcontact> Contacts { get; set; }

        public string InfoCardUrl { get; set; }

        public string PagerUrl { get; set; }

        public List<EVDItem> EVDCollection { get; private set; }
    }

    public class Pointofcontact
    {
        public string Name { get; set; }

        public string Designation { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        // Image URL ???
    }

    public class EVDItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
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
