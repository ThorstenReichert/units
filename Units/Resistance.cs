namespace PoC.Quantities
{
    public readonly struct Resistance
    {
        private readonly FloatType _ohms;

        private Resistance(FloatType ohms) => _ohms = ohms;

        public FloatType Gigaohms => _ohms / Giga;
        public FloatType Megaohms => _ohms / Mega;
        public FloatType Kiloohms => _ohms / Kilo;
        public FloatType Ohms => _ohms;
        public FloatType Milliohms => _ohms * Milli;
        public FloatType Microohms => _ohms * Micro;
        public FloatType Nanoohms => _ohms * Nano;

        public static Resistance Gigaohm(FloatType value) => Ohm(value * Giga);
        public static Resistance Megaohm(FloatType value) => Ohm(value * Mega);
        public static Resistance Kiloohm(FloatType value) => Ohm(value * Kilo);
        public static Resistance Ohm(FloatType value) => new(value);
        public static Resistance Milliohm(FloatType value) => Ohm(value / Milli);
        public static Resistance Microohm(FloatType value) => Ohm(value / Micro);
        public static Resistance Nanoohm(FloatType value) => Ohm(value / Nano);

        public static Resistance operator +(Resistance value) => value;
        public static Resistance operator -(Resistance value) => Ohm(-value.Ohms);
        public static Resistance operator +(Resistance left, Resistance right) => Ohm(left.Ohms + right.Ohms);
        public static Resistance operator -(Resistance left, Resistance right) => Ohm(left.Ohms - right.Ohms);
        public static Resistance operator *(Resistance left, FloatType right) => Ohm(left.Ohms * right);
        public static Resistance operator *(FloatType left, Resistance right) => Ohm(left * right.Ohms);
        public static Resistance operator /(Resistance left, FloatType right) => Ohm(left.Ohms / right);

        public static Duration operator *(Resistance left, Capacitance right) => Duration.Second(left.Ohms * right.Farads);
        public static Voltage operator *(Resistance left, Current right) => Voltage.Volt(left.Ohms * right.Amperes);

        public static bool operator ==(Resistance left, Resistance right) => left._ohms == right._ohms;
        public static bool operator !=(Resistance left, Resistance right) => !(left == right);

        public override bool Equals(object? obj) => obj is Resistance resistance && _ohms == resistance._ohms;
        public override int GetHashCode() => 762526141 + _ohms.GetHashCode();
    }
}
