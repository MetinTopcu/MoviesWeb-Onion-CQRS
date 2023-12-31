﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Services.Core.Application.Dtos.Films;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Delete;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.CommandHandlers.Delete
{
    public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand, ResponseDto<NoContentDto>>
    {
        private readonly AppDbContext _context;

        public DeleteFilmCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
        {
            var deleteFilm = await _context.Films.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

            if (deleteFilm == null)
            {
                return null;
            }

            _context.Films.Remove(deleteFilm);
            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(204);
        }
    }
}
