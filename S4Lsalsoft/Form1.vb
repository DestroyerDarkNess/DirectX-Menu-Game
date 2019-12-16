Imports System.Runtime.InteropServices
Imports S4Lsalsoft.DX9OverlayAPI
Imports S4Lsalsoft.Cheat.GuiFuncs
Imports S4Lsalsoft.Cheat.Values
Imports System.IO

Public Class Form1

#Region " Pinvokes "

    <DllImport("user32.dll")> _
    Shared Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
    End Function

#End Region

#Region " Declarations "

    Public imagenGui As Integer
    Public VisibleMenu As Boolean = False
    Public Shared OnSwishedColor As Color = Color.DarkViolet
    Public OFFSwishedColor As Color = Color.Black
    Public GameResolutionScreen As Point = Nothing
    Public AutoReziseMenu As Integer

#End Region

#Region " Labels Structure "

#Region " Controls Size "

    Public Structure Controls_Size
        Shared TitleLabel As Integer = 10
        Shared Labels As Integer = 14
        Shared GUI As Point = New Point(200, 200)
    End Structure

#End Region

#Region " UI "

    Public Structure Menu_Gui
        Shared X As Integer = 5
        Shared Y As Integer = 5
        Shared InfoNumber As Integer = 0
    End Structure

#End Region

#Region " TitleHack "

    Public Structure LabelTitle
        Shared Text As String = "VB.NET | Direcx Menu"
        Shared X As Integer = Menu_Gui.X + 5
        Shared Y As Integer = Menu_Gui.X + 3
        Shared FontColor As Color = Color.White
        Shared InfoNumber As Integer = 0
    End Structure

#End Region

#Region " Label1 "

    Public Structure Label1S
        Shared IsActive As Boolean = False
        Shared Text As String = "Hack 1"
        Shared X As Integer = Controls_Size.GUI.X - (Controls_Size.GUI.X - (CalculateSizePointX(Controls_Size.GUI.X) / 2)) 'Menu_Gui.X + 25
        Shared Y As Integer = 40 'Menu_Gui.Y + 45
        Shared FontColor As Color = OnSwishedColor
        Shared InfoNumber As Integer = 0
    End Structure

    Public Structure Label1ON
        Shared Show As Boolean = False
        Shared Text As String = "[ON]"
        Shared X As Integer = Controls_Size.GUI.X - Menu_Gui.X '+ 195
        Shared Y As Integer = Label1S.Y
        Shared FontColor As Color = Color.Lime
        Shared InfoNumber As Integer = 0
    End Structure

    Public Structure Label1OFF
        Shared Show As Boolean = False
        Shared Text As String = "[OFF]"
        Shared X As Integer = Controls_Size.GUI.X - Menu_Gui.X  'Menu_Gui.X + 195
        Shared Y As Integer = Label1S.Y
        Shared FontColor As Color = Color.Red
        Shared InfoNumber As Integer = 0
    End Structure

#End Region

#Region " Label2 "

    Public Structure Label2S
        Shared IsActive As Boolean = False
        Shared Text As String = "Hack 1"
        Shared X As Integer = Controls_Size.GUI.X - (Controls_Size.GUI.X - (CalculateSizePointX(Controls_Size.GUI.X) / 2)) 'Menu_Gui.X + 25
        Shared Y As Integer = Label1S.Y + 30 'Menu_Gui.Y + 95
        Shared FontColor As Color = Color.Black
        Shared InfoNumber As Integer = 0
    End Structure

    Public Structure Label2ON
        Shared Text As String = "[ON]"
        Shared X As Integer = Controls_Size.GUI.X - Menu_Gui.X '+ 195
        Shared Y As Integer = Label2S.Y
        Shared FontColor As Color = Color.Lime
        Shared InfoNumber As Integer = 0
    End Structure

    Public Structure Label2OFF
        Shared Text As String = "[OFF]"
        Shared X As Integer = Controls_Size.GUI.X - Menu_Gui.X '+ 195
        Shared Y As Integer = Label2S.Y
        Shared FontColor As Color = Color.Red
        Shared InfoNumber As Integer = 0
    End Structure

