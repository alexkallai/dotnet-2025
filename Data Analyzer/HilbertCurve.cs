public static class HilbertArray
{
    // -------- PUBLIC API --------

    // 1D → 2D Hilbert, padded
    public static double[,] To2D(double[] data, double pad = 0.0)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));

        int needed = data.Length;

        // find smallest r so (2^r)^2 >= needed
        int r = 0;
        while ((1 << (2 * r)) < needed) r++;

        int n = 1 << r;
        int total = n * n;
        var result = new double[n, n];

        int i = 0;
        for (int d = 0; d < total; d++)
        {
            var (x, y) = D2ToXY(r, d);
            result[x, y] = i < needed ? data[i++] : pad;
        }
        return result;
    }

    // 1D → 3D Hilbert, padded
    public static double[,,] To3D(double[] data, double pad = 0.0)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));

        int needed = data.Length;

        // find smallest r so (2^r)^3 >= needed
        int r = 0;
        while ((1 << (3 * r)) < needed) r++;

        int n = 1 << r;
        int total = n * n * n;
        var result = new double[n, n, n];

        int i = 0;
        for (int d = 0; d < total; d++)
        {
            var (x, y, z) = D3ToXYZ(r, d);
            result[x, y, z] = i < needed ? data[i++] : pad;
        }

        return result;
    }

    // -------- 2D Hilbert: d → (x,y) --------

    private static (int x, int y) D2ToXY(int r, int d)
    {
        int n = 1 << r;
        int x = 0, y = 0;
        int t = d;
        for (int s = 1; s < n; s <<= 1)
        {
            int rx = (t >> 1) & 1;
            int ry = (t ^ rx) & 1;
            Rotate2D(s, ref x, ref y, rx, ry);
            x += s * rx;
            y += s * ry;
            t >>= 2;
        }
        return (x, y);
    }

    private static void Rotate2D(int s, ref int x, ref int y, int rx, int ry)
    {
        if (ry == 0)
        {
            if (rx == 1)
            {
                x = s - 1 - x;
                y = s - 1 - y;
            }
            int t = x; x = y; y = t;
        }
    }

    // -------- 3D Hilbert: d → (x,y,z) --------
    // Uses Butz algorithm / standard 3D mapping
    private static (int x, int y, int z) D3ToXYZ(int r, int d)
    {
        int n = 1 << r;
        int x = 0, y = 0, z = 0;
        int t = d;
        int s = 1;

        while (s < n)
        {
            int rx = (t >> 2) & 1;
            int ry = (t >> 1) & 1;
            int rz = (t) & 1;

            Rotate3D(s, ref x, ref y, ref z, rx, ry, rz);

            x += s * rx;
            y += s * ry;
            z += s * rz;

            t >>= 3;
            s <<= 1;
        }

        return (x, y, z);
    }

    private static void Rotate3D(int s, ref int x, ref int y, ref int z, int rx, int ry, int rz)
    {
        // A minimal 3D Hilbert rotation.
        // There are many variants; this keeps parity and axis orientation consistent.
        if (rz == 0)
        {
            if (ry == 1)
            {
                x = s - 1 - x;
                z = s - 1 - z;
            }
            // rotate x and z
            int t = x; x = z; z = t;
        }
        if (ry == 0)
        {
            if (rx == 1)
            {
                y = s - 1 - y;
                z = s - 1 - z;
            }
            // rotate y and z
            int t = y; y = z; z = t;
        }
    }
}
