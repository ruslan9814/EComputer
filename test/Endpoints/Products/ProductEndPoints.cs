﻿using Carter;
using Microsoft.AspNetCore.Mvc;
using test.Endpoints.Products.Requests;
using test.CQRS.Products.Commands;
using test.CQRS.Products.Queries;

namespace test.Endpoints.Products;

////realizovat repositoriy cart and cartItem METODI DLA KORZINI ADD DELETE UPDATE NAPISAT V CLASSE cartItemRepository,
//// TAKJE DOVAVIT cartItemEndPoints i v ney vizvat metodi cerez ICartItemRepository

public sealed class ProductEndPoints : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var product = app.MapGroup("api/product").RequireAuthorization(policy => policy.RequireRole("Admin"));
        product.MapGet("{productId}/", GetProduct);
        product.MapPost("/", AddProduct);
        product.MapDelete("{productId}/", RemoveProduct);
        product.MapPut("{productId}/", UpdateProduct);
    }

    public async Task<IResult> GetProduct(int Id, ISender sender)
    {
        var response = await sender.Send(new GetProductByIdQuery(Id));
        return response.IsFailure
            ? Results.BadRequest(response.Error)
            : Results.Ok(response);
    }

    private async Task<IResult> AddProduct([FromBody] AddProductRequest request, ISender sender)
    {
        var response = await sender.Send(new AddProductCommand(request.Name, 
            request.Description, request.Price, request.IsInStock));

        return response.IsFailure ?
            Results.BadRequest(response.Error) 
            : Results.Ok(response);
    }

    public async Task<IResult> RemoveProduct([FromBody] DeleteProductRequest request, [FromServices] ISender sender)
    {
         var response = await sender.Send(new DeleteProductCommand(request.Id));
        return response.IsFailure
            ? Results.BadRequest(response.Error)
            : Results.Ok(response);
    }

    private async Task<IResult> UpdateProduct([FromBody] UpdateProductRequest request, [FromServices] ISender sender)
    {
       var response = await sender.Send(new UpdateProductCommand(request.Id, request.Name,
            request.Description, request.Price, request.Quantity, request.IsInStock));
        return response.IsFailure
            ? Results.BadRequest(response.Error)
            : Results.Ok(response);
    }
}
