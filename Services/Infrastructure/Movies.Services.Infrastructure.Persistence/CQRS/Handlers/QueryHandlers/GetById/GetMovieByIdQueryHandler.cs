﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Services.Core.Application.Dtos.Movies;
using Movies.Services.Core.Domain.Entities;
using Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetById;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.QueryHandlers.GetById
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetByIdMovieQuery, ResponseDto<MoviesDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<MoviesDto>> Handle(GetByIdMovieQuery request, CancellationToken cancellationToken)
        {
            var Movie = await _context.Movies.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            Movie.Categories = await _context.Categories.Where(x => x.Id == Movie.CategoriesId).FirstOrDefaultAsync();

            var movieDto = _mapper.Map<MoviesDto>(Movie);

            return ResponseDto<MoviesDto>.Success(movieDto, 200);
        }
    }
}
