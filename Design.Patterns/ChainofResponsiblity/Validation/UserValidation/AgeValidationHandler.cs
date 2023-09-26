namespace Design.Patterns.ChainofResponsiblity.Validation.UserValidation
{
    public class AgeValidationHandler : Handler<User>
    {
        public override void Handle(User data)
        {
            if (data.Age < 18)
            {
                throw new UserValidationException("You have to be 18 years or older");
            }

            base.Handle(data);
        }

    }
}
