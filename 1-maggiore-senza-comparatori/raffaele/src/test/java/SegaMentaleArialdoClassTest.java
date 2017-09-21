

import org.junit.Test;
import org.junit.experimental.max.MaxCore;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;

import java.util.Arrays;

import static org.junit.Assert.*;

@RunWith(Parameterized.class)
public class SegaMentaleArialdoClassTest {
    @Parameterized.Parameter(0)
    public int a;

    @Parameterized.Parameter(1)
    public int b;

    @Parameterized.Parameter(2)
    public int max;

    @Parameterized.Parameters
    public static Iterable<Object[]> arguments() {
        return Arrays.asList(new Object[][] {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0},

        });
    }



    @Test
    public void comparatorTest() {

        SegaMentaleArialdoClass sut = new SegaMentaleArialdoClass();

        assertEquals((long) this.max, sut.comparator(this.a, this.b));
    }

}