#End Region

    Public Shared Function CalculateSizePointX(ByVal x) As Integer
        Dim Ccal As Integer = (x * 20) / 200
        Return Ccal
    End Function

#End Region

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        DX9Overlay.DestroyAllVisual()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProcessMonitor.Enabled = True
    End Sub

    Private Sub ProcessMonitor_Tick(sender As Object, e As EventArgs) Handles ProcessMonitor.Tick
        Dim p As Process()
        p = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(ProcessGame))
        If Not p.Count = 1 Then
            End
        End If
    End Sub

#Region " ShowHide Menu "

    Private Sub ShowHideMenuTimer_Tick(sender As Object, e As EventArgs) Handles ShowHideMenuTimer.Tick
        '****************** Show/Hide Menu ***********************
        If GetAsyncKeyState(Keys.Insert) = -32767 Then
            If VisibleMenu = False Then
                VisibleMenu = True
                ShowMenu()
                ActionMenu.Enabled = True
                Exit Sub
            End If
            If VisibleMenu = True Then
                VisibleMenu = False
                ActionMenu.Enabled = False
                DX9Overlay.DestroyAllVisual()
                Exit Sub
            End If
        End If

        '******************** Close Hack *********************
        If GetAsyncKeyState(Keys.Delete) = -32767 Then
            Application.Exit()
            Exit Sub
        End If

    End Sub

    Private Sub ActionMenu_Tick(sender As Object, e As EventArgs) Handles ActionMenu.Tick
        
        '///////////////DOWN NAVIGATE///////////////////


        If GetAsyncKeyState(Keys.Down) = -32767 Then
            If Label1S.FontColor = OnSwishedColor Then
                Label1S.FontColor = OFFSwishedColor
                Label2S.FontColor = OnSwishedColor
                UpdateLabelAllLabels()
                Exit Sub
            End If
            If Label2S.FontColor = OnSwishedColor Then
                Label2S.FontColor = OFFSwishedColor
                Label1S.FontColor = OnSwishedColor

                UpdateLabelAllLabels()
                Exit Sub
            End If

        End If

        '///////////////UP NAVIGATE///////////////////

        If GetAsyncKeyState(Keys.Up) = -32767 Then
            If Label1S.FontColor = OnSwishedColor Then
                Label1S.FontColor = OFFSwishedColor
                Label2S.FontColor = OnSwishedColor

                UpdateLabelAllLabels()
                Exit Sub
            End If

            If Label2S.FontColor = OnSwishedColor Then
                Label2S.FontColor = OFFSwishedColor
                Label1S.FontColor = OnSwishedColor

                UpdateLabelAllLabels()
                Exit Sub
            End If
        End If

        '///////////////RIGHT = ACTIVE/////////////

        If GetAsyncKeyState(Keys.Right) = -32767 Then
            If Label1S.FontColor = OnSwishedColor Then
                If Label1S.IsActive = False Then
                    Label1S.IsActive = True
                    DX9Overlay.TextDestroy(Label1OFF.InfoNumber)
                    Label1ON.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label1ON.X, Label1ON.Y, colorFormat(Label1ON.FontColor), Label1ON.Text, False, True)
                    Exit Sub
                End If

            End If

            If Label2S.FontColor = OnSwishedColor Then
                If Label2S.IsActive = False Then
                    Label2S.IsActive = True
                    DX9Overlay.TextDestroy(Label2OFF.InfoNumber)
                    Label2ON.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label2ON.X, Label2ON.Y, colorFormat(Label2ON.FontColor), Label2ON.Text, False, True)
                    Exit Sub
                End If

            End If

        End If

        '///////////////LEFT = ACTIVE/////////////

        If GetAsyncKeyState(Keys.Left) = -32767 Then
            If Label1S.FontColor = OnSwishedColor Then
                If Label1S.IsActive = True Then
                    Label1S.IsActive = False
                    DX9Overlay.TextDestroy(Label1ON.InfoNumber)
                    Label1OFF.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label1OFF.X, Label1OFF.Y, colorFormat(Label1OFF.FontColor), Label1OFF.Text, False, True)
                    Exit Sub
                End If
            End If
            
            If Label2S.FontColor = OnSwishedColor Then
                If Label2S.IsActive = True Then
                    Label2S.IsActive = False
                    DX9Overlay.TextDestroy(Label2ON.InfoNumber)
                    Label2OFF.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label2OFF.X, Label2OFF.Y, colorFormat(Label2OFF.FontColor), Label2OFF.Text, False, True)
                    Exit Sub
                End If
            End If

        End If

    End Sub

    Public Sub UpdateLabelAllLabels()
        'Label1 ///////////////////////////////////
        DX9Overlay.TextDestroy(Label1S.InfoNumber)
        Label1S.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label1S.X, Label1S.Y, colorFormat(Label1S.FontColor), Label1S.Text, False, True)

        'Label2 ///////////////////////////////////
        DX9Overlay.TextDestroy(Label2S.InfoNumber)
        Label2S.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label2S.X, Label2S.Y, colorFormat(Label2S.FontColor), Label2S.Text, False, True)
    End Sub

    Public Sub Dx9Gamebar(ByVal x As Integer, ByVal y As Integer, ByVal Largue As Integer, ByVal Ancho As Integer, _
                          ByVal BlackColor As Color)
        Dim Test As Integer
        Dim Border As Integer

        Border = DX9Overlay.LineCreate(x - 10, y + 2, Largue + 4, y + 2, Ancho + 5, colorFormat(Color.Black), True)

        Test = DX9Overlay.LineCreate(x, y, Largue, y, Ancho, colorFormat(BlackColor), True)
       
    End Sub

    Public Function MenuCalculateSize(ByVal GameScreen As Point) As Point


    End Function

    Private Sub ShowMenu()
        DX9Overlay.SetParam("process", ProcessGame)
        GameResolutionScreen = DX9Overlay.GetScreenSpecsOverlay
        ' Label1.Text = DX9Overlay.SetCalculationRatioOverlay(GameResolutionScreen)



        Dim Gui As String = CreateFormGui(500, Brushes.DodgerBlue, 500, Brushes.White, Controls_Size.GUI)

        Menu_Gui.InfoNumber = GuisImagen(Gui, Menu_Gui.X, Menu_Gui.Y)

        LabelTitle.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.TitleLabel, False, False, LabelTitle.X, LabelTitle.Y, colorFormat(LabelTitle.FontColor), LabelTitle.Text, False, True)

        If Label1S.IsActive = False Then
            Label1S.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label1S.X, Label1S.Y, colorFormat(Label1S.FontColor), Label1S.Text, False, True)
            Label1OFF.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label1OFF.X, Label1OFF.Y, colorFormat(Label1OFF.FontColor), Label1OFF.Text, False, True)
        Else
            Label1S.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label1S.X, Label1S.Y, colorFormat(Label1S.FontColor), Label1S.Text, False, True)
            Label1ON.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label1ON.X, Label1ON.Y, colorFormat(Label1ON.FontColor), Label1ON.Text, False, True)
        End If

        If Label2S.IsActive = False Then
            Label2S.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label2S.X, Label2S.Y, colorFormat(Label2S.FontColor), Label2S.Text, False, True)
            Label2OFF.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label2OFF.X, Label2OFF.Y, colorFormat(Label2OFF.FontColor), Label2OFF.Text, False, True)
        Else
            Label2S.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label2S.X, Label2S.Y, colorFormat(Label2S.FontColor), Label2S.Text, False, True)
            Label2ON.InfoNumber = DX9Overlay.TextCreateUnicode("Arial", Controls_Size.Labels, False, False, Label2ON.X, Label2ON.Y, colorFormat(Label2ON.FontColor), Label2ON.Text, False, True)
        End If
    End Sub

    Private Function GuisImagen(ByVal directory As String, ByVal posX As Integer, ByVal posY As Integer) As Integer
        Return DX9Overlay.ImageCreate(directory, posX, posY, 0, 0, True)
    End Function

#End Region

    Dim Contador As Integer = 100

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Contador -= 1
        If Contador <= 0 Then
            ' Timer1.Enabled = False
        Else
            ' Label2S.Text = Contador
            ' Dx9Gamebar(Contador, 200, 500, 10, Color.Lime)
        End If



    End Sub

End Class