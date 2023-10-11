SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([UserId], [UserName], [FirstName], [LastName], [EmailAddress], [Password], [DateLastLoggedInUtc], [Enabled], [CreatedBy], [DateCreatedUtc]) VALUES (1, 'test001', 'test001', 'test001', 'test001','test001', getdate(),1, 'admin', getdate())
INSERT [dbo].[user] ([UserId], [UserName], [FirstName], [LastName], [EmailAddress], [Password], [DateLastLoggedInUtc], [Enabled], [CreatedBy], [DateCreatedUtc]) VALUES (2, 'test002', 'test002', 'test002', 'test002','test002', getdate(),1, 'admin', getdate())

SET IDENTITY_INSERT [dbo].[user] OFF