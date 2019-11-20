using System.Collections.Generic;
using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;
using log4net;
using System.Web;
using System.Net;

namespace eMonthleys
{
    public static class DirectPayment
    {
        static DirectPayment()
        {
            // Load the log4net configuration settings from Web.config or App.config    
            log4net.Config.XmlConfigurator.Configure();
        }

        // Logs output statements, errors, debug info to a text file
        private static ILog logger = LogManager.GetLogger(typeof(DirectPayment));

        // # DoDirectPaymentAPIOperation
        // The MassPay API operation makes a payment to one or more PayPal account holders.
        public static DoDirectPaymentResponseType DoDirectPaymentAPIOperation(CreditCardDetailsType creditCard, string amount)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // Create the DoDirectPaymentResponseType object
            DoDirectPaymentResponseType responseDoDirectPaymentResponseType = new DoDirectPaymentResponseType();

            try
            {
                // Create the DoDirectPaymentReq object
                DoDirectPaymentReq doDirectPayment = new DoDirectPaymentReq();
                DoDirectPaymentRequestDetailsType doDirectPaymentRequestDetails = new DoDirectPaymentRequestDetailsType();

                // Information about the credit card to be charged.

                doDirectPaymentRequestDetails.CreditCard = creditCard;

                // Information about the payment
                PaymentDetailsType paymentDetails = new PaymentDetailsType();

                //paymentDetails.NotifyURL = "http://IPNhost";
                BasicAmountType orderTotal = new BasicAmountType(CurrencyCodeType.CAD, amount);
                paymentDetails.OrderTotal = orderTotal;
                doDirectPaymentRequestDetails.PaymentDetails = paymentDetails;

                // IP address of the buyer's browser.
                // `Note:
                // PayPal records this IP addresses as a means to detect possible fraud.`
                doDirectPaymentRequestDetails.IPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; //127.0.0.1";

                DoDirectPaymentRequestType doDirectPaymentRequest = new DoDirectPaymentRequestType(doDirectPaymentRequestDetails);
                doDirectPayment.DoDirectPaymentRequest = doDirectPaymentRequest;

                // Create the service wrapper object to make the API call
                PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();

                // # API call
                // Invoke the DoDirectPayment method in service wrapper object
                responseDoDirectPaymentResponseType = service.DoDirectPayment(doDirectPayment);

                if (responseDoDirectPaymentResponseType != null)
                {
                    // Response envelope acknowledgement
                    string acknowledgement = "DoDirectPayment API Operation - ";
                    acknowledgement += responseDoDirectPaymentResponseType.Ack.ToString();
                    logger.Info(acknowledgement + "\n");
                    HttpContext.Current.Session["acknowledgement"] = acknowledgement;

                    // # Success values
                    if (responseDoDirectPaymentResponseType.Ack.ToString().Trim().ToUpper().Equals("SUCCESS"))
                    {
                        // Unique identifier of the transaction
                        logger.Info("Transaction ID : " + responseDoDirectPaymentResponseType.TransactionID + "\n");
                        HttpContext.Current.Session["acknowledgement"] = string.Concat("Transaction ID : ", responseDoDirectPaymentResponseType.TransactionID, "<br />");

                    }
                    // # Error Values
                    else
                    {
                        List<ErrorType> errorMessages = responseDoDirectPaymentResponseType.Errors;
                        foreach (ErrorType error in errorMessages)
                        {
                            logger.Debug("API Error Message : " + error.LongMessage);
                            HttpContext.Current.Session["acknowledgement"] = string.Concat("API Error Message : ", error.LongMessage, "<br />");
                        }
                    }
                }
            }
            // # Exception log    
            catch (System.Exception ex)
            {
                // Log the exception message       
                logger.Debug("Error Message : " + ex.Message);
                // Console.WriteLine("Error Message : " + ex.Message);
            }
            return responseDoDirectPaymentResponseType;
        }

    }
}
