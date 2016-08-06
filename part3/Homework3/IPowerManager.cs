using System;
using System.Runtime.InteropServices;

namespace PowerManagerLib
{
    [ComVisible(true)]
    [Guid("87508117-D113-4172-BB83-11D869B68394")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    interface IPowerManager
    {
        string GetSystemBatteryStateInfo();
        SYSTEM_BATTERY_STATE GetSystemBatteryState();

        string GetSystemPowerInformationInfo();
        SYSTEM_POWER_INFORMATION GetSystemPowerInformation();

        ulong GetLastSleepTime();
        ulong GetLastWakeTime();

        void Suspend();
        void Hibernate();

        bool ReserveHibernationFile();
        bool RemoveHibernationFile();
    }
}
