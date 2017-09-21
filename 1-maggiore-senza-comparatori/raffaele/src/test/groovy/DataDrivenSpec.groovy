import spock.lang.*

@Unroll
class ComparatorTest extends Specification {
    def "maximum of #a and #b is #c"() {
        expect:
        def sut = new SegaMentaleArialdoClass()

        sut.comparator(a, b) == c

        where:
        a     | b   || c
        0     | 0   || 0
        1     | 0   || 1
        0     | 1   || 1
        0     | -1  || 0
        -1    | 0   || 0
        -1    | -10 || -1
        -10   | -1  || -1
        10020 | 23  || 10020
    }
}