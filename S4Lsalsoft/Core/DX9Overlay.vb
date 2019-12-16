Imports System
Imports System.Runtime.InteropServices

Namespace DX9OverlayAPI
    Class DX9Overlay
        Public Const PATH As String = "dx9_overlay.dll"
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function TextCreate(ByVal font As String, ByVal fontSize As Integer, ByVal bBold As Boolean, ByVal bItalic As Boolean, ByVal x As Integer, ByVal y As Integer, ByVal color As Integer, ByVal text As String, ByVal bShadow As Boolean, ByVal bShow As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl, CharSet:=CharSet.Unicode)>
        Public Shared Function TextCreateUnicode(ByVal font As String, ByVal fontSize As Integer, ByVal bBold As Boolean, ByVal bItalic As Boolean, ByVal x As Integer, ByVal y As Integer, ByVal color As Integer, ByVal text As String, ByVal bShadow As Boolean, ByVal bShow As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function TextDestroy(ByVal id As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function TextSetShadow(ByVal id As Integer, ByVal b As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function TextSetShown(ByVal id As Integer, ByVal b As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function TextSetColor(ByVal id As Integer, ByVal color As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function TextSetPos(ByVal id As Integer, ByVal x As Integer, ByVal y As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function TextSetString(ByVal id As Integer, ByVal str As String) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl, CharSet:=CharSet.Unicode)>
        Public Shared Function TextSetStringUnicode(ByVal id As Integer, ByVal str As String) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function TextUpdate(ByVal id As Integer, ByVal font As String, ByVal fontSize As Integer, ByVal bBold As Boolean, ByVal bItalic As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl, CharSet:=CharSet.Unicode)>
        Public Shared Function TextUpdateUnicode(ByVal id As Integer, ByVal font As String, ByVal fontSize As Integer, ByVal bBold As Boolean, ByVal bItalic As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function BoxCreate(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal dwColor As Integer, ByVal bShow As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function BoxDestroy(ByVal id As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function BoxSetShown(ByVal id As Integer, ByVal bShown As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function BoxSetBorder(ByVal id As Integer, ByVal height As Integer, ByVal bShown As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function BoxSetBorderColor(ByVal id As Integer, ByVal dwColor As UInteger) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function BoxSetColor(ByVal id As Integer, ByVal dwColor As UInteger) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function BoxSetHeight(ByVal id As Integer, ByVal height As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function BoxSetPos(ByVal id As Integer, ByVal x As Integer, ByVal y As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function BoxSetWidth(ByVal id As Integer, ByVal width As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function LineCreate(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal width As Integer, ByVal color As Integer, ByVal bShow As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function LineDestroy(ByVal id As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function LineSetShown(ByVal id As Integer, ByVal bShown As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function LineSetColor(ByVal id As Integer, ByVal color As UInteger) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function LineSetWidth(ByVal id As Integer, ByVal width As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function LineSetPos(ByVal id As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function ImageCreate(ByVal path As String, ByVal x As Integer, ByVal y As Integer, ByVal rotation As Integer, ByVal align As Integer, ByVal bShow As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function ImageDestroy(ByVal id As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function ImageSetShown(ByVal id As Integer, ByVal bShown As Boolean) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function ImageSetAlign(ByVal id As Integer, ByVal align As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function ImageSetPos(ByVal id As Integer, ByVal x As Integer, ByVal y As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function ImageSetRotation(ByVal id As Integer, ByVal rotation As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function DestroyAllVisual() As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function ShowAllVisual() As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function HideAllVisual() As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function GetFrameRate() As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function GetScreenSpecs(<Out> ByRef width As Integer, <Out> ByRef height As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function SetCalculationRatio(ByVal width As Integer, ByVal height As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function SetOverlayPriority(ByVal id As Integer, ByVal priority As Integer) As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function Init() As Integer
        End Function
        <DllImport(PATH, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub SetParam(ByVal _szParamName As String, ByVal _szParamValue As String)
        End Sub

        Public Shared Function GetScreenSpecsOverlay() As Point
            Dim x As Integer
            Dim y As Integer
            DX9Overlay.GetScreenSpecs(x, y)
            Return New Point(x, y)
        End Function

        Public Shared Function SetCalculationRatioOverlay(ByVal GetScreen As Point) As Integer
            Dim RatioScreenAB As Integer
            RatioScreenAB = DX9Overlay.SetCalculationRatio(GetScreen.X, GetScreen.Y)
            Return RatioScreenAB
        End Function

    End Class
End Namespace
