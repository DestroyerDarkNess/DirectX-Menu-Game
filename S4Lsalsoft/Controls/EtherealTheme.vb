'' <summary>
'' Ethereal Theme
'' Author : THE LORD
'' Credits : Aeonhack(Round Rectangle Function)
'' Credits : Mavamaarten(TabPage Mouse Hover & Mouse Leave Event)
'' Release Date : Tuesday, December 27, 2016
'' Last Update : Monday, January 9, 2017
'' Update Purpose : Customizable Colors
'' </summary>

#Region " Namespaces "

Imports System.Drawing.Drawing2D
Imports System.ComponentModel

#End Region

#Region " Helper Methods "

Public Module HelperMethods

    Public GP As GraphicsPath

    Public Enum MouseMode As Byte
        NormalMode
        Hovered
        Pushed
    End Enum

    Public Sub DrawImageFromBase64(ByVal G As Graphics, ByVal Base64Image As String, ByVal Rect As Rectangle)
        Dim IM As Image = Nothing
        With G
            Using ms As New System.IO.MemoryStream(Convert.FromBase64String(Base64Image))
                IM = Image.FromStream(ms) : ms.Close()
            End Using
            .DrawImage(IM, Rect)
        End With
    End Sub

    Function RoundRec(ByVal r As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim CreateRoundPath As New GraphicsPath(FillMode.Winding)
        CreateRoundPath.AddArc(r.X, r.Y, Curve, Curve, 180.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - Curve, r.Y, Curve, Curve, 270.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - Curve, r.Bottom - Curve, Curve, Curve, 0.0F, 90.0F)
        CreateRoundPath.AddArc(r.X, r.Bottom - Curve, Curve, Curve, 90.0F, 90.0F)
        CreateRoundPath.CloseFigure()
        Return CreateRoundPath
    End Function

    Public Sub FillRoundedPath(ByVal G As Graphics, ByVal C As Color, ByVal Rect As Rectangle, ByVal Curve As Integer)
        With G
            .FillPath(New SolidBrush(C), RoundRec(Rect, Curve))
        End With
    End Sub

    Public Sub FillRoundedPath(ByVal G As Graphics, ByVal B As Brush, ByVal Rect As Rectangle, ByVal Curve As Integer)
        With G
            .FillPath(B, RoundRec(Rect, Curve))
        End With
    End Sub

    Public Sub DrawRoundedPath(ByVal G As Graphics, ByVal C As Color, ByVal Size As Single, ByVal Rect As Rectangle, ByVal Curve As Integer)
        With G
            .DrawPath(New Pen(C, Size), RoundRec(Rect, Curve))
        End With
    End Sub

    Public Sub DrawTriangle(ByVal G As Graphics, ByVal C As Color, ByVal Size As Integer, ByVal P1_0 As Point, ByVal P1_1 As Point, ByVal P2_0 As Point, ByVal P2_1 As Point, ByVal P3_0 As Point, ByVal P3_1 As Point)
        With G
            .DrawLine(New Pen(C, Size), P1_0, P1_1)
            .DrawLine(New Pen(C, Size), P2_0, P2_1)
            .DrawLine(New Pen(C, Size), P3_0, P3_1)
        End With
    End Sub

    Public Function PenRGBColor(ByVal GR As Graphics, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer, ByVal Size As Single) As Pen
        Return New Pen(Color.FromArgb(R, G, B), Size)
    End Function

    Public Function PenHTMlColor(ByVal C_WithoutHash As String, ByVal Size As Single) As Pen
        Return New Pen(GetHTMLColor(C_WithoutHash), Size)
    End Function

    Public Function SolidBrushRGBColor(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As SolidBrush
        Return New SolidBrush(Color.FromArgb(R, G, B))
    End Function

    Public Function SolidBrushHTMlColor(ByVal C_WithoutHash As String) As SolidBrush
        Return New SolidBrush(GetHTMLColor(C_WithoutHash))
    End Function

    Public Function GetHTMLColor(ByVal C_WithoutHash As String) As Color
        Return ColorTranslator.FromHtml("#" & C_WithoutHash)
    End Function

    Public Function ColorToHTML(ByVal C As Color) As String
        Return ColorTranslator.ToHtml(C)
    End Function

    Public Function SetARGB(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Color
        Return Color.FromArgb(A, R, G, B)
    End Function

    Public Function SetRGB(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Color
        Return Color.FromArgb(R, G, B)
    End Function

    Public Sub CentreString(ByVal G As Graphics, ByVal Text As String, ByVal font As Font, ByVal brush As Brush, ByVal Rect As Rectangle)
        G.DrawString(Text, font, brush, New Rectangle(0, Rect.Y + (Rect.Height / 2) - (G.MeasureString(Text, font).Height / 2) + 0, Rect.Width, Rect.Height), New StringFormat With {.Alignment = StringAlignment.Center})
    End Sub

    Public Sub LeftString(ByVal G As Graphics, ByVal Text As String, ByVal font As Font, ByVal brush As Brush, ByVal Rect As Rectangle)
        G.DrawString(Text, font, brush, New Rectangle(4, Rect.Y + (Rect.Height / 2) - (G.MeasureString(Text, font).Height / 2) + 0, Rect.Width, Rect.Height), New StringFormat With {.Alignment = StringAlignment.Near})
    End Sub

    Public Sub FillRect(ByVal G As Graphics, ByVal Br As Brush, ByVal Rect As Rectangle)
        G.FillRectangle(Br, Rect)
    End Sub

End Module

#End Region

#Region " Skin "

Public Class EtherealTheme : Inherits ContainerControl

#Region " Variables "

    Private Movable As Boolean = False
    Private MousePoint As New Point(0, 0)
    Private MoveHeight = 50
    Private _TitleTextPostion As TitlePostion = TitlePostion.Left
    Private _HeaderColor As Color = GetHTMLColor("3f2153")
    Private _BackColor As Color = Color.White
    Private _BorderColor As Color = GetHTMLColor("3f2153")
    Private Property _ShowIcon As Boolean = False

#End Region

#Region " Properties"

    Public Property HeaderColor As Color
        Get
            Return _HeaderColor
        End Get
        Set(value As Color)
            _HeaderColor = value
            Invalidate()
        End Set
    End Property
    Public Overridable Shadows Property BackColor As Color
        Get
            Return _BackColor
        End Get
        Set(value As Color)
            _BackColor = value
            MyBase.BackColor = value
            Invalidate()
        End Set
    End Property
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(value As Color)
            _BorderColor = value
            Invalidate()
        End Set
    End Property

    Public Overridable Shadows Property ShowIcon As Boolean
        Get
            Return _ShowIcon
        End Get
        Set(ByVal value As Boolean)
            If value = _ShowIcon Then Return
            FindForm().ShowIcon = value
            Invalidate()
            _ShowIcon = value
        End Set
    End Property

    Public Overridable Property TitleTextPostion As TitlePostion
        Get
            Return _TitleTextPostion
        End Get
        Set(value As TitlePostion)
            _TitleTextPostion = value
        End Set
    End Property

    Enum TitlePostion
        Left
        Center
    End Enum

#End Region

#Region " Initialization "

    Sub New()

        SetStyle(ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw, True)
        DoubleBuffered = True
        MyBase.Dock = DockStyle.None
        Font = New Font("Proxima Nova", 14, FontStyle.Bold)
    End Sub

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height), G = Graphics.FromImage(B)
        With G
            .TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            FillRect(G, New SolidBrush(HeaderColor), New Rectangle(0, 0, Width, 50))
            .DrawRectangle(New Pen(BorderColor, 2), New Rectangle(1, 1, Width - 2, Height - 2))

            If FindForm().ShowIcon = True Then
                G.DrawIcon(FindForm().Icon, New Rectangle(5, 13, 20, 20))
                Select Case TitleTextPostion
                    Case TitlePostion.Left
                        G.DrawString(Text, Font, Brushes.White, 27, 10)
                        Exit Select
                    Case TitlePostion.Center
                        HelperMethods.CentreString(G, Text, Font, Brushes.White, New Rectangle(0, 0, Width, 50))
                        Exit Select
                End Select
            Else
                Select Case TitleTextPostion
                    Case TitlePostion.Left
                        G.DrawString(Text, Font, Brushes.White, 5, 10)
                        Exit Select
                    Case TitlePostion.Center
                        HelperMethods.CentreString(G, Text, Font, Brushes.White, New Rectangle(0, 0, Width, 50))
                        Exit Select
                End Select
            End If

        End With
        MyBase.OnPaint(e)
        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width, MoveHeight).Contains(e.Location) Then
            Movable = True
            MousePoint = e.Location
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e) : Movable = False
    End Sub
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Movable Then Parent.Location = MousePosition - MousePoint
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        ParentForm.FormBorderStyle = FormBorderStyle.None
        ParentForm.AllowTransparency = False
        ParentForm.TransparencyKey = Color.Fuchsia
        ParentForm.FindForm.StartPosition = FormStartPosition.CenterScreen
        Dock = DockStyle.Fill
        Invalidate()
    End Sub

#End Region

End Class

#End Region

#Region " TabControl "

Public Class EtherealTabControl : Inherits TabControl

#Region " Variables "

    Private State As New MouseMode
    Private _TabsColor As Color = GetHTMLColor("432e58")
    Private _SeletedTabTriangleColor As Color = Color.White
    Private _LeftColor As Color = GetHTMLColor("4e3a62")
    Private _RightColor As Color = Color.White
    Private _LineColor As Color = GetHTMLColor("3b2551")
    Private _NoneSelectedTabColors As Color = GetHTMLColor("432e58")
    Private _HoverColor As Color = GetHTMLColor("3b2551")
    Private _TextColor As Color = Color.White
    Private _TabPageColor As Color = Color.White

#End Region

#Region " Properties "

    Public Property TabsColor As Color
        Get
            Return _TabsColor
        End Get
        Set(value As Color)
            _TabsColor = value
            Invalidate()
        End Set
    End Property

    Public Property SeletedTabTriangleColor As Color
        Get
            Return _SeletedTabTriangleColor
        End Get
        Set(value As Color)
            _SeletedTabTriangleColor = value
            Invalidate()
        End Set
    End Property

    Public Property LeftColor As Color
        Get
            Return _LeftColor
        End Get
        Set(value As Color)
            _LeftColor = value
            Invalidate()
        End Set
    End Property

    Public Property RightColor As Color
        Get
            Return _RightColor
        End Get
        Set(value As Color)
            _RightColor = value
            Invalidate()
        End Set
    End Property

    Public Property LineColor As Color
        Get
            Return _LineColor
        End Get
        Set(value As Color)
            _LineColor = value
            Invalidate()
        End Set
    End Property

    Public Property NoneSelectedTabColors As Color
        Get
            Return _NoneSelectedTabColors
        End Get
        Set(value As Color)
            _NoneSelectedTabColors = value
            Invalidate()
        End Set
    End Property

    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
            Invalidate()
        End Set
    End Property

    Public Property HoverColor As Color
        Get
            Return _HoverColor
        End Get
        Set(value As Color)
            _HoverColor = value
            Invalidate()
        End Set
    End Property

    Public Property TabPageColor As Color
        Get
            Return _TabPageColor
        End Get
        Set(value As Color)
            _TabPageColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Stractures "

    Private Structure MouseMode
        Dim Hover As Boolean
        Dim Coordinates As Point
    End Structure

#End Region

#Region " Initialization "

    Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        Dock = DockStyle.None
        ItemSize = New Size(40, 150)
        Alignment = TabAlignment.Left
    End Sub

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Using B As New Bitmap(Width, Height), G As Graphics = Graphics.FromImage(B)
            With G
                .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                .InterpolationMode = InterpolationMode.HighQualityBicubic
                FillRect(G, New SolidBrush(LeftColor), New Rectangle(0, 1, 150, Height))
                For i = 0 To TabCount - 1
                    Dim R As Rectangle = GetTabRect(i)

                    FillRect(G, New SolidBrush(NoneSelectedTabColors), New Rectangle(R.X - 1, R.Y - 1, R.Width - 3, R.Height))

                    If i = SelectedIndex Then
                        .SmoothingMode = SmoothingMode.AntiAlias
                        Dim P1 As New Point(ItemSize.Height - 12, R.Location.Y + 20), _
                            P2 As New Point(ItemSize.Height + 2, R.Location.Y + 10), _
                            P3 As New Point(ItemSize.Height + 2, R.Location.Y + 30)
                        .FillPolygon(New SolidBrush(SeletedTabTriangleColor), New Point() {P1, P2, P3})
                    Else
                        If State.Hover AndAlso R.Contains(State.Coordinates) Then
                            Cursor = Cursors.Hand
                            FillRect(G, New SolidBrush(HoverColor), New Rectangle(R.X, R.Y, R.Width - 3, R.Height))
                        End If
                    End If

                    .DrawString(TabPages(i).Text, New Font("Segoe UI", 8, FontStyle.Bold), New SolidBrush(TextColor), R.X + 28, R.Y + 13)

                    If ImageList IsNot Nothing Then
                        .DrawImage(ImageList.Images(i), New Rectangle(R.X + 6, R.Y + 11, 16, 16))
                    End If

                    .DrawLine(New Pen(LineColor, 1), New Point(R.X - 1, R.Bottom - 2), New Point(R.Width - 2, R.Bottom - 2))

                Next
                .FillRectangle(New SolidBrush(RightColor), New Rectangle(150, 1.3, Width, Height - 2))
                .DrawRectangle(New Pen(LineColor, 1), New Rectangle(0, 0, Width - 1, Height - 1))
            End With
            e.Graphics.DrawImage(B, 0, 0)
            G.Dispose()
            B.Dispose()
        End Using
    End Sub

#End Region

#Region " Events "

    Protected Overrides Sub OnMouseEnter(e As System.EventArgs)
        State.Hover = True
        MyBase.OnMouseHover(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As System.EventArgs)
        State.Hover = False
        For Each Tab As TabPage In MyBase.TabPages
            If Tab.DisplayRectangle.Contains(State.Coordinates) Then
                Invalidate()
                Exit For
            End If
        Next
        MyBase.OnMouseHover(e)
    End Sub

    Protected Overrides Sub OnMouseMove(e As System.Windows.Forms.MouseEventArgs)
        State.Coordinates = e.Location
        For Each Tab As TabPage In MyBase.TabPages
            If Tab.DisplayRectangle.Contains(e.Location) Then
                Invalidate()
                Exit For
            End If
        Next
        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        For Each T As TabPage In TabPages
            T.BackColor = TabPageColor
        Next
    End Sub

#End Region

End Class

#End Region

#Region " Button "

Public Class EtherealButton : Inherits Control

#Region " Variables "

    Private State As MouseMode
    Public Property ButtonStyle As Style
    Private NoneColor As Color = GetHTMLColor("222222")
    Private _RoundRadius As Integer = 5

#End Region

#Region " Properties "

    Public Property RoundRadius As Integer
        Get
            Return _RoundRadius
        End Get
        Set(value As Integer)
            _RoundRadius = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Initialization "

    Sub New()
        SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or _
        ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or _
        ControlStyles.Selectable Or ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
    End Sub

#End Region

#Region " Enumerators "

    Public Enum Style As Byte
        Clear
        DarkClear
        SemiBlack
        DarkPink
        LightPink
    End Enum

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Using B As New Bitmap(Width, Height), G As Graphics = Graphics.FromImage(B)
            Dim Rect As Rectangle = New Rectangle(0, 0, Width - 1, Height - 1)
            With G
                GP = RoundRec(Rect, RoundRadius)
                .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                .SmoothingMode = SmoothingMode.HighQuality

                Select Case State
                    Case MouseMode.NormalMode
                        Select Case ButtonStyle
                            Case Style.Clear
                                NoneColor = GetHTMLColor("ececec")
                                DrawRoundedPath(G, NoneColor, 1, Rect, RoundRadius)
                                CentreString(G, Text, New Font("Segoe UI", 9, FontStyle.Bold), SolidBrushHTMlColor("b9b9b9"), Rect)
                            Case Style.DarkClear
                                NoneColor = GetHTMLColor("444444")
                                DrawRoundedPath(G, NoneColor, 1, Rect, RoundRadius)
                                CentreString(G, Text, New Font("Segoe UI", 9, FontStyle.Bold), SolidBrushHTMlColor("444444"), Rect)
                            Case Style.SemiBlack
                                NoneColor = GetHTMLColor("222222")
                                FillRoundedPath(G, NoneColor, Rect, RoundRadius)
                                DrawRoundedPath(G, GetHTMLColor("121212"), 1, Rect, RoundRadius)
                                CentreString(G, Text, New Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, Rect)
                            Case Style.DarkPink
                                NoneColor = GetHTMLColor("3b2551")
                                FillRoundedPath(G, NoneColor, Rect, RoundRadius)
                                DrawRoundedPath(G, GetHTMLColor("6d5980"), 1, Rect, RoundRadius)
                                CentreString(G, Text, New Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, Rect)
                            Case Style.LightPink
                                NoneColor = GetHTMLColor("9d92a8")
                                FillRoundedPath(G, NoneColor, Rect, RoundRadius)
                                DrawRoundedPath(G, GetHTMLColor("573d71"), 1, Rect, RoundRadius)
                                CentreString(G, Text, New Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, Rect)
                        End Select
                    Case MouseMode.Hovered
                        NoneColor = GetHTMLColor("444444")
                        Select Case ButtonStyle
                            Case Style.Clear
                                NoneColor = GetHTMLColor("444444")
                                DrawRoundedPath(G, NoneColor, 1, Rect, RoundRadius)
                                CentreString(G, Text, New Font("Segoe UI", 9, FontStyle.Bold), SolidBrushHTMlColor("444444"), Rect)
                            Case Style.DarkClear
                                NoneColor = GetHTMLColor("ececec")
                                DrawRoundedPath(G, NoneColor, 1, Rect, RoundRadius)
                                CentreString(G, Text, New Font("Segoe UI", 9, FontStyle.Bold), SolidBrushHTMlColor("b9b9b9"), Rect)
                            Case Style.SemiBlack
                                NoneColor = GetHTMLColor("444444")
                                .FillPath(New SolidBrush(Color.Transparent), GP)
                                DrawRoundedPath(G, NoneColor, 1, Rect, RoundRadius)
                                CentreString(G, Text, New Font("Segoe UI", 9, FontStyle.Bold), SolidBrushHTMlColor("444444"), Rect)
                            Case Style.DarkPink
                                NoneColor = GetHTMLColor("444444")
                                FillRect(G, New SolidBrush(Color.Transparent), Rect)
                                DrawRoundedPath(G, NoneColor, 1, Rect, RoundRadius)
                                CentreString(G, Text, New Font("Segoe UI", 9, FontStyle.Bold), SolidBrushHTMlColor("444444"), Rect)
                            Case Style.LightPink
                                NoneColor = GetHTMLColor("9d92a8")
                                FillRect(G, New SolidBrush(Color.Transparent), Rect)
                                DrawRoundedPath(G, NoneColor, 1, Rect, RoundRadius)
                                CentreString(G, Text, New Font("Segoe UI", 9, FontStyle.Bold), SolidBrushHTMlColor("444444"), Rect)
                        End Select
                    Case MouseMode.Pushed
                        Select Case ButtonStyle
                            Case Style.Clear, Style.DarkClear
                                NoneColor = GetHTMLColor("444444")
                                FillRect(G, New SolidBrush(Color.Transparent), Rect)
                                DrawRoundedPath(G, NoneColor, 1, Rect, 5)
                                CentreString(G, Text, New Font("Segoe UI", 9, FontStyle.Bold), SolidBrushHTMlColor("444444"), Rect)
                            Case Style.DarkPink, Style.LightPink, Style.SemiBlack
                                NoneColor = GetHTMLColor("ececec")
                                DrawRoundedPath(G, NoneColor, 1, Rect, 5)
                                CentreString(G, Text, New Font("Segoe UI", 9, FontStyle.Bold), SolidBrushHTMlColor("b9b9b9"), Rect)
                        End Select
                End Select

            End With
            e.Graphics.DrawImage(B.Clone, 0, 0)
            G.Dispose() : B.Dispose()
        End Using
    End Sub

#End Region

#Region " Events "

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseMode.Hovered : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseMode.Pushed : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseMode.Hovered : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseMode.NormalMode : Invalidate()
    End Sub

#End Region

End Class

#End Region

#Region " ComboBox "

Public Class EtherealComboBox : Inherits ComboBox

#Region " Variables "

    Private _StartIndex As Integer = 0
    Private _BorderColor As Color = GetHTMLColor("ececec")
    Private _TextColor As Color = GetHTMLColor("b8c6d6")
    Private _TriangleColor As Color = GetHTMLColor("999999")

#End Region

#Region " Properties "

    Private Property StartIndex As Integer
        Get
            Return _StartIndex
        End Get
        Set(ByVal value As Integer)
            _StartIndex = value
            Try
                MyBase.SelectedIndex = value
            Catch
            End Try
            Invalidate()
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(value As Color)
            _BorderColor = value
            Invalidate()
        End Set
    End Property

    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
            Invalidate()
        End Set
    End Property

    Public Property TriangleColor As Color
        Get
            Return _TriangleColor
        End Get
        Set(value As Color)
            _TriangleColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Initialization "

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or _
                  ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        Size = New Size(200, 35)
        DropDownStyle = ComboBoxStyle.DropDownList
        BackColor = Color.Transparent
        Font = New Font("Segoe UI", 15)
        DoubleBuffered = True
    End Sub

#End Region

#Region " Draw Control "

    Sub MyBase_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MyBase.DrawItem
        Try
            With e.Graphics
                .SmoothingMode = SmoothingMode.HighQuality
                .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                e.DrawBackground()
                If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                    .FillRectangle(SolidBrushHTMlColor("3b2551"), e.Bounds)
                    .DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), New Font("Segoe UI", 10, FontStyle.Bold), New SolidBrush(Color.WhiteSmoke), 1, e.Bounds.Top + 5)
                Else
                    .FillRectangle(New SolidBrush(e.BackColor), e.Bounds)
                    .DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), New Font("Segoe UI", 10, FontStyle.Bold), SolidBrushHTMlColor("b8c6d6"), 1, e.Bounds.Top + 5)
                End If
            End With
        Catch
        End Try
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Using B As New Bitmap(Width, Height), G As Graphics = Graphics.FromImage(B)
            Dim Rect As New Rectangle(1, 1, Width - 2, Height - 2)
            With G
                .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias : .SmoothingMode = SmoothingMode.HighQuality : .PixelOffsetMode = PixelOffsetMode.HighQuality
                DrawTriangle(G, TriangleColor, 2, _
                New Point(Width - 20, 16), New Point(Width - 16, 20), _
                New Point(Width - 16, 20), New Point(Width - 12, 16), _
                New Point(Width - 16, 21), New Point(Width - 16, 20) _
                )
                DrawRoundedPath(G, BorderColor, 1.5, Rect, 4)
                .DrawString(Text, Font, New SolidBrush(TextColor), New Rectangle(7, 0, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
            End With
            e.Graphics.DrawImage(B, 0, 0)
            G.Dispose()
            B.Dispose()
        End Using
    End Sub

#End Region

End Class

#End Region

#Region " Textbox "

Public Class EtherealTextbox : Inherits Control

#Region " Variables "

    Private WithEvents T As New TextBox
    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Private _MaxLength As Integer = 32767
    Private _ReadOnly As Boolean = False
    Private _UseSystemPasswordChar As Boolean = False
    Private _WatermarkText As String = String.Empty
    Private _SideImage As Image
    Private _BackColor As Color = Color.White
    Private _BorderColor As Color = GetHTMLColor("ececec")
    Private _ForeColor As Color = Color.Gray

#End Region

#Region " Native Methods "

    Private Declare Auto Function SendMessage Lib "user32.dll" (hWnd As IntPtr, msg As Integer, wParam As Integer, <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)> lParam As String) As Int32

#End Region

#Region " Properties "

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Property BorderStyle As BorderStyle
        Get
            Return BorderStyle.None
        End Get
        Set(ByVal value As BorderStyle)
        End Set
    End Property

    Public Property WatermarkText As String
        Get
            Return _WatermarkText
        End Get
        Set(value As String)
            _WatermarkText = value
            SendMessage(T.Handle, &H1501, 0, value)
            Invalidate()
        End Set
    End Property

    Public Overridable Shadows Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If T IsNot Nothing Then
                T.TextAlign = value
            End If
        End Set
    End Property

    Public Overridable Shadows Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If T IsNot Nothing Then
                T.MaxLength = value
            End If
        End Set
    End Property

    Public Overridable Shadows Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If T IsNot Nothing Then
                T.ReadOnly = value
            End If
        End Set
    End Property

    Public Overridable Shadows Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If T IsNot Nothing Then
                T.UseSystemPasswordChar = value
            End If
        End Set
    End Property

    Public Overridable Shadows ReadOnly Property Multiline() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overridable Shadows Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If T IsNot Nothing Then
                T.Text = value
            End If
        End Set
    End Property

    <Browsable(False)>
    Public Overridable Shadows ReadOnly Property Font As Font
        Get
            Return New Font("Segoe UI", 10, FontStyle.Regular)
        End Get
    End Property

    Public Overridable Shadows Property ForeColor As Color
        Get
            Return _ForeColor
        End Get
        Set(value As Color)
            MyBase.ForeColor = value
            T.ForeColor = value
            _ForeColor = value
            Invalidate()
        End Set
    End Property

    <Browsable(True)>
    Public Property SideImage As Image
        Get
            Return _SideImage
        End Get
        Set(value As Image)
            _SideImage = value
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(T) Then
            Controls.Add(T)
        End If
    End Sub

    Private Sub T_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles T.TextChanged
        Text = T.Text
    End Sub

    Private Sub T_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles T.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.A Then e.SuppressKeyPress = True

        If e.Control AndAlso e.KeyCode = Keys.C Then
            T.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub

    Public Overridable Shadows Property BackColor As Color
        Get
            Return _BackColor
        End Get
        Set(value As Color)
            MyBase.BackColor = value
            T.BackColor = value
            _BackColor = value
            Invalidate()
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(value As Color)
            _BorderColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Initialization "

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                  ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                  ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        With T
            .Multiline = False
            .Cursor = Cursors.IBeam
            .BackColor = BackColor
            .ForeColor = ForeColor
            .Text = WatermarkText
            .BorderStyle = BorderStyle.None
            .Location = New Point(7, 7)
            .Font = Font
            .Size = New Size(Width - 10, 34)
            .UseSystemPasswordChar = _UseSystemPasswordChar
            Text = WatermarkText
        End With
        Size = New Size(135, 34)
    End Sub

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Using B As New Bitmap(Width, Height), G As Graphics = Graphics.FromImage(B)
            Height = 34
            With G
                .SmoothingMode = SmoothingMode.HighQuality
                .Clear(BackColor)
                DrawRoundedPath(G, BorderColor, 1.8, New Rectangle(0, 0, Width - 1, Height - 1), 4)
                If Not SideImage Is Nothing Then
                    T.Location = New Point(45, 7)
                    T.Width = Width - 60
                    .DrawRectangle(New Pen(BorderColor, 1), New Rectangle(-1, -1, 35, Height + 1))
                    .DrawImage(SideImage, New Rectangle(8, 7, 16, 16))
                Else
                    T.Location = New Point(7, 7)
                    T.Width = Width - 10
                End If
            End With
            e.Graphics.DrawImage(B.Clone(), 0, 0)
            G.Dispose() : B.Dispose()
        End Using
    End Sub

#End Region

End Class

#End Region

#Region " Seperator "

Public Class EtherealSeperator : Inherits Control

#Region " Variables "

    Public Property SepStyle As Style = Style.Horizental

#End Region

#Region " Enumerators "

    Enum Style
        Horizental
        Vertiacal
    End Enum

#End Region

#Region " Initialization "

    Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        ForeColor = GetHTMLColor("3b2551")
    End Sub

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height), G = e.Graphics
        With G
            .SmoothingMode = SmoothingMode.HighQuality
            Dim BL1, BL2 As New ColorBlend
            BL1.Positions = New Single() {0.0F, 0.15F, 0.85F, 1.0F}
            BL1.Colors = New Color() {Color.Transparent, ForeColor, ForeColor, Color.Transparent}
            Select Case SepStyle
                Case Style.Horizental
                    Dim lb1 As New LinearGradientBrush(ClientRectangle, Color.Empty, Color.Empty, 0.0F)
                    lb1.InterpolationColors = BL1
                    .DrawLine(New Pen(lb1), 0, 1, Width, 1)
                Case Style.Vertiacal
                    Dim lb1 As New LinearGradientBrush(ClientRectangle, Color.Empty, Color.Empty, 90.0F)
                    lb1.InterpolationColors = BL1
                    .DrawLine(New Pen(lb1), 1, 0, 1, Height)
            End Select
        End With
    End Sub

