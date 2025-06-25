Public Class ClassRuiseki
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Public Property UserID As String
        Get
            UserID = _UserID
        End Get
        Set(value As String)
            _UserID = value
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

    'NID 付け替え後
    Public NewID As String
    Public N_Ruiseki_Kokudaka As Double       'ポイント（石高）
    Public N_Ruiseki_RANK As String           'ランク
    Public N_Ruiseki_Kifukingaku As Double    '寄附金額
    Public N_Ruiseki_Kifukaisu As Double      '回数
    Public N_Ruiseki_Nykinhi As String        '入金日
    Public N_Ruiseki_SIRIAL As String         'LOG

    'NID 付け替え前
    Public OldID As String
    Public O_Ruiseki_Kokudaka As Double       'ポイント（石高）
    Public O_Ruiseki_RANK As String           'ランク
    Public O_Ruiseki_Kifukingaku As Double    '寄附金額
    Public O_Ruiseki_Kifukaisu As Double      '回数
    Public O_Ruiseki_Nykinhi As String        '入金日
    Public O_Ruiseki_SIRIAL As String         'LOG

    Dim classLIB As New ClassLIB

    '累積テーブルの存在チェック
    Public Function ChkNID(ｗNID As String) As Boolean
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Return False
        End If
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim strSQL As Text.StringBuilder = New Text.StringBuilder
        strSQL.Clear()
        strSQL.AppendLine("SELECT NID FROM T_RUISEKI WHERE NID ='" & ｗNID & "'")

        dt = classSQLite.SetDataTable(strSQL.ToString)
        If dt.Rows.Count = 1 Then
            Return True
        Else
            Return False
        End If
    End Function



    Public Sub Get_T_Ruiki_N(NID As String)
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim strSQL As Text.StringBuilder = New Text.StringBuilder
        strSQL.Clear()
        strSQL.AppendLine("SELECT ")
        strSQL.AppendLine("	 KOKUDAKA")
        strSQL.AppendLine("	,RANK")
        strSQL.AppendLine("	,KIFUKINGAKU")
        strSQL.AppendLine("	,KIFUKAISU")
        strSQL.AppendLine(" FROM  T_RUISEKI")
        strSQL.AppendLine(" WHERE NID  ='" & NID & "'")

        dt = classSQLite.SetDataTable(strSQL.ToString)
        If dt.Rows.Count = 1 Then
            For Each row In dt.Rows
                N_Ruiseki_Kokudaka = row("KOKUDAKA")
                N_Ruiseki_RANK = row("RANK")
                N_Ruiseki_Kifukingaku = row("KIFUKINGAKU")
                N_Ruiseki_Kifukaisu = row("KIFUKAISU")
                N_Ruiseki_SIRIAL = ""
            Next
        Else
            N_Ruiseki_Kokudaka = 0
            N_Ruiseki_RANK = ""
            N_Ruiseki_Kifukingaku = 0
            N_Ruiseki_Kifukaisu = 0
            N_Ruiseki_SIRIAL = ""
        End If
    End Sub
    Public Sub Get_T_Ruiki_O(NID As String)
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim strSQL As Text.StringBuilder = New Text.StringBuilder
        strSQL.Clear()
        strSQL.AppendLine("SELECT ")
        strSQL.AppendLine("	 KOKUDAKA")
        strSQL.AppendLine("	,RANK")
        strSQL.AppendLine("	,KIFUKINGAKU")
        strSQL.AppendLine("	,KIFUKAISU")
        strSQL.AppendLine(" FROM  T_RUISEKI")
        strSQL.AppendLine(" WHERE NID  ='" & NID & "'")

        dt = classSQLite.SetDataTable(strSQL.ToString)
        If dt.Rows.Count = 1 Then
            For Each row In dt.Rows
                O_Ruiseki_Kokudaka = row("KOKUDAKA")
                O_Ruiseki_RANK = row("RANK")
                O_Ruiseki_Kifukingaku = row("KIFUKINGAKU")
                O_Ruiseki_Kifukaisu = row("KIFUKAISU")
                O_Ruiseki_SIRIAL = ""
            Next
        Else
            O_Ruiseki_Kokudaka = 0
            O_Ruiseki_RANK = ""
            O_Ruiseki_Kifukingaku = 0
            O_Ruiseki_Kifukaisu = 0
            O_Ruiseki_SIRIAL = ""
        End If
    End Sub
    Public Sub Get_T_Meisai(TORIKOMI_HI As String, SEQ As Integer)
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim pdt As DataTable
        Dim dt As DataTable
        Dim strSQL As Text.StringBuilder = New Text.StringBuilder

        strSQL.Clear()
        strSQL.AppendLine("SELECT SYOHIN, KIFUKINAGKU, POINT")
        strSQL.AppendLine(" FROM M_POINT")
        pdt = classSQLite.SetDataTable(strSQL.ToString)

        strSQL.Clear()
        strSQL.AppendLine("SELECT NYUKINHI, SYOU01, SYOU01NAM, SYOU02, SYOU02NAM, SYOU03, SYOU03NAM, SYOU04, SYOU04NAM, SYOU05, SYOU05NAM, SYOU06, SYOU06NAM, SYOU07, SYOU07NAM, SYOU08, SYOU08NAM, SYOU09, SYOU09NAM, SYOU10, SYOU10NAM, SYOU11, SYOU11NAM, SYOU12, SYOU12NAM, SYOU13, SYOU13NAM, SYOU14, SYOU14NAM, SYOU15, SYOU15NAM, SYOU16, SYOU16NAM, SYOU17, SYOU17NAM, SYOU18, SYOU18NAM, SYOU19, SYOU19NAM, SYOU20, SYOU20NAM")
        strSQL.AppendLine(" ,NID,NID_NOW")
        strSQL.AppendLine(" FROM T_MEISAI")
        strSQL.AppendLine(" WHERE  TORIKOMI_HI = '" & TORIKOMI_HI & "'")
        strSQL.AppendLine(" AND   SEQ = " & SEQ & "")
        dt = classSQLite.SetDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            N_Ruiseki_Kifukaisu = N_Ruiseki_Kifukaisu + 1
            O_Ruiseki_Kifukaisu = O_Ruiseki_Kifukaisu - 1
            If O_Ruiseki_Kifukaisu < 0 Then
                O_Ruiseki_Kifukaisu = 0
            End If

            For Each mei In dt.Rows
                If pdt.Rows.Count > 0 Then
                    For Each po In pdt.Rows
                        For x = 2 To 40 Step 2
                            If StrConv(po("SYOHIN").ToString, VbStrConv.Narrow) = StrConv(mei(x).ToString, VbStrConv.Narrow) Then

                                If N_Ruiseki_Nykinhi < mei(0).ToString Then
                                    N_Ruiseki_Nykinhi = mei(0).ToString
                                End If
                                N_Ruiseki_Kokudaka = N_Ruiseki_Kokudaka + Double.Parse(po("POINT").ToString)
                                N_Ruiseki_Kifukingaku = N_Ruiseki_Kifukingaku + Double.Parse(po("KIFUKINAGKU").ToString)

                                If O_Ruiseki_Nykinhi < mei(0).ToString Then
                                    O_Ruiseki_Nykinhi = mei(0).ToString
                                End If
                                O_Ruiseki_Kokudaka = O_Ruiseki_Kokudaka - Double.Parse(po("POINT").ToString)
                                If O_Ruiseki_Kokudaka < 0 Then
                                    O_Ruiseki_Kokudaka = 0
                                End If
                                O_Ruiseki_Kifukingaku = O_Ruiseki_Kifukingaku - Double.Parse(po("KIFUKINAGKU").ToString)
                                If O_Ruiseki_Kifukingaku < 0 Then
                                    O_Ruiseki_Kifukingaku = 0
                                End If


                            End If
                        Next
                    Next
                End If
            Next
        End If

    End Sub

    '移動先の新しい　NIDに変更する
    '
    Public Sub ID_move(wNID As String, wKOUSIN As String, wSEQ As String)
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        strSQL = "UPDATE T_MEISAI SET  NID='" & wNID & "' WHERE  TORIKOMI_HI='" & wKOUSIN & "' AND SEQ=" & wSEQ & ""
        If classSQLite.EXEC(strSQL) Then



        End If

    End Sub

    '　NID履歴をスライド
    '
    Public Sub ID_Slide(wKOUSIN As String, wSEQ As String)
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        strSQL = "UPDATE T_MEISAI SET NID_NOW=NID ,NID_FIRST = NID_NOW, NID_SECOND= NID_FIRST ,NID_THIRD = NID_SECOND ,NID_FOURTH= NID_THIRD,NID_FIFTH = NID_FOURTH  WHERE  TORIKOMI_HI='" & wKOUSIN & "' AND SEQ=" & wSEQ & ""
        If classSQLite.EXEC(strSQL) Then

        End If

    End Sub
    '
    Public Sub UpdateT_Ruiseki_O(NID As String)
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty

        strSQL = ""
        strSQL &= "UPDATE T_RUISEKI"
        strSQL &= " SET KOKUDAKA=" & O_Ruiseki_Kokudaka & ""
        strSQL &= " , KOKUDAKAFLG='1'"
        strSQL &= " , RANK='" & O_Ruiseki_RANK & "'"
        'strSQL &= " , RANKUPFLG=''"
        'strSQL &= " , KINENHIN=''"
        'strSQL &= " , KINENHINSENDDAY=''"
        'strSQL &= " , SIRIAL=''"
        strSQL &= " , KIFUKINGAKU=" & O_Ruiseki_Kifukingaku & ""
        strSQL &= " , KIFURIREKI=''"
        strSQL &= " , NYUKINDAY='" & O_Ruiseki_Nykinhi & "'"
        strSQL &= " , KIFUKAISU=" & O_Ruiseki_Kifukaisu & ""
        'strSQL &= " , BIKOU=''"
        strSQL &= " , UPDATE_DAY=" & classSQLite.GetTimeSQL & ""
        strSQL &= " , UPDATE_NAM='" & UserName & "'"
        strSQL &= " WHERE NID='" & NID & "'"
        If classSQLite.EXEC(strSQL) Then

        End If

    End Sub

    Public Sub UpdateT_Ruiseki_N(NID As String)
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty

        strSQL = ""
        strSQL &= "UPDATE T_RUISEKI"
        strSQL &= " SET KOKUDAKA=" & N_Ruiseki_Kokudaka & ""
        strSQL &= " , KOKUDAKAFLG='1'"
        strSQL &= " , RANK='" & N_Ruiseki_RANK & "'"
        'strSQL &= " , RANKUPFLG=''"
        'strSQL &= " , KINENHIN=''"
        'strSQL &= " , KINENHINSENDDAY=''"
        'strSQL &= " , SIRIAL=''"
        strSQL &= " , KIFUKINGAKU=" & N_Ruiseki_Kifukingaku & ""
        strSQL &= " , KIFURIREKI=''"
        strSQL &= " , NYUKINDAY='" & N_Ruiseki_Nykinhi & "'"
        strSQL &= " , KIFUKAISU=" & N_Ruiseki_Kifukaisu & ""
        'strSQL &= " , BIKOU=''"
        strSQL &= " , UPDATE_DAY=" & classSQLite.GetTimeSQL & ""
        strSQL &= " , UPDATE_NAM='" & UserName & "'"
        strSQL &= " WHERE NID='" & NID & "'"
        If classSQLite.EXEC(strSQL) Then

        End If

    End Sub
    '------- 
    '取得ポイント（石）から送付を作成
    '
    '
    Public Sub SoufuHinAdd(wNID As String)
        If GetRankFromPoint(wNID) <> "" Then
            ToRankFromPoint(wNID)
        End If
    End Sub

    '--------------------------
    'ランクアップフラグが１の人でループする
    '---------------------
    Public Sub RuncUptoSoufu()
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Return
        End If
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        strSQL = "SELECT tr.NID  FROM T_RUISEKI tr WHERE tr.RANKUPFLG ='1'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            For Each row In dt.Rows
                ToRankFromPoint(row(0).ToString)
            Next
        End If

    End Sub

    '保有ポイントからランクを求める 送付履歴を追加する
    Public Sub ToRankFromPoint(wNID As String)
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Return
        End If
        Dim nm As Integer = 0
        Dim wRank As String = String.Empty
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim dta As DataTable

        strSQL = ""
        strSQL &= "SELECT tr.KOKUDAKA ,tr.RANK,mr.RANK_NAM ,mr.POINT  ,mr.KINENHIN "
        strSQL &= " FROM T_RUISEKI tr "
        strSQL &= " LEFT OUTER JOIN M_RANK mr ON tr.KOKUDAKA >= mr.POINT "
        strSQL &= " WHERE tr.NID ='" & wNID & "'"
        strSQL &= " AND  mr.RANK_NAM NOT like '×%'"
        strSQL &= " AND  mr.RANK_NAM NOT IN (SELECT ts.RANK_NAM  FROM T_SOUFU ts WHERE ts.NID = '" & wNID & "')"
        strSQL &= " ORDER BY mr.POINT ASC"

        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count > 0 Then

            'strSQL = ""
            'strSQL &= "UPDATE T_RUISEKI"
            'strSQL &= " SET KINENHIN = ''"
            'strSQL &= " ,UPDATE_DAY =" & classSQLite.GetTimeSQL & ""
            'strSQL &= " ,UPDATE_NAM ='" & UserID & "'"
            'strSQL &= " WHERE NID ='" & wNID & "'"

            'If classSQLite.EXEC(strSQL) Then
            'End If

            For Each row In dt.Rows

                strSQL = ""
                strSQL &= "SELECT NID, RANK_NAM FROM T_SOUFU WHERE NID = '" & wNID & "'"
                strSQL &= " AND RANK_NAM = '" & row("RANK_NAM").ToString & "'"
                dta = classSQLite.SetDataTable(strSQL)
                If dta.Rows.Count = 0 Then

                    strSQL = ""
                    strSQL &= "INSERT INTO T_SOUFU"
                    strSQL &= "(NID, RANK_NAM, KINENHIN, KINENHINSENDDAY, SIRIAL, ENTRY_DAY, ENTRY_NAM, UPDATE_DAY, UPDATE_NAM)VALUES("
                    strSQL &= "  '" & wNID & "'"
                    strSQL &= ", '" & row("RANK_NAM").ToString & "'"
                    strSQL &= ", '" & row("KINENHIN").ToString & "'"
                    strSQL &= " ,''"
                    strSQL &= ", ''"
                    strSQL &= " ," & classSQLite.GetTimeSQL & ""
                    strSQL &= " ,'" & UserID & "'"
                    strSQL &= " ," & classSQLite.GetTimeSQL & ""
                    strSQL &= " ,'" & UserID & "'"
                    strSQL &= ")"

                    If classSQLite.EXEC(strSQL) Then

                    End If

                    'wRank = row("RANK_NAM").ToString
                    'strSQL = ""
                    'strSQL &= "UPDATE T_RUISEKI"
                    'strSQL &= " SET RANK = '" & wRank & "'"
                    'strSQL &= " ,KINENHIN = KINENHIN || '" & wRank.Substring(0, 1) & "'"
                    'strSQL &= " ,KINENHINSENDDAY =" & classSQLite.GetDateSQL & ""
                    'strSQL &= " ,UPDATE_DAY =" & classSQLite.GetTimeSQL & ""
                    'strSQL &= " ,UPDATE_NAM ='" & UserID & "'"
                    'strSQL &= " WHERE NID ='" & wNID & "'"
                    'If classSQLite.EXEC(strSQL) Then
                    'End If

                End If
                nm = nm + 1

            Next
        End If


    End Sub

    '
    '現在のランクを取得する
    '
    Public Function GetRankFromPoint(wNID As String)
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Return ""
        End If
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        strSQL = ""
        strSQL &= "SELECT  M_RANK.RANK_NAM , M_RANK.POINT ,T_RUISEKI.KOKUDAKA"
        strSQL &= " FROM M_RANK ,T_RUISEKI "
        strSQL &= " WHERE  M_RANK.POINT <= T_RUISEKI.KOKUDAKA  AND  T_RUISEKI.NID ='" & wNID & "'"
        strSQL &= " AND    M_RANK.RANK_NAM Not Like '×%'"
        strSQL &= " ORDER BY M_RANK.POINT DESC LIMIT 1"

        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            For Each row In dt.Rows
                Return row("RANK_NAM").ToString
            Next
        End If
        Return ""
    End Function

    '
    'ポイント（石）からランクに変化があるかどうか
    '
    '
    ' return 0 変化なし
    '　　　　1 変化あり
    Public Function ChkPointUpDown(wNID As String)
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Return ""
        End If
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable

        strSQL = ""
        strSQL &= "SELECT tr.NID ,tr.KOKUDAKA ,tr.RANK , mr.RANK_NAM ,mr.POINT "
        strSQL &= " FROM T_RUISEKI tr "
        strSQL &= " LEFT OUTER JOIN M_RANK mr On mr.POINT <= tr.KOKUDAKA "
        strSQL &= " WHERE tr.NID ='" & wNID & "'"
        strSQL &= " ORDER BY mr.POINT DESC"
        strSQL &= " LIMIT 1"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            For Each row In dt.Rows
                If row("RANK").ToString = row("RANK_NAM").ToString Then
                    Return "0"
                End If
            Next
        End If
        Return "1"

    End Function

    '累積のランクアップフラグをクリアする
    Public Sub ClearRankUpFlg(wNID As String)
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Return
        End If

        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable

        strSQL = ""
        strSQL &= "SELECT RANKUPFLG "
        strSQL &= " FROM T_RUISEKI "
        strSQL &= " WHERE NID ='" & wNID & "'"

        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            strSQL = ""
            strSQL &= "UPDATE T_RUISEKI"
            strSQL &= " SET RANKUPFLG = '0'"
            strSQL &= " ,UPDATE_DAY =" & classSQLite.GetTimeSQL & ""
            strSQL &= " ,UPDATE_NAM ='" & UserID & "'"
            strSQL &= " WHERE NID ='" & wNID & "'"

            If classSQLite.EXEC(strSQL) Then
            End If
        End If
    End Sub

    '送付履歴に送付日を入れる
    Public Sub UpDatetSoufuDay(wNID As String)

        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Return
        End If
        Dim dt As DataTable
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt1 As DateTime = DateTime.Now

        strSQL = "UPDATE T_SOUFU  SET KINENHINSENDDAY  = " & classSQLite.GetDateSQL & "   WHERE NID ='" & wNID & "' and KINENHINSENDDAY = '' "

        classSQLite.EXEC(strSQL)
        strSQL = "SELECT KINENHINSENDDAY FROM T_RUISEKI WHERE NID ='" & wNID & "'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then
            If dt.Rows(0).Item(0).ToString < dt1.ToString("yyyy/MM/dd") Then
                strSQL = "UPDATE T_RUISEKI  SET KINENHINSENDDAY  = " & classSQLite.GetDateSQL & " WHERE NID ='" & wNID & "'"
                classSQLite.EXEC(strSQL)
            End If
        Else
            strSQL = ""
        End If
    End Sub

End Class
