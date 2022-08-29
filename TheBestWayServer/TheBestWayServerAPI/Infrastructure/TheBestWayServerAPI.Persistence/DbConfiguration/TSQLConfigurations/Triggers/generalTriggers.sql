alter trigger tg_post_delete
on Posts
instead of delete
as
declare @id int
select @id=Id from deleted
update Posts set Title=null, Content='This data has been deleted.', ModifiedDate=null, CreatedDate=null, ImagePath=null, IsDeleted = 1, DeletedDate=GETDATE(), UserId=1 where Id=@id
delete PostDetails where PostId=@id

go

alter trigger tg_user_delete
on AspNetUsers
instead of delete
as
declare @id int
select @id=Id from deleted
update Posts set Title=null, Content='This data has been deleted.', ModifiedDate=null, CreatedDate=null, ImagePath=null, IsDeleted = 1, DeletedDate=GETDATE(), UserId=1 where UserId=@id
update Comments set Content='This data has been deleted.',CreatedDate=null, IsDeleted = 1 ,DeletedDate=GETDATE(), UserId=1 where UserId=@id
update Questions set Title=null, Content='This data has been deleted.', CreatedDate=null,IsDeleted = 1 ,DeletedDate=GETDATE(), UserId=1 where UserId = @id
update QuestionAnswers set Content='This data has been deleted.', CreatedDate=null, IsDeleted = 1, DeletedDate=GETDATE() ,UserId=1 where UserId= @id
delete from AspNetUsers where Id= @id

go

alter trigger tg_question_delete
on Questions
instead of delete
as
declare @id int 
select @id=Id from deleted
update Questions set Title=null, Content='This data has been deleted.', CreatedDate=null, IsDeleted = 1 , DeletedDate=GETDATE() , UserId=1 where Id = @id

go

ALTER trigger tg_comment_delete
on Comments
instead of delete
as
declare @id int 
select @id=Id from deleted
update Comments set Content='This data has been deleted.', CreatedDate=null, IsDeleted = 1 , DeletedDate=GETDATE() , UserId=1 where Id = @id