#End Region

End Class

#End Region

#Region " Radio Button "

<DefaultEvent("CheckedChanged")> Public Class EtherealRadioButton : Inherits Control

#Region " Variables "

    Private _Checked As Boolean
    Private _Group As Integer = 1
    Event CheckedChanged(ByVal sender As Object)
    Private _BorderColor As Color = GetHTMLColor("746188")
    Private _CheckColor As Color = GetHTMLColor("746188")

#End Region

#Region " Properties "

    Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property

    Public Property CheckColor As Color
        Get
            Return _CheckColor
        End Get
        Set(value As Color)
            _CheckColor = value
            Invalidate()
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(value As Color)
            _BorderColor = value
            Invalidate()
        End Set
    End Property

    Property Group As Integer
        Get
            Return _Group
        End Get
        Set(ByVal value As Integer)
            _Group = value
        End Set
    End Property

    Private Sub UpdateState()
        If Not IsHandleCreated OrElse Not Checked Then Return
        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is EtherealRadioButton AndAlso DirectCast(C, EtherealRadioButton).Group = _Group Then
                DirectCast(C, EtherealRadioButton).Checked = False
            End If
        Next
    End Sub
#End Region

#Region " Initialization "

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or _
     ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
        Cursor = Cursors.Hand
        Font = New Font("Proxima Nova", 11, FontStyle.Regular)
    End Sub

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Using B As New Bitmap(Width, Height), G As Graphics = Graphics.FromImage(B)

            With G
                .SmoothingMode = SmoothingMode.HighQuality
                .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

                .DrawEllipse(New Pen(BorderColor, 2.5), 1, 1, 18, 18)
                .DrawString(Text, Font, Brushes.Gray, New Rectangle(23, -0.3, Width, Height))

                If Checked Then .FillEllipse(New SolidBrush(CheckColor), New Rectangle(5, 5, 10, 10))


            End With

            e.Graphics.DrawImage(B.Clone(), 0, 0)
            G.Dispose() : B.Dispose()

        End Using

    End Sub

