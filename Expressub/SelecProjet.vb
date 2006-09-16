Imports System.Windows.Forms

Public Class SelecProjet

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim index, i As Integer

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If CheckedListBox1.CheckedItems.Count < 0 Then
            MsgBox("Veuillez selectioner au moin une option")
        Else

            For i = 0 To Form1.TabControl1.TabPages.Count - 1

                If Form1.TabControl1.TabPages.Item(i).Name = TextBox1.Text Then
                    MsgBox("le projet que vous essayez d'ouvrir existe deja")
                    GoTo erreur
                End If

            Next

            Form1.TabControl1.TabPages.Add(TextBox1.Text)

            index = Form1.TabControl1.TabPages.Count - 1

            Dim ptabcontrol As New Form2
            Dim tabcontrol As New TabControl

            tabcontrol.Parent = Form1.TabControl1.TabPages(index)
            tabcontrol.Name = "tabcontrol" & index

            For i = 0 To CheckedListBox1.CheckedItems.Count - 1

                Select Case CheckedListBox1.CheckedItems(i).ToString()

                    Case "Traduction"
                        tabcontrol.TabPages.Add(ptabcontrol.TabControl1.TabPages("Traduction"))
                    Case "Adapt"
                        tabcontrol.TabPages.Add(ptabcontrol.TabControl1.TabPages("Adaptation"))
                    Case "Time"
                        tabcontrol.TabPages.Add(ptabcontrol.TabControl1.TabPages("Time"))
                    Case "Edit"
                        tabcontrol.TabPages.Add(ptabcontrol.TabControl1.TabPages("Edition"))
                    Case "Kara"
                        tabcontrol.TabPages.Add(ptabcontrol.TabControl1.TabPages("Karaoké"))

                End Select

            Next
            Me.Close()
        End If
erreur:
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
