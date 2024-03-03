namespace PoC.Quantities
{
    public readonly struct Location
    {
        private readonly FloatType _meters;

        private Location(FloatType meters) => _meters = meters;

        public FloatType Meters => _meters;
        public FloatType Centimeters => _meters * Centi;
        public FloatType Millimeters => _meters * Milli;
        public FloatType Micrometers => _meters * Micro;
        public FloatType Nanometers => _meters * Nano;

        public static Location Meter(FloatType value) => new(value);
        public static Location Centimeter(FloatType value) => Meter(value / Centi);
        public static Location Millimeter(FloatType value) => Meter(value / Milli);
        public static Location Micrometer(FloatType value) => Meter(value / Micro);
        public static Location Nanometer(FloatType value) => Meter(value / Nano);

        public static Distance operator -(Location left, Location right) => Distance.Meter(left.Meters - right.Meters);
        public static Location operator +(Location left, Distance right) => Meter(left.Meters + right.Meters);
        public static Location operator +(Distance left, Location right) => Meter(left.Meters + right.Meters);
        public static Location operator -(Location left, Distance right) => Meter(left.Meters - right.Meters);

        public static bool operator ==(Location left, Location right) => left._meters == right._meters;
        public static bool operator !=(Location left, Location right) => !(left == right);

        public override bool Equals(object? obj) => obj is Location location && _meters == location._meters;
        public override int GetHashCode() => -1331356788 + _meters.GetHashCode();
    }
}
