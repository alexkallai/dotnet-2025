public static class HilbertArray
{
    // Transform arbitrary 1D data into a Hilbert-ordered 2D array.
    // Remaining cells are padded with `pad`.
    public static double[,] To2D(double[] data, double pad = 0.0)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));

        // Find smallest r such that (2^r)^2 >= data.Length
        int needed = data.Length;
        int r = 0;
        while ((1 << (2 * r)) < needed) r++;
        int n = 1 << r;               // side length
        int total = n * n;            // total cells

        var result = new double[n, n];

        // Fill along Hilbert order
        int i = 0;
        for (int d = 0; d < total; d++)
        {
            var (x, y) = DToXY(r, d);
            result[x, y] = i < needed ? data[i++] : pad;
        }

        return result;
    }

    // Standard Hilbert d -> (x,y)
    private static (int x, int y) DToXY(int r, int d)
    {
        int n = 1 << r;
        int x = 0, y = 0;
        int t = d;
        for (int s = 1; s < n; s <<= 1)
        {
            int rx = (t / 2) & 1;
            int ry = (t ^ rx) & 1;
            Rotate(s, ref x, ref y, rx, ry);
            x += s * rx;
            y += s * ry;
            t >>= 2;
        }
        return (x, y);
    }

    private static void Rotate(int s, ref int x, ref int y, int rx, int ry)
    {
        if (ry == 0)
        {
            if (rx == 1)
            {
                x = s - 1 - x;
                y = s - 1 - y;
            }
            int t = x;
            x = y;
            y = t;
        }
    }
}
