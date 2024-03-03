namespace PoC.Quantities
{
    public readonly struct Temperature
    {
        private const FloatType CelsiusOffset = 273.15;
        private const FloatType FahrenheitOffset = 459.67;
        private const FloatType FahrenheitFactor = 5.0 / 9.0;

        private readonly FloatType _kelvin;

        private Temperature(FloatType kelvin) => _kelvin = kelvin;

        public static Temperature Kelvin(FloatType value) => new(value);
        public static Temperature DegreeCelsius(FloatType value) => Kelvin(value + CelsiusOffset);
        public static Temperature DegreeFahrenheit(FloatType value) => Kelvin(FahrenheitFactor * (value + FahrenheitOffset));

        public override bool Equals(object? obj) => obj is Temperature temperature && _kelvin == temperature._kelvin;
        public override int GetHashCode() => -881424217 + _kelvin.GetHashCode();

        public static bool operator ==(Temperature left, Temperature right) => left._kelvin == right._kelvin;
        public static bool operator !=(Temperature left, Temperature right) => !(left == right);

        public static TemperatureDifference operator -(Temperature left, Temperature right) => TemperatureDifference.Kelvin(left.Kelvins - right.Kelvins);
        public static Temperature operator +(Temperature left, TemperatureDifference right) => Kelvin(left.Kelvins + right.Kelvins);
        public static Temperature operator +(TemperatureDifference left, Temperature right) => Kelvin(left.Kelvins + right.Kelvins);
        public static Temperature operator -(Temperature left, TemperatureDifference right) => Kelvin(left.Kelvins - right.Kelvins);

        public FloatType Kelvins => _kelvin;
        public FloatType DegreesCelsius => _kelvin - CelsiusOffset;
        public FloatType DegreesFahrenheit => _kelvin * FahrenheitFactor - FahrenheitOffset;
    }
}
