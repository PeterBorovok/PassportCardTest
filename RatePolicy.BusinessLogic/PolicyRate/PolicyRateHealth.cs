using RatePolicyData;

namespace RatePolicyComponents.PolicyRate
{
    // Should be ** internal class ** in order to be used in Engine only and
    // prevent incorrect use of Rate objects without going through Validator
    // logic first,
    //
    // But in order to make it easier to apply TDD, the class made ** public ** 
    public class PolicyRateHealth : BasePolicyRate
    { 
        protected override decimal? RatePolicy(Policy policy)
        {
            if(policy.Type != TestRating.PolicyType.Health)
                return null;

            decimal rate;

            // Original BL copied AS IS, looks like there are logical errors, e.g.
            // Deductible condition no else, so always the line after if takes action 
            if (policy.Gender == "Male")
            {
                if (policy.Deductible < 500)
                {
                    rate = 1000m;
                }
                rate = 900m;
            }
            else
            {
                if (policy.Deductible < 800)
                {
                    rate = 1100m;
                }
                rate = 1000m;
            }

            return rate;
        }
    }
}