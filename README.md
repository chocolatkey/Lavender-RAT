
# Lavender RAT
The main base for the Lavender RAT (Windows)

Read the License.txt file for credits info. If you steal code (which you are welcome to do), credits or a link would be much appreciated.

__This project is under construction! It will probably NOT work properly for now!__

##Features (current)
* Typical info including OS, User, Antivirus process detection (out of date for now!), active window, IP, country by IP (falls back on system country setting)
* Shut down, restart, sleep, log off and lock computer
* RC4 password encryption for data
* Keylogger with formatted HTML output
* Saved passwords for Chrome, Firefox, IE, FileZilla, No-IP, DynDNS, Opera (old version), MSN, Yahoo, Paltalk (credits: Black-Blood, KingCobra, RockingWithTheBest, DarkSel, pr0t0fag, njq8)
* Typical utility features: Enable/Disable Mouse, Keyboard, Taskbar, Monitor, System Restore, CMD, Task Manager, Regedit, and of course, open and close the disk drive
* File Explorer with execute, rename and delete functions. File icons are retrieved from client!
* Remote Desktop with mouse and keyboard control. Resolution and quality adjustable and image splittable
* Show message (separate C++ app RunPE'd in to another process (Thanks AeonHack for the RunPE))
* Task Manager with kill and new process functions. Process PID, filename, CPU usage (bugged), RAM usage, Window Title and Command Line are retrieved from System.Diagnostics.Process and WMI along with the total CPU and RAM usage (tooltip needs fixing). The CPU and RAM columns are highlighted like the task manager in Windows 8+.

##Features (future)
* User level (admin or standard etc.)
* Processor, GPU, Motherboard and more specs
* RSA-4096 keypair profiles (and manager) for client authentication
* Builder (using Mono.Cecil) with obfuscation, mutex and config options (Thanks again AeonHack for the virtual keyboard control)
* File transfer to and from client
* Shell (Command Prompt access)
* Better compression for data
* Melting features need to be finished
* Multiple monitor support for Remote Desktop function
* Lock/Restrict screen with "secret" windows desktop function, keyboard remapping (anti ctrl-alt-del) and safe mode disable
* Windows Service
* Process Bootstrapper (C++)
* Webcam image (maybe)

##What took a long time to make?
* Separate C++ message function (because I've never used C++ before)
* List view column sorter that sorts Strings, Integers, Percents and B/KB/MB/GB/TB/PB/EB data sizes (feel free to steal this code)
* Task manager and file manager icon retrieval system (especially making them full-quality icons)
* RSA base
