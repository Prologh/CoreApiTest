DELETE FROM [dbo].QuestItems;
DBCC CHECKIDENT ('dbo.QuestItems', RESEED, 1);

DELETE FROM [dbo].HeroItems;
DBCC CHECKIDENT ('dbo.HeroItems', RESEED, 1);

INSERT INTO [dbo].HeroItems (IsRetired, Name) VALUES
	(0, 'Wolverine'),
	(0, 'Deadpool'),
	(1, 'Superman'),
	(0, 'Lutrz');

INSERT INTO[dbo].QuestItems (IdHero, IsCompleted, Title) VALUES
	(1, 0, 'Save yourself'),
	(1, 1, 'Defeat Magneto'),
	(2, 1, 'Listen to "Careless Whisper" by Wham!'),
	(3, 0, 'Save the world'),
	(3, 0, 'Stay undercover as Klark Kent'),
	(4, 1, 'Kill Boromir'),
	(4, 0, 'Serve Saruman');