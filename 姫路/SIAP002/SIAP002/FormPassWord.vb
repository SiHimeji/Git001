Public Class FormPassWord
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
    Private Sub FormPassWord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If
        Me.IDToolStripMenuItem.Text = "ID 【 " & UserID & " 】"

    End Sub
    Private Sub Button確定_Click(sender As Object, e As EventArgs) Handles Button確定.Click

        Dim strSQL As String
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable

        strSQL = "SELECT USERID, USERPASS FROM M_USER WHERE USERID = '" & UserID & "' AND upper(USERPASS) = upper('" & Me.TextBox現パスワード.Text & "') "
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count <> 1 Then
            MessageBox.Show("現パスワードが違います")
            Exit Sub
        End If

        'If Me.TextBox新パスワード.Text. <> Me.TextBox新パスワード再.Text Then
        If Me.TextBox新パスワード.Text.ToUpper.Trim <> Me.TextBox新パスワード再.Text.ToUpper.Trim Then
            MessageBox.Show("新パスワードと新パスワード(再)が違います")
            Exit Sub
        End If

        If Me.TextBox現パスワード.Text.ToUpper.Trim = Me.TextBox新パスワード.Text.ToUpper.Trim Then
            MessageBox.Show("現パスワードと新パスワードが同じになっています")
            Exit Sub
        End If

        If Me.TextBox新パスワード.Text.Trim = "" Or Me.TextBox新パスワード再.Text.Trim = "" Then
            MessageBox.Show("新パスワードまたは新パスワード(再)が入力されていません")
            Exit Sub
        End If

        strSQL = ""
        strSQL &= "UPDATE M_USER"
        'strSQL &= " SET USERPASS='" & Me.TextBox新パスワード.Text & "'"
        strSQL &= " SET USERPASS=upper('" & Me.TextBox新パスワード.Text.Trim & "')"
        strSQL &= " WHERE USERID='" & UserID & "'"

        If classSQLite.EXEC(strSQL) Then
            MessageBox.Show("パスワードを更新しました")
            Me.Close()
        End If

    End Sub

End Class