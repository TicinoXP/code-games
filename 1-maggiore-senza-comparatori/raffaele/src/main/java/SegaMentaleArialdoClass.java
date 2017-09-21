public class SegaMentaleArialdoClass {
    /**
     * Yes, That's Java, folks!
     */
    public int comparator(int a, int b) {
        return (int) ((a / 2) * (Math.signum(a - b) + 1) + b * Math.signum(b - a));
    }
}
