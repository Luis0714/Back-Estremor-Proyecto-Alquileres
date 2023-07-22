using Application.Messages;
using FluentValidation.Results;

namespace Application.Execteptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base(MessageErros.ValidationMessage)
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
        public List<string> Errors { get; }
    }
}
