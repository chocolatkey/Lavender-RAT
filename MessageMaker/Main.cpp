// MessageMaker.cpp : Defines the entry point for the console application.
//

#include <windows.h>
#include <string>
#include <regex>
#include <atlstr.h>

using namespace std;


int WINAPI WinMain(HINSTANCE inst, HINSTANCE prev, char* cl, int show)
{
	/*Match Regex "@#@"*/
	const tr1::regex pattern("@#@(.+)@#@(.+)");
	cmatch m;
	regex_match(cl, m, pattern);

	/*Message*/
	CString ss;
	ss.Format(_T("%S"), m.str(1).c_str());
	CStringA strA(ss);

	LPCSTR msg = strA;

	/*MessageBox Type*/
	CString ss2;
	ss2.Format(_T("%S"), m.str(2).c_str());
	CStringA strB(ss2);
	
	UINT mt = MB_OK;
	if (strB == "e"){
		mt = MB_ICONERROR;
	}
	else if (strB == "i"){
		mt = MB_ICONINFORMATION;
	}
	else if (strB == "q"){
		mt = MB_ICONQUESTION;
	}
	else if (strB == "w"){
		mt = MB_ICONWARNING;
	}

	/*Show MessageBox*/
	MessageBoxA(NULL, msg, "", mt);
	return 0;
}