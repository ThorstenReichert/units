namespace PoC.Quantities
{
    public readonly struct Energy
    {
        private readonly FloatType _joules;

        private Energy(FloatType joules) => _joules = joules;

        public FloatType Gigajoules => _joules / Giga;
        public FloatType Megajoules => _joules / Mega;
        public FloatType Kilojoules => _joules / Kilo;
        public FloatType Joules => _joules;
        public FloatType Millijoules => _joules * Milli;
        public FloatType Microjoules => _joules * Micro;
        public FloatType Nanojoules => _joules * Nano;

        public static Energy Gigajoule(FloatType value) => Joule(value * Giga);
        public static Energy Megajoule(FloatType value) => Joule(value * Mega);
        public static Energy Kilojoule(float value) => Joule(value * Kilo);
        public static Energy Joule(FloatType value) => new(value);
        public static Energy Millijoule(FloatType value) => Joule(value / Milli);
        public static Energy Microjoule(FloatType value) => Joule(value / Micro);
        public static Energy Nanojoule(FloatType value) => Joule(value / Nano);

        public static Energy operator +(Energy value) => value;
        public static Energy operator -(Energy value) => Joule(-value.Joules);
        public static Energy operator +(Energy left, Energy right) => Joule(left.Joules + right.Joules);
        public static Energy operator -(Energy left, Energy right) => Joule(left.Joules - right.Joules);
        public static Energy operator *(Energy left, FloatType right) => Joule(left.Joules * right);
        public static Energy operator *(FloatType left, Energy right) => Joule(left * right.Joules);
        public static Energy operator /(Energy left, FloatType right) => Joule(left.Joules / right);

        public static Charge operator /(Energy left, Voltage right) => Charge.AmpereSecond(left.Joules / right.Volts);
        public static Current operator /(Energy left, MagneticFlux right) => Current.Ampere(left.Joules / right.Webers);
        public static Distance operator /(Energy left, Force right) => Distance.Meter(left.Joules / right.Newtons);
        public static Duration operator /(Energy left, Power right) => Duration.Second(left.Joules / right.Watts);
        public static Force operator /(Energy left, Distance right) => Force.Newton(left.Joules / right.Meters);
        public static MagneticFlux operator /(Energy left, Current right) => MagneticFlux.Weber(left.Joules / right.Amperes);
        public static Power operator /(Energy left, Duration right) => Power.Watt(left.Joules / right.Seconds);
        public static Voltage operator /(Energy left, Charge right) => Voltage.Volt(left.Joules / right.AmpereSeconds);

        public static bool operator ==(Energy left, Energy right) => left._joules == right._joules;
        public static bool operator !=(Energy left, Energy right) => !(left == right);

        public override bool Equals(object? obj) => obj is Energy energy && _joules == energy._joules;
        public override int GetHashCode() => -2111008676 + _joules.GetHashCode();
    }
}
