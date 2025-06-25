'
Imports Microsoft.Office.Interop
'
'
Public Class ClassWord

    Public InsatuOk As Integer
    Public InsatuNg As Integer

    Private wdApp As Word.Application
    Private wdDocs As Word.Documents
    Private wdDoc As Word.Document

    Public Sub New()
        InsatuOk = 0
        InsatuNg = 0
    End Sub


    Public Sub SetWord(ByVal wordfile As String, ByVal dgr As DataGridViewRow)
        Dim strNoSheetName As String = ""
        Dim strSheetName As String = ""
        Dim strRank As String = ""
        Dim strPoint As String = ""
        Dim strKinen1 As String = ""
        Dim strKinen2 As String = ""
        Dim strKinen3 As String = ""

        Dim yubin As String = ""
        Dim addres As String = ""


        Dim ci As New System.Globalization.CultureInfo("ja-JP", False)
        ci.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar()
        ' 和暦年月日
        Dim wanen As String = Now.ToString("gy", ci)
        wanen = StrConv(wanen, VbStrConv.Wide)

        Dim yyyy As String = Now.ToString("yyyy")
        Dim mon As String = Now.ToString("MM")
        Dim day As String = Now.ToString("dd")


        mon = String.Format("{0:#0}", Integer.Parse(mon))
        day = String.Format("{0:#0} ", Integer.Parse(day))


        Dim strSQL As String
        Dim dt As DataTable
        Dim r As Integer = 0
        Dim docpath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)

        Dim classRuiseki As New ClassRuiseki
        Dim Classlib As New ClassLIB

        If Classlib.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            InsatuNg = InsatuNg + 1
            Exit Sub
        End If

        Dim classSQLite As New ClassSQLite(ClassLIB.gstrdbPath & "\" & ClassLIB.gstrdbFile)


        'シート名をID+氏名に変更
        strNoSheetName = dgr.Cells(1).Value.ToString & "_" & dgr.Cells(2).Value.ToString  'ID+氏名
        strSheetName = dgr.Cells(2).Value.ToString  '氏名


        yubin = dgr.Cells(4).Value.ToString
        addres = dgr.Cells(5).Value.ToString & dgr.Cells(6).Value.ToString & dgr.Cells(7).Value.ToString
        addres = StrConv(addres, VbStrConv.Wide)

        strRank = dgr.Cells(11).Value.ToString

        strPoint = String.Format("{0:#,0}", Integer.Parse(dgr.Cells(10).Value.ToString))

        ' ファイルの存在チェック
        If System.IO.File.Exists(docpath & "\" & strNoSheetName & "様.docx") Then
            MessageBox.Show("【" & docpath & "\" & strNoSheetName & "様.docx】 ファイルが存在します。削除してから実行してください")
            InsatuNg = InsatuNg + 1
            Exit Sub
        End If

        Try

            strSQL = "SELECT KINENHIN FROM T_SOUFU WHERE NID  ='" & dgr.Cells(1).Value.ToString & "' and  KINENHINSENDDAY=''  ORDER BY RANK_NAM DESC"
            dt = classSQLite.SetDataTable(strSQL)
            r = 0

            For Each Rows In dt.Rows
                Select Case r
                    Case 0
                        strKinen1 = Rows("KINENHIN").ToString()
                    Case 1
                        strKinen2 = Rows("KINENHIN").ToString()
                    Case 2
                        strKinen3 = Rows("KINENHIN").ToString()
                End Select
                r = r + 1
            Next
            '--------------------------------------------------

            wdApp = New Word.Application
            wdDocs = wdApp.Documents

            '別名で保存
            wdDoc = wdDocs.Open(wordfile)
            wdDoc.SaveAs2(docpath & "\" & strNoSheetName & "様.docx")

            Dim pos = wdApp.Selection.Start

            wdApp.Selection.End = pos
            wdApp.Selection.Find.Execute(FindText:="[wanen]", ReplaceWith:=wanen)

            wdApp.Selection.End = pos
            wdApp.Selection.Find.Execute(FindText:="[yyyy]", ReplaceWith:=yyyy)

            wdApp.Selection.End = pos
            wdApp.Selection.Find.Execute(FindText:="[tuki]", ReplaceWith:=mon)

            wdApp.Selection.End = pos
            wdApp.Selection.Find.Execute(FindText:="[hi]", ReplaceWith:=day)

            wdApp.Selection.End = pos
            wdApp.Selection.Find.Execute(FindText:="[name]", ReplaceWith:=strSheetName)

            wdApp.Selection.End = pos
            wdApp.Selection.Find.Execute(FindText:="[rank]", ReplaceWith:=strRank)

            wdApp.Selection.End = pos
            wdApp.Selection.Find.Execute(FindText:="[point]", ReplaceWith:=strPoint)

            wdApp.Selection.End = pos
            wdApp.Selection.Find.Execute(FindText:="[kinen1]", ReplaceWith:=strKinen1)
            wdApp.Selection.End = pos
            wdApp.Selection.Find.Execute(FindText:="[kinen2]", ReplaceWith:=strKinen2)
            wdApp.Selection.End = pos
            wdApp.Selection.Find.Execute(FindText:="[kinen3]", ReplaceWith:=strKinen3)


            wdApp.Selection.End = pos
            wdApp.Selection.Find.Execute(FindText:="[yubin]", ReplaceWith:=yubin)

            wdApp.Selection.End = pos
            wdApp.Selection.Find.Execute(FindText:="[addres]", ReplaceWith:=addres)


            wdDoc.Save()
            wdApp.Quit()


            If dgr.Cells(13).Value.ToString = "1" Then                  'ランクアップ
                classRuiseki.SoufuHinAdd(dgr.Cells(1).Value.ToString)     '送付履歴の追加
                classRuiseki.ClearRankUpFlg(dgr.Cells(1).Value.ToString)  'ランクアップのクリア
            End If
            classRuiseki.UpDatetSoufuDay(dgr.Cells(1).Value.ToString)

            InsatuOk = InsatuOk + 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Word Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
