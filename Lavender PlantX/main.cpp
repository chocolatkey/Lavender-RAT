#ifndef WIN32_LEAN_AND_MEAN
#define WIN32_LEAN_AND_MEAN
#endif
#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif
#include <windows.h>
#include <winsock2.h>
#include <ws2tcpip.h>
#include <iphlpapi.h>
#include <stdio.h>
#include <iostream>
#include <wininet.h>
#include "mem.h"
#include "str.h"
#include "debug.h"
#include "wsocket.h"
#include "sync.h"
#include "process.h"
#include "vnc/vncserver.h"
#include "mem.h"
#include "debug.h"

//#define SOCKET_TIMEOUT = 30 * 1000

class outbuf : public std::streambuf {
public:
	outbuf() {
		setp(0, 0);
	}

	virtual int_type overflow(int_type c = traits_type::eof()) {
		return fputc(c, stdout) == EOF ? traits_type::eof() : c;
	}
};

int WINAPI
WinMain(
	__in HINSTANCE hInstance,
	__in HINSTANCE hPrevInstance,
	__in LPSTR lpCmdLine,
	__in int nCmdShow)
{

	Mem::init(512 * 1024);

	DebugClient::Init();
	DebugClient::RegisterExceptionFilter();

	HMODULE hUser32 = LoadLibrary(L"user32.dll");
	typedef BOOL(*SetProcessDPIAwareFunc)();
	SetProcessDPIAwareFunc setDPIAware = NULL;
	if (hUser32) setDPIAware = (SetProcessDPIAwareFunc)GetProcAddress(hUser32, "SetProcessDPIAware");
	if (setDPIAware) setDPIAware();
	if (hUser32) FreeLibrary(hUser32);
	if (AllocConsole()) {
		freopen("CONOUT$", "w", stdout);
		SetConsoleTitle(L"Debug Console");
		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_RED);
	}

	// set std::cout to use custom streambuf
	outbuf ob;
	std::streambuf *sb = std::cout.rdbuf(&ob);

	std::cout << "Started" << std::endl;

	/*int msgboxID = MessageBox(
		NULL,
		(LPCWSTR)L"Koku",
		(LPCWSTR)L"Dialog",
		MB_ICONWARNING | MB_CANCELTRYCONTINUE | MB_DEFBUTTON2
	);*/

	WSADATA wsaData;

    #define DEFAULT_PORT "5900"

	struct addrinfo *result = NULL, *ptr = NULL, hints;

	int iResult;

	// Initialize Winsock
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != 0) {
		std::cout << "WSAStartup failed: failed: " << iResult;
		return 1;
	}

	ZeroMemory(&hints, sizeof(hints));
	hints.ai_family = AF_INET;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;
	hints.ai_flags = AI_PASSIVE;

	// Resolve the local address and port to be used by the server
	iResult = getaddrinfo(NULL, DEFAULT_PORT, &hints, &result);
	if (iResult != 0) {
		std::cout << "getaddrinfo failed: " << iResult;
		//Sleep(3000);
		//std::cout.rdbuf(sb);
		WSACleanup();
		return 1;
	}

	SOCKET ListenSocket = INVALID_SOCKET;
	// Create a SOCKET for the server to listen for client connections
	ListenSocket = socket(result->ai_family, result->ai_socktype, result->ai_protocol);

	if (ListenSocket == INVALID_SOCKET) {
		std::cout << "Error at socket(): " << WSAGetLastError();
		freeaddrinfo(result);
		WSACleanup();
		return 1;
	}

	// Setup the TCP listening socket
	iResult = bind(ListenSocket, result->ai_addr, (int)result->ai_addrlen);
	if (iResult == SOCKET_ERROR) {
		std::cout << "bind failed with error: " << WSAGetLastError();
		freeaddrinfo(result);
		closesocket(ListenSocket);
		WSACleanup();
		return 1;
	}

	freeaddrinfo(result);

	VncServer::init();
	std::cout << "Initialized" << std::endl;
	if (ListenSocket != INVALID_SOCKET)
	{
		std::cout << "Socket success" << std::endl;
		WSocket::tcpDisableDelay(ListenSocket, true);
		WSocket::tcpSetKeepAlive(ListenSocket, true, 5 * 60 * 1000, 5 * 1000);
		VncServer::start(ListenSocket);
	}
	std::cout << "Shutting down" << std::endl;
	WSocket::tcpClose(ListenSocket);
	VncServer::uninit();

	std::cout << "Goodbye!" << std::endl;
	Sleep(3000);
	std::cout.rdbuf(sb);
	return 0;
}