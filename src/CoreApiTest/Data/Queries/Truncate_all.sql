DELETE FROM [dbo].QuestItems;
DBCC CHECKIDENT ('dbo.QuestItems', RESEED, 1);

DELETE FROM [dbo].HeroItems;
DBCC CHECKIDENT ('dbo.HeroItems', RESEED, 1);