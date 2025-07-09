
Imports ClassIF
Imports System.IO



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

    Private Sub Button検索出庫_Click(sender As Object, e As EventArgs) Handles Button検索出庫.Click
        Dim ret As String = SelectFile()
        If ret.Length > 0 Then
            Me.TextBox出庫.Text = ret
        End If

    End Sub
    Private Sub Button出庫取り込み_Click(sender As Object, e As EventArgs) Handles Button出庫取り込み.Click
        Dim cLib As New ClassIF.ClassIF出庫()
        If Me.TextBox出庫.Text.Length > 0 Then

            Me.ToolStripStatusLabel1.Text = ""
            If File.Exists(Me.TextBox出庫.Text) Then
                cLib.csvINsert出庫(Me.TextBox出庫.Text)
            Else
                Me.ToolStripStatusLabel1.Text = "ファイルは存在しません。"
            End If

        End If
    End Sub


    Private Sub Button訂正_Click(sender As Object, e As EventArgs) Handles Button訂正.Click
        Dim ret As String = SelectFile()
        If ret.Length > 0 Then
            Me.TextBox訂正.Text = ret
        End If
    End Sub

    Private Sub Button訂正取り込み_Click(sender As Object, e As EventArgs) Handles Button訂正取り込み.Click
        Dim cLib As New ClassIF.ClassIF訂正()
        If Me.TextBox訂正.Text.Length > 0 Then

            Me.ToolStripStatusLabel1.Text = ""
            If File.Exists(Me.TextBox訂正.Text) Then
                cLib.csvINsert訂正(Me.TextBox訂正.Text)
            Else
                Me.ToolStripStatusLabel1.Text = "ファイルは存在しません。"
            End If

        End If
    End Sub
    Private Function SelectFile()

        Dim openFileDialog As New OpenFileDialog()

        ' ダイアログの設定
        openFileDialog.Title = "ファイルを選択してください"
        openFileDialog.Filter = "テキストファイル (*.csv)|*.csv|すべてのファイル (*.*)|*.*"
        'openFileDialog.InitialDirectory = "C:\"
        ' ダイアログを表示し、結果を確認
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' 選択されたファイルパスを取得
            Dim selectedFilePath As String = openFileDialog.FileName
            Return selectedFilePath
        End If
        Return ""
    End Function




End Class