#End Region

#Region " Events "

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        _Checked = Not Checked
        UpdateState()
        MyBase.OnClick(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnCreateControl()
        UpdateState()
        MyBase.OnCreateControl()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        Invalidate() : MyBase.OnTextChanged(e)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        Invalidate()
        MyBase.OnResize(e)
        Height = 21
    End Sub

#End Region

End Class

#End Region

#Region " CheckBox "

<DefaultEvent("CheckedChanged")> _
Public Class EtherealCheckBox : Inherits Control

#Region " Variables "

    Private _Checked As Boolean = False
    Event CheckedChanged(ByVal sender As Object)
    Private _BorderColor As Color = GetHTMLColor("746188")
    Private _CheckColor As Color = GetHTMLColor("746188")

#End Region

#Region " Properties "

    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    Public Property CheckColor As Color
        Get
            Return _CheckColor
        End Get
        Set(value As Color)
            _CheckColor = value
            Invalidate()
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(value As Color)
            _BorderColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Initialization "

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                   ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer _
                   Or ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Cursor = Cursors.Hand
        Size = New Size(200, 20)
        Font = New Font("Proxima Nova", 11, FontStyle.Regular)
        BackColor = Color.Transparent
    End Sub

#End Region

#Region " Events "

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        _Checked = Not _Checked
        RaiseEvent CheckedChanged(Me)
        MyBase.OnClick(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Height = 20
    End Sub

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Using B As New Bitmap(Width, Height), G As Graphics = Graphics.FromImage(B)

            With G

                .SmoothingMode = SmoothingMode.AntiAlias

                .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

                DrawRoundedPath(G, BorderColor, 3, New Rectangle(1, 1, 16, 16), 3)

                If Checked Then

                    FillRoundedPath(G, CheckColor, New Rectangle(5, 5, 8.5, 8.5), 1)

                End If

                G.DrawString(Text, Font, Brushes.Gray, New Rectangle(22, -1.2, Width, Height - 2))

            End With

            e.Graphics.DrawImage(B.Clone, 0, 0)

            G.Dispose() : B.Dispose()

        End Using

    End Sub

#End Region

End Class

#End Region

#Region " Switch "

<DefaultEvent("CheckedChanged")> _
Public Class EtherealSwitch : Inherits Control

#Region " Variables "

    Private _Switch As Boolean = False
    Private State As MouseMode
    Private _SwitchColor As Color = GetHTMLColor("3f2153")

#End Region

    Event CheckedChanged(ByVal sender As Object)

#Region " Properties "

    Public Property Switched() As Boolean
        Get
            Return _Switch
        End Get
        Set(ByVal value As Boolean)
            _Switch = value
            Invalidate()
        End Set
    End Property

    Public Property SwitchColor As Color
        Get
            Return _SwitchColor
        End Get
        Set(value As Color)
            _SwitchColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Initialization "

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                   ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer _
                   Or ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Cursor = Cursors.Hand
        Size = New Size(46, 25)
    End Sub

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Using B As New Bitmap(Width, Height), G As Graphics = Graphics.FromImage(B)

            With G
                .SmoothingMode = SmoothingMode.AntiAlias

                If Switched Then

                    FillRoundedPath(G, SwitchColor, New Rectangle(1, 1, 42, 22), 22)
                    DrawRoundedPath(G, GetHTMLColor("ededed"), 1.5, New Rectangle(1, 1, 42, 22), 20)

                    G.FillEllipse(SolidBrushHTMlColor("fcfcfc"), New Rectangle(22, 2.6, 19, 18))
                    G.DrawEllipse(PenHTMlColor("e9e9e9", 1.5), New Rectangle(22, 2.6, 19, 18))

                Else
                    FillRoundedPath(G, GetHTMLColor("f8f8f8"), New Rectangle(1, 1, 42, 22), 22)
                    DrawRoundedPath(G, GetHTMLColor("ededed"), 1.5, New Rectangle(1, 1, 42, 22), 20)

                    G.FillEllipse(SolidBrushHTMlColor("fcfcfc"), New Rectangle(3, 2.6, 19, 18))
                    G.DrawEllipse(PenHTMlColor("e9e9e9", 1.5), New Rectangle(3, 2.6, 19, 18))


                End If

            End With

            e.Graphics.DrawImage(B.Clone(), 0, 0)
            G.Dispose() : B.Dispose()

        End Using
    End Sub

#End Region

#Region " Events "

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseMode.Pushed : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseMode.Hovered : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseMode.Hovered : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseMode.NormalMode : Invalidate()
    End Sub

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        _Switch = Not _Switch
        RaiseEvent CheckedChanged(Me)
        MyBase.OnClick(e)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(46, 25)
    End Sub

#End Region

End Class

#End Region

#Region " ProgressBar "

Public Class EtherealProgressBar : Inherits Control

#Region " Variables "

    Private _Maximum As Integer = 100
    Private _Value As Integer = 0
    Private _RoundRadius As Integer = 8
    Private _ProgressColor As Color = GetHTMLColor("4e3a62")
    Private _BaseColor As Color = GetHTMLColor("f7f7f7")
    Private _BorderColor As Color = GetHTMLColor("ececec")

#End Region

#Region " Initialization "

    Sub New()
        MyBase.New()
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        Size = New Size(75, 23)
    End Sub

#End Region

#Region " Properties "

    Public Property Value() As Integer
        Get
            If _Value < 0 Then
                Return 0
            Else
                Return _Value
            End If
        End Get
        Set(ByVal Value As Integer)
            If Value > Maximum Then
                Value = Maximum
            End If
            _Value = Value
            Invalidate()
        End Set
    End Property

    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal Value As Integer)
            Select Case Value
                Case Is < _Value
                    _Value = Value
            End Select
            _Maximum = Value
            Invalidate()
        End Set
    End Property

    Public Property RoundRadius As Integer
        Get
            Return _RoundRadius
        End Get
        Set(value As Integer)
            _RoundRadius = value
            Invalidate()
        End Set
    End Property

    Public Property ProgressColor As Color
        Get
            Return _ProgressColor
        End Get
        Set(value As Color)
            _ProgressColor = value
            Invalidate()
        End Set
    End Property
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
            Invalidate()
        End Set
    End Property
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(value As Color)
            _BorderColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)

        Using B As New Bitmap(Width, Height), G As Graphics = Graphics.FromImage(B)

            G.SmoothingMode = SmoothingMode.HighQuality

            Dim CurrentValue As Integer = CInt(Value / Maximum * Width)

            Dim Rect As New Rectangle(0, 0, Width - 1, Height - 1)

            FillRoundedPath(G, BaseColor, Rect, RoundRadius)

            DrawRoundedPath(G, BorderColor, 1, Rect, RoundRadius)

            If Not CurrentValue = 0 Then

                FillRoundedPath(G, ProgressColor, New Rectangle(Rect.X, Rect.Y, CurrentValue, Rect.Height), RoundRadius)

            End If
            e.Graphics.DrawImage(B, 0, 0)
            G.Dispose()
            B.Dispose()
        End Using
    End Sub

