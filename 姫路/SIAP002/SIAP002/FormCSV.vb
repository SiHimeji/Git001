Public Class FormCSV
    '-----------------------------------------------------
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty

    '--- 23.12.15 k.s start ---
    Dim OldGridRow As Integer
    Dim NewGridRow As Integer
    '--- 23.12.15 k.s end ---

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
    Private classLIB As New ClassLIB

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FormCSV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If

        ShowDataGridViewCsv()
        Me.ToolStripStatusLabelIn.Text = "0件"
        Me.ToolStripStatusLabelout.Text = "0件"
        '--- 23.12.15 k.s start ---
        '初期値セット
        OldGridRow = -1
        NewGridRow = 0
        '--- 23.12.15 k.s end ---

#If DEBUG Then
#Else
#End If

    End Sub

    Private Sub FormCSV_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim dt As DataTable = DirectCast(DataGridViewCSV.DataSource, DataTable)
        Dim sql As String

        sql = GetSql_UpdateTCsv()

        If sql = "" Then
            Exit Sub
        End If

        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)

        Try
            classSQLite.DbOpen()
            classSQLite.BeginTrans()

            classSQLite.EXEC_tr(sql)

            classSQLite.Commit()
        Catch ex As SQLite.SQLiteException
            classSQLite.Rollback()
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            classSQLite.Rollback()
            Throw ex
        Finally
            classSQLite.DbClose()
        End Try
    End Sub

    Private Sub Button明細表示_Click(sender As Object, e As EventArgs)
        Dim fm As New FormMeisai
        fm.UserID = UserID
        fm.UserName = UserName
        fm.Kengen = Kengen
        'fm.NID = Me.TextBox顧客ID.Text
        fm.ShowDialog()
    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        Dim classLIB As New ClassLIB
        TextBoxFILE.Text = classLIB.GetFile("", "csv")

        'Using ofd As OpenFileDialog = New OpenFileDialog()
        'If ofd.ShowDialog = DialogResult.OK Then
        'TextBoxFILE.Text = ofd.FileName
        'End If
        'End Using
    End Sub

