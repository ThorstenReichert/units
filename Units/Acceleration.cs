namespace PoC.Quantities
{
    public readonly struct Acceleration
    {
        private readonly FloatType _metersPerSecondSquared;

        private Acceleration(FloatType metersPerSecondSquared) => _metersPerSecondSquared = metersPerSecondSquared;

        public FloatType MetersPerSecondSquared => _metersPerSecondSquared;

        public static Acceleration MeterPerSecondSquared(FloatType value) => new(value);

        public static Acceleration operator +(Acceleration value) => value;
        public static Acceleration operator -(Acceleration value) => MeterPerSecondSquared(-value.MetersPerSecondSquared);
        public static Acceleration operator +(Acceleration left, Acceleration right) => MeterPerSecondSquared(left.MetersPerSecondSquared + right.MetersPerSecondSquared);
        public static Acceleration operator -(Acceleration left, Acceleration right) => MeterPerSecondSquared(left.MetersPerSecondSquared - right.MetersPerSecondSquared);
        public static Acceleration operator *(Acceleration left, FloatType right) => MeterPerSecondSquared(left.MetersPerSecondSquared * right);
        public static Acceleration operator *(FloatType left, Acceleration right) => MeterPerSecondSquared(left * right.MetersPerSecondSquared);
        public static Acceleration operator /(Acceleration left, FloatType right) => MeterPerSecondSquared(left.MetersPerSecondSquared / right);

        public static Force operator *(Acceleration left, Mass right) => Force.Newton(left.MetersPerSecondSquared * right.Kilograms);

        public static bool operator ==(Acceleration left, Acceleration right) => left._metersPerSecondSquared == right._metersPerSecondSquared;
        public static bool operator !=(Acceleration left, Acceleration right) => !(left == right);

        public override bool Equals(object? obj) => obj is Acceleration acceleration && _metersPerSecondSquared == acceleration._metersPerSecondSquared;
        public override int GetHashCode() => 570013680 + _metersPerSecondSquared.GetHashCode();
    }
}
