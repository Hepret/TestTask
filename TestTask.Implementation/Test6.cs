using TestTasks;

namespace TestTask.Implementation
{
    public class Test6 : ITest6
    {
        public IExternalCalculator AssignedCalculator { get; set; }
        public void RegisterDataToCalculate(byte[] sourceData)
        {
            throw new System.NotImplementedException();
        }

        public int[] GetCalculatedHashes()
        {
            throw new System.NotImplementedException();
        }
    }
}