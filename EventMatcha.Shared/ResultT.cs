namespace EventMatcha.Shared
{
    public class Result<TValue> : Result
    {
        public readonly TValue? _value;

        protected internal Result(TValue? value, bool isSuccess, Error error)
            :base(isSuccess, error)
        {
            _value = value;
        }

        public TValue Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");

        public static Result Success(TValue value)
        {
            return new Result<TValue>(value, true, Error.None);
        }

        public static Result Failure(TValue value, Error error)
        {
            return new Result<TValue>(value, false, error);
        }

        //public static implicit operator Result<TValue>(TValue? value) => Create(value);
    }
}
