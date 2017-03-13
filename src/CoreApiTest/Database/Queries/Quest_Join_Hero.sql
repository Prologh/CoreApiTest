﻿SELECT h.Name, q.Title,
	CASE WHEN q.IsCompleted = 1 THEN 'Yes' ELSE 'No' END AS Completed
	FROM [dbo].QuestItems as Q
	LEFT JOIN (SELECT HeroId, Name FROM [dbo].HeroItems) as h
	ON q.QuestOwnerId =  h.HeroId;