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
Const EXPORT_SOURCE_CODE_PATH As String = "sources"
Private Sub Workbook_Open()
    'ImportCodeModules
End Sub
Private Sub Workbook_BeforeSave(ByVal SaveAsUI As Boolean, Cancel As Boolean)
    SaveCodeModules
End Sub
Private Sub SaveCodeModules()
    Dim outputFolderPath As String, outpitFilePath As String

    outputFolderPath = ThisWorkbook.Path & "\" & EXPORT_SOURCE_CODE_PATH & "\"
    If Dir(outputFolderPath, vbDirectory) = vbNullString Then Exit Sub

    Dim element As VBIDE.VBComponent
    For Each element In ThisWorkbook.VBProject.VBComponents
        Dim componentName As String
        componentName = element.Name

        Select Case element.Type
            Case vbext_ct_StdModule
                outpitFilePath = outputFolderPath & componentName & ".bas"

            Case vbext_ct_ClassModule
                outpitFilePath = outputFolderPath & componentName & ".cls"

            Case vbext_ct_MSForm
                outpitFilePath = outputFolderPath & componentName & ".frm"

            Case vbext_ct_Document
                outpitFilePath = outputFolderPath & componentName & ".vba"
        End Select

        '程式碼行數大於1行再匯出
        If element.CodeModule.CountOfLines > 1 Then Call element.Export(outpitFilePath)
    Next element
End Sub

Private Sub ImportCodeModules()
    Dim currentProject As VBIDE.VBProject
    Dim element As VBIDE.VBComponent
    Dim vbaCodeModule As VBIDE.CodeModule

    Dim importFolderPath As String

    Set currentProject = ThisWorkbook.VBProject
    'Set currentProject = ActiveWorkbook.VBProject
    'Set currentProject = Application.VBE.ActiveVBProject
    'Application.VBE.ActiveVBProject.VBComponents
Debug.Print "匯入：" & vbCrLf & "專案名稱:" & currentProject.Name & vbCrLf & "檔案名稱" & currentProject.Filename & vbCrLf

    importFolderPath = ThisWorkbook.Path & "\" & EXPORT_SOURCE_CODE_PATH & "\"
    If Dir(importFolderPath, vbDirectory) = "" Then Exit Sub

    For Each element In currentProject.VBComponents
        Dim componentName As String
        Dim importPathName As String
        Dim isFileExist As Boolean

        componentName = element.Name
        Set vbaCodeModule = element.CodeModule

        Select Case element.Type
            Case vbext_ct_StdModule
                importPathName = importFolderPath & componentName & ".bas"
                If Dir(importPathName) = vbNullString Then GoTo EndLoop    'continue
                Call currentProject.VBComponents.Remove(element)
                Call currentProject.VBComponents.Import(importPathName)

            Case vbext_ct_ClassModule
                importPathName = importFolderPath & componentName & ".cls"
                If Dir(importPathName) = vbNullString Then GoTo EndLoop    'continue
                Call currentProject.VBComponents.Remove(element)
                Call currentProject.VBComponents.Import(importPathName)


            Case vbext_ct_MSForm
                importPathName = importFolderPath & componentName & ".frm"
                If Dir(importPathName) = vbNullString Then GoTo EndLoop    'continue
                Call currentProject.VBComponents.Remove(element)
                Call currentProject.VBComponents.Import(importPathName)

            Case vbext_ct_Document
                '匯入Sheet程式碼，
                'VBComponents.Import 會將Sheet程式碼轉成cls型態，所以必須要自行處理

                importPathName = importFolderPath & componentName & ".vba"
                If componentName = "ThisWorkbook" Then GoTo EndLoop     'continue
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

                Call vbaCodeModule.DeleteLines(1, vbaCodeModule.CountOfLines)
                Call vbaCodeModule.InsertLines(vbaCodeModule.CountOfLines + 1, importSourceCode)

        End Select
EndLoop:
    Next element
End Sub


