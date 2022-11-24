using RestSharp;
using RestSharp.Authenticators;

namespace MailgunTest
{
    public static class SendSimpleMessageChunk
    {
        public static RestResponse SendSimpleMessage()
        {
            RestClient client = new RestClient("https://api.mailgun.net/v3/");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            "MY_API_KEY");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "MY_DOMAIN", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@MY_DOMAIN>");
            request.AddParameter("to", "MY_EMAIL");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", "Testing some Mailgun awesomness!");
            request.Method = Method.Post;
            return client.Execute(request);
        }
    }
}
