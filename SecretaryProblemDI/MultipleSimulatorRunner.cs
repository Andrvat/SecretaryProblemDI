// namespace SecretaryProblemDI;
//
// public static class MultipleSimulatorRunner
// {
//     private const int SimulateCounter = 10000;
//
//     public static void Run(string[] args)
//     {
//         for (var factor = 0.5; factor <= 1; factor += 0.01)
//         {
//             var happiness = 0;
//             for (var i = 0; i < SimulateCounter; i++)
//             {
//                 args[1] = factor.ToString();
//                 var simuator = new TaskSimulator();
//                 happiness += simuator.Simulate();
//             }
//
//             Console.WriteLine($"{factor} : {(double)happiness / SimulateCounter}");
//         }
//     }
// }