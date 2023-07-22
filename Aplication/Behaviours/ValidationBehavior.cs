using FluentValidation;
using MediatR;

namespace Application.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                var validatorResults = await Task.WhenAll(_validators.Select(validation => validation.ValidateAsync(context, cancellationToken)));
                var failures = validatorResults.SelectMany(error => error.Errors).Where(error => error != null).ToList();
                if (failures.Count != 0)
                    throw new Execteptions.ValidationException(failures);
            }
            return await next();
        }
    }
}
