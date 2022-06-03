// struct

using System;

struct PacketStruct
{
    public uint packetnumber;
    public ushort packetlength;
}

class TransactionClass
{
    static uint transactionnumber = 1; // Note static

    string accountnumber;
    double amount;

    PacketStruct ps;

    public TransactionClass(string an, double am)
    {
        ps.packetnumber = transactionnumber++; // Note inside constructor
        ps.packetlength = 512; // Note inside constructor

        accountnumber = an;
        amount = am;
    }

    public void sendTransactionMethod() // Note formatting: {3:C}
    {
        Console.WriteLine("Packet number: {0}, Packet length: {1}, Account number: {2}, Amount: {3:C}", ps.packetnumber, ps.packetlength, accountnumber, amount); 
    }    
    
}

class MainClass
{
    static void Main()
    {
        TransactionClass pc1 = new TransactionClass("a001", 10000.00);
        TransactionClass pc2 = new TransactionClass("a002", 20000.00);
        TransactionClass pc3 = new TransactionClass("a003", 30000.00);

        pc1.sendTransactionMethod();
        pc2.sendTransactionMethod();
        pc3.sendTransactionMethod();
    }
}

            
