Public Class ClassOldDataDelete
    Dim classLIB As New ClassLIB
    Dim UserName As String
    Sub New(iUserName As String)
        UserName = iUserName
    End Sub
    Public Function OldTRenDelete() As Boolean
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Return False
        End If
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim strSQL As String
        Dim nen As Integer
        Dim ken As Integer = 0

        Dim ToDay As DateTime = DateTime.Now

        dt = classSQLite.SetDataTable("SELECT NAIYOU FROM M_SYSTEM WHERE KBN='90'")
        If dt.Rows.Count = 1 Then

            If IsNumeric(dt.Rows(0).Item(0).ToString) = False Then
                MessageBox.Show("システムマスタ【90】に削除年数を設定してください")
                Return False
            End If

            'nen = Integer.Parse(dt.Rows(0).Item(0).ToString)
            nen = Integer.Parse(StrConv(dt.Rows(0).Item(0).ToString, VbStrConv.Narrow))

            Dim result As DialogResult = MessageBox.Show(nen.ToString & "年間、寄附が無い顧客データを削除します" & vbCr & "削除前にバックアップを取ってください" & vbCr & "【削除する場合->YES】",
                                             "確認",
                                             MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Return False
            End If
        Else
            MessageBox.Show("システムマスタ【90】に削除年を設定してください")
            Return False
        End If

        strSQL = "SELECT NID,FULLNAM ,ADMIN  FROM T_RUISEKI WHERE UPDATE_DAY < '" & ToDay.AddYears(-nen) & "'"
        dt = classSQLite.SetDataTable(strSQL)
        Try
            classSQLite.DbOpen()
            classSQLite.BeginTrans()

            For Each row In dt.Rows

                strSQL = "INSERT INTO T_LOG(ID, USERNAME, LOG, ENTRY_DAY)VALUES('過去データ削除','" & UserName & "','ID=" & row("NID").ToString & ":Name=" & row("FULLNAM").ToString & ":県=" & row("ADMIN").ToString & "'," & classSQLite.GetTimeSQL & ")"
                classSQLite.EXEC_tr(strSQL)

                strSQL = "DELETE FROM T_SOUFU WHERE NID='" & row("NID").ToString & "' "
                classSQLite.EXEC_tr(strSQL)

                strSQL = "DELETE FROM T_MEISAI WHERE NID='" & row("NID").ToString & "' "
                classSQLite.EXEC_tr(strSQL)

                strSQL = "DELETE FROM T_RUISEKI WHERE NID='" & row("NID").ToString & "' "
                classSQLite.EXEC_tr(strSQL)
                ken = ken + 1

            Next
            classSQLite.Commit()
        Catch ex As Exception
            classSQLite.Rollback()
            classSQLite.DbClose()
            MessageBox.Show("削除で【" & ex.Message & "】のエラーです")
            Return False
        End Try
        classSQLite.DbClose()

        MessageBox.Show("【" & ken.ToString & "】件削除しました")
        Return True

    End Function

End Class
