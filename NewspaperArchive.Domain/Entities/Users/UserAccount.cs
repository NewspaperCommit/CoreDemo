using NewspaperArchive.Domain.Entities;
using System;
//using System.Collections.Generic;
//using System.Web.Script.Serialization;

namespace NewspaperArchive.Domain.Entities
{
    [Serializable]
    public class UserAccount : BaseEntity
    {
        public UserAccount()
        {
         
        }

        public int UserAccountId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> PlanId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> LastBilledDate { get; set; }
        public Nullable<int> BillingAttempt { get; set; }
        public Nullable<System.DateTime> NextBillingDate { get; set; }
        public Nullable<System.DateTime> CancelDate { get; set; }
        public Nullable<System.DateTime> DateLastUpdate { get; set; }
        public Nullable<int> ActiveAccount { get; set; }
        public string CCDigits { get; set; }
        public Nullable<int> RecurringBilling { get; set; }
        public Nullable<int> RecurringError { get; set; }
        public string OriginalOrderId { get; set; }
        public Nullable<int> ReferralUserId { get; set; }
        public Nullable<System.DateTime> ReferralUserProcessDate { get; set; }
        public Nullable<int> ReferralSiteId { get; set; }
        public Nullable<int> UpgradeSiteId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public Nullable<bool> BilledByRecurly { get; set; }
        public string RecurlySubscriptionUuid { get; set; }       
        public Nullable<decimal> GlobalWayMakersContribution { get; set; }
        
        /// <summary>
        /// Gets the user
        /// </summary>
        //[ScriptIgnore]
        //public virtual User User { get; set; }

    }

    public class UserAccountPlan : BaseEntity
    {
        public int PlanId { get; set; }
        public Nullable<double> GlobalWayMakersContribution { get; set; }
        public int userAccountId { get; set; }
    }

    public class UserActiveAccount : BaseEntity
    {
        public int userAccountID { get; set; }
        public int userID { get; set; }
        public int roleID { get; set; }
        public int planID { get; set; }
        public DateTime nextBillingDate { get; set; }
        public bool isAcitveAccount { get; set; }
        public bool isRecurringBillingAccount { get; set; }
    }

    public class UserAccountID : BaseEntity
    {
        public int UserAccountId { get; set; }
    }

    /// <summary>
    /// UserAccounts Table all field
    /// </summary>
    public class UserAccountsAll : BaseEntity
    {
        public Nullable<int> UserAccountId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> PlanId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> LastBilledDate { get; set; }
        public Nullable<int> BillingAttempt { get; set; }
        public Nullable<System.DateTime> NextBillingDate { get; set; }
        public Nullable<System.DateTime> CancelDate { get; set; }
        public Nullable<System.DateTime> DateLastUpdate { get; set; }
        public Nullable<int> ActiveAccount { get; set; }
        public string CCDigits { get; set; }
        public Nullable<int> RecurringBilling { get; set; }
        public Nullable<int> RecurringError { get; set; }
        public string OriginalOrderId { get; set; }
        public Nullable<int> ReferralUserId { get; set; }
        public Nullable<System.DateTime> ReferralUserProcessDate { get; set; }
        public Nullable<int> ReferralSiteId { get; set; }
        public Nullable<int> UpgradeSiteId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public Nullable<bool> IsGlobalWayMakersContribution { get; set; }
        public Nullable<decimal> GlobalWayMakersContribution { get; set; }
        public Nullable<bool> OneTimeOnlyContribution { get; set; }
    }
    /// <summary>
    /// Added bY Vishant Garg
    /// </summary>
    public class SubscriptionCancelReasons : BaseEntity
    {
        public int SubscriptionCancelReasonId { get; set; }
        public string CancelReason { get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }
        public int DisplayOrder { get; set; }
    }
    public class UserSubscriptionUid : BaseEntity
    {
        public string RecurlySubscriptionUuid { get; set; }
    }
    public class UserTransactionDetail : BaseEntity
    {
        public Nullable<int> UserAccountId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> PlanId { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public Nullable<int> RecurringCount { get; set; }
    }
}
