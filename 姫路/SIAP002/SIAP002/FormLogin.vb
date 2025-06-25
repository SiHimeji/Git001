Public Class FormLogin
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

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim classLIB As New ClassLIB
        Me.Text = "Version " & classLIB.ProductVersion
        If ClassLIB.GetRegDbFile() = False Then
            'DBファイルが設定されていないのでここでは設定する
            ClassLIB.SetDatabaseFile()
        End If

        Dim strSQL As String
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable

        strSQL = "SELECT NAIYOU  FROM M_SYSTEM WHERE KBN = '50'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Try

                Dim fileName As String = dt.Rows(0).Item(0).ToString()
                If System.IO.File.Exists(fileName) Then
                    Me.BackgroundImage = System.Drawing.Image.FromFile(fileName)
                Else

                End If

            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub Button実行_Click(sender As Object, e As EventArgs) Handles Button実行.Click
        Logon()
    End Sub

    Private Sub Buttonキャンセル_Click(sender As Object, e As EventArgs) Handles Buttonキャンセル.Click
        Me.Close()
    End Sub

    Private Sub TextBoxユーザーID_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxユーザーID.KeyDown
        If e.Alt And e.KeyCode = Keys.F11 Then
            FormMenu.Kengen = "9"
            FormMenu.UserID = "SYSTEM"
            FormMenu.UserName = "SYSTEM"
            FormMenu.Show()
            Me.Hide()
        End If
        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean
            'Me.TextBoxパスワード.
            forward = e.Modifiers <> Keys.Shift
            ' タブオーダー順で次のコントロールにフォーカスを移動
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
        End If
    End Sub

    Private Sub TextBoxパスワード_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxパスワード.KeyDown
        If e.KeyCode = Keys.Enter Then
            Logon()
        End If
    End Sub

    Private Sub Button実行_KeyDown(sender As Object, e As KeyEventArgs) Handles Button実行.KeyDown
        Logon()
    End Sub
    Private Sub Logon()
        Dim classLIB As New ClassLIB
        If classLIB.GetRegDbFile() = False Then
            'DBファイルが設定されていないのでここでは設定する
            classLIB.SetDatabaseFile()
        End If

        Dim strSQL As String
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable

        strSQL = "Select USERID, USERNAME, KENGEN FROM M_USER WHERE upper(USERID) =upper('" & Me.TextBoxユーザーID.Text & "') AND upper(USERPASS) = upper('" & Me.TextBoxパスワード.Text & "') "
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count <> 1 Then
            MessageBox.Show("ユーザーＩＤ又はパスワードが違います")
            Exit Sub
        End If

        UserID = dt.Rows(0).Item(0).ToString()
        UserName = dt.Rows(0).Item(1).ToString()
        Kengen = dt.Rows(0).Item(2).ToString()

        Dim fm As New FormMenu

        fm.UserID = UserID 'dt.Rows(0).Item(0).ToString()
        fm.UserName = UserName 'dt.Rows(0).Item(1).ToString()
        fm.Kengen = Kengen 'dt.Rows(0).Item(2).ToString()

        Log()

        fm.Show()
        Me.Hide()

    End Sub

    Private Sub Log()
        Dim classLIB As New ClassLIB
        If classLIB.GetRegDbFile() = False Then
            'DBファイルが設定されていないのでここでは設定する
            classLIB.SetDatabaseFile()
        End If

        Dim strSQL As String
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        strSQL = "INSERT INTO T_LOG(ID, USERNAME, LOG, ENTRY_DAY)VALUES('" & UserID & "', '" & UserName & "', 'ログイン', " & classSQLite.GetTimeSQL & ")"
        If classSQLite.EXEC(strSQL) Then

        End If

    End Sub

End Class