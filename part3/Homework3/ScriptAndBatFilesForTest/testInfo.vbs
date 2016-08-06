dim lib

set lib = CreateObject("PowerManagerLib.PowerManager")

if not lib is Nothing then 

    dim val
    val = lib.GetSystemBatteryStateInfo()

    WScript.Echo val

    val = lib.GetSystemPowerInformationInfo()
    WScript.Echo val

    val = lib.GetLastSleepTime()
    WScript.Echo "LastSleepTime =", val

    val = lib.GetLastWakeTime()
    WScript.Echo "LastWakeTime =", val

    'lib.Suspend();
    'lib.Hibernate();

    'val = lib.RemoveHibernationFile()
    'if (val) then
    '    WScript.Echo "Файл hibernation был удален!"
    'end if
    
    'val = lib.ReserveHibernationFile()
    'if val then
    '    WScript.Echo "Файл hibernation был создан(зарезервирован)!"
    'end if

else
    WScript.Echo "Не удалось создать объект PowerManager!"
end if
