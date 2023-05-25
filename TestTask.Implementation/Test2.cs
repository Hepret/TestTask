using TestTasks;

namespace TestTask.Implementation
{
    public class Test2 : ITest2
    {
        public void Case1_NotifyUserRegistered(string userName)
        {
            throw new System.NotImplementedException();
        }

        public int Case1_GetRegisteredUsersCount()
        {
            throw new System.NotImplementedException();
        }

        public string Case2_NotifyMeter(string serialNumber)
        {
            throw new System.NotImplementedException();
        }

        public bool Case2_MeterAlreadyExists(string serialNumber)
        {
            throw new System.NotImplementedException();
        }

        public void Case3_NotifyUserSecurityEvent(string userName, bool userLoggedIn)
        {
            throw new System.NotImplementedException();
        }

        public int Case3_GetUserLoggedInCount(string userName)
        {
            throw new System.NotImplementedException();
        }

        public void Case4_NotifyCommand(int commandCode)
        {
            throw new System.NotImplementedException();
        }

        public int? Case4_TryExtractNextCommand()
        {
            throw new System.NotImplementedException();
        }

        public void Case5_PushContext(string contextDescription)
        {
            throw new System.NotImplementedException();
        }

        public string Case5_PopContext()
        {
            throw new System.NotImplementedException();
        }
    }
}