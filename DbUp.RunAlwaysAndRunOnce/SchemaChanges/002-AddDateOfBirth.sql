﻿ALTER TABLE [dbo].[Users]
	ADD [DateOfBirth] DATETIME NOT NULL DEFAULT(GETDATE())