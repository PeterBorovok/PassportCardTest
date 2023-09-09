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
    public class BasePolicyRateTests
    {
        [TestMethod()]
        public void Rate_TravelRateTest()
        {
            string policyJson = Resources.TravelPolicy;
            var policyObj = Utilities.Utilities.GetPolicyObject(policyJson);
            var travelRate = PolicyRateFactory.Create(TestRating.PolicyType.Travel);
            decimal? rating = travelRate.Rate(policyObj);
            // We know that supplied policy is a travel policy, that gives 75 Rating
            Assert.IsTrue(rating.HasValue && rating.Value == 75);
        }

        [TestMethod()]
        public void Rate_HealthRateTest()
        {
            string policyJson = Resources.TravelPolicy;
            var policyObj = Utilities.Utilities.GetPolicyObject(policyJson);
            var healthRate = PolicyRateFactory.Create(TestRating.PolicyType.Health);
            decimal? rating = healthRate.Rate(policyObj);
            // We know that supplied policy is a travel policy, therefore Health rate can not rate it
            Assert.IsFalse(rating.HasValue);
        }

        [TestMethod()]
        public void Rate_LifeRateTest()
        {
            string policyJson = Resources.TravelPolicy;
            var policyObj = Utilities.Utilities.GetPolicyObject(policyJson);
            var lifeRate = PolicyRateFactory.Create(TestRating.PolicyType.Life);
            decimal? rating = lifeRate.Rate(policyObj);
            // We know that supplied policy is a travel policy, therefore Life rate can not rate it
            Assert.IsFalse(rating.HasValue);
        }
    }
}