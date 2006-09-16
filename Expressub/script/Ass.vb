Imports System.IO
Imports System.Text
Imports System

Module Ass
    Public Dialogues(2, 1) As Integer
    Public Dialoguesbis(1) As Integer

    Public Sub LectureAss(ByVal path As String, ByVal NameDB As String)
        'Dim Stopwatch As System.Diagnostics.Stopwatch = System.Diagnostics.Stopwatch.StartNew()
        Try

            If CheckStatut(NameDB) Then Exit Sub

            ReDim Dialoguesbis(1), Dialogues(2, 1)
            Main.StyleSelection.Items.Clear()
            Main.ActorSelection.Items.Clear()

            AjoutDataTable("ScriptInfo", NameDB)
            AjoutDataTable("Styles", NameDB)
            AjoutDataTable("Events", NameDB)

            Dim fichier As New StreamReader(path, GetFileEncoding(path)) 'Ouvre le fichier
            Dim text As String
            Dim tested, section As Integer

            Do Until fichier.Peek = -1 'boucle de lecture du fichier
                text = fichier.ReadLine

                If tested <> 1 AndAlso text <> "[Script Info]" Then 'test si la 1ere ligne est conforme a la norme ass
                    fichier.Close()
                    MsgBox("File are not in Ass format.")
                    GoTo erreur
                End If

                While text = Nothing AndAlso fichier.Peek <> -1 OrElse InStr(text, ";") = 1 OrElse InStr(text, "!:") = 1
                    text = fichier.ReadLine
                End While

                If InStr(text, "[") = 1 Then
                    Select Case text

                        Case "[Script Info]"
                            tested = 1
                            section = 1
                        Case "[V4+ Styles]"
                            section = 2
                        Case "[Events]"
                            section = 3
                        Case "[Fonts]"
                            section = 4
                        Case "[Graphics]"
                            section = 5

                    End Select

                Else

                    Select Case section

                        Case 1
                            DecoupageScriptInfo(text, NameDB)
                        Case 2
                            DecoupageStyles(text, NameDB)
                        Case 3
                            DecoupageEvents(text, NameDB)
                        Case 4
                            DecoupageFonts(text, NameDB)
                        Case 5
                            DecoupageGraphics(text, NameDB)

                    End Select

                End If

            Loop

            fichier.Close()

            DetectCollision(NameDB)

            Main.Grid.Enabled = False
            Main.Grid.DataSource = Form2.Database.Tables("Events:" & NameDB)
            Main.Grid.Enabled = True

            ResizeGrid()

            Main.StartTimeBox.Text = Main.Grid.Item(4, 0).Value.ToString
            Main.EndTimeBox.Text = Main.Grid.Item(5, 0).Value.ToString
            AudioStartSelect(hmsToms(Main.StartTimeBox.Text), 0)
            AudioEndSelect(hmsToms(Main.EndTimeBox.Text))
            Main.DialogueBox.Text = Main.Grid.Item(12, 0).Value.ToString

            Main.LblStatus.Text = "Script load sucessfully"
            'Stopwatch.Stop()
            'Main.DialogueBox.Text = Stopwatch.Elapsed.TotalSeconds.ToString
        Catch ex As Exception

            MsgBox("Expressub can not read your file.")

        End Try
erreur:
    End Sub

    Sub DecoupageScriptInfo(ByVal texte As String, ByVal NameDB As String)
        Dim charSeparators() As String = {": "}
        Dim section() As String
        Dim table As System.Data.DataTable = Form2.Database.Tables("ScriptInfo:" & NameDB)
        Dim Ligne As System.Data.DataRow = table.NewRow

        Try

            section = texte.Split(charSeparators, StringSplitOptions.None)

            Ligne.Item(0) = section(0)
            Ligne.Item(1) = section(1)

            Form2.Database.Tables("ScriptInfo:" & NameDB).Rows.Add(Ligne)

        Catch ex As Exception

        End Try

    End Sub

    Sub DecoupageStyles(ByVal texte As String, ByVal NameDB As String)
        Dim section(), sectionbis() As String
        Dim i As Integer
        Dim charSeparators() As String = {","}
        Dim charSeparators2() As String = {": "}
        Dim Table As System.Data.DataTable = Form2.Database.Tables("Styles:" & NameDB)
        Dim Ligne As System.Data.DataRow = table.NewRow

        section = texte.Split(charSeparators2, StringSplitOptions.None)
        sectionbis = section(1).Split(charSeparators, 23, StringSplitOptions.None)

        If section(0) = "Format" Then GoTo fin

        For i = 0 To 22
            Ligne.Item(i) = sectionbis(i)
        Next

        Form2.Database.Tables("Styles:" & NameDB).Rows.Add(Ligne)

        Main.StyleSelection.Items.Add(sectionbis(0))

