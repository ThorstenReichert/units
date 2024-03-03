namespace PoC.Quantities
{
    public readonly struct Force
    {
        private readonly FloatType _newtons;

        private Force(FloatType newtons) => _newtons = newtons;

        public FloatType Giganewtons => _newtons / Giga;
        public FloatType Meganewtons => _newtons / Mega;
        public FloatType Kilonewtons => _newtons / Kilo;
        public FloatType Newtons => _newtons;
        public FloatType Millinewtons => _newtons * Milli;
        public FloatType Micronewtons => _newtons * Micro;
        public FloatType Nanonewtons => _newtons * Nano;

        public static Force Giganewton(FloatType value) => Newton(value * Giga);
        public static Force Meganewton(FloatType value) => Newton(value * Mega);
        public static Force Kilonewton(FloatType value) => Newton(value * Kilo);
        public static Force Newton(FloatType value) => new(value);
        public static Force Millinewton(FloatType value) => Newton(value / Milli);
        public static Force Micronewton(FloatType value) => Newton(value / Milli);
        public static Force Nanonewton(FloatType value) => Newton(value / Nano);

        public static Force operator +(Force value) => value;
        public static Force operator -(Force value) => Newton(-value.Newtons);
        public static Force operator +(Force left, Force right) => Newton(left.Newtons + right.Newtons);
        public static Force operator -(Force left, Force right) => Newton(left.Newtons - right.Newtons);
        public static Force operator *(Force left, FloatType right) => Newton(left.Newtons * right);
        public static Force operator *(FloatType left, Force right) => Newton(left * right.Newtons);
        public static Force operator /(Force left, FloatType right) => Newton(left.Newtons / right);

        public static Energy operator *(Force left, Distance right) => Energy.Joule(left.Newtons * right.Meters);

        public static Pressure operator /(Force left, Area right) => Pressure.Pascal(left.Newtons / right.MetersSquared);
        public static Area operator /(Force left, Pressure right) => Area.MeterSquared(left.Newtons / right.Pascals);
        public static Mass operator /(Force left, Acceleration right) => Mass.Kilogram(left.Newtons / right.MetersPerSecondSquared);
        public static Acceleration operator /(Force left, Mass right) => Acceleration.MeterPerSecondSquared(left.Newtons / right.Kilograms);

        public static bool operator ==(Force left, Force right) => left._newtons == right._newtons;
        public static bool operator !=(Force left, Force right) => !(left == right);

        public override bool Equals(object? obj) => obj is Force force && _newtons == force._newtons;
        public override int GetHashCode() => -67122646 + _newtons.GetHashCode();
    }
}
