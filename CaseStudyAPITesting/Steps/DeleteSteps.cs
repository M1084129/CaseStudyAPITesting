using CaseStudyAPITesting.CommonMethodsObj;
using System;
using TechTalk.SpecFlow;

namespace CaseStudyAPITesting.FeatureFiles
{
    [Binding]
    public class DeleteSteps
    {
        APIObj obj = new APIObj();
        [When(@"user send Delete request")]
        public void WhenUserSendDeleteRequest()
        {
            obj.DeleteUser();
        }
        
        [Then(@"user should able to delete the details and see success")]
        public void ThenUserShouldAbleToDeleteTheDetailsAndSeeSuccess()
        {
            obj.VerifyDeleteResult();
        }
    }
}
