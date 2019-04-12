Imports System.Runtime.InteropServices
Imports System.IO
Imports D3dmenuVB.DX9OverlayAPI
Imports System.Environment

Public Class Form1

    Public VisibleMenu As Boolean = False
    Public Proseso As String = "GAME.exe" 'Include the .exe
    Public TempImage As String = Path.GetTempPath() & "Dxgui.png"
    Public Title As Integer
    '/////////////////////integers/////////////////////
    Shared Label1I As Integer
    Shared Label2I As Integer
    Shared Label3I As Integer
    Shared Label4I As Integer
    Public imagenGui As Integer
    '/////////////////////Labels Identy/////////////////////
    Public Label1 As Boolean = False
    Public Label2 As Boolean = False
    Public Label3 As Boolean = False
    Public Label4 As Boolean = False
    '/////////////////////Labels string/////////////////////
    Public Label1T As String = "Hack 1"
    Public Label2T As String = "Hack 2"
    Public Label3T As String = False
    Public Label4T As String = False
    '/////////////////////Locations Labels/////////////////////
    Public Label1X As Integer = 30
    Public Label1Y As Integer = 50
    '--------------------------------------
    Public Label2X As Integer = 30
    Public Label2Y As Integer = 100
    '--------------------------------------
    Public Label3X As Integer = 200
    Public Label3Y As Integer = 50
    '--------------------------------------
    Public Label4X As Integer = 200
    Public Label4Y As Integer = 100
    '--------------------------------------

    <DllImport("user32.dll")> _
    Shared Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        DX9Overlay.DestroyAllVisual()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlatLabel1.Text = "Waiting For Game..."
        PictureBox1.Image = My.Resources.bar
        PictureBox2.Image = My.Resources.rotate_pulsating_loading_animation
    End Sub

#Region "subs"

    Private Sub GuisImagen(ByVal directory As String, ByVal posX As Integer, ByVal posY As Integer, Optional ByVal destroy As Boolean = False)
        DX9Overlay.SetParam("process", Proseso)
        imagenGui = DX9Overlay.ImageCreate(directory, posX, posY, 0, 0, True)
    End Sub

#End Region


#Region "FuncsCreate"

    Private Function colorFormat(ByVal c As Color) As Integer
        Return c.ToArgb
    End Function

    Private Function CreateFormGui(ByVal SuperiorBar As Integer, ByVal Scolor As Brush, ByVal Container As Integer, ByVal Ccolor As Brush, ByVal x As Integer, ByVal y As Integer) As String
        Dim flag As New Bitmap(x, y)
        Dim flagGraphics As Graphics = Graphics.FromImage(flag)
        Dim red As Integer = 0
        Dim white As Integer = 20
        flagGraphics.FillRectangle(Scolor, 0, red, 800, SuperiorBar)
        flagGraphics.FillRectangle(Ccolor, 0, white, 800, Container)
        Dim SaveImage As New Bitmap(flag)
        SaveImage.Save(TempImage, Imaging.ImageFormat.Png)
        SaveImage.Dispose()
        Return TempImage
    End Function


