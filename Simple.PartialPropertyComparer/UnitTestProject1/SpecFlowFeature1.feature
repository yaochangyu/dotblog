Feature: SpecFlowFeature1

Scenario: 使用table.Row.Select比,較部分屬性
	Given Product資料表應有以下資料
		| ID | Name | Price  | Remark |
		| 1  | yao  | 29.09  | None1  |
		| 2  | yy   | -10.00 | None2  |
	Then 使用table.Row.Select我預期應得到以下資料
		| ID | Name | Price  |
		| 1  | yao  | 29.09  |
		| 2  | yy   | -10.00 |

Scenario: SpecFlow比較部分屬性
	Given Product資料表應有以下資料
		| ID | Name | Price  | Remark |
		| 1  | yao  | 29.09  | None1  |
		| 2  | yy   | -10.00 | None2  |
	Then 我預期應得到以下資料
		| Price  |
		| 29.09  |
		| -10.00 |

Scenario: FluentAssertions比較部分屬性
	Given Product資料表應有以下資料
		| ID | Name | Price  | Remark |
		| 1  | yao  | 29.09  | None1  |
		| 2  | yy   | -10.00 | None2  |
	Then 使用匿名型別我預期應得到以下資料
		| Price  | Name |
		| 29.09  | yao  |
		| -10.00 | yy   |