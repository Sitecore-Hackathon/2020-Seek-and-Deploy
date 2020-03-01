using Meetcore.Feature.Authentication.Helper;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using Sitecore.Security.Accounts;
using Sitecore.Security.Authentication;
using BasicCompany.Foundation.FieldRendering;
using System;

namespace Meetcore.Feature.Authentication.SubmitActions.LoginUser
{
    public class LoginUser : SubmitActionBase<LoginUserData>
    {
        public LoginUser(ISubmitActionData submitActionData) : base(submitActionData)
        {
        }

        protected override bool Execute(LoginUserData data, FormSubmitContext formSubmitContext)
        {
            Assert.ArgumentNotNull(data, nameof(data));
            Assert.ArgumentNotNull(formSubmitContext, nameof(formSubmitContext));

            var fields = GetFormFields(data, formSubmitContext);
            Assert.IsNotNull(fields, nameof(fields));

            if (UsernameOrPasswordFieldIsNull(fields))
            {
                return AbortForm(formSubmitContext);
            }

            var values = fields.GetFieldValues();
            if (UsernameOrPasswordValueIsNull(values))
            {
                return AbortForm(formSubmitContext);
            }

            var user = Login(values.Username, values.Password);
            if (user == null)
            {
                return AbortForm(formSubmitContext);
            }
            var id = Context.User.GetUserGuid();

            formSubmitContext.RedirectOnSuccess = true;
            formSubmitContext.RedirectUrl = "/Home";
            
            return true;
        }

        public Guid GetUserGuid() {
            var membershipUser = System.Web.Security.Membership.GetUser(Context.User.Name);
            var userId = membershipUser.ProviderUserKey;
            return new Guid(userId as string);
        }

        protected virtual User Login(string userName, string password)
        {
            var accountName = string.Empty;
            var domain = Context.Domain;
            if (domain != null)
            {
                accountName = domain.GetFullName(userName);
            }

            var result = AuthenticationManager.Login(accountName, password);
            if (!result)
            {
                return null;
            }

            var user = AuthenticationManager.GetActiveUser();
            return user;
        }

        private LoginUserFormFields GetFormFields(LoginUserData data, FormSubmitContext formSubmitContext)
        {
            Assert.ArgumentNotNull(data, nameof(data));
            Assert.ArgumentNotNull(formSubmitContext, nameof(formSubmitContext));

            return new LoginUserFormFields
            {
                Username = FieldHelper.GetFieldById(data.UserNameFieldId, formSubmitContext.Fields),
                Password = FieldHelper.GetFieldById(data.PasswordFieldId, formSubmitContext.Fields)
            };
        }

        private bool UsernameOrPasswordFieldIsNull(LoginUserFormFields field)
        {
            Assert.ArgumentNotNull(field, nameof(field));
            return field.Username == null || field.Password == null;
        }

        private bool UsernameOrPasswordValueIsNull(LoginUserFieldValues values)
        {
            Assert.ArgumentNotNull(values, nameof(values));
            return string.IsNullOrEmpty(values.Username) || string.IsNullOrEmpty(values.Password);
        }

        private bool AbortForm(FormSubmitContext formSubmitContext)
        {
            formSubmitContext.Abort();
            return false;
        }

        internal class LoginUserFormFields
        {
            public IViewModel Username { get; set; }
            public IViewModel Password { get; set; }

            public LoginUserFieldValues GetFieldValues()
            {
                return new LoginUserFieldValues
                {
                    Username = FieldHelper.GetValue(Username),
                    Password = FieldHelper.GetValue(Password)
                };
            }
        }

        internal class LoginUserFieldValues
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}