Attribute VB_Name = "RegistryAPI"
Option Explicit
Option Compare Text
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' modRegistry
' By Chip Pearson, www.cpearson.com, chip@cpearson.com
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'
' This function provides several functions related to working with keys and values in the system
' registry. These routines call upon one another, so you should import this entire module into
' your project rather than just copy/pasting an individual procedures.
'
' This module is described and avaialable for download at http://www.cpearson.com/Excel/Registry.htm.
'
' Error conditions and details are reported in the following public variables:
'       G_Reg_AppErrNum As Long         Returns the module-defined error number.
'       G_Reg_AppErrText As String      Returns the text description of G_Reg_AppErrNum
'       G_Reg_SysErrNum As Long         Returns the system error number, usually the value of Err.LastDllError
'       G_Reg_SysErrText As String      Returns the text description associated with G_Reg_SysErrNum, the text
'                                       returned from GetSystemErrorMessageText.
'
' This module requires the moGetSystemErrorMessageText module, described and available for download at
' http://www.cpearson.com/excel/FormatMessage.htm. This module itself is described and available for
' download at http://www.cpearson.com/excel/registry.htm.
'
' In all functions with a BaseKey parameter, the value of BaseKey must be either HKEY_CURRENT_USER (or HKCU) or
' HKEY_LOCAL_MACHINE (or HKML). Any other value is invalid.
'
' Public Functions In This Module:
' --------------------------------
'   RegistryGetValue
'   RegistryGetValueType
'   RegistryCreateKey
'   RegistryCreateValue
'   RegistryDeleteKey
'   RegistryDeleteValue
'   RegistryKeyExists
'   RegistryValueExists
'   RegistryUpdateValue
'
' See http://www.cpearson.com/excel/registry.htm for details about these procedures.
'
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Error Constants
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Public Const C_REG_ERR_NO_ERROR = 0
Public Const C_REG_ERR_INVALID_BASE_KEY = vbObjectError + 1
Public Const C_REG_ERR_INVALID_DATA_TYPE = vbObjectError + 2
Public Const C_REG_ERR_KEY_NOT_FOUND = vbObjectError + 3
Public Const C_REG_ERR_VALUE_NOT_FOUND = vbObjectError + 4
Public Const C_REG_ERR_DATA_TYPE_MISMATCH = vbObjectError + 5
Public Const C_REG_ERR_ENTRY_LOCKED = vbObjectError + 6
Public Const C_REG_ERR_INVALID_KEYNAME = vbObjectError + 7
Public Const C_REG_ERR_UNABLE_TO_OPEN_KEY = vbObjectError + 8
Public Const C_REG_ERR_UNABLE_TO_READ_KEY = vbObjectError + 9
Public Const C_REG_ERR_UNABLE_TO_CREATE_KEY = vbObjectError + 10
Public Const C_REG_ERR_UBABLE_TO_READ_VALUE = vbObjectError + 11
Public Const C_REG_ERR_UNABLE_TO_UDPATE_VALUE = vbObjectError + 12
Public Const C_REG_ERR_UNABLE_TO_CREATE_VALUE = vbObjectError + 13
Public Const C_REG_ERR_UNABLE_TO_DELETE_KEY = vbObjectError + 14
Public Const C_REG_ERR_UNABLE_TO_DELETE_VALUE = vbObjectError + 15




'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' API Constants
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Public Const HKEY_CURRENT_USER As Long = &H80000001
Public Const HKEY_LOCAL_MACHINE As Long = &H80000002
Public Const HKEY_CLASSES_ROOT = &H80000000
Public Const HKEY_CURRENT_CONFIG = &H80000005
Public Const HKEY_DYN_DATA = &H80000006
Public Const HKEY_PERFORMANCE_DATA = &H80000004
Public Const HKEY_USERS = &H80000003


Public Const HKCU = HKEY_CURRENT_USER
Public Const HKLM = HKEY_LOCAL_MACHINE


Private Const REGSTR_MAX_VALUE_LENGTH As Long = &H100

Private Const KEY_QUERY_VALUE = &H1
Private Const KEY_SET_VALUE = &H2
Private Const KEY_CREATE_SUB_KEY = &H4
Private Const KEY_ENUMERATE_SUB_KEYS = &H8
Private Const KEY_NOTIFY = &H10
Private Const KEY_CREATE_LINK = &H20
Private Const KEY_ALL_ACCESS = &H3F

Private Const REG_CREATED_NEW_KEY = &H1
Private Const REG_OPENED_EXISTING_KEY = &H2

Private Const STANDARD_RIGHTS_ALL = &H1F0000
Private Const SPECIFIC_RIGHTS_ALL = &HFFFF

Private Const REG_OPTION_NON_VOLATILE = 0&
Private Const REG_OPTION_VOLATILE = &H1

Private Const ERROR_SUCCESS = 0&
Private Const ERROR_ACCESS_DENIED = 5
Private Const ERROR_INVALID_DATA = 13&
Private Const ERROR_MORE_DATA = 234    '  dderror
Private Const ERROR_NO_MORE_ITEMS = 259

Private Const S_OK = &H0
Private Const MAX_DATA_BUFFER_SIZE = 1024


