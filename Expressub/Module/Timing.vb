Module Timing
    Public Function msTohms(ByVal ms As Integer)
        Dim h, mm, ss, ms2 As String
        h = ms \ 3600000
        mm = Double0((ms \ 60000) - (h * 60))
        ss = Double0((ms \ 1000) - (mm * 60) - (h * 3600))
        ms2 = ms - (ss * 1000) - (mm * 60000) - (h * 3600000)

        Return h & ":" & mm & ":" & ss & "." & Double0(ms2 \ 10)
    End Function

    Public Function hmsToms(ByVal hms As String)
        Dim charSeparators() As Char = {"."}
        Dim charSeparators2() As Char = {":"}
        Dim section(), sectionbis() As String

        section = hms.Split(charSeparators, StringSplitOptions.None)
        sectionbis = section(0).Split(charSeparators2)
        Return (sectionbis(0) * 3600000 + sectionbis(1) * 60000 + sectionbis(2) * 1000 + section(1) * 10)
    End Function

    Private Function Double0(ByVal texte As String)

        If texte = "0" Then
            Return "00"
        Else
            If texte.Length = 1 Then
                texte = "0" & texte
            End If
            Return texte
        End If
    End Function

    Public Sub AudioStartSelect(ByVal FrameStart As Integer)
        Main.AudioEditor.Position.Selected = 1
        Main.AudioEditor.Position.StartSelect = FrameStart
        RefreshStartTimeBox(FrameStart)

        'AudioEditor.Markers.Insert(FrameStart, 500000, "label", "note", "texte", 0, 0, 0, 0)
    End Sub

    Public Sub AudioEndSelect(ByVal FrameEnd As Integer)

        If FrameEnd < Main.AudioEditor.Position.StartSelect Then
            Main.AudioEditor.Position.Selected = 0
            Main.AudioEditor.Position.StartSelect = FrameEnd
        End If
        Main.AudioEditor.Position.Selected = 1
        Main.AudioEditor.Position.EndSelect = FrameEnd
        RefreshEndTimeBox(FrameEnd)
    End Sub

    Public Sub RefreshStartTimeBox(ByVal Framestart As Integer)
        Main.StartTimeBox.Text = msTohms(Main.AudioEditor.Position.SamplesToSec(Framestart))
    End Sub

    Public Sub RefreshEndTimeBox(ByVal FrameEnd As Integer)
        Main.EndTimeBox.Text = msTohms(Main.AudioEditor.Position.SamplesToSec(FrameEnd))
    End Sub
End Module
