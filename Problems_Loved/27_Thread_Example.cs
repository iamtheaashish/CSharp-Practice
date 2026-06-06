Thread mainThread = Thread.CurrentThread;
mainThread.Name = "Main Thread";

Thread thread1 = new Thread(CountDown);
Thread thread2 = new Thread(CountUp);
thread1.Start();
thread2.Start();

Console.WriteLine(mainThread.Name + " is complete!");


static void CountDown()
{
    for(int i = 10; i >= 0; i--)
    {
        Console.WriteLine("Timer #1 : " + i + " seconds");
        Thread.Sleep(1000);
    }
}
static void CountUp()
{
    for(int i = 0; i <= 10; i++)
    {
        Console.WriteLine("Timer #2 : " + i + " seconds");
        Thread.Sleep(1000);
    }
}