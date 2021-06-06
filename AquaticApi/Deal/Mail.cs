using System;

namespace AquaticApi.Deal
{
    public class Mail
    {
        public bool ExisteMail(string _mail) 
        {
            DataAccess.Mail mail;

            try
            {
                mail = new DataAccess.Mail();
                return mail.ExisteMail(_mail);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
