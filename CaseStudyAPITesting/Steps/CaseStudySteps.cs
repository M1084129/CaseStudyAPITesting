using CaseStudyAPITesting.CommonMethodsObj;
using System;
using TechTalk.SpecFlow;

namespace CaseStudyAPITesting.FeatureFiles
{
    [Binding]
    public class CaseStudySteps
    {
        APIObj Obj = new APIObj();
        [When(@"user send get request")]
        public void WhenUserSendGetRequest()
        {
            Obj.GetListOfUsersRequest();
        }
        
        [Then(@"user should able to verify result")]
        public void ThenUserShouldAbleToVerifyResult()
        {
            Obj.VerifyGetResult();
        }

        [When(@"user send Post requests")]
        public void WhenUserSendPostRequests()
        {
            Obj.PostRequestforCreateUser();
        }

        [Then(@"user should able to verify")]
        public void ThenUserShouldAbleToVerify()
        {
            Obj.VerifyPostResult();
        }

    }
}
