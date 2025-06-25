
Public Class ClassSQLite
    Dim cn As SQLite.SQLiteConnection = New SQLite.SQLiteConnection
    Dim cm As SQLite.SQLiteCommand = New SQLite.SQLiteCommand
    Dim tr As SQLite.SQLiteTransaction = Nothing
    Dim dr As SQLite.SQLiteDataReader = Nothing
    Public ErrorMSg As String = String.Empty

    Dim conectstring As String = String.Empty

    Public Sub New(fileName As String)
        SetDatabase(fileName)
    End Sub

    Public Sub SetDatabase(fileName As String)
        '// 2022/04/28 \\→\\\\に追加 LANDISK対応
        If fileName.Substring(0, 2) = "\\" Then
            fileName = "\\" & fileName
        End If
        cn.ConnectionString = "Data Source=" & fileName
    End Sub

    Public Sub DbOpen()
        Try
            cn.Open()
        Catch ex As Exception
            ErrorMSg = ex.Message
        End Try
    End Sub

    Public Sub DbClose()
        cn.Close()
    End Sub
    '//
    '------------------------------------------------------------------------------------
    'トランザクション処理
    '------------------------------------------------------------------------------------
    Public Sub BeginTrans()
        tr = cn.BeginTransaction
    End Sub

    Public Sub Commit()
        If tr IsNot Nothing Then
            tr.Commit()
        End If
        tr = Nothing
    End Sub

    Public Sub Rollback()
        If tr IsNot Nothing Then
            tr.Rollback()
        End If
        tr = Nothing
    End Sub

    'トランザクション用(例外は呼び出し先で処理する)
    Public Sub EXEC_tr(ByVal StrSQL As String)
        ErrorMSg = String.Empty
        Dim cm As SQLite.SQLiteCommand
        Try
            cm = cn.CreateCommand
            cm.CommandText = StrSQL
            cm.ExecuteNonQuery()
        Finally

        End Try
        cm.Dispose()
    End Sub

    '////
    Public Function SetDataTable(strSQL As String) As DataTable
        ErrorMSg = String.Empty
        Dim dt As DataTable = New DataTable()
        Try
            cn.Open()
            Dim cm As SQLite.SQLiteCommand = New SQLite.SQLiteCommand(strSQL, cn)
            Dim da As SQLite.SQLiteDataAdapter = New SQLite.SQLiteDataAdapter(cm)
            da.Fill(dt)

        Catch ex As Exception
            ErrorMSg = ex.Message

        End Try
        cm.Dispose()
        cn.Close()

        Return dt
    End Function

    Public Function EXEC(strSQL As String) As Boolean
        ErrorMSg = String.Empty

        EXEC = True
        Try
            cn.Open()
            'cm.Connection = cn
            Dim cm As SQLite.SQLiteCommand = New SQLite.SQLiteCommand(strSQL, cn)
            'cm.CommandText = strSQL
            cm.ExecuteNonQuery()
        Catch ex As Exception
            ErrorMSg = ex.Message
            EXEC = False
            Throw ex
        End Try
        cn.Close()

    End Function

    Public Function GetFieldCount(strSQL As String) As Integer
        ErrorMSg = String.Empty
        Try
            cn.Open()
            cm.Connection = cn
            cm.CommandText = strSQL
            dr = cm.ExecuteReader()

            Return dr.FieldCount
        Catch ex As Exception
            ErrorMSg = ex.Message
            Return -1
        Finally
            If dr IsNot Nothing Then
                dr.Close()
            End If
        End Try
        cn.Close()
    End Function


    Public Function GetOneRecode(strSQL As String) As String
        ErrorMSg = String.Empty
        Try
            cn.Open()
            cm.Connection = cn
            cm.CommandText = strSQL
            dr = cm.ExecuteReader()
            dr.Read()

            GetOneRecode = dr(0).ToString()

        Catch ex As Exception
            ErrorMSg = ex.Message
            Return ""
        Finally
            dr.Close()
        End Try
        cn.Close()

    End Function

    Public Function GetTimeSQL()
        GetTimeSQL = "strftime('%Y/%m/%d %H:%M:%S', CURRENT_TIMESTAMP, 'localtime')"
    End Function

    Public Function GetDateSQL()
        GetDateSQL = "strftime('%Y/%m/%d', CURRENT_TIMESTAMP, 'localtime')"
    End Function



    Public Sub VACUUM()
        ErrorMSg = String.Empty
        Try
            cn.Open()
            cm.Connection = cn
            cm.CommandText = "VACUUM"
            cm.ExecuteNonQuery()
        Catch ex As Exception
            ErrorMSg = ex.Message
            Throw ex
        End Try
        cn.Close()
    End Sub

End Class
