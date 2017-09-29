package ticinoxp.codegame;

class Main {

    public static void main(String[] args) {
        System.out.println("Start ...");
        int[][] original =  { {0,2,1,0},{0,1,0,1},{1,1,0,1},{0,1,0,1}};
        int[][] bigger =  { {0,2,1,0,0,1},{0,1,0,1,2,3},{1,1,0,1,0,2},{0,1,0,1,1,2},{0,0,1,2,1,0}};
        int[][] particular =  { {0,2,0},{1,0,1},{0,1,0}};
        Pond pond = new Pond(original);
        pond.show();
        pond.check();
        pond = new Pond(bigger);
        pond.show();
        pond.check();
        pond = new Pond(particular);
        pond.show();
        pond.check();
	    System.out.println("End");
    }
}
