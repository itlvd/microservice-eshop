using System;
using BuildingBlocks.CQRS;
using Catalog.Api.Models;
using MediatR;

namespace Catalog.Api.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product {
            Name = command.Name,
            Categories = command.Categories,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        // Save product to database
        return Task.FromResult(new CreateProductResult(product.Id));
    }
}
