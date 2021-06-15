using System;
using System.Threading;
using System.IO;
using System.Diagnostics;

//Done by R.W.A.D.U.Rajapakshe
//20547312
namespace Authenticator
{
    class ClearTokenThread
    {
        public void clearTokens() {
            Stopwatch sw = new Stopwatch();
            try
            {
                Console.WriteLine("Enter number of minutes for periodical cleanup ");
                double min = Convert.ToDouble(Console.ReadLine());
                do
                {
                    sw.Start();
                    //to convert the minutes into milli seconds
                    Thread.Sleep((int)(min * 60000));
                    sw.Stop();
                    //clear all the data from the local file token.txt
                    File.WriteAllText("token.txt", string.Empty);

                } while (true);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
