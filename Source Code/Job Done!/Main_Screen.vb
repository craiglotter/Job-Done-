Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Threading
Imports System.ComponentModel

Public Class Main_Screen

    Dim messages As ArrayList
    Dim currentindex As Integer

    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            If ex.Message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message()
                Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.Message.ToString

                Display_Message1.Timer1.Interval = 1000
                Display_Message1.ShowDialog()
                Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
                If dir.Exists = False Then
                    dir.Create()
                End If
                dir = Nothing
                Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
                filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & identifier_msg & ":" & ex.ToString)
                filewriter.Flush()
                filewriter.Close()
                filewriter = Nothing
            End If
            ex = Nothing
            identifier_msg = Nothing
        Catch exc As Exception
            MsgBox("An error occurred in the application's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub




    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Control.CheckForIllegalCrossThreadCalls = False
            Me.Text = "Job Done! " & My.Application.Info.Version.Major & Format(My.Application.Info.Version.Minor, "00") & Format(My.Application.Info.Version.Build, "00") & "." & My.Application.Info.Version.Revision
            currentindex = 0
            messages = New ArrayList()
            messages.Add("Hi " & vbCrLf & vbCrLf & "I've updated the site. Let me know if you need anything else done." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "All done. If you need something else done, just let me know." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "I've uploaded everything to the site. Let me know if there is anything else that needs to be done." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "I've posted everything to the site. If there is something else that needs to be changed, let me know." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "I've made the changes to the site. Let me know is there is anything else that needs to be done." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "I've posted the file to the site." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "I've updated the site." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "I've made the change to the site." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "All done." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "Everything has been updated now." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "The site should be all updated now." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "The files have all been uploaded." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "The file has been uploaded." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "I've made the changes and informed the students." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
            messages.Add("Hi " & vbCrLf & vbCrLf & "The site has been updated and the students have been informed." & vbCrLf & vbCrLf & "Regards," & vbCrLf & "Craig")
        Catch ex As Exception
            Error_Handler(ex, "Application Load")
        End Try

    End Sub




    Private Sub RichTextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.Click
        RichTextBox1.Clear()
        RichTextBox1.Text = messages.Item(currentindex)
        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText(RichTextBox1.Text, TextDataFormat.Text)
        currentindex = currentindex + 1
        If currentindex = messages.Count Then currentindex = 0
    End Sub
End Class