#End Region

End Class

#End Region

#Region " Lable "

Public Class EtherealLabel : Inherits Control

#Region " Variables "

    Private _ColorStyle As Style = Style.DarkPink

#End Region

#Region " Properties "

    Public Property ColorStyle As Style
        Get
            Return _ColorStyle
        End Get
        Set(value As Style)
            _ColorStyle = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Enumerators "

    Public Enum Style As Byte
        SemiBlack
        DarkPink
        LightPink
    End Enum

#End Region

#Region " Events "

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

#End Region

#Region " Initialization "

    Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        Font = New Font("Montserrat", 10, FontStyle.Bold)
    End Sub

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        With G
            .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            Select Case ColorStyle
                Case Style.SemiBlack
                    .DrawString(Text, Font, SolidBrushHTMlColor("222222"), ClientRectangle)
                Case Style.DarkPink
                    .DrawString(Text, Font, SolidBrushHTMlColor("3b2551"), ClientRectangle)
                Case Style.LightPink
                    .DrawString(Text, Font, SolidBrushHTMlColor("9d92a8"), ClientRectangle)
            End Select
        End With
    End Sub

#End Region

End Class

#End Region

#Region " Close "

Public Class EtherealClose : Inherits Control

#Region " Variable "

    Private State As MouseMode
    Private _NormalColor As Color = GetHTMLColor("3f2153")
    Private _HoverColor As Color = GetHTMLColor("f0f0f0")
    Private _PushedColor As Color = GetHTMLColor("966bc1")
    Private _TextColor As Color = Color.White

