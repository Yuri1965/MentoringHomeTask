using System;
using System.Text;
using System.Runtime.InteropServices;

namespace PowerManagerLib
{
    static class PowerManagerNativeApi
    {
        public const int STATUS_SUCCESS = 0;

        [DllImport("PowrProf.dll", SetLastError = true)]
        public static extern uint CallNtPowerInformation([MarshalAs(UnmanagedType.I4)] InformationLevel InformationLevel, IntPtr lpInputBuffer, int nInputBufferSize,
          IntPtr lpOutputBuffer, int nOutputBufferSize);


        [DllImport("PowrProf.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool SetSuspendState([MarshalAs(UnmanagedType.U1)]bool Hibernate, [MarshalAs(UnmanagedType.U1)]bool ForceCritical,
          [MarshalAs(UnmanagedType.U1)]bool DisableWakeEvent);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_POWER_INFORMATION
    {
        public uint MaxIdlenessAllowed;
        public uint Idleness;
        public uint TimeRemaining;
        public byte CoolingMode;

        public override string ToString()
        {
            StringBuilder infoBuilder = new StringBuilder();
            infoBuilder.AppendLine(String.Format("Information on a condition of parameters of idle time of system:"));
            infoBuilder.AppendLine(String.Format("MaxIdlenessAllowed: {0}", MaxIdlenessAllowed));
            infoBuilder.AppendLine(String.Format("Idleness: {0}", Idleness));
            infoBuilder.AppendLine(String.Format("TimeRemaining: {0}", TimeRemaining));
            infoBuilder.AppendLine(String.Format("CoolingMode: {0}", CoolingMode));

            return infoBuilder.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_BATTERY_STATE
    {
        public bool AcOnLine;
        public bool BatteryPresent;
        public bool Charging;
        public bool Discharging;
        public bool Spare11;
        public bool Spare12;
        public bool Spare13;
        public bool Spare14;
        public uint MaxCapacity;
        public uint RemainingCapacity;
        public uint Rate;
        public uint EstimatedTime;
        public uint DefaultAlert1;
        public uint DefaultAlert2;

        public override string ToString()
        {
            StringBuilder infoBuilder = new StringBuilder();
            infoBuilder.AppendLine(String.Format("Information on a condition of the power supply:"));
            infoBuilder.AppendLine(String.Format("AcOnLine: {0}", AcOnLine));
            infoBuilder.AppendLine(String.Format("BatteryPresent: {0}", BatteryPresent));
            infoBuilder.AppendLine(String.Format("Charging: {0}", Charging));
            infoBuilder.AppendLine(String.Format("Discharging: {0}", Discharging));
            infoBuilder.AppendLine(String.Format("MaxCapacity: {0}", MaxCapacity));
            infoBuilder.AppendLine(String.Format("RemainingCapacity: {0}", RemainingCapacity));
            infoBuilder.AppendLine(String.Format("Rate: {0}", Rate));
            infoBuilder.AppendLine(String.Format("EstimatedTime: {0}", EstimatedTime));
            infoBuilder.AppendLine(String.Format("DefaultAlert1: {0}", DefaultAlert1));
            infoBuilder.AppendLine(String.Format("DefaultAlert2: {0}", DefaultAlert2));

            return infoBuilder.ToString();
        }
    };

    enum InformationLevel
    {
        SystemBatteryState = 5,
        SystemPowerInformation = 12,
        LastWakeTime = 14,
        LastSleepTime = 15,
        SystemReserveHiberFile = 10
    }
}