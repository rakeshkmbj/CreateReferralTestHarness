using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using CreateReferralTestHarness.Models;

namespace CreateReferralTestHarness.Controllers
{
    //public class CreateReferralController : ApiController
    //{
    //}
    public class CreateReferralController : Controller
    {
        CreateReferral _model;
        static string _accessToken;

        //string postURL = "https://nbty--dev5.cs69.my.salesforce.com/services/apexrest/referralservice";
        string postURL = "https://nbty--UAT.cs64.my.salesforce.com/services/apexrest/CreateReferrals";

        public ActionResult Index()
        {
            return View();
        }


        private void getAccessToken()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                using ( WebClient client = new WebClient() )
                {
                    string tokenURL = "https://nbty--UAT.cs64.my.salesforce.com//services/oauth2/token";

                    var data = "grant_type=refresh_token"
                         + "&client_id=" + HttpUtility.UrlEncode( "3MVG967gVD5fuTmL1omVvIWrWPtG_rpNRy9MO5Cq5LQc.LLg2fMDrW3QsNB5tGFHSsvLAj5dPkDeNt0yFyoI5" )
                         + "&client_secret=" + HttpUtility.UrlEncode( "5046757764784457611" )
                         + "&refresh_token=" + HttpUtility.UrlEncode( "5Aep8612Xuhpe0phpPd40Q87srqTgH2W1bpmH8fICFgKwkmywG01JDppdvK20OSeSdm5CJlIHbHx7o.3Hay3jay" );

                    client.Headers[ HttpRequestHeader.ContentType ] = "application/x-www-form-urlencoded";

                    // https://nbty--UAT.cs64.my.salesforce.com//services/oauth2/token
                    var jsonResponse = client.UploadString( tokenURL, data );

                    OAuth oAuth = JsonConvert.DeserializeObject<OAuth>( jsonResponse );

                    _accessToken = oAuth.access_token;
                }
            }
            catch ( Exception e )
            {
                //var db = Database.OpenNamedConnection( "OrderProcessingDb" );
                //var result = db.SafetechEvents.Insert( EventMessage: "SalesForce post call Error: " + e.Message );
                //return Content( e.Message, "application/json" );
            }
        }

        [HttpGet]
        public ActionResult TrackReferral( CreateReferral model )
        {
            try
            {
                var accountId = model.AccountId;

                if ( _accessToken == null )
                {
                    getAccessToken();
                }

          //      if ( ModelState.IsValid )
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    //var request = JsonConvert.SerializeObject( _model );

                    using ( WebClient client = new WebClient() )
                    {
                        client.Headers[ HttpRequestHeader.Accept ] = "application/json";
                        client.Headers[ HttpRequestHeader.ContentType ] = "application/json";
                        //                        client.Headers[ HttpRequestHeader.ContentType ] = "application/json; charset=utf-8";
                        client.Headers[ HttpRequestHeader.Authorization ] = "Bearer " + _accessToken;

                        //                        client.Encoding = System.Text.Encoding.UTF8;
                        
                        var jsonResponse = client.DownloadString( "https://nbty--UAT.cs64.my.salesforce.com/services/apexrest/TrackReferrals?AccountId=" + accountId );

                        //return Content( jsonResponse, "application/json" );
                        return Json( jsonResponse, JsonRequestBehavior.AllowGet );

                        //throw new NotImplementedException();
                    }
                }
            }
            catch ( System.Net.WebException e )
            {
                if ( ( (HttpWebResponse)e.Response ).StatusCode == HttpStatusCode.Unauthorized )
                {
                    // get token and retry
                    getAccessToken();

                    //sendJourney( _accessToken, _model );
                    TrackReferral( model );

                    return Content( e.Message, "application/json" );
                }
                return Content( e.Message, "application/json" );
            }

            return View( "TrackReferral", model );
        }

        [HttpGet]
        public ActionResult GetRewards( CreateReferral model )
        {
            try
            {
                var accountId = model.AccountId;

                if ( _accessToken == null )
                {
                    getAccessToken();
                }

                //      if ( ModelState.IsValid )
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    //var request = JsonConvert.SerializeObject( _model );

                    using ( WebClient client = new WebClient() )
                    {
                        client.Headers[ HttpRequestHeader.Accept ] = "application/json";
                        client.Headers[ HttpRequestHeader.ContentType ] = "application/json";
                        //                        client.Headers[ HttpRequestHeader.ContentType ] = "application/json; charset=utf-8";
                        client.Headers[ HttpRequestHeader.Authorization ] = "Bearer " + _accessToken;

                        //                        client.Encoding = System.Text.Encoding.UTF8;

                        var jsonResponse = client.DownloadString( "https://nbty--UAT.cs64.my.salesforce.com/services/apexrest/TrackRewards?AccountId=" + accountId );

                        //return Content( jsonResponse, "application/json" );
                        return Json( jsonResponse, JsonRequestBehavior.AllowGet );

                        //throw new NotImplementedException();
                    }
                }
            }
            catch ( System.Net.WebException e )
            {
                if ( ( (HttpWebResponse)e.Response ).StatusCode == HttpStatusCode.Unauthorized )
                {
                    // get token and retry
                    getAccessToken();

                    //sendJourney( _accessToken, _model );
                    GetRewards( model );

                    return Content( e.Message, "application/json" );
                }
                return Content( e.Message, "application/json" );
            }

            return View( "TrackReferral", model );
        }

        [HttpGet]
        public ActionResult GetRewardBalance( CreateReferral model )
        {
            try
            {
                var accountId = model.AccountId;

                if ( _accessToken == null )
                {
                    getAccessToken();
                }

                //      if ( ModelState.IsValid )
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    //var request = JsonConvert.SerializeObject( _model );

                    using ( WebClient client = new WebClient() )
                    {
                        client.Headers[ HttpRequestHeader.Accept ] = "application/json";
                        client.Headers[ HttpRequestHeader.ContentType ] = "application/json";
                        //                        client.Headers[ HttpRequestHeader.ContentType ] = "application/json; charset=utf-8";
                        client.Headers[ HttpRequestHeader.Authorization ] = "Bearer " + _accessToken;

                        //                        client.Encoding = System.Text.Encoding.UTF8;

                        var jsonResponse = client.DownloadString( "https://nbty--UAT.cs64.my.salesforce.com/services/apexrest/GetRewardBalance?AccountId=" + accountId );

                        return Content( jsonResponse, "application/json" );

                        //throw new NotImplementedException();
                    }
                }
            }
            catch ( System.Net.WebException e )
            {
                if ( ( (HttpWebResponse)e.Response ).StatusCode == HttpStatusCode.Unauthorized )
                {
                    // get token and retry
                    getAccessToken();

                    //sendJourney( _accessToken, _model );
                    GetRewardBalance( model );

                    return Content( e.Message, "application/json" );
                }
                return Content( e.Message, "application/json" );
            }

            return View( "TrackReferral", model );
        }

        [HttpPost]
        public ActionResult Create( CreateReferral model )
        {
            try
            {
                if ( model.Referrals[ 1 ].EmailAddress == null )
                {
                    _model = new CreateReferral();
                    _model.AccountId = model.AccountId;
                    _model.Referrals = new Referral[1];
                    _model.Referrals[ 0 ] = model.Referrals[ 0 ];
                }
                else
                {
                    _model = model;
                }

                if ( _accessToken == null )
                {
                    getAccessToken();
                }

                if ( ModelState.IsValid )
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var request = JsonConvert.SerializeObject( _model );

                    using ( WebClient client = new WebClient() )
                    {
                        client.Headers[ HttpRequestHeader.Accept ] = "application/json";
                        client.Headers[ HttpRequestHeader.ContentType ] = "application/json";
                        //                        client.Headers[ HttpRequestHeader.ContentType ] = "application/json; charset=utf-8";
                        client.Headers[ HttpRequestHeader.Authorization ] = "Bearer " + _accessToken;

                        //                        client.Encoding = System.Text.Encoding.UTF8;

                        var jsonResponse = client.UploadString( postURL, request );

                        return Content( jsonResponse, "application/json" );

                        //throw new NotImplementedException();
                    }
                }
            }
            catch ( System.Net.WebException e )
            {
                if ( ( (HttpWebResponse)e.Response ).StatusCode == HttpStatusCode.Unauthorized )
                {
                    // get token and retry
                    getAccessToken();

                    //sendJourney( _accessToken, _model );
                    Create( model );

                    return Content( e.Message, "application/json" );
                }
                return Content( e.Message, "application/json" );
            }

            return View( "Index", model );
        }

        private class ClientDetails
        {
            public string clientId { get; set; }
            public string clientSecret { get; set; }
        }

        private class OAuth
        {
            public string id { get; set; }
            public string issued_at { get; set; }
            public string scope { get; set; }
            public string instance_url { get; set; }
            public string signature { get; set; }
            public string access_token { get; set; }
        }
    }
}

