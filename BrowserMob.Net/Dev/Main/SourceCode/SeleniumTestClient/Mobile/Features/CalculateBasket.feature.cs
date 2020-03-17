﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CalculateBasket")]
    public partial class CalculateBasketFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CalculateBasket.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CalculateBasket", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("As a customer I want to ensure the total value of the items added match the value" +
            " on the checkout")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        public virtual void AsACustomerIWantToEnsureTheTotalValueOfTheItemsAddedMatchTheValueOnTheCheckout()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a customer I want to ensure the total value of the items added match the value" +
                    " on the checkout", new string[] {
                        "checkout"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("I have added an item to the bag on the PDP page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("I go to the checkout page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("The Add to Bag value matched the checkout page value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a customer I want to ensure that the delivery is added on correctly to the bas" +
            "ket total for UK market")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        [NUnit.Framework.CategoryAttribute("uk")]
        [NUnit.Framework.TestCaseAttribute("Standard", null)]
        [NUnit.Framework.TestCaseAttribute("Royal Mail", null)]
        [NUnit.Framework.TestCaseAttribute("Express", null)]
        [NUnit.Framework.TestCaseAttribute("Express Noon", null)]
        public virtual void AsACustomerIWantToEnsureThatTheDeliveryIsAddedOnCorrectlyToTheBasketTotalForUKMarket(string deliveryOption, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "checkout",
                    "uk"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a customer I want to ensure that the delivery is added on correctly to the bas" +
                    "ket total for UK market", @__tags);
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
testRunner.Given("I am on the checkout page with a product in my basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
testRunner.When(string.Format("I click on a UK {0} delivery", deliveryOption), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.Then("The sub total plus the delivery equals the total price", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a customer I want to ensure that the delivery is added on correctly to the bas" +
            "ket total for US market")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        [NUnit.Framework.CategoryAttribute("us")]
        [NUnit.Framework.TestCaseAttribute("Standard", null)]
        [NUnit.Framework.TestCaseAttribute("Premium", null)]
        [NUnit.Framework.TestCaseAttribute("Express", null)]
        public virtual void AsACustomerIWantToEnsureThatTheDeliveryIsAddedOnCorrectlyToTheBasketTotalForUSMarket(string deliveryOption, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "checkout",
                    "us"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a customer I want to ensure that the delivery is added on correctly to the bas" +
                    "ket total for US market", @__tags);
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
testRunner.Given("I am on the checkout page with a product in my basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
testRunner.When(string.Format("I click on a US {0} delivery", deliveryOption), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
testRunner.Then("The sub total plus the delivery equals the total price", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a customer I want to ensure that the delivery is added on correctly to the bas" +
            "ket total for DE market")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        [NUnit.Framework.CategoryAttribute("de")]
        [NUnit.Framework.TestCaseAttribute("Standard", null)]
        [NUnit.Framework.TestCaseAttribute("Express", null)]
        public virtual void AsACustomerIWantToEnsureThatTheDeliveryIsAddedOnCorrectlyToTheBasketTotalForDEMarket(string deliveryOption, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "checkout",
                    "de"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a customer I want to ensure that the delivery is added on correctly to the bas" +
                    "ket total for DE market", @__tags);
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
testRunner.Given("I am on the checkout page with a product in my basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
testRunner.When(string.Format("I click on a DE {0} delivery", deliveryOption), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.Then("The sub total plus the delivery equals the total price", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a customer I want to ensure that the delivery is added on correctly to the bas" +
            "ket total for FR market")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        [NUnit.Framework.CategoryAttribute("fr")]
        [NUnit.Framework.TestCaseAttribute("Standard", null)]
        [NUnit.Framework.TestCaseAttribute("Premium", null)]
        public virtual void AsACustomerIWantToEnsureThatTheDeliveryIsAddedOnCorrectlyToTheBasketTotalForFRMarket(string deliveryOption, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "checkout",
                    "fr"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a customer I want to ensure that the delivery is added on correctly to the bas" +
                    "ket total for FR market", @__tags);
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
testRunner.Given("I am on the checkout page with a product in my basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
testRunner.When(string.Format("I click on a FR {0} delivery", deliveryOption), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
testRunner.Then("The sub total plus the delivery equals the total price", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a customer I want to ensure that the delivery is added on correctly to the bas" +
            "ket total for AU market")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        [NUnit.Framework.CategoryAttribute("au")]
        [NUnit.Framework.TestCaseAttribute("Standard", null)]
        public virtual void AsACustomerIWantToEnsureThatTheDeliveryIsAddedOnCorrectlyToTheBasketTotalForAUMarket(string deliveryOption, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "checkout",
                    "au"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a customer I want to ensure that the delivery is added on correctly to the bas" +
                    "ket total for AU market", @__tags);
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
testRunner.Given("I am on the checkout page with a product in my basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
testRunner.When(string.Format("I click on a AU {0} delivery", deliveryOption), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
testRunner.Then("The sub total plus the delivery equals the total price", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a customer I want to ensure the value on the checkout page matches the confirm" +
            "ation page")]
        [NUnit.Framework.CategoryAttribute("checkout")]
        public virtual void AsACustomerIWantToEnsureTheValueOnTheCheckoutPageMatchesTheConfirmationPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a customer I want to ensure the value on the checkout page matches the confirm" +
                    "ation page", new string[] {
                        "checkout"});
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
testRunner.Given("I am on the checkout page with a product in my basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
testRunner.When("I place an order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
testRunner.Then("the total value on the checkout page matches the total value on the confirmation " +
                    "page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
