// struct

using System;

struct PacketStruct
{
    public uint packetnumber;
    public ushort packetlength;
}

class TransactionClass
{
    static uint transactionnumber = 1;
  
    public string accountnumber; // Note public
    public double amount; // Note public

    public PacketStruct ps; // Note public
   
    public TransactionClass(string an, double am)
    {
        ps.packetnumber = transactionnumber++; 
        ps.packetlength = 512; 

        accountnumber = an;
        amount = am;
    }
  

    /* 
    public void sendTransactionMethod()
    {
        Console.WriteLine("Packet number: {0}, Packet length: {1}, Account number: {2}, Amount: {3}", ps.packetnumber, ps.packetlength, accountnumber, amount); 
    } 
    */    
    
}

class MainClass
{
    static void Main()
    {        
        TransactionClass pc1 = new TransactionClass("a001", 10000.00);
        TransactionClass pc2 = new TransactionClass("a002", 20000.00);
        TransactionClass pc3 = new TransactionClass("a003", 30000.00);
       
        Console.WriteLine("Packet number: {0}, Packet length: {1}, Account number: {2}, Amount: {3}", pc1.ps.packetnumber, pc1.ps.packetlength, pc1.accountnumber, pc1.amount); 
        Console.WriteLine("Packet number: {0}, Packet length: {1}, Account number: {2}, Amount: {3}", pc2.ps.packetnumber, pc2.ps.packetlength, pc2.accountnumber, pc2.amount); 
        Console.WriteLine("Packet number: {0}, Packet length: {1}, Account number: {2}, Amount: {3}", pc3.ps.packetnumber, pc3.ps.packetlength, pc3.accountnumber, pc3.amount); 

      
        /*
        pc1.sendTransactionMethod();        
        pc2.sendTransactionMethod();
        pc3.sendTransactionMethod();
        */
    }
}

            
