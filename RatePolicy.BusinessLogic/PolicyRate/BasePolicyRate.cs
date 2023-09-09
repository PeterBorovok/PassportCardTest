using RatePolicyData;

namespace RatePolicyComponents.PolicyRate
{
    public abstract class BasePolicyRate : IPolicyRate
    {
        public event EventHandler<PolicyRateEventArgs> PolicyRateState;

        public decimal? Rate(Policy policy)
        {
            if (PolicyRateState != null)
                PolicyRateState(this, new PolicyRateEventArgs() { NotificationText = $"Starting {policy.Type} policy rate." });
            
            return RatePolicy(policy);
        }

        protected abstract decimal? RatePolicy(Policy policy);
    }
}
