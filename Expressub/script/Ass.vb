Imports System.IO
Module Ass
    Public Script_info(1, 1), Styles(22, 1), Dialogues(11, 1), Fonts(1, 1), Graphics(1, 1) As String
    Public iDecoupage3 As Integer

    Public Sub lectureAss(ByVal path As String)
        Dim i As Integer
        Try

            Main.Grid.SelectAll()
            If Main.Grid.SelectedRows.Count > 0 Then
                Main.Grid.Rows.Clear()
            End If

            Dim file As New StreamReader(path) 'Ouvre le fichier
            Dim text As String
            Dim tested, section As Integer

            iDecoupage3 = 0

            Do Until file.Peek = -1 'boucle de lecture du fichier *1ere partie
                text = file.ReadLine

                If tested <> 1 AndAlso text <> "[Script Info]" Then 'test si la 1ere ligne est conforme a la norme ass
                    file.Close()
                    MsgBox("Fichier non conforme au norme ass detecté.")
                    GoTo erreur
                End If

                While text = Nothing AndAlso file.Peek <> -1 OrElse InStr(text, ";") = 1 OrElse InStr(text, "!:") = 1
                    text = file.ReadLine
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
                            decoupage(text)
                        Case 2
                            decoupage2(text)
                        Case 3
                            decoupage3(text)
                        Case 4
                            decoupage4(text)
                        Case 5
                            decoupage5(text)

                    End Select

                End If

            Loop

            file.Close()

            For i = 0 To 12
                Main.Grid.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader)
            Next

        Catch ex As Exception
            MsgBox("Le logiciel n'arrive pas a lire votre fichier.")
        End Try
erreur:
    End Sub

    Sub decoupage(ByVal texte As String)
        Dim charSeparators() As Char = {":"}
        Dim section() As String
        Dim i As Integer

        section = texte.Split(charSeparators, 2)
        i = Script_info.GetLength(1)
        If Script_info(0, i - 1) = Nothing And Script_info(0, i - 2) <> Nothing Then
            ReDim Preserve Script_info(1, i)
        End If
        i = Script_info.GetLength(1)
        Script_info(0, i - 2) = section(0)
        Script_info(1, i - 2) = section(1)

    End Sub

    Sub decoupage2(ByVal texte As String)
        Dim section(), sectionbis() As String
        Dim i, ii As Integer
        Dim charSeparators() As Char = {","}
        Dim charSeparators2() As Char = {":"}

        section = texte.Split(charSeparators2, 2)
        If section(0) = "Format" Then GoTo fin
        sectionbis = section(1).Split(charSeparators, 23, StringSplitOptions.None)
        ii = Styles.GetLength(1)
        If Styles(0, ii - 1) = Nothing And Styles(0, ii - 2) <> Nothing Then
            ReDim Preserve Styles(22, ii)
        End If

        ii = Styles.GetLength(1)
        For i = 0 To 22
            Styles(i, ii - 2) = sectionbis(i)
        Next
fin:
    End Sub

    Sub decoupage3(ByVal texte As String)
        Dim section(), sectionbis(), type As String
        Dim i, ii As Integer
        Dim charSeparators() As Char = {","}
        Dim charSeparators2() As Char = {":"}
        type = ""

        Try
            section = texte.Split(charSeparators2, 2)
            sectionbis = section(1).Split(charSeparators, 10, StringSplitOptions.None)
        Catch
            Exit Sub
        End Try
        If section(0) = "Format" Then GoTo fin
        If sectionbis(5).Length <> 4 And IsNumeric(sectionbis(5)) Then Exit Sub
        If sectionbis(6).Length <> 4 And IsNumeric(sectionbis(6)) Then Exit Sub
        If sectionbis(7).Length <> 4 And IsNumeric(sectionbis(7)) Then Exit Sub

        Select Case section(0)
            Case "Dialogue"
                type = "D"
            Case "Comment"
                type = "C"
            Case "Picture"
                type = "P"
            Case "Sound"
                type = "S"
            Case "Movie"
                type = "M"
            Case "Command"
                type = "Command"
        End Select

        iDecoupage3 += 1
        Dim Row(12) As String
        Row(0) = iDecoupage3
        Row(1) = i
        Row(2) = type
        Array.Copy(sectionbis, 0, Row, 3, 10)
        Main.Grid.Rows.Add(Row)

        ii = Dialogues.GetLength(1)
        If Dialogues(0, ii - 1) = Nothing And Dialogues(0, ii - 2) <> Nothing Then
            ReDim Preserve Dialogues(11, ii)
        End If
        ii = Dialogues.GetLength(1)
        Dialogues(0, ii - 2) = section(0)
        For i = 1 To 10
            Dialogues(i, ii - 2) = sectionbis(i - 1)
        Next

