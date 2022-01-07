using ChatOnline.Application.Users.GetUserDetail.Commands.CreateUser;
using FluentValidation;

namespace ChatOnline.Application.Users.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
        }
    }
}
