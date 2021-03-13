using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Profile
{
    public class QuestionProfile : AutoMapper.Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionDTO>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.CategoryId,
                    opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest =>
                    dest.Category,
                    opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest =>
                    dest.QuestionAnswerUserId,
                    opt => opt.MapFrom(src => src.QuestionAnswerUserId))
                .ForMember(dest =>
                    dest.QuestionAnswerUserName,
                    opt => opt.MapFrom(src => src.QuestionAnswerUser.UserName))
                .ForMember(dest =>
                    dest.QuestionAnswerUserEmail,
                    opt => opt.MapFrom(src => src.QuestionAnswerUser.Email))
                .ForMember(dest =>
                    dest.TotalVotes,
                    opt => opt.MapFrom(src => src.TotalVotes))
                .ForMember(dest =>
                    dest.UpVotes,
                    opt => opt.MapFrom(src => src.UpVotes))
                .ForMember(dest =>
                    dest.DownVotes,
                    opt => opt.MapFrom(src => src.DownVotes))
                .ForMember(dest =>
                    dest.CreatedAt,
                    opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest =>
                    dest.LastUpdated,
                    opt => opt.MapFrom(src => src.LastUpdated));

            CreateMap<QuestionDTO, Question>();
        }
    }
}
