using NLua;
using test_nlua;

var vm = new Lua();


// Dump globals table
//Console.WriteLine("Globals:");
//try
//{
//   vm.DoString(@"

//      for k, v in pairs(_G) do
//         print(k, v)
//      end
      
//   ");
//}
//catch { }
//Console.WriteLine("------");


// Disable "dangerous" modules
vm.DoString(@"
dofile = nil
import = nil
io = nil
load = nil
loadfile = nil
luanet = nil
os = nil
package = nil
xpcall = nil
");



// Custom thingy
vm["xxx"] = (int a) => a * 2;
vm["print"] = Lib.CustomPrint;
vm.DoString(@"print('xxx =>', xxx(xxx(xxx(2))))");


vm["disponibles"] = 168;
vm["efectivas"] = 160.0;
vm["extras"] = 7.2;
vm["pausa"] = 1.4;

Console.WriteLine($"disponibles => {vm["disponibles"]}");
Console.WriteLine($"efectivas   => {vm["efectivas"]}");
Console.WriteLine($"extras      => {vm["extras"]}");
Console.WriteLine($"pausa       => {vm["pausa"]}");

Console.WriteLine("------");

vm.DoString(@"

   efectivas = 168
   extras = 0
   pausa = 0.6

");

Console.WriteLine($"disponibles => {vm["disponibles"]}");
Console.WriteLine($"efectivas   => {vm["efectivas"]}");
Console.WriteLine($"extras      => {vm["extras"]}");
Console.WriteLine($"pausa       => {vm["pausa"]}");



// Try unsafe code
try
{
   vm.DoString(@"

      local file = io.open(""test.lua"", ""a+"")
      io.output(file)
      io.write(""HACKD!"");
      
   ");
}
catch
{
   Console.WriteLine("Hacking thwarted :)");
}

