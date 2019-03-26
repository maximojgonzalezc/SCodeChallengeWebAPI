using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeCodeChallengeWebAPI.Models.Validator
{
    public class contactValidator
    {
        List<string> errorList = new List<string>();

        public List<string> ValidateContact(Contact contact)
        {
            IsValidUSPhoneNumber(contact.ContactPhone.PersonalPhone);
            IsValidUSPhoneNumber(contact.ContactPhone.WorkPhone);
            IsValidEmail(contact.Email);
            return errorList;
        }

        private bool MatchStringFromRegex(string str, string regexstr)
        {
            str = str.Trim();
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(regexstr);
            return pattern.IsMatch(str);
        }

        private void IsValidUSPhoneNumber(string phone)
        {
            string regExPattern = @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$";
            if (!MatchStringFromRegex(phone, regExPattern))
            {
                errorList.Add($"the phone {phone} is not valid");
            }
        }

        private void IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (!(addr.Address == email))
                {
                    errorList.Add("Email is not valid");
                }
            }
            catch
            {
                errorList.Add("Email is not valid");
            }
        }

    }
}
