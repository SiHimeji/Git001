Imports System.IO
Public Class FormBackUp
    '-----------------------------------------------------
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Public Property UserID As String
        Get
            UserID = _UserID
        End Get
        Set(value As String)
            _UserID = value
        End Set
    End Property

    Public Property Kengen As String
        Get
            Kengen = _Kengen
        End Get
        Set(value As String)
            _Kengen = value
        End Set
    End Property
    Public Property UserName As String
        Get
            UserName = _UserName
        End Get
        Set(value As String)
            _UserName = value
        End Set
    End Property
    '-----------------------------------------------------
    Dim classLIB As New ClassLIB
    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FormBackUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)

        Me.TextBoxバックアップファイル.Text = classLIB.gstrdbPath & "\" & classLIB.gstrdbFile
        'システムマスタ区分20 から設定値を読み出す
        strSQL = "SELECT ms.NAIYOU  FROM M_SYSTEM ms WHERE ms.KBN ='20'"
        Me.TextBoxバックアップ先.Text = classSQLite.GetOneRecode(strSQL)

        Me.ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub Buttonバックアップ先指定_Click(sender As Object, e As EventArgs) Handles Buttonバックアップ先指定.Click
        'システムマスタ区分20 に設定する
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)

        Dim fbd As New FolderBrowserDialog

        fbd.Description = "フォルダを指定してください。"
        fbd.RootFolder = Environment.SpecialFolder.Desktop
        fbd.SelectedPath = ""
        fbd.ShowNewFolderButton = True
        If fbd.ShowDialog(Me) = DialogResult.OK Then
            '選択されたフォルダを表示する
            Me.TextBoxバックアップ先.Text = fbd.SelectedPath
            strSQL = "UPDATE M_SYSTEM SET NAIYOU = '" & Me.TextBoxバックアップ先.Text.Trim & "' WHERE KBN ='20'"
            classSQLite.EXEC(strSQL)

        End If

    End Sub

    Private Sub Button実行_Click(sender As Object, e As EventArgs) Handles Button実行.Click
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String
        Dim dy As DateTime = DateTime.Now
        Try

            Dim path1 As String = Me.TextBoxバックアップファイル.Text
            Dim path2 As String = Me.TextBoxバックアップ先.Text & "\\" & dy.ToString("yyyyMMdd-HHmmss") & "-HIMEJI.DB"

            If System.IO.File.Exists(path1) = False Then
                MessageBox.Show("バックアップデータベースファイルが存在しません")
                Exit Sub
            End If
            If System.IO.Directory.Exists(Me.TextBoxバックアップ先.Text) = False Then
                MessageBox.Show("バックアップ先のディレクトリが存在しません")
                Exit Sub

            End If
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.ToolStripStatusLabel1.Text = "DB VACUUM!"
            classSQLite.VACUUM()
            Me.ToolStripStatusLabel1.Text = "BackUp!"
            File.Copy(path1, path2)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Me.ToolStripStatusLabel1.Text = ""

            strSQL = "INSERT INTO T_LOG(ID, USERNAME, LOG, ENTRY_DAY)VALUES('バックアップ', '" & UserID & "', '" & path2 & "'," & classSQLite.GetTimeSQL & ")"
            classSQLite.EXEC(strSQL)

            MessageBox.Show("バックアップしました")

        Catch ex As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Me.ToolStripStatusLabel1.Text = "BackUp Error!"
            MessageBox.Show("バックアップエラーです。" & vbCrLf& & ex.Message)
        End Try

    End Sub
End Class