Public Class FormLog
    Dim classLIB As New ClassLIB

    Private Sub FormLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Me.ToolStripStatusLabel1.Text = classLIB.Get会社情報
        Me.ToolStripStatusLabel1.BackColor = Color.LightGray

        LogDelete()

        Disp()

    End Sub

    Private Sub LogDelete()
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        'Dim hi As Integer
        Dim hi As String

        strSQL = "SELECT NAIYOU FROM M_SYSTEM WHERE KBN  ='10'"
        'hi = Integer.Parse(StrConv(classSQLite.GetOneRecode(strSQL), vbNarrow))
        hi = StrConv(classSQLite.GetOneRecode(strSQL), vbNarrow)

        If IsNumeric(hi) = False Then
            MessageBox.Show("システムマスタ【10】で日数を指定してください")
            Exit Sub
        End If

        Dim day As DateTime = DateTime.Now

        day = day.AddDays(0 - Integer.Parse(hi))
        strSQL = "DELETE FROM T_LOG  WHERE  ENTRY_DAY < '" & day.ToString & "'"
        If classSQLite.EXEC(strSQL) Then

        End If

    End Sub
    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub Disp()
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim ro As Integer = 0
        Dim dt As DataTable
        strSQL = "SELECT ID, USERNAME, LOG, ENTRY_DAY FROM T_LOG ORDER BY ENTRY_DAY DESC"
        dt = classSQLite.SetDataTable(strSQL)


        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "ID", "ＩＤ", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "USERNAME", "ユーザーＩＤ", 200, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "LOG", "ログ", 500, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "ENTRY_DAY", "日時間", 500, True)

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False

    End Sub

    Private Sub 削除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 削除ToolStripMenuItem.Click
        Dim inputText As String
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty

        inputText = InputBox("何日以前を削除しますか", "削除期間", "10", 200, 100)
        If IsNumeric(inputText) Then
            Dim day As DateTime = DateTime.Now
            If inputText < 0 Then
                MessageBox.Show(inputText & "日は削除できません")
                Exit Sub
            End If
            day = day.AddDays(0 - Integer.Parse(inputText))
            strSQL = "DELETE FROM T_LOG  where  ENTRY_DAY < '" & day.ToString & "'"
            If classSQLite.EXEC(strSQL) Then
                Disp()
            End If
        End If

    End Sub

    Private Sub EXCLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCLToolStripMenuItem.Click
        Dim classExcel As New ClassExcel
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            classExcel.excelOutDataGred03(Me.DataGridView1, 0)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub 出力ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 出力ToolStripMenuItem.Click

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class