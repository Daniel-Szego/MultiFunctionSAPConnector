Declare @year int
Declare @month int

Set @year = 1990

While @year < 2010 Begin
set @month = 1

  	while @month < 13 begin

		insert into [dbo].[Dim_Date] values (@year, @month)
	Set @month = @month + 1
	End
Set @year = @year + 1
End


