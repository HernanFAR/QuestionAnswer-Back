using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Profile
{
    public class AnswerProfile : AutoMapper.Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer, AnswerDTO>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.QuestionId,
                    opt => opt.MapFrom(src => src.QuestionId))
                .ForMember(dest =>
                    dest.Question,
                    opt => opt.MapFrom(src => src.Question.Name))
                .ForMember(dest =>
                    dest.CreatedAt,
                    opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest =>
                    dest.Votes,
                    opt => opt.MapFrom(src => src.Votes))
                .ForMember(dest =>
                    dest.LastUpdated,
                    opt => opt.MapFrom(src => src.LastUpdated));

            CreateMap<QuestionDTO, Question>();
        }
    }
}