fin:
    End Sub

    Sub decoupage4(ByVal texte As String)
        Dim charSeparators() As Char = {":"}
        Dim section() As String
        Dim i As Integer

        section = texte.Split(charSeparators, 2)
        i = Fonts.GetLength(1)
        If Fonts(0, i - 1) = Nothing And Fonts(0, i - 2) <> Nothing Then
            ReDim Preserve Fonts(1, i)
        End If
        i = Fonts.GetLength(1)
        Fonts(0, i - 2) = section(0)
        Fonts(1, i - 2) = section(1)

    End Sub

    Sub decoupage5(ByVal texte As String)
        Dim charSeparators() As Char = {":"}
        Dim section() As String
        Dim i As Integer

        section = texte.Split(charSeparators, 2)
        i = Graphics.GetLength(1)
        If Graphics(0, i - 1) = Nothing And Graphics(0, i - 2) <> Nothing Then
            ReDim Preserve Graphics(1, i)
        End If
        i = Graphics.GetLength(1)
        Graphics(0, i - 2) = section(0)
        Graphics(1, i - 2) = section(1)

    End Sub

    Public Sub EnregistrementAss(ByVal path As String)
        Dim encoding As New System.Text.UnicodeEncoding
        Dim Fs As IO.FileStream = New IO.FileStream(path, IO.FileMode.Create)

        Dim file As New IO.StreamWriter(Fs, encoding)

        file.Write(SaveAss)
        'If CatSupp = 1 Then file.WriteLine(EnrFonts)
        'If CatSupp = 1 Then file.WriteLine(EnrGraphics)
        file.Close()
    End Sub

    Function SaveAss()

        Dim i, ii As Integer
        Dim stylebis, eventbis, script As String
        Dim style As String = "Style:"

        script = "[Script Info]" + ControlChars.CrLf + ControlChars.CrLf
        script += ";**********************************************" + ControlChars.CrLf
        script += ";***    Advanced Sub Station Alpha script   ***" + ControlChars.CrLf
        script += ";**********************************************" + ControlChars.CrLf
        script += ";***                                        ***" + ControlChars.CrLf
        script += ";***    This script has been created with   ***" + ControlChars.CrLf
        script += ";***                Expressub               ***" + ControlChars.CrLf
        script += ";***                                        ***" + ControlChars.CrLf
        script += ";**********************************************" + ControlChars.CrLf + ControlChars.CrLf

        For i = 0 To Script_info.GetLength(1) - 2
            script += Script_info(0, i) + ":" + Script_info(1, i) + ControlChars.CrLf
        Next
        script += ControlChars.CrLf + "[V4+ Styles]" + ControlChars.CrLf
        script += "Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding" + ControlChars.CrLf

        For i = 0 To Styles.GetLength(1) - 2
            stylebis = ""
            For ii = 0 To 21
                If Styles(0, i) = Nothing Then GoTo re
                stylebis += Styles(ii, i) + ","
            Next
            script += style + stylebis + Styles(22, i) + ControlChars.CrLf
re:
        Next

        script += ControlChars.CrLf + "[Events]" + ControlChars.CrLf
        script += "Format: Layer, Start, End, Style, Actor, MarginL, MarginR, MarginV, Effect, Text" + ControlChars.CrLf

        For i = 0 To Dialogues.GetLength(1) - 2
            eventbis = ""
            For ii = 1 To 9
                eventbis += Dialogues(ii, i) + ","
            Next
            script += Dialogues(0, i) + ":" + eventbis + Dialogues(10, i) + ControlChars.CrLf
        Next

        If Fonts(0, 0) <> Nothing Then
            script += ControlChars.CrLf + "[Fonts]" + ControlChars.CrLf + ControlChars.CrLf
            For i = 0 To Fonts.GetLength(1) - 2
                script += Fonts(0, i) + ":" + Fonts(1, i) + ControlChars.CrLf
            Next
        End If

        If Graphics(0, 0) <> Nothing Then
            script += ControlChars.CrLf + "[Graphics]" + ControlChars.CrLf + ControlChars.CrLf
            For i = 0 To Graphics.GetLength(1) - 2
                script += Graphics(0, i) + ":" + Graphics(1, i) + ControlChars.CrLf
            Next
        End If

        Return script
    End Function
End Module
