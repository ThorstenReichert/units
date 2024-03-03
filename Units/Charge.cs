namespace PoC.Quantities
{
    public readonly struct Charge
    {
        private readonly FloatType _ampereSeconds;

        private Charge(FloatType ampereseconds) => _ampereSeconds = ampereseconds;

        public FloatType GigaampereSeconds => _ampereSeconds / Giga;
        public FloatType MegaampereSeconds => _ampereSeconds / Mega;
        public FloatType KiloampereSeconds => _ampereSeconds / Kilo;
        public FloatType AmpereSeconds => _ampereSeconds;
        public FloatType MilliampereSeconds => _ampereSeconds * Milli;
        public FloatType MicroampereSeconds => _ampereSeconds * Micro;
        public FloatType NanoampereSeconds => _ampereSeconds * Nano;

        public static Charge GigaampereSecond(FloatType value) => AmpereSecond(value * Giga);
        public static Charge MegaampereSecond(FloatType value) => AmpereSecond(value * Mega);
        public static Charge KiloampereSecond(float value) => AmpereSecond(value * Kilo);
        public static Charge AmpereSecond(FloatType value) => new(value);
        public static Charge MilliampereSecond(FloatType value) => AmpereSecond(value / Milli);
        public static Charge MicroampereSecond(FloatType value) => AmpereSecond(value / Micro);
        public static Charge NanoampereSecond(FloatType value) => AmpereSecond(value / Nano);

        public static Charge operator +(Charge value) => value;
        public static Charge operator -(Charge value) => AmpereSecond(-value.AmpereSeconds);
        public static Charge operator +(Charge left, Charge right) => AmpereSecond(left.AmpereSeconds + right.AmpereSeconds);
        public static Charge operator -(Charge left, Charge right) => AmpereSecond(left.AmpereSeconds - right.AmpereSeconds);
        public static Charge operator *(Charge left, FloatType right) => AmpereSecond(left.AmpereSeconds * right);
        public static Charge operator *(FloatType left, Charge right) => AmpereSecond(left * right.AmpereSeconds);
        public static Charge operator /(Charge left, FloatType right) => AmpereSecond(left.AmpereSeconds / right);

        public static Energy operator *(Charge left, Voltage right) => Energy.Joule(left.AmpereSeconds * right.Volts);

        public static Capacitance operator /(Charge left, Voltage right) => Capacitance.Farad(left.AmpereSeconds / right.Volts);
        public static Current operator /(Charge left, Duration right) => Current.Ampere(left.AmpereSeconds / right.Seconds);
        public static Duration operator /(Charge left, Current right) => Duration.Second(left.AmpereSeconds / right.Amperes);
        public static Voltage operator /(Charge left, Capacitance right) => Voltage.Volt(left.AmpereSeconds / right.Farads);

        public static bool operator ==(Charge left, Charge right) => left._ampereSeconds == right._ampereSeconds;
        public static bool operator !=(Charge left, Charge right) => !(left == right);

        public override bool Equals(object? obj) => obj is Charge charge && _ampereSeconds == charge._ampereSeconds;
        public override int GetHashCode() => 902557787 + _ampereSeconds.GetHashCode();
    }
}
