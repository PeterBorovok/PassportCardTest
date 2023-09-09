using RatePolicyData;

namespace RatePolicyComponents.PolicyRate
{
    public interface IPolicyRate
    {
        event EventHandler<PolicyRateEventArgs> PolicyRateState;
        decimal? Rate(Policy policy);
    }

    public class PolicyRateEventArgs : EventArgs
    {
        public string NotificationText { get; set; }
    }
}