'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' API Types
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Private Type SECURITY_ATTRIBUTES
    nLength As Long
    lpSecurityDescriptor As Long
    bInheritHandle As Boolean
End Type

Private Type FILETIME
    dwLowDateTime As Long
    dwHighDateTime As Long
End Type

Public Enum REG_DATA_TYPE
    REG_INVALID = -1    ' Invalid
    REG_SZ = 1       ' String
    REG_DWORD = 4    ' Long
End Enum

Private Type ACL
    AclRevision As Byte
    Sbz1 As Byte
    AclSize As Integer
    AceCount As Integer
    Sbz2 As Integer
End Type

Private Type SECURITY_DESCRIPTOR
    Revision As Byte
    Sbz1 As Byte
    Control As Long
    Owner As Long
    Group As Long
    Sacl As ACL
    Dacl As ACL
End Type


'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' API Declares
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Private Declare Function RegCloseKey Lib "advapi32.dll" ( _
                                     ByVal HKey As Long) As Long

Private Declare Function RegCreateKeyEx Lib "advapi32.dll" Alias "RegCreateKeyExA" ( _
                                        ByVal HKey As Long, _
                                        ByVal lpSubKey As String, _
                                        ByVal Reserved As Long, _
                                        ByVal lpClass As String, _
                                        ByVal dwOptions As Long, _
                                        ByVal samDesired As Long, _
                                        lpSecurityAttributes As SECURITY_ATTRIBUTES, _
                                        phkResult As Long, _
                                        lpdwDisposition As Long) As Long

Private Declare Function RegDeleteKey Lib "advapi32.dll" Alias "RegDeleteKeyA" ( _
                                      ByVal HKey As Long, _
                                      ByVal lpSubKey As String) As Long

Private Declare Function RegOpenKey Lib "advapi32.dll" Alias "RegOpenKeyA" ( _
                                    ByVal HKey As Long, _
                                    ByVal lpSubKey As String, _
                                    phkResult As Long) As Long

Private Declare Function RegDeleteValue Lib "advapi32.dll" Alias "RegDeleteValueA" ( _
                                        ByVal HKey As Long, _
                                        ByVal lpValueName As String) As Long

Private Declare Function RegEnumKey Lib "advapi32.dll" Alias "RegEnumKeyA" ( _
                                    ByVal HKey As Long, _
                                    ByVal dwIndex As Long, _
                                    ByVal lpName As String, _
                                    ByVal cbName As Long) As Long

Private Declare Function RegEnumKeyEx Lib "advapi32.dll" Alias "RegEnumKeyExA" ( _
                                      ByVal HKey As Long, _
                                      ByVal dwIndex As Long, _
                                      ByVal lpName As String, _
                                      lpcbName As Long, _
                                      ByVal lpReserved As Long, _
                                      ByVal lpClass As String, _
                                      lpcbClass As Long, _
                                      lpftLastWriteTime As FILETIME) As Long

Private Declare Function RegEnumValue Lib "advapi32.dll" Alias "RegEnumValueA" ( _
                                      ByVal HKey As Long, _
                                      ByVal dwIndex As Long, _
                                      ByVal lpValueName As String, _
                                      lpcbValueName As Long, _
                                      ByVal lpReserved As Long, _
                                      lpType As Long, _
                                      lpData As Byte, _
                                      lpcbData As Long) As Long

Private Declare Function RegFlushKey Lib "advapi32.dll" ( _
                                     ByVal HKey As Long) As Long

Private Declare Function RegGetKeySecurity Lib "advapi32.dll" ( _
                                           ByVal HKey As Long, _
                                           ByVal SecurityInformation As Long, _
                                           pSecurityDescriptor As SECURITY_DESCRIPTOR, _
                                           lpcbSecurityDescriptor As Long) As Long

Private Declare Function RegQueryInfoKey Lib "advapi32.dll" Alias "RegQueryInfoKeyA" ( _
                                         ByVal HKey As Long, _
                                         ByVal lpClass As String, _
                                         lpcbClass As Long, _
                                         ByVal lpReserved As Long, _
                                         lpcSubKeys As Long, _
                                         lpcbMaxSubKeyLen As Long, _
                                         lpcbMaxClassLen As Long, _
                                         lpcValues As Long, _
                                         lpcbMaxValueNameLen As Long, _
                                         lpcbMaxValueLen As Long, _
                                         lpcbSecurityDescriptor As Long, _
                                         lpftLastWriteTime As FILETIME) As Long

Private Declare Function RegQueryValue Lib "advapi32.dll" Alias "RegQueryValueA" ( _
                                       ByVal HKey As Long, _
                                       ByVal lpSubKey As String, _
                                       ByVal lpValue As String, _
                                       lpcbValue As Long) As Long

Private Declare Function RegQueryValueEx Lib "advapi32.dll" Alias "RegQueryValueExA" ( _
                                         ByVal HKey As Long, _
                                         ByVal lpValueName As String, _
                                         ByVal lpReserved As Long, _
                                         lpType As Long, _
                                         lpData As Any, _
                                         lpcbData As Long) As Long

Private Declare Function RegSetValueEx Lib "advapi32.dll" Alias "RegSetValueExA" ( _
                                       ByVal HKey As Long, _
                                       ByVal lpValueName As String, _
                                       ByVal Reserved As Long, _
                                       ByVal dwType As Long, _
                                       lpData As Any, _
                                       ByVal cbData As Long) As Long

