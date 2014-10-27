VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ThisWorkbook"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = True
Option Explicit
Private m_AddinInstalled As Boolean
Const EXPORT_SOURCE_CODE_PATH As String = "sources"

Private Sub Workbook_AddinInstall()
    m_AddinInstalled = True
    MsgBox "增益集:" & ThisWorkbook.Name & "安裝成功"
End Sub

Private Sub Workbook_AddinUninstall()
    m_AddinInstalled = False
    MsgBox "增益集:" & ThisWorkbook.Name & "解除成功"
End Sub

Private Sub Workbook_Open()
    If Not m_AddinInstalled Then Call frmAddin.Show
    'ImportCodeModules
End Sub

Private Sub Workbook_BeforeSave(ByVal SaveAsUI As Boolean, Cancel As Boolean)
    SaveCodeModules
End Sub

Private Sub SaveCodeModules()

    Dim currentProject As VBIDE.VBProject
    Dim outputFolderPath As String, outpitFilePath As String

    Set currentProject = ThisWorkbook.VBProject
    Dim element As VBIDE.VBComponent
Debug.Print "匯出：" & vbCrLf & "專案名稱:" & currentProject.Name & vbCrLf & "檔案名稱" & currentProject.Filename & vbCrLf

    outputFolderPath = ThisWorkbook.Path & "\" & EXPORT_SOURCE_CODE_PATH & "\"
    If Dir(outputFolderPath, vbDirectory) = "" Then Exit Sub

    For Each element In currentProject.VBComponents
        Dim vbaComponentName As String
        vbaComponentName = element.Name

        Select Case element.Type
            Case vbext_ct_StdModule
                outpitFilePath = outputFolderPath & vbaComponentName & ".bas"

            Case vbext_ct_ClassModule
                outpitFilePath = outputFolderPath & vbaComponentName & ".cls"

            Case vbext_ct_MSForm
                outpitFilePath = outputFolderPath & vbaComponentName & ".frm"

            Case vbext_ct_Document
                outpitFilePath = outputFolderPath & vbaComponentName & ".vba"

                '                Dim sourceCode As String, sourceCodes() As String
                '                Dim file2Write As Integer
                '
                '                With element.CodeModule
                '                    sourceCode = .Lines(1, .CountOfLines)
                '                    sourceCodes = Split(sourceCode, vbCrLf)
                '                End With
                '
                '                Open outpitFilePath For Output As #1
                '                Write #1, CStr(sourceCode)
                '
                '                Close #1
        End Select

        If element.CodeModule.CountOfLines > 1 Then Call element.Export(outpitFilePath)
    Next element
End Sub

Private Sub ImportCodeModules()
    Dim currentProject As VBIDE.VBProject
    Dim elementComponent As VBIDE.VBComponent
    Dim elementCodeModule As VBIDE.CodeModule

    Dim importFolderPath As String

    Set currentProject = ThisWorkbook.VBProject
    'Set currentProject = ActiveWorkbook.VBProject
    'Set currentProject = Application.VBE.ActiveVBProject
    'Application.VBE.ActiveVBProject.VBComponents
Debug.Print "匯入：" & vbCrLf & "專案名稱:" & currentProject.Name & vbCrLf & "檔案名稱" & currentProject.Filename & vbCrLf

    importFolderPath = ThisWorkbook.Path & "\" & EXPORT_SOURCE_CODE_PATH & "\"
    If Dir(importFolderPath, vbDirectory) = "" Then Exit Sub

    For Each elementComponent In currentProject.VBComponents
        Dim elementComponentName As String
        Dim importPathName As String
        Dim isFileExist As Boolean

        elementComponentName = elementComponent.Name
        Set elementCodeModule = elementComponent.CodeModule

        Select Case elementComponent.Type
            Case vbext_ct_StdModule
                importPathName = importFolderPath & elementComponentName & ".bas"
                If Dir(importPathName) = vbNullString Then GoTo EndLoop    'continue
                Call currentProject.VBComponents.Remove(elementComponent)
                Call currentProject.VBComponents.Import(importPathName)

            Case vbext_ct_ClassModule
                importPathName = importFolderPath & elementComponentName & ".cls"
                If Dir(importPathName) = vbNullString Then GoTo EndLoop    'continue
                Call currentProject.VBComponents.Remove(elementComponent)
                Call currentProject.VBComponents.Import(importPathName)


            Case vbext_ct_MSForm
                importPathName = importFolderPath & elementComponentName & ".frm"
                If Dir(importPathName) = vbNullString Then GoTo EndLoop    'continue
                Call currentProject.VBComponents.Remove(elementComponent)
                Call currentProject.VBComponents.Import(importPathName)

            Case vbext_ct_Document
                '匯入Sheet程式碼，
                'VBComponents.Import 會將Sheet程式碼轉成cls型態，所以必須要自行處理

                importPathName = importFolderPath & elementComponentName & ".vba"
                If elementComponentName = "ThisWorkbook" Then GoTo EndLoop     'continue
                If Dir(importPathName) = vbNullString Then GoTo EndLoop    'continue

                Dim importComponent As VBIDE.VBComponent
                Dim importCodeModule As VBIDE.CodeModule
                Dim importSourceCode As String

                Set importComponent = currentProject.VBComponents.Import(importPathName)
                Set importCodeModule = importComponent.CodeModule

                If importCodeModule.CountOfLines <= 0 Then GoTo EndLoop    'contiune

                importSourceCode = importCodeModule.Lines(1, importCodeModule.CountOfLines)
                Call currentProject.VBComponents.Remove(importComponent)

                If importSourceCode = vbNullString Then GoTo EndLoop  'continue

                Call elementCodeModule.DeleteLines(1, elementCodeModule.CountOfLines)
                Call elementCodeModule.InsertLines(elementCodeModule.CountOfLines + 1, importSourceCode)

        End Select
EndLoop:
    Next elementComponent
End Sub


