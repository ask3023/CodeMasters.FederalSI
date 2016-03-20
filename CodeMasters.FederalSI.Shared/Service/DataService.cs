using CodeMasters.FederalSI.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMasters.FederalSI.Shared.Service
{
    public class DataService
    {
        public List<Solution> GetSolutions()
        {
            // retun temp solutions
            // TODO: call API to fetch the data
            return this.BuildSolutions();
        }

        private List<Solution> BuildSolutions()
        {
            List<Solution> solutions = new List<Solution>();
            solutions.Add(
                new Solution()
                {
                    Id = 1,
                    Name = "DConnect"
                });

            solutions.Add(
                new Solution()
                {
                    Id = 2,
                    Name = "DotAgile"
                });

            solutions.Add(
                new Solution()
                {
                    Id = 1,
                    Name = "Legacy Modernization"
                });

            solutions.Add(
                new Solution()
                {
                    Id = 1,
                    Name = "Solution01"
                });

            solutions.Add(
                new Solution()
                {
                    Id = 1,
                    Name = "Solution02"
                });

            solutions.Add(
                new Solution()
                {
                    Id = 1,
                    Name = "Solution03"
                });

            solutions.Add(
                new Solution()
                {
                    Id = 1,
                    Name = "Solution04"
                });

            solutions.Add(
                new Solution()
                {
                    Id = 1,
                    Name = "Solution05"
                });

            solutions.Add(
                new Solution()
                {
                    Id = 1,
                    Name = "Solution06"
                });

            solutions.Add(
                new Solution()
                {
                    Id = 1,
                    Name = "Solution07"
                });

            solutions.Add(
                new Solution()
                {
                    Id = 1,
                    Name = "Solution08"
                });

            return solutions;
        }
    }
}
