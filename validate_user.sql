create proc validate_user
@Username nvarchar(20),
@Password nvarchar(20)
as
begin
	declare @UserId int, @LastLoginDate datetime
	select @UserId = UserId, @LastLoginDate = LastLoginDate from Users where Username = @Username and Password = @Password

	if @UserId is not null
	begin
		if not exists (select UserId from UserActivation where UserId = @UserId)
		begin
			update Users set LastLoginDate = GETDATE() where UserId = @UserId
			select @UserId
		end
		else
		begin
			select -2
		end
	end
	else
	begin
		select -1
	end
end