#Region "Button読込"
    Private Sub Button読込_Click(sender As Object, e As EventArgs) Handles Button読込.Click
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim filePath As String = TextBoxFILE.Text
        Dim sql As String
        Dim dt As DataTable

        '--- 23.12.15 k.s start ---
        '初期値セット
        OldGridRow = 0
        NewGridRow = 0
        '--- 23.12.15 k.s end ---

        If filePath = "" Then
            MessageBox.Show("CSVファイルを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '---------------------------------
        'CSVのチェック ヘッダーが５個以上合わないとNG
        Try
            Dim csvmst As Integer = 0
            Dim csvflag As Integer = 0
            Dim HinaMst As String
            sql = "SELECT MOSHIKOMINO, FULLNAM, KANA, ZIPCD, ADMIN, CITY, TOWN, TEL, MAIL, KIFUKIN, NYUKINHI, SYOU01, SYOU01NAM, SYOU02, SYOU02NAM, SYOU03, SYOU03NAM, SYOU04, SYOU04NAM, SYOU05, SYOU05NAM, SYOU06, SYOU06NAM, SYOU07, SYOU07NAM, SYOU08, SYOU08NAM, SYOU09, SYOU09NAM, SYOU10, SYOU10NAM, SYOU11, SYOU11NAM, SYOU12, SYOU12NAM, SYOU13, SYOU13NAM, SYOU14, SYOU14NAM, SYOU15, SYOU15NAM, SYOU16, SYOU16NAM, SYOU17, SYOU17NAM, SYOU18, SYOU18NAM, SYOU19, SYOU19NAM, SYOU20, SYOU20NAM  FROM M_HINAGATA WHERE SWON ='1'"
            dt = classSQLite.SetDataTable(sql)

            Dim sr As System.IO.StreamReader = Nothing
            If System.IO.File.Exists(filePath) Then
                sr = New System.IO.StreamReader(filePath, System.Text.Encoding.GetEncoding("Shift_JIS"))
                Dim line As String() = sr.ReadLine.Split(","c)
                For x As Integer = 0 To dt.Columns.Count - 1
                    HinaMst = dt.Rows(0).Item(x).ToString
                    If HinaMst <> "" Then
                        csvmst = csvmst + 1
                        For Each item As String In line
                            If item.Replace("""", "").Replace("=", "") = HinaMst Then
                                csvflag = csvflag + 1
                            End If
                        Next

                    End If
                Next

                sr.Close()
            End If

            If csvflag <> csvmst Then
                MessageBox.Show("取り込みを指定しているＣＳＶファイルが、設定されているひな形定義と違います")
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show("CSVのチェックでエラーです" & vbCr & ex.Message)
            Exit Sub
        End Try

        '---------------------------------
        Try
            classSQLite.DbOpen()
            classSQLite.BeginTrans()

            classSQLite.EXEC_tr(GetSql_DeleteTCsv())

            sql = GetSql_ImportCsv(filePath)
            If sql <> "" Then
                classSQLite.EXEC_tr(sql)
            End If

            classSQLite.EXEC_tr(GetSql_ToSetNLevelAndNId())

            classSQLite.Commit()
        Catch ex As SQLite.SQLiteException
            classSQLite.Rollback()
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            classSQLite.Rollback()
            Throw ex
        Finally
            classSQLite.DbClose()
        End Try

        ShowDataGridViewCsv()

        '--- 23.12.15 k.s start ---
        '累積一覧表をクリアー
        If Me.DataGridView累積.DataSource IsNot Nothing Then
            DirectCast(Me.DataGridView累積.DataSource, DataTable).Clear()
        End If
        '--- 23.12.15 k.s end ---

        MessageBox.Show(Me.ToolStripStatusLabelIn.Text & "読み込み 　-> 　" & Me.ToolStripStatusLabelout.Text & "有効でした")

    End Sub

    Private Function GetSql_DeleteTCsv() As String
        Dim buf As New Text.StringBuilder

        buf.AppendLine("DELETE FROM T_CSV;")
        buf.AppendLine("DELETE FROM sqlite_sequence WHERE name = 'T_CSV';")

        Return buf.ToString
    End Function

    Private Function GetSql_ImportCsv(ByVal filePath As String) As String
        Dim sql As New Text.StringBuilder
        Dim cnt_out As Integer = 0
        Dim cnt_in As Integer = 0

        Dim d1 As String = DateTime.Today.ToString("yyyy/MM/dd")        '取込日
        Dim d2 As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") '登録日
        Me.ToolStripStatusLabelout.Text = "0件"
        Me.ToolStripStatusLabelIn.Text = "0件"
        cnt_out = 0
        cnt_in = 0

        Using cr As New CsvReader(filePath)
            Do Until cr.EndOfData
                cr.ReadFields()
                cnt_in = cnt_in + 1
                Me.ToolStripStatusLabelIn.Text = cnt_in.ToString & "件"

                If cr.IsAllowedToInsert Then

                    cnt_out = cnt_out + 1

                    Me.ToolStripStatusLabelout.Text = cnt_out.ToString & "件"

                    sql.AppendLine("INSERT INTO T_CSV")
                    '取込日
                    sql.AppendLine("(TORIKOMI_HI,")
                    'CSV取込データ
                    sql.AppendLine(" MOSHIKOMINO,FULLNAM,KANA,ZIPCD,ADMIN,CITY,TOWN,TEL,MAIL,KIFUKIN,NYUKINHI,")
                    sql.AppendLine(" SYOU01,SYOU01NAM,SYOU02,SYOU02NAM,SYOU03,SYOU03NAM,SYOU04,SYOU04NAM,SYOU05,SYOU05NAM,SYOU06,SYOU06NAM,SYOU07,SYOU07NAM,SYOU08,SYOU08NAM,SYOU09,SYOU09NAM,SYOU10,SYOU10NAM,")
                    sql.AppendLine(" SYOU11,SYOU11NAM,SYOU12,SYOU12NAM,SYOU13,SYOU13NAM,SYOU14,SYOU14NAM,SYOU15,SYOU15NAM,SYOU16,SYOU16NAM,SYOU17,SYOU17NAM,SYOU18,SYOU18NAM,SYOU19,SYOU19NAM,SYOU20,SYOU20NAM,")
                    '名寄せ処理後データ
                    sql.AppendLine(" N_FULLNAM,N_KANA,N_ADMIN,N_CITY,N_TOWN,N_TEL,N_MAIL,")
                    '名寄せレベル,名寄ID,登録日,登録者,更新日,更新者
                    sql.AppendLine(" N_SQL,NLEVEL,NID,ENTRY_DAY,ENTRY_NAM,UPDATE_DAY,UPDATE_NAM)")
                    sql.AppendLine("VALUES")
                    '取込日
                    sql.AppendLine($"('{d1}',")
                    'CSV取込データ
                    sql.AppendLine(cr.GetInsertValues)
                    '名寄せ処理後データ
                    sql.AppendLine(cr.GetInsertNayose)
                    '名寄せレベル,名寄ID,登録日,登録者,更新日,更新者
                    sql.AppendLine($" '','','','{d2}','{Me.UserName}','{d2}','{Me.UserName}');")
                End If
            Loop

        End Using

        Return sql.ToString
    End Function

    Private Function GetSql_ToSetNLevelAndNId() As String
        Dim nOrder As MyOrderdDictionaly(Of String, List(Of String)) = HimejiDb.GetNOrder
        Dim sql As New Text.StringBuilder
        Dim sqlWhere1 As New Text.StringBuilder
        Dim sqlWhere2 As New Text.StringBuilder

        For i As Integer = 0 To nOrder.Count - 1
            Dim nLv As String = nOrder.Keys(i)

            '検索条件の作成
            sqlWhere1.Clear()
            For Each v As String In nOrder(nLv)
                sqlWhere1.AppendLine($"      AND tr.{v} = T_CSV.{v}") '名寄せLEVEL変更用
            Next

            '名寄せLEVEL設定用のSQLを作成
            sql.AppendLine("UPDATE T_CSV")
            sql.AppendLine("SET NLEVEL = CASE")
            sql.AppendLine($"                 WHEN NLEVEL = '' THEN '{nLv}'")
            sql.AppendLine($"                 ELSE NLEVEL || '・{nLv}'")
            sql.AppendLine("             END")
            sql.AppendLine("WHERE EXISTS(")
            sql.AppendLine("    SELECT *")
            sql.AppendLine("    FROM T_RUISEKI tr")
            sql.AppendLine("    WHERE 1=1")
            sql.Append(sqlWhere1.ToString)
            sql.AppendLine(");")
        Next

        '検索条件の作成(全ての条件)
        sqlWhere1.Clear()
        sqlWhere2.Clear()
        For i As Integer = 0 To nOrder.Count - 1
            For Each v As String In nOrder(nOrder.Keys(i))
                sqlWhere1.AppendLine($"      AND tr.{v} = T_CSV.{v}") '名寄せLEVEL変更用
                sqlWhere2.AppendLine($"      AND tc.{v} = T_CSV.{v}") 'T_CSV内での名寄せ処理用
            Next
        Next

        '名寄せLEVEL設定用のSQLを作成
        sql.AppendLine("UPDATE T_CSV")
        sql.AppendLine("SET NLEVEL = '一致'")
        sql.AppendLine("WHERE EXISTS(")
        sql.AppendLine("    SELECT *")
        sql.AppendLine("    FROM T_RUISEKI tr")
        sql.AppendLine("    WHERE 1=1")
        sql.Append(sqlWhere1.ToString)
        sql.AppendLine(");")

        '名寄せID設定用のSQLを作成
        sql.AppendLine("UPDATE T_CSV")
        sql.AppendLine("SET NID = (")
        sql.AppendLine("    SELECT tr.NID")
        sql.AppendLine("    FROM T_RUISEKI tr")
        sql.AppendLine("    WHERE 1=1")
        sql.Append(sqlWhere1.ToString)
        sql.AppendLine(")")
        sql.AppendLine("WHERE 1 = (")
        sql.AppendLine("    SELECT COUNT(*)")
        sql.AppendLine("    FROM T_RUISEKI tr")
        sql.AppendLine("    WHERE 1=1")
        sql.Append(sqlWhere1.ToString)
        sql.AppendLine(");")

        'T_CSV内での名寄せ処理用SQLを作成
        sql.AppendLine("UPDATE T_CSV")
        sql.AppendLine("SET N_SQL = (")
        sql.AppendLine("    SELECT MIN(tc.SEQ)")
        sql.AppendLine("    FROM T_CSV tc")
        sql.AppendLine("    WHERE 1=1")
        sql.Append(sqlWhere2.ToString)
        sql.AppendLine(")")
        sql.AppendLine("WHERE NID = ''")
        sql.AppendLine("  And 1 < (")
        sql.AppendLine("    SELECT COUNT(*)")
        sql.AppendLine("    FROM T_CSV tc")
        sql.AppendLine("    WHERE 1=1")
        sql.Append(sqlWhere2.ToString)
        sql.AppendLine(");")

        Return sql.ToString
    End Function

    Private Sub ShowDataGridViewCsv()
        Dim dgv As DataGridView = Me.DataGridViewCSV

#Region "DataGridViewCsvのヘッダ作成"
        If dgv.Columns.Count = 0 Then
            Dim ro As Integer = 0

            ro = classLIB.SettextColumn(dgv, ro, "NLEVEL", "名寄せレベル", 120, True)
            ro = classLIB.SettextColumn(dgv, ro, "NID", "ID", 60, False)
            ro = classLIB.SettextColumn(dgv, ro, "FULLNAM", "名前", 120, True)
            ro = classLIB.SettextColumn(dgv, ro, "KANA", "フリガナ", 150, True)
            ro = classLIB.SettextColumn(dgv, ro, "ZIPCD", "郵便番号", 90, True)
            ro = classLIB.SettextColumn(dgv, ro, "ADMIN", "都道府県", 90, True)
            ro = classLIB.SettextColumn(dgv, ro, "CITY", "市区町村", 90, True)
            ro = classLIB.SettextColumn(dgv, ro, "TOWN", "番地・ﾏﾝｼｮﾝ名", 160, True)
            ro = classLIB.SettextColumn(dgv, ro, "TEL", "電話番号", 130, True)
            ro = classLIB.SettextColumn(dgv, ro, "MAIL", "E-mailアドレス", 240, True)
            ro = classLIB.SettextColumn(dgv, ro, "KIFUKIN", "寄附金額", 120, True)
            ro = classLIB.SettextColumn(dgv, ro, "NYUKINHI", "入金日", 110, True)
            ro = classLIB.SettextColumn(dgv, ro, "MOSHIKOMINO", "申込番号", 160, True)

            ro = classLIB.SettextColumn(dgv, ro, "SYOU01", "商品1_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU01NAM", "商品1_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU02", "商品2_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU02NAM", "商品2_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU03", "商品3_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU03NAM", "商品3_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU04", "商品4_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU04NAM", "商品4_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU05", "商品5_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU05NAM", "商品5_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU06", "商品6_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU06NAM", "商品6_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU07", "商品7_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU07NAM", "商品7_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU08", "商品8_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU08NAM", "商品8_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU09", "商品9_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU09NAM", "商品9_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU10", "商品10_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU10NAM", "商品10_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU11", "商品11_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU11NAM", "商品11_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU12", "商品12_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU12NAM", "商品12_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU13", "商品13_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU13NAM", "商品13_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU14", "商品14_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU14NAM", "商品14_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU15", "商品15_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU15NAM", "商品15_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU16", "商品16_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU16NAM", "商品16_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU17", "商品17_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU17NAM", "商品17_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU18", "商品18_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU18NAM", "商品18_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU19", "商品19_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU19NAM", "商品19_商品名", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU20", "商品20_番号", 80, True)
            ro = classLIB.SettextColumn(dgv, ro, "SYOU20NAM", "商品20_商品名", 80, True)

            '非表示の列を追加する
            Dim hideColStart As Integer = ro
            Dim hideColEnd As Integer

            ro = classLIB.SettextColumn(dgv, ro, "SEQ", "SEQ", 0, True)
            ro = classLIB.SettextColumn(dgv, ro, "N_FULLNAM", "N_FULLNAM", 0, True)
            ro = classLIB.SettextColumn(dgv, ro, "N_KANA", "N_KANA", 0, True)
            ro = classLIB.SettextColumn(dgv, ro, "N_ADMIN", "N_ADMIN", 0, True)
            ro = classLIB.SettextColumn(dgv, ro, "N_CITY", "N_CITY", 0, True)
            ro = classLIB.SettextColumn(dgv, ro, "N_TOWN", "N_TOWN", 0, True)
            ro = classLIB.SettextColumn(dgv, ro, "N_TEL", "N_TEL", 0, True)
            ro = classLIB.SettextColumn(dgv, ro, "N_MAIL", "N_MAIL", 0, True)
            ro = classLIB.SettextColumn(dgv, ro, "N_SQL", "N_SQL", 0, True)

            hideColEnd = ro - 1
            For i As Integer = hideColStart To hideColEnd
                dgv.Columns(i).Visible = False
            Next
        End If
#End Region

        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim sql As New Text.StringBuilder

#Region "DataGridViewCsvのデータ取得"
        sql.AppendLine("SELECT NLEVEL")
        sql.AppendLine("      ,NID")
        sql.AppendLine("      ,FULLNAM")
        sql.AppendLine("      ,KANA")
        sql.AppendLine("      ,ZIPCD")
        sql.AppendLine("      ,ADMIN")
        sql.AppendLine("      ,CITY")
        sql.AppendLine("      ,TOWN")
        sql.AppendLine("      ,TEL")
        sql.AppendLine("      ,MAIL")
        sql.AppendLine("      ,KIFUKIN")
        sql.AppendLine("      ,NYUKINHI")
        sql.AppendLine("      ,MOSHIKOMINO")
        sql.AppendLine("      ,SYOU01")
        sql.AppendLine("      ,SYOU01NAM")
        sql.AppendLine("      ,SYOU02")
        sql.AppendLine("      ,SYOU02NAM")
        sql.AppendLine("      ,SYOU03")
        sql.AppendLine("      ,SYOU03NAM")
        sql.AppendLine("      ,SYOU04")
        sql.AppendLine("      ,SYOU04NAM")
        sql.AppendLine("      ,SYOU05")
        sql.AppendLine("      ,SYOU05NAM")
        sql.AppendLine("      ,SYOU06")
        sql.AppendLine("      ,SYOU06NAM")
        sql.AppendLine("      ,SYOU07")
        sql.AppendLine("      ,SYOU07NAM")
        sql.AppendLine("      ,SYOU08")
        sql.AppendLine("      ,SYOU08NAM")
        sql.AppendLine("      ,SYOU09")
        sql.AppendLine("      ,SYOU09NAM")
        sql.AppendLine("      ,SYOU10")
        sql.AppendLine("      ,SYOU10NAM")
        sql.AppendLine("      ,SYOU11")
        sql.AppendLine("      ,SYOU11NAM")
        sql.AppendLine("      ,SYOU12")
        sql.AppendLine("      ,SYOU12NAM")
        sql.AppendLine("      ,SYOU13")
        sql.AppendLine("      ,SYOU13NAM")
        sql.AppendLine("      ,SYOU14")
        sql.AppendLine("      ,SYOU14NAM")
        sql.AppendLine("      ,SYOU15")
        sql.AppendLine("      ,SYOU15NAM")
        sql.AppendLine("      ,SYOU16")
        sql.AppendLine("      ,SYOU16NAM")
        sql.AppendLine("      ,SYOU17")
        sql.AppendLine("      ,SYOU17NAM")
        sql.AppendLine("      ,SYOU18")
        sql.AppendLine("      ,SYOU18NAM")
        sql.AppendLine("      ,SYOU19")
        sql.AppendLine("      ,SYOU19NAM")
        sql.AppendLine("      ,SYOU20")
        sql.AppendLine("      ,SYOU20NAM")
        sql.AppendLine("      ,SEQ")
        sql.AppendLine("      ,N_FULLNAM")
        sql.AppendLine("      ,N_KANA")
        sql.AppendLine("      ,N_ADMIN")
        sql.AppendLine("      ,N_CITY")
        sql.AppendLine("      ,N_TOWN")
        sql.AppendLine("      ,N_TEL")
        sql.AppendLine("      ,N_MAIL")
        sql.AppendLine("      ,N_SQL")
        sql.AppendLine("FROM T_CSV")
        sql.AppendLine("ORDER BY N_ADMIN,N_CITY,N_TOWN,N_FULLNAM,N_KANA")
#End Region

        dt = classSQLite.SetDataTable(sql.ToString)
        dgv.DataSource = dt

        Me.Label件数.Text = dt.Rows.Count.ToString & "件"

    End Sub
#End Region

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable = DirectCast(DataGridViewCSV.DataSource, DataTable)
        Dim sql As New Text.StringBuilder

        If Me.DataGridViewCSV.Rows.Count = 0 Then
            MessageBox.Show("登録するデータがありません")
            Exit Sub
        End If

        Try
            Dim newNId As String = HimejiDb.GetNewNId
            Dim d As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

            classSQLite.DbOpen()
            classSQLite.BeginTrans()

            '新規データをT_RUISEKIに追加する
            For dtRow As Integer = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows(dtRow)("NID")) OrElse dt.Rows(dtRow)("NID") = "" Then
                    Dim dr As DataRow = dt.Rows(dtRow)
                    Dim nSql As String = If(IsDBNull(dr("N_SQL")), "", dr("N_SQL"))

                    If nSql = "" Then
                        dr("NID") = newNId
                    Else
                        dt.AsEnumerable.Where(Function(n) n("N_SQL") = nSql) _
                                       .Select(Function(n)
                                                   n("NID") = newNId
                                                   Return n
                                               End Function).ToList
                    End If

                    sql = New Text.StringBuilder

                    sql.AppendLine("INSERT INTO T_RUISEKI")
                    sql.AppendLine("(NID,FULLNAM,KANA,ZIPCD,ADMIN,CITY,TOWN,TEL,MAIL,")
                    sql.AppendLine(" KOKUDAKA,KOKUDAKAFLG,""RANK"",RANKUPFLG,KIFUKINGAKU,NYUKINDAY,KIFUKAISU,BIKOU,")
                    sql.AppendLine(" N_FULLNAM,N_KANA,N_ADMIN,N_CITY,N_TOWN,N_TEL,N_MAIL,")
                    sql.AppendLine(" ENTRY_DAY,ENTRY_NAM,UPDATE_DAY,UPDATE_NAM)")
                    sql.AppendLine("VALUES")
                    sql.AppendLine($"('{dr("NID")}','{dr("FULLNAM")}','{dr("KANA")}','{dr("ZIPCD")}','{dr("ADMIN")}','{dr("CITY")}','{dr("TOWN")}','{dr("TEL")}','{dr("MAIL")}',")
                    sql.AppendLine($" 0,'0','','0',0,'{dr("NYUKINHI")}',0,'',")
                    sql.AppendLine($" '{dr("N_FULLNAM")}','{dr("N_KANA")}','{dr("N_ADMIN")}','{dr("N_CITY")}','{dr("N_TOWN")}','{dr("N_TEL")}','{dr("N_MAIL")}',")
                    sql.AppendLine($" '{d}','{Me.UserName}','{d}','{Me.UserName}');")

                    classSQLite.EXEC_tr(sql.ToString)



                    newNId = Integer.Parse(newNId) + 1
                End If
            Next

            'DataGridViewを元にT_RUISEKIを更新する
            Dim mPointList As Dictionary(Of String, HimejiDb.MPoint) = HimejiDb.GetMPointList

            For dtRow As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(dtRow)

                sql = New Text.StringBuilder

                For i As Integer = 1 To 20
                    Dim key As String = dr("SYOU" & i.ToString("00") & "NAM")

                    If mPointList.ContainsKey(key) Then

                        sql.AppendLine("UPDATE T_RUISEKI")
                        sql.AppendLine($"SET KOKUDAKA    = KOKUDAKA + {mPointList(key).Point}")
                        sql.AppendLine($"   ,KIFUKINGAKU = KIFUKINGAKU + {mPointList(key).KifuKingaku}")
                        sql.AppendLine($"WHERE NID = '{dr("NID")}';")
                    End If
                Next

                sql.AppendLine("UPDATE T_RUISEKI")
                sql.AppendLine("SET KIFUKAISU = T_RUISEKI.KIFUKAISU + 1")

                sql.AppendLine("   ,""RANK"" = IFNULL((")
                sql.AppendLine("    SELECT mr.RANK_NAM")
                sql.AppendLine("    FROM M_RANK mr")
                sql.AppendLine("    WHERE mr.POINT <= T_RUISEKI.KOKUDAKA")
                sql.AppendLine("    ORDER BY mr.POINT DESC")
                sql.AppendLine("    LIMIT 1")
                sql.AppendLine("),'')")

                sql.AppendLine("   ,RANKUPFLG =")
                sql.AppendLine("    CASE")
                sql.AppendLine("        WHEN T_RUISEKI.""RANK"" <> IFNULL((")
                sql.AppendLine("            SELECT mr.RANK_NAM")
                sql.AppendLine("            FROM M_RANK mr")
                sql.AppendLine("            WHERE mr.POINT <= T_RUISEKI.KOKUDAKA")
                sql.AppendLine("            ORDER BY mr.POINT DESC")
                sql.AppendLine("            LIMIT 1")
                sql.AppendLine("        ),'') THEN '1'")
                sql.AppendLine("        ELSE '0'")
                sql.AppendLine("    END")
                sql.AppendLine("   ,KOKUDAKAFLG = '1'")
                sql.AppendLine("   ,NYUKINDAY =")
                sql.AppendLine("    CASE")
                sql.AppendLine($"        WHEN T_RUISEKI.NYUKINDAY < '{dr("NYUKINHI")}' THEN '{dr("NYUKINHI")}'")
                sql.AppendLine("        ELSE T_RUISEKI.NYUKINDAY")
                sql.AppendLine("    END")
                sql.AppendLine($"   ,UPDATE_DAY = '{d}'")
                sql.AppendLine($"   ,UPDATE_NAM = '{Me.UserName}'")
                sql.AppendLine($"WHERE NID = '{dr("NID")}';")

                classSQLite.EXEC_tr(sql.ToString)

            Next

            'T_CSVを更新する
            sql = New Text.StringBuilder(GetSql_UpdateTCsv)

            If sql.ToString <> "" Then
                classSQLite.EXEC_tr(sql.ToString)
            End If

            'T_CSVのデータをT_MEISAIに追加する
            sql = New Text.StringBuilder

            sql.AppendLine("INSERT INTO T_MEISAI")
            sql.AppendLine("(SEQ,TORIKOMI_HI,FULLNAM,KANA,ZIPCD,ADMIN,CITY,TOWN,TEL,MAIL,KIFUKIN,NYUKINHI,")
            sql.AppendLine(" SYOU01,SYOU01NAM,SYOU02,SYOU02NAM,SYOU03,SYOU03NAM,SYOU04,SYOU04NAM,SYOU05,SYOU05NAM,SYOU06,SYOU06NAM,SYOU07,SYOU07NAM,SYOU08,SYOU08NAM,SYOU09,SYOU09NAM,SYOU10,SYOU10NAM,")
            sql.AppendLine(" SYOU11,SYOU11NAM,SYOU12,SYOU12NAM,SYOU13,SYOU13NAM,SYOU14,SYOU14NAM,SYOU15,SYOU15NAM,SYOU16,SYOU16NAM,SYOU17,SYOU17NAM,SYOU18,SYOU18NAM,SYOU19,SYOU19NAM,SYOU20,SYOU20NAM,")
            sql.AppendLine(" N_FULLNAM,N_KANA,N_ADMIN,N_CITY,N_TOWN,N_TEL,N_MAIL,")
            sql.AppendLine(" NID,NID_NOW,MOSHIKOMINO,")
            sql.AppendLine(" ENTRY_DAY,ENTRY_NAM,UPDATE_DAY,UPDATE_NAM)")
            sql.AppendLine("SELECT (SELECT ifnull(MAX(tm.SEQ),1) FROM T_MEISAI tm) + tc.SEQ")
            sql.AppendLine("      ,tc.TORIKOMI_HI,tc.FULLNAM,tc.KANA,tc.ZIPCD,tc.ADMIN,tc.CITY,tc.TOWN,tc.TEL,tc.MAIL,tc.KIFUKIN,tc.NYUKINHI")
            sql.AppendLine("      ,tc.SYOU01,tc.SYOU01NAM,tc.SYOU02,tc.SYOU02NAM,tc.SYOU03,tc.SYOU03NAM,tc.SYOU04,tc.SYOU04NAM,tc.SYOU05,tc.SYOU05NAM,tc.SYOU06,tc.SYOU06NAM,tc.SYOU07,tc.SYOU07NAM,tc.SYOU08,tc.SYOU08NAM,tc.SYOU09,tc.SYOU09NAM,tc.SYOU10,tc.SYOU10NAM")
            sql.AppendLine("      ,tc.SYOU11,tc.SYOU11NAM,tc.SYOU12,tc.SYOU12NAM,tc.SYOU13,tc.SYOU13NAM,tc.SYOU14,tc.SYOU14NAM,tc.SYOU15,tc.SYOU15NAM,tc.SYOU16,tc.SYOU16NAM,tc.SYOU17,tc.SYOU17NAM,tc.SYOU18,tc.SYOU18NAM,tc.SYOU19,tc.SYOU19NAM,tc.SYOU20,tc.SYOU20NAM")
            sql.AppendLine("      ,tc.N_FULLNAM,tc.N_KANA,tc.N_ADMIN,tc.N_CITY,tc.N_TOWN,tc.N_TEL,tc.N_MAIL,tc.NID,tc.NID,tc.MOSHIKOMINO")
            sql.AppendLine($"      ,'{d}','{Me.UserName}','{d}','{Me.UserName}'")
            sql.AppendLine("FROM T_CSV tc")

            classSQLite.EXEC_tr(sql.ToString)

            'T_CSVの削除
            sql = New Text.StringBuilder(GetSql_DeleteTCsv)
            classSQLite.EXEC_tr(sql.ToString)

            classSQLite.Commit()


            Dim classRuiseki As New ClassRuiseki
            Call classRuiseki.RuncUptoSoufu()


        Catch ex As SQLite.SQLiteException
            classSQLite.Rollback()
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            classSQLite.Rollback()
            Throw ex
        Finally
            classSQLite.DbClose()
        End Try
        'Add FC ----
        RetLevel()

        ShowDataGridViewCsv()
        If Me.DataGridView累積.DataSource IsNot Nothing Then
            DirectCast(Me.DataGridView累積.DataSource, DataTable).Clear()
        End If
    End Sub

    Private Function GetSql_UpdateTCsv() As String
        Dim dt As DataTable = DirectCast(DataGridViewCSV.DataSource, DataTable)
        Dim sql As New Text.StringBuilder

        For Each dr As DataRow In dt.Rows
            If dr.RowState = DataRowState.Modified Then
                sql.AppendLine("UPDATE T_CSV")
                sql.AppendLine($"SET NID = '{dr("NID")}'")
                sql.AppendLine($"WHERE SEQ = {dr("SEQ")};")
            End If
        Next

        Return sql.ToString
    End Function
    Private TextBoxVal As String
    Public Sub SetTextBox(ByVal astrText As String)
        '自分のプロパティを利用する
        TextBoxVal = astrText
    End Sub

    '--- 23.12.15 k.s start ---
    'カーソル移動で累積一覧表に表示
    Private Sub DataGridViewCSV_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewCSV.SelectionChanged

        Dim dgvSrc As DataGridView = Me.DataGridViewCSV
        Dim dgvDst As DataGridView = Me.DataGridView累積
        Dim dgvRow As Integer = NewGridRow

        Dim classRuiseki As New ClassRuiseki

        'ヘッダーをクリックした時、累積グリッドをクリアー
        If dgvSrc.CurrentCell Is Nothing Then
            OldGridRow = 0
            NewGridRow = -1
            DirectCast(Me.DataGridView累積.DataSource, DataTable).Clear()
            Exit Sub
        End If
        'new行に現在の行位置をセット
        NewGridRow = dgvSrc.CurrentCell.RowIndex

        '行が変わった時
        If OldGridRow <> NewGridRow Then
            'new行セット
            OldGridRow = NewGridRow
            dgvRow = NewGridRow

#Region "DataGridView累積のヘッダ作成"
            If dgvDst.Columns.Count = 0 Then
                Dim ro As Integer = 0

                ro = classLIB.SettextColumn(dgvDst, ro, "NID", "ID", 60, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "FULLNAM", "名前", 120, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "KANA", "フリガナ", 150, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "ZIPCD", "郵便番号", 90, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "ADMIN", "都道府県", 90, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "CITY", "市区町村", 90, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "TOWN", "番地・ﾏﾝｼｮﾝ名", 160, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "TEL", "電話番号", 130, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "MAIL", "E-mailアドレス", 240, True)

                ro = classLIB.SettextColumn(dgvDst, ro, "NYUKINDAY", "最終入金日", 110, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "KIFUKINGAKU", "寄付金額", 120, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "KOKUDAKA", "累積石高", 120, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "RANK", "ランク", 120, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "KINENHINSENDDAY", "記念品送付日時", 110, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "SIRIAL", "シリアルナンバー", 80, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "KIFUKAISU", "寄付回数", 75, True)
                ro = classLIB.SettextColumn(dgvDst, ro, "BIKOU", "備考", 150, True)

            End If
#End Region

            Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
            Dim dt As DataTable
            Dim sql As New Text.StringBuilder

            sql.AppendLine("SELECT NID")
            sql.AppendLine("      ,FULLNAM")
            sql.AppendLine("      ,KANA")
            sql.AppendLine("      ,ZIPCD")
            sql.AppendLine("      ,ADMIN")
            sql.AppendLine("      ,CITY")
            sql.AppendLine("      ,TOWN")
            sql.AppendLine("      ,TEL")
            sql.AppendLine("      ,MAIL")
            sql.AppendLine("      ,NYUKINDAY")
            sql.AppendLine("      ,KIFUKINGAKU")
            sql.AppendLine("      ,KOKUDAKA")
            sql.AppendLine("      ,""RANK""")
            sql.AppendLine("      ,KINENHINSENDDAY")
            sql.AppendLine("      ,SIRIAL")
            sql.AppendLine("      ,KIFUKAISU")
            sql.AppendLine("      ,BIKOU")
            sql.AppendLine("FROM T_RUISEKI")
            sql.AppendLine("WHERE")
            sql.AppendLine(GetSql_NWhere(DirectCast(dgvSrc.Rows(dgvRow).DataBoundItem, DataRowView).Row))

            dt = classSQLite.SetDataTable(sql.ToString)

            dgvDst.DataSource = dt

            '累積データがない時に累積グリッドをクリアー
            If dt.Rows.Count = 0 Then
                '累積一覧表をクリアー
                If Me.DataGridView累積.DataSource IsNot Nothing Then
                    DirectCast(Me.DataGridView累積.DataSource, DataTable).Clear()
                End If
                Exit Sub
            End If
        End If
    End Sub
    '--- 23.12.15 k.s end ---

    Private Sub DataGridViewCSV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCSV.CellClick
        Dim dgvSrc As DataGridView = Me.DataGridViewCSV
        Dim dgvDst As DataGridView = Me.DataGridView累積
        Dim dgvRow As Integer = e.RowIndex
        Dim dgvCol As Integer = e.ColumnIndex

        Dim classRuiseki As New ClassRuiseki

        If dgvRow = -1 Then
            Exit Sub
        End If

        '--- 23.12.15 k.s start ---
        'new行とold行に現在の行をセット
        OldGridRow = dgvRow
        NewGridRow = dgvRow
        '--- 23.12.15 k.s end ---

        If dgvCol = 1 Then
            Dim Fm As New FormKey()
            Fm.SetFormCSV(Me)
            Fm.wNID = dgvSrc.Rows(dgvRow).Cells(1).Value.ToString
            Fm.ShowDialog()

            If classRuiseki.ChkNID(TextBoxVal) Then
                dgvSrc.Rows(dgvRow).Cells(1).Value = TextBoxVal
                dgvSrc.CurrentCell = dgvSrc(1, dgvRow)
            Else
                '--- 23.12.15 k.s start ---
                'MessageBox.Show("顧客IDが存在しません")
                'dgvSrc.Rows(dgvRow).Cells(1).Value = ""
                'dgvSrc.CurrentCell = dgvSrc(1, dgvRow)
                If TextBoxVal <> "" Then
                    MessageBox.Show("顧客IDが存在しません")
                    dgvSrc.Rows(dgvRow).Cells(1).Value = ""
                    dgvSrc.CurrentCell = dgvSrc(1, dgvRow)
                End If
                '--- 23.12.15 k.s end ---
            End If

            Exit Sub
        End If

#Region "DataGridView累積のヘッダ作成"
        If dgvDst.Columns.Count = 0 Then
            Dim ro As Integer = 0

            'ro = classLIB.SettextButton(dgvDst, ro, "", "明細表示", 80, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "NID", "ID", 60, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "FULLNAM", "名前", 120, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "KANA", "フリガナ", 150, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "ZIPCD", "郵便番号", 90, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "ADMIN", "都道府県", 90, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "CITY", "市区町村", 90, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "TOWN", "番地・ﾏﾝｼｮﾝ名", 160, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "TEL", "電話番号", 130, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "MAIL", "E-mailアドレス", 240, True)

            ro = classLIB.SettextColumn(dgvDst, ro, "NYUKINDAY", "最終入金日", 110, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "KIFUKINGAKU", "寄付金額", 120, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "KOKUDAKA", "累積石高", 120, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "RANK", "ランク", 120, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "KINENHINSENDDAY", "記念品送付日時", 110, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "SIRIAL", "シリアルナンバー", 80, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "KIFUKAISU", "寄付回数", 75, True)
            ro = classLIB.SettextColumn(dgvDst, ro, "BIKOU", "備考", 150, True)

        End If
#End Region

        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim sql As New Text.StringBuilder

        sql.AppendLine("SELECT NID")
        sql.AppendLine("      ,FULLNAM")
        sql.AppendLine("      ,KANA")
        sql.AppendLine("      ,ZIPCD")
        sql.AppendLine("      ,ADMIN")
        sql.AppendLine("      ,CITY")
        sql.AppendLine("      ,TOWN")
        sql.AppendLine("      ,TEL")
        sql.AppendLine("      ,MAIL")
        sql.AppendLine("      ,NYUKINDAY")
        sql.AppendLine("      ,KIFUKINGAKU")
        sql.AppendLine("      ,KOKUDAKA")
        sql.AppendLine("      ,""RANK""")
        sql.AppendLine("      ,KINENHINSENDDAY")
        sql.AppendLine("      ,SIRIAL")
        sql.AppendLine("      ,KIFUKAISU")
        sql.AppendLine("      ,BIKOU")
        sql.AppendLine("FROM T_RUISEKI")
        sql.AppendLine("WHERE")
        sql.AppendLine(GetSql_NWhere(DirectCast(dgvSrc.Rows(dgvRow).DataBoundItem, DataRowView).Row))

        dt = classSQLite.SetDataTable(sql.ToString)

        dgvDst.DataSource = dt

    End Sub

    Private Function GetSql_NWhere(ByVal dr As DataRow) As String
        Dim buf As New Text.StringBuilder
        Dim nOrder As MyOrderdDictionaly(Of String, List(Of String)) = HimejiDb.GetNOrder

        If dr("NLEVEL") = "一致" Then
            buf.AppendLine(" 1=1")
            For i As Integer = 0 To nOrder.Count - 1
                Dim k As String = nOrder.Keys(i)

                For Each v As String In nOrder(k)
                    buf.AppendLine($"  AND {v} = '{dr(v)}'")
                Next
            Next
        Else
            buf.AppendLine(" 1=0")
            For i As Integer = 0 To nOrder.Count - 1
                Dim k As String = nOrder.Keys(i)

                If dr("NLEVEL") Like $"*{k}*" Then
                    buf.Append("   OR (1=1")
                    For Each v As String In nOrder(k)
                        buf.Append($" AND {v} = '{dr(v)}'")
                    Next
                    buf.AppendLine(")")
                End If
            Next
        End If

        Return buf.ToString
    End Function


    Private Sub DataGridView累積_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView累積.CellClick
        Dim dgvSrc As DataGridView = Me.DataGridView累積
        Dim dgvDst As DataGridView = Me.DataGridViewCSV
        Dim dgvCol As Integer = e.ColumnIndex
        Dim dgvRow As Integer = e.RowIndex

        If dgvRow = -1 Then
            Exit Sub
        End If

        If dgvCol = 0 Then
            Dim dtDst As DataTable = DirectCast(dgvDst.DataSource, DataTable)
            Dim drSrc As DataRow = DirectCast(dgvSrc.Rows(dgvRow).DataBoundItem, DataRowView).Row
            Dim drDst As DataRow = DirectCast(dgvDst.Rows(dgvDst.CurrentCell.RowIndex).DataBoundItem, DataRowView).Row

            '選択された行のみ更新
            drDst("NID") = drSrc("NID")

            ''選択された行と同じN_SQLのデータをまとめて更新
            'dtDst.AsEnumerable.Where(Function(n) n("N_SQL") <> "" AndAlso n("N_SQL") = drDst("N_SQL")) _
            '                  .Select(Function(n)
            '                              n("NID") = drSrc("NID")
            '                              Return n
            '                          End Function).ToList

        Else

            Dim dr As DataRow = DirectCast(dgvSrc.Rows(dgvRow).DataBoundItem, DataRowView).Row

            FormMeisai.NID = dr("NID")
            FormMeisai.ShowDialog()


        End If
    End Sub

    Private Class HimejiDb
        Private Shared classLIB As New ClassLIB

        Shared Sub New()
            If classLIB.GetRegDbFile() = False Then
                MessageBox.Show("データベースファイルの設定が読めません")
                Exit Sub
            End If
        End Sub

        Public Shared Function GetNOrder() As MyOrderdDictionaly(Of String, List(Of String))
            Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
            Dim buf1 As New SortedList(Of Integer, String)
            Dim buf2 As New MyOrderdDictionaly(Of String, List(Of String))
            Dim dt As DataTable
            Dim sql As New Text.StringBuilder

#Region "名寄せ順取得SQL"
            sql.Clear()
            sql.AppendLine("SELECT FULLNAM AS N_FULLNAM")
            sql.AppendLine("      ,KANA    AS N_KANA")
            sql.AppendLine("      ,ADMIN   AS N_ADMIN")
            sql.AppendLine("      ,CITY    AS N_CITY")
            sql.AppendLine("      ,TOWN    AS N_TOWN")
            sql.AppendLine("      ,TEL     AS N_TEL")
            sql.AppendLine("      ,MAIL    AS N_MAIL")
            sql.AppendLine("FROM M_NAYOSE")
            sql.AppendLine("WHERE NAYOSE_ID = '1'")
#End Region

            '名寄せ順取得(住所は)
            dt = classSQLite.SetDataTable(sql.ToString)
            For i As Integer = 0 To dt.Columns.Count - 1
                If dt.Rows(0)(i) <> "0" Then
                    buf1.Add(Integer.Parse(dt.Rows(0)(i)), dt.Columns(i).ColumnName)
                End If
            Next

            For i As Integer = 0 To buf1.Count - 1
                Dim buf2Key As String

                Select Case buf1(buf1.Keys(i))
                    Case "N_FULLNAM"
                        buf2Key = "名前"
                    Case "N_KANA"
                        buf2Key = "カナ"
                    Case "N_ADMIN", "N_CITY", "N_TOWN"
                        buf2Key = "住所"
                    Case "N_TEL"
                        buf2Key = "電話"
                    Case "N_MAIL"
                        buf2Key = "メール"
                    Case Else
                        Throw New Exception
                End Select

                If buf2.ContainsKey(buf2Key) Then
                    buf2(buf2Key).Add(buf1(buf1.Keys(i)))
                Else
                    buf2.Add(buf2Key, New List(Of String))
                    buf2(buf2Key).Add(buf1(buf1.Keys(i)))
                End If
            Next

            Return buf2
        End Function

        Public Shared Function GetNewNId() As String
            Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
            Dim sql As New Text.StringBuilder

            sql.AppendLine("SELECT")
            sql.AppendLine("    CASE")
            sql.AppendLine("        WHEN COUNT(*) = 0 THEN 1")
            sql.AppendLine("        ELSE MAX(CAST(NID AS INTEGER)) + 1")
            sql.AppendLine("    END")
            sql.AppendLine("FROM T_RUISEKI")

            Return classSQLite.GetOneRecode(sql.ToString)
        End Function

        Public Shared Function GetMPointList() As Dictionary(Of String, MPoint)
            Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
            Dim buf As New Dictionary(Of String, MPoint)
            Dim dt As DataTable
            Dim sql As New Text.StringBuilder

            sql.AppendLine("SELECT SYOHIN,KIFUKINAGKU,POINT")
            sql.AppendLine("FROM M_POINT")

            dt = classSQLite.SetDataTable(sql.ToString)

            For i As Integer = 0 To dt.Rows.Count - 1
                buf.Add(dt.Rows(i)(0), New MPoint(dt.Rows(i)(1), dt.Rows(i)(2)))
            Next

            Return buf
        End Function

        Public Shared Function GetMNoList() As List(Of String)
            Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
            Dim dt As DataTable

            dt = classSQLite.SetDataTable("SELECT MOSHIKOMINO FROM T_MEISAI")
            Return dt.AsEnumerable.Select(Function(n) n(0).ToString).ToList
        End Function

        Public Structure MPoint
            Private p_kifuKingaku As Integer
            Private p_point As Integer

            Public Sub New(ByVal kifuKingaku As Integer, ByVal point As Integer)
                p_kifuKingaku = kifuKingaku
                p_point = point
            End Sub

            Public ReadOnly Property KifuKingaku As Integer
                Get
                    Return p_kifuKingaku
                End Get
            End Property

            Public ReadOnly Property Point As Integer
                Get
                    Return p_point
                End Get
            End Property
        End Structure
    End Class

    'CSV読込用の内部クラス
    Private Class CsvReader
        Implements IDisposable

        Private classLIB As New ClassLIB
        Private tfp As FileIO.TextFieldParser
        Private tmpsKeysOrder As New List(Of String) 'ひな型の順序を保持する
        Private tmpsKeys As New Dictionary(Of String, String)  'ひな型,CSVヘッダ名
        Private fldsKeys As New Dictionary(Of String, Integer) 'CSVヘッダ名,CSV列番号
        Private flds As String()
        Private fldsA As String()

        Private mNoList As List(Of String)
        Private mPointList As Dictionary(Of String, HimejiDb.MPoint)

        Private Sub New()
            If classLIB.GetRegDbFile() = False Then
                MessageBox.Show("データベースファイルの設定が読めません")
                Exit Sub
            End If

            Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
            Dim dt As DataTable
            Dim sql As Text.StringBuilder = New Text.StringBuilder

#Region "CSVひな型取得SQL"
            sql.Clear()
            sql.AppendLine("SELECT MOSHIKOMINO AS 申込番号")
            sql.AppendLine("      ,FULLNAM     AS 名前")
            sql.AppendLine("      ,KANA        AS フリガナ")
            sql.AppendLine("      ,ZIPCD       AS 郵便番号")
            sql.AppendLine("      ,ADMIN       AS 都道府県")
            sql.AppendLine("      ,CITY        AS 市区町村")
            sql.AppendLine("      ,TOWN        AS 番地マンション名")
            sql.AppendLine("      ,TEL         AS 電話番号")
            sql.AppendLine("      ,MAIL        AS 'e-mailアドレス'")
            sql.AppendLine("      ,KIFUKIN     AS 寄付金額")
            sql.AppendLine("      ,NYUKINHI    AS 入金処理日")
            sql.AppendLine("      ,SYOU01      AS 商品1_番号")
            sql.AppendLine("      ,SYOU01NAM   AS 商品1_商品名")
            sql.AppendLine("      ,SYOU02      AS 商品2_番号")
            sql.AppendLine("      ,SYOU02NAM   AS 商品2_商品名")
            sql.AppendLine("      ,SYOU03      AS 商品3_番号")
            sql.AppendLine("      ,SYOU03NAM   AS 商品3_商品名")
            sql.AppendLine("      ,SYOU04      AS 商品4_番号")
            sql.AppendLine("      ,SYOU04NAM   AS 商品4_商品名")
            sql.AppendLine("      ,SYOU05      AS 商品5_番号")
            sql.AppendLine("      ,SYOU05NAM   AS 商品5_商品名")
            sql.AppendLine("      ,SYOU06      AS 商品6_番号")
            sql.AppendLine("      ,SYOU06NAM   AS 商品6_商品名")
            sql.AppendLine("      ,SYOU07      AS 商品7_番号")
            sql.AppendLine("      ,SYOU07NAM   AS 商品7_商品名")
            sql.AppendLine("      ,SYOU08      AS 商品8_番号")
            sql.AppendLine("      ,SYOU08NAM   AS 商品8_商品名")
            sql.AppendLine("      ,SYOU09      AS 商品9_番号")
            sql.AppendLine("      ,SYOU09NAM   AS 商品9_商品名")
            sql.AppendLine("      ,SYOU10      AS 商品10_番号")
            sql.AppendLine("      ,SYOU10NAM   AS 商品10_商品名")
            sql.AppendLine("      ,SYOU11      AS 商品11_番号")
            sql.AppendLine("      ,SYOU11NAM   AS 商品11_商品名")
            sql.AppendLine("      ,SYOU12      AS 商品12_番号")
            sql.AppendLine("      ,SYOU12NAM   AS 商品12_商品名")
            sql.AppendLine("      ,SYOU13      AS 商品13_番号")
            sql.AppendLine("      ,SYOU13NAM   AS 商品13_商品名")
            sql.AppendLine("      ,SYOU14      AS 商品14_番号")
            sql.AppendLine("      ,SYOU14NAM   AS 商品14_商品名")
            sql.AppendLine("      ,SYOU15      AS 商品15_番号")
            sql.AppendLine("      ,SYOU15NAM   AS 商品15_商品名")
            sql.AppendLine("      ,SYOU16      AS 商品16_番号")
            sql.AppendLine("      ,SYOU16NAM   AS 商品16_商品名")
            sql.AppendLine("      ,SYOU17      AS 商品17_番号")
            sql.AppendLine("      ,SYOU17NAM   AS 商品17_商品名")
            sql.AppendLine("      ,SYOU18      AS 商品18_番号")
            sql.AppendLine("      ,SYOU18NAM   AS 商品18_商品名")
            sql.AppendLine("      ,SYOU19      AS 商品19_番号")
            sql.AppendLine("      ,SYOU19NAM   AS 商品19_商品名")
            sql.AppendLine("      ,SYOU20      AS 商品20_番号")
            sql.AppendLine("      ,SYOU20NAM   AS 商品20_商品名")
            sql.AppendLine("FROM M_HINAGATA")
            sql.AppendLine("WHERE SWON='1'")
#End Region

            'CSVひな型取得
            dt = classSQLite.SetDataTable(sql.ToString)
            For i As Integer = 0 To dt.Columns.Count - 1
                If IsDBNull(dt.Rows(0)(i)) OrElse dt.Rows(0)(i) = "" Then
                    tmpsKeys.Add(dt.Columns(i).ColumnName, dt.Columns(i).ColumnName)
                    tmpsKeysOrder.Add(dt.Columns(i).ColumnName)
                Else
                    tmpsKeys.Add(dt.Columns(i).ColumnName, dt.Rows(0)(i))
                    tmpsKeysOrder.Add(dt.Columns(i).ColumnName)
                End If
            Next
        End Sub

        Public Sub New(ByVal filePath As String)
            Me.New

            tfp = New FileIO.TextFieldParser(filePath, System.Text.Encoding.GetEncoding("Shift_JIS"))
            ' カンマ区切りの指定
            tfp.TextFieldType = FileIO.FieldType.Delimited
            tfp.SetDelimiters(",")

            ' フィールドが引用符で囲まれているか
            tfp.HasFieldsEnclosedInQuotes = True
            ' フィールドの空白トリム設定
            tfp.TrimWhiteSpace = True

            '1行目のフィールドをキーとして取得する
            If Not tfp.EndOfData Then
                Dim flds As String() = tfp.ReadFields

                For i = LBound(flds) To UBound(flds)
                    fldsKeys.Add(flds(i).Replace("""", "").Replace("=", ""), i)
                Next
            End If
        End Sub

        Public Sub ReadFields()
            flds = tfp.ReadFields

            For i = LBound(flds) To UBound(flds)
                flds(i) = flds(i).Replace("""", "").Replace("=", "")
            Next

        End Sub

        Public ReadOnly Property EndOfData() As Boolean
            Get
                Return tfp.EndOfData
            End Get
        End Property

        Public ReadOnly Property Fields(ByVal index As String) As String
            Get
                If fldsKeys.ContainsKey(tmpsKeys(index)) Then
                    Return Me.Fields(fldsKeys(tmpsKeys(index)))
                Else
                    Return ""
                End If
            End Get
        End Property

        Public ReadOnly Property Fields(ByVal index As Integer) As String
            Get
                Return flds(index)
            End Get
        End Property

        'INSERT文に使用する文字列を作成する
        Public Function GetInsertValues() As String
            Dim buf As Text.StringBuilder = New Text.StringBuilder

            buf.Append(" ")
            For i As Integer = 0 To tmpsKeys.Count - 1
                If tmpsKeysOrder(i) = "入金処理日" Then
                    If IsDate(Me.Fields(tmpsKeysOrder(i))) Then
                        buf.Append("'" & CDate(Me.Fields(tmpsKeysOrder(i))).ToString("yyyy/MM/dd") & "',")
                    Else
                        buf.Append("'',")
                    End If
                Else
                    '--- 23.12.28 k.s start ---
                    'buf.Append("'" & Me.Fields(tmpsKeysOrder(i)) & "',")
                    Select Case tmpsKeysOrder(i)
                        Case "商品1_商品名", "商品2_商品名", "商品3_商品名", "商品4_商品名", "商品5_商品名", "商品6_商品名", "商品7_商品名", "商品8_商品名", "商品9_商品名", "商品10_商品名",
                            "商品11_商品名", "商品12_商品名", "商品13_商品名", "商品14_商品名", "商品15_商品名", "商品16_商品名", "商品17_商品名", "商品18_商品名", "商品19_商品名", "商品20_商品名"
                            buf.Append(" '" & StrConv(Me.Fields(tmpsKeysOrder(i)), VbStrConv.Narrow) & "',")
                        Case Else

                            buf.Append(" '" & Me.Fields(tmpsKeysOrder(i)) & "',")
                    End Select
                    '--- 23.12.28 k.s end ---
                End If
            Next

            Return buf.ToString
        End Function

        'INSERT文に使用する文字列を作成する(名寄せ)
        Public Function GetInsertNayose() As String
            Dim classNayose As ClassNayose = New ClassNayose
            Dim buf As Text.StringBuilder = New Text.StringBuilder

            buf.Append(" ")
            buf.Append("'" & classNayose.Nayose_Name(Me.Fields("名前")) & "',")
            buf.Append("'" & classNayose.Nayose_Kana(Me.Fields("フリガナ")) & "',")
            buf.Append("'" & classNayose.Nayose_Admin(Me.Fields("都道府県")) & "',")
            buf.Append("'" & classNayose.Nayose_City(Me.Fields("市区町村")) & "',")
            buf.Append("'" & classNayose.Nayose_Banti(Me.Fields("番地マンション名")) & "',")
            buf.Append("'" & classNayose.Nayose_TEL(Me.Fields("電話番号")) & "',")
            buf.Append("'" & classNayose.Nayose_Mail(Me.Fields("e-mailアドレス")) & "',")

            Return buf.ToString
        End Function

        Public Function IsAllowedToInsert()
            If mNoList Is Nothing Then
                mNoList = HimejiDb.GetMNoList()
            End If

            If mNoList.Contains(Me.Fields("申込番号")) Then
                Return False
            End If

            If mPointList Is Nothing Then
                mPointList = HimejiDb.GetMPointList()
            End If

            For i As Integer = 1 To 20
                '--- 23.12.28 k.s start ---
                'If mPointList.ContainsKey(Me.Fields("商品" & i & "_商品名")) Then
                '    Return True
                'End If
                If mPointList.ContainsKey(StrConv(Me.Fields("商品" & i & "_商品名"), VbStrConv.Narrow)) Then
                    Return True
                End If
                '--- 23.12.28 k.s end ---
            Next

            Return False
        End Function

#Region "IDisposableインターフェイスの実装"
        Private disposedValue As Boolean

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: マネージド状態を破棄します (マネージド オブジェクト)
                End If

                ' TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                tfp.Dispose()
                ' TODO: 大きなフィールドを null に設定します
                disposedValue = True
            End If
        End Sub

        ' ' TODO: 'Dispose(disposing As Boolean)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        Protected Overrides Sub Finalize()
            ' このコードを変更しないでください。クリーンアップ コードを 'Dispose(disposing As Boolean)' メソッドに記述します
            Dispose(disposing:=False)
            MyBase.Finalize()
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            ' このコードを変更しないでください。クリーンアップ コードを 'Dispose(disposing As Boolean)' メソッドに記述します
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Private Class MyOrderdDictionaly(Of TKey, TValue)
        Private dic As New Dictionary(Of TKey, TValue)
        Private dicKeys As New List(Of TKey) '追加順保持用のリスト

        Default Public Overloads Property Item(ByVal key As TKey) As TValue
            Get
                Return dic(key)
            End Get
            Set(value As TValue)
                dic(key) = value
            End Set
        End Property

        Public Sub Add(ByVal key As TKey, ByVal value As TValue)
            dic.Add(key, value)
            dicKeys.Add(key)
        End Sub

        Public Sub Remove(ByVal key As TKey)
            dic.Remove(key)
            dicKeys.Remove(key)
        End Sub

        Public Function ContainsKey(ByVal key As TKey) As Boolean
            Return dic.ContainsKey(key)
        End Function

        Public ReadOnly Property Keys() As List(Of TKey)
            Get
                Return dicKeys
            End Get
        End Property

        Public ReadOnly Property Count()
            Get
                Return dic.Count
            End Get
        End Property
    End Class

    Private Sub RetLevel()
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)

        Try
            classSQLite.DbOpen()
            classSQLite.BeginTrans()
            classSQLite.EXEC_tr(GetSql_ToSetNLevelAndNId())
            classSQLite.Commit()

        Catch ex As SQLite.SQLiteException
            classSQLite.Rollback()
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            classSQLite.Rollback()
            Throw ex
        Finally
            classSQLite.DbClose()
        End Try

    End Sub

    Private Sub TESTToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridViewCSV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCSV.CellContentClick

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

End Class