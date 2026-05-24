using FluentValidation;
using LLibrary.Models;

namespace LLibrary.Validators
{
    /// <summary>Валидатор для модели Book.</summary>
    public class BookValidator : AbstractValidator<Book>
    {
        /// <summary>Настраивает правила валидации для книги.</summary>
        public BookValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Введите название книги")
                .MaximumLength(200).WithMessage("Название не должно превышать 200 символов");

            RuleFor(b => b.AuthorId)
                .GreaterThan(0).WithMessage("Выберите автора из списка");

            RuleFor(b => b.ISBN)
                .MaximumLength(20).WithMessage("ISBN не должен превышать 20 символов")
                .When(b => !string.IsNullOrWhiteSpace(b.ISBN));
        }
    }
}