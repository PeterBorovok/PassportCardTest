using Microsoft.VisualStudio.TestTools.UnitTesting;
using RatePolicy.BusinessLogicTests.Properties;
using Utilities;

namespace RatePolicyComponents.PolicyRate.Tests
{
    [TestClass()]
    public class PolicyValidatorHealthTests
    {
        [TestMethod()]
        public void IsPolicyValidTest()
        {
            string policyJson = Resources.HealthValidatorTest_Policy1;
            var policy = Utilities.Utilities.GetPolicyObject(policyJson);
            var validator = new PolicyValidatorHealth();
            bool isValid = validator.IsValid(policy);

            // Should be false
            Assert.IsFalse(isValid);
        }
    }
}