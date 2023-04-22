# Windows thread management

Win forms app that imports the windows kernel32.dll for GUI process thread management.

Contains a separate spawned mock counter thread for testing.

<br>

## Info

> **__Note__** &nbsp; <br> App is setup to run with admin privileges. Blocking certain threads can easily cause the system to freeze.


### Thread management

Dll imports:

```c#
[DllImport("kernel32.dll")]
static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
[DllImport("kernel32.dll")]
static extern uint SuspendThread(IntPtr hThread);
[DllImport("kernel32.dll")]
static extern int ResumeThread(IntPtr hThread);
[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
static extern bool CloseHandle(IntPtr handle);
```

- **Suspend**: kernel32.dll handle for opening and suspening selected threads
- **Resume**: kernel32.dll handle for opening and resuming selected threads

### Mock thread counter

The app runs a separate counter thread which can be paused and resumed, therefore affecting the total counter displayed on the GUI.

<br>

## Demo

Getting app process, stopping and resuming mock thread execution.


https://user-images.githubusercontent.com/72694712/233787078-3f15c553-5695-4f57-b78a-5cb95e28b938.mp4


  
<br>

## Tech

**IDEs:** [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

**Frameworks:** [ASP.NET Core](https://learn.microsoft.com/en-us/dotnet/fundamentals/)

[![My Skills](https://skillicons.dev/icons?i=dotnet,visualstudio)](https://skillicons.dev)

<br>

## References

- [Win32 - Processes and threads](https://learn.microsoft.com/en-us/windows/win32/api/_processthreadsapi/)
- [Win32 - Access rights](https://learn.microsoft.com/en-us/windows/win32/procthread/thread-security-and-access-rights)

Other:

- [Stackoverflow - Killing/ aborting a specific thread using it's ID in C#](https://stackoverflow.com/questions/28295619/killing-aborting-a-specific-thread-using-its-id-in-c-sharp)

<br>

## Authors

- [@v-gabriel](https://github.com/v-gabriel)
