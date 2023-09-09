using Microsoft.VisualStudio.TestTools.UnitTesting;
using RatePolicy.BusinessLogicTests.Properties;
using RatePolicyComponents.PolicyRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatePolicyComponents.PolicyRate.Tests
{
    [TestClass()]
    public class BasePolicyValidatorTests
    {
        [TestMethod()]
        public void IsValid_HealthValidatorTest()
        {
            string policyJson = Resources.HealthValidatorTest_Policy1;
            var policyObj = Utilities.Utilities.GetPolicyObject(policyJson);
            var healthValidator = PolicyValidatorFactory.Create(TestRating.PolicyType.Health);
            bool isValid = healthValidator.IsValid(policyObj);  
            // We know that supplied policy is a travel policy which is invalid for health validator
            Assert.IsFalse(isValid);
        }

        [TestMethod()]
        public void IsValid_LifeValidatorTest()
        {
            string policyJson = Resources.HealthValidatorTest_Policy1;
            var policyObj = Utilities.Utilities.GetPolicyObject(policyJson);
            var healthValidator = PolicyValidatorFactory.Create(TestRating.PolicyType.Life);
            bool isValid = healthValidator.IsValid(policyObj);
            // We know that supplied policy is a travel policy which is invalid for life validator
            Assert.IsFalse(isValid);
        }

        [TestMethod()]
        public void IsValid_TravelValidatorTest()
        {
            string policyJson = Resources.HealthValidatorTest_Policy1;
            var policyObj = Utilities.Utilities.GetPolicyObject(policyJson);
            var healthValidator = PolicyValidatorFactory.Create(TestRating.PolicyType.Travel);
            bool isValid = healthValidator.IsValid(policyObj);
            // We know that supplied policy is a travel policy which is VALID for travel validator
            Assert.IsTrue(isValid);
        }
    }
}