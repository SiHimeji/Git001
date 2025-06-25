Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.IO

Public Class ClassExcel
    Dim classRuiseki As New ClassRuiseki
    Dim Classlib As New ClassLIB

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    'EXCEL 出力(累計ポイント一覧)
    Public Sub excelOutDataGred00(dgv As DataGridView, sw As Integer)
        '

        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing

        'シートの最大表示列項目数
        Dim columnMaxNum As Integer = dgv.Columns.Count - 1
        'シートの最大表示行項目数
        Dim rowMaxNum As Integer = dgv.Rows.Count - 1
        'チェックの行数
        Dim rowOutNum As Integer = 0

        '項目名格納用リストを宣言
        Dim columnList As New List(Of String)
        '項目名を取得
        For i As Integer = 0 To (columnMaxNum)
            columnList.Add(dgv.Columns(i).HeaderCell.Value)
        Next

        'セルのデータ取得用二次元配列を宣言
        Dim v As String(,) = New String(rowMaxNum, columnMaxNum) {}

        For row As Integer = 0 To rowMaxNum
            If dgv.Rows(row).Cells(0).Value Then      'チェックボックス分のみ出力
                For col As Integer = 0 To columnMaxNum
                    'If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                    If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                        ' セルに値が入っている場合、二次元配列に格納
                        'v(row, col) = dgv.Rows(row).Cells(col).Value.ToString()
                        v(rowOutNum, col) = dgv.Rows(row).Cells(col).Value.ToString()
                    End If
                Next
                rowOutNum += 1
            End If
        Next

        ' EXCELに項目名を転送
        For i As Integer = 1 To dgv.Columns.Count
            ' シートの一行目に項目を挿入
            objWorkBook.Sheets(1).Cells(1, i) = columnList(i - 1)

            ' 罫線を設定
            objWorkBook.Sheets(1).Cells(1, i).Borders.LineStyle = True
            ' 項目の表示行に背景色を設定
            objWorkBook.Sheets(1).Cells(1, i).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objWorkBook.Sheets(1).Cells(1, i).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(1, i).Font.Bold = True
        Next

        ' EXCELにデータを範囲指定で転送
        Dim coln As String

        coln = ExcelCel(columnMaxNum)

        ' Dim data As String = "A2:" & Chr(Asc("A") + columnMaxNum) & dgv.Rows.Count + 1
        Dim data As String = "A2:" & coln & rowOutNum + 1  'dgv.Rows.Count + 1
        objWorkBook.Sheets(1).Range(data) = v
        ' データの表示範囲に罫線を設定
        objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True

        'Dim data1 As String = "A:" & coln
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit

        'objWorkBook.Sheets(1).Range("A:E").Delete


        Select Case sw
            Case 0
                '表題が空白列を削除する
                If objWorkBook.Sheets(1).Range("S1").value = Nothing Then
                    objWorkBook.Sheets(1).Columns("S:S").delete
                End If
                If objWorkBook.Sheets(1).Range("R1").value = Nothing Then
                    objWorkBook.Sheets(1).Columns("R:R").delete
                End If
                objWorkBook.Sheets(1).Columns("A:A").delete

            Case 1 '
                objWorkBook.Sheets(1).Columns("B:B").ColumnWidth = 129
                objWorkBook.Sheets(1).Columns("C:C").ColumnWidth = 60
                objWorkBook.Sheets(1).Columns("A:" & coln).RowHeight = 33
            Case 2

            Case 3


        End Select

        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing

        MessageBox.Show("EXCELを出力しました")
    End Sub
    'EXCEL 出力(通知書、送り状)
    Public Sub excelOutDataGred01(dgv As DataGridView, strHinaFileNam As String, strHinaSheetNam As String, sw As Integer, snd As String)
        If Classlib.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If

        Dim Row As Integer
        Dim strNextRank As String = ""          '次のランク
        Dim lngNextNeedPoint As Long = 0        '次のランクに必要なポイント


        Dim classRuiseki As New ClassRuiseki
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(Classlib.gstrdbPath & "\" & Classlib.gstrdbFile)
        Dim strKinenhin As String = ""
        Dim dt As DataTable
        Dim intLop As Integer


        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application = New Excel.Application

        ' エクセル表示
        objExcel.Visible = False

        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Open(strHinaFileNam)    'ひな形の Excel ブックを開く
        Dim sheetHina As Excel.Worksheet = objWorkBook.Worksheets(strHinaSheetNam)     '通知書のシート名

        '通知書シートを別の新規ブックにコピーします。
        sheetHina.Copy()

        'ひな形の Excel ブックを閉じる
        objWorkBook.Close(SaveChanges:=False)
        Marshal.ReleaseComObject(objWorkBook)
        objWorkBook = Nothing

        'コピーした Excel ブック
        Dim objWorkBookNew As Excel.Workbook = objExcel.ActiveWorkbook                  '新規ブック
        Dim sheetNew As Excel.Worksheet = objWorkBookNew.Worksheets(strHinaSheetNam)    '通知書のシート名
        Dim sheet As Excel.Worksheet
        Dim strSheetName As String                                                      '作成するシート名(NID+氏名)

        '-----------------------------------

        '行 → シート毎の作成処理
        For Row = 0 To dgv.Rows.Count - 1
            Try
                If dgv.Rows(Row).Cells(0).Value Then      'チェックボックス
                    If snd = "OKURI" Then
                        classRuiseki.ClearRankUpFlg(dgv.Rows(Row).Cells(1).Value.ToString)
                        'classRuiseki.UpDatetSoufuDay(dgv.Rows(Row).Cells(1).Value.ToString)
                    End If


                    '次のランクと石高
                    If gfnNextRankAndPoint(Long.Parse(dgv.Rows(Row).Cells(10).Value.ToString), strNextRank, lngNextNeedPoint) Then

                    End If

                    '通知書シートをその前にコピー
                    sheetNew.Copy(Before:=sheetNew)

                    'シート名をID+氏名に変更
                    strSheetName = dgv.Rows(Row).Cells(1).Value.ToString & dgv.Rows(Row).Cells(2).Value.ToString  'ID+氏名
                    objWorkBookNew.ActiveSheet.Name = strSheetName
                    sheet = DirectCast(objWorkBookNew.ActiveSheet, Excel.Worksheet)

                    '--- 23.12.28 k.s start ----
                    'sheet.Range("H6").Value = DateTime.Today.ToString     '日付
                    sheet.Range("H6").Value = DateTime.Today.ToString("yyyy年MM月dd日")     '日付
                    '--- 23.12.28 k.s end ----

                    sheet.Range("B1").NumberFormatLocal = "@"
                    sheet.Range("B1").Value = "〒" & dgv.Rows(Row).Cells(4).Value.ToString                                  '〒
                    sheet.Range("B2").NumberFormatLocal = "@"
                    sheet.Range("B2").Value = dgv.Rows(Row).Cells(5).Value.ToString & dgv.Rows(Row).Cells(6).Value.ToString '都道府県と市町村
                    sheet.Range("B3").NumberFormatLocal = "@"
                    sheet.Range("B3").Value = dgv.Rows(Row).Cells(7).Value.ToString                                         '番地･ﾏﾝｼｮﾝ名
                    sheet.Range("B5").NumberFormatLocal = "@"
                    sheet.Range("B5").Value = dgv.Rows(Row).Cells(2).Value.ToString & "　様"
                    sheet.Range("C6").NumberFormatLocal = "@"
                    'sheet.Range("I1").Value = "'(" & dgv.Rows(Row).Cells(1).Value.ToString & ")"                             'ID
                    'sheet.Range("I1").Font.Size = 9

                    If strHinaSheetNam = gcstrHinaSheetNam Then
                        '通知書
                        sheet.Range("C17").NumberFormatLocal = "@"         'ランク
                        If dgv.Rows(Row).Cells(11).Value.ToString = "" Then
                            sheet.Range("C17").Value = "未取得"
                        Else
                            sheet.Range("C17").Value = dgv.Rows(Row).Cells(11).Value.ToString
                        End If

                        sheet.Range("C18").NumberFormatLocal = "@"          '累積石高
                        sheet.Range("C18").Value = Long.Parse(dgv.Rows(Row).Cells(10).Value).ToString("##,#") & "石"
                    Else
                        '送り状
                        sheet.Range("C17").NumberFormatLocal = "@"          'ランク
                        If dgv.Rows(Row).Cells(11).Value.ToString = "" Then
                            sheet.Range("C17").Value = ""
                        Else
                            sheet.Range("C17").Value = dgv.Rows(Row).Cells(11).Value.ToString
                        End If

                        '記念品
                        intLop = 17
                        'strSQL = "SELECT KINENHIN FROM T_SOUFU WHERE NID  ='" & dgv.Rows(Row).Cells(1).Value.ToString & "' ORDER BY RANK_NAM DESC"
                        strSQL = "SELECT KINENHIN FROM T_SOUFU WHERE NID  ='" & dgv.Rows(Row).Cells(1).Value.ToString & "' and  KINENHINSENDDAY=''  ORDER BY RANK_NAM DESC"
                        dt = classSQLite.SetDataTable(strSQL)
                        For Each Rows In dt.Rows
                            intLop += 1
                            sheet.Range("C" & intLop.ToString).NumberFormatLocal = "@"          '記念品
                            sheet.Range("C" & intLop.ToString).Value = Rows("KINENHIN").ToString
                        Next

                    End If

                    '次のランクと石高
                    sheet.Range("B23").NumberFormatLocal = "@"          '次のランクと必要な石高
                    If strNextRank = "" Then
                        sheet.Range("B23").Value = ""
                    Else
                        sheet.Range("B23").Value = "※次のランク（" & strNextRank & "）にアップするために必要な石高は、" & lngNextNeedPoint.ToString("##,#") & "石です。"
                    End If

                    Select Case sw
                        Case 0

                        Case 1 '
                            sheet.Columns("B:B").ColumnWidth = 129
                            sheet.Columns("C:C").ColumnWidth = 60
                        'sheet.Columns("A:" & coln).RowHeight = 33
                        Case 2

                        Case 3

                    End Select

                    If strHinaSheetNam = gcstrHinaSheetNam Then
                        '通知書の場合
                        'ランクアップ者なら、SoufuhinAddを実行して、送付履歴を追加し、ランクアップフラグをクリアする
                        If snd = "OKURI" Then
                            If dgv.Rows(Row).Cells(13).Value.ToString = "1" Then      'ランクアップ
                                classRuiseki.SoufuHinAdd(dgv.Rows(Row).Cells(1).Value.ToString)     '送付履歴の追加
                                'classRuiseki.ClearRankUpFlg(dgv.Rows(Row).Cells(1).Value.ToString)  'ランクアップのクリア
                            End If
                        End If
                    End If

                    If snd = "OKURI" Then
                        'classRuiseki.ClearRankUpFlg(dgv.Rows(Row).Cells(1).Value.ToString)
                        classRuiseki.UpDatetSoufuDay(dgv.Rows(Row).Cells(1).Value.ToString)
                    End If

                End If

            Catch ex As Exception

            End Try
        Next

        'ひな形の通知書シートを削除
        objExcel.Application.DisplayAlerts = False
        sheetNew.Delete()
        objExcel.Application.DisplayAlerts = True

        '-----------------------------------

        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBookNew)
        objWorkBookNew = Nothing
        objExcel = Nothing

        If strHinaSheetNam = gcstrHinaSheetNam Then
            '通知書
            MessageBox.Show("ランク及び累積石高の通知を出力しました")
        Else
            '送り状
            MessageBox.Show("送り状を出力しました")
        End If
    End Sub

    '
    'マスタ関係出力
    '
    Public Sub excelOutDataGred03(dgv As DataGridView, sw As Integer)
        '

        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing

        'シートの最大表示列項目数
        Dim columnMaxNum As Integer = dgv.Columns.Count - 1
        'シートの最大表示行項目数
        Dim rowMaxNum As Integer = dgv.Rows.Count - 1
        'チェックの行数
        Dim rowOutNum As Integer = 0

        '項目名格納用リストを宣言
        Dim columnList As New List(Of String)
        '項目名を取得
        For i As Integer = 0 To (columnMaxNum)
            columnList.Add(dgv.Columns(i).HeaderCell.Value)
        Next

        'セルのデータ取得用二次元配列を宣言
        Dim v As String(,) = New String(rowMaxNum, columnMaxNum) {}

        For row As Integer = 0 To rowMaxNum
            For col As Integer = 0 To columnMaxNum
                'If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                    ' セルに値が入っている場合、二次元配列に格納
                    'v(row, col) = dgv.Rows(row).Cells(col).Value.ToString()
                    v(rowOutNum, col) = dgv.Rows(row).Cells(col).Value.ToString()
                End If
            Next
            rowOutNum += 1
        Next

        ' EXCELに項目名を転送
        For i As Integer = 1 To dgv.Columns.Count
            ' シートの一行目に項目を挿入
            objWorkBook.Sheets(1).Cells(1, i) = columnList(i - 1)

            ' 罫線を設定
            objWorkBook.Sheets(1).Cells(1, i).Borders.LineStyle = True
            ' 項目の表示行に背景色を設定
            objWorkBook.Sheets(1).Cells(1, i).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objWorkBook.Sheets(1).Cells(1, i).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(1, i).Font.Bold = True
        Next

        ' EXCELにデータを範囲指定で転送
        Dim coln As String

        coln = ExcelCel(columnMaxNum)

        ' Dim data As String = "A2:" & Chr(Asc("A") + columnMaxNum) & dgv.Rows.Count + 1
        Dim data As String = "A2:" & coln & rowOutNum + 1  'dgv.Rows.Count + 1
        objWorkBook.Sheets(1).Range(data) = v
        ' データの表示範囲に罫線を設定
        objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True

        'Dim data1 As String = "A:" & coln
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit

        'objWorkBook.Sheets(1).Range("A:E").Delete


        Select Case sw
            Case 0

            Case 1 '
                objWorkBook.Sheets(1).Columns("B:B").ColumnWidth = 129
                objWorkBook.Sheets(1).Columns("C:C").ColumnWidth = 60
                objWorkBook.Sheets(1).Columns("A:" & coln).RowHeight = 33
            Case 2


            Case 3


        End Select

        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing

        MessageBox.Show("EXCELを出力しました")
    End Sub





    Public Function ExcelCel(columnMaxNum As Integer) As String

        Dim abc1 As Integer
        Dim abc2 As Integer
        Dim coln As String

        If columnMaxNum > 26 Then
            abc1 = Int(columnMaxNum / 26) - 1
            abc2 = (columnMaxNum Mod 26)
            coln = Chr(Asc("A") + abc1) & Chr(Asc("A") + abc2)
        Else
            abc1 = (columnMaxNum Mod 26)
            If abc1 = 0 Then abc1 = 25
            coln = Chr(Asc("A") + abc1)
        End If

        Return coln

    End Function

End Class
