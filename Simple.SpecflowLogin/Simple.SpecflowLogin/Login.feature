Feature: SSO
	In 不同的應用程式用同一個驗証機制(Token)
	As 適用Web/App
	I Want 使用者登入過後，在限定時間內不需要再輸入密碼

@mytag
Scenario Outline: authentication
	Given 我輸入 <UserId>,<Password>
	When 我按下Login
	Then 結果應為 <Result>
	Examples: 
	| UserId | Password | Result |
	| kobe   | 12234    | false  |
	| yao    | 1234     | true   |
	| jordan | 5566     | false  |    

