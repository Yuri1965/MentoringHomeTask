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
        WScript.Echo("���� hibernation ��� ������!");
    }
    */

    /*
    val = lib.ReserveHibernationFile();
    if (val) {
        WScript.Echo("���� hibernation ��� ������(��������������)!");
    }
    */

} else { WScript.Echo("�� ������� ������� ������ PowerManager!"); }

