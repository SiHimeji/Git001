Public Class FormRiseki
    '-----------------------------------------------------
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim _NID As String = String.Empty
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
    Public Property NID As String
        Get
            NID = _NID
        End Get
        Set(value As String)
            _NID = value
        End Set
    End Property
    '-----------------------------------------------------
    Dim classLIB As New ClassLIB
    'Dim classRuiseki As New ClassRuiseki

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button明細表示_Click(sender As Object, e As EventArgs) Handles Button明細表示.Click


        Dim fm As New FormMeisai
        fm.UP = "1"
        fm.UserID = UserID
        fm.UserName = UserName
        fm.Kengen = Kengen
        fm.NID = NID
        fm.ShowDialog()
        disp()
        Soufu()

    End Sub

    Private Sub FormRiseki_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Me.ToolStripStatusLabel1.Text = classLIB.Get会社情報
        Me.ToolStripStatusLabel1.BackColor = Color.LightGray

        Me.TextBox顧客ID.Text = NID
        SetComboxRanku()

        disp()
        Soufu()

    End Sub

    Private Sub SetComboxRanku()
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Me.ComboBoxランク.Items.Clear()
        Me.ComboBoxランク.Items.Add("")

        strSQL = "select RANK_NAM  from M_RANK ORDER BY RANK_ID"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            For Each row In dt.Rows
                Me.ComboBoxランク.Items.Add(row("RANK_NAM").ToString)
            Next
        End If
    End Sub



    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        'キーはNIDです　UpDateしか存在しません
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim classNayose As New ClassNayose
        Dim classRuiseki As New ClassRuiseki
        '--- チェック
        If Not IsDate(Me.TextBox入金日.Text) Then
            MessageBox.Show("入金日が日付型ではありません")
            Exit Sub
        End If
        For row As Integer = 0 To Me.DataGridViewSoufu.Rows.Count - 1
            If Me.DataGridViewSoufu.Rows(row).Cells(3).Value.ToString.Length > 0 Then
                If Not IsDate(Me.DataGridViewSoufu.Rows(row).Cells(3).Value) Then
                    MessageBox.Show("送付日が日付型ではありません")
                    Exit Sub
                End If
            End If

        Next

        '--- チェック

        Cursor.Current = Cursors.WaitCursor

        classSQLite.DbOpen()
        classSQLite.BeginTrans()
        Try

            For row As Integer = 0 To Me.DataGridViewSoufu.Rows.Count - 1
                strSQL = ""
                strSQL &= "UPDATE T_SOUFU"
                strSQL &= " SET KINENHINSENDDAY ='" & Me.DataGridViewSoufu.Rows(row).Cells(3).Value.ToString & "'"
                strSQL &= "  ,SIRIAL='" & Me.DataGridViewSoufu.Rows(row).Cells(4).Value.ToString & "'"
                strSQL &= " , UPDATE_DAY=" & classSQLite.GetTimeSQL & ""
                strSQL &= " , UPDATE_NAM='" & UserID & "'"
                strSQL &= "  WHERE NID='" & Me.TextBox顧客ID.Text.Trim & "' "
                strSQL &= "  AND RANK_NAM='" & Me.DataGridViewSoufu.Rows(row).Cells(1).Value.ToString & "'"

                classSQLite.EXEC_tr(strSQL)

                If Me.DataGridViewSoufu.Rows(row).Cells(3).Value.ToString = "" Then
                    strSQL = ""
                    strSQL &= "UPDATE T_RUISEKI"
                    strSQL &= " SET RANKUPFLG='1'"
                    strSQL &= " , UPDATE_DAY=" & classSQLite.GetTimeSQL & ""
                    strSQL &= " , UPDATE_NAM='" & UserID & "'"
                    strSQL &= " WHERE NID='" & Me.TextBox顧客ID.Text.Trim & "'"
                    classSQLite.EXEC_tr(strSQL)

                End If
            Next


            '------------------------------------------------------------------------------------

            strSQL = ""
            strSQL &= "UPDATE T_RUISEKI"
            strSQL &= " SET FULLNAM='" & Me.TextBox名前.Text.Trim & "'"
            strSQL &= " , KANA='" & Me.TextBoxフリガナ.Text.Trim & "'"
            strSQL &= " , ZIPCD='" & Me.TextBox郵便番号.Text.Trim & "'"
            strSQL &= " , ADMIN='" & Me.ComboBox都道府県.Text.Trim & "'"
            strSQL &= " , CITY='" & Me.TextBox市区町村.Text.Trim & "'"
            strSQL &= " , TOWN='" & Me.TextBox番地マンション名.Text.Trim & "'"
            strSQL &= " , TEL='" & Me.TextBox電話番号.Text.Trim & "'"
            strSQL &= " , MAIL='" & Me.TextBoxEmailアドレス.Text.Trim & "'"
            strSQL &= " , KOKUDAKA=" & Me.NumericUpDown累積石高.Value.ToString & ""
            'strSQL &= " , KOKUDAKAFLG=''"
            strSQL &= " , RANK='" & Me.ComboBoxランク.Text & "'"
            'If Me.DataGridViewSoufu.Rows(row).Cells(3).Value.ToString = "" Then
            'strSQL &= " , RANKUPFLG='1'"
            'End If

            If Me.DataGridViewSoufu.Rows.Count = 0 And Me.ComboBoxランク.Text = "" Then
                strSQL &= " , RANKUPFLG='0'"
            End If

            'strSQL &= " , KINENHIN='" & GetSpufuRyaku(Me.TextBox顧客ID.Text.Trim) & "'"
            strSQL &= " , KINENHINSENDDAY='" & GetKINENHINSENDDAY(Me.TextBox顧客ID.Text.Trim) & "'"
            'strSQL &= " , SIRIAL=''"
            strSQL &= " , KIFUKINGAKU=" & Me.NumericUpDown寄付金額.Value.ToString & ""
            'strSQL &= " , KIFURIREKI=''"
            strSQL &= " , NYUKINDAY='" & Me.TextBox入金日.Text & "'"
            strSQL &= " , KIFUKAISU=" & Me.NumericUpDown寄付回数.Value.ToString & ""
            strSQL &= " , BIKOU='" & Me.TextBox備考.Text.Trim & "'"
            strSQL &= " , N_FULLNAM='" & classNayose.Nayose_Name(Me.TextBox名前.Text) & "'"
            strSQL &= " , N_KANA='" & classNayose.Nayose_Kana(Me.TextBoxフリガナ.Text) & "'"
            strSQL &= " , N_ADMIN='" & classNayose.Nayose_Admin(Me.ComboBox都道府県.Text) & "'"
            strSQL &= " , N_CITY='" & classNayose.Nayose_City(Me.TextBox市区町村.Text) & "'"
            strSQL &= " , N_TOWN='" & classNayose.Nayose_Banti(Me.TextBox番地マンション名.Text) & "'"
            strSQL &= " , N_TEL='" & classNayose.Nayose_TEL(Me.TextBox電話番号.Text) & "'"
            strSQL &= " , N_MAIL='" & classNayose.Nayose_Mail(Me.TextBoxEmailアドレス.Text) & "'"
            strSQL &= " , UPDATE_DAY=" & classSQLite.GetTimeSQL & ""
            strSQL &= " , UPDATE_NAM='" & UserID & "'"
            strSQL &= "WHERE NID='" & Me.TextBox顧客ID.Text.Trim & "'"
            classSQLite.EXEC_tr(strSQL)

        Catch ex As Exception
            classSQLite.Rollback()
            classSQLite.DbClose()
            Cursor.Current = Cursors.Default
            MessageBox.Show("更新で【" & ex.Message & "】のエラーです")
            Exit Sub
        End Try
        classSQLite.Commit()
        classSQLite.DbClose()

        Cursor.Current = Cursors.Default

        If classRuiseki.ChkPointUpDown(Me.TextBox顧客ID.Text.Trim) = "1" Then
            classLIB.SetCombox(Me.ComboBoxランク, classRuiseki.GetRankFromPoint(Me.TextBox顧客ID.Text.Trim))
            MessageBox.Show("ランクに変更がありました")
        Else
            MessageBox.Show("更新しました")
        End If

    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        '明細のNIDが全て存在しない事を確認してから削除する
        'キーはNIDです　UpDateしか存在しません
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable

        strSQL = "SELECT NID FROM T_MEISAI WHERE NID ='" & Me.TextBox顧客ID.Text.Trim & "'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 0 Then
            Dim result As DialogResult = MessageBox.Show("削除しますか？",
                             "質問",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Exclamation,
                             MessageBoxDefaultButton.Button2)
            If result = vbYes Then
                strSQL = ""
                strSQL &= "DELETE FROM T_RUISEKI WHERE NID='" & Me.TextBox顧客ID.Text.Trim & "' "
                If classSQLite.EXEC(strSQL) Then
                    MessageBox.Show("削除しました")
                    Me.Close()
                End If
            End If

        Else
            MessageBox.Show("明細データが空ではありません")
        End If

    End Sub
    '送付履歴の追加
    Private Sub soufuAdd()
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)

        If GetRank(Me.DataGridViewSoufu.Rows.Count, 0) <> "" Then

            strSQL = ""
            strSQL &= "INSERT INTO T_SOUFU"
            strSQL &= "(NID, RANK_NAM, KINENHIN, KINENHINSENDDAY, SIRIAL, ENTRY_DAY, ENTRY_NAM, UPDATE_DAY, UPDATE_NAM)VALUES("
            strSQL &= "  '" & Me.TextBox顧客ID.Text.Trim & "'"
            strSQL &= ", '" & GetRank(Me.DataGridViewSoufu.Rows.Count, 0) & "'"
            strSQL &= ", '" & GetRank(Me.DataGridViewSoufu.Rows.Count, 1) & "'"
            strSQL &= " ,''"
            strSQL &= ", ''"

            strSQL &= " ," & classSQLite.GetTimeSQL & ""
            strSQL &= " ,'" & UserID & "'"
            strSQL &= " ," & classSQLite.GetTimeSQL & ""
            strSQL &= " ,'" & UserID & "'"
            strSQL &= ")"

            If classSQLite.EXEC(strSQL) Then
                Soufu()
            End If
        End If
    End Sub
    Private Function GetRank(row As Integer, col As Integer)
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Return ""
        End If
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        strSQL = "SELECT RANK_NAM , KINENHIN , POINT FROM M_RANK "
        strSQL &= " WHERE RANK_NAM Not Like '×%'"
        strSQL &= " ORDER BY POINT ASC "


        dt = classSQLite.SetDataTable(strSQL)
        Try
            Return dt.Rows(row).Item(col).ToString()

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub Button追加_Click(sender As Object, e As EventArgs) Handles Button追加.Click
        soufuAdd()
    End Sub
    ' M_RANKI から
    '
    '
    Private Function GetSpufuRyaku(wNID As String)
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim msg As String = String.Empty

        strSQL = "SELECT  T_SOUFU.RANK_NAM, T_SOUFU.KINENHINSENDDAY FROM T_SOUFU , M_RANK WHERE T_SOUFU.NID ='" & wNID & "' AND  T_SOUFU.RANK_NAM = M_RANK.RANK_NAM  ORDER BY M_RANK.POINT ASC "
        dt = classSQLite.SetDataTable(strSQL)
        For Each row In dt.Rows
            msg = msg & row("RANK_NAM").ToString.Substring(0, 1)
        Next

        Return msg
    End Function
    Private Function GetKINENHINSENDDAY(wNID As String)
        'Dim strSQL As String = String.Empty
        'Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As New DataTable
        'Dim msg As String = ""

        'strSQL = "SELECT  KINENHINSENDDAY FROM T_SOUFU  WHERE T_SOUFU.NID ='" & wNID & "' ORDER BY KINENHINSENDDAY DESC LIMIT 1"
        'dt = classSQLite.SetDataTable(strSQL)
        'For Each row In dt.Rows
        'msg = row("KINENHINSENDDAY").ToString
        'Next
        If Me.DataGridViewSoufu.Rows.Count = 0 Then
            Return ""
        Else
            dt = Me.DataGridViewSoufu.DataSource
            Dim dv = New DataView(dt)
            dv.Sort = "KINENHINSENDDAY DESC"
            dt = dv.ToTable
            'Return dt.Rows(0).Item(0).ToString()
            Return dt.Rows(0).Item(2).ToString()
        End If
    End Function


    Private Sub disp()
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        strSQL &= "SELECT  FULLNAM, KANA, ZIPCD, ADMIN, CITY, TOWN, TEL, MAIL, KOKUDAKA, KOKUDAKAFLG, RANK, RANKUPFLG, KINENHIN, KINENHINSENDDAY, SIRIAL, KIFUKINGAKU, KIFURIREKI, NYUKINDAY, KIFUKAISU, BIKOU"
        strSQL &= " FROM T_RUISEKI WHERE NID ='" & NID & "'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then
            For Each row In dt.Rows
                Me.TextBox名前.Text = row("FULLNAM").ToString
                Me.TextBoxフリガナ.Text = row("KANA").ToString
                Me.TextBox郵便番号.Text = row("ZIPCD").ToString
                Me.TextBox電話番号.Text = row("TEL").ToString
                TextBoxEmailアドレス.Text = row("MAIL").ToString
                classLIB.SetCombox(Me.ComboBox都道府県, row("ADMIN").ToString)
                Me.TextBox市区町村.Text = row("CITY").ToString
                Me.TextBox番地マンション名.Text = row("TOWN").ToString
                classLIB.SetCombox(Me.ComboBoxランク, row("RANK").ToString)

                If Integer.Parse(row("KIFUKINGAKU").ToString) > 0 Then
                    Me.NumericUpDown寄付金額.Value = row("KIFUKINGAKU").ToString
                Else
                    Me.NumericUpDown寄付金額.Value = "0"
                End If
                If Integer.Parse(row("KIFUKAISU").ToString) > 0 Then
                    Me.NumericUpDown寄付回数.Value = row("KIFUKAISU").ToString
                Else
                    Me.NumericUpDown寄付回数.Value = "0"
                End If
                If Integer.Parse(row("KIFUKAISU").ToString) > 0 Then
                    Me.NumericUpDown累積石高.Value = row("KOKUDAKA").ToString
                Else
                    Me.NumericUpDown累積石高.Value = "0"
                End If
                Me.TextBox入金日.Text = row("NYUKINDAY").ToString
                Me.TextBox備考.Text = row("BIKOU").ToString
            Next
        End If


    End Sub

    Private Sub Soufu()

        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim ro As Integer = 0


        Me.DataGridViewSoufu.DataSource = Nothing
        Me.DataGridViewSoufu.Rows.Clear()
        Me.DataGridViewSoufu.Columns.Clear()

        strSQL = ""
        strSQL &= "SELECT T_SOUFU.RANK_NAM, T_SOUFU.KINENHIN, T_SOUFU.KINENHINSENDDAY, T_SOUFU.SIRIAL "
        strSQL &= " FROM T_SOUFU ,M_RANK "
        strSQL &= " WHERE NID ='" & NID & "'"
        strSQL &= " AND T_SOUFU.RANK_NAM  = M_RANK.RANK_NAM  "
        strSQL &= " ORDER BY M_RANK.RANK_ID ASC"


        dt = classSQLite.SetDataTable(strSQL)


        Me.DataGridViewSoufu.RowHeadersVisible = False
        Me.DataGridViewSoufu.AutoGenerateColumns = False
        Me.DataGridViewSoufu.DataSource = dt


        ro = classLIB.SettextButton(Me.DataGridViewSoufu, ro, "", "削除", 40, True)
        'ro = classLIB.SettextColumn(Me.DataGridViewSoufu, ro, "RANK_NAM", "ランク名", 120, True)
        ro = classLIB.SettextColumn(Me.DataGridViewSoufu, ro, "RANK_NAM", "ランク名", 90, True)
        ro = classLIB.SettextColumn(Me.DataGridViewSoufu, ro, "KINENHIN", "記念品", 300, True)
        ro = classLIB.SettextColumn(Me.DataGridViewSoufu, ro, "KINENHINSENDDAY", "送付日", 120, False)
        ro = classLIB.SettextColumn(Me.DataGridViewSoufu, ro, "SIRIAL", "シリアルナンバー", 100, False)
        'ro = classLIB.SettextButton(Me.DataGridViewSoufu, ro, "", "送付", 40, True)


        Me.DataGridViewSoufu.AllowUserToAddRows = False
        Me.DataGridViewSoufu.RowHeadersVisible = False
        Me.DataGridViewSoufu.Font = New Font(“MS UI Gothic”, 14)


        'For ro = 0 To dt.Rows.Count - 1
        'If dt.Rows(ro).Item(4).ToString = "1" Then
        '    Me.DataGridViewSoufu.Rows(ro).Cells(5).Style.BackColor = Color.Blue
        'End If
        'Me.DataGridViewSoufu.CurrentCell = Me.DataGridViewSoufu(1, 0)
        'Next

    End Sub

    Private Sub DataGridViewSoufu_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridViewSoufu.CellMouseClick
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim row As Integer

        If e.RowIndex >= 0 Then
            row = e.RowIndex
            If e.ColumnIndex = 0 Then

                If e.RowIndex = Me.DataGridViewSoufu.Rows.Count - 1 Then

                    Dim result As DialogResult = MessageBox.Show("削除しますか？",
                                             "質問",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxDefaultButton.Button2)
                    If result = vbYes Then

                        strSQL = ""
                        strSQL &= "DELETE FROM T_SOUFU"
                        strSQL &= " WHERE NID='" & Me.TextBox顧客ID.Text.Trim & "' "
                        strSQL &= "  AND RANK_NAM='" & Me.DataGridViewSoufu.Rows(row).Cells(1).Value.ToString & "'"
                        If classSQLite.EXEC(strSQL) Then
                            Soufu()
                        End If


                    End If
                Else
                    MessageBox.Show("一番上位から削除してください")
                End If
            End If
        End If

    End Sub

    Private Sub DataGridViewSoufu_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSoufu.CellValueChanged
        Dim row As Integer = e.RowIndex
        Dim col As Integer = e.ColumnIndex
        If col = 3 Then '送付日
            If Me.DataGridViewSoufu.Rows(row).Cells(col).Value.ToString.Length > 0 Then
                If Not IsDate(Me.DataGridViewSoufu.Rows(row).Cells(col).Value) Then
                    MessageBox.Show("日付型が正しくありません")
                End If
            End If
        End If
        If col = 4 Then 'シリアル
            If (Me.DataGridViewSoufu.Rows(row).Cells(col).Value.ToString.Length > 5) Then
                MessageBox.Show("シリアルナンバーは、５桁以下で入力してください")
                Me.DataGridViewSoufu.Rows(row).Cells(col).Value = ""
                'Me.DataGridViewSoufu.CurrentCell = Me.DataGridViewSoufu(col, row)
            End If
        End If
    End Sub

    'Dim classRuiseki As New ClassRuiseki
    'ClassRuiseki.SoufuHinAdd(Me.TextBox顧客ID.Text)
    'disp()
    'Soufu()

End Class