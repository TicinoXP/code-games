public class SegaMentaleArialdoClass {
    /**
     * Yes, That's Java, folks!
     */
    public int comparator(int a, int b) {
        return (int)
                (a * (Math.signum(a - b) + 1) / 2 +
                        b * (Math.signum(b - a) + 1) / 2 -
                        a * (Math.signum(a - b) + Math.signum(b - a)) / 2);
    }
}
