namespace BigFootVentures.Business.EmailTemplates.Management
{
    public static class UserAccountTemplate
    {
        public static string GetEmailVerificationTemplate(int id, string url, string firstName)
        {
            return $@"<div>
                        <span>Hi {firstName},</span><br />
                    </div>
                    <p>Please click on these <a href='{url}/Public/UserAccountVerification/{id}'>link</a> to verify your account and set your own password.</p>";
        }
    }
}
