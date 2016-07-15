/*
  ������ � Window Station's � Desktop's.

  ����������: �.�. ������ ����������� ��������������� ����� �����, ��������� ���� ������������
              ������������, � ����� �� ������.
*/
#pragma once

namespace WindowStation
{
  /*
    �������������.
  */
  void init(void);

  /*
    ���������������.
  */
  void uninit(void);

  /*
    ��������� ����� �������.

    IN handle - ������.

    Return    - ��� �������, ���������� ���������� ����� Mem. ��� NULL � ������ ������.
  */
  LPWSTR _getObjectName(HANDLE handle);

  /*
    ��������� ��������� �� ������ �� ���� � ����� ������.

    IN handle1 - ������ 1.
    IN handle2 - ������ 2.

    Return     - true - ���� ������ ����������� ������ � ������� �������,
                 false - � ��������� ������.
  */
  bool _isEqualObjects(HANDLE handle1, HANDLE handle2);

  /*
    ��������� ��� ������� �������.
    
    IN name          - ��� ������� ��� NULL ��� ��������� Winsta0.
    IN desiredAccess - ����� �������.

    Return           - ����� ������� (����� �������� ����� CloseWindowStation),
                       ��� NULL � ������ ������.
  */
  HWINSTA _openWindowStation(const LPWSTR name, ACCESS_MASK desiredAccess);

  /*
    ��������� ������� ������� ��� �������.

    IN handle - ������� ��� ���������.

    Return    - true - � ������ ������,
                false - � ������ ������.
  */
  bool _setProcessWindowStation(HWINSTA handle);

  /*
    ��������� ��� ������� �������.

    IN name          - ��� �������� ��� NULL ��� ��������� default.
    IN desiredAccess - ����� �������.

    Return           - ����� ������� (����� �������� ����� CloseDesktop),
                       ��� NULL � ������ ������.
  */
  HDESK _openDesktop(const LPWSTR name, ACCESS_MASK desiredAccess);

  /*
    ������������ ������� ������ �� �������.

    IN handle - ������ �� ������� ������� �������������.

    Return    - true - � ������ ������,
                false - � ������ ������.
  */
  bool _setThreadDesktop(HDESK handle);

  /*
    ������������ ������� ������ �� �������.

    IN stationName - ��� ������� ��� NULL ��� ��������� Winsta0. ���� ������� �� ���������,
                     ��� ����� �������.
    IN desktopName - ��� �������� ��� NULL ��� ��������� default. ���� ������� �� ���������,
                     �� ����� �������.

    Return         - true - � ������ ������,
                     false - � ������ ������.
  */
  bool _setThreadDesktopEx(const LPWSTR stationName, const LPWSTR desktopName);
};