create proc insert_user
@Username nvarchar(20),
@Password nvarchar(20),
@Email nvarchar(30)
as
begin
	set nocount on;
	if exists(select UserId from Users where Username = @Username)
		begin
			select -1
		end
	else if exists(select UserId from Users where Email = @Email)
		begin 
			select -2
		end
	else
		begin
			insert into Users (Username,Password,Email,CreatedDate) values (@Username,@Password,@Email,GETDATE())
			select SCOPE_IDENTITY()
		end
end