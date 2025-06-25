Public Class FormMSTuser
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
    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FormMSTuser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Me.ToolStripStatusLabel1.Text = classLIB.Get会社情報
        Me.ToolStripStatusLabel1.BackColor = Color.LightGray

        Disp()

    End Sub
    Private Sub Disp()
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim ro As Integer = 0


        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        strSQL = "SELECT USERID, USERNAME, USERPASS, CASE  WHEN KENGEN='9' THEN '管理者' ELSE '' END 'KENGEN'  FROM M_USER"
        dt = classSQLite.SetDataTable(strSQL)

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "USERID", "ユーザーID", 120, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "USERNAME", "ユーザー名", 120, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "USERPASS", "パスワード", 120, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "KENGEN", "権限", 100, True)

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim ro As Integer
        ro = e.RowIndex
        If ro < 0 Then
            Return
        End If
        If e.Button = MouseButtons.Left Then
            Me.TextBoxユーザーID.Text = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
            Me.TextBoxユーザー名.Text = Me.DataGridView1.Rows(ro).Cells(1).Value.ToString
            Me.TextBoxパスワード.Text = Me.DataGridView1.Rows(ro).Cells(2).Value.ToString
            If Me.DataGridView1.Rows(ro).Cells(3).Value = "管理者" Then
                Me.CheckBox管理者.Checked = True
            Else
                Me.CheckBox管理者.Checked = False
            End If
        End If
    End Sub

    Private Sub Clear()

        Me.TextBoxユーザーID.Text = ""
        Me.TextBoxユーザー名.Text = ""
        Me.TextBoxパスワード.Text = ""
        Me.CheckBox管理者.Checked = False

    End Sub


    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        Dim dt As DataTable
        Dim msg As String = String.Empty


        If Me.TextBoxユーザーID.Text.Trim = "" Then
            msg = "ユーザーIDを入力してください"
        End If

        If Me.TextBoxユーザー名.Text.Trim = "" Then
            If msg = "" Then
                msg = "ユーザー名を入力してください"
            Else
                msg &= vbCrLf & "ユーザー名を入力してください"
            End If
        End If

        If Me.TextBoxパスワード.Text.Trim = "" Then
            If msg = "" Then
                msg = "パスワードを入力してください"
            Else
                msg &= vbCrLf & "パスワードを入力してください"
            End If
        End If

        If msg <> "" Then
            MessageBox.Show(msg)
            Exit Sub
        End If


        strSQL = "SELECT USERID FROM M_USER WHERE upper(USERID) =upper('" & Me.TextBoxユーザーID.Text.Trim & "')"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then

            strSQL = ""
            strSQL &= "UPDATE M_USER"
            strSQL &= " SET USERNAME='" & Me.TextBoxユーザー名.Text.Trim & "'"
            'strSQL &= ", USERPASS='" & Me.TextBoxパスワード.Text.Trim & "'"
            strSQL &= ", USERPASS=upper('" & Me.TextBoxパスワード.Text.Trim & "')"

            If Me.CheckBox管理者.Checked = True Then
                strSQL &= ",KENGEN='9'"
            Else
                strSQL &= ",KENGEN='0'"
            End If
            strSQL &= ", UPDATE_DAY = " & classSQLite.GetTimeSQL & ""
            strSQL &= ", UPDATE_NAM = '" & UserID & "'"
            strSQL &= " WHERE upper(USERID)=upper('" & Me.TextBoxユーザーID.Text.Trim & "')"

        Else

            strSQL = ""
            strSQL &= "INSERT INTO M_USER"
            strSQL &= "(USERID, USERNAME, USERPASS, KENGEN, ENTRY_DAY, ENTRY_NAM, UPDATE_DAY, UPDATE_NAM)VALUES("
            strSQL &= "upper('" & Me.TextBoxユーザーID.Text.Trim & "')"
            strSQL &= ",'" & Me.TextBoxユーザー名.Text.Trim & "'"
            strSQL &= ",upper('" & Me.TextBoxパスワード.Text.Trim & "')"
            If Me.CheckBox管理者.Checked = True Then
                strSQL &= ",'9'"
            Else
                strSQL &= ",'0'"
            End If
            strSQL &= "," & classSQLite.GetTimeSQL & ""
                strSQL &= ",'" & UserID & "'"
                strSQL &= "," & classSQLite.GetTimeSQL & ""
                strSQL &= ",'" & UserID & "'"
                strSQL &= ")"
            End If

            If classSQLite.EXEC(strSQL) Then
            Clear()
        End If

        Disp()

    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        Dim dt As DataTable

        strSQL = "SELECT USERID FROM M_USER WHERE upper(USERID) =upper('" & Me.TextBoxユーザーID.Text.Trim & "')"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then

            strSQL = ""
            strSQL &= "DELETE FROM M_USER"
            strSQL &= " WHERE upper(USERID) = upper('" & Me.TextBoxユーザーID.Text.Trim & "')"
            If classSQLite.EXEC(strSQL) Then
                Clear()
                Disp()
            End If

        End If

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        Dim classExcel As New ClassExcel
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            classExcel.excelOutDataGred03(Me.DataGridView1, 0)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If

    End Sub

    Private Sub Buttonクリア_Click(sender As Object, e As EventArgs) Handles Buttonクリア.Click
        Clear()
    End Sub
End Class