Private Declare Function RegSetValueExStr Lib "advapi32" Alias "RegSetValueExA" ( _
                                          ByVal HKey As Long, _
                                          ByVal lpValueName As String, _
                                          ByVal Reserved As Long, _
                                          ByVal dwType As Long, _
                                          ByVal szData As String, _
                                          ByVal cbData As Long) As Long

Private Declare Function RegSetValueExLong Lib "advapi32" Alias "RegSetValueExA" ( _
                                           ByVal HKey As Long, _
                                           ByVal lpValueName As String, _
                                           ByVal Reserved As Long, _
                                           ByVal dwType As Long, _
                                           szData As Long, _
                                           ByVal cbData As Long) As Long

Private Declare Function RegOpenKeyEx Lib "advapi32" Alias "RegOpenKeyExA" ( _
                                      ByVal HKey As Long, _
                                      ByVal lpSubKey As String, _
                                      ByVal ulOptions As Long, _
                                      ByVal samDesired As Long, _
                                      phkResult As Long) As Long

Private Declare Function RegQueryValueExStr Lib "advapi32" Alias "RegQueryValueExA" ( _
                                            ByVal HKey As Long, _
                                            ByVal lpValueName As String, _
                                            ByVal lpReserved As Long, _
                                            ByRef lpType As Long, _
                                            ByVal szData As String, _
                                            ByRef lpcbData As Long) As Long


'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Application Constants
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Public Type RegValue
    ValueName As String
    ValueValue As Variant
End Type

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Public  Variables
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Public G_Reg_AppErrNum As Long
Public G_Reg_AppErrText As String
Public G_Reg_SysErrNum As Long
Public G_Reg_SysErrText As String



'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Private Variables
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Public Functions
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Public Function RegistryGetValue(BaseKey As Long, KeyName As String, _
                                 ValueName As String) As Variant
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' RegistryGetValue
    ' This funciton gets the value of of the specified ValueName in the
    ' key KeyName in the base key BaseKey. Returns NULL if an error
    ' occurred.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Dim HKey As Long
    Dim Res As Long
    Dim RegDataType As REG_DATA_TYPE
    Dim LenData As Long
    Dim LongData As Long
    Dim StringData As String
    Dim IntArr(0 To 1024) As Integer
    Dim LenStringData As Long

    ResetErrorVariables

    If IsValidBaseKey(BaseKey:=BaseKey) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryGetValue = Null
        Exit Function
    End If

    If IsValidKeyName(KeyName:=KeyName) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryGetValue = Null
        Exit Function
    End If

    If RegistryKeyExists(BaseKey:=BaseKey, KeyName:=KeyName) = False Then
        G_Reg_AppErrNum = C_REG_ERR_KEY_NOT_FOUND
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryGetValue = Null
        Exit Function
    End If

    RegDataType = RegistryGetValueType(BaseKey:=BaseKey, KeyName:=KeyName, ValueName:=ValueName)
    HKey = OpenRegistryKey(BaseKey:=BaseKey, KeyName:=KeyName)
    If HKey = 0 Then
        G_Reg_SysErrNum = Res
        G_Reg_SysErrText = GetSystemErrorMessageText(ErrorNumber:=Res)
        G_Reg_AppErrNum = C_REG_ERR_UNABLE_TO_OPEN_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryGetValue = Null
        Exit Function
    End If


    If RegDataType = REG_DWORD Then
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Data is Long data-type.
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Res = RegQueryValueEx(HKey:=HKey, lpValueName:=ValueName, lpReserved:=0&, _
                              lpType:=RegDataType, lpData:=LongData, lpcbData:=Len(LongData))
        If Res = ERROR_SUCCESS Then
            RegistryGetValue = LongData
            Exit Function
        Else
            G_Reg_SysErrNum = Res
            G_Reg_SysErrText = GetSystemErrorMessageText(ErrorNumber:=Res)
            G_Reg_AppErrNum = C_REG_ERR_UBABLE_TO_READ_VALUE
            G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
            RegCloseKey HKey
            RegistryGetValue = Null
            Exit Function
        End If
    ElseIf RegDataType = REG_SZ Then
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Data is String data-type.
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        StringData = String$(MAX_DATA_BUFFER_SIZE, vbNullChar)
        LenStringData = Len(StringData)
        Res = RegQueryValueExStr(HKey:=HKey, lpValueName:=ValueName, lpReserved:=0&, _
                                 lpType:=RegDataType, szData:=StringData, lpcbData:=LenStringData)
        If Res <> ERROR_SUCCESS Then
            G_Reg_SysErrNum = Res
            G_Reg_SysErrText = GetSystemErrorMessageText(ErrorNumber:=Res)
            G_Reg_AppErrNum = C_REG_ERR_UBABLE_TO_READ_VALUE
            G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
            RegCloseKey HKey
            RegistryGetValue = Null
            Exit Function
        End If
        StringData = TrimToNull(StringData)
        RegistryGetValue = StringData
    Else
        G_Reg_AppErrNum = C_REG_ERR_INVALID_DATA_TYPE
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryGetValue = Null
    End If

End Function

