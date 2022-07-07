namespace azure_m.Models
{
    namespace ResponseModels
    {

        public class ListSubscriptionResponse: ListResponse<SubscriptionResponse> { }

        public class SubscriptionResponse: Subscription { }

        public class Subscription
        {
            public string authorizationSource;
            public string displayName;
            public string id;
            public ManagedByTenant[] managedByTenants;
            public SubscriptionState state;
            public string subscriptionId;
            public SubscriptionPolicies subscriptionPolicies;
            public object tags;
            public string tenantId;
        }
        public class ManagedByTenant
        {
            public string tenantId;
        }
        public class SubscriptionState
        {
            public string Deleted;
            public string Disabled;
            public string Enabled;
            public string PastDue;
            public string Warned;
        }
        public class SubscriptionPolicies
        {
            public string locationPlacementId;
            public string quotaId;
            public spendingLimit spendingLimit;
        }
        public class spendingLimit
        {
            public string CurrentPeriodOff;
            public string Off;
            public string On;
        }
    }
}
