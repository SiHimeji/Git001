Public Class FormMeisai
    'ヘッダーの色
    Dim ColorAnd As Color = Color.LightPink                 'Andの色
    Dim ColorOr As Color = Color.LightYellow                'Orの色
    Dim ColorDefault As Color = SystemColors.ButtonFace     '既定の色

    Dim cstrKatu As String = "かつ"         'かつ
    Dim cstrMataha As String = "または"     'または


    '-----------------------------------------------------
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim _NID As String = String.Empty
    Dim _UP As String = String.Empty
    Dim nNID As Integer = 0
    Dim oNID As Integer = 0
    Dim nSEQ As Integer = 0
    Dim nTORIKOMI_HI As Integer = 0

    Public Property UP As String
        Get
            UP = _UP
        End Get
        Set(value As String)
            _UP = value
        End Set
    End Property

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


    Dim classLIB As New ClassLIB
    Dim classRuiseki As New ClassRuiseki

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub FormMeisai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ClassLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Me.TextBox顧客ID.Text = NID
        Disp()
        'Me.TopMost = Not Me.TopMost
    End Sub
    'Disp  検索表示
    '
    Private Sub Disp()
        Dim classNayose As New ClassNayose
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        Dim kensakuFLG As Boolean = False

        Dim dt As DataTable
        Dim ro As Integer = 0
        strSQL = "SELECT TORIKOMI_HI, SEQ, FULLNAM, KANA, ZIPCD, ADMIN, CITY, TOWN, TEL, MAIL, KIFUKIN, NYUKINHI"
        strSQL &= ", SYOU01, SYOU01NAM, SYOU02, SYOU02NAM, SYOU03, SYOU03NAM, SYOU04, SYOU04NAM, SYOU05, SYOU05NAM"
        strSQL &= ", SYOU06, SYOU06NAM, SYOU07, SYOU07NAM, SYOU08, SYOU08NAM, SYOU09, SYOU09NAM, SYOU10, SYOU10NAM"
        strSQL &= ", SYOU11, SYOU11NAM, SYOU12, SYOU12NAM, SYOU13, SYOU13NAM, SYOU14, SYOU14NAM, SYOU15, SYOU15NAM"
        strSQL &= ", SYOU16, SYOU16NAM, SYOU17, SYOU17NAM, SYOU18, SYOU18NAM, SYOU19, SYOU19NAM, SYOU20, SYOU20NAM"
        strSQL &= ", NID, NID_NOW,NID_FIRST ,MOSHIKOMINO FROM T_MEISAI"
        strSQL &= "  WHERE 1=1"

        If Me.TextBox顧客ID.Text <> "" Then
            strSQL &= "  AND NID ='" & Me.TextBox顧客ID.Text & "'"
            kensakuFLG = True
        End If

        '----

        strSQL &= "  ORDER BY NID"
        '<----

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()


        dt = classSQLite.SetDataTable(strSQL)

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt
        If UP = "1" Then
            ro = classLIB.SettextButton(Me.DataGridView1, ro, "", "更新", 40, False)
            ro = classLIB.SettextColumn(Me.DataGridView1, ro, "NID", "ID", 60, False)
        Else
            ro = classLIB.SettextButton(Me.DataGridView1, ro, "", "", 40, False)
            ro = classLIB.SettextColumn(Me.DataGridView1, ro, "NID", "ID", 60, True)
        End If

        nNID = ro - 1
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "FULLNAM", "名前", 120, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "KANA", "フリガナ", 140, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "ZIPCD", "郵便番号", 100, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "ADMIN", "都道府県", 100, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "CITY", "市区町村", 100, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "TOWN", "番地・マンション名", 180, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "TEL", "電話番号", 140, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "MAIL", "E-mailアドレス", 140, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "KIFUKIN", "寄附金額", 100, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "NYUKINHI", "入金処理日", 120, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "MOSHIKOMINO", "申込番号", 160, True)

        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU01", "商品１", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU01NAM", "商品１名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU02", "商品２", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU02NAM", "商品２名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU03", "商品３", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU03NAM", "商品３名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU04", "商品４", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU04NAM", "商品４名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU05", "商品５", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU05NAM", "商品５名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU06", "商品６", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU06NAM", "商品６名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU07", "商品７", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU07NAM", "商品７名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU08", "商品８", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU08NAM", "商品８名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU09", "商品９", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU09NAM", "商品９名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU10", "商品１０", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU10NAM", "商品１０名", 80, True)

        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU11", "商品１１", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU11NAM", "商品１１名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU12", "商品１２", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU12NAM", "商品１２名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU13", "商品１３", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU13NAM", "商品１３名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU14", "商品１４", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU14NAM", "商品１４名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU15", "商品１５", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU15NAM", "商品１５名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU16", "商品１６", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU16NAM", "商品１６名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU17", "商品１７", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU17NAM", "商品１７名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU18", "商品１８", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU18NAM", "商品１８名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU19", "商品１９", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU19NAM", "商品１９名", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU20", "商品２０", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SYOU20NAM", "商品２０名", 80, True)

        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "NID_NOW", "現在のNID", 60, True)
        oNID = ro - 1
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "NID_FIRST", "１個前NID", 60, True)

        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "TORIKOMI_HI", "取込日", 120, True)
        nTORIKOMI_HI = ro - 1
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "SEQ", "SEQ", 60, True)
        nSEQ = ro - 1
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

        Me.Label件数.Text = Me.DataGridView1.Rows.Count.ToString & "件"

        If UP = "" Then
            Me.DataGridView1.Columns(0).Visible = False
        End If

        sbHeaderColorReset()
        'ヘッダーの背景色を変える
        DataGridView1.EnableHeadersVisualStyles = False
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.DataGridView1.CurrentCell = Me.DataGridView1(2, 0)
        End If

    End Sub
    Private Sub sbHeaderColorReset()
        Call sbHeaderColorSet(1, "")    'ID
        Call sbHeaderColorSet(2, "")    '氏名
        Call sbHeaderColorSet(3, "")    'カナ
        Call sbHeaderColorSet(5, "")    '都道府県
        Call sbHeaderColorSet(6, "")    '市区町村
        Call sbHeaderColorSet(8, "")    '電話番号
    End Sub
    ' sbHeaderColorClr : ヘッダーの色をクリアする
    ' 引数
    ' 1 intColumnNo一覧グリッドの列番号　0始まり
    ' 2 strKetsuJyoken 検索条件(空白、かつ、または)
    '
    Private Sub sbHeaderColorSet(intColumnNo As Integer, strKetsuJyoken As String)
        'Dim ColorAnd As Color = Color.LightPink   'Andの色
        'Dim ColorOr As Color = Color.LightYellow  'Orの色
        'Dim ColorDefault As Color = Color.White   '既定の色

        With DataGridView1
            Select Case strKetsuJyoken
                Case ""
                    .Columns(intColumnNo).HeaderCell.Style.BackColor = ColorDefault
                Case cstrKatu
                    .Columns(intColumnNo).HeaderCell.Style.BackColor = ColorAnd
                Case cstrMataha
                    .Columns(intColumnNo).HeaderCell.Style.BackColor = ColorOr
                Case Else
            End Select
        End With
    End Sub

    ' sbHeaderColor : 結合条件によって、ヘッダーの色を変える
    ' 引数
    ' 1 intType オブジェクトタイプ(0:テキストボックス、コンボボックス 1:範囲 NumericUpDown、DateTimePicker
    ' 2 obKetsuJyoken 結合条件
    ' 3 intColumnNo一覧グリッドの列番号　0始まり
    ' 4 obKensakuChi 検索値
    '
    Private Sub sbHeaderColor(intType As String, obKetsuJyoken As Object, intColumnNo As Integer, Optional obKensakuChi As Object = Nothing)
        'Dim ColorAnd As Color = Color.LightPink   'Andの色
        'Dim ColorOr As Color = Color.LightYellow  'Orの色
        'Dim ColorDefault As Color = Color.White   '既定の色

        With DataGridView1
            '検索項目
            If intType = 0 Then
                If obKensakuChi.Text = "" Then
                    .Columns(intColumnNo).HeaderCell.Style.BackColor = ColorDefault
                Else
                    'NumericUpDownやDateTimePickerはこっちを通る
                    If obKetsuJyoken.Text = cstrKatu Then
                        .Columns(intColumnNo).HeaderCell.Style.BackColor = ColorAnd
                    Else
                        If obKetsuJyoken.Text = cstrMataha Then
                            .Columns(intColumnNo).HeaderCell.Style.BackColor = ColorOr
                        Else
                            .Columns(intColumnNo).HeaderCell.Style.BackColor = ColorDefault
                        End If
                    End If
                End If
            Else
                'NumericUpDownやDateTimePickerはこっちを通る
                If obKetsuJyoken.Text = cstrKatu Then
                    .Columns(intColumnNo).HeaderCell.Style.BackColor = ColorAnd
                Else
                    If obKetsuJyoken.Text = cstrMataha Then
                        .Columns(intColumnNo).HeaderCell.Style.BackColor = ColorOr
                    Else
                        .Columns(intColumnNo).HeaderCell.Style.BackColor = ColorDefault
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub Button検索_Click(sender As Object, e As EventArgs)
        Disp()
    End Sub
    'Function Chk_T_RUISEKI 累積データが存在するか
    '引数　NID
    '
    ' return　　true　 データあり
    '           false　データなし
    Private Function Chk_T_RUISEKI(wNID As String) As Boolean
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        Dim dt As DataTable

        strSQL = "SELECT FULLNAM FROM T_RUISEKI WHERE NID = '" & wNID & "'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then
            Return True
        Else
            Return False
        End If

    End Function
    'Sub EXCECLToolStripMenuItem_Click EXCEL出力
    '
    '
    Private Sub EXCECLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCECLToolStripMenuItem.Click
        Dim classExcel As New ClassExcel
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            classExcel.excelOutDataGred03(Me.DataGridView1, 0)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If

    End Sub

    ' DataGridView1 をマウスクリック
    '
    'カラム=0　NIDを変更処理
    '　　　=1　NID入力
    '
    '
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        'ボタンが押された
        Dim msg As String = String.Empty

        If e.RowIndex >= 0 Then
            msg = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
        End If
        If UP = "1" Then

            '--更新ボタン--
            If e.RowIndex >= 0 And e.ColumnIndex = 0 And msg <> "" Then

                If Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString = Me.DataGridView1.Rows(e.RowIndex).Cells(53).Value.ToString Then

                    Exit Sub
                End If
                '-- 1  52 53 
                'T_RUISEKI　の存在チェック
                If Chk_T_RUISEKI(Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString) Then

                    Dim result As DialogResult = MessageBox.Show("名寄せ先を変更しますか？",
                                             "質問",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxDefaultButton.Button2)

                    If result = vbYes Then

                        classRuiseki.UserID = UserID
                        classRuiseki.UserName = UserName

                        classRuiseki.ID_move(Me.DataGridView1.Rows(e.RowIndex).Cells(nNID).Value.ToString, Me.DataGridView1.Rows(e.RowIndex).Cells(nTORIKOMI_HI).Value.ToString, Me.DataGridView1.Rows(e.RowIndex).Cells(nSEQ).Value.ToString)

                        classRuiseki.Get_T_Ruiki_N(Me.DataGridView1.Rows(e.RowIndex).Cells(nNID).Value.ToString)
                        classRuiseki.Get_T_Ruiki_O(Me.DataGridView1.Rows(e.RowIndex).Cells(oNID).Value.ToString)

                        classRuiseki.Get_T_Meisai(Me.DataGridView1.Rows(e.RowIndex).Cells(nTORIKOMI_HI).Value.ToString, Me.DataGridView1.Rows(e.RowIndex).Cells(nSEQ).Value.ToString)

                        classRuiseki.UpdateT_Ruiseki_N(Me.DataGridView1.Rows(e.RowIndex).Cells(nNID).Value.ToString)
                        classRuiseki.UpdateT_Ruiseki_O(Me.DataGridView1.Rows(e.RowIndex).Cells(oNID).Value.ToString)

                        classRuiseki.ID_Slide(Me.DataGridView1.Rows(e.RowIndex).Cells(nTORIKOMI_HI).Value.ToString, Me.DataGridView1.Rows(e.RowIndex).Cells(nSEQ).Value.ToString)

                        msg = ""
                        If classRuiseki.ChkPointUpDown(Me.DataGridView1.Rows(e.RowIndex).Cells(nNID).Value.ToString) = "1" Then
                            msg = msg & "ID " & Me.DataGridView1.Rows(e.RowIndex).Cells(nNID).Value.ToString & " はランクアップしました"
                        End If

                        If classRuiseki.ChkPointUpDown(Me.DataGridView1.Rows(e.RowIndex).Cells(oNID).Value.ToString) = "1" Then
                            If msg <> "" Then
                                msg = msg & vbCrLf
                            End If
                            msg = msg & "ID " & Me.DataGridView1.Rows(e.RowIndex).Cells(oNID).Value.ToString & " はランクダウンしました"
                        End If
                        If msg <> "" Then
                            MessageBox.Show(msg)
                        End If

                        Disp()
                    Else


                    End If
                Else
                    MessageBox.Show("顧客ID【" & Me.DataGridView1.Rows(e.RowIndex).Cells(nNID).Value.ToString & "】が存在しません")
                    Me.DataGridView1.Rows(e.RowIndex).Cells(nNID).Value = Me.DataGridView1.Rows(e.RowIndex).Cells(oNID).Value

                End If
            End If

            '--ID変更--
            If e.RowIndex >= 0 And e.ColumnIndex = 1 Then
                Dim wwNID As String = String.Empty

                Dim Fm As New FormKey()
                Fm.SetFormMeisai(Me)
                If Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString = Nothing Then

                Else
                    Fm.wNID = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
                    wwNID = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
                End If
                Fm.ShowDialog()
                Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value = TextBoxVal

                If wwNID <> TextBoxVal Then
                    Me.DataGridView1.CurrentCell = Me.DataGridView1(0, e.RowIndex)
                End If


            End If
            End If
    End Sub
    '
    Private Sub ToCsv(hi As String, seq As String)
        Dim strSQL As String = String.Empty

        strSQL = "INSERT INTO T_CSV ("
        strSQL &= "TORIKOMI_HI, SEQ, FULLNAM, KANA, ZIPCD, ADMIN, CITY, TOWN, TEL, MAIL, KIFUKIN, NYUKINHI, SYOU01, SYOU01NAM, SYOU02, SYOU02NAM, SYOU03, SYOU03NAM, SYOU04, SYOU04NAM, SYOU05, SYOU05NAM, SYOU06, SYOU06NAM, SYOU07, SYOU07NAM, SYOU08, SYOU08NAM, SYOU09, SYOU09NAM, SYOU10, SYOU10NAM, SYOU11, SYOU11NAM, SYOU12, SYOU12NAM, SYOU13, SYOU13NAM, SYOU14, SYOU14NAM, SYOU15, SYOU15NAM, SYOU16, SYOU16NAM, SYOU17, SYOU17NAM, SYOU18, SYOU18NAM, SYOU19, SYOU19NAM, SYOU20, SYOU20NAM, N_FULLNAM, N_KANA, N_ADMIN, N_CITY, N_TOWN, N_TEL, N_MAIL, N_SQL, NLEVEL, NID, MOSHIKOMINO, ENTRY_DAY, ENTRY_NAM, UPDATE_DAY, UPDATE_NAM"
        strSQL &= ") SELECT "
        strSQL &= "TORIKOMI_HI, SEQ, FULLNAM, KANA, ZIPCD, ADMIN, CITY, TOWN, TEL, MAIL, KIFUKIN, NYUKINHI, SYOU01, SYOU01NAM, SYOU02, SYOU02NAM, SYOU03, SYOU03NAM, SYOU04, SYOU04NAM, SYOU05, SYOU05NAM, SYOU06, SYOU06NAM, SYOU07, SYOU07NAM, SYOU08, SYOU08NAM, SYOU09, SYOU09NAM, SYOU10, SYOU10NAM, SYOU11, SYOU11NAM, SYOU12, SYOU12NAM, SYOU13, SYOU13NAM, SYOU14, SYOU14NAM, SYOU15, SYOU15NAM, SYOU16, SYOU16NAM, SYOU17, SYOU17NAM, SYOU18, SYOU18NAM, SYOU19, SYOU19NAM, SYOU20, SYOU20NAM, N_FULLNAM, N_KANA, N_ADMIN, N_CITY, N_TOWN, N_TEL, N_MAIL,''     ,''    , NID, MOSHIKOMINO, ENTRY_DAY, ENTRY_NAM, UPDATE_DAY, UPDATE_NAM"
        strSQL &= "FROM T_MEISAI WHERE TORIKOMI_HI = '" & hi & "' AND  SEQ='" & seq & "'"



        strSQL = "DELETE　FROM T_MEISAI WHERE TORIKOMI_HI = '" & hi & "' AND  SEQ='" & seq & "'"



    End Sub



    '子画面からの帰り値
    Private TextBoxVal As String
    Public Sub SetTextBox(ByVal astrText As String)
        '自分のプロパティを利用する
        TextBoxVal = astrText
    End Sub

    Private Sub Buttonクリア_Click(sender As Object, e As EventArgs)
        Me.TextBox顧客ID.Text = ""

    End Sub


End Class