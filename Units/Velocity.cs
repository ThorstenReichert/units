namespace PoC.Quantities
{
    public readonly struct Velocity
    {
        private readonly FloatType _metersPerSecond;

        private Velocity(FloatType metersPerSecond) => _metersPerSecond = metersPerSecond;

        public FloatType MetersPerSecond => _metersPerSecond;

        public static Velocity MeterPerSecond(FloatType value) => new(value);

        public static Velocity operator +(Velocity value) => value;
        public static Velocity operator -(Velocity value) => MeterPerSecond(-value.MetersPerSecond);
        public static Velocity operator +(Velocity left, Velocity right) => MeterPerSecond(left.MetersPerSecond + right.MetersPerSecond);
        public static Velocity operator -(Velocity left, Velocity right) => MeterPerSecond(left.MetersPerSecond - right.MetersPerSecond);
        public static Velocity operator *(Velocity left, FloatType right) => MeterPerSecond(left.MetersPerSecond * right);
        public static Velocity operator *(FloatType left, Velocity right) => MeterPerSecond(left * right.MetersPerSecond);
        public static Velocity operator /(Velocity left, FloatType right) => MeterPerSecond(left.MetersPerSecond / right);

        public static Acceleration operator /(Velocity left, Duration right) => Acceleration.MeterPerSecondSquared(left.MetersPerSecond / right.Seconds);

        public static bool operator ==(Velocity left, Velocity right) => left._metersPerSecond == right._metersPerSecond;
        public static bool operator !=(Velocity left, Velocity right) => !(left == right);

        public override bool Equals(object? obj) => obj is Velocity velocity && _metersPerSecond == velocity._metersPerSecond;
        public override int GetHashCode() => -995992093 + _metersPerSecond.GetHashCode();
    }
}
