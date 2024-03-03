namespace PoC.Quantities
{
    public readonly struct Current
    {
        private readonly FloatType _amperes;

        private Current(FloatType amperes) => _amperes = amperes;

        public FloatType Gigaamperes => _amperes / Giga;
        public FloatType Megaamperes => _amperes / Mega;
        public FloatType Kiloamperes => _amperes / Kilo;
        public FloatType Amperes => _amperes;
        public FloatType Milliamperes => _amperes * Milli;
        public FloatType Microamperes => _amperes * Micro;
        public FloatType Nanoamperes => _amperes * Nano;

        public static Current Gigaampere(FloatType value) => Ampere(value * Giga);
        public static Current Megaampere(FloatType value) => Ampere(value * Mega);
        public static Current Kiloampere(FloatType value) => Ampere(value * Kilo);
        public static Current Ampere(FloatType value) => new(value);
        public static Current Milliampere(FloatType value) => Ampere(value / Milli);
        public static Current Microampere(FloatType value) => Ampere(value / Micro);
        public static Current Nanoampere(FloatType value) => Ampere(value / Nano);

        public static Current operator +(Current value) => value;
        public static Current operator -(Current value) => Ampere(-value.Amperes);
        public static Current operator +(Current left, Current right) => Ampere(left.Amperes + right.Amperes);
        public static Current operator -(Current left, Current right) => Ampere(left.Amperes - right.Amperes);
        public static Current operator *(Current left, FloatType right) => Ampere(left.Amperes * right);
        public static Current operator *(FloatType left, Current right) => Ampere(left * right.Amperes);
        public static Current operator /(Current left, FloatType right) => Ampere(left.Amperes / right);

        public static Charge operator *(Current left, Duration right) => Charge.AmpereSecond(left.Amperes * right.Seconds);
        public static Power operator *(Current left, Voltage right) => Power.Watt(left.Amperes * right.Volts);
        public static Voltage operator *(Current left, Resistance right) => Voltage.Volt(left.Amperes * right.Ohms);
        public static Energy operator *(Current left, MagneticFlux right) => Energy.Joule(left.Amperes * right.Webers);

        public static bool operator ==(Current left, Current right) => left._amperes == right._amperes;
        public static bool operator !=(Current left, Current right) => !(left == right);

        public override bool Equals(object? obj) => obj is Current current && _amperes == current._amperes;
        public override int GetHashCode() => -1123989129 + _amperes.GetHashCode();
    }
}
