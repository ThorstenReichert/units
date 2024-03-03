namespace PoC.Quantities
{
    public readonly struct Mass
    {
        private readonly FloatType _kilograms;

        private Mass(FloatType kilograms) => _kilograms = kilograms;

        public FloatType Kilograms => _kilograms;
        public FloatType Grams => _kilograms * Kilo;
        public FloatType Milligrams => _kilograms * Kilo * Milli;
        public FloatType Micrograms => _kilograms * Kilo * Micro;
        public FloatType Nanograms => _kilograms * Kilo * Nano;

        public static Mass Kilogram(FloatType value) => new(value);
        public static Mass Gram(FloatType value) => Kilogram(value / Kilo);
        public static Mass Milligram(FloatType value) => Kilogram(value / (Milli * Kilo));
        public static Mass Microgram(FloatType value) => Kilogram(value / (Micro * Kilo));
        public static Mass Nanogram(FloatType value) => Kilogram(value / (Nano * Kilo));

        public static Mass operator +(Mass value) => value;
        public static Mass operator -(Mass value) => Kilogram(-value.Kilograms);
        public static Mass operator +(Mass left, Mass right) => Kilogram(left.Kilograms + right.Kilograms);
        public static Mass operator -(Mass left, Mass right) => Kilogram(left.Kilograms - right.Kilograms);
        public static Mass operator *(Mass left, FloatType right) => Kilogram(left.Kilograms * right);
        public static Mass operator *(FloatType left, Mass right) => Kilogram(left * right.Kilograms);
        public static Mass operator /(Mass left, FloatType right) => Kilogram(left.Kilograms / right);

        public static Force operator *(Mass left, Acceleration right) => Force.Newton(left.Kilograms * right.MetersPerSecondSquared);

        public static bool operator ==(Mass left, Mass right) => left._kilograms == right._kilograms;
        public static bool operator !=(Mass left, Mass right) => !(left == right);

        public override bool Equals(object? obj) => obj is Mass mass && _kilograms == mass._kilograms;
        public override int GetHashCode() => 577971585 + _kilograms.GetHashCode();
    }
}