#End Region

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
       '******************Show/Hide Menue***********************
        If GetAsyncKeyState(Keys.Insert) = -32767 Then
            If VisibleMenu = False Then
                VisibleMenu = True
                ShowMenu()
                Timer4.Enabled = True
                Exit Sub
            End If
            If VisibleMenu = True Then
                VisibleMenu = False
                Timer4.Enabled = False
                DX9Overlay.DestroyAllVisual()
                Exit Sub
            End If
        End If

        '********************close menue process*********************
        If GetAsyncKeyState(Keys.Delete) = -32767 Then
            Application.Exit()
            Exit Sub
        End If

    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        If GetAsyncKeyState(Keys.F1) = -32767 Then
            If Label1 = False Then
                Label1 = True
                Label1I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label1X, Label1Y, colorFormat(Color.White), Label1T, True, True)
                Label3 = True
                DX9Overlay.TextDestroy(Label3I)
                Label3I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label3X, Label3Y, colorFormat(Color.Lime), "[ON]", True, True)
                Exit Sub
            Else
                Label1 = False
                Label1I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label1X, Label1Y, colorFormat(Color.White), Label1T, True, True)
                Label3 = False
                DX9Overlay.TextDestroy(Label3I)
                Label3I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label3X, Label1Y, colorFormat(Color.Red), "[OFF]", True, True)
                Exit Sub
            End If

        End If

        If GetAsyncKeyState(Keys.F2) = -32767 Then
            If Label2 = False Then
                Label2 = True
                Label2I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label2X, Label2Y, colorFormat(Color.White), Label2T, True, True)
                Label4 = True
                DX9Overlay.TextDestroy(Label4I)
                Label4I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label4X, Label4Y, colorFormat(Color.Lime), "[ON]", True, True)
                Exit Sub
            Else
                Label2 = False
                Label2I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label2X, Label2Y, colorFormat(Color.White), Label2T, True, True)
                Label4 = False
                DX9Overlay.TextDestroy(Label4I)
                Label4I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label4X, Label4Y, colorFormat(Color.Red), "[OFF]", True, True)
                Exit Sub
            End If

        End If
    End Sub

    Private Sub ShowMenu()
        Dim Gui As String = CreateFormGui(500, Brushes.DodgerBlue, 500, Brushes.Gray, 200, 200)
        GuisImagen(Gui, 5, 5)
        Title = DX9Overlay.TextCreateUnicode("Arial", 10, False, False, 10, 8, colorFormat(Color.Lime), "Real D3D Menu", True, True)

        If Label1 = False Then
            Label1I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label1X, Label1Y, colorFormat(Color.White), Label1T, True, True)
            ' DX9Overlay.TextDestroy(Label3I)
            Label3I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label3X, Label3Y, colorFormat(Color.Red), "[OFF]", True, True)
        Else
            Label1I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label1X, Label1Y, colorFormat(Color.White), Label1T, True, True)
            ' DX9Overlay.TextDestroy(Label3I)
            Label3I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label3X, Label3Y, colorFormat(Color.Lime), "[ON]", True, True)
        End If

        If Label2 = False Then
            Label2I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label2X, Label2Y, colorFormat(Color.White), Label2T, True, True)
            Label4I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label4X, Label4Y, colorFormat(Color.Red), "[OFF]", True, True)
        Else
            Label2I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label2X, Label2Y, colorFormat(Color.White), Label2T, True, True)
            Label4I = DX9Overlay.TextCreateUnicode("Arial", 14, False, False, Label4X, Label4Y, colorFormat(Color.Lime), "[ON]", True, True)
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If win7 = True Then
            'hack con adress de windows 7

            If Label1 = True Then
                'hack 1 , con los adress de windows 7
            End If

            If Label2 = True Then
                'hack 2 , con los adress de windows 7
            End If

        End If


        If win8 = True Then
            'hack con adress de windows 8/10

            If Label1 = True Then
                'hack 1 , con los adress de windows 8
            End If

            If Label2 = True Then
                'hack 2 , con los adress de windows 8
            End If

        End If

        If win10 = True Then
            'hack con adress de windows 10 Pro

            If Label1 = True Then
                'hack 1 , con los adress de windows 10 Pro
            End If

            If Label2 = True Then
                'hack 2 , con los adress de windows 10 Pro
            End If

        End If

    End Sub

#Region "WinAutoDetect"

    Public win7 As Boolean = False
    Public win8 As Boolean = False
    Public win10 As Boolean = False

    Private Sub CheckedOS()
        Dim OSResult As String = DeterminedOS(GetOS)
        If OSResult = "Win7" Then
            win7 = True
        ElseIf OSResult = "Win8" Then
            win8 = True
        ElseIf OSResult = "Win10" Then
            win8 = True
        ElseIf OSResult = "Pro" Then
            win10 = True
        End If
    End Sub

    Private Function DeterminedOS(ByVal OS As String) As String
        If InStr(1, OS, "7") > 0 Then
            Return "Win7"
        ElseIf InStr(1, OS, "8") > 0 Then
            Return "Win8"
        ElseIf InStr(1, OS, "Pro") > 0 Then
            Return "Win10 Pro"
        ElseIf InStr(1, OS, "10") > 0 Then
            Return "Win10"
        End If
        Return "Error"
    End Function


    Private Function GetOS() As String
        Try
            Dim OS As String = My.Computer.Info.OSFullName
            Return OS
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


    Private Function GetVersion() As String
        Try
            Dim Version As String = My.Computer.Info.OSVersion
            Return Version
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function GetPlatform() As String
        Try
            Dim Platform As String = My.Computer.Info.OSPlatform
            Return Platform
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


#End Region

#Region "Loader"

    Dim Proc As String = "GAME" ' Include the name of the game process, without the .exe

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Try
            Dim ProcID As String = String.Empty
            Dim p As Process()
            p = Process.GetProcessesByName(Proc)

            If p.Count = 1 Then
                FlatLabel1.Text = "Status :  Game Detected, starting hack . . ."
                already()
            Timer1.Enabled = True
            Timer3.Enabled = False
                ' Interaction.AppActivate("GFXTest32")
            Me.Hide()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
     End Sub

    Private Sub already()
        DX9Overlay.SetParam("process", Proseso)
        DX9Overlay.DestroyAllVisual()
        Timer5.Enabled = True
    End Sub

#End Region

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        Dim p As Process()
        p = Process.GetProcessesByName(Proc)
        If Not p.Count = 1 Then
            End
        End If
    End Sub

End Class
