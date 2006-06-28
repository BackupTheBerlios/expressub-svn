Module Timing

    Public Function msTohms(ByVal ms As Integer) As String
        Dim h, mm, ss, ms2 As Integer

        h = ms \ 3600000
        mm = CType(CType((ms \ 60000) - (h * 60), String), Integer)
        ss = CType(CType((ms \ 1000) - (mm * 60) - (h * 3600), String), Integer)
        ms2 = ms - (ss * 1000) - (mm * 60000) - (h * 3600000)

        Return h & ":" & DoubleDigit(CType(mm, String)) & ":" & DoubleDigit(CType(ss, String)) & "." & DoubleDigit(CType((ms2 \ 10), String))

    End Function

    Public Function hmsToms(ByVal hms As String) As Integer
        Dim charSeparators() As String = {"."}
        Dim charSeparators2() As String = {":"}
        Dim section(), sectionbis() As String

        section = hms.Split(charSeparators, StringSplitOptions.None)
        sectionbis = section(0).Split(charSeparators2, StringSplitOptions.None)

        Return (CType(sectionbis(0), Integer) * 3600000 + CType(sectionbis(1), Integer) * 60000 + CType(sectionbis(2), Integer) * 1000 + CType(section(1), Integer) * 10)

    End Function

    Private Function DoubleDigit(ByVal texte As String) As String

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

        Main.AudioEditor.Position.Selected = True
        Main.AudioEditor.Position.StartSelect = FrameStart
        RefreshStartTimeBox(FrameStart)

    End Sub

    Public Sub AudioEndSelect(ByVal FrameEnd As Integer)

        If FrameEnd < Main.AudioEditor.Position.StartSelect Then
            Main.AudioEditor.Position.Selected = False
        Else
            Main.AudioEditor.Position.Selected = True
        End If

        Main.AudioEditor.Position.EndSelect = FrameEnd
        RefreshEndTimeBox(FrameEnd)

    End Sub

    Public Sub RefreshStartTimeBox(ByVal Framestart As Integer)

        If Framestart <> 0 Then
            Main.StartTimeBox.Text = msTohms(Main.AudioEditor.Position.SamplesToSec(Framestart)).ToString
        End If

    End Sub

    Public Sub RefreshEndTimeBox(ByVal FrameEnd As Integer)

        If FrameEnd <> 0 Then
            Dim hihi As Integer = Main.AudioEditor.Position.SamplesToSec(FrameEnd)
            Main.EndTimeBox.Text = msTohms(Main.AudioEditor.Position.SamplesToSec(FrameEnd)).ToString
        End If

    End Sub

End Module
