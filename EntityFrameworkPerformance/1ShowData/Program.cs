using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using _1ShowData.AdsModels;
using System.Diagnostics;

namespace _1ShowData
{
    class Program
    {
        static void Main()
        {
            var context = new AdsContext();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            var adsEverything = context.Ads;

            foreach (Ad ad in adsEverything)
            {
                Console.WriteLine(ad.Title);
            }

            Console.Clear();
            stopwatch.Stop();
            var nonOptimizedTime = stopwatch.Elapsed;


            stopwatch.Reset();
            stopwatch.Start();
            var adsTitle = context.Ads.Select(ad => ad.Title);

            foreach (var item in adsTitle)
            {
                Console.WriteLine(item);
            }

            stopwatch.Stop();
            Console.Clear();
            var optimizedTime = stopwatch.Elapsed;

            Console.WriteLine($"Non-optimized: {nonOptimizedTime}");
            Console.WriteLine($"Optimized:     {optimizedTime}");

        }
    }
}