fin:

    End Sub

    Sub DecoupageEvents(ByVal texte As String, ByVal NameDB As String)
        Dim section(), sectionbis(), type As String
        Dim i, ii, test As Integer
        Dim charSeparators() As String = {","}
        Dim charSeparators2() As String = {": "}
        Dim table As System.Data.DataTable = Form2.Database.Tables("Events:" & NameDB)
        Dim Ligne As System.Data.DataRow = table.NewRow

        i = 0
        type = ""

        Try
            section = texte.Split(charSeparators2, 2, StringSplitOptions.None)
            sectionbis = section(1).Split(charSeparators, 10, StringSplitOptions.None)

            If section(0) = "Format" Then GoTo fin
            If sectionbis(5).Length <> 4 And IsNumeric(sectionbis(5)) Then Exit Sub
            If sectionbis(6).Length <> 4 And IsNumeric(sectionbis(6)) Then Exit Sub
            If sectionbis(7).Length <> 4 And IsNumeric(sectionbis(7)) Then Exit Sub

            ii = Dialogues.GetLength(1)

            If ii = table.Rows.Count Then
                ReDim Preserve Dialogues(2, ii + 1)
                ReDim Preserve Dialoguesbis(ii + 1)
            End If

            Dialoguesbis(ii - 1) = 0

            Ligne.Item(0) = table.Rows.Count
            Ligne.Item(2) = section(0)
            Dialogues(0, ii - 1) = hmsToms(sectionbis(1))
            Dialogues(1, ii - 1) = hmsToms(sectionbis(2))
            Dialogues(2, ii - 1) = CType(sectionbis(0), Integer)

            For i = 0 To 9
                Ligne.Item(i + 3) = sectionbis(i)
            Next

            Form2.Database.Tables("Events:" & NameDB).Rows.Add(Ligne)

            i = Main.ActorSelection.Items.Count
            If Main.ActorSelection.Items.Count <> 0 Then
                For i = 0 To Main.ActorSelection.Items.Count - 1
                    If sectionbis(4) = Main.ActorSelection.Items.Item(i).ToString Then
                        test = 0
                        Exit For
                    Else
                        test = 1
                    End If
                Next
            Else
                If sectionbis(4) <> Nothing Then
                    Main.ActorSelection.Items.Add(sectionbis(4))
                End If
            End If

            If test = 1 Then
                Main.ActorSelection.Items.Add(sectionbis(4))
            End If

        Catch

        End Try
