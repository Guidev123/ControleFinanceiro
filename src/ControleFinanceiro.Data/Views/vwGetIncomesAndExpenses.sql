CREATE OR ALTER VIEW [vwGetIncomesAndExpenses] AS
    SELECT
    [Transactions].[UserId],
    MONTH([Transactions].[PaidOrReceivedAt]) AS [MONTH],
    YEAR([Transactions].[PaidOrReceivedAt]) AS [YEAR],
    SUM(CASE WHEN [Transactions].[TransactionType] = 1 THEN [Transactions].[Amount] ELSE 0 END) AS [Incomes],
    SUM(CASE WHEN [Transactions].[TransactionType] = 2 THEN [Transactions].[Amount] ELSE 0 END) AS [Expenses]
    FROM
    [Transactions]
    WHERE [Transactions].[PaidOrReceivedAt] >= DATEADD(MONTH, -13, CAST(GETDATE() AS DATE)) 
        AND [Transactions].[PaidOrReceivedAt] <= DATEADD(MONTH, -1, CAST(GETDATE() AS DATE))
    GROUP BY [Transactions].[UserId],
    MONTH([Transactions].[PaidOrReceivedAt]),
    YEAR([Transactions].[PaidOrReceivedAt])
