namespace PoC.Quantities
{
    public readonly struct Voltage
    {
        private readonly FloatType _volts;

        private Voltage(FloatType volts) => _volts = volts;

        public FloatType Gigavolts => _volts / Giga;
        public FloatType Megavolts => _volts / Mega;
        public FloatType Kilovolts => _volts / Kilo;
        public FloatType Volts => _volts;
        public FloatType Millivolts => _volts * Milli;
        public FloatType Microvolts => _volts * Micro;
        public FloatType Nanovolts => _volts * Nano;

        public static Voltage Gigavolt(FloatType value) => Volt(value * Giga);
        public static Voltage Megavolt(FloatType value) => Volt(value * Mega);
        public static Voltage Kilovolt(FloatType value) => Volt(value * Kilo);
        public static Voltage Volt(FloatType value) => new(value);
        public static Voltage Millivolt(FloatType value) => Volt(value / Milli);
        public static Voltage Microvolt(FloatType value) => Volt(value / Micro);
        public static Voltage Nanovolt(FloatType value) => Volt(value / Nano);

        public static Voltage operator +(Voltage value) => value;
        public static Voltage operator -(Voltage value) => Volt(-value.Volts);
        public static Voltage operator +(Voltage left, Voltage right) => Volt(left.Volts + right.Volts);
        public static Voltage operator -(Voltage left, Voltage right) => Volt(left.Volts - right.Volts);
        public static Voltage operator *(Voltage left, FloatType right) => Volt(left.Volts * right);
        public static Voltage operator *(FloatType left, Voltage right) => Volt(left * right.Volts);
        public static Voltage operator /(Voltage left, FloatType right) => Volt(left.Volts / right);

        public static Charge operator *(Voltage left, Capacitance right) => Charge.AmpereSecond(left.Volts * right.Farads);
        public static Energy operator *(Voltage left, Charge right) => Energy.Joule(left.Volts * right.AmpereSeconds);
        public static Power operator *(Voltage left, Current right) => Power.Watt(left.Volts * right.Amperes);
        public static MagneticFlux operator *(Voltage left, Duration right) => MagneticFlux.Weber(left.Volts * right.Seconds);

        public static Current operator /(Voltage left, Resistance right) => Current.Ampere(left.Volts / right.Ohms);
        public static Resistance operator /(Voltage left, Current right) => Resistance.Ohm(left.Volts / right.Amperes);

        public static bool operator ==(Voltage left, Voltage right) => left._volts == right._volts;
        public static bool operator !=(Voltage left, Voltage right) => !(left == right);

        public override bool Equals(object? obj) => obj is Voltage voltage && _volts == voltage._volts;
        public override int GetHashCode() => -2133568406 + _volts.GetHashCode();
    }
}
