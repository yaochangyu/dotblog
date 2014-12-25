Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 驗証登入/登出
	Given 前往 https://mail.google.com
	When 輸入帳號、密碼，然後按下登入
	Then 驗証右上角顯示登入名為 +小章，hyper link為 https://plus.google.com/u/0/?tab=mX
	Then 驗証登入成功後的網址 https://mail.google.com/mail/u/0/#inbox
	When 按按下右上角的登出
	Then 驗証Email 
