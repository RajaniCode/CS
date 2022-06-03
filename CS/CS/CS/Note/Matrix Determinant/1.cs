// Matrix Determinant


using System;

class MyClass
{
    public int calc(int dim, params int[] matrix) //  A params parameter must be the last parameter in a formal parameter list
    {
        int sum = 0; 
        int bul;
        int x = 1;

        for(int l=0; l<(dim*dim); l+=(dim + 1))
            x *= matrix[l];

        sum = x;
        x = 1;
 
        for(int c=1; c<dim; c++)
        {
            bul = c;
            for(int m=0; m<dim; m++)
            {
                if((bul + 1) % dim != 0) 
                {
                    x *= matrix[bul];
                    bul +=(dim + 1);
                }
                else
                {
                    x = x * matrix[bul];
                    bul += 1;
                }
            }
            sum += x;
            x = 1;
        }
        return sum;
    }

    public void revmatrix(int dim, params int[] matrix) 
    {
        int end;
        int temp;
        int counter;
        for( int t=dim-1; t<=(dim*dim); t+=dim ) 
        {
            end = t;
            counter = end -(dim-1);
            while( end > counter )
            {
                temp = matrix[end];
                matrix[end] = matrix[counter];
                matrix[counter] = temp;
                ++counter;
                --end;
            }
        }
    }
}

class MainClass
{
    static void Main() 
    {
        MyClass mc = new MyClass();

        int[] matrix = new int[1000];

        double leftsum;
        double rightsum;	
    
        Console.WriteLine("Enter (n) dimension of nXn Matrix:");
        int dim = int.Parse(Console.ReadLine());

        for(int i=0; i<(dim*dim); i++ )
        {
            Console.WriteLine("Enter element:");
            matrix[i] = int.Parse(Console.ReadLine());
        }

        if(dim > 2 ) 
        {
            leftsum = mc.calc(dim, matrix);
            Console.WriteLine("Left sum of the matrix = " + leftsum + "\n\n");

            mc.revmatrix(dim, matrix);
            rightsum = mc.calc(dim, matrix);
            Console.WriteLine("Right sum of the matrix = " + rightsum + "\n\n");
            Console.WriteLine("Determinant of the Matrix = " + (leftsum - rightsum) + "\n\n");
        }
        else
            Console.WriteLine("Determinant of the Matrix = " + (matrix[0] * matrix[3] - matrix[1] * matrix[2]) + "\n\n");
    }
}