#End Region

#Region " Initialization "

    Sub New()
        SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or _
        ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or _
        ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Font = New Font("Marlett", 8)
        Size = New Size(20, 20)
    End Sub

#End Region

#Region " Properties "

    Public Property NormalColor As Color
        Get
            Return _NormalColor
        End Get
        Set(value As Color)
            _NormalColor = value
            Invalidate()
        End Set
    End Property

    Public Property HoverColor As Color
        Get
            Return _HoverColor
        End Get
        Set(value As Color)
            _HoverColor = value
            Invalidate()
        End Set
    End Property

    Public Property PushedColor As Color
        Get
            Return _PushedColor
        End Get
        Set(value As Color)
            _PushedColor = value
            Invalidate()
        End Set
    End Property

    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Using B As New Bitmap(Width, Height), G As Graphics = Graphics.FromImage(B)

            With G

                .SmoothingMode = SmoothingMode.HighQuality

                .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

                .PixelOffsetMode = PixelOffsetMode.HighQuality

                Select Case State
                    Case MouseMode.NormalMode
                        .FillEllipse(New SolidBrush(NormalColor), 1, 1, 19, 19)
                    Case MouseMode.Hovered
                        Cursor = Cursors.Hand
                        .FillEllipse(New SolidBrush(NormalColor), 1, 1, 19, 19)
                        .DrawEllipse(New Pen(HoverColor, 2), 1, 1, 18, 18)
                    Case MouseMode.Pushed
                        .FillEllipse(New SolidBrush(PushedColor), 1, 1, 19, 19)
                End Select

                .DrawString("r", Font, New SolidBrush(TextColor), New Rectangle(4, 6, 18, 18))

            End With

            e.Graphics.DrawImage(B.Clone, 0, 0)
            G.Dispose() : B.Dispose()

        End Using

    End Sub

