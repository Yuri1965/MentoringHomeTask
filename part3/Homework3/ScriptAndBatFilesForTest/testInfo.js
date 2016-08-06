var lib = new ActiveXObject("PowerManagerLib.PowerManager");

if (lib != null) {

    var val = lib.GetSystemBatteryStateInfo();
    WScript.Echo(val);

    val = lib.GetSystemPowerInformationInfo();
    WScript.Echo(val);

    val = lib.GetLastSleepTime();
    WScript.Echo("LastSleepTime = ", val);

    val = lib.GetLastWakeTime();
    WScript.Echo("LastWakeTime = ", val);

    /*lib.Suspend();*/
    /*lib.Hibernate();*/

    /*
    val = lib.RemoveHibernationFile();
    if (val) {
        WScript.Echo("Файл hibernation был удален!");
    }
    */

    /*
    val = lib.ReserveHibernationFile();
    if (val) {
        WScript.Echo("Файл hibernation был создан(зарезервирован)!");
    }
    */

} else { WScript.Echo("Не удалось создать объект PowerManager!"); }

