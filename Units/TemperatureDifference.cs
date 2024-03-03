namespace PoC.Quantities
{
    public readonly struct TemperatureDifference
    {
        private readonly FloatType _kelvin;

        private TemperatureDifference(FloatType kelvin) => _kelvin = kelvin;

        public FloatType Kelvins => _kelvin;

        public static TemperatureDifference Kelvin(FloatType value) => new(value);

        public static TemperatureDifference operator +(TemperatureDifference value) => value;
        public static TemperatureDifference operator -(TemperatureDifference value) => Kelvin(-value.Kelvins);
        public static TemperatureDifference operator +(TemperatureDifference left, TemperatureDifference right) => Kelvin(left.Kelvins + right.Kelvins);
        public static TemperatureDifference operator -(TemperatureDifference left, TemperatureDifference right) => Kelvin(left.Kelvins - right.Kelvins);
        public static TemperatureDifference operator *(TemperatureDifference left, FloatType right) => Kelvin(left.Kelvins * right);
        public static TemperatureDifference operator *(FloatType left, TemperatureDifference right) => Kelvin(left * right.Kelvins);
        public static TemperatureDifference operator /(TemperatureDifference left, FloatType right) => Kelvin(left.Kelvins / right);

        public static bool operator ==(TemperatureDifference left, TemperatureDifference right) => left._kelvin == right._kelvin;
        public static bool operator !=(TemperatureDifference left, TemperatureDifference right) => !(left == right);

        public override bool Equals(object? obj) => obj is TemperatureDifference difference && _kelvin == difference._kelvin;
        public override int GetHashCode() => -881424217 + _kelvin.GetHashCode();
    }
}
