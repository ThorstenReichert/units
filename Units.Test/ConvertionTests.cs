using System.Linq;
using System.Reflection;

namespace PoC.Quantities.Test;

[TestClass]
public class ConvertionTests
{


    [TestMethod]
    public void Charge_Equals_Capacitance_Times_Voltage() =>
        TestConversion(Charge.AmpereSecond(1), Capacitance.Farad(1), Voltage.Volt(1));

    [TestMethod]
    public void Charge_Equals_Current_Times_Duration() =>
        TestConversion(Charge.AmpereSecond(1), Current.Ampere(1), Duration.Second(1));

    [TestMethod]
    public void Duration_Equals_Capacitance_Times_Resistance() =>
        TestConversion(Duration.Second(1), Capacitance.Farad(1), Resistance.Ohm(1));

    [TestMethod]
    public void Energy_Equals_Charge_Times_Voltage() =>
        TestConversion(Energy.Joule(1), Charge.AmpereSecond(1), Voltage.Volt(1));

    [TestMethod]
    public void Energy_Equals_Current_Times_MagneticFlux() =>
        TestConversion(Energy.Joule(1), Current.Ampere(1), MagneticFlux.Weber(1));

    [TestMethod]
    public void Energy_Equals_Distance_Times_Force() =>
        TestConversion(Energy.Joule(1), Distance.Meter(1), Force.Newton(1));

    [TestMethod]
    public void Energy_Equals_Duration_Times_Power() =>
        TestConversion(Energy.Joule(1), Duration.Second(1), Power.Watt(1));

    [TestMethod]
    public void Force_Equals_Acceleration_Times_Mass() =>
        TestConversion(Force.Newton(1), Acceleration.MeterPerSecondSquared(1), Mass.Kilogram(1));

    [TestMethod]
    public void Force_Equals_Pressure_Times_Area() =>
        TestConversion(Force.Newton(1), Area.MeterSquared(1), Pressure.Pascal(1));

    [TestMethod]
    public void MagneticFlux_Equals_Area_Times_Induction() =>
        TestConversion(MagneticFlux.Weber(1), Area.MeterSquared(1), Induction.Tesla(1));

    [TestMethod]
    public void MagneticFlux_Equals_Duration_Times_Voltage() =>
        TestConversion(MagneticFlux.Weber(1), Duration.Second(1), Voltage.Volt(1));

    [TestMethod]
    public void Power_Equals_Current_Times_Voltage() =>
        TestConversion(Power.Watt(1), Current.Ampere(1), Voltage.Volt(1));

    [TestMethod]
    public void Voltage_Equals_Current_Times_Resistance() =>
        TestConversion(Voltage.Volt(1), Current.Ampere(1), Resistance.Ohm(1));

    [TestMethod]
    public void Volume_Equals_Area_Times_Distance() =>
        TestConversion(Volume.MeterCubed(1), Area.MeterSquared(1), Distance.Meter(1));

    private static void TestConversion<TResult, TLeft, TRight>(TResult result, TLeft left, TRight right)
    {
        // left * right == result
        Assert.IsTrue(
            (bool) GetEqualityOperator<TResult>().Invoke(
                null,
                [
                    result,
                    GetMultiplicationOperator<TLeft, TRight, TResult>().Invoke(null, [left, right])
                ])!);

        // right * left == result
        Assert.IsTrue(
            (bool) GetEqualityOperator<TResult>().Invoke(
                null,
                [
                    result,
                    GetMultiplicationOperator<TRight, TLeft, TResult>().Invoke(null, [right, left])
                ])!);

        // left == result / right
        Assert.IsTrue(
            (bool) GetEqualityOperator<TLeft>().Invoke(
                null,
                [
                    left,
                    GetDivisionOperator<TResult, TRight, TLeft>().Invoke(null, [result, right])
                ])!);

        // right == result / left
        Assert.IsTrue(
            (bool) GetEqualityOperator<TRight>().Invoke(
                null,
                [
                    right,
                    GetDivisionOperator<TResult, TLeft, TRight>().Invoke(null, [result, left])
                ])!);
    }

    private static MethodInfo GetEqualityOperator<T>() => GetBinaryOperator<T, T, bool>("op_Equality");
    public static MethodInfo GetMultiplicationOperator<TLeft, TRight, TResult>() => GetBinaryOperator<TLeft, TRight, TResult>("op_Multiply");
    public static MethodInfo GetDivisionOperator<TLeft, TRight, TResult>() => GetBinaryOperator<TLeft, TRight, TResult>("op_Division");

    private static MethodInfo GetBinaryOperator<TLeft, TRight, TResult>(string opName)
    {
        var candidates = typeof(TLeft)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(info =>
            {
                var parameter = info.GetParameters();
                if (parameter.Length != 2)
                {
                    return false;
                }

                return info.Name == opName
                    && info.ReturnType == typeof(TResult)
                    && parameter[0].ParameterType == typeof(TLeft)
                    && parameter[1].ParameterType == typeof(TRight);
            })
            .ToList();

        Assert.AreEqual(1, candidates.Count, $"Unable to find '{opName}' for '({typeof(TLeft).Name}', {typeof(TRight).Name}) -> {typeof(TResult).Name}'.");

        return candidates[0];
    }
}