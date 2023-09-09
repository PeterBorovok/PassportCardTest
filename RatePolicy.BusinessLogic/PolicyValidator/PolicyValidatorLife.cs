using RatePolicyData;
using System;
using System.Numerics;

namespace RatePolicyComponents.PolicyRate
{
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