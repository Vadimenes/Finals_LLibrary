using FluentValidation;
using LLibrary.Models;

namespace LibraryPZ3.Validators
{
    /// <summary>Валидатор для модели Reader.</summary>
    public class ReaderValidator : AbstractValidator<Reader>
    {
        /// <summary>Настраивает правила валидации для читателя.</summary>
        public ReaderValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("Введите имя")
                .MaximumLength(100).WithMessage("Имя не должно превышать 100 символов");

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage("Введите фамилию")
                .MaximumLength(100).WithMessage("Фамилия не должна превышать 100 символов");

            RuleFor(r => r.ClassNumber)
                .MaximumLength(20).WithMessage("Класс/статус не должен превышать 20 символов");
        }
    }
}