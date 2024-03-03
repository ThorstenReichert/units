namespace PoC.Quantities
{
    public readonly struct Instant
    {
        private readonly DateTime _dateTimeUtc;

        private Instant(DateTime dateTimeUtc) => _dateTimeUtc = dateTimeUtc;
        public DateTime DateTimeUtc => _dateTimeUtc;

        public static Instant Now() => new(DateTime.UtcNow);
        public static Instant From(DateTime dateTime) => new(dateTime.ToUniversalTime());

        public static explicit operator Instant(DateTime value) => From(value);
        public static explicit operator DateTime(Instant value) => value.DateTimeUtc;

        public static Duration operator -(Instant left, Instant right) => Duration.Second((left._dateTimeUtc - right._dateTimeUtc).TotalSeconds);
        public static Instant operator +(Instant left, Duration right) => From(left.DateTimeUtc + right.Timespan);
        public static Instant operator +(Duration left, Instant right) => From(right.DateTimeUtc + left.Timespan);
        public static Instant operator -(Instant left, Duration right) => From(left.DateTimeUtc - right.Timespan);

        public static bool operator ==(Instant left, Instant right) => left._dateTimeUtc == right._dateTimeUtc;
        public static bool operator !=(Instant left, Instant right) => !(left == right);

        public override bool Equals(object? obj) => obj is Instant instant && _dateTimeUtc == instant._dateTimeUtc;
        public override int GetHashCode() => -305687565 + _dateTimeUtc.GetHashCode();

    }
}