#End Region

#Region " Events "

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseMode.Hovered : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseMode.Pushed : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseMode.Hovered : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseMode.NormalMode : Invalidate()
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(20, 20)
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        Environment.Exit(0)
        Application.Exit()
    End Sub

#End Region

End Class

#End Region

#Region " Minimize "

Public Class EtherealMinimize : Inherits Control

#Region " Variables "

    Private State As MouseMode
    Private _NormalColor As Color = GetHTMLColor("3f2153")
    Private _HoverColor As Color = GetHTMLColor("f0f0f0")
    Private _PushedColor As Color = GetHTMLColor("966bc1")
    Private _TextColor As Color = Color.White

#End Region

#Region " Initialization "

    Sub New()
        SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or _
        ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or _
        ControlStyles.Selectable Or ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Font = New Font("Marlett", 8)
        Size = New Size(21, 21)
    End Sub

#End Region

#Region " Properties "

    Public Property NormalColor As Color
        Get
            Return _NormalColor
        End Get
        Set(value As Color)
            _NormalColor = value
            Invalidate()
        End Set
    End Property

    Public Property HoverColor As Color
        Get
            Return _HoverColor
        End Get
        Set(value As Color)
            _HoverColor = value
            Invalidate()
        End Set
    End Property

    Public Property PushedColor As Color
        Get
            Return _PushedColor
        End Get
        Set(value As Color)
            _PushedColor = value
            Invalidate()
        End Set
    End Property

    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Using B As New Bitmap(Width, Height), G As Graphics = Graphics.FromImage(B)

            With G

                .SmoothingMode = SmoothingMode.HighQuality

                .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

                Select Case State
                    Case MouseMode.NormalMode
                        .FillEllipse(New SolidBrush(NormalColor), 1, 1, 19, 19)
                    Case MouseMode.Hovered
                        Cursor = Cursors.Hand
                        .FillEllipse(New SolidBrush(NormalColor), 1, 1, 19, 19)
                        .DrawEllipse(New Pen(HoverColor, 2), 1, 1, 18, 18)
                    Case MouseMode.Pushed
                        .FillEllipse(New SolidBrush(PushedColor), 1, 1, 19, 19)
                End Select


                .DrawString("0", Font, New SolidBrush(TextColor), New Rectangle(4.6, 2.6, 18, 18))

            End With

            e.Graphics.DrawImage(B, 0, 0)
            G.Dispose() : B.Dispose()

        End Using

    End Sub

