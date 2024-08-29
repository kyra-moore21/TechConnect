using TechConnect.Models.DTOs;

namespace TechConnect.Interfaces
{
    public interface IPost
    {
        Task<List<PostDetailDTO>> GetPostsAsync();
        Task<PostDetailDTO> GetPostByIdAsync(int id);
        Task<PostCreateDTO> CreatePostAsync(PostCreateDTO createPostDTO);
        Task<PostDetailDTO> UpdatePostAsync(int id, PostDetailDTO postDTO);
        Task<bool> DeletePostAsync(int id);
    }
}
