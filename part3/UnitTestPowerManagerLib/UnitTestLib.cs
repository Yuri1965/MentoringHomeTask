using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPowerManagerLib
{

    [TestClass]
    public class UnitTestLib
    {
        private PowerManagerLib.PowerManager pwrMng = new PowerManagerLib.PowerManager();

        [TestMethod]
        public void TestGetSystemBatteryState()
        {
            PowerManagerLib.SYSTEM_BATTERY_STATE batState = pwrMng.GetSystemBatteryState();

            Console.WriteLine(batState.ToString());
        }

        [TestMethod]
        public void TestGetSystemPowerInfo()
        {
            PowerManagerLib.SYSTEM_POWER_INFORMATION pwrInfo = pwrMng.GetSystemPowerInformation();

            Console.WriteLine(pwrInfo.ToString());
        }

        [TestMethod]
        public void TestLastSleepTimeAndLastWakeTime()
        {
            Console.WriteLine("LastSleepTime = {0}",  pwrMng.GetLastSleepTime());
            Console.WriteLine("LastWakeTime = {0}", pwrMng.GetLastWakeTime());
        }

        [TestMethod]
        public void TestReserveHibernationFile()
        {
            Console.WriteLine(pwrMng.ReserveHibernationFile() ? "Hibernation file is reserved!" : "Hibernation file isn't reserved!");
        }

        [TestMethod]
        public void TestRemoveHibernationFile()
        {
            Console.WriteLine(pwrMng.RemoveHibernationFile() ? "Hibernation file is removed!" : "Hibernation file isn't removed!");
        }

        [TestMethod]
        public void TestSuspend()
        {
            pwrMng.Suspend();
        }

        [TestMethod]
        public void TestHibernate()
        {
            pwrMng.Hibernate();
        }
    }
}
