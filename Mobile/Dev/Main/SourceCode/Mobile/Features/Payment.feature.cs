﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace UAT.Mobile.Automation.Mobile.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Payment")]
    public partial class PaymentFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Payment.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Payment", "\tIn order to place an order\r\n\tAs a customer\r\n\tI want to be pay using multiple meh" +
                    "tods of payments", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a registered customer with Account Credit the Account Credit panel is displaye" +
            "d")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        [NUnit.Framework.CategoryAttribute("payment")]
        public virtual void AsARegisteredCustomerWithAccountCreditTheAccountCreditPanelIsDisplayed()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a registered customer with Account Credit the Account Credit panel is displaye" +
                    "d", new string[] {
                        "checkout",
                        "payment"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("I am on the checkout page with a product in my basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("I enter my account credit credentials to sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("The account credit panel is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a registered customer I can place an order using Account Credit")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        [NUnit.Framework.CategoryAttribute("payment")]
        public virtual void AsARegisteredCustomerICanPlaceAnOrderUsingAccountCredit()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a registered customer I can place an order using Account Credit", new string[] {
                        "checkout",
                        "payment"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
testRunner.Given("I am on the checkout page with a product in my basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
testRunner.When("I enter my account credit credentials to sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.And("I click apply account credit to this order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.And("I click place order using account credit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.Then("The confirmation page is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I want to place an order with an offer code")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        [NUnit.Framework.CategoryAttribute("payment")]
        public virtual void IWantToPlaceAnOrderWithAnOfferCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I want to place an order with an offer code", new string[] {
                        "checkout",
                        "payment"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
testRunner.Given("I am on the checkout page with 1 or more product(s) in my basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
testRunner.When("I place an order with valid offer code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
testRunner.Then("The confirmation page is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a customer I want to know that my address failed Open Invoice credit check for" +
            " DE markets")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        [NUnit.Framework.CategoryAttribute("payment")]
        [NUnit.Framework.CategoryAttribute("openinvoice")]
        [NUnit.Framework.CategoryAttribute("de")]
        [NUnit.Framework.CategoryAttribute("WIP")]
        public virtual void AsACustomerIWantToKnowThatMyAddressFailedOpenInvoiceCreditCheckForDEMarkets()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a customer I want to know that my address failed Open Invoice credit check for" +
                    " DE markets", new string[] {
                        "checkout",
                        "payment",
                        "openinvoice",
                        "de",
                        "WIP",
                        "ignore"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
testRunner.Given("I am on the checkout page with a women product in my basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
testRunner.And("I enter my negative account credit credentials to sign", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
testRunner.When("I select payment by Open Invoice", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
testRunner.Then("The message about Open Invoice not available is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a customer I want to know that my address passed Open Invoice credit check for" +
            " DE markets")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        [NUnit.Framework.CategoryAttribute("payment")]
        [NUnit.Framework.CategoryAttribute("openinvoice")]
        [NUnit.Framework.CategoryAttribute("de")]
        public virtual void AsACustomerIWantToKnowThatMyAddressPassedOpenInvoiceCreditCheckForDEMarkets()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a customer I want to know that my address passed Open Invoice credit check for" +
                    " DE markets", new string[] {
                        "checkout",
                        "payment",
                        "openinvoice",
                        "de",
                        "ignore"});
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
testRunner.Given("I am on the checkout page with a women product in my basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
testRunner.And("I enter my positive account credit credentials to sign", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
testRunner.When("I select payment by Open Invoice", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("The message about Open Invoice is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a registered customer with Account Credit, I can place an order using Credit C" +
            "ard for UK, US, DE, AT, FR, AU markets")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        [NUnit.Framework.CategoryAttribute("payment")]
        [NUnit.Framework.CategoryAttribute("uk")]
        [NUnit.Framework.CategoryAttribute("us")]
        [NUnit.Framework.CategoryAttribute("de")]
        [NUnit.Framework.CategoryAttribute("at")]
        [NUnit.Framework.CategoryAttribute("fr")]
        [NUnit.Framework.CategoryAttribute("au")]
        public virtual void AsARegisteredCustomerWithAccountCreditICanPlaceAnOrderUsingCreditCardForUKUSDEATFRAUMarkets()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a registered customer with Account Credit, I can place an order using Credit C" +
                    "ard for UK, US, DE, AT, FR, AU markets", new string[] {
                        "checkout",
                        "payment",
                        "uk",
                        "us",
                        "de",
                        "at",
                        "fr",
                        "au"});
#line 41
this.ScenarioSetup(scenarioInfo);
#line 42
testRunner.Given("I am on the checkout page with a product in my basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 43
testRunner.When("I enter my account credit credentials to sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.And("I continue without using account credit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
testRunner.And("I place an order using credit card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
testRunner.Then("The confirmation page is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
