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
    public class PolicyValidatorHealth : BasePolicyValidator
    {
        protected override bool IsPolicyValid(Policy policy, out string errorMessage)
        {
            if (String.IsNullOrEmpty(policy.Gender))
            {
                errorMessage = "Health policy must specify Gender";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}