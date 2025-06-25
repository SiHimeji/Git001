Module Modulelib
    Dim classLIB As New ClassLIB

    '通知書のエクセル関係定義
    Public gcstrHinaFolder As String = ""                            'ひな形ｴｸｾﾙのフォルダ―名
    Public gcstrHinaWord As String = ""                             'ひな形ワードファイル名
    Public Const gcstrHinaFileNam As String = "通知書_ひな形.xlsx"         'ひな形のファイル名
    Public Const gcstrHinaSheetNam As String = "通知書"                    'ひな形のシート名
    Public Const gcstrOkurijyoFileNam As String = "送り状_ひな形.xlsx"     '送り状のファイル名
    Public Const gcstrOkurijyoSheetNam As String = "送り状"                '送り状のシート名

    '-----------------------------------------------
    ' gfnNextRankAndPoint : 次のランクと必要なポイント
    ' 引数
    ' 1 lngPoint　現在のポイント
    ' 2 strNextRank　次のランク(次ランクは無しは、空白)
    ' 3 lngNextNeedPoint　次のランクに必要なポイント(次のランクは無しは、0)
    ' return true:次のランクあり、False:次のランク無し
    '
    Public Function gfnNextRankAndPoint(lngPoint As Long, ByRef strNextRank As String, ByRef lngNextNeedPoint As Long) As Boolean
        If classLIB.GetRegDbFile() = False Then
            'DBファイルが設定されていないのでここでは設定する
            classLIB.SetDatabaseFile()
        End If

        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable

        '次のランク検索
        strSQL = "SELECT RANK_NAM,POINT FROM M_RANK WHERE POINT IN (SELECT min(POINT) from M_RANK WHERE POINT > " & lngPoint & " )"

        dt = classSQLite.SetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            '次ランク無し
            strNextRank = ""
            lngNextNeedPoint = 0
            gfnNextRankAndPoint = False
        Else
            '次ランクあり
            strNextRank = dt.Rows(0).Item(0).ToString()
            lngNextNeedPoint = Long.Parse(dt.Rows(0).Item(1).ToString()) - lngPoint
            gfnNextRankAndPoint = True
        End If
        dt.Dispose()

    End Function

End Module
