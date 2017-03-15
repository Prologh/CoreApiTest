DELETE FROM [dbo].QuestItems;
DBCC CHECKIDENT ('dbo.QuestItems', RESEED, 0);

--DELETE FROM [dbo].HeroItems;
--DBCC CHECKIDENT ('dbo.HeroItems', RESEED, 0);