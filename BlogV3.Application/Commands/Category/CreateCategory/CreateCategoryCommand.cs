using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Category.CreateCategory
{
    public sealed record CreateCategoryCommand(
        Guid UserId,
        string Name) : IRequest<Result>;
}