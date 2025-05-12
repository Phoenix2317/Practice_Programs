// See https://aka.ms/new-console-template for more information

countDown(10);

///<summary>
///Counts down from a given int to 1 with each call
/// </summary>
void countDown(int num)
{
    if (num == 1) Console.WriteLine(num);
    else
    {
        Console.WriteLine(num);
        countDown(num - 1);
    }

}