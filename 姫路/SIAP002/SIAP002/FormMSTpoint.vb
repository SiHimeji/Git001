Public Class FormMSTpoint
    '-----------------------------------------------------
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ZenKakuHankaku As Boolean = False


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


    Private Sub FormMSTpoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If

        Me.ToolStripStatusLabel1.Text = classLIB.Get会社情報
        Me.ToolStripStatusLabel1.BackColor = Color.LightGray

        disp()

    End Sub
    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        Dim dt As DataTable
        Dim msg As String = String.Empty


        If Me.TextBox商品名.Text.Trim = "" Then
            msg = "商品名を入力してください"
        End If

        If Me.TextBox換算率.Text.Trim = "" Then
            If msg = "" Then
                msg = "換算率を入力してください"
            Else
                msg &= vbCrLf & "換算率を入力してください"
            End If
        End If

        If msg <> "" Then
            MessageBox.Show(msg)
            Exit Sub
        End If


        strSQL = "SELECT SYOHIN, KIFUKINAGKU, POINT, KANSANROTU FROM M_POINT WHERE  SYOHIN ='" & Me.TextBox商品名.Text.Trim & "'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then
            strSQL = ""
            strSQL &= "UPDATE M_POINT"
            strSQL &= " SET POINT = " & Me.NumericUpDownポイント.Text.Trim & ""
            strSQL &= " , KIFUKINAGKU = " & Me.NumericUpDown寄付金額.Text.Trim & ""
            strSQL &= " , KANSANROTU = '" & Me.TextBox換算率.Text.Trim & "'"
            strSQL &= " , UPDATE_DAY = " & classSQLite.GetTimeSQL & ""
            strSQL &= " , UPDATE_NAM = '" & UserID & "'"
            strSQL &= " WHERE SYOHIN = '" & Me.TextBox商品名.Text.Trim & "'"
        Else
            strSQL = ""
            strSQL &= "INSERT INTO M_POINT"
            strSQL &= "(SYOHIN, KIFUKINAGKU, POINT, KANSANROTU, ENTRY_DAY, ENTRY_NAM, UPDATE_DAY, UPDATE_NAM)"
            strSQL &= "VALUES("
            strSQL &= "  '" & Me.TextBox商品名.Text.Trim & "'"
            strSQL &= " , " & Me.NumericUpDown寄付金額.Text.Trim & ""
            strSQL &= " , " & Me.NumericUpDownポイント.Text.Trim & ""
            strSQL &= " ,'" & Me.TextBox換算率.Text.Trim & "'"
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

        strSQL = "SELECT SYOHIN, KIFUKINAGKU, POINT, KANSANROTU FROM M_POINT WHERE  SYOHIN ='" & Me.TextBox商品名.Text.Trim & "'"
        dt = classSQLite.SetDataTable(strSQL)

        If dt.Rows.Count = 1 Then

            strSQL = ""
            strSQL &= "DELETE FROM M_POINT"
            strSQL &= " WHERE SYOHIN ='" & Me.TextBox商品名.Text.Trim & "'"
            If classSQLite.EXEC(strSQL) Then
                disp()
            End If
        End If

    End Sub
    Private Sub disp()

        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim ro As Integer = 0

        Clear()

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        strSQL = "SELECT SYOHIN, KIFUKINAGKU, POINT, KANSANROTU FROM M_POINT ORDER BY POINT"
        dt = classSQLite.SetDataTable(strSQL)


        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOHIN", "商品名", 260, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "KIFUKINAGKU", "寄附金額", 120, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "POINT", "石(ポイント)", 140, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "KANSANROTU", "換算率", 120, True)

        Me.DataGridView1.Columns(1).DefaultCellStyle.Format = "#,0"     '寄付金
        Me.DataGridView1.Columns(2).DefaultCellStyle.Format = "#,0"     'ポイント
        Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight     '寄付金
        Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight     'ポイント
        Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight     '加算率

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

        ZenKakuHankaku = False

        '商品名半角チェック　2023/12/28 
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            If StrConv(Me.DataGridView1.Rows(ro).Cells(0).Value, VbStrConv.Narrow) <> Me.DataGridView1.Rows(ro).Cells(0).Value Then
                Me.DataGridView1.Rows(ro).Cells(0).Value = StrConv(Me.DataGridView1.Rows(ro).Cells(0).Value, VbStrConv.Narrow)
                ZenKakuHankaku = True
            End If
        Next

    End Sub
    Private Sub Clear()

        Me.TextBox商品名.Text = ""
        Me.TextBox換算率.Text = ""

        Me.NumericUpDownポイント.Value = 0
        Me.NumericUpDownポイント.Maximum = 10000000

        Me.NumericUpDown寄付金額.Value = 0
        Me.NumericUpDown寄付金額.Maximum = 10000000
    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim ro As Integer
        ro = e.RowIndex
        If ro < 0 Then
            Return
        End If
        If e.Button = MouseButtons.Left Then

            Me.TextBox商品名.Text = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
            Me.NumericUpDown寄付金額.Text = Me.DataGridView1.Rows(ro).Cells(1).Value.ToString
            Me.NumericUpDownポイント.Text = Me.DataGridView1.Rows(ro).Cells(2).Value.ToString
            Me.TextBox換算率.Text = Me.DataGridView1.Rows(ro).Cells(3).Value.ToString

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

    Private Sub FormMSTpoint_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String
        Dim ro As Integer

        If ZenKakuHankaku Then
            Try
                classSQLite.DbOpen()
                classSQLite.BeginTrans()
                classSQLite.EXEC_tr("DELETE FROM M_POINT")
                For ro = 0 To Me.DataGridView1.Rows.Count - 1
                    strSQL = ""
                    strSQL &= "INSERT INTO M_POINT"
                    strSQL &= "(SYOHIN, KIFUKINAGKU, POINT, KANSANROTU, ENTRY_DAY, ENTRY_NAM, UPDATE_DAY, UPDATE_NAM)"
                    strSQL &= "VALUES("
                    strSQL &= "  '" & Me.DataGridView1.Rows(ro).Cells(0).Value.ToString.Trim & "'"
                    strSQL &= " , " & Me.DataGridView1.Rows(ro).Cells(1).Value.ToString.Trim & ""
                    strSQL &= " , " & Me.DataGridView1.Rows(ro).Cells(2).Value.ToString.Trim & ""
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(3).Value.ToString.Trim & "'"
                    strSQL &= " ," & classSQLite.GetTimeSQL & ""
                    strSQL &= " ,'" & UserID & "'"
                    strSQL &= " ," & classSQLite.GetTimeSQL & ""
                    strSQL &= " ,'" & UserID & "'"
                    strSQL &= " )"
                    classSQLite.EXEC_tr(strSQL)
                Next
                classSQLite.Commit()
                classSQLite.DbClose()
            Catch ex As Exception
                classSQLite.Rollback()
                classSQLite.DbClose()
            End Try
        End If
    End Sub
End Class