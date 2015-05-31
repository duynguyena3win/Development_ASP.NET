using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bank_Host
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBankService" in both code and config file together.
    [ServiceContract]
    public interface IBankService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        Account LoadProfile(string idcard);

        [OperationContract]
        bool GetFunds(string idaccount, Int64 funds);

        [OperationContract]
        bool LogIn(string idcard, string pin);

        [OperationContract]
        bool CheckAccount(string idaccount);

        [OperationContract]
        string GetIdAccount(string idcard);
    }

    [DataContract]
    public class Account
    {

        string _pin;
        public string Password
        {
            get { return _pin; }
            set { _pin = value; }
        }
        string _idCard;

        [DataMember]
        public string IdCard
        {
            get { return _idCard; }
            set { _idCard = value; }
        }

        string _name;

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        
        DateTime _endDate;

        [DataMember]
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        
        Int64 _funds;

        [DataMember]
        public Int64 Funds
        {
            get { return _funds; }
            set { _funds = value; }
        }

        string _idAccount;

        [DataMember]
        public string IdAccount
        {
            get { return _idAccount; }
            set { _idAccount = value; }
        }

        public Account()
        {
            Funds = 0;
            EndDate = DateTime.Now;
        }
        public Account(string id, string name, DateTime date, Int64 funds)
        {
            IdCard = id;
            Name = name;
            EndDate = date;
            Funds = funds;
        }

    }
}
