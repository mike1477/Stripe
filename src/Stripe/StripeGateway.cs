﻿// Copyright (c) Service Stack LLC. All Rights Reserved.
// License: https://raw.github.com/ServiceStack/ServiceStack/master/license.txt

using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using ServiceStack.Stripe.Types;
using ServiceStack.Text;

namespace ServiceStack.Stripe
{
    /* Charges 
     * https://stripe.com/docs/api/curl#charges
     */
    [Route("/charges")]
    public class ChargeStripeCustomer : IPost, IReturn<StripeCharge>
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Customer { get; set; }
        public string Card { get; set; }
        public string Description { get; set; }
        public bool? Capture { get; set; }
        public int? ApplicationFee { get; set; }
    }

    [Route("/charges/{ChargeId}")]
    public class GetStripeCharge : IGet, IReturn<StripeCharge>
    {
        public string ChargeId { get; set; }
    }

    [Route("/charges/{ChargeId}/refund")]
    public class RefundStripeCharge : IPost, IReturn<StripeCharge>
    {
        [IgnoreDataMember]
        public string ChargeId { get; set; }
        public int? Amount { get; set; }
        public bool? RefundApplicationFee { get; set; }
    }

    [Route("/charges/{ChargeId}/capture")]
    public class CaptureStripeCharge : IPost, IReturn<StripeCharge>
    {
        [IgnoreDataMember]
        public string ChargeId { get; set; }
        public int? Amount { get; set; }
        public bool? ApplicationFee { get; set; }
    }

    [Route("/charges")]
    public class GetStripeCharges : IGet, IReturn<StripeCollection<StripeCharge>>
    {
        public int? Count { get; set; }
        public int? Offset { get; set; }
        public DateTime? Created { get; set; }
        public string Customer { get; set; }
    }

    /* Customers 
     * https://stripe.com/docs/api/curl#customers
     */
    [Route("/customers")]
    public class CreateStripeCustomer : IPost, IReturn<StripeCustomer>
    {
        public int AccountBalance { get; set; }
        public StripeCard Card { get; set; }
        public string Coupon { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Plan { get; set; }
        public int? Quantity { get; set; }
        public DateTime? TrialEnd { get; set; }
    }

    [Route("/customers/{Id}")]
    public class GetStripeCustomer : IGet, IReturn<StripeCustomer>
    {
        public string Id { get; set; }
    }

    [Route("/customers/{Id}")]
    public class UpdateStripeCustomer : IPost, IReturn<StripeCustomer>
    {
        [IgnoreDataMember]
        public string Id { get; set; }
        public int AccountBalance { get; set; }
        public StripeCard Card { get; set; }
        public string Coupon { get; set; }
        public string DefaultCard { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }

    [Route("/customers/{Id}")]
    public class DeleteStripeCustomer : IDelete, IReturn<StripeReference>
    {
        public string Id { get; set; }
    }

    [Route("/customers")]
    public class GetStripeCustomers : IGet, IReturn<StripeCollection<StripeCustomer>>
    {
        public int? Count { get; set; }
        public int? Offset { get; set; }
        public DateTime? Created { get; set; }
    }

    /* Cards
     * https://stripe.com/docs/api/curl#cards
     */
    [Route("/customers/{CustomerId}/cards")]
    public class CreateStripeCard : IPost, IReturn<StripeCard>
    {
        [IgnoreDataMember]
        public string CustomerId { get; set; }

        public StripeCard Card { get; set; }
    }

    [Route("/customers/{CustomerId}/cards/{CardId}")]
    public class GetStripeCard : IGet, IReturn<StripeCard>
    {
        public string CustomerId { get; set; }
        public string CardId { get; set; }
    }

    [Route("/customers/{CustomerId}/cards/{CardId}")]
    public class DeleteStripeCard : IDelete, IReturn<StripeReference>
    {
        public string CustomerId { get; set; }
        public string CardId { get; set; }
    }

    [Route("/customers/{CustomerId}/cards")]
    public class GetStripeCards : IGet, IReturn<StripeCollection<StripeCard>>
    {
        public string CustomerId { get; set; }

        public int? Count { get; set; }
        public int? Offset { get; set; }
    }

    /* Subscriptions
     * https://stripe.com/docs/api/curl#subscriptions
     */
    [Route("/customers/{CustomerId}/subscription")]
    public class SubscribeStripeCustomer : IPost, IReturn<StripeSubscription>
    {
        [IgnoreDataMember]
        public string CustomerId { get; set; }
        public string Plan { get; set; }
        public string Coupon { get; set; }
        public bool? Prorate { get; set; }
        public DateTime? TrialEnd { get; set; }
        public string Card { get; set; }
        public int? Quantity { get; set; }
        public int? ApplicationFeePercent { get; set; }
    }

    [Route("/customers/{CustomerId}/subscription")]
    public class CancelStripeSubscription : IDelete, IReturn<StripeSubscription>
    {
        public string CustomerId { get; set; }
        public bool AtPeriodEnd { get; set; }
    }

    /* Plans
     * https://stripe.com/docs/api/curl#plans
     */
    [Route("/plans")]
    public class CreateStripePlan : IPost, IReturn<StripePlan>
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public StripePlanInterval Interval { get; set; }
        public int? IntervalCount { get; set; }
        public string Name { get; set; }
        public int? TrialPeriodDays { get; set; }
    }

    [Route("/plans/{Id}")]
    public class GetStripePlan : IGet, IReturn<StripePlan>
    {
        public string Id { get; set; }
    }

    [Route("/plans/{Id}")]
    public class UpdateStripePlan : IPost, IReturn<StripePlan>
    {
        [IgnoreDataMember]
        public string Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }

    [Route("/plans/{Id}")]
    public class DeleteStripePlan : IDelete, IReturn<StripeReference>
    {
        public string Id { get; set; }
    }

    [Route("/plans")]
    public class GetStripePlans : IGet, IReturn<StripeCollection<StripePlan>>
    {
        public int? Count { get; set; }
        public int? Offset { get; set; }
    }

    /* Coupons
     * https://stripe.com/docs/api/curl#coupons
     */
    [Route("/coupons")]
    public class CreateStripeCoupon : IPost, IReturn<StripeCoupon>
    {
        public string Id { get; set; }
        public StripeCouponDuration Duration { get; set; }
        public int? AmountOff { get; set; }
        public string Currency { get; set; }
        public int? DurationInMonths { get; set; }
        public int? MaxRedemptions { get; set; }
        public int? PercentOff { get; set; }
        public DateTime? RedeemBy { get; set; }
    }

    [Route("/coupons/{Id}")]
    public class GetStripeCoupon : IGet, IReturn<StripeCoupon>
    {
        public string Id { get; set; }
    }

    [Route("/coupons/{Id}")]
    public class DeleteStripeCoupon : IDelete, IReturn<StripeReference>
    {
        public string Id { get; set; }
    }

    [Route("/coupons")]
    public class GetStripeCoupons : IGet, IReturn<StripeCollection<StripeCoupon>>
    {
        public int? Count { get; set; }
        public int? Offset { get; set; }
    }

    /* Discounts
     * https://stripe.com/docs/api/curl#discounts
     */
    [Route("/customers/{CustomerId}/discount")]
    public class DeleteStripeDiscount : IDelete, IReturn<StripeReference>
    {
        public string CustomerId { get; set; }
    }

    /* Invoices
     * https://stripe.com/docs/api/curl#invoices
     */
    [Route("/invoices")]
    public class CreateStripeInvoice : IPost, IReturn<StripeInvoice>
    {
        public string Customer { get; set; }
        public int? ApplicationFee { get; set; }
    }

    [Route("/invoices/{Id}/pay")]
    public class PayStripeInvoice : IPost, IReturn<StripeInvoice>
    {
        [IgnoreDataMember]
        public string Id { get; set; }
    }

    [Route("/invoices/upcoming")]
    public class GetUpcomingStripeInvoice : IGet, IReturn<StripeInvoice>
    {
        public string Customer { get; set; }
    }


    public class StripeGateway : IRestGateway
    {
        private const string BaseUrl = "https://api.stripe.com/v1";
        public const string UsdCurrency = "usd";

        public TimeSpan Timeout { get; set; }

        public string Currency { get; set; }

        private string apiKey;
        private string publishableKey;
        public ICredentials Credentials { get; set; }
        private string UserAgent { get; set; }

        public StripeGateway(string apiKey, string publishableKey = null)
        {
            this.apiKey = apiKey;
            this.publishableKey = publishableKey;
            Credentials = new NetworkCredential(apiKey, "");
            Timeout = TimeSpan.FromSeconds(60);
            UserAgent = "servicestack .net stripe v1";
            Currency = UsdCurrency;
        }

        protected virtual string Send(string relativeUrl, string method, string body)
        {
            try
            {
                var url = BaseUrl.CombineWith(relativeUrl);

                var response = url.SendStringToUrl(method: method, requestBody: body, requestFilter: req =>
                {
                    req.Accept = MimeTypes.Json;
                    req.Credentials = Credentials;
                    PclExport.Instance.Config(req,
                        userAgent: UserAgent,
                        timeout: Timeout,
                        preAuthenticate: true);

                    if (method == HttpMethods.Post)
                        req.ContentType = MimeTypes.FormUrlEncoded;
                });

                return response;
            }
            catch (WebException ex)
            {
                string errorBody = ex.GetResponseBody();
                var errorStatus = ex.GetStatus() ?? HttpStatusCode.BadRequest;

                if (ex.IsAny400())
                {
                    var result = errorBody.FromJson<StripeErrors>();
                    throw new StripeException(result.Error)
                    {
                        StatusCode = errorStatus
                    };
                }

                throw;
            }
        }

        class ConfigScope : IDisposable
        {
            private readonly WriteComplexTypeDelegate holdQsStrategy;
            private readonly JsConfigScope jsConfigScope;

            public ConfigScope()
            {
                jsConfigScope = JsConfig.With(dateHandler: DateHandler.UnixTime,
                                              propertyConvention: PropertyConvention.Lenient,
                                              emitLowercaseUnderscoreNames: true);

                holdQsStrategy = QueryStringSerializer.ComplexTypeStrategy;
                QueryStringSerializer.ComplexTypeStrategy = QueryStringStrategy.FormUrlEncoded;
            }

            public void Dispose()
            {
                QueryStringSerializer.ComplexTypeStrategy = holdQsStrategy;
                jsConfigScope.Dispose();
            }
        }

        public T Send<T>(IReturn<T> request, string method, bool sendRequestBody = true)
        {
            using (new ConfigScope())
            {
                var relativeUrl = request.ToUrl(method);
                var body = sendRequestBody ? QueryStringSerializer.SerializeToString(request) : null;

                var json = Send(relativeUrl, method, body);

                var response = json.FromJson<T>();
                return response;
            }
        }

        public T Send<T>(IReturn<T> request)
        {
            var method = request is IPost ?
                  HttpMethods.Post
                : request is IPut ?
                  HttpMethods.Put
                : request is IDelete ?
                  HttpMethods.Delete :
                  HttpMethods.Get;

            return Send(request, method, sendRequestBody: false);
        }

        public T Get<T>(IReturn<T> request)
        {
            return Send(request, HttpMethods.Get, sendRequestBody: false);
        }

        public T Post<T>(IReturn<T> request)
        {
            return Send(request, HttpMethods.Post);
        }

        public T Put<T>(IReturn<T> request)
        {
            return Send(request, HttpMethods.Put);
        }

        public T Delete<T>(IReturn<T> request)
        {
            return Send(request, HttpMethods.Delete, sendRequestBody: false);
        }
    }
}

