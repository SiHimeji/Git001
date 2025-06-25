Public Class FormMSTrank
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

    Private Sub FormMSTrank_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If

        Me.ToolStripStatusLabel1.Text = classLIB.Get会社情報
        Me.ToolStripStatusLabel1.BackColor = Color.LightGray

        Clear()
        disp()

    End Sub

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click

        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        Dim dt As DataTable
        Dim msg As String = String.Empty

        If Me.TextBoxランク.Text.Trim = "" Then
            msg = "ランクＩＤを入力してください"
        Else
            If Me.TextBoxランク.Text.Trim.Length <> 2 Then
                msg = "ランクＩＤは数字２桁で入力してください"
            End If
        End If

        If Me.TextBoxランク名.Text.Trim = "" Then
            If msg = "" Then
                msg = "ランク名を入力してください"
            Else
                msg &= vbCrLf & "ランク名を入力してください"
            End If
        End If
        If Me.ComboBox記念品.Text.Trim = "" Then
            If msg = "" Then
                msg = "記念品を選択してください"
            Else
                msg &= vbCrLf & "記念品を選択してください"
            End If
        End If

        If Me.NumericUpDown必要ポイント.Text.Trim = "" Then
            If msg = "" Then
                msg = "必要ポイントを入力してください"
            End If
        End If

        If Me.NumericUpDown寄附金額.Text.Trim = "" Then
            If msg = "" Then
                msg = "寄附金額を入力してください"
            End If
        End If

        If msg <> "" Then
            MessageBox.Show(msg)
            Exit Sub
        End If








        strSQL = "SELECT RANK_ID, RANK_NAM, KINENHIN, POINT, KIFUKIN FROM M_RANK WHERE  RANK_ID ='" & Me.TextBoxランク.Text.Trim & "'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then
            strSQL = ""
            strSQL &= "UPDATE M_RANK"
            strSQL &= " SET RANK_NAM='" & Me.TextBoxランク名.Text.Trim & "'"
            strSQL &= " , POINT= " & Me.NumericUpDown必要ポイント.Text.Trim & ""
            strSQL &= " , KINENHIN= '" & Me.ComboBox記念品.Text.Trim & "'"
            strSQL &= " , KIFUKIN= " & Me.NumericUpDown寄附金額.Text.Trim & ""
            strSQL &= " , UPDATE_DAY = " & classSQLite.GetTimeSQL & ""
            strSQL &= " , UPDATE_NAM = '" & UserID & "'"
            strSQL &= " WHERE RANK_ID='" & Me.TextBoxランク.Text.Trim & "'"
        Else
            strSQL = ""
            strSQL &= "INSERT INTO M_RANK"
            strSQL &= "(RANK_ID, RANK_NAM, KINENHIN, POINT, KIFUKIN, ENTRY_DAY, ENTRY_NAM, UPDATE_DAY, UPDATE_NAM)"
            strSQL &= "VALUES("
            strSQL &= " '" & Me.TextBoxランク.Text.Trim & "'"
            strSQL &= " , '" & Me.TextBoxランク名.Text.Trim & "'"
            strSQL &= " , '" & Me.ComboBox記念品.Text.Trim & "'"
            strSQL &= " , " & Me.NumericUpDown必要ポイント.Text.Trim & ""
            strSQL &= " , " & Me.NumericUpDown寄附金額.Text.Trim & ""
            strSQL &= " ," & classSQLite.GetTimeSQL & ""
            strSQL &= " ,'" & UserID & "'"
            strSQL &= " ," & classSQLite.GetTimeSQL & ""
            strSQL &= " ,'" & UserID & "'"
            strSQL &= " )"

        End If
        If classSQLite.EXEC(strSQL) Then
            Clear()
        End If

        disp()

    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click

        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        Dim dt As DataTable

        strSQL = "SELECT RANK_ID, RANK_NAM, POINT, KIFUKIN FROM M_RANK WHERE  RANK_ID ='" & Me.TextBoxランク.Text.Trim & "'"
        dt = classSQLite.SetDataTable(strSQL)

        If dt.Rows.Count = 1 Then

            strSQL = ""
            strSQL &= "DELETE FROM M_RANK"
            strSQL &= " WHERE RANK_ID ='" & Me.TextBoxランク.Text.Trim & "'"
            If classSQLite.EXEC(strSQL) Then
                Clear()
                disp()
            End If
        End If

    End Sub
    Private Sub disp()

        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim ro As Integer = 0

        '記念品コンボボックス
        strSQL = "SELECT KINENHIN FROM M_KINEN ORDER BY KINENHIN_ID"
        dt = classSQLite.SetDataTable(strSQL)

        ComboBox記念品.Items.Clear()
        For Each rows In dt.Rows
            ComboBox記念品.Items.Add(rows("KINENHIN"))
        Next

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        strSQL = "SELECT RANK_ID, RANK_NAM, POINT, KIFUKIN, KINENHIN FROM M_RANK ORDER BY RANK_ID"
        dt = classSQLite.SetDataTable(strSQL)


        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "RANK_ID", "ランクID", 90, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "RANK_NAM", "ランク名", 100, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "KINENHIN", "記念品", 420, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "POINT", "必要ポイント", 140, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "KIFUKIN", "寄附金額", 120, True)
        'ro = classLIB.SettextColumn(Me.DataGridView1, ro, "KANSANROTU", "加算率", 120, True)

        Me.DataGridView1.Columns(3).DefaultCellStyle.Format = "#,0"     '必要ポイント
        Me.DataGridView1.Columns(4).DefaultCellStyle.Format = "#,0"     '寄付金
        Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight     '必要ポイント
        Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight     '寄付金

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)
    End Sub
    Private Sub Clear()

        Me.TextBoxランク.Text = ""
        Me.TextBoxランク名.Text = ""
        Me.NumericUpDown必要ポイント.Value = 0
        Me.NumericUpDown必要ポイント.Maximum = 10000000

        Me.NumericUpDown寄附金額.Value = 0
        Me.NumericUpDown寄附金額.Maximum = 10000000

        Me.ComboBox記念品.SelectedIndex = -1

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim ro As Integer
        ro = e.RowIndex
        If ro < 0 Then
            Return
        End If
        If e.Button = MouseButtons.Left Then

            Me.TextBoxランク.Text = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
            Me.TextBoxランク名.Text = Me.DataGridView1.Rows(ro).Cells(1).Value.ToString
            Me.ComboBox記念品.Text = Me.DataGridView1.Rows(ro).Cells(2).Value.ToString
            Me.NumericUpDown必要ポイント.Text = Me.DataGridView1.Rows(ro).Cells(3).Value.ToString
            Me.NumericUpDown寄附金額.Text = Me.DataGridView1.Rows(ro).Cells(4).Value.ToString
            'Me.TextBox換算率.Text = Me.DataGridView1.Rows(ro).Cells(4).Value.ToString

        End If

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        Dim classExcel As New ClassExcel
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            classExcel.excelOutDataGred03(Me.DataGridView1, 0)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If

    End Sub

    Private Sub Buttonクリア_Click(sender As Object, e As EventArgs) Handles Buttonクリア.Click
        Clear()
    End Sub
End Class