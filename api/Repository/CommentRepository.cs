using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context )
        {
            _context = context;
        }

        public async Task<Comments> CreateAsync(Comments comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comments>> GetAllAsync()
        {
           return  await _context.Comments.ToListAsync();
        }

        public Task<Comments?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        // public async Task<Comments?> GetByIdAsync(int id)
        // {
        //   return  await _context.Comments.FindAsync(id);
        // }
    }
}