<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Loader
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.AnimaForm1 = New S4Lsalsoft.AnimaForm()
        Me.EtherealClose1 = New S4Lsalsoft.EtherealClose()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AnimaForm1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'AnimaForm1
        '
        Me.AnimaForm1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.AnimaForm1.Controls.Add(Me.EtherealClose1)
        Me.AnimaForm1.Controls.Add(Me.Label3)
        Me.AnimaForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnimaForm1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.AnimaForm1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.AnimaForm1.Location = New System.Drawing.Point(0, 0)
        Me.AnimaForm1.Name = "AnimaForm1"
        Me.AnimaForm1.Size = New System.Drawing.Size(628, 382)
        Me.AnimaForm1.TabIndex = 0
        Me.AnimaForm1.Text = "Cheat Loader"
        '
        'EtherealClose1
        '
        Me.EtherealClose1.BackColor = System.Drawing.Color.Transparent
        Me.EtherealClose1.Font = New System.Drawing.Font("Marlett", 8.0!)
        Me.EtherealClose1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.EtherealClose1.Location = New System.Drawing.Point(605, 3)
        Me.EtherealClose1.Name = "EtherealClose1"
        Me.EtherealClose1.NormalColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.EtherealClose1.PushedColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.EtherealClose1.Size = New System.Drawing.Size(20, 20)
        Me.EtherealClose1.TabIndex = 40
        Me.EtherealClose1.Text = "EtherealClose1"
        Me.EtherealClose1.TextColor = System.Drawing.Color.White
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(12, 312)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 61)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Status : " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "They wait for the game"
        '
        'Loader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 382)
        Me.Controls.Add(Me.AnimaForm1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Loader"
        Me.Text = "Form1"
        Me.AnimaForm1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AnimaForm1 As S4Lsalsoft.AnimaForm
    Friend WithEvents EtherealClose1 As S4Lsalsoft.EtherealClose
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
