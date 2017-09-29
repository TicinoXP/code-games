package ticinoxp.codegame;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;

class Pond {
    private final int[][] num;

    public int[][] getNum() {
        return num;
    }

    private  int[][] result;
    private int ponds;

    public Pond(int[][] num) {
        this.num = num;
    }

    public int getValue(int x, int y) {
        return num[x][y];
    }


    public void check() {
        ponds = 0;
        result = getEmptyResult(getLength(num), getWidth(num));
        for (int i=0; i<getLength(num); i++)
        {
            for (int l=0; l<getWidth(num); l++)
            {
                setResult(i,l,check(i,l));
            }
        }
        printResult();
    }

    private void printResult() {
        int c = 1;
        for (int p=1; p<= ponds; p++) {
            int count = getCount(p);
            if (count>0){
                System.out.println("Pond " + c + " counts " + count);
                c++;
            }
        }
    }

    private int getCount(int p) {
        int count = 0;
        for (int i = 0; i < getLength(result); i++) {
            for (int l = 0; l < getWidth(result); l++) {
                if (getResult(i, l) == p)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public int check(int i, int l) {
        int tempPond = 0;
        if (getValue(i,l) == 0)
        {
            ArrayList list = getArrayList(i, l);
            int actual = 0;
            int tmp = 0;
            Iterator iter = list.iterator();
            while (iter.hasNext())
            {
                tmp = (Integer) iter.next();
                if (tmp != 0)
                {
                    tempPond = tmp;
                    if (actual == 0)
                    {
                        actual = tmp;
                    }
                    else if (actual != tmp)
                    {
                        replace(actual,tmp);
                    }
                }
            }
            if (actual == 0)
            {
                ponds++;
                tempPond = ponds;
            }
        }
        return tempPond;
    }

    private ArrayList getArrayList(int i, int l) {
        ArrayList list = new ArrayList();
        list.add(checkDelta(i-1,l-1));
        list.add(checkDelta(i-1,l));
        list.add(checkDelta(i-1,l+1));
        list.add(checkDelta(i,l-1));
        list.add(checkDelta(i,l+1));
        list.add(checkDelta(i+1,l-1));
        list.add(checkDelta(i+1,l));
        list.add(checkDelta(i+1,l+1));
        HashSet hs = new HashSet();
        hs.addAll(list);
        list.clear();
        list.addAll(hs);
        return list;
    }

    private int checkDelta(int i, int l) {
        int ret = 0;
        try
        {
            if (getValue(i,l) == 0)
            {
                ret = getResult(i,l);
            }
        }
        catch (IndexOutOfBoundsException  ex)
        {
            ret = 0;
        }
        return ret;
    }


    public int[][] getEmptyResult(int lenghtX, int lenghtY) {
        int[][] temp = new int[lenghtX][lenghtY];
        for (int i=0; i<lenghtX; i++)
        {
            for (int l=0; l<lenghtY; l++)
            {
                temp[i][l]=0;
            }
        }
        return temp;
    }


    public int getResult(int i, int l) {
        return result[i][l];
    }
    public void setResult(int i, int l, int tempPond) {
        result[i][l] = tempPond;
    }
    public void setResult(int[][] result) {
        this.result = result;
    }
    public int[][] getResult() {
        return result;
    }

    public void replace(int actual, int replace) {
        for (int i=0; i<getLength(result); i++)
        {
            for (int l=0; l<getWidth(result); l++)
            {
                if (getResult(i,l) == actual) {
                    setResult(i,l,replace);
                }
            }
        }
    }

    public void show() {
        System.out.println();
        for (int i=0; i<getLength(num); i++)
        {
            for (int l=0; l<getWidth(num); l++)
            {
                System.out.print(" "+ getValue(i,l));
            }
            System.out.println();
        }
        System.out.println();
    }

    private static int getWidth(int[][] num) {
        return num[0].length;
    }

    private static int getLength(int[][] num) {
        return num.length;
    }
}