namespace ServiceStack.Stripe.Types
{
    public class StripeErrors
    {
        public StripeError Error { get; set; }
    }

    public class StripeError
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public string Param { get; set; }
    }

    public class StripeException : Exception
    {
        public StripeException(StripeError error)
            : base(error.Message)
        {
            Code = error.Code;
            Param = error.Param;
        }

        public string Code { get; set; }
        public string Param { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }

    public class StripeReference
    {
        public string Id { get; set; }
        public bool Deleted { get; set; }
    }

    public class StripeObject
    {
        public StripeType Object { get; set; }
    }

    public class StripeId : StripeObject
    {
        public string Id { get; set; }
    }

    public enum StripeType
    {
        Unknown,
        Account,
        Card,
        Charge,
        Coupon,
        Customer,
        Discount,
        Dispute,
        Event,
        InvoiceItem,
        Invoice,
        Line_Item,
        Plan,
        Subscription,
        Token,
        Transfer,
        List,
    }

    public class StripeInvoice : StripeId
    {
        public DateTime Date { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public StripeCollection<StripeLineItem> Lines { get; set; }
        public int Subtotal { get; set; }
        public int Total { get; set; }
        public string Customer { get; set; }
        public bool Attempted { get; set; }
        public bool Closed { get; set; }
        public bool Paid { get; set; }
        public bool Livemode { get; set; }
        public int AttemptCount { get; set; }
        public int AmountDue { get; set; }
        public string Currency { get; set; }
        public int StartingBalance { get; set; }
        public int? EndingBalance { get; set; }
        public DateTime? NextPaymentAttempt { get; set; }
        public string Charge { get; set; }
        public StripeDiscount Discount { get; set; }
        public int? ApplicationFee { get; set; }
    }

    public class StripeCollection<T> : StripeId
    {
        public string Url { get; set; }
        public int Count { get; set; }
        public List<T> Data { get; set; }
    }

    public class StripeLineItem : StripeId
    {
        public string Type { get; set; }
        public bool Livemode { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public bool Proration { get; set; }
        public StripePeriod Period { get; set; }
        public int? Quantity { get; set; }
        public StripePlan Plan { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }

    public class StripePlan : StripeId
    {
        public bool Livemode { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Identifier { get; set; }
        public StripePlanInterval Interval { get; set; }
        public string Name { get; set; }
        public int? TrialPeriodDays { get; set; }
    }

    public class StripePeriod
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public enum StripePlanInterval
    {
        month,
        year
    }

    public class StripeDiscount : StripeId
    {
        public string Customer { get; set; }
        public StripeCoupon Coupon { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }

    public class StripeCoupon : StripeId
    {
        public int? PercentOff { get; set; }
        public int? AmountOff { get; set; }
        public string Currency { get; set; }
        public bool Livemode { get; set; }
        public StripeCouponDuration Duration { get; set; }
        public DateTime? RedeemBy { get; set; }
        public int? MaxRedemptions { get; set; }
        public int TimesRedeemed { get; set; }
        public int? DurationInMonths { get; set; }
    }

    public enum StripeCouponDuration
    {
        forever,
        once,
        repeating
    }

    public class StripeCustomer : StripeId
    {
        public DateTime? Created { get; set; }
        public bool Livemode { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public bool? Deliquent { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public StripeSubscription Subscription { get; set; }
        public StripeDiscount Discount { get; set; }
        public int AccountBalance { get; set; }
        public StripeCollection<StripeCard> Cards { get; set; }
        public bool Deleted { get; set; }
        public string DefaultCard { get; set; }
    }

    public class DeleteStripeCustomer
    {
        public string Id { get; set; }
    }

    public class GetAllStripeCustomers
    {
        public int? Count { get; set; }
        public int? Offset { get; set; }
        public StripeDateRange Created { get; set; }
    }

    public class StripeDateRange
    {
        public DateTime? Gt { get; set; }
        public DateTime? Gte { get; set; }
        public DateTime? Lt { get; set; }
        public DateTime? Lte { get; set; }
    }

    public class StripeCard : StripeId
    {
        public string Last4 { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string Cvc { get; set; }
        public string Name { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public string AddressCountry { get; set; }
        public StripeCvcCheck? CvcCheck { get; set; }
        public string AddressLine1Check { get; set; }
        public string AddressZipCheck { get; set; }

        public string Fingerprint { get; set; }
        public string Customer { get; set; }
        public string Country { get; set; }
    }

    public enum StripeCvcCheck
    {
        Unknown,
        Pass,
        Fail,
        Unchecked
    }

    public class StripeSubscription : StripeId
    {
        public DateTime? CurrentPeriodEnd { get; set; }
        public StripeSubscriptionStatus Status { get; set; }
        public StripePlan Plan { get; set; }
        public DateTime? CurrentPeriodStart { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? TrialStart { get; set; }
        public bool? CancelAtPeriodEnd { get; set; }
        public DateTime? TrialEnd { get; set; }
        public DateTime? CanceledAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
    }

    public enum StripeSubscriptionStatus
    {
        Unknown,
        Trialing,
        Active,
        PastDue,
        Canceled,
        Unpaid
    }

    public class StripeCharge : StripeId
    {
        public bool LiveMode { get; set; }
        public int Amount { get; set; }
        public bool Captured { get; set; }
        public StripeCard Card { get; set; }
        public DateTime Created { get; set; }
        public string Currency { get; set; }
        public bool Paid { get; set; }
        public bool Refunded { get; set; }
        public List<StripeRefund> Refunds { get; set; }
        public int AmountRefunded { get; set; }
        public string BalanceTransaction { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }
        public StripeDispute Dispute { get; set; }
        public string FailureCode { get; set; }
        public string FailureMessage { get; set; }
        public string Invoice { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }

    public class CreateStripeCharge : StripeId
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Customer { get; set; }
        public StripeCard Card { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public bool Capture { get; set; }
        public int? ApplicationFee { get; set; }
    }

    public class GetStripeCharge
    {
        public string Id { get; set; }
    }

    public class UpdateStripeCharge
    {
        public string Description { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }

    public class StripeRefund : StripeObject
    {
        public int Amount { get; set; }
        public DateTime Created { get; set; }
        public string Currency { get; set; }
        public string BalanceTransaction { get; set; }
    }

    public class StripeDispute : StripeObject
    {
        public StripeDisputeStatus Status { get; set; }
        public string Evidence { get; set; }
        public string Charge { get; set; }
        public DateTime? Created { get; set; }
        public string Currency { get; set; }
        public int Amount;
        public bool LiveMode { get; set; }
        public StripeDisputeReason Reason { get; set; }
        public DateTime? EvidenceDueBy { get; set; }
    }

    public class StripeFeeDetail
    {
        public string Type { get; set; }
        public string Currency { get; set; }
        public string Application { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }

    public enum StripeDisputeStatus
    {
        Won,
        Lost,
        NeedsResponse,
        UnderReview
    }

    public enum StripeDisputeReason
    {
        Duplicate,
        Fraudulent,
        SubscriptionCanceled,
        ProductUnacceptable,
        ProductNotReceived,
        Unrecognized,
        CreditNotProcessed,
        General
    }
    
}