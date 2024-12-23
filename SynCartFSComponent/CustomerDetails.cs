using FileHelpers;

namespace SynCartFSComponent
{
    [DelimitedRecord(",")]
    public class CustomerDetails
    {
        /// <summary>
        /// static integer to manage Unique Customer ID
        /// </summary>
        private static int s_customerID=1000;

          /// <summary>
        /// Unique Customer ID
        /// </summary>
        /// <value>CID1001</value>
        public string CustomerID { get; set; }
    
        /// <summary>
        /// Customer Name
        /// </summary>
        /// <value></value>
        public string CustomerName { get; set; }

        /// <summary>
        /// To Store Customer Wallet Balance Read, Write
        /// </summary>
        /// <value></value>
        
        public string City { get; set; }
        /// <summary>
        /// Customer Phone Number
        /// </summary>
        /// <value></value>
        private double _walletBalance { get; set; }
      
        
        /// <summary>
        /// Customer Resident City
        /// </summary>
        /// <value></value>
      
        public string MobileNumber { get; set; }
        
        /// <summary>
        /// Customer's Email ID
        /// </summary>
        /// <value></value>
        public string EmailID { get; set; }

        /// <summary>
        /// To Store Customer Wallet Balance Read Only
        /// </summary>
        /// <value></value>
        public double WalletBalance { get{return _walletBalance;} }
        public CustomerDetails()
        {}        
        public CustomerDetails(string values)
        {
            string[] value=values.Split(",");
            CustomerID=value[0];
            s_customerID=int.Parse(value[0].Remove(0,3));
            CustomerName=value[1];
            City=value[2];
            MobileNumber=value[2];
            _walletBalance=double.Parse(value[4]);
            EmailID=value[5];
        }
        /// <summary>
        /// Parametrised Constructor
        /// </summary>
        /// <param name="customerName">Customer's Name</param>
        /// <param name="city">Customer's Resident City</param>
        /// <param name="mobileNumber">Customer's Mobile Number</param>
        /// <param name="walletBalance">Customer's Wallet Balance</param>
        /// <param name="emailID">Customer's Email ID</param>
        public CustomerDetails(string customerName,string city,string mobileNumber,double walletBalance,string emailID)
        {
            CustomerID=$"CID{++s_customerID}";
            CustomerName=customerName;
            City=city;
            MobileNumber=mobileNumber;
            _walletBalance=walletBalance;
            EmailID=emailID;
        }

        /// <summary>
        /// To Return Customer Current Balance
        /// </summary>
        /// <returns></returns>
        public double CurrentBalance()
        {
            return _walletBalance;
        }
        /// <summary>
        /// To Recharge Customer's Wallet
        /// </summary>
        /// <param name="rechargeAmount"></param>
        public void RechargeWallet(double rechargeAmount)
        {
            _walletBalance=_walletBalance+rechargeAmount;
        }
        /// <summary>
        /// To Deduct Amount from Cusotmer's Wallet
        /// </summary>
        /// <param name="deductAmoubt"></param>
        public void DeductWallet(double deductAmoubt)
        {
            _walletBalance=_walletBalance-deductAmoubt;
        }
    }
}