<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.OpenScript = New System.Windows.Forms.OpenFileDialog
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ScriptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AudioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LectureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PauseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VideoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Grid = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SaveAsScript = New System.Windows.Forms.SaveFileDialog
        Me.OpenSound = New System.Windows.Forms.OpenFileDialog
        Me.DialogueBox = New System.Windows.Forms.TextBox
        Me.StartTimeBox = New System.Windows.Forms.MaskedTextBox
        Me.Audio = New System.Windows.Forms.GroupBox
        Me.HScrollAudio2 = New System.Windows.Forms.HScrollBar
        Me.AudioEditor = New AxNCTAUDIOEDITORLib.AxAudioEditor
        Me.VScrollAudio = New System.Windows.Forms.VScrollBar
        Me.HScrollAudio = New System.Windows.Forms.HScrollBar
        Me.OpenVideo = New System.Windows.Forms.OpenFileDialog
        Me.EndTimeBox = New System.Windows.Forms.MaskedTextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.LoadBar = New System.Windows.Forms.ToolStripProgressBar
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ControlsBox = New System.Windows.Forms.GroupBox
        Me.LayerBox = New System.Windows.Forms.TextBox
        Me.VertBox = New System.Windows.Forms.MaskedTextBox
        Me.RightBox = New System.Windows.Forms.MaskedTextBox
        Me.LeftBox = New System.Windows.Forms.MaskedTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TypeSection = New System.Windows.Forms.ComboBox
        Me.ActorSelection = New System.Windows.Forms.ComboBox
        Me.StyleSelection = New System.Windows.Forms.ComboBox
        Me.TotalTimeBox = New System.Windows.Forms.MaskedTextBox
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Audio.SuspendLayout()
        CType(Me.AudioEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ControlsBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenScript
        '
        Me.OpenScript.FileName = "OpenFileDialog1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScriptToolStripMenuItem, Me.AudioToolStripMenuItem, Me.VideoToolStripMenuItem, Me.OptionToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1016, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ScriptToolStripMenuItem
        '
        Me.ScriptToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.OpenToolStripMenuItem1, Me.ToolStripSeparator1, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator2, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.ScriptToolStripMenuItem.Name = "ScriptToolStripMenuItem"
        Me.ScriptToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ScriptToolStripMenuItem.Text = "Script"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.OpenToolStripMenuItem.Text = "New"
        '
        'OpenToolStripMenuItem1
        '
        Me.OpenToolStripMenuItem1.Name = "OpenToolStripMenuItem1"
        Me.OpenToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
        Me.OpenToolStripMenuItem1.Text = "Open"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(109, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save as"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(109, 6)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(109, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AudioToolStripMenuItem
        '
        Me.AudioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem2, Me.CloseToolStripMenuItem, Me.LectureToolStripMenuItem, Me.ToolStripMenuItem1, Me.PauseToolStripMenuItem, Me.StopToolStripMenuItem})
        Me.AudioToolStripMenuItem.Name = "AudioToolStripMenuItem"
        Me.AudioToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.AudioToolStripMenuItem.Text = "Audio"
        '
        'OpenToolStripMenuItem2
        '
        Me.OpenToolStripMenuItem2.Name = "OpenToolStripMenuItem2"
        Me.OpenToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.OpenToolStripMenuItem2.Text = "Open"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'LectureToolStripMenuItem
        '
        Me.LectureToolStripMenuItem.Name = "LectureToolStripMenuItem"
        Me.LectureToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LectureToolStripMenuItem.Text = "lecture -> fin"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem1.Text = "lecture selection"
        '
        'PauseToolStripMenuItem
        '
        Me.PauseToolStripMenuItem.Name = "PauseToolStripMenuItem"
        Me.PauseToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PauseToolStripMenuItem.Text = "pause"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.StopToolStripMenuItem.Text = "stop"
        '
        'VideoToolStripMenuItem
        '
        Me.VideoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem3})
        Me.VideoToolStripMenuItem.Name = "VideoToolStripMenuItem"
        Me.VideoToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.VideoToolStripMenuItem.Text = "Video"
        '
        'OpenToolStripMenuItem3
        '
        Me.OpenToolStripMenuItem3.Name = "OpenToolStripMenuItem3"
        Me.OpenToolStripMenuItem3.Size = New System.Drawing.Size(98, 22)
        Me.OpenToolStripMenuItem3.Text = "open"
        '
        'OptionToolStripMenuItem
        '
        Me.OptionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreferencesToolStripMenuItem})
        Me.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem"
        Me.OptionToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.OptionToolStripMenuItem.Text = "Option"
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.PreferencesToolStripMenuItem.Text = "Preferences"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.Grid)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 396)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1016, 313)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Script"
        '
        'Grid
        '
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grid.BackgroundColor = System.Drawing.Color.CornflowerBlue
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid.DefaultCellStyle = DataGridViewCellStyle7
        Me.Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Grid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Grid.Location = New System.Drawing.Point(3, 16)
        Me.Grid.Name = "Grid"
        Me.Grid.RowHeadersVisible = False
        Me.Grid.RowHeadersWidth = 25
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Grid.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(1010, 294)
        Me.Grid.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "#"
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 21
        '
        'Column2
        '
        Me.Column2.HeaderText = "Collisions"
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 56
        '
        'Column3
        '
        Me.Column3.HeaderText = "Type"
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 37
        '
        'Column4
        '
        Me.Column4.HeaderText = "Layer"
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 39
        '
        'Column5
        '
        Me.Column5.HeaderText = "Start"
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Width = 35
        '
        'Column6
        '
        Me.Column6.HeaderText = "End"
        Me.Column6.Name = "Column6"
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Width = 32
        '
        'Column7
        '
        Me.Column7.HeaderText = "Style"
        Me.Column7.Name = "Column7"
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column7.Width = 36
        '
        'Column8
        '
        Me.Column8.HeaderText = "Actor"
        Me.Column8.Name = "Column8"
        Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column8.Width = 38
        '
        'Column9
        '
        Me.Column9.HeaderText = "Left"
        Me.Column9.Name = "Column9"
        Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column9.Width = 31
        '
        'Column10
        '
        Me.Column10.HeaderText = "Right"
        Me.Column10.Name = "Column10"
        Me.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column10.Width = 38
        '
        'Column11
        '
        Me.Column11.HeaderText = "Vert"
        Me.Column11.Name = "Column11"
        Me.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column11.Width = 32
        '
        'Column12
        '
        Me.Column12.HeaderText = "Effect"
        Me.Column12.Name = "Column12"
        Me.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column12.Width = 41
        '
        'Column13
        '
        Me.Column13.HeaderText = "Dialogue"
        Me.Column13.Name = "Column13"
        Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column13.Width = 55
        '
        'OpenSound
        '
        Me.OpenSound.FileName = "OpenFileDialog1"
        '
        'DialogueBox
        '
        Me.DialogueBox.AcceptsReturn = True
        Me.DialogueBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DialogueBox.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DialogueBox.Location = New System.Drawing.Point(6, 96)
        Me.DialogueBox.Multiline = True
        Me.DialogueBox.Name = "DialogueBox"
        Me.DialogueBox.Size = New System.Drawing.Size(732, 67)
        Me.DialogueBox.TabIndex = 9
        '
        'StartTimeBox
        '
        Me.StartTimeBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StartTimeBox.BeepOnError = True
        Me.StartTimeBox.Culture = New System.Globalization.CultureInfo("")
        Me.StartTimeBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.StartTimeBox.Location = New System.Drawing.Point(638, 15)
        Me.StartTimeBox.Mask = "0:00:00.00"
        Me.StartTimeBox.Name = "StartTimeBox"
        Me.StartTimeBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
        Me.StartTimeBox.Size = New System.Drawing.Size(100, 20)
        Me.StartTimeBox.TabIndex = 15
        Me.StartTimeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.StartTimeBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Audio
        '
        Me.Audio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Audio.Controls.Add(Me.HScrollAudio2)
        Me.Audio.Controls.Add(Me.AudioEditor)
        Me.Audio.Controls.Add(Me.VScrollAudio)
        Me.Audio.Controls.Add(Me.HScrollAudio)
        Me.Audio.Location = New System.Drawing.Point(0, 27)
        Me.Audio.Name = "Audio"
        Me.Audio.Size = New System.Drawing.Size(1013, 188)
        Me.Audio.TabIndex = 17
        Me.Audio.TabStop = False
        Me.Audio.Text = "Audio"
        '
        'HScrollAudio2
        '
        Me.HScrollAudio2.Location = New System.Drawing.Point(3, 168)
        Me.HScrollAudio2.Name = "HScrollAudio2"
        Me.HScrollAudio2.Size = New System.Drawing.Size(789, 17)
        Me.HScrollAudio2.TabIndex = 10001
        '
        'AudioEditor
        '
        Me.AudioEditor.Enabled = True
        Me.AudioEditor.Location = New System.Drawing.Point(3, 16)
        Me.AudioEditor.Name = "AudioEditor"
        Me.AudioEditor.OcxState = CType(resources.GetObject("AudioEditor.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AudioEditor.Size = New System.Drawing.Size(192, 192)
        Me.AudioEditor.TabIndex = 5
        '
        'VScrollAudio
        '
        Me.VScrollAudio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollAudio.Location = New System.Drawing.Point(993, 16)
        Me.VScrollAudio.Maximum = 109
        Me.VScrollAudio.Name = "VScrollAudio"
        Me.VScrollAudio.Size = New System.Drawing.Size(17, 152)
        Me.VScrollAudio.TabIndex = 3
        Me.VScrollAudio.Value = 50
        '
        'HScrollAudio
        '
        Me.HScrollAudio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.HScrollAudio.LargeChange = 1500
        Me.HScrollAudio.Location = New System.Drawing.Point(792, 168)
        Me.HScrollAudio.Maximum = 120000
        Me.HScrollAudio.Minimum = 10000
        Me.HScrollAudio.Name = "HScrollAudio"
        Me.HScrollAudio.Size = New System.Drawing.Size(218, 17)
        Me.HScrollAudio.SmallChange = 1000
        Me.HScrollAudio.TabIndex = 10000
        Me.HScrollAudio.Value = 10000
        '
        'OpenVideo
        '
        Me.OpenVideo.FileName = "OpenVideo"
        '
        'EndTimeBox
        '
        Me.EndTimeBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EndTimeBox.BeepOnError = True
        Me.EndTimeBox.Culture = New System.Globalization.CultureInfo("")
        Me.EndTimeBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.EndTimeBox.Location = New System.Drawing.Point(638, 41)
        Me.EndTimeBox.Mask = "0:00:00.00"
        Me.EndTimeBox.Name = "EndTimeBox"
        Me.EndTimeBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
        Me.EndTimeBox.Size = New System.Drawing.Size(100, 20)
        Me.EndTimeBox.TabIndex = 20
        Me.EndTimeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EndTimeBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus, Me.LoadBar, Me.StatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 712)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1016, 22)
        Me.StatusStrip1.TabIndex = 21
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'LoadBar
        '
        Me.LoadBar.Name = "LoadBar"
        Me.LoadBar.Size = New System.Drawing.Size(100, 16)
        Me.LoadBar.Visible = False
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'ControlsBox
        '
        Me.ControlsBox.Controls.Add(Me.LayerBox)
        Me.ControlsBox.Controls.Add(Me.VertBox)
        Me.ControlsBox.Controls.Add(Me.RightBox)
        Me.ControlsBox.Controls.Add(Me.LeftBox)
        Me.ControlsBox.Controls.Add(Me.Label4)
        Me.ControlsBox.Controls.Add(Me.Label3)
        Me.ControlsBox.Controls.Add(Me.Label2)
        Me.ControlsBox.Controls.Add(Me.Label1)
        Me.ControlsBox.Controls.Add(Me.Panel1)
        Me.ControlsBox.Controls.Add(Me.TypeSection)
        Me.ControlsBox.Controls.Add(Me.StartTimeBox)
        Me.ControlsBox.Controls.Add(Me.ActorSelection)
        Me.ControlsBox.Controls.Add(Me.DialogueBox)
        Me.ControlsBox.Controls.Add(Me.EndTimeBox)
        Me.ControlsBox.Controls.Add(Me.StyleSelection)
        Me.ControlsBox.Controls.Add(Me.TotalTimeBox)
        Me.ControlsBox.Location = New System.Drawing.Point(135, 221)
        Me.ControlsBox.Name = "ControlsBox"
        Me.ControlsBox.Size = New System.Drawing.Size(744, 169)
        Me.ControlsBox.TabIndex = 24
        Me.ControlsBox.TabStop = False
        Me.ControlsBox.Text = "Controls"
        '
        'LayerBox
        '
        Me.LayerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LayerBox.Location = New System.Drawing.Point(140, 28)
        Me.LayerBox.Name = "LayerBox"
        Me.LayerBox.Size = New System.Drawing.Size(35, 20)
        Me.LayerBox.TabIndex = 37
        Me.LayerBox.Text = "0"
        Me.LayerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'VertBox
        '
        Me.VertBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VertBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.VertBox.Location = New System.Drawing.Point(83, 28)
        Me.VertBox.Mask = "0000"
        Me.VertBox.Name = "VertBox"
        Me.VertBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
        Me.VertBox.Size = New System.Drawing.Size(35, 20)
        Me.VertBox.TabIndex = 36
        Me.VertBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RightBox
        '
        Me.RightBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RightBox.Location = New System.Drawing.Point(49, 28)
        Me.RightBox.Mask = "0000"
        Me.RightBox.Name = "RightBox"
        Me.RightBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
        Me.RightBox.Size = New System.Drawing.Size(35, 20)
        Me.RightBox.TabIndex = 35
        Me.RightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LeftBox
        '
        Me.LeftBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LeftBox.Location = New System.Drawing.Point(15, 28)
        Me.LeftBox.Mask = "0000"
        Me.LeftBox.Name = "LeftBox"
        Me.LeftBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(48)
        Me.LeftBox.Size = New System.Drawing.Size(35, 20)
        Me.LeftBox.TabIndex = 34
        Me.LeftBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(141, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Layer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(87, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Vert"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Right"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Left"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(193, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(302, 77)
        Me.Panel1.TabIndex = 29
        '
        'TypeSection
        '
        Me.TypeSection.FormattingEnabled = True
        Me.TypeSection.Items.AddRange(New Object() {"Dialogue", "Comment", "Picture", "Movie", "Sound", "Command"})
        Me.TypeSection.Location = New System.Drawing.Point(30, 66)
        Me.TypeSection.Name = "TypeSection"
        Me.TypeSection.Size = New System.Drawing.Size(121, 21)
        Me.TypeSection.TabIndex = 28
        Me.TypeSection.Text = "Dialogue"
        '
        'ActorSelection
        '
        Me.ActorSelection.FormattingEnabled = True
        Me.ActorSelection.Location = New System.Drawing.Point(501, 54)
        Me.ActorSelection.Name = "ActorSelection"
        Me.ActorSelection.Size = New System.Drawing.Size(121, 21)
        Me.ActorSelection.TabIndex = 23
        '
        'StyleSelection
        '
        Me.StyleSelection.FormattingEnabled = True
        Me.StyleSelection.Items.AddRange(New Object() {"Default"})
        Me.StyleSelection.Location = New System.Drawing.Point(501, 27)
        Me.StyleSelection.Name = "StyleSelection"
        Me.StyleSelection.Size = New System.Drawing.Size(121, 21)
        Me.StyleSelection.TabIndex = 22
        Me.StyleSelection.Text = "Default"
        '
        'TotalTimeBox
        '
        Me.TotalTimeBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TotalTimeBox.BeepOnError = True
        Me.TotalTimeBox.Culture = New System.Globalization.CultureInfo("")
        Me.TotalTimeBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.TotalTimeBox.Location = New System.Drawing.Point(638, 67)
        Me.TotalTimeBox.Mask = "0:00:00.00"
        Me.TotalTimeBox.Name = "TotalTimeBox"
        Me.TotalTimeBox.ReadOnly = True
        Me.TotalTimeBox.Size = New System.Drawing.Size(100, 20)
        Me.TotalTimeBox.TabIndex = 21
        Me.TotalTimeBox.Text = "0000000"
        Me.TotalTimeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotalTimeBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.ControlsBox)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Audio)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Main"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expressub"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Audio.ResumeLayout(False)
        CType(Me.AudioEditor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ControlsBox.ResumeLayout(False)
        Me.ControlsBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenScript As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ScriptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AudioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SaveAsScript As System.Windows.Forms.SaveFileDialog
    Friend WithEvents LectureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PauseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenSound As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DialogueBox As System.Windows.Forms.TextBox
    Friend WithEvents VideoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartTimeBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents OptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Audio As System.Windows.Forms.GroupBox
    Friend WithEvents OpenVideo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PreferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EndTimeBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LoadBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents VScrollAudio As System.Windows.Forms.VScrollBar
    Friend WithEvents HScrollAudio As System.Windows.Forms.HScrollBar
    Friend WithEvents AudioEditor As AxNCTAUDIOEDITORLib.AxAudioEditor
    Friend WithEvents HScrollAudio2 As System.Windows.Forms.HScrollBar
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ControlsBox As System.Windows.Forms.GroupBox
    Friend WithEvents ActorSelection As System.Windows.Forms.ComboBox
    Friend WithEvents StyleSelection As System.Windows.Forms.ComboBox
    Friend WithEvents TotalTimeBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TypeSection As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LeftBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LayerBox As System.Windows.Forms.TextBox
    Friend WithEvents VertBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents RightBox As System.Windows.Forms.MaskedTextBox
End Class
