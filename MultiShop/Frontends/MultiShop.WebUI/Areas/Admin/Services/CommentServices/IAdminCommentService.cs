using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.CommentServices
{
    public interface IAdminCommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task<List<ResultCommentDto>> CommentListByProductId(string id);
        Task<HttpResponseMessage> CreateCommentAsync(CreateCommentDto createCommentDto);
        Task<HttpResponseMessage> UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task<HttpResponseMessage> DeleteCommentAsync(string id);
        Task<UpdateCommentDto> GetByIdCommentAsync(string id);
        Task<int> GetTotalCommentCount();
    }
}
