using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_nlua
{
   public static class Lib
   {
      public static void CustomPrint(params object[] args)
      {
         Console.Write("CustomPrint: ");
         Console.WriteLine("[" + string.Join(", ", args.Select(x => x.ToString())) + "]");
      }
   }
}
