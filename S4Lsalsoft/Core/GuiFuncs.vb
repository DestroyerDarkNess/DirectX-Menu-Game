Imports System.IO

Namespace Cheat

    Public Class GuiFuncs

#Region " Declarations "

        Shared TempImage As String = Path.GetTempPath() & "Dxgui.png"

#End Region


#Region " Methods "

        Public Shared Function colorFormat(ByVal c As Color) As Integer
            Return c.ToArgb
        End Function

        Public Shared Function CreateFormGui(ByVal SuperiorBar As Integer, ByVal Scolor As Brush, ByVal Container As Integer, ByVal Ccolor As Brush, ByVal Size As Point) As String
            Dim flag As New Bitmap(Size.X, Size.Y)
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

    End Class

End Namespace

