Imports System.Data

Module GestionDB

    Sub AjoutDataTable(ByVal Type As String, ByVal Name As String)
        Dim NameTable As String = Type & ":" & Name

        Form2.Database.Tables.Add(New DataTable(NameTable))

        Select Case Type

            Case "ScriptInfo"
                Form2.Database.Tables(NameTable).Merge(Form2.Database.Tables("ScriptInfo"))

            Case "Styles"
                Form2.Database.Tables(NameTable).Merge(Form2.Database.Tables("Styles"))

            Case "Events"
                Form2.Database.Tables(NameTable).Merge(Form2.Database.Tables("Events"))

            Case "Fonts"
                Form2.Database.Tables(NameTable).Merge(Form2.Database.Tables("Fonts"))

            Case "Graphics"
                Form2.Database.Tables(NameTable).Merge(Form2.Database.Tables("Graphics"))

        End Select

    End Sub

End Module