Public Function RegistryKeyExists(BaseKey As Long, KeyName As String, _
                                  Optional CreateIfNotExists As Boolean = False) As Boolean
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' RegistryKeyExists
    ' Returns True or False indicating whether KeyName exists in BaseKey.
    ' Returns False if an error occurred. See the global error values
    ' for more information. If CreateIfNotExists is True and the
    ' key does not exist, it will be created.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Dim HKey As Long
    Dim Res As Long

    ResetErrorVariables
    If IsValidBaseKey(BaseKey:=BaseKey) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryKeyExists = False
    End If

    If IsValidKeyName(KeyName:=KeyName) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryKeyExists = False
    End If

    Res = RegOpenKey(HKey:=BaseKey, lpSubKey:=KeyName, phkResult:=HKey)
    If Res = ERROR_SUCCESS Then
        RegistryKeyExists = True
    Else
        RegistryKeyExists = False
        If CreateIfNotExists = True Then
            Res = RegistryCreateKey(BaseKey:=BaseKey, KeyName:=KeyName)
            RegistryKeyExists = CBool(Res)
        End If
    End If

    RegCloseKey HKey:=HKey

End Function

Public Function RegistryValueExists(BaseKey As Long, KeyName As String, _
                                    ValueName As String, Optional CreateIfNotExists As Boolean = False, _
                                    Optional CreateType As REG_DATA_TYPE = REG_DWORD) As Boolean
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' RegistryValueExists
    ' This returns True or False indicating whether ValueName exists in
    ' KeyName in BaseKey.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


    Dim HKey As Long
    Dim Res As Long

    ResetErrorVariables
    If IsValidBaseKey(BaseKey:=BaseKey) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryValueExists = False
    End If

    If IsValidKeyName(KeyName:=KeyName) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryValueExists = False
    End If

    HKey = OpenRegistryKey(BaseKey:=BaseKey, KeyName:=KeyName)
    If HKey = 0 Then
        G_Reg_AppErrNum = C_REG_ERR_UNABLE_TO_OPEN_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryValueExists = False
    End If

    Res = RegQueryValueEx(HKey:=HKey, lpValueName:=ValueName, lpReserved:=0&, lpType:=0&, lpData:=0&, lpcbData:=0&)
    If (Res = ERROR_SUCCESS) Or (Res = ERROR_MORE_DATA) Then
        RegistryValueExists = True
    Else
        If CreateIfNotExists = True Then
            If CreateType = REG_DWORD Then
                Res = RegistryCreateValue(BaseKey:=BaseKey, KeyName:=KeyName, ValueName:=ValueName, _
                                          ValueValue:=0&, CreateKeyIfNotExists:=True)
            Else
                Res = RegistryCreateValue(BaseKey:=BaseKey, KeyName:=KeyName, ValueName:=ValueName, _
                                          ValueValue:=vbNullString, CreateKeyIfNotExists:=True)
            End If
            If CBool(Res) = True Then
                RegistryValueExists = True
            Else
                RegistryValueExists = False
            End If
        End If
    End If

    RegCloseKey HKey

End Function

Public Function RegistryGetValueType(BaseKey As Long, KeyName As String, ValueName As String) As REG_DATA_TYPE
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' RegistryGetValueType
    ' This returns the data type of value named in ValueName. The procedures in
    ' this module support only Longs and Strings, so the result will be REG_SZ
    ' for a string, REG_DWORD for a Long, or REG_INVALID for any other data type.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Dim Res As Long
    Dim HKey As Long
    Dim DataType As REG_DATA_TYPE

    ResetErrorVariables

    If IsValidBaseKey(BaseKey:=BaseKey) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryGetValueType = False
    End If

    If IsValidKeyName(KeyName:=KeyName) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryGetValueType = False
    End If

    Res = RegOpenKey(HKey:=BaseKey, lpSubKey:=KeyName, phkResult:=HKey)
    If Res <> ERROR_SUCCESS Then
        G_Reg_AppErrNum = C_REG_ERR_UNABLE_TO_OPEN_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryGetValueType = REG_INVALID
        Exit Function
    End If

    Res = RegQueryValueEx(HKey:=HKey, lpValueName:=ValueName, lpReserved:=0&, lpType:=DataType, lpData:=0&, lpcbData:=0&)
    If (Res <> ERROR_SUCCESS) And (Res <> ERROR_MORE_DATA) Then
        G_Reg_AppErrNum = C_REG_ERR_UBABLE_TO_READ_VALUE
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryGetValueType = REG_INVALID
        RegCloseKey HKey
        Exit Function
    End If

    Select Case DataType
        Case REG_SZ
            RegistryGetValueType = REG_SZ
        Case REG_DWORD
            RegistryGetValueType = REG_DWORD
        Case Else
            RegistryGetValueType = REG_INVALID
    End Select

    RegCloseKey HKey

End Function

