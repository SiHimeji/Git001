Imports System.Data
Imports System.Diagnostics
Imports Oracle.ManagedDataAccess.Client

'
' NuGet Package 21 
' Oracle.ManagedDataAccess
'
Public Class ClassOracle


        Public login As Boolean
        Public conStr As String = "user id=CRMKEN;password=MP8TA24M;Pooling=false;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=172.31.37.169)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=GQLDB.WORLD)))"
        Public ErrorMSg As String
        Public cn As OracleConnection = New OracleConnection()
        Public cm As OracleCommand = New OracleCommand()
        Public rs As OracleDataReader


        Public Sub SetDatabe(DB As String)
        End Sub


        Private Function DatabeLogin() As Boolean
            If Not login Then
                cn.ConnectionString = conStr
                Try
                    cn.Open()
                Catch ex As Exception
                    ErrorMSg = ex.Message
                    Return False
                End Try
            End If
            Return True
        End Function


        Private Sub DatabeLogout()
            If login Then
                Try
                    cn.Close()
                    login = False
                Catch ex As Exception
                    ErrorMSg = ex.Message
                End Try

            End If

        End Sub

        Public Function execSQL(ByVal StrSQL As String) As Boolean
            If StrSQL = "" Then
                End
            End If

            Try
                DatabeLogin()
                cm = cn.CreateCommand
                Try
                    cm.CommandText = StrSQL
                    cm.ExecuteNonQuery()
                    execSQL = True

                Catch ex2 As Exception
                    ErrorMSg = ex2.Message
                    execSQL = False
                Finally
                    cm.Dispose()
                End Try
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                execSQL = False
            End Try
            DatabeLogout()

        End Function
        Public Function execSQL(ByVal StrSQL() As String) As Boolean

            If StrSQL.Length = 0 Then
                End
            End If

            Try
                DatabeLogin()
                cm = cn.CreateCommand
                Try
                    For Each iSQL In StrSQL
                        If iSQL <> "" Then
                            cm.CommandText = iSQL
                            cm.ExecuteNonQuery()
                        End If
                    Next
                    execSQL = True
                Catch ex2 As Exception
                    ErrorMSg = ex2.Message
                    execSQL = False
                Finally
                    cm.Dispose()
                End Try
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                execSQL = False
            End Try
            DatabeLogout()

        End Function

        Public Function SetDataGredv(ByVal StrSQL As String, ByVal Dgv As DataGridView) As Boolean
            Dim idx As Integer

            If StrSQL = "" Then
                Return (False)
            End If
            Try
                If DatabeLogin() = False Then
                    SetDataGredv = False
                    Exit Function
                End If
                'SQLコマンド設定
                cm = cn.CreateCommand
                Dgv.Rows.Clear()
                idx = 0
                ' Dgv.Rows.Add()
                Try
                    '検索
                    cm.CommandText = StrSQL
                    rs = cm.ExecuteReader()
                    While rs.Read() = True

                        Dgv.Rows.Add()

                        For index As Integer = 0 To rs.FieldCount - 1
                            Dgv.Rows(idx).Cells(index).Value = rs(index).ToString
                        Next
                        idx = idx + 1

                    End While

                    SetDataGredv = True
                    DatabeLogout()

                Catch ex2 As Exception
                    ErrorMSg = ex2.Message
                    SetDataGredv = False

                Finally
                    '破棄
                    cm.Dispose()

                End Try
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                SetDataGredv = False
            End Try

            SetDataGredv = False
            DatabeLogout()

        End Function

        Public Function SetDataTable(ByVal strSql As String) As DataTable
            Dim dt As DataTable = New DataTable()
            'If DatabeLogin() = False Then
            'SetDataTable = Nothing
            'Exit Function
            'End If

            Try
                cn.ConnectionString = conStr
                cn.Open()
                Dim cmd As OracleCommand = New OracleCommand(strSql, cn)
                Dim da As OracleDataAdapter = New OracleDataAdapter(cmd)
                da.Fill(dt)

            Catch ex As Exception
                ErrorMSg = ex.Message
            End Try
            'DatabeLogout()
            cn.Close()

            Return dt
        End Function

    End Class
