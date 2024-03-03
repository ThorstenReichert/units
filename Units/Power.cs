namespace PoC.Quantities
{
    public readonly struct Power
    {
        private readonly FloatType _watts;

        private Power(FloatType watts) => _watts = watts;

        public FloatType Gigawatts => _watts / Giga;
        public FloatType Megawatts => _watts / Mega;
        public FloatType Kilowatts => _watts / Kilo;
        public FloatType Watts => _watts;
        public FloatType Milliwatts => _watts * Milli;
        public FloatType Microwatts => _watts * Micro;
        public FloatType Nanowatts => _watts * Nano;

        public static Power Gigawatt(FloatType value) => Watt(value * Giga);
        public static Power Megawatt(FloatType value) => Watt(value * Mega);
        public static Power Kilowatt(FloatType value) => Watt(value * Kilo);
        public static Power Watt(FloatType value) => new(value);
        public static Power Milliwatt(FloatType value) => Watt(value / Milli);
        public static Power Microwatt(FloatType value) => Watt(value / Micro);
        public static Power Nanowatt(FloatType value) => Watt(value / Nano);

        public static Power operator +(Power value) => value;
        public static Power operator -(Power value) => Watt(-value.Watts);
        public static Power operator +(Power left, Power right) => Watt(left.Watts + right.Watts);
        public static Power operator -(Power left, Power right) => Watt(left.Watts - right.Watts);
        public static Power operator *(Power left, FloatType right) => Watt(left.Watts * right);
        public static Power operator *(FloatType left, Power right) => Watt(left * right.Watts);
        public static Power operator /(Power left, FloatType right) => Watt(left.Watts / right);

        public static Energy operator *(Power left, Duration right) => Energy.Joule(left.Watts * right.Seconds);

        public static Current operator /(Power left, Voltage right) => Current.Ampere(left.Watts / right.Volts);
        public static Voltage operator /(Power left, Current right) => Voltage.Volt(left.Watts / right.Amperes);

        public static bool operator ==(Power left, Power right) => left._watts == right._watts;
        public static bool operator !=(Power left, Power right) => !(left == right);

        public override bool Equals(object? obj) => obj is Power power && _watts == power._watts;
        public override int GetHashCode() => 2052746015 + _watts.GetHashCode();
    }
}
