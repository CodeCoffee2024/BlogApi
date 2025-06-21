using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Module.GetOneModule
{
    public class GetOneModuleQueryHandler(IModuleRepository _repository, IMapper _mapper) : IRequestHandler<GetOneModuleQuery, Result<ModuleDto>>
    {
        #region Public Methods

        public async Task<Result<ModuleDto>> Handle(GetOneModuleQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            if (result == null)
            {
                return Result.Failure<ModuleDto>(Error.Notfound);
            }
            var mappedResult = _mapper.Map<ModuleDto>(result);
            return Result.Success(mappedResult);
        }

        #endregion Public Methods
    }
}