using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices.NoLoginCommentServices
{
    public interface INoLoginCommentService
    {
        Task<List<ResultCommentDto>> CommentListByProductId(string id);
    }
}
