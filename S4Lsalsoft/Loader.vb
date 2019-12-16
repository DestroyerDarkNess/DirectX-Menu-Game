Imports S4Lsalsoft.Cheat.Values
Imports System.IO

Public Class Loader


    Private Sub Loader_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim p As Process()
        p = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(ProcessGame))
        If p.Count = 1 Then
            Label3.Text = "Status : " & vbNewLine & vbNewLine & "Counter Strike 1.6 Detected, starting hack . . ."
            Timer1.Stop()
            Form1.Show()
            Me.Hide()
            Form1.Hide()
            Timer1.Enabled = False
        End If
    End Sub


End Class
