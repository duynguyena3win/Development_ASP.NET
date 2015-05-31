using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;

namespace Bank_Host
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BankService" in both code and config file together.
    public class BankService : IBankService
    {
        public void DoWork()
        {
        }

        public Account LoadProfile(string idacc)
        {
            Account Temp;
            XDocument doc = XDocument.Load("Database_Banking.xml");
            
            foreach (var node in doc.Document.Descendants("ACCOUNT"))
            {
                if (node.Attribute("IdAccount").Value == idacc)
                {
                    Temp = new Account();
                    Temp.IdCard = node.Attribute("IdCard").Value;
                    Temp.IdAccount = idacc;
                    Temp.Name = node.Attribute("Name").Value;
                    Temp.EndDate = Convert.ToDateTime(node.Attribute("DateEnd").Value);
                    Temp.Funds = Convert.ToInt64(node.Attribute("Funds").Value);
                    return Temp;
                }
            }
            
            return null;
        }

        public bool GetFunds(string idaccount, Int64 funds)
        {
            XDocument doc = XDocument.Load("Database_Banking.xml");

            foreach (var node in doc.Document.Descendants("ACCOUNT"))
            {
                if (node.Attribute("IdAccount").Value == idaccount)
                {
                    if (Convert.ToInt64(node.Attribute("Funds").Value) >= funds + 50000)
                    {
                        node.SetAttributeValue("Funds", Convert.ToInt64(node.Attribute("Funds").Value) - funds);
                        doc.Save("Database_Banking.xml");
                        return true;
                    }
                    return false;
                }
            }

            return false;
        }
       
        public bool LogIn(string idcard, string pin)
        {
            XDocument doc = XDocument.Load("Database_Banking.xml");

            foreach (var node in doc.Document.Descendants("ACCOUNT"))
            {
                if (node.Attribute("IdCard").Value == idcard && node.Attribute("Pin").Value == pin)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckAccount(string idaccount)
        {
            XDocument doc = XDocument.Load("Database_Banking.xml");

            foreach (var node in doc.Document.Descendants("ACCOUNT"))
            {
                if (node.Attribute("IdAccount").Value == idaccount)
                {
                    return true;
                }
            }
            return false;
        }


        public string GetIdAccount(string idcard)
        {
            XDocument doc = XDocument.Load("Database_Banking.xml");

            foreach (var node in doc.Document.Descendants("ACCOUNT"))
            {
                if (node.Attribute("IdCard").Value == idcard)
                {
                    return node.Attribute("IdAccount").Value;
                }
            }
            return null;
        }
    }
}
