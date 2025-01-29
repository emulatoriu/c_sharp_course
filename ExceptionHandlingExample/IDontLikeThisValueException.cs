class IDontLikeThisValueException : Exception
{
    //int? meinInt = 5;
    
    public int valueIDoNotLike { get;}

    public IDontLikeThisValueException() { }

    public IDontLikeThisValueException(string message)
        : base(message) { /*bool b = meinInt.HasValue;*/ }

    public IDontLikeThisValueException(string message, Exception inner)
        : base(message, inner) { }

    public IDontLikeThisValueException(string message, int valueIDoNotLike)
        : base(message) 
    { 
        this.valueIDoNotLike = valueIDoNotLike;
    }
}