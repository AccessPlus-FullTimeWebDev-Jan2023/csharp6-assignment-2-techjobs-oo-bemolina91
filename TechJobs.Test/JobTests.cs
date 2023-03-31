
using System.Reflection;

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

        [TestMethod] //4
        public void TestJobConstructorSetsAllFields()
        {
            //verify 
            Assert.AreEqual(job3.Name, "Product tester", "Testing Job Name");
            Assert.AreEqual(job3.EmployerName.ToString(), "ACME", "Testing EmployerName Value");
            Assert.AreEqual(job3.EmployerLocation.ToString(), "Desert", "Testing EmployerLocation Value");
            Assert.AreEqual(job3.JobType.ToString(), "Quality control", "Testing JobType Value");
            Assert.AreEqual(job3.JobCoreCompetency.ToString(), "Persistence", "Testing JobCoreCompetency Value");
        }

        [TestMethod] //5
        public void TestJobsForEquality()
        {
            Assert.AreNotEqual(job3, job4, "Objects with different ID are not equal");
        }

    }
}

