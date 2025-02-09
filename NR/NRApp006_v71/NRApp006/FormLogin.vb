Public Class FormLogin
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim New_Var As String
    Dim dlver As String
    Dim exever As String

    Private Sub Buttonキャンセル_Click(sender As Object, e As EventArgs) Handles Buttonキャンセル.Click
        Application.Exit()
    End Sub

    Private Sub Buttonログイン_Click(sender As Object, e As EventArgs) Handles Buttonログイン.Click
        Entry()
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ApUpdate As ClassTransV4 = New ClassTransV4()
        GetAsm()

        Me.Text = menu_bar & " ログイン Version " & vAsm.Version & ""
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        '------------------自動バージョンUp------
        New_Var = GetDbVer()
        If New_Var <> Now_Ver Then
            '----------- V3-----------------
            ApUpdate.TransExecV3(vAsm.v製品)
        End If

    End Sub


    Private Sub Entry()
        Dim strSQL As String
        Dim dt As New DataTable

        strSQL = "Select u_name, ms.seq FROM " & schema & "m_user mu , " & schema & "m_system ms"
        strSQL &= " where UPPER(u_id) = '" & Me.TextBoxログイン.Text.ToUpper.Trim & "'"
        strSQL &= " And UPPER(u_pass) = '" & Me.TextBoxパスワード.Text.ToUpper.Trim & "'"
        strSQL &= " And MS.kbn ='1'"
        strSQL &= " And MS.naiyou = mu.u_kengen"

        dt = ClassPostgeDB.SetTable(strSQL)

        If dt.Rows.Count = 1 Then

            For Each row As DataRow In dt.Rows
                FormMain.UserName = row("u_name").ToString
                FormMain.Kengen = row("seq").ToString
            Next

            FormMain.UserID = Me.TextBoxログイン.Text.ToUpper.Trim

            If Logent(FormMain.UserID, FormMain.UserName, "1") Then
                FormMain.Show()
                Me.Hide()
            End If

        Else
            MessageBox.Show("ID、パスワードが間違っているか、もしくは存在しません")
        End If

    End Sub

    Private Sub TextBoxログイン_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxログイン.KeyDown

        '管理者権限
        If e.Alt And e.KeyCode = Keys.F11 Then
            FormMain.Kengen = "0"
            FormMain.UserID = "SYSTEM"
            FormMain.UserName = "SYSTEM"

            If Logent(FormMain.UserID, FormMain.UserName, "1") Then
                FormMain.Show()
                Me.Hide()
            End If
        End If
        '一般権限
        If e.Alt And e.KeyCode = Keys.F12 Then
            FormMain.Kengen = "1"
            FormMain.UserID = "SYSTEM1"
            FormMain.UserName = "SYSTEM1"

            If Logent(FormMain.UserID, FormMain.UserName, "1") Then
                FormMain.Show()
                Me.Hide()
            End If
        End If

        'ENTERでの処理
        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean
            'Me.TextBoxパスワード.
            forward = e.Modifiers <> Keys.Shift
            ' タブオーダー順で次のコントロールにフォーカスを移動
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
        End If


    End Sub

    Private Sub LabelVer_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBoxパスワード_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxパスワード.KeyDown

        If e.KeyCode = Keys.Enter Then
            Entry()
        End If
        If e.Alt And e.KeyCode = Keys.F1 Then

        End If

    End Sub
End Class