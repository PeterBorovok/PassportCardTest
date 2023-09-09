using RatePolicyData;

namespace RatePolicyComponents.PolicyRate
{
    // Should be ** internal class ** in order to be used in Engine only and
    // prevent incorrect use of Rate objects without going through Validator
    // logic first,
    //
    // But in order to make it easier to apply TDD, the class made ** public ** .
    public class PolicyRateTravel : BasePolicyRate
    {
        protected override decimal? RatePolicy(Policy policy)
        {
            if (policy.Type != TestRating.PolicyType.Travel)
                return null;

            decimal rate;
           
            rate = policy.Days * 2.5m;
            if (policy.Country == "Italy")
            {
                rate *= 3;
            }

            return rate;
        }
    }
}