namespace SportPredictionsSystem.Web.Models.PayPal
{
    using System.Configuration;

    public class PayPalModel
    {
        public string Cmd { get; set; }

        public string Business { get; set; }

        public string NoShipping { get; set; }

        public string Return { get; set; }

        public string CancelReturn { get; set; }

        public string NotifyUrl { get; set; }

        public string CurrencyCode { get; set; }

        public string ItemName { get; set; }

        public string Amount { get; set; }

        public string ActionUrl { get; set; }

        public PayPalModel(bool useSandbox)
        {
            this.Cmd = "_xclick";
            this.Business = ConfigurationManager.AppSettings["this.Business"];
            this.CancelReturn = ConfigurationManager.AppSettings["this.CancelReturn"];
            this.Return = ConfigurationManager.AppSettings["return"];
            this.ActionUrl = useSandbox ? ConfigurationManager.AppSettings["test_url"] : ConfigurationManager.AppSettings["Prod_url"];

            // We can add parameters here, for example OrderId, CustomerId, etc….
            this.NotifyUrl = ConfigurationManager.AppSettings["this.NotifyUrl"];
            // We can add parameters here, for example OrderId, CustomerId, etc….
            this.CurrencyCode = ConfigurationManager.AppSettings["this.CurrencyCode"];
        }
    }
}