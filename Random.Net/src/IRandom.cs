namespace SimpleX.Random
{
    public interface IRandom
    {
        // [0.0, 1.0]
        float Next();

        // [min, max]
        int Next(int min, int max);
    }
}