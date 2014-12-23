Feature: 單一登入
	In 不同的應用程式用同一個憑證
	As 適用Web/App
	I 使用者登入過後，在限定時間內不需要再輸入一次密碼

@mytag
Scenario Outline: authentication
	Given 我輸入 <UserId>/<Password>
	When 我按下Login
	Then 結果應為 <Result>
	Examples: 
	| Result |
	| true   |
	| false  |  
