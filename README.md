# Windows thread management

Win forms app that imports the windows kernel32.dll for GUI process thread management.

> **Note** <br>
App is setup to run with admin privileges. Use with caution.

<br>

## Info

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

### Counter thread

Separate counter thread which can be used for suspend/ resume testing.

Counts to 100.

### Rollback thread
 
Standalone rollback service which triggers a resume operation on suspended threads.

Triggers every 10 seconds.
 
<br>

## Demo

Getting app process, stopping and resuming mock thread execution.

//TODO

Blocking system threads, waiting for rollback thread to resume.

//TODO

Closing main window, waiting for thread cleanup.

//TODO
  
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

## Appendix

- [Process explorer](https://learn.microsoft.com/en-us/sysinternals/downloads/process-explorer)

<br>

## Authors

- [@v-gabriel](https://github.com/v-gabriel)
