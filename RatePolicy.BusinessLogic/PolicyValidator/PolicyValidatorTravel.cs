using RatePolicyData;
using System;
using System.Numerics;

namespace RatePolicyComponents.PolicyRate
{
    // Should be ** internal class ** in order to be used in Engine only and
    // prevent incorrect use of Rate objects without going through Validator
    // logic first,
    //
    // But in order to make it easier to apply TDD, the class made ** public ** .
    public class PolicyValidatorTravel : BasePolicyValidator
    {
        protected override bool IsPolicyValid(Policy policy, out string errorMessage)
        {
            decimal rate;
            if (policy.Days <= 0)
            {
                errorMessage = "Travel policy must specify Days.";
                return false;
            }
            if (policy.Days > 180)
            {
                errorMessage = "Travel policy cannot be more then 180 Days.";
                return false;
            }
            if (String.IsNullOrEmpty(policy.Country))
            {
                errorMessage = "Travel policy must specify country.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
    }
}