Imports Microsoft.DirectX.AudioVideoPlayback
Imports System.IO
Imports Microsoft.Win32
Imports System.Threading

Public Class Main

    Public FrameEnd, FrameStart, MouseClickGauche, XClic, IndexSelectionListview As Integer
    Public CurrentDB, CurrentPath As String
    Public FramePerPixel As Double
    Public Modified As Boolean
    Public video As Video

    Sub InitVariable()

        'Initialisation des variables qui servent a remplir la table initial

        InitScriptInfo() 'section script info
        InitStyles() 'section styles
        InitEvent() 'section event
        CurrentDB = "Initial" 'et on travaille avec la table initial

    End Sub

    Private Sub InitScriptInfo()
        Dim i As Integer

        Dim ScriptInfo() As String = {"Title: ", "Original Script: ", _
        "Original Translation: ", "Original Editing: ", "Original Timing: ", "Synch Point: ", _
        "Script Updated By: ", "Update Details: ", "ScriptType: v4.00+", _
        "Collisions: Normal", "PlayResX: 640", "PlayResY: 480", "PlayDepth: 0", _
        "Timer: 100.0000", "WrapStyle: 0"}

        'on ajoute la table
        AjoutDataTable("ScriptInfo", "Initial")

        For i = 0 To 14
            'et on la remplie avec les info enregistré ci-dessus
            DecoupageScriptInfo(ScriptInfo(i), "Initial")
        Next

    End Sub

    Private Sub InitStyles()
        Dim Style As String

        StyleSelection.Items.Clear()

        Style = "Style: Default,Arial,25,&H00FFFFFF,&H00000000,&H00000000,&H00000000," _
        & "0,0,0,0,100,100,0,0,1,2,2,2,20,20,30,0"

        'on ajoute la table
        AjoutDataTable("Styles", "Initial")
        'et on la remplie avec les info enregistré ci-dessus
        DecoupageStyles(Style, "Initial")

    End Sub

    Private Sub InitEvent()
        Dim Events As String

        Events = "Dialogue: 0,0:00:00.00,0:00:00.00,Default,,0000,0000," _
        & "0000,,"

        'on ajoute la table
        AjoutDataTable("Events", "Initial")
        'et on la remplie avec les info enregistré ci-dessus
        DecoupageEvents(Events, "Initial")

    End Sub

    Private Sub InitInfoBulle()

        'Initialisation des toutes les bulles d'aide des boutons
        ToolTip1.SetToolTip(Button1, "Hihihi")

    End Sub

    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Modified Then

            Dim result As DialogResult

            Dialogue.Label1.Text = "Voulez vous sauvegarder votre script en cour ?"
            result = Dialogue.ShowDialog

            If result = Windows.Forms.DialogResult.OK Then

                With SaveAsScript

                    .FileName = ""
                    .Title = "Save As File ..."
                    .OverwritePrompt = True
                    .DefaultExt = "ass"
                    .Filter = "ASS Files (*.ass)|*.ass"

                End With

                If SaveAsScript.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'on lance la compilation du nouveau fichier
                    EnregistrementAss(SaveAsScript.FileName, CurrentDB)
                End If

            End If

            If result = Windows.Forms.DialogResult.Cancel Then

                e.Cancel = True

            End If

        End If
    End Sub

    Private Sub Main_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        'systeme de raccourcie clavier
        If e.KeyCode = Keys.Enter Then 'si touche entrer

            e.Handled = True 'on intercepte la touche
            SaveAsMemory(StartTimeBox.Text, EndTimeBox.Text, DialogueBox.Text, Grid.CurrentRow.Index)
            LoadLine(Grid.CurrentRow.Index, AudioEditor.Position.SecToSamples(hmsToms(EndTimeBox.Text)))

        Else

            e.Handled = False 'sinon on fait rien

        End If

    End Sub

    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'on initialise les varible de commencement
        InitVariable()
        'on affiche la table event initial dans la grid
        Grid.DataSource = Form2.Database.Tables("Events:" & CurrentDB)
        'redimensionement des colonnes de la grid
        ResizeGrid()
        'redimensionement de l'editeur audio
        ReziseAudioeditor()
        'redimensionement des scroll de l'editeur audio
        ReziseScroll()
        'initialisation des info bulle
        InitInfoBulle()

        'Form1.Show()

        'recuperation du nom de fichier pour lequel le logiciel a été ouvert
        If Environment.GetCommandLineArgs().Length > 1 Then
            Dim Fi As FileInfo = New FileInfo(Environment.GetCommandLineArgs(1))

            Select Case Fi.Extension 'on recupere l'extension

                Case ".ass"
                    'on lit le fichier
                    LectureAss(Environment.GetCommandLineArgs(1), Fi.Name.Substring(0, Fi.Name.LastIndexOf(".")))
                    'on donne un nom a notre database (le nom du fichier
                    CurrentDB = Fi.Name.Substring(0, Fi.Name.LastIndexOf("."))
                    CurrentPath = Environment.GetCommandLineArgs(1)
                    'Case ".txt"
                    'lectureTxt(Environment.GetCommandLineArgs(1))
                    'CurrentDB = Fi.Name.Substring(0, Fi.Name.LastIndexOf("."))

            End Select

        End If

        'changement de parametre
        'My.Settings.mouhahaha = 666

    End Sub

    Private Sub OpenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem1.Click

        With OpenScript

            .FileName = ""
            .Title = "Open File ..."
            .Filter = "All Suported Format |*.ass"
            '.Filter = "|ASS Files (*.ass)|*.ass"
            '.Filter = "|TXT Files (*.txt)|*.txt"
            .Multiselect = False
            .CheckFileExists = True

        End With

        If OpenScript.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Fi As FileInfo = New FileInfo(OpenScript.FileName)

            Select Case Fi.Extension

                Case ".ass"

                    'on lit le fichier
                    LectureAss(OpenScript.FileName, Fi.Name.Substring(0, Fi.Name.LastIndexOf(".")))
                    'on donne un nom a notre database (le nom du fichier
                    CurrentDB = Fi.Name.Substring(0, Fi.Name.LastIndexOf("."))
                    CurrentPath = OpenScript.FileName

                    'Case ".txt"

                    'lectureTxt(OpenScript.FileName)
                    'on donne un nom a notre database (le nom du fichier
                    'CurrentDB = Fi.Name.Substring(0, Fi.Name.LastIndexOf("."))
                    'CurrentPath = OpenScript.FileName

            End Select

        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Application.Exit() 'on quite l'application

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
            'on lance la compilation du nouveau fichier
            EnregistrementAss(SaveAsScript.FileName, CurrentDB)
            Modified = False
        End If

    End Sub

    Private Sub OpenToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem2.Click

        With OpenSound
            .FileName = ""
            .Title = "Open File ..."
            .Filter = "All Suported format |*.wav;*.mp3;*.mp2;*.mpeg;*.ogg;*.avi;*.g721," _
            & "*.g723,*.g726;*.vox;*.raw;*.pcm;*.wma;*.cda"
            .Filter = .Filter & "|Wav Files (*.wav)|*.wav"
            .Filter = .Filter & "|MPEG Files (*.mp3;*.mp2;*.mpeg)|*.mp3;*.mp2;*.mpeg"
            .Filter = .Filter & "|OggVorbis Files (*.ogg)|*.ogg"
            .Filter = .Filter & "|AVI Files (*.avi)|*.avi"
            .Filter = .Filter & "|G.72x Files (*.g721;*.g723;*.g726)|*.g721,*.g723,*.g726"
            .Filter = .Filter & "|VOX Files (*.vox)|*.vox"
            .Filter = .Filter & "|RAW Files (*.raw; *.pcm)|*.raw;*.pcm"
            .Filter = .Filter & "|WMA Files (*.wma)|*.wma"
            .Filter = .Filter & "|CD Audio (*.cda)|*.cda"
            .CheckFileExists = True
        End With

        If OpenSound.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                'on ouvre le fichier
                AudioEditor.Open(OpenSound.FileName)
            Catch
                'au cas où le fichier soit illisible
                MsgBox("Format not allowed")
            End Try
        End If

    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click

        'dechargement du fichier en cour
        AudioEditor.Close()

    End Sub

    Private Sub AudioEditor_BlockOperation(ByVal sender As Object, ByVal e As AxNCTAUDIOEDITOR2Lib._IAudioEditor2Events_BlockOperationEvent) Handles AudioEditor.BlockOperation

        If (e.percent >= 0 And e.percent < 100 And LoadBar.Visible = False) Then LoadBar.Visible = True

        Select Case AudioEditor.Status
            Case 1 : LblStatus.Text = "Play"
            Case 2 : LblStatus.Text = "Record"
            Case 3 : LblStatus.Text = "Audio Load"
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

        LoadBar.Value = e.percent 'maj de l'avancement du chargement
        Application.DoEvents() 'evite le freeze de l'affichage

    End Sub

    Private Sub AudioEditor_ChangePosition(ByVal sender As Object, ByVal e As System.EventArgs) Handles AudioEditor.ChangePosition

        FramePerPixel = (AudioEditor.Position.EndView - AudioEditor.Position.StartView) / (AudioEditor.Width - 5)

    End Sub

    Private Sub AudioEditor_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles AudioEditor.DblClick

        SaveAsMemory(StartTimeBox.Text, EndTimeBox.Text, DialogueBox.Text, Grid.CurrentRow.Index)
        LoadLine(Grid.CurrentRow.Index, AudioEditor.Position.SecToSamples(hmsToms(EndTimeBox.Text)))

    End Sub

    Private Sub AudioEditor_EndOperation(ByVal sender As Object, ByVal e As System.EventArgs) Handles AudioEditor.EndOperation

        LoadBar.Visible = False
        'on n'affiche que les 10 premiere seconde
        AudioEditor.Position.EndView = AudioEditor.Position.SecToSamples(10000)
        LblStatus.Text = "Audio load sucessfully"
        'frameperpixel utilisé dans les calcul de position dans l'audioeditor
        FramePerPixel = (AudioEditor.Position.EndView - AudioEditor.Position.StartView) / (AudioEditor.Width - 5)
        AudioEditor.ZoomVertical(100)
        VScrollAudio.Value = 100
        DeltaAudio = AudioEditor.Position.EndView - AudioEditor.Position.StartView
        HScrollAudio.Value = 0
        HScrollAudio.Maximum = AudioEditor.Position.TotalSamples - DeltaAudio
        HScrollAudio.SmallChange = AudioEditor.Position.EndSelect - AudioEditor.Position.StartSelect
        HScrollAudio2.Value = 10

    End Sub

    Private Sub AudioEditor_MouseDownEvent(ByVal sender As Object, ByVal e As AxNCTAUDIOEDITOR2Lib._IAudioEditor2Events_MouseDownEvent) Handles AudioEditor.MouseDownEvent

        XClic = e.x

        If e.y > 11 Then

            If (e.button = 1) Then 'bouton gauche
                AudioStartSelect(CType(AudioEditor.Position.StartView + (FramePerPixel * e.x), Integer), frameend)
            End If

            If (e.button = 2) Then 'bouton droit
                FrameEnd = AudioEditor.Position.StartView + CType((FramePerPixel * e.x), Integer)
                AudioEndSelect(frameend)
            End If

        End If

    End Sub

    Private Sub AudioEditor_MouseUpEvent(ByVal sender As Object, ByVal e As AxNCTAUDIOEDITOR2Lib._IAudioEditor2Events_MouseUpEvent) Handles AudioEditor.MouseUpEvent

        'au cas où les control ne soit pu a jour
        RefreshStartTimeBox(AudioEditor.Position.StartSelect)
        RefreshEndTimeBox(AudioEditor.Position.EndSelect)
        TotalTimeBox.Text = msTohms(hmsToms(EndTimeBox.Text) - hmsToms(StartTimeBox.Text))
        FrameEnd = AudioEditor.Position.EndSelect

    End Sub

    Private Sub OpenToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem3.Click

        With OpenVideo
            .FileName = ""
            .Title = "Open File ..."
            .Filter = "Tout les fichier|*.*|Fichiers Video|*.mpg;*.avi"
            .CheckFileExists = True
        End With

        If OpenVideo.ShowDialog = Windows.Forms.DialogResult.OK Then

            'on affiche la vidéo
            'DisplayVideoWithAudio()
            'on redimensionne l'audioeditor
            'ReziseAudioeditor()
            'on redimensionne les scroll
            'ReziseScroll()

        End If

    End Sub

    Public Sub SaveAsMemory(ByVal StartTime As String, ByVal EndTime As String, ByVal Dialogue As String, ByVal CurrentRow As Integer)

        Grid.Item(2, CurrentRow).Value = TypeSection.SelectedItem
        Grid.Item(3, CurrentRow).Value = LayerBox.Text
        Grid.Item(4, CurrentRow).Value = StartTime
        Grid.Item(5, CurrentRow).Value = EndTime
        Grid.Item(6, CurrentRow).Value = StyleSelection.SelectedItem
        Grid.Item(7, CurrentRow).Value = ActorSelection.SelectedItem
        Grid.Item(8, CurrentRow).Value = LeftBox.Text
        Grid.Item(9, CurrentRow).Value = RightBox.Text
        Grid.Item(10, CurrentRow).Value = VertBox.Text
        Grid.Item(12, CurrentRow).Value = Dialogue
        Modified = True

    End Sub

    Public Sub LoadLine(ByVal IndexRow As Integer, ByVal EndTime As Integer)

        Try

            If IndexRow + 1 = Grid.RowCount Then
                Dim Events As String

                Events = "Dialogue: 0,0:00:00.00,0:00:00.00,Default,,0000,0000," _
                & "0000,,"

                DecoupageEvents(Events, CurrentDB)

                Grid.Refresh()

                Grid.Rows(IndexRow).Selected = False
                Grid.Rows(IndexRow + 1).Selected = True
                Grid.CurrentCell = Grid(1, IndexRow + 1)
                StartTimeBox.Text = Grid.Item(4, IndexRow + 1).Value.ToString
                EndTimeBox.Text = Grid.Item(5, IndexRow + 1).Value.ToString
                AudioStartSelect(AudioEditor.Position.SecToSamples(hmsToms(Grid.Item(5, IndexRow).Value.ToString)), 0)
                DialogueBox.Text = Grid.Item(12, IndexRow + 1).Value.ToString()
                TypeSection.SelectedItem = Grid.Item(2, IndexRow + 1).Value.ToString
                StyleSelection.SelectedItem = Grid.Item(6, IndexRow + 1).Value.ToString
                ActorSelection.SelectedItem = Grid.Item(7, IndexRow + 1).Value.ToString
                LayerBox.Text = Grid.Item(3, IndexRow + 1).Value.ToString
                LeftBox.Text = Grid.Item(8, IndexRow + 1).Value.ToString
                RightBox.Text = Grid.Item(9, IndexRow + 1).Value.ToString
                VertBox.Text = Grid.Item(10, IndexRow + 1).Value.ToString

                Exit Sub

            End If

            Grid.Rows(IndexRow).Selected = False
            Grid.Rows(IndexRow + 1).Selected = True
            Grid.CurrentCell = Grid(1, IndexRow + 1)
            StartTimeBox.Text = Grid.Item(4, IndexRow + 1).Value.ToString
            EndTimeBox.Text = Grid.Item(5, IndexRow + 1).Value.ToString
            AudioStartSelect(hmsToms(StartTimeBox.Text), 0)
            AudioEndSelect(hmsToms(EndTimeBox.Text))
            DialogueBox.Text = Grid.Item(12, IndexRow + 1).Value.ToString()
            TypeSection.SelectedItem = Grid.Item(2, IndexRow + 1).Value.ToString
            StyleSelection.SelectedItem = Grid.Item(6, IndexRow + 1).Value.ToString
            ActorSelection.SelectedItem = Grid.Item(7, IndexRow + 1).Value.ToString
            LayerBox.Text = Grid.Item(3, IndexRow + 1).Value.ToString
            LeftBox.Text = Grid.Item(8, IndexRow + 1).Value.ToString
            RightBox.Text = Grid.Item(9, IndexRow + 1).Value.ToString
            VertBox.Text = Grid.Item(10, IndexRow + 1).Value.ToString

        Catch ex As Exception

        End Try

    End Sub

    Private Sub RegistryExtension()

        My.Computer.Registry.ClassesRoot.CreateSubKey("Expressub\shell\open\command")
        My.Computer.Registry.ClassesRoot.SetValue("HKEY_CLASSES_ROOT\Expressub\shell\open", "Edit with Expressub")
        My.Computer.Registry.ClassesRoot.SetValue("HKEY_CLASSES_ROOT\Expressub\shell\open\command", Me.GetType.Assembly.Location & " %1")

        My.Computer.Registry.ClassesRoot.CreateSubKey("Expressub\DefaultIcon")
        Dim sICO As String = Me.GetType.Assembly.Location
        sICO = sICO.Substring(0, sICO.LastIndexOf("\")) & "\Expressub.exe"
        My.Computer.Registry.ClassesRoot.SetValue("HKEY_CLASSES_ROOT\Expressub\DefaultIcon", sICO)

    End Sub

    Private Sub Grid_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.SelectionChanged

        Try

            Dim IndexCurrentRow As Integer = Grid.CurrentRow.Index

            DialogueBox.Text = Grid.Item(12, IndexCurrentRow).Value.ToString()
            StartTimeBox.Text = Grid.Item(4, IndexCurrentRow).Value.ToString()
            EndTimeBox.Text = Grid.Item(5, IndexCurrentRow).Value.ToString()
            TypeSection.SelectedItem = Grid.Item(2, IndexCurrentRow).Value.ToString
            StyleSelection.SelectedItem = Grid.Item(6, IndexCurrentRow).Value.ToString
            ActorSelection.SelectedItem = Grid.Item(7, IndexCurrentRow).Value.ToString
            LayerBox.Text = Grid.Item(3, IndexCurrentRow).Value.ToString
            LeftBox.Text = Grid.Item(8, IndexCurrentRow).Value.ToString
            RightBox.Text = Grid.Item(9, IndexCurrentRow).Value.ToString
            VertBox.Text = Grid.Item(10, IndexCurrentRow).Value.ToString

            If Grid.Item(5, IndexCurrentRow).Value.ToString() <> "0:00:00.00" Then

                AudioEditor.Position.Selected = True
                AudioEndSelect(AudioEditor.Position.SecToSamples(hmsToms(Grid.Item(5, IndexCurrentRow).Value.ToString)))

            End If

            If Grid.Item(4, IndexCurrentRow).Value.ToString() <> "0:00:00.00" Then

                AudioEditor.Position.Selected = True
                AudioStartSelect(AudioEditor.Position.SecToSamples(hmsToms(Grid.Item(4, IndexCurrentRow).Value.ToString)), AudioEditor.Position.EndSelect)

            End If

            TotalTimeBox.Text = msTohms(hmsToms(EndTimeBox.Text) - hmsToms(StartTimeBox.Text))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub VScrollAudio_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollAudio.Scroll

        AudioEditor.ZoomVertical(VScrollAudio.Value)

    End Sub

    Private Sub DisplayVideoWithAudio()
        Dim VideoBox As New GroupBox
        Dim Frame As New PictureBox

        VideoBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top _
            Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        VideoBox.Location = New System.Drawing.Point(0, 27)
        VideoBox.Name = "VideoBox"
        VideoBox.Text = "Video"
        Frame.Dock = DockStyle.Fill
        Frame.BackColor = Color.Beige
        VideoBox.Controls.Add(Frame)

        Me.Controls.Add(VideoBox)

        Try
            video = New Video(OpenVideo.FileName, True)
            video.Owner = Frame
            VideoBox.BringToFront()
        Catch ex As Exception
            MsgBox("Error in open video")
        End Try

        VideoBox.Size = New System.Drawing.Size(326, 259)
        Frame.Size = New System.Drawing.Size(320, 240)
        Audio.Size = New System.Drawing.Size(686, 188)
        Audio.Location = New System.Drawing.Point(327, 27)
        ControlsBox.Location = New System.Drawing.Point(327, 221)

    End Sub

    Private Sub LayerBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LayerBox.KeyPress

        If IsNumeric(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TypeSection_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TypeSection.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
        End If

    End Sub

    Private Sub StyleSelection_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles StyleSelection.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
        End If

    End Sub

    Private Sub ActorSelection_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ActorSelection.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        AudioEditor.Stop()
        AudioEditor.Play()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        AudioEditor.Stop()

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        LoadLine(Grid.CurrentRow.Index - 2, AudioEditor.Position.SecToSamples(hmsToms(EndTimeBox.Text)))

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        LoadLine(Grid.CurrentRow.Index, AudioEditor.Position.SecToSamples(hmsToms(EndTimeBox.Text)))

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        AudioEditor.Play()

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        AudioEditor.Stop()
        AudioEditor.Play(NCTAUDIOEDITOR2Lib.PlayTypeConstants.PLAYTOEND)

    End Sub

    Private Sub PreferencesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreferencesToolStripMenuItem.Click

        Options.ShowDialog()

    End Sub

    Private Sub HScrollAudio_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollAudio.Scroll

        FrameStart = e.NewValue
        AudioEditor.Position.StartView = e.NewValue
        AudioEditor.Position.EndView = e.NewValue + DeltaAudio

    End Sub

    Private Sub HScrollAudio2_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollAudio2.Scroll

        DeltaAudio = AudioEditor.Position.SecToSamples(e.NewValue * 1000) '*1000 car milliseconde
        AudioEditor.Position.EndView = e.NewValue + DeltaAudio + FrameStart
        HScrollAudio.Maximum = AudioEditor.Position.TotalSamples - DeltaAudio

    End Sub

    Private Sub DialogueBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DialogueBox.KeyDown

        If e.KeyCode = Keys.Return Then
            e.Handled = True
        End If

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click

        If CheckStatut(CurrentDB) Then Exit Sub
        'on initialise les varible de commencement
        InitVariable()
        'on affiche la table event initial dans la grid
        Grid.DataSource = Form2.Database.Tables("Events:" & CurrentDB)

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click

        If File.Exists(CurrentPath) Then

            EnregistrementAss(CurrentPath, CurrentDB)

        Else

            With SaveAsScript

                .FileName = ""
                .Title = "Save Fille ..."
                .OverwritePrompt = True
                .DefaultExt = "ass"
                .Filter = "ASS Files (*.ass)|*.ass"

            End With

            If SaveAsScript.ShowDialog = Windows.Forms.DialogResult.OK Then
                'on lance la compilation du nouveau fichier
                EnregistrementAss(SaveAsScript.FileName, CurrentDB)
                Modified = False
            End If

        End If

    End Sub
End Class
