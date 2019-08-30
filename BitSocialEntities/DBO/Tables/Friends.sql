CREATE TABLE [dbo].[Friends]
(
	[FriendsID] INT NOT NULL Identity(1,1) , 
    [UserID] INT NOT NULL, 
    [FriendName] NCHAR(50) NOT NULL, 
    [FriendSurname] NCHAR(50) NOT NULL, 
    PRIMARY KEY ([FriendsID]),
	Foreign Key ([UserID]) references [Users]([UserID]),

)
