using RatePolicyData;

namespace RatePolicyComponents.PolicyRate
{
    // Should be ** internal class ** in order to be used in Engine only and
    // prevent incorrect use of Rate objects without going through Validator
    // logic first,
    //
    // But in order to make it easier to apply TDD, the class made ** public ** 
    public class PolicyRateLife : BasePolicyRate
    {
        protected override decimal? RatePolicy(Policy policy)
        {
            if (policy.Type != TestRating.PolicyType.Life)
                return null;

            decimal rate;
            
            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
                rate = baseRate * 2;
            else
                rate = baseRate;
            return rate;
        }
    }
}