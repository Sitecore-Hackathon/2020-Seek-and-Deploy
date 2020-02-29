using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meetcore.Feature.Authentication.SubmitActions.LoginUser
{
    public class LoginUserData
    {
        public Guid UserNameFieldId { get; set; }
        public Guid PasswordFieldId { get; set; }
    }
}