using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;


namespace ComproPikoulasTest.Business.Services
{
    public class Validator
    {
        //String RegeXPatternEmail = @'^ (? (")(".+? (?< !\\)"@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$; ;


        public Validator() { }

        public bool IsEmailValid(string email)
        {
            try
            {
                var test = new MailAddress(email);
            }
            catch (Exception ex)
            {

                throw;
            }
           
            
            return false;
        }
    }
}
