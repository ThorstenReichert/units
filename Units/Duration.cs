namespace PoC.Quantities
{
    public readonly struct Duration
    {
        private readonly FloatType _seconds;

        private Duration(FloatType seconds) => _seconds = seconds;

        public FloatType Seconds => _seconds;
        public FloatType Milliseconds => _seconds * Milli;
        public FloatType Microseconds => _seconds * Micro;
        public FloatType NanoSeconds => _seconds * Nano;
        public TimeSpan Timespan => TimeSpan.FromSeconds(Seconds);

        public static Duration Second(FloatType value) => new(value);
        public static Duration Millisecond(FloatType value) => Second(value / Milli);
        public static Duration Microsecond(FloatType value) => Second(value / Micro);
        public static Duration Nanosecond(FloatType value) => Second(value / Nano);
        public static Duration From(TimeSpan value) => Second((FloatType) value.TotalSeconds);

        public static explicit operator Duration(TimeSpan value) => From(value);
        public static explicit operator TimeSpan(Duration value) => value.Timespan;

        public static Duration operator +(Duration value) => value;
        public static Duration operator -(Duration value) => Second(-value.Seconds);
        public static Duration operator +(Duration left, Duration right) => Second(left.Seconds + right.Seconds);
        public static Duration operator -(Duration left, Duration right) => Second(left.Seconds - right.Seconds);
        public static Duration operator *(Duration left, FloatType right) => Second(left.Seconds * right);
        public static Duration operator *(FloatType left, Duration right) => Second(left * right.Seconds);
        public static Duration operator /(Duration left, FloatType right) => Second(left.Seconds / right);

        public static Charge operator *(Duration left, Current right) => Charge.AmpereSecond(left.Seconds * right.Amperes);
        public static Energy operator *(Duration left, Power right) => Energy.Joule(left.Seconds * right.Watts);
        public static MagneticFlux operator *(Duration left, Voltage right) => MagneticFlux.Weber(left.Seconds * right.Volts);

        public static Capacitance operator /(Duration left, Resistance right) => Capacitance.Farad(left.Seconds / right.Ohms);
        public static Resistance operator /(Duration left, Capacitance right) => Resistance.Ohm(left.Seconds / right.Farads);

        public static bool operator ==(Duration left, Duration right) => left._seconds == right._seconds;
        public static bool operator !=(Duration left, Duration right) => !(left == right);

        public override bool Equals(object? obj) => obj is Duration duration && _seconds == duration._seconds;
        public override int GetHashCode() => -707225725 + _seconds.GetHashCode();
    }
}
