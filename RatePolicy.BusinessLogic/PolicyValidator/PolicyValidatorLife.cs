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
    public class PolicyValidatorLife : BasePolicyValidator
    {
        protected override bool IsPolicyValid(Policy policy, out string errorMessage)
        {
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                errorMessage = "Life policy must include Date of Birth.";
                return false;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                errorMessage = "Max eligible age for coverage is 100 years.";
                return false;
            }
            if (policy.Amount == 0)
            {
                errorMessage = "Life policy must include an Amount.";
                return false;
            }
            errorMessage = string.Empty;    
            return true;
        }
    }
}