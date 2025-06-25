Public Class FormMeisaiMain

    'ヘッダーの色
    Dim ColorAnd As Color = Color.LightPink                 'Andの色
    Dim ColorOr As Color = Color.LightYellow                'Orの色
    Dim ColorDefault As Color = SystemColors.ButtonFace     '既定の色

    Dim cstrKatu As String = "かつ"         'かつ
    Dim cstrMataha As String = "または"     'または


    '-----------------------------------------------------
    Dim _NID As String = String.Empty
    Dim _UP As String = String.Empty
    Dim nNID As Integer = 0
    Dim oNID As Integer = 0
    Dim nSEQ As Integer = 0
    Dim nTORIKOMI_HI As Integer = 0

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
    Dim classRuiseki As New ClassRuiseki

    Private Sub FormMeisaiMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Me.Labelkai.Text = classLIB.Get会社情報
        Me.Labelkai.BackColor = Color.LightGray
        Me.Label件数.Text = "件"

    End Sub

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub EXCECLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCECLToolStripMenuItem.Click
        Dim classExcel As New ClassExcel
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            classExcel.excelOutDataGred03(Me.DataGridView1, 0)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If

    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        Disp()

    End Sub
    'Disp  検索表示
    '
    Private Sub Disp()
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        Dim kensakuFLG As Boolean = False
        Dim OrSQL As String = String.Empty
        Dim AndSQL As String = String.Empty


        Dim dt As DataTable
        Dim ro As Integer = 0

        If Me.TextBox顧客ID.Text <> "" And Me.ComboBox顧客ID結合.Text <> "" Then
            Select Case Me.ComboBox顧客ID結合.Text
                Case "かつ"
                    AndSQL &= "  AND NID ='" & Me.TextBox顧客ID.Text & "'"
                    kensakuFLG = True
                Case "または"
                    OrSQL = createOrSQL(OrSQL, "NID ='" & Me.TextBox顧客ID.Text & "'")
                    kensakuFLG = True
            End Select
        End If


        'チェック
        '検索値未入力は検索させない（全件出さない）
        If (TextBox氏名.Text <> "" And ComboBox氏名パターン.Text <> "" And ComboBox氏名結合.Text <> "") Or
            (TextBox顧客ID.Text <> "" And ComboBox顧客ID結合.Text <> "") Or
            (TextBoxカナ.Text <> "" And ComboBoxカナパターン.Text <> "" And ComboBoxカナ結合.Text <> "") Or
            (ComboBox都道府県.Text <> "" And ComboBox都道府県結合.Text <> "") Or
            (TextBox市区町村.Text <> "" And ComboBox市区町村パターン.Text <> "" And ComboBox市区町村結合.Text <> "") Or
            (TextBox電話番号.Text <> "" And ComboBox電話番号パターン.Text <> "" And ComboBox電話番号結合.Text <> "") Then
        Else
            MessageBox.Show("検索条件無しでは検索出来ません。検索値と検索ﾊﾟﾀｰﾝ、検索範囲、結合条件を１つ以上入力してください。")
            TextBox氏名.Focus()
            Exit Sub
        End If

        '検索内容が入っているのに、結合条件が空白
        Dim blnChkFlg As Boolean = False

        If TextBox顧客ID.Text <> "" And (ComboBox顧客ID結合.Text = "") Then
            ComboBox顧客ID結合.Focus()
            blnChkFlg = True
        Else
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


        strSQL = "SELECT TORIKOMI_HI, SEQ, FULLNAM, KANA, ZIPCD, ADMIN, CITY, TOWN, TEL, MAIL, KIFUKIN, NYUKINHI"
        strSQL &= ", SYOU01, SYOU01NAM, SYOU02, SYOU02NAM, SYOU03, SYOU03NAM, SYOU04, SYOU04NAM, SYOU05, SYOU05NAM"
        strSQL &= ", SYOU06, SYOU06NAM, SYOU07, SYOU07NAM, SYOU08, SYOU08NAM, SYOU09, SYOU09NAM, SYOU10, SYOU10NAM"
        strSQL &= ", SYOU11, SYOU11NAM, SYOU12, SYOU12NAM, SYOU13, SYOU13NAM, SYOU14, SYOU14NAM, SYOU15, SYOU15NAM"
        strSQL &= ", SYOU16, SYOU16NAM, SYOU17, SYOU17NAM, SYOU18, SYOU18NAM, SYOU19, SYOU19NAM, SYOU20, SYOU20NAM"
        strSQL &= ", NID, NID_NOW,NID_FIRST ,MOSHIKOMINO FROM T_MEISAI"

        strSQL += CreateSQL条件()

        strSQL += " Order by NID + 0"   '文字→数値化ソート

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        dt = classSQLite.SetDataTable(strSQL)

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = classLIB.SettextButton(Me.DataGridView1, ro, "", "更新", 40, False)

        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "NID", "ID", 60, False)
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


        sbHeaderColorReset()
        Call sbHeaderColor(0, ComboBox顧客ID結合, 1, TextBox顧客ID)
        Call sbHeaderColor(0, ComboBox氏名結合, 2, TextBox氏名)
        Call sbHeaderColor(0, ComboBoxカナ結合, 3, TextBoxカナ)
        Call sbHeaderColor(0, ComboBox都道府県結合, 5, ComboBox都道府県)
        Call sbHeaderColor(0, ComboBox市区町村結合, 6, TextBox市区町村)
        Call sbHeaderColor(0, ComboBox電話番号結合, 8, TextBox電話番号)
        'ヘッダーの背景色を変える
        DataGridView1.EnableHeadersVisualStyles = False
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.DataGridView1.CurrentCell = Me.DataGridView1(2, 0)
        End If

    End Sub
    Private Function CreateSQL条件() As String
        Dim classNayose As New ClassNayose

        'And条件 AND (OR条件 OR OR条件）にしないと全部抽出されてしまうので
        Dim strwhere As String = ""
        Dim strwhereAnd As String = ""
        Dim strwhereOr As String = ""
        '顧客ID
        If Me.TextBox顧客ID.Text <> "" Then

            Me.TextBox顧客ID.Text = StrConv(Me.TextBox顧客ID.Text, VbStrConv.Narrow)

            Select Case Me.ComboBox顧客ID結合.Text
                Case cstrKatu
                    If strwhereAnd = "" Then
                    Else
                        strwhereAnd += " AND"
                    End If
                    strwhereAnd = fnstrTextBox(Me.TextBox顧客ID.Text, strwhereAnd, "NID") '顧客IDで検索
                Case cstrMataha
                    If strwhereOr = "" Then
                    Else
                        strwhereOr += " OR"
                    End If
                    strwhereOr = fnstrTextBox(Me.TextBox顧客ID.Text, strwhereOr, "NID")   '顧客IDで検索
            End Select
        End If


        '氏名
        If Me.TextBox氏名.Text <> "" And Me.ComboBox氏名パターン.Text <> "" Then

            Select Case Me.ComboBox氏名結合.Text
                Case cstrKatu
                    If strwhereAnd = "" Then
                    Else
                        strwhereAnd += " AND"
                    End If
                    strwhereAnd = fnstrTextBox(classNayose.Nayose_Name(Me.TextBox氏名.Text), Me.ComboBox氏名パターン, strwhereAnd, "N_FULLNAM") '名寄せ項目で検索
                Case cstrMataha
                    If strwhereOr = "" Then
                    Else
                        strwhereOr += " OR"
                    End If
                    strwhereOr = fnstrTextBox(classNayose.Nayose_Name(Me.TextBox氏名.Text), Me.ComboBox氏名パターン, strwhereOr, "N_FULLNAM")   '名寄せ項目で検索
            End Select
        End If

        'カタカナ
        If Me.TextBoxカナ.Text <> "" And Me.ComboBoxカナパターン.Text <> "" Then
            Select Case Me.ComboBoxカナ結合.Text
                Case cstrKatu
                    If strwhereAnd = "" Then
                    Else
                        strwhereAnd += " AND"
                    End If
                    strwhereAnd = fnstrTextBox(classNayose.Nayose_Kana(Me.TextBoxカナ.Text), Me.ComboBoxカナパターン, strwhereAnd, "N_KANA")    '名寄せ項目で検索
                Case cstrMataha
                    If strwhereOr = "" Then
                    Else
                        strwhereOr += " OR"
                    End If
                    strwhereOr = fnstrTextBox(classNayose.Nayose_Kana(Me.TextBoxカナ.Text), Me.ComboBoxカナパターン, strwhereOr, "N_KANA")  '名寄せ項目で検索
            End Select
        End If

        '都道府県
        If ComboBox都道府県.Text <> "" Then
            Select Case Me.ComboBox都道府県結合.Text
                Case cstrKatu
                    If strwhereAnd = "" Then
                    Else
                        strwhereAnd += " AND"
                    End If
                    strwhereAnd = fnstrComboBox(Me.ComboBox都道府県, strwhereAnd, "ADMIN")
                Case cstrMataha
                    If strwhereOr = "" Then
                    Else
                        strwhereOr += " OR"
                    End If
                    strwhereOr = fnstrComboBox(Me.ComboBox都道府県, strwhereOr, "ADMIN")
            End Select
        End If

        '市区町村
        If Me.TextBox市区町村.Text <> "" And Me.ComboBox市区町村パターン.Text <> "" Then
            Select Case Me.ComboBox市区町村結合.Text
                Case cstrKatu
                    If strwhereAnd = "" Then
                    Else
                        strwhereAnd += " AND"
                    End If
                    strwhereAnd = fnstrTextBox(classNayose.Nayose_City(Me.TextBox市区町村.Text), Me.ComboBox市区町村パターン, strwhereAnd, "N_CITY")  '名寄せ項目で検索
                Case cstrMataha
                    If strwhereOr = "" Then
                    Else
                        strwhereOr += " OR"
                    End If
                    strwhereOr = fnstrTextBox(classNayose.Nayose_City(Me.TextBox市区町村.Text), Me.ComboBox市区町村パターン, strwhereOr, "N_CITY")    '名寄せ項目で検索
            End Select
        End If

        '電話番号
        If Me.TextBox電話番号.Text <> "" And Me.ComboBox電話番号パターン.Text <> "" Then
            Select Case Me.ComboBox電話番号結合.Text
                Case cstrKatu
                    If strwhereAnd = "" Then
                    Else
                        strwhereAnd += " AND"
                    End If
                    strwhereAnd = fnstrTextBox(classNayose.Nayose_TEL(Me.TextBox電話番号.Text), Me.ComboBox電話番号パターン, strwhereAnd, "N_TEL")  '名寄せ項目で検索
                Case cstrMataha
                    If strwhereOr = "" Then
                    Else
                        strwhereOr += " OR"
                    End If
                    strwhereOr = fnstrTextBox(classNayose.Nayose_TEL(Me.TextBox電話番号.Text), Me.ComboBox電話番号パターン, strwhereOr, "N_TEL")    '名寄せ項目で検索
            End Select
        End If

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

        Return strwhere

    End Function



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
    Private Function fnstrTextBox(ByRef obText As String, ByVal strSQL As String, ByVal strDBItemNa As String, Optional ByVal strOmit As String = "") As String
        '未入力
        If obText = "" Then
            fnstrTextBox = strSQL
            Exit Function
        Else
            strSQL += " replace(" & strDBItemNa & ",'" & strOmit & "','') = '" & obText & "'"
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
    Private Function createOrSQL(OSQL As String, Qary As String) As String
        If OSQL = "" Then
            OSQL = " OR ( " & Qary
        Else
            OSQL = OSQL & " OR " & Qary
        End If
        Return OSQL
    End Function



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

    Private Sub Buttonクリア_Click(sender As Object, e As EventArgs) Handles Buttonクリア.Click
        Me.TextBox顧客ID.Text = ""
        Me.TextBox氏名.Text = ""
        Me.TextBoxカナ.Text = ""
        Me.TextBox市区町村.Text = ""
        Me.TextBox電話番号.Text = ""

        Me.ComboBoxカナ結合.SelectedIndex = -1
        Me.ComboBoxカナパターン.SelectedIndex = -1
        Me.ComboBox市区町村結合.SelectedIndex = -1
        Me.ComboBox市区町村パターン.SelectedIndex = -1
        Me.ComboBox氏名結合.SelectedIndex = -1
        Me.ComboBox氏名パターン.SelectedIndex = -1
        Me.ComboBox都道府県.SelectedIndex = -1
        Me.ComboBox都道府県結合.SelectedIndex = -1
        Me.ComboBox電話番号パターン.SelectedIndex = -1
        Me.ComboBox電話番号結合.SelectedIndex = -1
        Me.ComboBox顧客ID結合.SelectedIndex = -1


    End Sub

    Private TextBoxVal As String
    Public Sub SetTextBox(ByVal astrText As String)
        '自分のプロパティを利用する
        TextBoxVal = astrText
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        'ボタンが押された
        Dim msg As String = String.Empty

        If e.RowIndex >= 0 Then
            msg = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
        End If

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
            Fm.SetFormMeisaiMain(Me)

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

End Class