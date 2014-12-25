Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 模糊查詢產品
	Given 我輸入查詢資料
	| ProductName   |
	| 余小章's       |  
	And 預計資料應有
	| ProductName          | UnitPrice | Discontinued |
	| 余小章's C# book      | 29        | false        |
	| 余小章's VB book      | 21        | false        |
	| 余小章's ASP.NET book | 22        | false        |  
	When 我按下查詢
	Then 查詢結果應該有
	| ProductName          | UnitPrice |
	| 余小章's C# book      | 29        |
	| 余小章's VB book      | 21        |
	| 余小章's ASP.NET book | 22        |  