namespace PoC.Quantities
{
    public readonly struct Pressure
    {
        private readonly FloatType _pascals;

        private Pressure(FloatType pascals) => _pascals = pascals;

        public FloatType Gigapascals => _pascals / Giga;
        public FloatType Megapascals => _pascals / Mega;
        public FloatType Kilopascals => _pascals / Kilo;
        public FloatType Hectopascals => _pascals / Hecto;
        public FloatType Pascals => _pascals;
        public FloatType Millipascals => _pascals * Milli;
        public FloatType Micropascals => _pascals * Micro;
        public FloatType Nanopascals => _pascals * Nano;

        public static Pressure Gigapascal(FloatType value) => Pascal(value * Giga);
        public static Pressure Megapascal(FloatType value) => Pascal(value * Mega);
        public static Pressure Kilopascal(FloatType value) => Pascal(value * Kilo);
        public static Pressure Hectopascal(FloatType value) => Pascal(value * Hecto);
        public static Pressure Pascal(FloatType value) => new(value);
        public static Pressure Millipascal(FloatType value) => Pascal(value / Milli);
        public static Pressure Micropascal(FloatType value) => Pascal(value / Micro);
        public static Pressure Nanopascal(FloatType value) => Pascal(value / Nano);

        public static Pressure operator +(Pressure value) => value;
        public static Pressure operator -(Pressure value) => Pascal(-value.Pascals);
        public static Pressure operator +(Pressure left, Pressure right) => Pascal(left.Pascals + right.Pascals);
        public static Pressure operator -(Pressure left, Pressure right) => Pascal(left.Pascals - right.Pascals);
        public static Pressure operator *(Pressure left, FloatType right) => Pascal(left.Pascals * right);
        public static Pressure operator *(FloatType left, Pressure right) => Pascal(left * right.Pascals);
        public static Pressure operator /(Pressure left, FloatType right) => Pascal(left.Pascals / right);

        public static Force operator *(Pressure left, Area right) => Force.Newton(left.Pascals * right.MetersSquared);

        public static bool operator ==(Pressure left, Pressure right) => left._pascals == right._pascals;
        public static bool operator !=(Pressure left, Pressure right) => !(left == right);

        public override bool Equals(object? obj) => obj is Pressure pressure && _pascals == pressure._pascals;
        public override int GetHashCode() => 1546405003 + _pascals.GetHashCode();
    }
}
