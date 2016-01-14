<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPetRecords
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
        Me.lblPetName = New System.Windows.Forms.Label()
        Me.txtPetName = New System.Windows.Forms.TextBox()
        Me.txtOwnerName = New System.Windows.Forms.TextBox()
        Me.lblOwnerName = New System.Windows.Forms.Label()
        Me.txtSpecies = New System.Windows.Forms.TextBox()
        Me.lblSpecies = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblAgeUnits = New System.Windows.Forms.Label()
        Me.lstAgeUnits = New System.Windows.Forms.ListBox()
        Me.chkIsNeutered = New System.Windows.Forms.CheckBox()
        Me.txtLastVisit = New System.Windows.Forms.TextBox()
        Me.lblLastVisit = New System.Windows.Forms.Label()
        Me.btnGoLeft = New System.Windows.Forms.Button()
        Me.btnNewRecord = New System.Windows.Forms.Button()
        Me.btnGoRight = New System.Windows.Forms.Button()
        Me.btnSaveRecord = New System.Windows.Forms.Button()
        Me.btnCancelNewRecord = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPetName
        '
        Me.lblPetName.AutoSize = True
        Me.lblPetName.Location = New System.Drawing.Point(12, 37)
        Me.lblPetName.Name = "lblPetName"
        Me.lblPetName.Size = New System.Drawing.Size(57, 13)
        Me.lblPetName.TabIndex = 0
        Me.lblPetName.Text = "Pet Name:"
        '
        'txtPetName
        '
        Me.txtPetName.Location = New System.Drawing.Point(75, 34)
        Me.txtPetName.Name = "txtPetName"
        Me.txtPetName.Size = New System.Drawing.Size(231, 20)
        Me.txtPetName.TabIndex = 1
        '
        'txtOwnerName
        '
        Me.txtOwnerName.Location = New System.Drawing.Point(474, 34)
        Me.txtOwnerName.Name = "txtOwnerName"
        Me.txtOwnerName.Size = New System.Drawing.Size(255, 20)
        Me.txtOwnerName.TabIndex = 3
        '
        'lblOwnerName
        '
        Me.lblOwnerName.AutoSize = True
        Me.lblOwnerName.Location = New System.Drawing.Point(396, 37)
        Me.lblOwnerName.Name = "lblOwnerName"
        Me.lblOwnerName.Size = New System.Drawing.Size(72, 13)
        Me.lblOwnerName.TabIndex = 2
        Me.lblOwnerName.Text = "Owner Name:"
        '
        'txtSpecies
        '
        Me.txtSpecies.Location = New System.Drawing.Point(75, 117)
        Me.txtSpecies.Name = "txtSpecies"
        Me.txtSpecies.Size = New System.Drawing.Size(131, 20)
        Me.txtSpecies.TabIndex = 5
        '
        'lblSpecies
        '
        Me.lblSpecies.AutoSize = True
        Me.lblSpecies.Location = New System.Drawing.Point(21, 120)
        Me.lblSpecies.Name = "lblSpecies"
        Me.lblSpecies.Size = New System.Drawing.Size(48, 13)
        Me.lblSpecies.TabIndex = 4
        Me.lblSpecies.Text = "Species:"
        '
        'txtAge
        '
        Me.txtAge.Location = New System.Drawing.Point(331, 117)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(131, 20)
        Me.txtAge.TabIndex = 7
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.Location = New System.Drawing.Point(277, 120)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(29, 13)
        Me.lblAge.TabIndex = 6
        Me.lblAge.Text = "Age:"
        '
        'lblAgeUnits
        '
        Me.lblAgeUnits.AutoSize = True
        Me.lblAgeUnits.Location = New System.Drawing.Point(521, 120)
        Me.lblAgeUnits.Name = "lblAgeUnits"
        Me.lblAgeUnits.Size = New System.Drawing.Size(56, 13)
        Me.lblAgeUnits.TabIndex = 8
        Me.lblAgeUnits.Text = "Age Units:"
        '
        'lstAgeUnits
        '
        Me.lstAgeUnits.FormattingEnabled = True
        Me.lstAgeUnits.Location = New System.Drawing.Point(583, 117)
        Me.lstAgeUnits.Name = "lstAgeUnits"
        Me.lstAgeUnits.Size = New System.Drawing.Size(120, 30)
        Me.lstAgeUnits.TabIndex = 9
        '
        'chkIsNeutered
        '
        Me.chkIsNeutered.AutoSize = True
        Me.chkIsNeutered.Location = New System.Drawing.Point(24, 209)
        Me.chkIsNeutered.Name = "chkIsNeutered"
        Me.chkIsNeutered.Size = New System.Drawing.Size(117, 17)
        Me.chkIsNeutered.TabIndex = 11
        Me.chkIsNeutered.Text = "Spayed/Neutered?"
        Me.chkIsNeutered.UseVisualStyleBackColor = True
        '
        'txtLastVisit
        '
        Me.txtLastVisit.Location = New System.Drawing.Point(356, 207)
        Me.txtLastVisit.Name = "txtLastVisit"
        Me.txtLastVisit.Size = New System.Drawing.Size(231, 20)
        Me.txtLastVisit.TabIndex = 13
        '
        'lblLastVisit
        '
        Me.lblLastVisit.AutoSize = True
        Me.lblLastVisit.Location = New System.Drawing.Point(293, 210)
        Me.lblLastVisit.Name = "lblLastVisit"
        Me.lblLastVisit.Size = New System.Drawing.Size(52, 13)
        Me.lblLastVisit.TabIndex = 12
        Me.lblLastVisit.Text = "Last Visit:"
        '
        'btnGoLeft
        '
        Me.btnGoLeft.Location = New System.Drawing.Point(40, 290)
        Me.btnGoLeft.Name = "btnGoLeft"
        Me.btnGoLeft.Size = New System.Drawing.Size(117, 40)
        Me.btnGoLeft.TabIndex = 14
        Me.btnGoLeft.Text = "<<"
        Me.btnGoLeft.UseVisualStyleBackColor = True
        '
        'btnNewRecord
        '
        Me.btnNewRecord.Location = New System.Drawing.Point(213, 290)
        Me.btnNewRecord.Name = "btnNewRecord"
        Me.btnNewRecord.Size = New System.Drawing.Size(334, 40)
        Me.btnNewRecord.TabIndex = 15
        Me.btnNewRecord.Text = "Add New Pet Record"
        Me.btnNewRecord.UseVisualStyleBackColor = True
        '
        'btnGoRight
        '
        Me.btnGoRight.Location = New System.Drawing.Point(599, 290)
        Me.btnGoRight.Name = "btnGoRight"
        Me.btnGoRight.Size = New System.Drawing.Size(117, 40)
        Me.btnGoRight.TabIndex = 16
        Me.btnGoRight.Text = ">>"
        Me.btnGoRight.UseVisualStyleBackColor = True
        '
        'btnSaveRecord
        '
        Me.btnSaveRecord.Location = New System.Drawing.Point(40, 290)
        Me.btnSaveRecord.Name = "btnSaveRecord"
        Me.btnSaveRecord.Size = New System.Drawing.Size(117, 40)
        Me.btnSaveRecord.TabIndex = 17
        Me.btnSaveRecord.Text = "Save"
        Me.btnSaveRecord.UseVisualStyleBackColor = True
        Me.btnSaveRecord.Visible = False
        '
        'btnCancelNewRecord
        '
        Me.btnCancelNewRecord.Location = New System.Drawing.Point(599, 290)
        Me.btnCancelNewRecord.Name = "btnCancelNewRecord"
        Me.btnCancelNewRecord.Size = New System.Drawing.Size(130, 40)
        Me.btnCancelNewRecord.TabIndex = 18
        Me.btnCancelNewRecord.Text = "Cancel"
        Me.btnCancelNewRecord.UseVisualStyleBackColor = True
        Me.btnCancelNewRecord.Visible = False
        '
        'frmPetRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 351)
        Me.Controls.Add(Me.btnCancelNewRecord)
        Me.Controls.Add(Me.btnSaveRecord)
        Me.Controls.Add(Me.btnGoRight)
        Me.Controls.Add(Me.btnNewRecord)
        Me.Controls.Add(Me.btnGoLeft)
        Me.Controls.Add(Me.txtLastVisit)
        Me.Controls.Add(Me.lblLastVisit)
        Me.Controls.Add(Me.chkIsNeutered)
        Me.Controls.Add(Me.lstAgeUnits)
        Me.Controls.Add(Me.lblAgeUnits)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.txtSpecies)
        Me.Controls.Add(Me.lblSpecies)
        Me.Controls.Add(Me.txtOwnerName)
        Me.Controls.Add(Me.lblOwnerName)
        Me.Controls.Add(Me.txtPetName)
        Me.Controls.Add(Me.lblPetName)
        Me.MaximizeBox = False
        Me.Name = "frmPetRecords"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPetName As Label
    Friend WithEvents txtPetName As TextBox
    Friend WithEvents txtOwnerName As TextBox
    Friend WithEvents lblOwnerName As Label
    Friend WithEvents txtSpecies As TextBox
    Friend WithEvents lblSpecies As Label
    Friend WithEvents txtAge As TextBox
    Friend WithEvents lblAge As Label
    Friend WithEvents lblAgeUnits As Label
    Friend WithEvents lstAgeUnits As ListBox
    Friend WithEvents chkIsNeutered As CheckBox
    Friend WithEvents txtLastVisit As TextBox
    Friend WithEvents lblLastVisit As Label
    Friend WithEvents btnGoLeft As Button
    Friend WithEvents btnNewRecord As Button
    Friend WithEvents btnGoRight As Button
    Friend WithEvents btnSaveRecord As Button
    Friend WithEvents btnCancelNewRecord As Button
End Class