Public Function RegistryCreateValue(BaseKey As Long, KeyName As String, _
                                    ValueName As String, ValueValue As Variant, _
                                    Optional CreateKeyIfNotExists As Boolean = False) As Boolean
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' RegistryCreateValue
    ' This creates a value named ValueName in KeyName in BaseKey with a value
    ' of ValueValue. If the key named by KeyName does not exist, and
    ' CreateKeyIfNotExist is True, the key will be created. If the value
    ' already exists, its value is set to the new value if they are
    ' compatible data types.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Dim HKey As Long
    Dim Res As Long
    Dim DataType As REG_DATA_TYPE
    Dim StringValue As String
    Dim LongValue As Long

    ResetErrorVariables

    If IsValidBaseKey(BaseKey:=BaseKey) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryCreateValue = False
        Exit Function
    End If

    If IsValidKeyName(KeyName:=KeyName) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryCreateValue = False
        Exit Function
    End If

    If RegistryKeyExists(BaseKey:=BaseKey, KeyName:=KeyName, _
                         CreateIfNotExists:=CreateKeyIfNotExists) = False Then
        G_Reg_AppErrNum = C_REG_ERR_KEY_NOT_FOUND
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryCreateValue = False
        Exit Function
    End If


    If IsCompatibleValueValue(Var:=ValueValue) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_DATA_TYPE
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryCreateValue = False
        Exit Function
    End If

    If RegistryKeyExists(BaseKey:=BaseKey, KeyName:=KeyName, CreateIfNotExists:=False) = False Then
        If CreateKeyIfNotExists = True Then
            If RegistryKeyExists(BaseKey:=BaseKey, KeyName:=KeyName, CreateIfNotExists:=True) = False Then
                G_Reg_AppErrNum = C_REG_ERR_UNABLE_TO_CREATE_KEY
                G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
                RegistryCreateValue = False
                Exit Function
            End If
        Else
            G_Reg_AppErrNum = C_REG_ERR_KEY_NOT_FOUND
            G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
            RegistryCreateValue = False
            Exit Function
        End If
    End If

    If RegistryValueExists(BaseKey:=BaseKey, KeyName:=KeyName, ValueName:=ValueName) = True Then
        DataType = RegistryGetValueType(BaseKey:=BaseKey, KeyName:=KeyName, ValueName:=ValueName)
        If DataType = REG_SZ Then
            If VarType(ValueValue) <> vbString Then
                G_Reg_AppErrNum = C_REG_ERR_DATA_TYPE_MISMATCH
                G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
                RegistryCreateValue = False
                Exit Function
            Else
                '''''''''''''''''''''''''''''
                ' ValueValue is a string. OK.
                '''''''''''''''''''''''''''''
            End If
        Else
            '''''''''''''''''''''''''
            ' ValueValue is numeric
            '''''''''''''''''''''''''
        End If
    Else
        '''''''''''''''''''''''
        ' Value does not exist.
        ' Set the DataType.
        '''''''''''''''''''''''
        If VarType(ValueValue) = vbString Then
            DataType = REG_SZ
        Else
            DataType = REG_DWORD
        End If
    End If

    If DataType = REG_DWORD Then
        LongValue = CLng(ValueValue)
        HKey = OpenRegistryKey(BaseKey:=BaseKey, KeyName:=KeyName)
        If HKey = 0 Then
            G_Reg_SysErrNum = Err.LastDllError
            G_Reg_SysErrText = GetSystemErrorMessageText(ErrorNumber:=G_Reg_SysErrNum)
            G_Reg_AppErrNum = C_REG_ERR_UNABLE_TO_OPEN_KEY
            G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
            RegCloseKey HKey
            RegistryCreateValue = False
            Exit Function
        End If

        Res = RegSetValueExLong(HKey:=HKey, lpValueName:=ValueName, Reserved:=0&, _
                                dwType:=REG_DWORD, szData:=LongValue, cbData:=Len(LongValue))
        If Res <> ERROR_SUCCESS Then
            G_Reg_AppErrNum = C_REG_ERR_UNABLE_TO_UDPATE_VALUE
            G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
            RegCloseKey HKey
            RegistryCreateValue = False
            Exit Function
        End If
    Else
        StringValue = CStr(ValueValue)
        HKey = OpenRegistryKey(BaseKey:=BaseKey, KeyName:=KeyName)
        If HKey = 0 Then
            G_Reg_SysErrNum = Err.LastDllError
            G_Reg_SysErrText = GetSystemErrorMessageText(ErrorNumber:=G_Reg_SysErrNum)
            G_Reg_AppErrNum = C_REG_ERR_UNABLE_TO_OPEN_KEY
            G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
            RegCloseKey HKey
            RegistryCreateValue = False
            Exit Function
        End If
        Res = RegSetValueExStr(HKey:=HKey, lpValueName:=ValueName, Reserved:=0&, _
                               dwType:=REG_SZ, szData:=StringValue, cbData:=Len(StringValue))
        If Res <> ERROR_SUCCESS Then
            G_Reg_AppErrNum = C_REG_ERR_UNABLE_TO_UDPATE_VALUE
            G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
            RegistryCreateValue = False
            RegCloseKey HKey
            Exit Function
        End If
    End If

    RegCloseKey HKey
    RegistryCreateValue = True

End Function

Public Function RegistryCreateKey(BaseKey As Long, KeyName As String) As Boolean
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' RegistryCreateKey
    ' This function creates a Key named KeyName in BaseKey. Returns True if successful
    ' or False if an error occurred.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Dim Res As Long
    Dim HKey As Long
    Dim DataType As REG_DATA_TYPE
    Dim SecAttrib As SECURITY_ATTRIBUTES
    Dim Disposition As Long
    ResetErrorVariables

    If IsValidBaseKey(BaseKey:=BaseKey) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryCreateKey = False
    End If

    If IsValidKeyName(KeyName:=KeyName) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryCreateKey = False
    End If

    If RegistryKeyExists(BaseKey:=BaseKey, KeyName:=KeyName) = True Then
        '''''''''''''''''''''''''''
        ' Key already exist. Return
        ' True as if we created it.
        '''''''''''''''''''''''''''
        RegistryCreateKey = True
        Exit Function
    End If

    Res = RegCreateKeyEx(HKey:=BaseKey, lpSubKey:=KeyName, Reserved:=0&, lpClass:=vbNullString, _
                         dwOptions:=REG_OPTION_NON_VOLATILE, samDesired:=KEY_ALL_ACCESS, _
                         lpSecurityAttributes:=SecAttrib, phkResult:=HKey, lpdwDisposition:=Disposition)
    If Res <> ERROR_SUCCESS Then
        G_Reg_SysErrNum = Res
        G_Reg_SysErrText = GetSystemErrorMessageText(ErrorNumber:=G_Reg_SysErrNum)
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryCreateKey = False
        Exit Function
    End If

    RegistryCreateKey = True

End Function

Public Function RegistryDeleteValue(BaseKey As Long, KeyName As String, ValueName As String) As Boolean
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' RegistryDeleteValue
    ' This deletes a value in KeyName in BaseKey.  Returns True or False indicating
    ' success. The function returns True if the Value does not exist.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim Res As Long
    Dim HKey As Long
    Dim DataType As REG_DATA_TYPE
    Dim SecAttrib As SECURITY_ATTRIBUTES
    Dim Disposition As Long

    ResetErrorVariables

    If IsValidBaseKey(BaseKey:=BaseKey) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryDeleteValue = False
        Exit Function
    End If

    If IsValidKeyName(KeyName:=KeyName) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryDeleteValue = False
        Exit Function
    End If

    If RegistryKeyExists(BaseKey:=BaseKey, KeyName:=KeyName, CreateIfNotExists:=False) = False Then
        G_Reg_AppErrNum = C_REG_ERR_KEY_NOT_FOUND
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryDeleteValue = False
        Exit Function
    End If

    HKey = OpenRegistryKey(BaseKey:=BaseKey, KeyName:=KeyName)
    If HKey = 0 Then
        RegistryDeleteValue = False
        Exit Function
    End If
    If RegistryValueExists(BaseKey:=BaseKey, KeyName:=KeyName, ValueName:=ValueName) = False Then
        RegCloseKey HKey
        RegistryDeleteValue = True
        Exit Function
    End If

    Res = RegDeleteValue(HKey:=HKey, lpValueName:=ValueName)
    If Res <> ERROR_SUCCESS Then
        G_Reg_SysErrNum = Res
        G_Reg_SysErrText = GetSystemErrorMessageText(ErrorNumber:=Res)
        G_Reg_AppErrNum = C_REG_ERR_UNABLE_TO_DELETE_VALUE
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegCloseKey HKey
        RegistryDeleteValue = False
        Exit Function
    End If

    RegCloseKey HKey
    RegistryDeleteValue = True

End Function

Public Function RegistryDeleteKey(BaseKey As Long, KeyName As String) As Boolean
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' RegistryDeleteKey
    ' This delete the registry key named in KeyName in BaseKey. All subkeys and
    ' values are deleted. Returns True or False indicating success. Returns
    ' True if the key does not exist.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Dim Res As Long
    Dim HKey As Long
    Dim DataType As REG_DATA_TYPE
    Dim SecAttrib As SECURITY_ATTRIBUTES
    Dim Disposition As Long

    ResetErrorVariables

    If IsValidBaseKey(BaseKey:=BaseKey) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryDeleteKey = False
        Exit Function
    End If

    If IsValidKeyName(KeyName:=KeyName) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryDeleteKey = False
        Exit Function
    End If

    If RegistryKeyExists(BaseKey:=BaseKey, KeyName:=KeyName, CreateIfNotExists:=False) = False Then
        RegistryDeleteKey = True
        Exit Function
    End If

    HKey = OpenRegistryKey(BaseKey:=BaseKey, KeyName:=KeyName)
    If HKey = 0 Then
        RegistryDeleteKey = False
        Exit Function
    End If

    Res = RegDeleteKey(HKey:=BaseKey, lpSubKey:=KeyName)
    RegCloseKey HKey
    If Res <> ERROR_SUCCESS Then
        G_Reg_SysErrNum = Res
        G_Reg_SysErrText = GetSystemErrorMessageText(Res)
        G_Reg_AppErrNum = C_REG_ERR_UNABLE_TO_DELETE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryDeleteKey = False
        Exit Function
    End If

    RegistryDeleteKey = True

End Function

Public Function RegistryUpdateValue(BaseKey As Long, KeyName As String, _
                                    ValueName As String, NewValue As Variant, Optional CreateIfNotExists As Boolean = True) As Boolean
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' RegistryUpdateValue
    ' This updates the value of a key. It calls RegistryDeleteValue to delete the
    ' value and the RegistryCreateValue to re-create the value. Returns True or
    ' False indicating success.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Dim Res As Boolean
    Dim HKey As Long

    ResetErrorVariables

    If IsValidBaseKey(BaseKey:=BaseKey) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryUpdateValue = False
        Exit Function
    End If

    If IsValidKeyName(KeyName:=KeyName) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryUpdateValue = False
        Exit Function
    End If

    If IsCompatibleValueValue(Var:=NewValue) = False Then
        G_Reg_AppErrNum = C_REG_ERR_INVALID_DATA_TYPE
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryUpdateValue = False
        Exit Function
    End If


    Res = RegistryKeyExists(BaseKey:=BaseKey, KeyName:=KeyName, CreateIfNotExists:=True)
    If Res = False Then
        G_Reg_AppErrNum = C_REG_ERR_KEY_NOT_FOUND
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryUpdateValue = False
        Exit Function
    End If

    If VarType(NewValue) = vbString Then
        Res = RegistryValueExists(BaseKey:=BaseKey, KeyName:=KeyName, ValueName:=ValueName, _
                                  CreateIfNotExists:=CreateIfNotExists, CreateType:=REG_DWORD)
    Else
        Res = RegistryValueExists(BaseKey:=BaseKey, KeyName:=KeyName, ValueName:=ValueName, _
                                  CreateIfNotExists:=CreateIfNotExists, CreateType:=REG_SZ)
    End If

    If Res = False Then
        G_Reg_AppErrNum = C_REG_ERR_VALUE_NOT_FOUND
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        RegistryUpdateValue = False
        Exit Function
    End If


    Res = RegistryDeleteValue(BaseKey:=BaseKey, KeyName:=KeyName, ValueName:=ValueName)
    Res = RegistryCreateValue(BaseKey:=BaseKey, KeyName:=KeyName, ValueName:=ValueName, ValueValue:=NewValue, CreateKeyIfNotExists:=True)

    RegistryUpdateValue = Res


End Function


'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Private Functions
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Private Function OpenRegistryKey(BaseKey As Long, KeyName As String) As Long
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' OpenRegistryKey
    ' This opens the KeyName in BaseKey and returns the key handle
    ' if successful or 0 if an error occurred.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim Res As Long
    Dim HKey As Long

    ResetErrorVariables
    If IsValidBaseKey(BaseKey) = False Then
        ''''''''''''''''''''''''''''''''''''''
        ' Invalid Base Key. Return 0 and
        ' get out.
        ''''''''''''''''''''''''''''''''''''''
        OpenRegistryKey = 0
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        Exit Function
    End If

    Res = RegOpenKeyEx(HKey:=BaseKey, lpSubKey:=KeyName, ulOptions:=0&, samDesired:=KEY_ALL_ACCESS, phkResult:=HKey)
    If Res <> ERROR_SUCCESS Then
        OpenRegistryKey = 0
        G_Reg_SysErrNum = Res
        G_Reg_SysErrText = GetSystemErrorMessageText(ErrorNumber:=Res)
        G_Reg_AppErrNum = C_REG_ERR_INVALID_BASE_KEY
        G_Reg_AppErrText = GetAppErrText(G_Reg_AppErrNum)
        Exit Function
    End If

    OpenRegistryKey = HKey


End Function



Private Function TrimToNull(Text As String, _
                            Optional Reverse As Boolean = False) As String
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TrimToNull
    ' If Reverse is omitted or False, the function returns the
    ' portion of Text that is to the left of the first vbNullChar
    ' character. The vbNullChar is not returned. If Reverse is
    ' True, the function returns the portion to the left of the
    ' last vbNullChar. The vbNullChar is not returned. In either
    ' case, if vbNullChar is not found, the entire string Text
    ' is returned.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim Pos As Long
    If Reverse = False Then
        Pos = InStr(1, Text, vbNullChar, vbTextCompare)
    Else
        Pos = InStrRev(Text, vbNullChar, -1, vbTextCompare)
    End If
    If Pos Then
        TrimToNull = Left(Text, Pos - 1)
    Else
        TrimToNull = Text
    End If

End Function

Private Function TrimToChar(Text As String, Char As String, _
                            Optional ByVal Reverse As Boolean = False, _
                            Optional ByVal CompareMode As VbCompareMethod) As String
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' If Reverse is False, the function returns the portion of
    ' Text that is to the left of the first occurrence of Char.
    ' If Reverse is True, the function returns the portion of
    ' Text that is to the left of the last occurrence of Char.
    ' If Char is not found, the entire string Text is returned.
    ' If CompareMode is vbBinaryCompare, text is compared in
    ' a CASE-SENSITIVE manner ("A"<>"a"). If CompareMode is any
    ' other value, text is compared in CASE-INSENSITIVE mode ("A" = "a").
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim Pos As Long

    If CompareMode <> vbBinaryCompare Then
        CompareMode = vbTextCompare
    End If

    If Reverse = False Then
        Pos = InStr(1, Text, Char, CompareMode)
    Else
        Pos = InStrRev(Text, Char, -1, CompareMode)
    End If

    If Pos Then
        TrimToChar = Left(Text, Pos - 1)
    Else
        TrimToChar = Text
    End If


