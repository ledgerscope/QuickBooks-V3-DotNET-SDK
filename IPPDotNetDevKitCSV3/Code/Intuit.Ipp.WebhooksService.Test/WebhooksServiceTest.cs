using System;
using Intuit.Ipp.WebhooksService;
using Intuit.Ipp.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intuit.Ipp.WebhooksService.Test
{

    using Intuit.Ipp.Core;
    using Intuit.Ipp.Utility;
    using System.Security.Cryptography;
    using System.Text;

    [TestClass]
    public class WebhooksServiceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

       private static WebhooksService webhooksServiceTestCases;

       [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            webhooksServiceTestCases = new WebhooksService();

        }

        [TestMethod]
        public void ExecuteverifyToken()
        {
            try
            {
                string verifierToken = webhooksServiceTestCases.VerifierToken;
                if (string.IsNullOrWhiteSpace(verifierToken))
                {
                    Assert.Inconclusive("Webhooks verifier token is not configured for this environment.");
                }

                string payload = "{\"eventNotifications\":[{\"realmId\":\"1269959970\",\"dataChangeEvent\":{\"entities\":[{\"name\":\"Vendor\",\"id\":\"40\",\"operation\":\"Update\",\"lastUpdated\":\"2016-10-05T03:09:04.000Z\"},{\"name\":\"Customer\",\"id\":\"43\",\"operation\":\"Create\",\"lastUpdated\":\"2016-10-05T03:07:04.000Z\"}]}}]}";

                string intuitHeaderSignature;
                using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(verifierToken)))
                {
                    intuitHeaderSignature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(payload)));
                }

                bool isWebhooksOk = webhooksServiceTestCases.VerifyPayload(intuitHeaderSignature, payload);

                Assert.AreEqual(isWebhooksOk, true);



            }
            catch (AssertInconclusiveException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.ToString());
            }


        }

        [TestMethod]
        public void GetWebooksEvents()
        {
            try
            {

                string wehooksResponsePayload = "{\"eventNotifications\":[{\"realmId\":\"1269959970\",\"dataChangeEvent\":{\"entities\":[{\"name\":\"Vendor\",\"id\":\"40\",\"operation\":\"Update\",\"lastUpdated\":\"2016-10-05T03:09:04.000Z\"},{\"name\":\"Customer\",\"id\":\"43\",\"operation\":\"Create\",\"lastUpdated\":\"2016-10-05T03:07:04.000Z\"}]}}]}";

                WebhooksEvent webhooksEvent = webhooksServiceTestCases.GetWebooksEvents(wehooksResponsePayload);

                Assert.AreEqual(webhooksEvent.EventNotifications[0].RealmId, "1269959970");
                Assert.AreEqual(webhooksEvent.EventNotifications[0].DataChangeEvent.Entities[0].Name, "Vendor");



            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.ToString());
            }


        }
    }
}
