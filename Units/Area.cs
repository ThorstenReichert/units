namespace PoC.Quantities
{
    public readonly struct Area
    {
        private readonly FloatType _metersSquared;

        private Area(FloatType metersSquared) => _metersSquared = metersSquared;

        public FloatType MetersSquared => _metersSquared;
        public FloatType KilometersSquared => _metersSquared / (Kilo * Kilo);
        public FloatType MillimetersSquared => _metersSquared * (Milli * Milli);
        public FloatType MicrometersSquared => _metersSquared * (Micro * Micro);
        public FloatType NanometersSquared => _metersSquared * (Nano * Nano);

        public static Area KilometerSquared(FloatType value) => MeterSquared(value * (Kilo * Kilo));
        public static Area MeterSquared(FloatType value) => new(value);
        public static Area MillimeterSquared(FloatType value) => MeterSquared(value / (Milli * Milli));
        public static Area MicrometerSquared(FloatType value) => MeterSquared(value / (Micro * Micro));
        public static Area NanometerSquared(FloatType value) => MeterSquared(value / (Nano * Nano));

        public static Area operator +(Area value) => value;
        public static Area operator -(Area value) => MeterSquared(-value.MetersSquared);
        public static Area operator +(Area left, Area right) => MeterSquared(left.MetersSquared + right.MetersSquared);
        public static Area operator -(Area left, Area right) => MeterSquared(left.MetersSquared - right.MetersSquared);
        public static Area operator *(Area left, FloatType right) => MeterSquared(left.MetersSquared * right);
        public static Area operator *(FloatType left, Area right) => MeterSquared(left * right.MetersSquared);
        public static Area operator /(Area left, FloatType right) => MeterSquared(left.MetersSquared / right);

        public static Force operator *(Area left, Pressure right) => Force.Newton(left.MetersSquared * right.Pascals);
        public static MagneticFlux operator *(Area left, Induction right) => MagneticFlux.Weber(left.MetersSquared * right.Teslas);
        public static Volume operator *(Area left, Distance right) => Volume.MeterCubed(left.MetersSquared * right.Meters);

        public static Distance operator /(Area left, Distance right) => Distance.Meter(left.MetersSquared / right.Meters);

        public static bool operator ==(Area left, Area right) => left._metersSquared == right._metersSquared;
        public static bool operator !=(Area left, Area right) => !(left == right);

        public override bool Equals(object? obj) => obj is Area area && _metersSquared == area._metersSquared;
        public override int GetHashCode() => -611357851 + _metersSquared.GetHashCode();
    }
}
