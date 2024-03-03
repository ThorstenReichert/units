namespace PoC.Quantities
{
    public readonly struct Volume
    {
        private readonly FloatType _metersCubed;

        private Volume(FloatType metersCubed) => _metersCubed = metersCubed;

        public FloatType MetersCubed => _metersCubed;

        public static Volume MeterCubed(FloatType value) => new(value);

        public static Volume operator +(Volume value) => value;
        public static Volume operator -(Volume value) => MeterCubed(-value.MetersCubed);
        public static Volume operator +(Volume left, Volume right) => MeterCubed(left.MetersCubed + right.MetersCubed);
        public static Volume operator -(Volume left, Volume right) => MeterCubed(left.MetersCubed - right.MetersCubed);
        public static Volume operator *(Volume left, FloatType right) => MeterCubed(left.MetersCubed * right);
        public static Volume operator *(FloatType left, Volume right) => MeterCubed(left * right.MetersCubed);
        public static Volume operator /(Volume left, FloatType right) => MeterCubed(left.MetersCubed / right);

        public static Area operator /(Volume left, Distance right) => Area.MeterSquared(left._metersCubed / right.Meters);
        public static Distance operator /(Volume left, Area right) => Distance.Meter(left.MetersCubed / right.MetersSquared);

        public static bool operator ==(Volume left, Volume right) => left._metersCubed == right._metersCubed;
        public static bool operator !=(Volume left, Volume right) => !(left == right);

        public override bool Equals(object? obj) => obj is Volume volume && _metersCubed == volume._metersCubed;
        public override int GetHashCode() => 576999847 + _metersCubed.GetHashCode();
    }
}
