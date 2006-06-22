Imports Microsoft.DirectX.AudioVideoPlayback
Imports System.IO

Public Class Main
    Public FramePerPixel, MouseClickGauche, XClic, Frame, IndexSelectionListview As Integer
    Public video As Video

    Sub ResizeGrid()
        Dim i As Integer
        Dim largeur As Integer

        For i = 0 To 11
            Grid.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.ColumnHeader)
            largeur += Grid.Columns.Item(i).Width
        Next

        Grid.Columns.Item(12).Width = (Grid.Width - 3) - largeur
        Grid.Columns.Item(12).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft

    End Sub

    Sub InitVariable()

        InitScriptInfo()
        InitStyles()
        InitEvent()

    End Sub

    Private Sub InitScriptInfo()
        Dim i As Integer
        Dim ScriptInfo() As String = {"Title:", "Original Script:", "Original Translation:", _
        "Original Editing:", "Original Timing:", "Synch Point:", "Script Updated By:", _
        "Update Details:", "Script Type: v4.00+", "Collisions: Normal", "PlayResX: 640", _
        "PlayResY: 480", "PlayDepth: 0", "Timer: 100.0000", "WrapStyle: 0"}

        For i = 0 To 14
            DecoupageScriptInfo(ScriptInfo(i))
        Next

    End Sub

    Private Sub InitStyles()
        Dim Style As String

        Style = "Format: Name, Fontname, Fontsize, PrimaryColour," _
        & "SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut," _
        & "ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment," _
        & "MarginL, MarginR, MarginV, Encoding"

        DecoupageStyles(Style)

        Style = "Style: Default,Arial,25,&H00FFFFFF,&H00000000,&H00000000,&H00000000," _
        & "0,0,0,0,100,100,0,0,1,2,2,2,20,20,30,0"

        DecoupageStyles(Style)

    End Sub

    Private Sub InitEvent()
        Dim Events As String

        Events = "Format: Layer, Start, End, Style, Actor, MarginL, MarginR, MarginV," _
        & "Effect, Text"

        DecoupageEvents(Events)

        Events = "Dialogue: 0,0:00:00.00,0:00:00.00,Default,,0000,0000," _
        & "0000,,"

        DecoupageEvents(Events)

    End Sub

    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With AudioEditor
            .MouseEventsEnabled = False
            .ScaleY.Visible = False
            .Channels.Num = 1
            .Channels.Visible = True
            .Channels.Num = 2
            .Channels.Visible = False
            .TypeBorder = 4
            .ScaleX.Type = 2
        End With

        ResizeGrid()
        InitVariable()

        If Environment.GetCommandLineArgs().Length > 1 Then
            Dim Fi As FileInfo = New FileInfo(Environment.GetCommandLineArgs(1))

            Select Case Fi.Extension

                Case ".ass"
                    lectureAss(Environment.GetCommandLineArgs(1))
                    'Case ".txt"
                    'lectureTxt(OpenScript.FileName)

            End Select

        End If

    End Sub

    Private Sub OpenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem1.Click

        With OpenScript

            .FileName = ""
            .Title = "Open File ..."
            .Filter = "ASS Files (*.ass)|*.ass" & _
             "|TXT Files (*.txt)|*.txt"
            .Multiselect = False
            .CheckFileExists = True

        End With

        If OpenScript.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Fi As FileInfo = New FileInfo(OpenScript.FileName)

            Select Case Fi.Extension

                Case ".ass"
                    lectureAss(OpenScript.FileName)
                    'Case ".txt"
                    'lectureTxt(OpenScript.FileName)

            End Select

        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        With SaveAsScript

            .FileName = ""
            .Title = "Save As File ..."
            .OverwritePrompt = True
            .DefaultExt = "ass"
            .Filter = "ASS Files (*.ass)|*.ass"

        End With

        If SaveAsScript.ShowDialog = Windows.Forms.DialogResult.OK Then
            EnregistrementAss(SaveAsScript.FileName)
        End If
    End Sub

    Private Sub OpenToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem2.Click
        AudioEditor.Focus()
        With OpenSound
            .FileName = ""
            .Title = "Open File ..."
            .Filter = "Wav Files (*.wav)|*.wav"
            .Filter = .Filter & "|MPEG Files (*.mp3;*.mp2;*.mpeg)|*.mp3;*.mp2;*.mpeg"
            .Filter = .Filter & "|OggVorbis Files (*.ogg)|*.ogg"
            .Filter = .Filter & "|AVI Files (*.avi)|*.avi"
            .Filter = .Filter & "|G.72x Files (*.g721;*.g723;*.g726)|*.*.g721,*.g723,*.g726"
            .Filter = .Filter & "|VOX Files (*.vox)|*.vox"
            .Filter = .Filter & "|RAW Files (*.raw; *.pcm)|*.raw;*.pcm"
            .Filter = .Filter & "|WMA Files (*.wma)|*.wma"
            .Filter = .Filter & "|CD Audio (*.cda)|*.cda"
            .CheckFileExists = True
        End With

        If OpenSound.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                AudioEditor.Open(OpenSound.FileName)
            Catch
                MsgBox("Format not allowed")
            End Try
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        AudioEditor.Close()
    End Sub

    Private Sub LectureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LectureToolStripMenuItem.Click
        AudioEditor.Play(NCTAUDIOEDITOR2Lib.PlayTypeConstants.PLAYTOEND)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        AudioEditor.Play()
    End Sub

    Private Sub AudioEditor_BlockOperation(ByVal sender As Object, ByVal e As AxNCTAUDIOEDITOR2Lib._IAudioEditor2Events_BlockOperationEvent) Handles AudioEditor.BlockOperation
        If (e.percent >= 0 And e.percent < 100 And LoadBar.Visible = False) Then LoadBar.Visible = True
        Select Case AudioEditor.Status
            Case 1 : LblStatus.Text = "Play"
            Case 2 : LblStatus.Text = "Record"
            Case 3 : LblStatus.Text = "Load"
            Case 4 : LblStatus.Text = "Save"
            Case 5 : LblStatus.Text = "Pause"
            Case 6 : LblStatus.Text = "Copy"
            Case 7 : LblStatus.Text = "Reset Waveform"
            Case 10 : LblStatus.Text = "Invert"
            Case 11 : LblStatus.Text = "Reverse"
            Case 12 : LblStatus.Text = "Normalize"
            Case 13 : LblStatus.Text = "Silence"
            Case 14 : LblStatus.Text = "Stretch"
            Case 15 : LblStatus.Text = "Trim"
            Case 16 : LblStatus.Text = "Delete Silence"
            Case 17 : LblStatus.Text = "Delete"
            Case 18 : LblStatus.Text = "Insert Silence"
            Case 19 : LblStatus.Text = "Paste Mix"
            Case 20 : LblStatus.Text = "Paste"
            Case 21 : LblStatus.Text = "ConvertSimpleType"
            Case 30 : LblStatus.Text = "Delay"
            Case 31 : LblStatus.Text = "Phaser"
            Case 32 : LblStatus.Text = "Flanger"
            Case 33 : LblStatus.Text = "Reverb"
            Case 40 : LblStatus.Text = "FFT Filter"
            Case 41 : LblStatus.Text = "Low Pass Filter"
            Case 42 : LblStatus.Text = "Band Pass Filter"
            Case 43 : LblStatus.Text = "High Pass Filter"
            Case 44 : LblStatus.Text = "Notch Filter"
            Case 45 : LblStatus.Text = "Low Shelf  Filter"
            Case 46 : LblStatus.Text = "High Shelf Filter"
            Case 47 : LblStatus.Text = "PeakEQFilter"
            Case 50 : LblStatus.Text = "Amplify"
            Case 51 : LblStatus.Text = "Fade"
            Case 52 : LblStatus.Text = "Vibrato"
            Case 53 : LblStatus.Text = "Add Noise"
            Case 54 : LblStatus.Text = "Advanced Mix"
            Case 55 : LblStatus.Text = "Mix Stereo Channels"
            Case 56 : LblStatus.Text = "Envelope"
            Case 57 : LblStatus.Text = "Compressor"
            Case 58 : LblStatus.Text = "Expander"
            Case 60 : LblStatus.Text = "Equalizer"
            Case Else : LblStatus.Text = ""
        End Select
        LoadBar.Value = e.percent
        Application.DoEvents()
    End Sub

    Private Sub AudioEditor_EndOperation(ByVal sender As Object, ByVal e As System.EventArgs) Handles AudioEditor.EndOperation
        LoadBar.Visible = False
        AudioEditor.Position.EndView = AudioEditor.Position.SecToSamples(10000)
        LblStatus.Text = "Audio load sucessfully"
        FramePerPixel = (AudioEditor.Position.EndView - AudioEditor.Position.StartView) / (AudioEditor.Width - 2)
    End Sub

    Private Sub AudioEditor_MouseDownEvent(ByVal sender As Object, ByVal e As AxNCTAUDIOEDITOR2Lib._IAudioEditor2Events_MouseDownEvent) Handles AudioEditor.MouseDownEvent
        XClic = e.x

        If (e.button = 1) Then 'bouton gauche
            Timer1.Enabled = True
            MouseClickGauche = 1
            Frame = (AudioEditor.Position.StartView + (FramePerPixel * e.x))
            AudioStartSelect(Frame)
        End If

        If (e.button = 2) Then 'bouton droit
            AudioEndSelect(AudioEditor.Position.StartView + (FramePerPixel * e.x))
        End If

    End Sub

    Private Sub AudioEditor_MouseMoveEvent(ByVal sender As Object, ByVal e As AxNCTAUDIOEDITOR2Lib._IAudioEditor2Events_MouseMoveEvent) Handles AudioEditor.MouseMoveEvent
        If Timer1.Enabled Then Exit Sub
        If MouseClickGauche Then
            If XClic > e.x Then
                AudioEditor.Position.EndSelect = Frame
                AudioEditor.Position.StartSelect = (AudioEditor.Position.StartView + (FramePerPixel * e.x))
            Else
                AudioEditor.Position.EndSelect = (AudioEditor.Position.StartView + (FramePerPixel * e.x))
                AudioEditor.Position.StartSelect = Frame
            End If
        End If
    End Sub

    Private Sub AudioEditor_MouseUpEvent(ByVal sender As Object, ByVal e As AxNCTAUDIOEDITOR2Lib._IAudioEditor2Events_MouseUpEvent) Handles AudioEditor.MouseUpEvent
        MouseClickGauche = 0
        RefreshStartTimeBox(AudioEditor.Position.StartSelect)
        RefreshEndTimeBox(AudioEditor.Position.EndSelect)
        Timer1.Dispose()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
    End Sub

    Private Sub OpenToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem3.Click
        With OpenVideo
            .FileName = ""
            .Title = "Open File ..."
            .Filter = "Tout les fichier|*.*|Fichiers Video|*.mpg;*.avi"
            .CheckFileExists = True
        End With

        If OpenVideo.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                video = New Video(OpenVideo.FileName, True)
            Catch
                MsgBox("Error in open video")
            End Try
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Joystick.Timer1.Enabled = True
        Else
            Joystick.Timer1.Enabled = False
        End If
    End Sub

    Private Sub Listview_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs)
        DialogueBox.Text = e.Item.SubItems.Item(12).Text
        StartTimeBox.Text = e.Item.SubItems.Item(4).Text
        EndTimeBox.Text = e.Item.SubItems.Item(5).Text
        IndexSelectionListview = e.ItemIndex
        If e.Item.SubItems.Item(4).Text <> "0:00:00.00" Then
            AudioEditor.Position.Selected = True
            AudioEditor.Position.StartSelect = AudioEditor.Position.SecToSamples(hmsToms(e.Item.SubItems.Item(4).Text))
        End If
        If e.Item.SubItems.Item(5).Text <> "0:00:00.00" Then
            AudioEditor.Position.Selected = True
            AudioEditor.Position.EndSelect = AudioEditor.Position.SecToSamples(hmsToms(e.Item.SubItems.Item(5).Text))
        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DialogueBox.KeyDown
        If e.KeyCode = Keys.Enter And Grid.RowCount <> 0 Then
            'SaveAsMemory(StartTimeBox.Text, EndTimeBox.Text, DialogueBox.Text)
            LoadNextLine(IndexSelectionListview, AudioEditor.Position.SecToSamples(hmsToms(EndTimeBox.Text)))
        End If
    End Sub

    Private Sub AudioEditor_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles AudioEditor.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            SaveAsMemory(StartTimeBox.Text, EndTimeBox.Text, DialogueBox.Text, Grid.CurrentRow.ToString)
        End If
    End Sub

    Public Sub SaveAsMemory(ByVal StartTime As String, ByVal EndTime As String, ByVal Dialogue As String, ByVal CurrentLine As Integer)
        'Grid.Item(4, CurrentLine).FormattedValue = StartTime
        'Grid.Item(5).Text = EndTime
        'Grid.Item(12).Text = Dialogue
    End Sub

    Public Sub LoadNextLine(ByVal IndexCurrentLine As Integer, ByVal EndTime As String)
        'Grid.Item(IndexCurrentLine + 1).Selected = True
    End Sub
End Class
