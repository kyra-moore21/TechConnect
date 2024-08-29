using Microsoft.EntityFrameworkCore;
using TechConnect.Interfaces;
using TechConnect.Models.Context;
using TechConnect.Models.DTOs;
using TechConnect.Models.Entities;

namespace TechConnect.Services
{
    public class PostService : IPost
    {
        private readonly TechconnectdbContext _context;

        public PostService(TechconnectdbContext context)
        {
            _context = context;
        }
        //introduce pagination for posts
        //get posts by userid eventually
       public async Task<List<PostDetailDTO>> GetPostsAsync()
        {
            var posts = await _context.Posts
                .Select(p => new PostDetailDTO
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    User = new UserDetailDTO
                    {
                        Id = p.User.Id,
                        Email = p.User.Email,
                        FullName = p.User.Email,

                    },
                }).ToListAsync();
            return posts;
        }
        public async Task<PostDetailDTO> GetPostByIdAsync(int id)
        {
            var profiles = await _context.Posts
                .Where(p => p.Id == id).FirstOrDefaultAsync();
            PostDetailDTO postDTO = new PostDetailDTO
            {
                Id = profiles.Id,
                Title = profiles.Title,
                Description = profiles.Description,
                CreatedAt = profiles.CreatedAt,
                UpdatedAt = profiles.UpdatedAt,
                User = new UserDetailDTO
                {
                    Id = profiles.User.Id,
                    Email = profiles.User.Email,
                    FullName = profiles.User.Email,

                }
            };
            return postDTO;
        }
        public async Task<PostCreateDTO> CreatePostAsync(PostCreateDTO createPostDTO)
        {
            var post = new Post
            {
                Title = createPostDTO.Title,
                Description = createPostDTO.Description,
                UserId = createPostDTO.UserId
            };
           _context.Posts.Add(post);
           await  _context.SaveChangesAsync();
            return new PostCreateDTO
            {
                Title = post.Title,
                Description = post.Description,
                UserId = (int)post.UserId
            };
        }
        public async Task<PostDetailDTO> UpdatePostAsync(int id, PostDetailDTO postDTO)
        {
            Post p = await _context.Posts.FindAsync(id);
            if (p == null)
            {
                return null;
            }
            p.Title = postDTO.Title;
            p.Description = postDTO.Description;
            p.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return new PostDetailDTO
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                User = new UserDetailDTO
                {
                    Id = p.User.Id,
                    Email = p.User.Email,
                    FullName = p.User.Email,

                }
            };
        }
        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if(post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
