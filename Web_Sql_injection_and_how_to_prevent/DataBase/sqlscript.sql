CREATE TABLE [dbo].[UserDetails](
[UserId] [int] IDENTITY(1,1) NOT NULL,
[UserName] [nvarchar](50) NULL);

INSERT INTO UserDetails (UserName) VALUES ('webblogsforyou');

--Sample SELECT Query that works
SELECT * FROM UserDetails WHERE UserName='webblogsforyou';

--Sample SELECT Query without SQL Injection that will not work
SELECT * FROM UserDetails WHERE UserName='test';
--Sample SELECT Query with SQL Injection that will work
SELECT * FROM UserDetails WHERE UserName='test' or '1'='1';