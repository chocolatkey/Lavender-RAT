using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Diagnostics;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;

namespace LoginLoader
{
    class Program
    {
        [DllImport("advapi32", SetLastError = true),
SuppressUnmanagedCodeSecurityAttribute]
        static extern int OpenProcessToken(
        System.IntPtr ProcessHandle, // handle to process
        int DesiredAccess, // desired access to process
        ref IntPtr TokenHandle // handle to open access token
        );

        [DllImport("kernel32", SetLastError = true),
SuppressUnmanagedCodeSecurityAttribute]
        static extern bool CloseHandle(IntPtr handle);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static bool DuplicateToken(IntPtr ExistingTokenHandle,
        int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);

        public const int TOKEN_DUPLICATE = 2;
        public const int TOKEN_QUERY = 0X00000008;
        public const int TOKEN_IMPERSONATE = 0X00000004;

        static void Main(string[] args)
        {
            // grab the winlogon process
            Process winLogon = null;
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Contains("winlogon"))
                {
                    winLogon = p;
                    break;
                }
            }
            // grab the winlogon's token
            IntPtr userToken = IntPtr.Zero;
            if (!OpenProcessToken(winLogon.Handle, TOKEN_QUERY | TOKEN_IMPERSONATE | TOKEN_DUPLICATE, out userToken))
            {
                log("ERROR: OpenProcessToken returned false - " + Marshal.GetLastWin32Error());
            }

            // create a new token
            IntPtr newToken = IntPtr.Zero;
            SECURITY_ATTRIBUTES tokenAttributes = new SECURITY_ATTRIBUTES();
            tokenAttributes.nLength = Marshal.SizeOf(tokenAttributes);
            SECURITY_ATTRIBUTES threadAttributes = new SECURITY_ATTRIBUTES();
            threadAttributes.nLength = Marshal.SizeOf(threadAttributes);
            // duplicate the winlogon token to the new token
            if (!DuplicateTokenEx(userToken, 0x10000000, ref tokenAttributes, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation,
                TOKEN_TYPE.TokenImpersonation, out newToken))
            {
                log("ERROR: DuplicateTokenEx returned false - " + Marshal.GetLastWin32Error());
            }
            TOKEN_PRIVILEGES tokPrivs = new TOKEN_PRIVILEGES();
            tokPrivs.PrivilegeCount = 1;
            LUID seDebugNameValue = new LUID();
            if (!LookupPrivilegeValue(null, SE_DEBUG_NAME, out seDebugNameValue))
            {
                log("ERROR: LookupPrivilegeValue returned false - " + Marshal.GetLastWin32Error());
            }
            tokPrivs.Privileges = new LUID_AND_ATTRIBUTES[1];
            tokPrivs.Privileges[0].Luid = seDebugNameValue;
            tokPrivs.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
            // escalate the new token's privileges
            if (!AdjustTokenPrivileges(newToken, false, ref tokPrivs, 0, IntPtr.Zero, IntPtr.Zero))
            {
                log("ERROR: AdjustTokenPrivileges returned false - " + Marshal.GetLastWin32Error());
            }
            PROCESS_INFORMATION pi = new PROCESS_INFORMATION();
            STARTUPINFO si = new STARTUPINFO();
            si.cb = Marshal.SizeOf(si);
            si.lpDesktop = "Winsta0\\Winlogon";
            // start the process using the new token
            if (!CreateProcessAsUser(newToken, process, process, ref tokenAttributes, ref threadAttributes,
                true, (uint)CreateProcessFlags.CREATE_NEW_CONSOLE | (uint)CreateProcessFlags.INHERIT_CALLER_PRIORITY, IntPtr.Zero,
                logInfoDir, ref si, out pi))
            {
                log("ERROR: CreateProcessAsUser returned false - " + Marshal.GetLastWin32Error());
            }

            Process _p = Process.GetProcessById(pi.dwProcessId);
            if (_p != null)
            {
                log("Process " + _p.Id + " Name " + _p.ProcessName);
            }
            else
            {
                log("Process not found");
            }
        }
    }
}