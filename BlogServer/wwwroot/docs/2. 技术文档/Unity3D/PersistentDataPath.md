#unity 

# ApplicationpersistentDataPath
url: https://docs.unity3d.com/ScriptReference/Application.html

Leave feedback

public static string **persistentDataPath**;

### **Description**

(Read Only) Contains the path to a persistent data directory.

This value is a directory path where you can store data that you want to be kept between runs. When you publish on iOS and Android, persistentDataPath points to a public directory on the device. Files in this location are not erased by app updates. The files can still be erased by users directly.When you build the Unity application, a GUID is generated that is based on the Bundle Identifier. This GUID is part of persistentDataPath. If you keep the same Bundle Identifier in future versions, the application keeps accessing the same location on every update.

**Windows Store Apps**: [Application.persistentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html) points to `%userprofile%\\AppData\\Local\\Packages\\<productname>\\LocalState`.

**Windows Editor and Standalone Player**: [Application.persistentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html) usually points to `%userprofile%\\AppData\\LocalLow\\<companyname>\\<productname>`. It is resolved by [SHGetKnownFolderPath](https://docs.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shgetknownfolderpath) with FOLDERID_LocalAppDataLow, or [SHGetFolderPathW](https://docs.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shgetfolderpathw) with CSIDL_LOCAL_APPDATA if the former is not available.

**WebGL**: [Application.persistentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html) points to `/idbfs/<md5 hash of data path>` where the data path is the URL stripped of everything including and after the last '/' before any '?' components.

**Linux**: [Application.persistentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html) points to `$XDG_CONFIG_HOME/unity3d` or `$HOME/.config/unity3d`.

**iOS**: [Application.persistentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html) points to `/var/mobile/Containers/Data/Application/<guid>/Documents`.

**tvOS**: [Application.persistentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html) is not supported and returns an empty string.

**Android**: [Application.persistentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html) points to `/storage/emulated/0/Android/data/<packagename>/files` on most devices (some older phones might point to location on SD card if present), the path is resolved using [android.content.Context.getExternalFilesDir](https://developer.android.com/reference/android/content/Context#getExternalFilesDir(java.lang.String)).

**Mac**: [Application.persistentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html) points to the user Library folder. (This folder is often hidden.) In recent Unity releases user data is written into `~/Library/Application Support/company name/product name`. Older versions of Unity wrote into the `~/Library/Caches` folder, or `~/Library/Application Support/unity.company name.product name`. These folders are all searched for by Unity. The application finds and uses the oldest folder with the required data on your system.