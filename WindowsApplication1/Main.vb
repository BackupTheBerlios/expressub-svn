Public Class Main
    Public FramePerPixel, MouseClickGauche, XClic, Frame, IndexSelection As Integer

    Sub resizelistview()
        Dim i As Integer
        Dim largeur As Integer
        For i = 0 To 11
            Listview.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize)
            largeur += Listview.Columns.Item(i).Width
        Next
        Listview.Columns.Item(12).Width = (Listview.Width - 4) - largeur
    End Sub

    Sub AudioStartSelect(ByVal FrameStart As Integer)
        Dim TempDebut As Integer
        AudioEditor.Position.Selected = 1
        AudioEditor.Position.StartSelect = FrameStart
        TempDebut = AudioEditor.Position.SamplesToSec(FrameStart)

        'AudioEditor.Markers.Insert(FrameStart, 500000, "label", "note", "texte", 0, 0, 0, 0)
    End Sub

    Sub AudioEndSelect(ByVal FrameEnd As Integer)

        If FrameEnd < AudioEditor.Position.StartSelect Then
            AudioEditor.Position.Selected = 0
            AudioEditor.Position.StartSelect = FrameEnd
        End If
        AudioEditor.Position.Selected = 1
        AudioEditor.Position.EndSelect = FrameEnd

    End Sub

    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        resizelistview()
        With AudioEditor
            .MouseEventsEnabled = False
            .ScaleY.Visible = False
            .Channels.Num = 1
            .Channels.Visible = True
            .Channels.Num = 2
            .Channels.Visible = False
            .TypeBorder = 4
            .ScaleX.Type = 2
            .Parent = Audio
        End With
    End Sub

    Private Sub OpenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem1.Click
        With OpenScript

            .FileName = ""
            .Title = "Open File ..."
            .Filter = "ASS Files (*.ass)|*.ass"
            .Filter = .Filter & "|TXT Files (*.txt)|*.txt"
            .Multiselect = False
            .CheckFileExists = True

        End With
        If OpenScript.ShowDialog = Windows.Forms.DialogResult.OK Then
            Ass.lecture(OpenScript.FileName)
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
            Ass.enregistrement(SaveAsScript.FileName)
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
            AudioEditor.Open(OpenSound.FileName)
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        AudioEditor.Close()
    End Sub

    Private Sub LectureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LectureToolStripMenuItem.Click
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
        LblStatus.Text = "Audio load sucessfully"
        FramePerPixel = (AudioEditor.Position.EndView - AudioEditor.Position.StartView) / (AudioEditor.Width - 2)
    End Sub

    Private Sub AudioEditor_EndPlay(ByVal sender As Object, ByVal e As System.EventArgs) Handles AudioEditor.EndPlay
        AudioEditor.Position.StartSelect = Joystick.FrameStart
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
        Timer1.Dispose()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
    End Sub

    Private Sub AudioEditor_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles AudioEditor.PreviewKeyDown
        If e.KeyCode = Keys.NumPad2 Then
            AudioEditor.Position.StartSelect = AudioEditor.Position.StartSelect + 50000
            AudioEditor.Position.CurrentPosition = AudioEditor.Position.StartSelect
            AudioEditor.Play()
        End If
        If e.KeyCode = Keys.NumPad1 Then
            AudioEditor.Position.StartSelect = AudioEditor.Position.StartSelect - 50000
            AudioEditor.Position.CurrentPosition = AudioEditor.Position.StartSelect
            AudioEditor.Play()
        End If
    End Sub

    Private Sub OpenToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem3.Click
        With OpenVideo
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

        If OpenVideo.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Form1.AxWindowsMediaPlayer1.URL = OpenVideo.FileName
            Joystick.ShowDialog()
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Joystick.Timer1.Enabled = True
        Else
            Joystick.Timer1.Enabled = False
        End If
    End Sub

    Private Sub Listview_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles Listview.ItemSelectionChanged
        TextBox1.Text = e.Item.SubItems.Item(12).Text
        StartTimeBox.Text = e.Item.SubItems.Item(4).Text
        EndTimeBox.Text = e.Item.SubItems.Item(5).Text
        If e.Item.SubItems.Item(4).Text <> "0:00:00.00" Then
            AudioEditor.Position.Selected = True
            AudioEditor.Position.StartSelect = AudioEditor.Position.SecToSamples(hmsToms(e.Item.SubItems.Item(4).Text))
        End If
        If e.Item.SubItems.Item(5).Text <> "0:00:00.00" Then
            AudioEditor.Position.Selected = True
            AudioEditor.Position.EndSelect = AudioEditor.Position.SecToSamples(hmsToms(e.Item.SubItems.Item(5).Text))
        End If
    End Sub

    Public Function msTohms(ByVal ms As Integer)
        Dim h, mm, ss, ms2 As Integer
        h = ms \ 3600000
        mm = (ms \ 60000) - (h * 60)
        ss = (ms \ 1000) - (mm * 60) - (h * 3600)
        ms2 = ms - (ss * 1000) - (mm * 60000) - (h * 3600000)

        Return h & ":" & mm & ":" & ss & "." & (ms2 \ 10)
    End Function

    Public Function hmsToms(ByVal hms As String)
        Dim charSeparators() As Char = {"."}
        Dim charSeparators2() As Char = {":"}
        Dim section(), sectionbis() As String

        section = hms.Split(charSeparators, StringSplitOptions.None)
        sectionbis = section(0).Split(charSeparators2)
        Return (sectionbis(0) * 3600000 + sectionbis(1) * 60000 + sectionbis(2) * 1000 + section(1) * 10)
    End Function
End Class
