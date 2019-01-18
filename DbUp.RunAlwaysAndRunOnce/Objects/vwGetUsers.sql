CREATE OR ALTER VIEW [dbo].[vwGetUsers] AS (
	SELECT
		Id,
		Name,
		DateOfBirth
	FROM
		[dbo].[Users]
)
