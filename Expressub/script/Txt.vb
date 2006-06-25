Imports System.IO
Module Txt
    Private iDecoupage As Integer

    Public Sub lectureTxt(ByVal path As String)
        Dim i As Integer

        OptionTxt.ShowDialog()

        Try

            Main.Grid.SelectAll()
            If Main.Grid.SelectedRows.Count > 0 Then
                Main.Grid.Rows.Clear()
            End If

            ReDim Styles(22, 1)

            Dim file As New StreamReader(path) 'Ouvre le fichier
            Dim text As String

            iDecoupage = 0

            Do Until file.Peek = -1 'boucle de lecture du fichier 1ere partie
                text = file.ReadLine

                While text = Nothing AndAlso file.Peek <> -1 OrElse InStr(text, ";") = 1 OrElse InStr(text, "!:") = 1
                    text = file.ReadLine
                End While

                If InStr(text, "[") = 1 Then

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

    Sub DecoupageTxt(ByVal texte As String)
        Dim charSeparators() As String = {":"}
        Dim section() As String

        section = texte.Split(charSeparators, StringSplitOptions.None)

        iDecoupage += 1

        Dim Row(12) As String

        Row(0) = iDecoupage.ToString
        Row(1) = "0"
        Row(2) = "Dialogue"
        'Array.Copy(sectionbis, 0, Row, 3, 10)
        Main.Grid.Rows.Add(Row)
    End Sub

End Module
