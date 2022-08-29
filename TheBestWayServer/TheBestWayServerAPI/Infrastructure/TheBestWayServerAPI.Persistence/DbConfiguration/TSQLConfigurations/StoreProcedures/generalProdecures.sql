create procedure get_post_by_ıd 
(
@postId int
)as
select C.Id,C.Name,P.Id,P.Title,P.Content,P.CreatedDate,P.ModifiedDate,PD.ViewCount,PD.LikeCount,PD.DislikeCount,U.Id,U.UserName from Categories C
right join Posts P on C.Id= P.CategoryId 
left join AspNetUsers U on P.UserId= U.Id 
full join PostDetails PD on P.Id= PD.PostId
where P.Id=@postId

go



