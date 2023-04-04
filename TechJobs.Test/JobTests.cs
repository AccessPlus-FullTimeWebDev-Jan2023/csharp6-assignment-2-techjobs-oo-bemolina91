
using System.Reflection;
using System.Xml.Linq;

namespace TechJobs.Tests
{
	[TestClass]
	public class JobTests
	{
        //Testing Objects
        //initalize your testing objects here
        Job job1 = new Job();
        Job job2 = new Job();
        Job job3 = new Job("Product tester", new Employer("ACME"), new Location("Desert"),
            new PositionType("Quality control"), new CoreCompetency("Persistence"));
        Job job4 = new Job("Product tester", new Employer("ACME"), new Location("Desert"),
            new PositionType("Quality control"), new CoreCompetency("Persistence"));
        

        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.AreNotEqual(job1, job2, "Unique Id Test");
        }

        [TestMethod] 
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual(job3.Name, "Product tester", "Testing Job Name");
            Assert.AreEqual(job3.EmployerName.ToString(), "ACME", "Testing EmployerName Value");
            Assert.AreEqual(job3.EmployerLocation.ToString(), "Desert", "Testing EmployerLocation Value");
            Assert.AreEqual(job3.JobType.ToString(), "Quality control", "Testing JobType Value");
            Assert.AreEqual(job3.JobCoreCompetency.ToString(), "Persistence", "Testing JobCoreCompetency Value");
        }

        [TestMethod] 
        public void TestJobsForEquality()
        {
            Assert.AreNotEqual(job3, job4, "Objects with different ID are not equal");
        }

        [TestMethod]
        public void TestToStringStartsAndEndsWithNewLine()
        {
            char[] arr = job4.ToString().ToCharArray();
            Assert.AreEqual(Environment.NewLine, arr[arr.Length - 1].ToString());
            Assert.AreEqual(arr[0].ToString(), Environment.NewLine);
            //string str = Environment.NewLine + "" + Environment.NewLine;
            //Assert.AreEqual(Environment.NewLine, str[str.Length - 1].ToString());
            //Assert.AreEqual(Environment.NewLine, str[0].ToString());
        }

        [TestMethod]
        public void TestToStringContainsCorrectLabelsAndData()
        {
            string output = $"{Environment.NewLine}ID: {job4.Id}{Environment.NewLine}Name: {job4.Name}{Environment.NewLine}Employer: {job4.EmployerName}" +
                $"{Environment.NewLine}Location: {job4.EmployerLocation}{Environment.NewLine}Position Type: {job4.JobType}" +
                $"{Environment.NewLine}Core Competency: {job4.JobCoreCompetency}{Environment.NewLine}";
            Assert.AreEqual(output, job4.ToString());
        }

        [TestMethod]
        public void TestToStringHandlesEmptyField()
        {
            job3.Name = "";
            job3.EmployerName.Value = "";
            job3.EmployerLocation.Value = null;
            job3.JobType.Value = "";
            job3.JobCoreCompetency.Value = " ";
            string output = $"{Environment.NewLine}ID: {job3.Id}{Environment.NewLine}Name: Data not available{Environment.NewLine}Employer: Data not available" +
                            $"{Environment.NewLine}Location: Data not available{Environment.NewLine}Position Type: Data not available" +
                            $"{Environment.NewLine}Core Competency: Data not available{Environment.NewLine}";
            Assert.AreEqual(output, job3.ToString());
        }
    }
}
