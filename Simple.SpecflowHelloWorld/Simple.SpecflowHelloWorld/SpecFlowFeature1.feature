Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 兩個數字相加
	Given 我在計算機輸入 50 
	And 我計算機輸入 70
	When 我按下 Add 按鈕
	Then 螢幕上的結果應為 120
