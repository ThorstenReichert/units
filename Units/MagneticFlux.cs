namespace PoC.Quantities
{
    public readonly struct MagneticFlux
    {
        private readonly FloatType _webers;

        private MagneticFlux(FloatType webers) => _webers = webers;

        public FloatType Gigawebers => _webers / Giga;
        public FloatType Megawebers => _webers / Mega;
        public FloatType Kilowebers => _webers / Kilo;
        public FloatType Webers => _webers;
        public FloatType Milliwebers => _webers * Milli;
        public FloatType Microwebers => _webers * Micro;
        public FloatType Nanowebers => _webers * Nano;

        public static MagneticFlux Gigaweber(FloatType value) => Weber(value * Giga);
        public static MagneticFlux Megaweber(FloatType value) => Weber(value * Mega);
        public static MagneticFlux Kiloweber(FloatType value) => Weber(value * Kilo);
        public static MagneticFlux Weber(FloatType value) => new(value);
        public static MagneticFlux Milliweber(FloatType value) => Weber(value / Milli);
        public static MagneticFlux Microweber(FloatType value) => Weber(value / Micro);
        public static MagneticFlux Nanoweber(FloatType value) => Weber(value / Nano);

        public static MagneticFlux operator +(MagneticFlux value) => value;
        public static MagneticFlux operator -(MagneticFlux value) => Weber(-value.Webers);
        public static MagneticFlux operator +(MagneticFlux left, MagneticFlux right) => Weber(left.Webers + right.Webers);
        public static MagneticFlux operator -(MagneticFlux left, MagneticFlux right) => Weber(left.Webers - right.Webers);
        public static MagneticFlux operator *(MagneticFlux left, FloatType right) => Weber(left.Webers * right);
        public static MagneticFlux operator *(FloatType left, MagneticFlux right) => Weber(left * right.Webers);
        public static MagneticFlux operator /(MagneticFlux left, FloatType right) => Weber(left.Webers / right);

        public static Energy operator *(MagneticFlux left, Current right) => Energy.Joule(left.Webers * right.Amperes);

        public static Area operator /(MagneticFlux left, Induction right) => Area.MeterSquared(left.Webers / right.Teslas);
        public static Induction operator /(MagneticFlux left, Area right) => Induction.Tesla(left.Webers / right.MetersSquared);
        public static Duration operator /(MagneticFlux left, Voltage right) => Duration.Second(left.Webers / right.Volts);
        public static Voltage operator /(MagneticFlux left, Duration right) => Voltage.Volt(left.Webers / right.Seconds);

        public static bool operator ==(MagneticFlux left, MagneticFlux right) => left._webers == right._webers;
        public static bool operator !=(MagneticFlux left, MagneticFlux right) => !(left == right);

        public override bool Equals(object? obj) => obj is MagneticFlux flux && _webers == flux._webers;
        public override int GetHashCode() => 378352484 + _webers.GetHashCode();
    }
}
