namespace PipeFlow.Core;

public static class FlowCalculator
{
    public static double Area(double diameter) => (Math.PI * Math.Pow(diameter, 2)) / 4;

    public static double Velocity(double flowRate, double area) => flowRate / area;

    public static double Reynolds(double density, double velocity, double diameter, double viscosity) => density * velocity * diameter / viscosity;

    public static double LaminarFriction(double reynolds) => 64.0 / reynolds;

    public static double SwameeJain(double roughness, double diameter, double reynolds)
    {
        return 0.25 / Math.Pow((Math.Log10((roughness / (3.7 * diameter)) + (5.74 / Math.Pow(reynolds, 0.9)))), 2);
    }

    public static double Colebrook(double roughness, double diameter, double reynolds)
    {
        var friction = SwameeJain(roughness, diameter, reynolds);
        for (int i = 0; i < 50; i++)
        {
            var rightSide = -2 * Math.Log10((roughness / (3.7 * diameter)) + (2.51 / (reynolds * Math.Sqrt(friction))));
            var newF = 1 / Math.Pow(rightSide, 2);

            if (Math.Abs(newF - friction) < 1e-10)
            {
                return newF;
            }

            friction = newF;
        }

        throw new InvalidOperationException("Colebrook did not converge after 50 iterations");
    }
}
