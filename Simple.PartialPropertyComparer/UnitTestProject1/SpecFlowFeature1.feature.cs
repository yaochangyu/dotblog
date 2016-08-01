﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace UnitTestProject1
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SpecFlowFeature1Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SpecFlowFeature1.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowFeature1", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "SpecFlowFeature1")))
            {
                UnitTestProject1.SpecFlowFeature1Feature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("使用table.Row.Select比,較部分屬性")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecFlowFeature1")]
        public virtual void 使用Table_Row_Select比較部分屬性()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("使用table.Row.Select比,較部分屬性", ((string[])(null)));
#line 3
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "Price",
                        "Remark"});
            table1.AddRow(new string[] {
                        "1",
                        "yao",
                        "29.09",
                        "None1"});
            table1.AddRow(new string[] {
                        "2",
                        "yy",
                        "-10.00",
                        "None2"});
#line 4
 testRunner.Given("Product資料表應有以下資料", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "Price"});
            table2.AddRow(new string[] {
                        "1",
                        "yao",
                        "29.09"});
            table2.AddRow(new string[] {
                        "2",
                        "yy",
                        "-10.00"});
#line 8
 testRunner.Then("使用table.Row.Select我預期應得到以下資料", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("SpecFlow比較部分屬性")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecFlowFeature1")]
        public virtual void SpecFlow比較部分屬性()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SpecFlow比較部分屬性", ((string[])(null)));
#line 13
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "Price",
                        "Remark"});
            table3.AddRow(new string[] {
                        "1",
                        "yao",
                        "29.09",
                        "None1"});
            table3.AddRow(new string[] {
                        "2",
                        "yy",
                        "-10.00",
                        "None2"});
#line 14
 testRunner.Given("Product資料表應有以下資料", ((string)(null)), table3, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Price"});
            table4.AddRow(new string[] {
                        "29.09"});
            table4.AddRow(new string[] {
                        "-10.00"});
#line 18
 testRunner.Then("我預期應得到以下資料", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FluentAssertions比較部分屬性")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecFlowFeature1")]
        public virtual void FluentAssertions比較部分屬性()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("FluentAssertions比較部分屬性", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "Price",
                        "Remark"});
            table5.AddRow(new string[] {
                        "1",
                        "yao",
                        "29.09",
                        "None1"});
            table5.AddRow(new string[] {
                        "2",
                        "yy",
                        "-10.00",
                        "None2"});
#line 24
 testRunner.Given("Product資料表應有以下資料", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Price",
                        "Name"});
            table6.AddRow(new string[] {
                        "29.09",
                        "yao"});
            table6.AddRow(new string[] {
                        "-10.00",
                        "yy"});
#line 28
 testRunner.Then("使用匿名型別我預期應得到以下資料", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion