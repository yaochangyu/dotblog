VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} frmAddin 
   Caption         =   "UserForm1"
   ClientHeight    =   1635
   ClientLeft      =   45
   ClientTop       =   390
   ClientWidth     =   4335
   OleObjectBlob   =   "frmAddin.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "frmAddin"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private m_Addin As Excel.addin
Private m_IsAddinExist As Boolean
Const ADDIN_FILENAME As String = "MyApp(Add-In).xla"

Dim m_SourceAddinFilePath As String
Dim m_TargetAddinFilePath As String

Private Sub UserForm_Initialize()
    Me.Caption = "SimpleAddinManager"
    Me.AddinEnable_CheckBox.Visible = False
    Me.AddinUninstall_Button.Enabled = False
    Me.AddinInstall_Button.Enabled = False

    m_SourceAddinFilePath = ActiveWorkbook.Path & "\" & ADDIN_FILENAME
    m_TargetAddinFilePath = Application.UserLibraryPath & ADDIN_FILENAME
    Set m_Addin = FindAddin(ADDIN_FILENAME)
    Call SetControlForAddin(m_Addin)
End Sub

Private Function SetControlForAddin(addin As Excel.addin) As String
    Dim msg As String
    Dim isFileExist As Boolean
    If Dir(m_TargetAddinFilePath) <> vbNullString Then isFileExist = True

    If Not isFileExist Then
        msg = "�W�q��: " & ADDIN_FILENAME & vbCrLf & "���w��"
        Me.AddinInstall_Button.Enabled = True
        Me.AddinUninstall_Button.Enabled = False
    ElseIf isFileExist And addin Is Nothing Then
        msg = "�W�q��: " & ADDIN_FILENAME & vbCrLf & "���w��"
        Me.AddinInstall_Button.Enabled = True
        Me.AddinUninstall_Button.Enabled = False
    ElseIf isFileExist And Not addin Is Nothing Then
        If addin.Installed Then
            msg = "�W�q��: " & ADDIN_FILENAME & vbCrLf & "�w�w�˨ñҥ�"
        Else
            msg = "�W�q��: " & ADDIN_FILENAME & vbCrLf & "�w�w�˥��ҥ�"
        End If

        Me.AddinInstall_Button.Enabled = False
        Me.AddinUninstall_Button.Enabled = True
    End If

    SetControlForAddin = msg
    Me.AddinStatus_Label.Caption = msg

End Function

Private Sub AddinInstall_Button_Click()
    If Dir(m_TargetAddinFilePath) <> vbNullString Then Exit Sub

    Dim fso As New FileSystemObject
    Call fso.CopyFile(m_SourceAddinFilePath, m_TargetAddinFilePath, True)

    Set m_Addin = Application.AddIns.Add(m_TargetAddinFilePath, True)
    m_Addin.Installed = True

    Call SetControlForAddin(m_Addin)
End Sub

Function IsAddinExists(addinName As String) As Boolean
    Dim element As Excel.addin
    For Each element In Application.AddIns
        If element.Name = addinName Then
            IsAddinExists = True
            Exit Function
        End If
    Next
    IsAddinExists = False
End Function

Private Function FindAddin(addinName As String) As Excel.addin
    For Each FindAddin In Application.AddIns
        If FindAddin.Name = addinName Then
            Exit Function
        End If
    Next
    Set FindAddin = Nothing
End Function

Private Sub AddinUninstall_Button_Click()
    If Dir(m_TargetAddinFilePath) = vbNullString Then Exit Sub

    m_Addin.Installed = False

    Dim fso As New FileSystemObject

    If Dir(m_TargetAddinFilePath) <> "" Then fso.DeleteFile m_TargetAddinFilePath
    Set m_Addin = Nothing
    Call SetControlForAddin(m_Addin)

    MsgBox "Excel �n���������~��ͮ�,�Y�N�������{��", vbCritical, "�����q��"
    Unload Me
End Sub

Private Sub UserForm_Terminate()
    'm_CurrentWorkbook.Close
End Sub
