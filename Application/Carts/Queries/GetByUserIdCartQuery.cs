﻿using Application.Dtos;
using Infrasctructure.Repositories.Interfaces;

namespace Application.Carts.Queries;

public sealed record GetByUserIdCartQuery(int UserId) : IRequest<Result<CartDto>>;

public sealed class GetByUserIdCartQueryHandler(ICartRepository cartRepository) 
    : IRequestHandler<GetByUserIdCartQuery, Result<CartDto>>
{
    private readonly ICartRepository _cartRepository = cartRepository;
    public async Task<Result<CartDto>> Handle(GetByUserIdCartQuery request, CancellationToken cancellationToken)
    {
        var isCartExist = await _cartRepository.IsExistAsync(request.UserId);

        if (!isCartExist)
        {
            return Result.Failure<CartDto>("Корзина не найдена.");
        }


        var cart = await _cartRepository.GetAsync(request.UserId);

        ICollection<CartItemDto> cartItemDtos = [];

        foreach (var cartItem in cart.Items)
        {
            var cartItemDto = new CartItemDto(
                cartItem.Id,  
                cartItem.Quantity,  
                new ProductDto(   
                    cartItem.ProductId,              
                    cartItem.Product.Name,           
                    cartItem.Product.Description,    
                    cartItem.Product.Price,        
                    cartItem.Product.IsInStock,      
                    cartItem.Product.CreatedDate,
                    new CategoryDto(
                        cartItem.Product.Category.Id 
                        ,cartItem.Product.Category.Name)
                )
            );

          
            cartItemDtos.Add(cartItemDto);
        }

       
        var cartDto = new CartDto(
            request.UserId,           
            cart.Items.Count,         
            cartItemDtos             
        );

        return Result.Success(cartDto);
    }
}
