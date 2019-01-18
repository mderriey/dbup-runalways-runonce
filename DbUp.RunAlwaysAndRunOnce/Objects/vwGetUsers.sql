CREATE OR ALTER VIEW [dbo].[vwGetUsers] AS (
	SELECT
		Id,
		Name
	FROM
		[dbo].[Users]
)
