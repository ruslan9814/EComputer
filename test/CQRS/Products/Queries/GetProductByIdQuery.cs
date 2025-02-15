﻿using test.Common;
using test.CQRS.Dtos;
using Test.Database.Repositories.Interfaces;

namespace test.CQRS.Products.Queries;

public sealed record GetProductByIdQuery(int Id) : IRequest<Result<ProductDto>>;

public sealed class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var productIsExist = await _productRepository.IsExistAsync(request.Id);

        if (!productIsExist)
        {
            return (Result<ProductDto>)Result.Failure($"Продукт с ID {request.Id} не найден.");
        }

        var product = await _productRepository.GetAsync(request.Id);

        var response = new ProductDto(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.IsInStock,
            product.CreatedDate
        );

        return Result<ProductDto>.Success(response);
    }
}
