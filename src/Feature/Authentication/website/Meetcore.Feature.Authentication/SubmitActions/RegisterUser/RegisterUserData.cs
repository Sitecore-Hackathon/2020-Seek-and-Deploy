using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meetcore.Feature.Authentication.SubmitActions.RegisterUser
{
    public class RegisterUserData
    {
        public Guid EmailFieldId { get; set; }

        public Guid PasswordFieldId { get; set; }

        public Guid FullNameFieldId { get; set; }

        public string ProfileId { get; set; }
    }
}