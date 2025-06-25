Public Class FormKifuKensaku
    '-----------------------------------------------------
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty

    '定数

    '検索結合条件
    Dim cstrKatu As String = "かつ"         'かつ
    Dim cstrMataha As String = "または"     'または

    'ランク　追加分
    Dim strRank() As String = {"", "空白", "空白以外"}

    'ヘッダーの色
    Dim ColorAnd As Color = Color.LightPink                 'Andの色
    Dim ColorOr As Color = Color.LightYellow                'Orの色
    Dim ColorDefault As Color = SystemColors.ButtonFace     '既定の色

    Dim cintFrom As Integer = 0             '値のForm値
    Dim cintTo As Integer = 5000            '値のTo値
    Dim cDateFrom As Date = #2023/10/01#    '日付のFrom値

    Dim cintBtFlag As Integer = 0           '検索ボタン1=1 検索ボタン2=2   k.s

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

    Private Sub FormKifuKensaku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If

        Me.ToolStripStatusLabel1.Text = ClassLIB.Get会社情報
        Me.ToolStripStatusLabel1.BackColor = Color.LightGray
        Me.ToolStripStatusLabel2.Text = ""


        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable

        'ランクコンボボックス
        strSQL = "SELECT RANK_NAM FROM M_RANK ORDER BY RANK_ID"
        dt = ClassSQLite.SetDataTable(strSQL)

        ComboBoxランク.Items.Clear()

        'ランク　追加分
        For i As Integer = 0 To strRank.Length - 1
            ComboBoxランク.Items.Add(strRank(i))
        Next
        'DB分
        For Each rows In dt.Rows
            ComboBoxランク.Items.Add(rows("RANK_NAM"))
        Next

        dt.Dispose()

        NumericUpDown累積石高From.Value = cintFrom
        NumericUpDown累積石高To.Value = cintTo
        NumericUpDown寄附金額From.Value = cintFrom
        NumericUpDown寄附金額To.Value = cintTo
        DateTimePicker記念品送付日From.Value = cDateFrom
        DateTimePicker記念品送付日To.Value = Now
        DateTimePicker入金日From.Value = cDateFrom
        DateTimePicker入金日To.Value = Now

        disp(True, DataGridView1)

        ActiveControl = TextBox氏名

    End Sub
    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        cintBtFlag = 1              '検索ボタン1を押したとき k.s
        Kensaku()
    End Sub

    Private Sub Kensaku()

        '【検索条件】

        'チェック
        '検索値未入力は検索させない（全件出さない）
        If (TextBox氏名.Text <> "" And ComboBox氏名パターン.Text <> "" And ComboBox氏名結合.Text <> "") Or
            (TextBoxカナ.Text <> "" And ComboBoxカナパターン.Text <> "" And ComboBoxカナ結合.Text <> "") Or
            (ComboBox都道府県.Text <> "" And ComboBox都道府県結合.Text <> "") Or
            (TextBox市区町村.Text <> "" And ComboBox市区町村パターン.Text <> "" And ComboBox市区町村結合.Text <> "") Or
            (TextBox電話番号.Text <> "" And ComboBox電話番号パターン.Text <> "" And ComboBox電話番号結合.Text <> "") Or
            (ComboBox寄付金額結合.Text <> "") Or
            (ComboBoxランク.Text <> "" And ComboBoxランク結合.Text <> "") Or
            (ComboBox累積石高結合.Text <> "") Or
            (ComboBox記念品結合.Text <> "") Or
            (ComboBox入金日結合.Text <> "") Then
        Else
            MessageBox.Show("検索条件無しでは検索出来ません。検索値と検索ﾊﾟﾀｰﾝ、検索範囲、結合条件を１つ以上入力してください。")
            TextBox氏名.Focus()
            Exit Sub
        End If

        '寄付金額大小、累積石高大小は以上の検索の為に、チェックしない
        '記念品送付日大小
        If DateTimePicker入金日From.Value > DateTimePicker入金日To.Value Then
            MessageBox.Show("入金日の範囲が正しくありません")
            DateTimePicker記念品送付日From.Focus()
            Exit Sub
        End If

        If DateTimePicker記念品送付日From.Value > DateTimePicker記念品送付日To.Value Then
            MessageBox.Show("記念品送付日の範囲が正しくありません")
            DateTimePicker記念品送付日From.Focus()
            Exit Sub
        End If

        If Me.NumericUpDown累積石高From.Value > Me.NumericUpDown累積石高To.Value Then
            MessageBox.Show("累積石高の範囲が正しくありません")
            'CType(Me.NumericUpDown累積石高From.Controls(1), TextBox).SelectAll()
            Exit Sub
        End If

        If Me.NumericUpDown寄附金額From.Value > Me.NumericUpDown寄附金額To.Value Then
            MessageBox.Show("寄附金額の範囲が正しくありません")
            Exit Sub
        End If

        '検索内容が入っているのに、結合条件が空白
        Dim blnChkFlg As Boolean = False
        If TextBox氏名.Text <> "" And (ComboBox氏名パターン.Text = "" Or ComboBox氏名結合.Text = "") Then
            ComboBox氏名結合.Focus()
            blnChkFlg = True
        Else
            If TextBoxカナ.Text <> "" And (ComboBoxカナパターン.Text = "" Or ComboBoxカナ結合.Text = "") Then
                ComboBoxカナ結合.Focus()
                blnChkFlg = True
            Else
                If ComboBox都道府県.Text <> "" And ComboBox都道府県結合.Text = "" Then
                    ComboBox都道府県結合.Focus()
                    blnChkFlg = True
                Else
                    If TextBox市区町村.Text <> "" And (ComboBox市区町村パターン.Text = "" Or ComboBox市区町村結合.Text = "") Then
                        ComboBox市区町村結合.Focus()
                        blnChkFlg = True
                    Else
                        If TextBox電話番号.Text <> "" And (ComboBox電話番号パターン.Text = "" Or ComboBox電話番号結合.Text = "") Then
                            ComboBox電話番号結合.Focus()
                            blnChkFlg = True
                        Else
                            If ComboBoxランク.Text <> "" And ComboBoxランク結合.Text = "" Then
                                ComboBoxランク.Focus()
                                blnChkFlg = True
                            End If
                        End If
                    End If
                End If
            End If
        End If




        If blnChkFlg Then
            Dim dialog1 As DialogResult = MessageBox.Show("検索パターンや結合条件が空白の場合、検索内容が入力済でも無視されます。" & vbCrLf & "無視して検索しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If dialog1 = vbNo Then
                Exit Sub
            End If
        End If

        disp(False, DataGridView1)

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

        If e.RowIndex >= 0 Then
            'チェックボックスのクリックは、累積修正を表示しない
            If e.ColumnIndex = 0 Then
                If Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value Then
                    Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value = False
                Else
                    Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value = True
                End If
            Else
                '累積修正
                Dim Fm As New FormRiseki
                Fm.UserID = UserID
                Fm.UserName = UserName
                Fm.Kengen = Kengen
                Fm.NID = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                Fm.ShowDialog()

                '累積修正から戻ってきたとき一覧表を再表示する　k.s
                If cintBtFlag = 1 Then                      '検索ボタン1を押したとき
                    Kensaku()
                ElseIf cintBtFlag = 2 Then                  '検索ボタン2を押したとき
                    'ランクアップ者一覧
                    disp(False, DataGridView1, " Where R.RANKUPFLG = '1'")
                    'ヘッダー色のリセット
                    Call sbHeaderColorReset()
                    'ヘッダー色塗り
                    Call sbHeaderColorSet(13, cstrKatu)     'ランクUP
                End If

            End If
        End If
    End Sub

    '--------------------------------------------------------------
    'ランク04の存在をチェックし、存在する場合ランク名先頭文字を返す
    '-------------------------------------------------------------
    Private Function GetRank04()
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        dt = classSQLite.SetDataTable("SELECT RANK_NAM  from M_RANK WHERE RANK_ID ='04'")
        If dt.Rows.Count = 1 Then
            Return dt.Rows(0).Item(0).ToString().Substring(0, 1)
        Else
            Return ""
        End If
    End Function
    Private Function GetRank05()
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        dt = classSQLite.SetDataTable("SELECT RANK_NAM  from M_RANK WHERE RANK_ID ='05'")
        If dt.Rows.Count = 1 Then
            Return dt.Rows(0).Item(0).ToString().Substring(0, 1)
        Else
            Return ""
        End If
    End Function

    '-----------------------------------------------
    ' disp : 表示
    ' 引数
    ' 1 blnInitial 初期表示(データ表示無し)
    ' 2 obGrid データグリッドビューの指定
    ' 3 strwhere 抽出条件の直接指定
    '
    Private Sub disp(blnInitial As Boolean, obGrid As DataGridView, Optional strwhere As String = "")
        Dim classNayose As New ClassNayose
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim ro As Integer = 0

        obGrid.DataSource = Nothing
        obGrid.Rows.Clear()
        obGrid.Columns.Clear()

        If Not blnInitial Then

            strSQL = ""
            strSQL &= " Select R.NID"
            strSQL &= "       , R.FULLNAM"
            strSQL &= "       , R.KANA"
            strSQL &= "       , R.ZIPCD"
            strSQL &= "       , R.ADMIN"
            strSQL &= "       , R.CITY"
            strSQL &= "       , R.TOWN"
            strSQL &= "       , R.TEL"
            strSQL &= "       , R.MAIL"
            strSQL &= "       , R.KOKUDAKA"
            strSQL &= "       , R.RANK"
            strSQL &= "       , S.SIRIAL"           'シリアル№
            strSQL &= "       , R.RANKUPFLG"
            strSQL &= "       , R.KINENHIN"         '送付要記念品
            strSQL &= "       , (SELECT KINENHINSENDDAY FROM T_SOUFU WHERE T_SOUFU.NID = R.NID ORDER BY KINENHINSENDDAY DESC LIMIT 1) as KINENHINSENDDAY"　　   'R.KINENHINSENDDAY  記念品送付日
            strSQL &= "       , R.KIFUKAISU"
            strSQL &= "       , R.KIFUKINGAKU"
            strSQL &= "       , R.NYUKINDAY"
            strSQL &= "       , R.BIKOU"

            strSQL &= ",(SELECT CASE WHEN KINENHINSENDDAY = '' THEN """" ELSE ""●"" END FROM T_SOUFU where NID = R.NID and RANK_NAM =(SELECT RANK_NAM FROM M_RANK  WHERE RANK_ID ='01')) as Do"
            strSQL &= ",(SELECT CASE WHEN KINENHINSENDDAY = '' THEN """" ELSE ""●"" END FROM T_SOUFU where NID = R.NID and RANK_NAM =(SELECT RANK_NAM FROM M_RANK  WHERE RANK_ID ='02')) as Gn"
            strSQL &= ",(SELECT CASE WHEN KINENHINSENDDAY = '' THEN """" ELSE ""●"" END FROM T_SOUFU where NID = R.NID and RANK_NAM =(SELECT RANK_NAM FROM M_RANK  WHERE RANK_ID ='03')) as Kn"


            If GetRank04() = "" Then
                strSQL &= ",'' as Pu"
            Else
                strSQL &= ",(SELECT CASE WHEN KINENHINSENDDAY = '' THEN """" ELSE ""●"" END FROM T_SOUFU where NID = R.NID and RANK_NAM =(SELECT RANK_NAM FROM M_RANK  WHERE RANK_ID ='04')) as Pu"
            End If
            If GetRank05() = "" Then
                strSQL &= ",'' as Bu"
            Else
                strSQL &= ",(SELECT CASE WHEN KINENHINSENDDAY = '' THEN """" ELSE ""●"" END FROM T_SOUFU where NID = R.NID and RANK_NAM =(SELECT RANK_NAM FROM M_RANK  WHERE RANK_ID ='05')) as Bu"
            End If

            strSQL &= " FROM T_RUISEKI R"
            strSQL &= "      LEFT JOIN (Select NID, MAX(SIRIAL) As SIRIAL from T_SOUFU WHERE SIRIAL Is Not NULL GROUP BY NID) S"   'シリアル№
            strSQL &= "      ON R.NID = S.NID"

            'strwhere文を指定する場合
            If strwhere = "" Then

                'And条件 AND (OR条件 OR OR条件）にしないと全部抽出されてしまうので
                Dim strwhereAnd As String = ""
                Dim strwhereOr As String = ""

                '氏名
                If TextBox氏名.Text <> "" And ComboBox氏名パターン.Text <> "" Then

                    Select Case ComboBox氏名結合.Text
                        Case cstrKatu
                            If strwhereAnd = "" Then
                            Else
                                strwhereAnd += " AND"
                            End If
                            strwhereAnd = fnstrTextBox(classNayose.Nayose_Name(Me.TextBox氏名.Text), ComboBox氏名パターン, strwhereAnd, "N_FULLNAM") '名寄せ項目で検索
                        Case cstrMataha
                            If strwhereOr = "" Then
                            Else
                                strwhereOr += " OR"
                            End If
                            strwhereOr = fnstrTextBox(classNayose.Nayose_Name(TextBox氏名.Text), ComboBox氏名パターン, strwhereOr, "N_FULLNAM")   '名寄せ項目で検索
                    End Select
                End If

                'カタカナ
                If TextBoxカナ.Text <> "" And ComboBoxカナパターン.Text <> "" Then
                    Select Case ComboBoxカナ結合.Text
                        Case cstrKatu
                            If strwhereAnd = "" Then
                            Else
                                strwhereAnd += " AND"
                            End If
                            strwhereAnd = fnstrTextBox(classNayose.Nayose_Kana(TextBoxカナ.Text), ComboBoxカナパターン, strwhereAnd, "N_KANA")    '名寄せ項目で検索
                        Case cstrMataha
                            If strwhereOr = "" Then
                            Else
                                strwhereOr += " OR"
                            End If
                            strwhereOr = fnstrTextBox(classNayose.Nayose_Kana(TextBoxカナ.Text), ComboBoxカナパターン, strwhereOr, "N_KANA")  '名寄せ項目で検索
                    End Select
                End If

                '都道府県
                If ComboBox都道府県.Text <> "" Then
                    Select Case ComboBox都道府県結合.Text
                        Case cstrKatu
                            If strwhereAnd = "" Then
                            Else
                                strwhereAnd += " AND"
                            End If
                            strwhereAnd = fnstrComboBox(ComboBox都道府県, strwhereAnd, "ADMIN")
                        Case cstrMataha
                            If strwhereOr = "" Then
                            Else
                                strwhereOr += " OR"
                            End If
                            strwhereOr = fnstrComboBox(ComboBox都道府県, strwhereOr, "ADMIN")
                    End Select
                End If

                '市区町村
                If TextBox市区町村.Text <> "" And ComboBox市区町村パターン.Text <> "" Then
                    Select Case ComboBox市区町村結合.Text
                        Case cstrKatu
                            If strwhereAnd = "" Then
                            Else
                                strwhereAnd += " AND"
                            End If
                            strwhereAnd = fnstrTextBox(classNayose.Nayose_City(TextBox市区町村.Text), ComboBox市区町村パターン, strwhereAnd, "N_CITY")  '名寄せ項目で検索
                        Case cstrMataha
                            If strwhereOr = "" Then
                            Else
                                strwhereOr += " OR"
                            End If
                            strwhereOr = fnstrTextBox(classNayose.Nayose_City(TextBox市区町村.Text), ComboBox市区町村パターン, strwhereOr, "N_CITY")    '名寄せ項目で検索
                    End Select
                End If

                '電話番号
                If TextBox電話番号.Text <> "" And ComboBox電話番号パターン.Text <> "" Then
                    Select Case ComboBox電話番号結合.Text
                        Case cstrKatu
                            If strwhereAnd = "" Then
                            Else
                                strwhereAnd += " AND"
                            End If
                            strwhereAnd = fnstrTextBox(classNayose.Nayose_TEL(TextBox電話番号.Text), ComboBox電話番号パターン, strwhereAnd, "N_TEL")  '名寄せ項目で検索
                        Case cstrMataha
                            If strwhereOr = "" Then
                            Else
                                strwhereOr += " OR"
                            End If
                            strwhereOr = fnstrTextBox(classNayose.Nayose_TEL(TextBox電話番号.Text), ComboBox電話番号パターン, strwhereOr, "N_TEL")    '名寄せ項目で検索
                    End Select
                End If

                '寄附金額
                Select Case ComboBox寄付金額結合.Text
                    Case cstrKatu
                        If strwhereAnd = "" Then
                        Else
                            strwhereAnd += " AND"
                        End If
                        strwhereAnd = fnstrNumericUpDown(NumericUpDown寄附金額From, NumericUpDown寄附金額To, strwhereAnd, "KIFUKINGAKU")
                    Case cstrMataha
                        If strwhereOr = "" Then
                        Else
                            strwhereOr += " OR"
                        End If
                        strwhereOr = fnstrNumericUpDown(NumericUpDown寄附金額From, NumericUpDown寄附金額To, strwhereOr, "KIFUKINGAKU")
                End Select

                'ランク
                If ComboBoxランク.Text <> "" Then
                    Select Case ComboBoxランク結合.Text
                        Case cstrKatu
                            If strwhereAnd = "" Then
                            Else
                                strwhereAnd += " AND"
                            End If

                            If ComboBoxランク.Text = "空白" Then
                                strwhereAnd += " RANK = ''"
                            Else
                                If ComboBoxランク.Text = "空白以外" Then
                                    strwhereAnd += " RANK <> ''"
                                Else
                                    strwhereAnd = fnstrComboBox(ComboBoxランク, strwhereAnd, "RANK")
                                End If
                            End If

                        Case cstrMataha
                            If strwhereOr = "" Then
                            Else
                                strwhereOr += " OR"
                            End If

                            If ComboBoxランク.Text = "空白" Then
                                strwhereOr += " RANK = ''"
                            Else
                                If ComboBoxランク.Text = "空白以外" Then
                                    strwhereOr += " RANK <> ''"
                                Else
                                    strwhereOr = fnstrComboBox(ComboBoxランク, strwhereOr, "RANK")
                                End If
                            End If
                    End Select
                End If

                '累積石高
                Select Case ComboBox累積石高結合.Text
                    Case cstrKatu
                        If strwhereAnd = "" Then
                        Else
                            strwhereAnd += " AND"
                        End If
                        strwhereAnd = fnstrNumericUpDown(NumericUpDown累積石高From, NumericUpDown累積石高To, strwhereAnd, "KOKUDAKA")
                    Case cstrMataha
                        If strwhereOr = "" Then
                        Else
                            strwhereOr += " OR"
                        End If
                        strwhereOr = fnstrNumericUpDown(NumericUpDown累積石高From, NumericUpDown累積石高To, strwhereOr, "KOKUDAKA")
                End Select

                '記念品送付日
                Select Case ComboBox記念品結合.Text
                    Case cstrKatu
                        If strwhereAnd = "" Then
                        Else
                            strwhereAnd += " AND"
                        End If
                        If Me.RadioButton送付日すべて.Checked Then
                            strwhereAnd = strwhereAnd & " R.NID IN (SELECT NID FROM T_SOUFU  WHERE KINENHINSENDDAY BETWEEN  '" & DateTimePicker記念品送付日From.Value.ToShortDateString & "' AND  '" & DateTimePicker記念品送付日To.Value.ToShortDateString & "') " 'fnstrDateTimePicker(DateTimePicker記念品送付日From, DateTimePicker記念品送付日To, strwhereAnd, "KINENHINSENDDAY")
                        Else
                            strwhereAnd = strwhereAnd & " R.KINENHINSENDDAY BETWEEN  '" & DateTimePicker記念品送付日From.Value.ToShortDateString & "' AND  '" & DateTimePicker記念品送付日To.Value.ToShortDateString & "' "
                        End If

                    Case cstrMataha
                        If strwhereOr = "" Then
                        Else
                            strwhereOr += " OR"
                        End If
                        If Me.RadioButton送付日すべて.Checked Then
                            strwhereOr = strwhereOr & " R.NID IN (SELECT NID FROM T_SOUFU  WHERE KINENHINSENDDAY BETWEEN  '" & DateTimePicker記念品送付日From.Value.ToShortDateString & "' AND  '" & DateTimePicker記念品送付日To.Value.ToShortDateString & "') " 'fnstrDateTimePicker(DateTimePicker記念品送付日From, DateTimePicker記念品送付日To, strwhereOr, "KINENHINSENDDAY")
                        Else
                            strwhereOr = strwhereOr & " R.KINENHINSENDDAY BETWEEN  '" & DateTimePicker記念品送付日From.Value.ToShortDateString & "' AND  '" & DateTimePicker記念品送付日To.Value.ToShortDateString & "' "
                        End If
                End Select

                '入金日
                Select Case ComboBox入金日結合.Text
                    Case cstrKatu
                        If strwhereAnd = "" Then
                        Else
                            strwhereAnd += " AND"
                        End If

                        strwhereAnd = fnstrDateTimePicker(DateTimePicker入金日From, DateTimePicker入金日To, strwhereAnd, "NYUKINDAY")
                    Case cstrMataha
                        If strwhereOr = "" Then
                        Else
                            strwhereOr += " OR"
                        End If
                        strwhereOr = fnstrDateTimePicker(DateTimePicker入金日From, DateTimePicker入金日To, strwhereOr, "NYUKINDAY")
                End Select

                If strwhere = "" Then
                    If strwhereAnd = "" Then
                        If strwhereOr = "" Then
                        Else
                            strwhere += " Where " & strwhereOr
                        End If
                    Else
                        strwhere += " Where " & strwhereAnd

                        If strwhereOr = "" Then
                        Else
                            strwhere += " And (" & strwhereOr & ")"
                        End If
                    End If
                Else
                    If strwhereAnd = "" Then
                        If strwhereOr = "" Then
                        Else
                            strwhere += " And (" & strwhereOr & ")"
                        End If
                    Else
                        strwhere += " And " & strwhereAnd

                        If strwhereOr = "" Then
                        Else
                            strwhere += " And (" & strwhereOr & ")"
                        End If
                    End If
                End If
            End If

            strSQL += strwhere

            strSQL += " Order by R.NID + 0"   '文字→数値化ソート

            dt = classSQLite.SetDataTable(strSQL)

            obGrid.RowHeadersVisible = False
            obGrid.AutoGenerateColumns = False
            obGrid.DataSource = dt

            If Not IsDBNull(dt.Rows.Count) Then
                ToolTip1.SetToolTip(Button検索, dt.Rows.Count.ToString & "件")
                ToolTip1.SetToolTip(Button検索２, dt.Rows.Count.ToString & "件")
            End If

        End If

        ro = classLIB.SettextChkBox(obGrid, ro, "", "選択", 55, False)                       '0
        ro = classLIB.SettextColumn(obGrid, ro, "NID", "ID", 60, False, DataGridViewContentAlignment.MiddleRight)   '1  
        ro = classLIB.SettextColumn(obGrid, ro, "FULLNAM", "名前", 120, True)                '2  
        ro = classLIB.SettextColumn(obGrid, ro, "KANA", "フリガナ", 150, True)               '3  
        ro = classLIB.SettextColumn(obGrid, ro, "ZIPCD", "郵便番号", 90, True)               '4  
        ro = classLIB.SettextColumn(obGrid, ro, "ADMIN", "都道府県", 90, True)               '5  
        ro = classLIB.SettextColumn(obGrid, ro, "CITY", "市区町村", 320, True)                '6  
        ro = classLIB.SettextColumn(obGrid, ro, "TOWN", "番地･ﾏﾝｼｮﾝ名", 160, True)           '7  
        ro = classLIB.SettextColumn(obGrid, ro, "TEL", "電話番号", 0, True)                '8  
        ro = classLIB.SettextColumn(obGrid, ro, "MAIL", "E-mailアドレス", 0, True)         '9  
        ro = classLIB.SettextColumn(obGrid, ro, "KOKUDAKA", "累積石高", 120, True)           ' 10 
        ro = classLIB.SettextColumn(obGrid, ro, "RANK", "ランク", 120, True)                 ' 11 
        ro = classLIB.SettextColumn(obGrid, ro, "SIRIAL", "ｼﾘｱﾙ№", 60, True)                  '   12 
        ro = classLIB.SettextColumn(obGrid, ro, "RANKUPFLG", "ﾗﾝｸUp", 70, True)              '13
        'ro = classLIB.SettextColumn(obGrid, ro, "KINENHIN", "送付要記念品", 100, True)       ' 14
        ro = classLIB.SettextColumn(obGrid, ro, "Do", "銅", 30, True, DataGridViewContentAlignment.MiddleCenter)  '14
        ro = classLIB.SettextColumn(obGrid, ro, "Gn", "銀", 30, True, DataGridViewContentAlignment.MiddleCenter)  '15
        ro = classLIB.SettextColumn(obGrid, ro, "Kn", "金", 30, True, DataGridViewContentAlignment.MiddleCenter)  '16
        '------プラチナ
        Dim Pu As String = GetRank04()
        Dim Bu As String = GetRank05()

        If Pu = "" Then
            ro = classLIB.SettextColumn(obGrid, ro, "Pu", Pu, 0, True)  '17
        Else
            ro = classLIB.SettextColumn(obGrid, ro, "Pu", Pu, 30, True, DataGridViewContentAlignment.MiddleCenter)  '17
        End If
        If Bu = "" Then
            ro = classLIB.SettextColumn(obGrid, ro, "Bu", Bu, 0, True)  '18
        Else
            ro = classLIB.SettextColumn(obGrid, ro, "Bu", Bu, 30, True, DataGridViewContentAlignment.MiddleCenter)  '18
        End If

        '------プラチナ
        ro = classLIB.SettextColumn(obGrid, ro, "KINENHINSENDDAY", "最終送付日", 110, True)  '19
        ro = classLIB.SettextColumn(obGrid, ro, "KIFUKAISU", "寄付回数", 75, True)           '20
        ro = classLIB.SettextColumn(obGrid, ro, "KIFUKINGAKU", "累積寄付金額", 120, True)    '21
        ro = classLIB.SettextColumn(obGrid, ro, "NYUKINDAY", "最終入金日", 110, True)        '22
        ro = classLIB.SettextColumn(obGrid, ro, "BIKOU", "備考", 150, True)                  '23


        obGrid.Columns(10).DefaultCellStyle.Format = "#,0"      '累積石高
        obGrid.Columns(20).DefaultCellStyle.Format = "#,0"      '寄付回数
        obGrid.Columns(21).DefaultCellStyle.Format = "#,0"      '寄付金額

        obGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight    '累積石高
        obGrid.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight    '寄付回数
        obGrid.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight    '寄付金額
        obGrid.AllowUserToAddRows = False
        obGrid.RowHeadersVisible = False
        obGrid.Font = New Font(“MS UI Gothic”, 14)

        '検索項目のヘッダー色変更
        Call sbHeaderColor(0, ComboBox氏名結合, 2, TextBox氏名, ComboBox氏名パターン.Text)
        Call sbHeaderColor(0, ComboBoxカナ結合, 3, TextBoxカナ, ComboBoxカナパターン.Text)
        Call sbHeaderColor(0, ComboBox都道府県結合, 5, ComboBox都道府県)
        Call sbHeaderColor(0, ComboBox市区町村結合, 6, TextBox市区町村, ComboBox市区町村パターン.Text)
        Call sbHeaderColor(0, ComboBox電話番号結合, 8, TextBox電話番号, ComboBox電話番号パターン.Text)
        Call sbHeaderColor(1, ComboBox累積石高結合, 10)
        Call sbHeaderColor(0, ComboBoxランク結合, 11, ComboBoxランク)
        'Call sbHeaderColor(1, ComboBox記念品結合, 17)
        Call sbHeaderColor(1, ComboBox記念品結合, 19)
        Call sbHeaderColor(1, ComboBox寄付金額結合, 21)
        Call sbHeaderColor(1, ComboBox入金日結合, 22)

        'ヘッダーの背景色を変える
        DataGridView1.EnableHeadersVisualStyles = False

        'チェックボックス非選択
        CheckBox全選択.Checked = False
        CheckBox全選択2.Checked = False

        Me.ToolStripStatusLabel2.Text = Me.DataGridView1.Rows.Count.ToString & "件"

    End Sub
    '-----------------------------------------------
    ' fnstrTextBox : SQL文を作成する　TEXTBox、検索パターン、SQLWhere文、DB項目名より
    ' 引数
    ' 1 TEXTBoxオブジェクト
    ' 2 検索パターンオブジェクト
    ' 3 既にあるWhere文（AND,ORの要否判断）
    ' 4 DB項目名
    ' 5 strOmit オプション　データ値を除いて検索する(例、電話番号の"-")
    ' return SQL文
    '
    Private Function fnstrTextBox(ByRef obText As String, ByRef obPattern As ComboBox, ByVal strSQL As String, ByVal strDBItemNa As String, Optional ByVal strOmit As String = "") As String
        '未入力
        If obText = "" Then
            fnstrTextBox = strSQL
            Exit Function
        Else
            Select Case obPattern.Text
                Case "一致"
                    strSQL += " replace(" & strDBItemNa & ",'" & strOmit & "','') = '" & obText & "'"
                Case "前方"
                    strSQL += " replace(" & strDBItemNa & ",'" & strOmit & "','') LIKE '" & obText & "%'"
                Case "後方"
                    strSQL += " replace(" & strDBItemNa & ",'" & strOmit & "','') LIKE '%" & obText & "'"
                Case "部分"
                    strSQL += " replace(" & strDBItemNa & ",'" & strOmit & "','') LIKE '%" & obText & "%'"
            End Select

            fnstrTextBox = strSQL
        End If
    End Function
    '-----------------------------------------------
    ' fnstrComboBox : SQL文を作成する　ComboBox、SQLWhere文、DB項目名より
    ' 引数
    ' 1 ComboBoxオブジェクト
    ' 2 既にあるWhere文（AND,ORの要否判断）
    ' 3 DB項目名
    ' return SQL文
    '
    Private Function fnstrComboBox(ByRef obText As ComboBox, ByVal strSQL As String, ByVal strDBItemNa As String) As String
        '未入力
        If obText.Text = "" Then
            fnstrComboBox = strSQL
            Exit Function
        Else
            strSQL += " " & strDBItemNa & " = '" & obText.Text.Trim & "'"

            fnstrComboBox = strSQL
        End If
    End Function
    '-----------------------------------------------
    ' fnstrfnstrNumericUpDown : SQL文を作成する　fnstrNumericUpDown、SQLWhere文、DB項目名より
    ' 引数
    ' 1 NumericUpDownオブジェクト From
    ' 2 NumericUpDownオブジェクト To
    ' 3 既にあるWhere文（AND,ORの要否判断）
    ' 4 DB項目名
    ' return SQL文
    '
    Private Function fnstrNumericUpDown(ByRef obTextFrom As NumericUpDown, ByRef obTextTo As NumericUpDown, ByVal strSQL As String, ByVal strDBItemNa As String) As String
        '開始のみ
        If obTextFrom.Text <> "" And obTextTo.Text = "" Then
            strSQL += " (" & strDBItemNa & " >= " & obTextFrom.Value & ")"
        Else
            '終了のみ
            If obTextFrom.Text = "" And obTextTo.Text <> "" Then
                strSQL += " (" & strDBItemNa & " <=" & obTextTo.Value & ")"
            Else
                '開始、終了
                                                         If obTextFrom.Text <> "" And obTextTo.Text <> "" Then
                    '開始、終了
                    strSQL += " (" & strDBItemNa & " >= " & obTextFrom.Value & " AND " & strDBItemNa & " <= " & obTextTo.Value & ")"
                Else
                    strSQL = ""
                End If
            End If
        End If
        fnstrNumericUpDown = strSQL
    End Function
    '-----------------------------------------------
    ' fnstrDateTimePicker : SQL文を作成する　fnstrDateTimePicker、SQLWhere文、DB項目名より
    ' 引数
    ' 1 DateTimePickerオブジェクト From
    ' 2 DateTimePickerオブジェクト To
    ' 3 既にあるWhere文（AND,ORの要否判断）
    ' 4 DB項目名
    ' return SQL文
    '
    Private Function fnstrDateTimePicker(ByRef obTextFrom As DateTimePicker, ByRef obTextTo As DateTimePicker, ByVal strSQL As String, ByVal strDBItemNa As String) As String
        '未入力
        strSQL += " (" & strDBItemNa & " >= '" & obTextFrom.Value.ToShortDateString & "' AND " & strDBItemNa & " <= '" & obTextTo.Value.ToShortDateString & "')"

        fnstrDateTimePicker = strSQL
    End Function
    '-----------------------------------------------
    ' gfnDbSelect : Select文の第一項目値を返す
    ' 引数
    ' 1 SQL文
    ' 2 第一項目値
    ' return true:データあり、False:データ無し
    '
    Private Function gfnDbSelect(ByVal strSQL As String, ByRef strName As String) As Boolean
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim ro As Integer = 0

        dt = classSQLite.SetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            strName = ""
            gfnDbSelect = False
        Else
            strName = dt.Rows(0)(0).ToString
            gfnDbSelect = True
        End If

        dt.Dispose()
    End Function

    'ヘッダー色のリセット
    Private Sub sbHeaderColorReset()
        Call sbHeaderColorSet(2, "")    '氏名
        Call sbHeaderColorSet(3, "")    'カナ
        Call sbHeaderColorSet(5, "")    '都道府県
        Call sbHeaderColorSet(6, "")    '市区町村
        Call sbHeaderColorSet(8, "")    '電話番号
        Call sbHeaderColorSet(17, "")   '寄付金額
        Call sbHeaderColorSet(11, "")   'ランク
        Call sbHeaderColorSet(10, "")   '累積石高
        Call sbHeaderColorSet(15, "")   '記念品
        Call sbHeaderColorSet(18, "")   '入金日
    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        Dim blnSakuseiFlg As Boolean = False    '作成したフラグ

        'チェック付き分の有無確認
        blnSakuseiFlg = False
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(0).Value Then      'チェックボックス
                blnSakuseiFlg = True
                Exit For
            End If
        Next
        If Not blnSakuseiFlg = True Then
            MessageBox.Show("出力対象がチェックされていません")
            Exit Sub
        End If

        Dim classExcel As New ClassExcel
        Call classExcel.excelOutDataGred00(DataGridView1, 0)
    End Sub
    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim cstrOutputFileNam As String = "検索"
        Dim strFileName As String

        'DBフォルダ―の下に"出力"フォルダ―を作成
        If Not System.IO.Directory.Exists(classLIB.gstrdbPath & "\" & gcstrHinaFolder) Then
            System.IO.Directory.CreateDirectory(classLIB.gstrdbPath & "\" & gcstrHinaFolder)
        End If
        strFileName = classLIB.gstrdbPath & "\" & gcstrHinaFolder & "\" & cstrOutputFileNam & "_" & Format(Now(), "yyyyMMddhhmmss") & ".CSV"

        Call SaveToCsv(DataGridView1, strFileName)

        MessageBox.Show("csvファイルを、" & strFileName & " に作成しました")

    End Sub

    '保存したいDataGridViewコントロールの名前を引数として
    '設定します。
    Public Sub SaveToCsv(ByVal tempDgv As DataGridView, ByVal strFolderFileName As String)

        '1行もデータが無い場合は、保存を中止します。
        If tempDgv.Rows.Count = 0 Then
            Exit Sub
        End If

        '変数を定義します。
        Dim i As Integer
        Dim j As Integer
        Dim strFileName As String
        Dim strResult As New System.Text.StringBuilder
        Dim strData As String

        'コラムヘッダを1行目に列記します。
        '※ヘッダ行が不要な場合は削除可能です。
        For i = 0 To tempDgv.Columns.Count - 1
            Select Case i
                Case 0
                    strResult.Append("""" & tempDgv.Columns(i).HeaderText.ToString & """")

                Case tempDgv.Columns.Count - 1
                    strResult.Append("," & """" & tempDgv.Columns(i).HeaderText.ToString & """" & vbCrLf)

                Case Else
                    strResult.Append("," & """" & tempDgv.Columns(i).HeaderText.ToString & """")
            End Select

        Next

        'データを保存します。
        '※新規行の追加を認めている場合は、次行の
        '「tempDgv.Columns.Count - 1」を
        '「tempDgv.Columns.Count - 2」としてください。
        For i = 0 To tempDgv.Rows.Count - 1
            For j = 0 To tempDgv.Columns.Count - 1
                If tempDgv.Rows(i).Cells(j).Value Is Nothing Then
                    strData = ""
                Else
                    strData = tempDgv.Rows(i).Cells(j).Value.ToString
                End If
                Select Case j
                    Case 0
                        strResult.Append("""" & strData & """")

                    Case tempDgv.Columns.Count - 1
                        strResult.Append("," & """" & strData & """" & vbCrLf)

                    Case Else
                        strResult.Append("," & """" & strData & """")
                End Select

            Next
        Next

        '保存するフォルダ―とファイル名
        strFileName = strFolderFileName

        'Shift-JISで保存します。
        Dim swText As New System.IO.StreamWriter(strFileName, False, System.Text.Encoding.GetEncoding(932))
        swText.Write(strResult.ToString)
        swText.Dispose()

    End Sub

    Private Function fnNullStr(ByVal vrData As VariantType) As String
        If vrData = VariantType.Null Then
            fnNullStr = ""
        Else
            fnNullStr = vrData.ToString
        End If
    End Function

    Private Sub ランク及び累積石高の通知ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ランク及び累積石高の通知ToolStripMenuItem.Click

        Call GetExcelFolder()
        Call sbTsuuchiOkuriExcel("T")

        'Dim classExcel As New ClassExcel
        'Dim i As Integer
        'Dim blnSakuseiFlg As Boolean = False    '作成したフラグ
        'Dim strNextRank As String = ""          '次のランク
        'Dim lngNextNeedPoint As Long = 0        '次のランクに必要なポイント

        ''DBフォルダ―の下に"EXCEL"フォルダ―のチェックと作成
        'If Not System.IO.Directory.Exists(classLIB.gstrdbPath & "\" & gcstrHinaFolder) Then
        '    System.IO.Directory.CreateDirectory(classLIB.gstrdbPath & "\" & gcstrHinaFolder)
        'End If
        ''通知書_ひな形.xlsの存在ﾁｪｯｸ
        'If Not System.IO.File.Exists(classLIB.gstrdbPath & "\" & gcstrHinaFolder & "\" & gcstrHinaFileNam) Then
        '    MessageBox.Show(gcstrHinaFileNam & " ファイルを、" & classLIB.gstrdbPath & "\" & gcstrHinaFolder & " にコピーしてください")
        '    Exit Sub
        'End If

        ''チェック付き分の有無確認
        'blnSakuseiFlg = False
        'For i = 0 To DataGridView1.Rows.Count - 1
        '    If DataGridView1.Rows(i).Cells(0).Value Then      'チェックボックス
        '        blnSakuseiFlg = True
        '        Exit For
        '    End If
        'Next
        'If Not blnSakuseiFlg = True Then
        '    MessageBox.Show("出力対象がチェックされていません")
        '    Exit Sub
        'End If

        ''チェック付き分の通知書作成処理

        ''エクセルにシート毎（NID氏名）で通知書を作成する
        'Call classExcel.excelOutDataGred01(Me.DataGridView1, classLIB.gstrdbPath & "\" & gcstrHinaFolder & "\" & gcstrHinaFileNam, gcstrHinaSheetNam, 0)

        ''MessageBox.Show("通知書を作成しました")

    End Sub

    ' sbHeaderColor : 結合条件によって、ヘッダーの色を変える
    ' 引数
    ' 1 intType オブジェクトタイプ(0:テキストボックス、コンボボックス 1:範囲 NumericUpDown、DateTimePicker
    ' 2 obKetsuJyoken 結合条件
    ' 3 intColumnNo一覧グリッドの列番号　0始まり
    ' 4 obKensakuChi 検索値
    ' 5 strPattern 検索パターンのテキスト
    '
    Private Sub sbHeaderColor(intType As String, obKetsuJyoken As Object, intColumnNo As Integer, Optional obKensakuChi As Object = Nothing, Optional strPattern As String = "")
        'Dim ColorAnd As Color = Color.LightPink   'Andの色
        'Dim ColorOr As Color = Color.LightYellow  'Orの色
        'Dim ColorDefault As Color = Color.White   '既定の色

        With DataGridView1
            '検索項目
            If intType = 0 Then
                'If obKensakuChi.Text = "" Or strPattern = "" Then
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

    Private Sub CheckBox全選択_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox全選択.CheckedChanged
        Dim i As Integer
        If CheckBox全選択.Checked Then
            For i = 0 To DataGridView1.Rows.Count - 1
                DataGridView1.Rows(i).Cells(0).Value = True
            Next
        Else
            For i = 0 To DataGridView1.Rows.Count - 1
                DataGridView1.Rows(i).Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub CheckBox全選択2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox全選択2.CheckedChanged
        Dim i As Integer
        If CheckBox全選択2.Checked Then
            For i = 0 To DataGridView1.Rows.Count - 1
                DataGridView1.Rows(i).Cells(0).Value = True
            Next
        Else
            For i = 0 To DataGridView1.Rows.Count - 1
                DataGridView1.Rows(i).Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub Button検索２_Click_1(sender As Object, e As EventArgs) Handles Button検索２.Click
        Dim strwhere As String = ""
        cintBtFlag = 2                              '検索ボタン2を押したとき k.s

        'ランクアップ者一覧
        If RadioButtonランクアップ者.Checked Then
            strwhere = " Where R.RANKUPFLG = '1'"   '1:ランクアップ者
            disp(False, DataGridView1, strwhere)

            'ヘッダー色のリセット
            Call sbHeaderColorReset()
            'ヘッダー色塗り
            Call sbHeaderColorSet(13, cstrKatu)   'ランクUP
        Else
            '記念品未送付者者一覧



        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedTab.Text = "検索１" Then
            TextBox氏名.Focus()
        Else
            RadioButtonランクアップ者.Focus()
        End If
    End Sub

    Private Sub Button検索クリア_Click(sender As Object, e As EventArgs) Handles Button検索クリア.Click
        TextBox氏名.Text = ""
        ComboBox氏名パターン.SelectedIndex = -1
        ComboBox氏名結合.Text = ""

        TextBoxカナ.Text = ""
        ComboBoxカナパターン.SelectedIndex = -1
        ComboBoxカナ結合.Text = ""

        ComboBox都道府県.Text = ""
        ComboBox都道府県結合.Text = ""

        TextBox市区町村.Text = ""
        ComboBox市区町村パターン.SelectedIndex = -1
        ComboBox市区町村結合.Text = ""

        TextBox電話番号.Text = ""
        ComboBox電話番号パターン.SelectedIndex = -1
        ComboBox電話番号結合.Text = ""

        NumericUpDown累積石高From.Value = cintFrom
        NumericUpDown累積石高To.Value = cintTo
        ComboBox累積石高結合.Text = ""

        ComboBoxランク.Text = ""
        ComboBoxランク結合.Text = ""

        DateTimePicker記念品送付日From.Value = cDateFrom
        DateTimePicker記念品送付日To.Value = Now
        ComboBox記念品結合.Text = ""

        NumericUpDown寄附金額From.Value = cintFrom
        NumericUpDown寄附金額To.Value = cintTo
        ComboBox寄付金額結合.Text = ""

        DateTimePicker入金日From.Value = cDateFrom
        DateTimePicker入金日To.Value = Now
        ComboBox入金日結合.Text = ""
    End Sub

    Private Sub 記念品送り状ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 記念品送り状ToolStripMenuItem.Click

        Call GetExcelFolder()
        Call sbTsuuchiOkuriExcel("")
    End Sub
    Private Sub 記念品送り状WORDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 記念品送り状WORDToolStripMenuItem.Click
        Call GetExcelFolder()
        Call GetWordFileName()
        Call okurijyouWord()

    End Sub


    Private Sub okurijyouWord()
        Dim classWord As New ClassWord
        Dim ro As Integer

        'DBフォルダ―の下に"EXCEL"フォルダ―のチェックと作成
        If Not System.IO.Directory.Exists(gcstrHinaFolder) Then
            MessageBox.Show("システムマスタ【60】でフォルダーを設定してください")
            Exit Sub
        End If
        If gcstrHinaWord = "" Then
            MessageBox.Show("システムマスタ【61】でワードファイルを設定してください")
            Exit Sub
        End If

        If Not System.IO.File.Exists(gcstrHinaFolder & "\" & gcstrHinaWord) Then
            MessageBox.Show(gcstrHinaWord & " ファイルを、" & gcstrHinaFolder & " にコピーしてください")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        '行 → シート毎の作成処理
        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            Try
                If Me.DataGridView1.Rows(ro).Cells(0).Value Then      'チェックボックス

                    Dim dgr As DataGridViewRow = Me.DataGridView1.Rows(ro)

                    classWord.SetWord(gcstrHinaFolder & "\" & gcstrHinaWord, dgr)

                End If
            Catch ex As Exception


            End Try
        Next
        Me.Cursor = Cursors.Default

        If classWord.InsatuOk > 0 Then
            MessageBox.Show(" ドキュメントフォルダーに、送り状を、ワードで" & classWord.InsatuOk & "件、出力しました")
        ElseIf classWord.InsatuNg > 0 Then
            MessageBox.Show(" ワードで出力で" & classWord.InsatuNg & "件、エラーがあります")
        End If

    End Sub


    Private Function copyGridToData() As DataTable

        'Dim copyToDataset As DataSet = New DataSet
        Dim dt As DataTable = DirectCast(Me.DataGridView1.DataSource, DataTable)
        'copyToDataset.Tables.Add(dt.Copy())
        Return dt

    End Function

    Private Sub GetExcelFolder()

        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable

        strSQL = "SELECT ms.NAIYOU FROM M_SYSTEM ms where ms.KBN ='60'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then
            gcstrHinaFolder = dt.Rows(0).Item(0).ToString
        End If

    End Sub

    'gcstrHinaWord
    Private Sub GetWordFileName()

        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable

        strSQL = "SELECT ms.NAIYOU FROM M_SYSTEM ms where ms.KBN ='61'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then
            gcstrHinaWord = dt.Rows(0).Item(0).ToString
        End If

    End Sub



    'チェックボックスのチェックをカーソル移動ではなく、即座に反映させる
    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.CurrentCellAddress.X = 0 AndAlso
        DataGridView1.IsCurrentCellDirty Then
            'コミットする
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub
    ' sbTsuuchiOkuriExcel : 通知書、送り状のEXCEL作成
    ' 引数
    ' 1 strKubun　"T":通知書、"T"以外:送り状
    '
    Private Sub sbTsuuchiOkuriExcel(ByVal strKubun As String)
        Dim classExcel As New ClassExcel
        Dim i As Integer
        Dim blnSakuseiFlg As Boolean = False    '作成したフラグ
        Dim strNextRank As String = ""          '次のランク
        Dim lngNextNeedPoint As Long = 0        '次のランクに必要なポイント

        'DBフォルダ―の下に"EXCEL"フォルダ―のチェックと作成
        If Not System.IO.Directory.Exists(gcstrHinaFolder) Then
            MessageBox.Show("システムマスタ【60】でフォルダーを設定してください")
            Exit Sub
            'System.IO.Directory.CreateDirectory(gcstrHinaFolder)
        End If

        If strKubun = "T" Then
            '通知書_ひな形.xlsの存在ﾁｪｯｸ
            If Not System.IO.File.Exists(gcstrHinaFolder & "\" & gcstrHinaFileNam) Then
                MessageBox.Show(gcstrHinaFileNam & " ファイルを、" & gcstrHinaFolder & " にコピーしてください")
                Exit Sub
            End If
        Else
            '送り状_ひな形.xlsの存在ﾁｪｯｸ
            If Not System.IO.File.Exists(gcstrHinaFolder & "\" & gcstrOkurijyoFileNam) Then
                MessageBox.Show(gcstrOkurijyoFileNam & " ファイルを、" & gcstrHinaFolder & " にコピーしてください")
                Exit Sub
            End If
        End If

        'チェック付き分の有無確認
        blnSakuseiFlg = False
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(0).Value Then      'チェックボックス
                If strKubun = "T" Then
                Else
                    '

                End If
                blnSakuseiFlg = True
                'Exit For
            End If
        Next
        If Not blnSakuseiFlg = True Then
            MessageBox.Show("出力対象がチェックされていません")
            Exit Sub
        End If

        'チェック付き分の通知書作成処理

        'エクセルにシート毎（NID氏名）で通知書を作成する
        Me.Cursor = Cursors.WaitCursor

        If strKubun = "T" Then
            '通知書
            Call classExcel.excelOutDataGred01(Me.DataGridView1, gcstrHinaFolder & "\" & gcstrHinaFileNam, gcstrHinaSheetNam, 0, "T")
        Else
            '送り状
            Call classExcel.excelOutDataGred01(Me.DataGridView1, gcstrHinaFolder & "\" & gcstrOkurijyoFileNam, gcstrOkurijyoSheetNam, 0, "OKURI")
        End If
        Me.Cursor = Cursors.Default

        'MessageBox.Show("通知書を作成しました")

    End Sub


End Class