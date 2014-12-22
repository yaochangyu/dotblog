using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Simple.SpecflowHelloWorld
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"我在計算機輸入 (.*)")]
        public void Given我在計算機輸入(double firstNumber)
        {
            ScenarioContext.Current.Set<double>(firstNumber, "firstNumber");
        }

        [Given(@"我計算機輸入 (.*)")]
        public void Given我計算機輸入(double secondNumber)
        {
            ScenarioContext.Current.Set<double>(secondNumber, "secondNumber");
        }

        [When(@"我按下 Add 按鈕")]
        public void When我按下Add按鈕()
        {
            var firstNumber = ScenarioContext.Current.Get<double>("firstNumber");
            var secondNumber = ScenarioContext.Current.Get<double>("secondNumber");
            var actual = new MyUtility.Calculation().Add(firstNumber, secondNumber);
            ScenarioContext.Current.Set<double>(actual, "actual");
        }

        [Then(@"螢幕上的結果應為 (.*)")]
        public void Then螢幕上的結果應為(int expected)
        {
            var actual = ScenarioContext.Current.Get<double>("actual");
            Assert.AreEqual(expected, actual);
        }
    }
}
