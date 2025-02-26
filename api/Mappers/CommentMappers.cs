using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDTO ToCommentDto(this Comment commentModel)
        {
            return new CommentDTO
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                CreatedBy = commentModel.AppUser.UserName,
                StockId = commentModel.StockId,

            };
        }
        public static Comment ToCommentFromCreate(this CreateCommentDTO commentdto, int stockId)
        {
            return new Comment
            {

                Title = commentdto.Title,
                Content = commentdto.Content,
                StockId = stockId

            };
        }
        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDTO commentdto)
        {
            return new Comment
            {

                Title = commentdto.Title,
                Content = commentdto.Content


            };
        }

    }
}