End Function


Private Function IsValidBaseKey(BaseKey As Long) As Boolean
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' IsValidBaseKey
    ' This returns True of BaseKey is valid base key
    ' (HKEY_CURRENT_USER etc) or False if BaseKey is not
    ' a valid base key.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Select Case BaseKey
        Case HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE, _
             HKEY_CLASSES_ROOT, HKEY_CURRENT_CONFIG, HKEY_DYN_DATA, _
             HKEY_PERFORMANCE_DATA, HKEY_USERS
            IsValidBaseKey = True
        Case Else
            IsValidBaseKey = False
    End Select

End Function

Private Sub ResetErrorVariables()
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' ResetErrorVariables
    ' This resets the global error values to their default
    ' (no error) values.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    G_Reg_AppErrNum = C_REG_ERR_NO_ERROR
    G_Reg_AppErrText = vbNullString
    G_Reg_SysErrNum = C_REG_ERR_NO_ERROR
    G_Reg_SysErrText = vbNullString
End Sub

Private Function GetAppErrText(ErrNum As Long) As String
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' GetAppErrText
    ' This returns the text description of the application error
    ' number in ErrNum.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Select Case ErrNum
        Case C_REG_ERR_NO_ERROR
            GetAppErrText = vbNullString
        Case C_REG_ERR_INVALID_BASE_KEY
            GetAppErrText = "Invalid Base Key Value."
        Case C_REG_ERR_INVALID_DATA_TYPE
            GetAppErrText = "Invalid Data Type."
        Case C_REG_ERR_KEY_NOT_FOUND
            GetAppErrText = "Key Not Found."
        Case C_REG_ERR_VALUE_NOT_FOUND
            GetAppErrText = "Value Not Found."
        Case C_REG_ERR_DATA_TYPE_MISMATCH
            GetAppErrText = "Value Data Type Mismatch."
        Case C_REG_ERR_ENTRY_LOCKED
            GetAppErrText = "Registry Entry Locked."
        Case C_REG_ERR_INVALID_KEYNAME
            GetAppErrText = "The Specified Key Is Invalid."
        Case C_REG_ERR_UNABLE_TO_OPEN_KEY
            GetAppErrText = "Unable To Open Key."
        Case C_REG_ERR_UNABLE_TO_READ_KEY
            GetAppErrText = "Unable To Read Key."
        Case C_REG_ERR_UNABLE_TO_CREATE_KEY
            GetAppErrText = "Unable To Create Key."
        Case C_REG_ERR_UBABLE_TO_READ_VALUE
            GetAppErrText = "Unable To Read Value."
        Case C_REG_ERR_UNABLE_TO_UDPATE_VALUE
            GetAppErrText = "Unable To Update Value."
        Case C_REG_ERR_UNABLE_TO_CREATE_VALUE
            GetAppErrText = "Unable To Create Value."
        Case C_REG_ERR_UNABLE_TO_DELETE_KEY
            GetAppErrText = "Unable To Delete Key."
        Case C_REG_ERR_UNABLE_TO_DELETE_VALUE
            GetAppErrText = "Unable To Delete Value."




        Case Else
            GetAppErrText = "Undefined Error."
    End Select







End Function

Private Function IsStringValidLength(Text As String) As Boolean
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' IsStringValidLength
    ' This tests whether the length of Text is less than
    ' REGSTR_MAX_VALUE_LENGTH.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    IsStringValidLength = (Len(Text) <= REGSTR_MAX_VALUE_LENGTH)

End Function

Private Function IsValidKeyName(KeyName As String) As Boolean
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' IsValidKeyName
    ' Returns True or False indicating whether KeyName is valid.
    ' An invalid key is one whose name length is greater than
    ' REGSTR_MAX_VALUE_LENGTH or is all spaces or is an empty string.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    IsValidKeyName = (Len(KeyName) <= REGSTR_MAX_VALUE_LENGTH) And (Len(Trim(KeyName)) > 0)
End Function


Private Function IsValidDataType(DataType As REG_DATA_TYPE) As Boolean
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' IsValidDataType
    ' This returns True or False indicating whether DataType is
    ' a valid data type (REG_SZ or REG_DWORD).
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Select Case DataType
        Case REG_SZ, REG_DWORD
            IsValidDataType = True
        Case Else
            IsValidDataType = False
    End Select

End Function

Private Function IsCompatibleValueValue(Var As Variant) As Boolean
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' IsCompatibleValueValue
    ' This test the VarType of Var to see if it is valid to be used
    ' as a registry key value. Note that all numeric data types (Singles,
    ' Doubles, etc) are considered value, even though their values will
    ' be changed when converted to longs.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    If VarType(Var) >= vbArray Then
        IsCompatibleValueValue = False
        Exit Function
    End If
    If IsArray(Var) = True Then
        IsCompatibleValueValue = False
        Exit Function
    End If
    If IsObject(Var) = True Then
        IsCompatibleValueValue = False
        Exit Function
    End If

    Select Case VarType(Var)
        Case vbBoolean, vbByte, vbCurrency, vbDate, vbDouble, vbInteger, vbLong, vbSingle, vbString
            IsCompatibleValueValue = True
        Case Else
            IsCompatibleValueValue = False
    End Select

End Function

