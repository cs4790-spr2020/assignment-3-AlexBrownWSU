using System;
using System.Net.Mail;

namespace BlabberApp.Domain.Entities
{
    public class User : BaseEntity
    {
        private System.DateTime _regDTTM;
        public System.DateTime RegDTTM
        {
            get { return this._regDTTM; }
            set { this._regDTTM = value; }
        }
        private System.DateTime _lastLoginDTTM;
        public System.DateTime LastLoginDTTM
        {
            get { return this._lastLoginDTTM; }
            set { this._lastLoginDTTM = value; }
        }
        private string _userId;
        public string UserID
        {
            get { return this._userId; }
            set
            {
                try
                {
                    MailAddress m = new MailAddress(value);
                    this._userId = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("DUH, not an email");//fe.Message);
                }
            }
        }
    }
}