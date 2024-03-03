namespace PoC.Quantities
{
    public readonly struct Capacitance
    {
        private readonly FloatType _farads;

        private Capacitance(FloatType farads) => _farads = farads;

        public FloatType Gigafarads => _farads / Giga;
        public FloatType Megafarads => _farads / Mega;
        public FloatType Kilofarads => _farads / Kilo;
        public FloatType Farads => _farads;
        public FloatType Millifarads => _farads * Milli;
        public FloatType Microfarads => _farads * Micro;
        public FloatType Nanofarads => _farads * Nano;

        public static Capacitance Gigafarad(FloatType value) => Farad(value * Giga);
        public static Capacitance Megafarad(FloatType value) => Farad(value * Mega);
        public static Capacitance Kilofarad(FloatType value) => Farad(value * Kilo);
        public static Capacitance Farad(FloatType value) => new(value);
        public static Capacitance Millifarad(FloatType value) => Farad(value / Milli);
        public static Capacitance Microfarad(FloatType value) => Farad(value / Micro);
        public static Capacitance Nanofarad(FloatType value) => Farad(value / Nano);

        public static Capacitance operator +(Capacitance value) => value;
        public static Capacitance operator -(Capacitance value) => Farad(-value.Farads);
        public static Capacitance operator +(Capacitance left, Capacitance right) => Farad(left.Farads + right.Farads);
        public static Capacitance operator -(Capacitance left, Area right) => Farad(left.Farads - right.MetersSquared);
        public static Capacitance operator *(Capacitance left, FloatType right) => Farad(left.Farads * right);
        public static Capacitance operator *(FloatType left, Capacitance right) => Farad(left * right.Farads);
        public static Capacitance operator /(Capacitance left, FloatType right) => Farad(left.Farads / right);

        public static Charge operator *(Capacitance left, Voltage right) => Charge.AmpereSecond(left.Farads * right.Volts);
        public static Duration operator *(Capacitance left, Resistance right) => Duration.Second(left.Farads * right.Ohms);
        public static Voltage operator *(Capacitance left, Charge right) => Voltage.Volt(left.Farads * right.AmpereSeconds);

        public static bool operator ==(Capacitance left, Capacitance right) => left._farads == right._farads;
        public static bool operator !=(Capacitance left, Capacitance right) => !(left == right);

        public override bool Equals(object? obj) => obj is Capacitance capacitance && _farads == capacitance._farads;
        public override int GetHashCode() => -539048257 + _farads.GetHashCode();
    }
}
