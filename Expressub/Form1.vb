Public Class Form1

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Main.video.Dispose()
        Main.video = Nothing
    End Sub
End Class