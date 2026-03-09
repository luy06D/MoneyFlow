USE dbMoney

SELECT * FROM Service;
SELECT * FROM [Transaction]

update [Transaction]
set [Date] = '2026-03-01' 
where TransactionId = 3;