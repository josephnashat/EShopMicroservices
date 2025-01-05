using BuildingBlocks.CQRS;
using CatalogAPI.Models;
namespace CatalogAPI.Products.CreateProduct;
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);
internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //Business logic to create a product

        //create product entity from command
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        //TODO
        //save product entity to database

        //return CreateProductResult
        return new CreateProductResult(Guid.NewGuid());
        //return new Task<CreateProductResult>(() => new CreateProductResult(product.Id));
        //throw new NotImplementedException();
    }
}

