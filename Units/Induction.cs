namespace PoC.Quantities
{
    public readonly struct Induction
    {
        private readonly FloatType _teslas;

        private Induction(FloatType teslas) => _teslas = teslas;

        public FloatType Gigateslas => _teslas / Giga;
        public FloatType Megateslas => _teslas / Mega;
        public FloatType Kiloteslas => _teslas / Kilo;
        public FloatType Teslas => _teslas;
        public FloatType Milliteslas => _teslas * Milli;
        public FloatType Microteslas => _teslas * Micro;
        public FloatType Nanoteslas => _teslas * Nano;

        public static Induction Gigatesla(FloatType value) => Tesla(value * Giga);
        public static Induction Megatesla(FloatType value) => Tesla(value * Mega);
        public static Induction Kilotesla(FloatType value) => Tesla(value * Kilo);
        public static Induction Tesla(FloatType value) => new(value);
        public static Induction Millitesla(FloatType value) => Tesla(value / Milli);
        public static Induction Microtesla(FloatType value) => Tesla(value / Micro);
        public static Induction Nanotesla(FloatType value) => Tesla(value / Nano);

        public static Induction operator +(Induction value) => value;
        public static Induction operator -(Induction value) => Tesla(-value.Teslas);
        public static Induction operator +(Induction left, Induction right) => Tesla(left.Teslas + right.Teslas);
        public static Induction operator -(Induction left, Induction right) => Tesla(left.Teslas - right.Teslas);
        public static Induction operator *(Induction left, FloatType right) => Tesla(left.Teslas * right);
        public static Induction operator *(FloatType left, Induction right) => Tesla(left * right.Teslas);
        public static Induction operator /(Induction left, FloatType right) => Tesla(left.Teslas / right);

        public static MagneticFlux operator *(Induction left, Area right) => MagneticFlux.Weber(left.Teslas * right.MetersSquared);

        public static bool operator ==(Induction left, Induction right) => left._teslas == right._teslas;
        public static bool operator !=(Induction left, Induction right) => !(left == right);

        public override bool Equals(object? obj) => obj is Induction induction && _teslas == induction._teslas;
        public override int GetHashCode() => -648504182 + _teslas.GetHashCode();
    }
}
