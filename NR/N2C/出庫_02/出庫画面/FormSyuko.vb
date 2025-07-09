
Imports ClassIF

Public Class FormSyuko
    Private Sub FormSyuko_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub 出庫ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 出庫ToolStripMenuItem.Click

        Dim cLib As New ClassIF.ClassIF出庫()
        cLib.csvINsert出庫("D:\01_Work\04_NR\06_点検センター\70_N2C対応\ソース\NEXTB002.csv")


    End Sub
End Class
