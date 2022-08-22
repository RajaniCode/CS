using System;

class MainClass
{
    static void Main()
    {
        try
        {
            try
            {
                try
                {
                    return;
                    throw new Exception();

                }
                catch (Exception)
                {
                    Console.WriteLine("1");
                    // return;
                }
                finally
                {
                    Console.WriteLine("2");
                    // throw new Exception();
                }

                try //
                { //
                    throw new Exception(); //
                } //
                catch (Exception)//
                { //
                    Console.WriteLine("11");//
                } //
                finally //
                { //
                    Console.WriteLine("22"); //
                } //
            }
            catch (Exception)
            {
                Console.WriteLine("11111111111");
            }
            finally
            {
                Console.WriteLine("22222222222");
            }

        }
        catch (Exception)
        {
            Console.WriteLine("3");
        }
        finally
        {
            Console.WriteLine("4");
            Console.ReadLine();
        }
    }
}
