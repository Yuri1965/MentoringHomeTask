using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PowerManagerLib
{
    [ComVisible(true)]
    [Guid("6FB52872-70EE-4BF2-A0A2-BFB6239120E4")]
    [ClassInterface(ClassInterfaceType.None)]
    public class PowerManager : IPowerManager
    {

        #region SystemBatteryState
        public string GetSystemBatteryStateInfo()
        {
            try
            {
                return GetSystemBatteryState().ToString();
            }
            catch (Exception e)
            {
                return String.Format("When obtaining information on a condition of the power supply there was a error:\n {0}", e.Message);
            }
        }

        public unsafe SYSTEM_BATTERY_STATE GetSystemBatteryState()
        {
            SYSTEM_BATTERY_STATE result;
            SYSTEM_BATTERY_STATE* ptr = &result;
            var ret = PowerManagerNativeApi.CallNtPowerInformation(InformationLevel.SystemBatteryState, IntPtr.Zero, 0, new IntPtr(ptr),
              sizeof(SYSTEM_BATTERY_STATE));

            if (ret != PowerManagerNativeApi.STATUS_SUCCESS)
                throw new PowerManagerException(String.Format("Call to CallNtPowerInformation failed! GetSystemBatteryState error:\n {0}",
                    GetErrorMessageByCode(Marshal.GetLastWin32Error())));

            return result;
        }
        #endregion

        #region SystemPowerInfo
        public string GetSystemPowerInformationInfo()
        {
            try
            {
                return GetSystemPowerInformation().ToString();
            }
            catch (Exception e)
            {
                return String.Format("When obtaining information on a condition of parameters of idle time of system there was a error:\n {0}", e.Message);
            }
        }

        public unsafe SYSTEM_POWER_INFORMATION GetSystemPowerInformation()
        {
            SYSTEM_POWER_INFORMATION result;
            SYSTEM_POWER_INFORMATION* ptr = &result;
            var ret = PowerManagerNativeApi.CallNtPowerInformation(InformationLevel.SystemPowerInformation, IntPtr.Zero, 0, new IntPtr(ptr),
              sizeof(SYSTEM_POWER_INFORMATION));

            if (ret != PowerManagerNativeApi.STATUS_SUCCESS)
                throw new PowerManagerException(String.Format("Call to CallNtPowerInformation failed! GetSystemPowerInformation error:\n {0}",
                    GetErrorMessageByCode(Marshal.GetLastWin32Error())));

            return result;
        }
        #endregion

        #region LastSleepTime OR LastWakeTime
        public ulong GetLastSleepTime()
        {
            return GetUnsingedLongValue(InformationLevel.LastSleepTime);
        }

        public ulong GetLastWakeTime()
        {
            return GetUnsingedLongValue(InformationLevel.LastWakeTime);
        }

        private static unsafe ulong GetUnsingedLongValue(InformationLevel level)
        {
            ulong result;
            ulong* ptr = &result;
            var ret = PowerManagerNativeApi.CallNtPowerInformation(level, IntPtr.Zero, 0, new IntPtr(ptr), sizeof(ulong));

            if (ret != PowerManagerNativeApi.STATUS_SUCCESS)
                throw new PowerManagerException(String.Format("Call to CallNtPowerInformation failed! Get{0} error:\n {1}",
                    System.Enum.GetName(typeof(InformationLevel), level),
                    GetErrorMessageByCode(Marshal.GetLastWin32Error())));

            return result;
        }
        #endregion

        #region ReserveHibernationFile OR RemoveHibernationFile
        public bool ReserveHibernationFile()
        {
            bool result = ReserveOrRemoveHibernationFile(true);

            if (!result)
                throw new PowerManagerException(String.Format("Call to CallNtPowerInformation failed! ReserveHibernationFile error:\n {0}",
                    GetErrorMessageByCode(Marshal.GetLastWin32Error())));
            
            return result;
        }

        public bool RemoveHibernationFile()
        {
            bool result = ReserveOrRemoveHibernationFile(false);

            if (!result)
                throw new PowerManagerException(String.Format("Call to CallNtPowerInformation failed! RemoveHibernationFile error:\n {0}",
                    GetErrorMessageByCode(Marshal.GetLastWin32Error())));

            return result;
        }

        private static unsafe bool ReserveOrRemoveHibernationFile(bool reserve)
        {
            bool* ptr = &reserve;
            var ret = PowerManagerNativeApi.CallNtPowerInformation(InformationLevel.SystemReserveHiberFile, new IntPtr(ptr), sizeof(bool), IntPtr.Zero, 0);

            if (ret != PowerManagerNativeApi.STATUS_SUCCESS)
                return false;
            else
                return true;
        }
        #endregion

        #region Suspend OR Hibernate
        public void Suspend()
        {
            if (!SuspendOrHibernate(false))
                throw new PowerManagerException(String.Format("Call to SetSuspendState failed! Suspend error:\n {0}",
                    GetErrorMessageByCode(Marshal.GetLastWin32Error())));
        }

        public void Hibernate()
        {
            if (!SuspendOrHibernate(true))
                throw new PowerManagerException(String.Format("Call to SetSuspendState failed! Hibernate error::\n {0}",
                    GetErrorMessageByCode(Marshal.GetLastWin32Error())));
        }

        private static bool SuspendOrHibernate(bool hibernate)
        {
            return PowerManagerNativeApi.SetSuspendState(hibernate, false, false);
        }
        #endregion

        private static string GetErrorMessageByCode(int errorCode)
        {
            return new System.ComponentModel.Win32Exception(errorCode).Message;
        }

    }
}
