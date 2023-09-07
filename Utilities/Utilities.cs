using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RatePolicyData;

namespace Utilities
{
    public class Utilities
    {
        public static Policy GetPolicyObject(string policyJson)
        {
            return JsonConvert.DeserializeObject<Policy>(policyJson,
                    new StringEnumConverter());
        }
    }
}
