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
                Name = "DotAgile",
                Overview = "The DotAgile Solution Center supports every step of a shift to Agile, for IT and beyond, across small delivery teams and large enterprises. Our solutions are designed to bring rapid, repeatable results built from a combination of years of Agile delivery experience and Deloitte’s industry-leading consulting services. We are constantly evolving to enable the successful adoption of Agile at scale and meet the toughest challenges of our Federal clients."
                            + "\n\n\t The first step is to understand the needs and readiness for Agile within your organization. We use proprietary toolkits to rapidly assess your current state, including the objectives, opportunities, and unique challenges that must be addressed to meet your agency’s criteria for success."
                            +"\n\n\t Our experts design a custom plan built to achieve your Agile goals within the desired timeframe, factoring in the unique requirements of each organization. The Roadmap’s scope will vary to meet the need and can include options for scaled or phased approaches."
                            +"\n\n\t Deloitte began by conducting an assessment of the organization’s readiness for Agile. We used our opportunity matrix to determine that the organization wanted value demonstrated on a small scale before proceeding with a wider rollout. Deloitte designed a custom Roadmap specifically to meet the success criteria and the audit and regulatory requirements, and engaged a pilot program using the rapid deployment model. Teams, business owners, leadership, and other stakeholders were engaged to establish organizational readiness. Tailored simulations supported the learning plan, and coaches provided on-site support. Upon seeing the value of Agile for one team, the agency decided to expand."
            };
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Project));
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Code));
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Test));
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Requirement));
            dotAgile.EVDCollection.Add(BuildEVDItem(EVDType.Deployment));

            dotAgile.Contacts.Add(new Pointofcontact
            {
                Name = "Brian Breit",
                Email = @"bbreit@deloitte.com",
                Designation = "Partner",
                Description = "Leads the Federal System Development capability, with 20+ years of experience focusing on large technology-enabled business transformations across Financial Services and Health-related clients in Federal, State, and Commercial",
                ImageURL = "BrianBreit"
            });
            dotAgile.Contacts.Add(new Pointofcontact
            {
                Name = "Azunna Anyanwu",
                Email = @"aanyanwu@deloitte.com",
                Designation = "Manager",
                Description = "15+ years of experience delivering solutions to clients in Federal & State. Expert at applying Agile frameworks such as Scrum & Rapid Application Development (RAD). Certified Scrum Master (CSM) and PMI Agile Professional (PMI-ACP).",
                ImageURL = "AzunnaAnyanwu"
            });
            dotAgile.Contacts.Add(new Pointofcontact
            {
                Name = "Jason Bowers",
                Email = @"Jbowers@deloitte.com",
                Designation = "Director",
                Description = "Agile advocate with 15+ years in large-scale custom development. Leader in Agile practices to deliver across multiple technology platforms. Delivers solutions in Case Management and other collaborative, mission IT solutions.",
                ImageURL = "JasonBowers"
            });


            solutions.Add(dotAgile);


            SolutionMock legacyModernization = new SolutionMock()
            {
                Id = 4,
                Name = "Legacy Modernization",
                Overview = "Legacy systems are typically large, complex, custom built systems that deliver mission critical services, designed and built decades ago. Over the years they have tied the organization to outdated hardware platforms, programming languages and databases that are not part of the organization’s future IT strategy. These systems pose increasing risk due to attrition of key resources, lack of flexibility to changing business demands and the complexity of the environment that has evolved around them. Recent news articles highlight the extent of the problem"
                            + "\n\n\t On average, 80 percent of time, energy, and budgets are consumed by the care and feeding of an organization’s existing IT stack . Within it, unwanted technical debt and complexity often exist, with systems at various stages of health, maturity, and architectural sophistication. Organizations have compelling reasons to consider modernizing their core legacy systems, and each situation should be handled based on the specific drivers and circumstances"
                            + "\n\n\t Deloitte’s Legacy Systems Modernization Framework (LSMF) provides a comprehensive blueprint for modernization using a structured and pragmatic approach to plan and implement the appropriate steps when modernizing legacy systems. It is based on extensive experience and lessons learned delivering large, complex modernization initiatives across Federal, State and Private Industry. The framework is an all-inclusive set of modernization steps, techniques and tools to guide strategy, implementation, deployment, and long-term maintenance of modernized solutions. It also outlines the key decisions and trade-offs for each step, enabling avoidance of modernization pitfalls while addressing business objectives and managing execution risk. Through our extensive experience, we’ve learned that each unique situation requires its own tailored modernization approach. As a result, we work with our clients to determine the best approach based on their specific circumstances, drivers and pain points."
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

        public string ImageURL { get; set; }
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
