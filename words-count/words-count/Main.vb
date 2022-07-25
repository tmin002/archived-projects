Public Class main


    Private File As String = ""
    Private estr As String() = {}
    Private estrcnt As Integer = 0


    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        RichTextBox1.Clear()
        Me.Text = "New File"
    End Sub

    Private Sub VToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VToolStripMenuItem.Click

    End Sub

    Private Sub OpenFileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenFileToolStripMenuItem1.Click
        Dim a As New OpenFileDialog
        a.ShowDialog()

        Try
            RichTextBox1.Text = IO.File.ReadAllText(a.FileName)
            Me.File = a.FileName
            Me.Text = a.FileName
            Button1_Click()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        IO.File.WriteAllText(File, RichTextBox1.Text)
        Me.Text = Me.File
        Button1_Click()
    End Sub

    Private Sub SaveAsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem1.Click
        Dim a As New SaveFileDialog
        a.ShowDialog()

        Try
            IO.File.WriteAllText(a.FileName, RichTextBox1.Text)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
        Button1_Click()
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        If Not Me.Text.Contains("*") Then
            Me.Text += " *"
        End If
    End Sub

    Private Sub a() Handles Me.SizeChanged
        Button1.Location = New Point(Me.Width - 103, Button1.Location.Y)
        RichTextBox1.Size = New Point(Me.Width - 41, Me.Height - 135)
    End Sub

    Private Sub b() Handles RichTextBox1.TextChanged

    End Sub

    Private Sub FontsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontsToolStripMenuItem.Click
        Dim a As New FontDialog
        a.ShowDialog()
        RichTextBox1.Font = a.Font
    End Sub
    Private Delegate Sub d()

    Private Sub AddCountExceptionWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddCountExceptionWordToolStripMenuItem.Click
        Dim a As New ExcWnd
        For Each i In estr
            a.ListBox1.Items.Add(i)
        Next
        a.ShowDialog()

        estr = {}
        For Each i In a.ListBox1.Items
            ReDim estr(estrcnt)
            estr(estrcnt) = i
            estrcnt += 1
        Next


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        Label3.Text = RichTextBox1.Text.Count
        Dim a As String = RichTextBox1.Text
        For Each i In estr
            Try
                a = a.Replace(i, "")
            Catch ex As Exception
            End Try
        Next

        Label4.Text = a.Count
    End Sub


    Private clicked As Boolean = False
    Private Sub Button1_Click() Handles Button1.Click

        If Not clicked Then
            If MsgBox("This will erase your text and replace with the current file's text you loaded. sure to continue?", vbYesNo) = vbNo Then
                Exit Sub
            End If
        End If
        Try
            RichTextBox1.Text = IO.File.ReadAllText(File)
        Catch ex As Exception
        End Try
        Label3.Text = RichTextBox1.Text.Count
        Dim a As String = RichTextBox1.Text
        For Each i In estr
            Try
                a = a.Replace(i, "")
            Catch ex As Exception
            End Try
        Next

        Label4.Text = a.Count
        clicked = True

    End Sub

End Class