fin:
    End Sub

    Sub DecoupageFonts(ByVal texte As String, ByVal NameDB As String)
        Dim charSeparators() As String = {":"}
        Dim section() As String
        Dim table As System.Data.DataTable = Form2.Database.Tables("Fonts:" & NameDB)
        Dim Ligne As System.Data.DataRow = table.NewRow

        section = texte.Split(charSeparators, StringSplitOptions.None)

        Ligne.Item(0) = section(0)
        Ligne.Item(1) = section(1)
        Form2.Database.Tables("Fonts:" & NameDB).Rows.Add(Ligne)

    End Sub

    Sub DecoupageGraphics(ByVal texte As String, ByVal NameDB As String)
        Dim charSeparators() As String = {":"}
        Dim section() As String
        Dim table As System.Data.DataTable = Form2.Database.Tables("Graphics:" & NameDB)
        Dim Ligne As System.Data.DataRow = table.NewRow

        section = texte.Split(charSeparators, StringSplitOptions.None)

        Ligne.Item(0) = section(0)
        Ligne.Item(1) = section(1)
        Form2.Database.Tables("Graphics:" & NameDB).Rows.Add(Ligne)

    End Sub

    Public Sub EnregistrementAss(ByVal path As String, ByVal NameDB As String)
        Dim encoding As New System.Text.UnicodeEncoding
        Dim Fs As IO.FileStream = New IO.FileStream(path, IO.FileMode.Create)
        Dim file As New IO.StreamWriter(Fs, encoding)

        file.Write(SaveAss(NameDB))
        file.Close()
    End Sub

    Function SaveAss(ByVal Namedb As String) As String

        Dim i, ii As Integer
        Dim stylebis, eventbis, script As String
        Dim style As String = "Style: "
        Dim table As System.Data.DataTable

        script = "[Script Info]" & ControlChars.CrLf + ControlChars.CrLf
        script &= ";**********************************************" & ControlChars.CrLf
        script &= ";***    Advanced Sub Station Alpha script   ***" & ControlChars.CrLf
        script &= ";**********************************************" & ControlChars.CrLf
        script &= ";***                                        ***" & ControlChars.CrLf
        script &= ";***    This script has been created with   ***" & ControlChars.CrLf
        script &= ";***                Expressub               ***" & ControlChars.CrLf
        script &= ";***                                        ***" & ControlChars.CrLf
        script &= ";**********************************************" & ControlChars.CrLf & ControlChars.CrLf

        table = Form2.Database.Tables("ScriptInfo:" & Namedb)

        For i = 0 To 14
            script &= table.Rows.Item(i).Item(0).ToString & ": " _
            & table.Rows.Item(i).Item(1).ToString & ControlChars.CrLf
        Next
        script &= ControlChars.CrLf & "[V4+ Styles]" & ControlChars.CrLf
        script &= "Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, " _
        & "OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, " _
        & "Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, " _
        & "MarginV, Encoding" & ControlChars.CrLf

        stylebis = ""
        table = Form2.Database.Tables("Styles:" & Namedb)

        For i = 0 To table.Rows.Count - 1
            stylebis = ""
            For ii = 0 To 21
                stylebis &= table.Rows.Item(i).Item(ii).ToString & ","
            Next
            script &= "Style: " & stylebis & table.Rows.Item(i).Item(22).ToString _
            & ControlChars.CrLf
        Next

        table = Form2.Database.Tables("Events:" & Namedb)

        script &= ControlChars.CrLf & "[Events]" & ControlChars.CrLf
        script &= "Format: Layer, Start, End, Style, Actor, MarginL, MarginR, MarginV, " _
        & "Effect, Text" & ControlChars.CrLf

        For i = 0 To table.Rows.Count - 1
            eventbis = ""
            For ii = 3 To 11
                eventbis &= table.Rows.Item(i).Item(ii).ToString & ","
            Next
            script &= table.Rows.Item(i).Item(2).ToString + ": " _
            & eventbis & table.Rows.Item(i).Item(12).ToString & ControlChars.CrLf
        Next

        If Form2.Database.Tables.IndexOf("Fonts:" & Namedb) <> -1 Then
            table = Form2.Database.Tables("Fonts:" & Namedb)
            script &= ControlChars.CrLf & "[Fonts]" & ControlChars.CrLf
            For i = 0 To table.Rows.Count - 1
                script &= table.Rows.Item(i).Item(0).ToString & ": " _
                & table.Rows.Item(i).Item(1).ToString & ControlChars.CrLf
            Next
        End If

        If Form2.Database.Tables.IndexOf("Graphics:" & Namedb) <> -1 Then
            table = Form2.Database.Tables("Graphics:" & Namedb)
            script &= ControlChars.CrLf & "[Graphics]" & ControlChars.CrLf
            For i = 0 To table.Rows.Count - 1
                script &= table.Rows.Item(i).Item(0).ToString & ": " _
                & table.Rows.Item(i).Item(1).ToString & ControlChars.CrLf
            Next
        End If

        Return script

    End Function

    Public Function GetFileEncoding(ByVal FileName As String) As System.Text.Encoding

        'Return the Encoding of a text file. Return Encoding.Default if no Unicode
        'BOM (byte order mark) is found.
        Dim Result As Encoding = Encoding.Default
        Dim FI As New FileInfo(FileName)
        Dim FS As FileStream = Nothing
        Dim i, j As Integer

        Try

            FS = FI.OpenRead()

            Dim UnicodeEncodings() As Encoding = {Text.Encoding.Unicode, Text.Encoding.UTF7, _
            Text.Encoding.BigEndianUnicode, Text.Encoding.UTF8, Text.Encoding.ASCII}

            For i = 0 To 4

                If Result IsNot Encoding.Default Then Exit For

                FS.Position = 0

                Dim preamble As Byte() = UnicodeEncodings(i).GetPreamble()
                Dim PreamblesAreEqual As Boolean = False
                Dim hihi As Integer = FS.ReadByte

                For j = 0 To preamble.Length - 1

                    If PreamblesAreEqual = True Then Exit For

                    PreamblesAreEqual = preamble(j) = FS.ReadByte()

                Next

                If PreamblesAreEqual Then

                    Result = UnicodeEncodings(i)

                End If
            Next

        Catch

        Finally

            If FS IsNot Nothing Then
                FS.Close()
            End If

        End Try

        If Result IsNot Encoding.Default Then
            Return Result
        End If

        Return Encoding.Default

    End Function

    Public Sub DetectCollision(ByVal NameDB As String)
        Dim table As System.Data.DataTable = Form2.Database.Tables("Events:" & NameDB)
        Dim i, j As Integer

        For i = 0 To Dialogues.GetLength(1) - 1

            For j = (i + 1) To Dialogues.GetLength(1) - 1

                If (Dialogues(0, j) < Dialogues(1, i)) AndAlso _
                (Dialogues(1, j) > Dialogues(0, i)) AndAlso _
                (j <> i) AndAlso (Dialogues(2, i) <> Dialogues(2, j)) Then

                    Dialoguesbis(i) += 1
                    Dialoguesbis(j) += 1

                End If

            Next

        Next

        For i = 0 To table.Rows.Count - 1
            table.Rows(i).Item(1) = Dialoguesbis(i)
        Next
    End Sub

    Public Function CheckStatut(ByVal NameDB As String) As Boolean
        Dim result As DialogResult

        If Form2.Database.Tables.IndexOf("Events:" & NameDB) <> -1 Then

            Dialogue.Label1.Text = "Ce projet existe déja, remplasser ?"
            result = Dialogue.ShowDialog()

            If result = Windows.Forms.DialogResult.OK Then

                Form2.Database.Tables.Remove("ScriptInfo:" & NameDB)
                Form2.Database.Tables.Remove("Styles:" & NameDB)
                Form2.Database.Tables.Remove("Events:" & NameDB)

            End If

            If result = Windows.Forms.DialogResult.No Then

                With Main.SaveAsScript

                    .FileName = ""
                    .Title = "Save As File ..."
                    .OverwritePrompt = True
                    .DefaultExt = "ass"
                    .Filter = "ASS Files (*.ass)|*.ass"

                End With

                If Main.SaveAsScript.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'on lance la compilation du nouveau fichier
                    EnregistrementAss(Main.SaveAsScript.FileName, Main.CurrentDB)

                    Form2.Database.Tables.Remove("ScriptInfo:" & NameDB)
                    Form2.Database.Tables.Remove("Styles:" & NameDB)
                    Form2.Database.Tables.Remove("Events:" & NameDB)

                End If

            End If

            If result = Windows.Forms.DialogResult.Cancel Then

                Return True
                Exit Function

            End If

        End If

        If Main.Modified Then

            Dialogue.Label1.Text = "Voulez vous sauvegarder votre script en cour ?"
            result = Dialogue.ShowDialog()

            If result = Windows.Forms.DialogResult.OK Then

                With Main.SaveAsScript

                    .FileName = ""
                    .Title = "Save As File ..."
                    .OverwritePrompt = True
                    .DefaultExt = "ass"
                    .Filter = "ASS Files (*.ass)|*.ass"

                End With

                If Main.SaveAsScript.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'on lance la compilation du nouveau fichier
                    EnregistrementAss(Main.SaveAsScript.FileName, Main.CurrentDB)

                    Form2.Database.Tables.Remove("ScriptInfo:" & NameDB)
                    Form2.Database.Tables.Remove("Styles:" & NameDB)
                    Form2.Database.Tables.Remove("Events:" & NameDB)

                End If

            End If

            If result = Windows.Forms.DialogResult.Cancel Then

                Return True
                Exit Function

            End If

        End If

        Return False

    End Function

End Module
