namespace PoC.Quantities
{
    public readonly struct Distance
    {
        private readonly FloatType _meters;

        private Distance(FloatType metres) => _meters = metres;

        public FloatType Kilometers => _meters / Kilo;
        public FloatType Meters => _meters;
        public FloatType Centimeters => _meters * Centi;
        public FloatType Millimeters => _meters * Milli;
        public FloatType Micrometers => _meters * Micro;
        public FloatType Nanometers => _meters * Nano;

        public static Distance Kilometer(FloatType value) => Meter(value * Kilo);
        public static Distance Meter(FloatType value) => new(value);
        public static Distance Centimeter(FloatType value) => Meter(value / Centi);
        public static Distance Millimeter(FloatType value) => Meter(value / Milli);
        public static Distance Micrometer(FloatType value) => Meter(value / Micro);
        public static Distance Nanometer(FloatType value) => Meter(value / Nano);

        public static Distance operator +(Distance value) => value;
        public static Distance operator -(Distance value) => Meter(-value.Meters);
        public static Distance operator +(Distance left, Distance right) => Meter(left.Meters + right.Meters);
        public static Distance operator -(Distance left, Distance right) => Meter(left.Meters - right.Meters);
        public static Distance operator *(Distance left, FloatType right) => Meter(left.Meters * right);
        public static Distance operator *(FloatType left, Distance right) => Meter(left * right.Meters);
        public static Distance operator /(Distance left, FloatType right) => Meter(left.Meters / right);

        public static Area operator *(Distance left, Distance right) => Area.MeterSquared(left.Meters * right.Meters);
        public static Energy operator *(Distance left, Force right) => Energy.Joule(left.Meters * right.Newtons);
        public static Velocity operator /(Distance distance, Duration duration) => Velocity.MeterPerSecond(distance.Meters / duration.Seconds);
        public static Volume operator *(Distance left, Area right) => Volume.MeterCubed(left.Meters * right.MetersSquared);

        public static bool operator ==(Distance left, Distance right) => left._meters == right._meters;
        public static bool operator !=(Distance left, Distance right) => !(left == right);

        public override bool Equals(object? obj) => obj is Distance distance && _meters == distance._meters;
        public override int GetHashCode() => -1331356788 + _meters.GetHashCode();
    }
}
