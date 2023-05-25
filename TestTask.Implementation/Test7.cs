using TestTasks;

namespace TestTask.Implementation
{
    public class Test7 : ITest7
    {
        public IExternalCalculator AssignedCalculator { get; set; }
        public int[] CalculateHashes(byte[][] sourceArrays)
        {
            throw new System.NotImplementedException();
        }
    }
}