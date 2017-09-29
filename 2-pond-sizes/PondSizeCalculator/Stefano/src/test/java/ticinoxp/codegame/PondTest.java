package ticinoxp.codegame;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotNull;

public class PondTest {
    @Test
    public void getValue() throws Exception {
    }

    @Test
    public void check() throws Exception {
        Pond pond = new Pond(array);
        pond.setResult(pond.getEmptyResult(4,4));
        assertEquals(1, pond.check(1,2));
        pond = new Pond(array);
        pond.setResult(pond.getEmptyResult(4,4));
        pond.setResult(0,3,1);
        pond.setResult(2,2,2);
        assertEquals(2, pond.check(1,2));
    }

    @Test
    public void replace() throws Exception {
        Pond pond = new Pond(array);
        pond.setResult(pond.getEmptyResult(4,4));
        pond.setResult(0,1,1);
        pond.setResult(0,0,1);
        pond.setResult(2,1,2);
        pond.setResult(2,2,2);
        pond.replace(1,2);
        assertEquals(2, pond.getResult(0,1));
        assertEquals(2, pond.getResult(0,0));
        assertEquals(2, pond.getResult(2,2));
        assertEquals(2, pond.getResult(2,1));


    }

    @Test
    public void getResult() throws Exception {
    }

    int[][] array =  new int[4][4];

    @Before
    public void setUp() throws Exception {
        array[0][0]=0;
        array[0][1]=2;
        array[0][2]=1;
        array[0][3]=0;
        array[1][0]=0;
        array[1][1]=1;
        array[1][2]=0;
        array[1][3]=1;
        array[2][0]=1;
        array[2][1]=1;
        array[2][2]=0;
        array[2][3]=1;
        array[3][0]=0;
        array[3][1]=1;
        array[3][2]=0;
        array[3][3]=1;
    }

    @After
    public void tearDown() throws Exception {
    }

    @Test
    public void PondTest() throws Exception {
        Pond pond = new Pond(array);
        assertNotNull(pond);
    }

    @Test
    public void getValueTest() throws Exception {
        Pond pond = new Pond(array);
        assertEquals(pond.getValue(0,0),0);
        assertEquals(pond.getValue(0,1),2);
        assertEquals(pond.getValue(0,2),1);
        assertEquals(pond.getValue(0,3),0);
        assertEquals(pond.getValue(1,0),0);
        assertEquals(pond.getValue(1,1),1);
        assertEquals(pond.getValue(1,2),0);
        assertEquals(pond.getValue(1,3),1);
        assertEquals(pond.getValue(2,0),1);
        assertEquals(pond.getValue(2,1),1);
        assertEquals(pond.getValue(2,2),0);
        assertEquals(pond.getValue(2,3),1);
        assertEquals(pond.getValue(3,0),0);
        assertEquals(pond.getValue(3,1),1);
        assertEquals(pond.getValue(3,2),0);
        assertEquals(pond.getValue(3,3),1);
    }

    @Test
    public void getCheckTest() throws Exception {
        Pond pond = new Pond(array);
        pond.check();
        assertEquals(pond.getResult(0,0),1);
        assertEquals(pond.getResult(0,1),0);
        assertEquals(pond.getResult(0,2),0);
        assertEquals(pond.getResult(0,3),2);
        assertEquals(pond.getResult(1,0),1);
        assertEquals(pond.getResult(1,1),0);
        assertEquals(pond.getResult(1,2),2);
        assertEquals(pond.getResult(1,3),0);
        assertEquals(pond.getResult(2,0),0);
        assertEquals(pond.getResult(2,1),0);
        assertEquals(pond.getResult(2,2),2);
        assertEquals(pond.getResult(2,3),0);
        assertEquals(pond.getResult(3,0),3);
        assertEquals(pond.getResult(3,1),0);
        assertEquals(pond.getResult(3,2),2);
        assertEquals(pond.getResult(3,3),0);
    }

}