#End Region

#Region " Events "

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(21, 21)
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        If FindForm.WindowState = FormWindowState.Normal Then
            FindForm.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseMode.Hovered : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseMode.Pushed : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseMode.Hovered : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseMode.NormalMode : Invalidate()
    End Sub

#End Region

End Class

#End Region

#Region " Maximize "

Public Class EtherealMaximize : Inherits Control

#Region " Variables "

    Private State As MouseMode
    Private _NormalColor As Color = GetHTMLColor("3f2153")
    Private _HoverColor As Color = GetHTMLColor("f0f0f0")
    Private _PushedColor As Color = GetHTMLColor("966bc1")
    Private _TextColor As Color = Color.White

#End Region

#Region " Initialization "

    Sub New()
        SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or _
        ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or _
        ControlStyles.Selectable Or ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Font = New Font("Marlett", 9)
        Size = New Size(22, 22)
    End Sub

#End Region

#Region " Properties "

    Public Property NormalColor As Color
        Get
            Return _NormalColor
        End Get
        Set(value As Color)
            _NormalColor = value
            Invalidate()
        End Set
    End Property

    Public Property HoverColor As Color
        Get
            Return _HoverColor
        End Get
        Set(value As Color)
            _HoverColor = value
            Invalidate()
        End Set
    End Property

    Public Property PushedColor As Color
        Get
            Return _PushedColor
        End Get
        Set(value As Color)
            _PushedColor = value
            Invalidate()
        End Set
    End Property

    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Draw Control "

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Using B As New Bitmap(Width, Height), G As Graphics = Graphics.FromImage(B)

            With G

                .SmoothingMode = SmoothingMode.HighQuality

                .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

                Select Case State
                    Case MouseMode.NormalMode
                        .FillEllipse(New SolidBrush(NormalColor), 1, 1, 19, 19)
                    Case MouseMode.Hovered
                        Cursor = Cursors.Hand
                        .FillEllipse(New SolidBrush(NormalColor), 1, 1, 19, 19)
                        .DrawEllipse(New Pen(HoverColor, 2), 1, 1, 18, 18)
                    Case MouseMode.Pushed
                        .FillEllipse(New SolidBrush(PushedColor), 1, 1, 19, 19)
                End Select

                .DrawString("v", Font, New SolidBrush(TextColor), New Rectangle(3.4, 5, 18, 18))


            End With

            e.Graphics.DrawImage(B.Clone, 0, 0)
            G.Dispose() : B.Dispose()

        End Using

    End Sub

#End Region

#Region " Events "

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(22, 22)
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        If FindForm.WindowState = FormWindowState.Normal Then
            FindForm.WindowState = FormWindowState.Maximized
        Else
            FindForm.WindowState = FormWindowState.Normal
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseMode.Hovered : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseMode.Pushed : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseMode.Hovered : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseMode.NormalMode : Invalidate()
    End Sub

#End Region

End Class

#End Region