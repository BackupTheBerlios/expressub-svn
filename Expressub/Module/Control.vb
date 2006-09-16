Module Control

    Sub ResizeGrid()
        Dim i As Integer

        For i = 0 To 12
            Main.Grid.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells)
        Next

        Main.Grid.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader)
        Main.Grid.AutoResizeColumn(3, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader)
        Main.Grid.AutoResizeColumn(7, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader)
        Main.Grid.AutoResizeColumn(11, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader)

        Main.Grid.Columns.Item(12).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft

    End Sub

    Sub ReziseAudioeditor()

        With Main.AudioEditor
            .MouseEventsEnabled = True
            .ScaleY.Visible = False
            .Channels.Num = 1
            .Channels.Visible = True
            .Channels.Num = 2
            .Channels.Visible = False
            .TypeBorder = 4
            .ScaleX.Type = 2
            .Size = New Size(Main.Audio.Width - 23, Main.Audio.Height - 36)
            .Location = New Point(3, 16)
        End With

    End Sub

    Sub ReziseScroll()

        With Main.VScrollAudio
            .Size = New Size(17, Main.Audio.Height - 36)
            .Location = New Point(Main.Audio.Width - 20, 16)
        End With

        With Main.HScrollAudio2
            .Size = New Size((Main.Audio.Width \ 4), 17)
            .Location = New Point(((Main.Audio.Width \ 4) * 3) - 2, Main.Audio.Height - 20)
        End With

        With Main.HScrollAudio
            .Size = New Size(((Main.Audio.Width \ 4) * 3) - 5, 17)
            .Location = New Point(3, Main.Audio.Height - 20)
        End With

    End Sub

    Sub hihi(ByVal haha As TabControl)

        haha.TabPages.Add("test")

    End Sub

End Module
