﻿using AutoMapper;
using MediatR;
using Movies.Services.Core.Application.Dtos;
using Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetById;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.QueryHandlers.GetById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetByIdCategoryQuery, ResponseDto<CategoriesDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<CategoriesDto>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == request.Id);

            var categoryDto = _mapper.Map<CategoriesDto>(category);

            return ResponseDto<CategoriesDto>.Success(categoryDto, 200);
        }
    }
}