
CREATE OR ALTER   VIEW [dbo].[vwGetExpensesByCategory] AS
    SELECT
        [Transactions].[UserId],
        [Categories].[Title] AS [Category],
        YEAR([Transactions].[PaidOrReceivedAt]) AS [Year],
        SUM([Transactions].[Amount]) AS [Expenses]
    FROM
        [Transactions]
            INNER JOIN [Categories]
                       ON [Transactions].[CategoryId] = [Categories].[Id]
    WHERE
        [Transactions].[PaidOrReceivedAt]
            >= DATEADD(MONTH, -11, CAST(GETDATE() AS DATE))
      AND [Transactions].[PaidOrReceivedAt]
        < DATEADD(MONTH, 1, CAST(GETDATE() AS DATE))
      AND [Transactions].[TransactionType] = 2
    GROUP BY
        [Transactions].[UserId],
        [Categories].[Title],
        YEAR([Transactions].[PaidOrReceivedAt])
GO
