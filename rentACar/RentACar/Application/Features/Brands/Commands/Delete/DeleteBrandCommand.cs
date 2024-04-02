﻿using Application.Features.Brands.Commands.Update;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand: IRequest<DeleteBrandResponse>
{
    public Guid Id { get; set; }
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<DeleteBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate: w => w.Id == request.Id, cancellationToken: cancellationToken);

            brand = _mapper.Map(request, brand);

            await _brandRepository.DeleteAsync(brand);

            DeleteBrandResponse response = _mapper.Map<DeleteBrandResponse>(brand);
            return response;
        }

       
    }
}
