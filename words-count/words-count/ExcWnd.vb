Public Class ExcWnd
    Private Sub ExcWnd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub addtolist(text As String)
        If ListBox1.Items.Contains(text) Then
            MsgBox("text already exists.")
        Else
            ListBox1.Items.Add(text)
        End If
    End Sub

    Private Sub addbtn_Click(sender As Object, e As EventArgs) Handles addbtn.Click
        addtolist(textbox1.Text)
    End Sub

    Private Sub addnbtn_Click(sender As Object, e As EventArgs) Handles addnbtn.Click
        addtolist(vbCrLf)
    End Sub

    Private Sub addtabbtn_Click(sender As Object, e As EventArgs) Handles addtabbtn.Click
        addtolist("	")
    End Sub

    Private Sub addspacebtn_Click(sender As Object, e As EventArgs) Handles addspacebtn.Click
        addtolist(" ")
    End Sub

    Private Sub removebtn_Click(sender As Object, e As EventArgs) Handles removebtn.Click
        If ListBox1.SelectedIndex = -1 Then
            Exit Sub
        End If
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
    End Sub
End Class