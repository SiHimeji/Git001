Public Class FormMSTsystem
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
    Dim classLIB As New ClassLIB

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click

        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        Dim dt As DataTable

        Dim msg As String = String.Empty

        If Me.TextBox区分.Text.Trim = "" Then
            msg = "区分を入力してください"
        End If

        '--- 23.12.28 k.s --- 
        'TextBox内容.Text MaxLength 60→300に変更 
        If Me.TextBox内容.Text.Trim = "" Then
            If msg = "" Then
                msg = "内容を入力してください"
            Else
                msg &= vbCrLf & "内容を入力してください"
            End If
        End If
        If Me.TextBox備考.Text.Trim = "" Then
            If msg = "" Then
                msg = "備考を入力してください"
            Else
                msg &= vbCrLf & "備考を入力してください"
            End If
        End If

        If msg <> "" Then
            MessageBox.Show(msg)
            Exit Sub
        End If

        strSQL = "SELECT KBN, NAIYOU, BIKOU  FROM M_SYSTEM WHERE  KBN ='" & Me.TextBox区分.Text.Trim & "'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then
            strSQL = ""
            strSQL &= "UPDATE M_SYSTEM"
            strSQL &= " SET  NAIYOU ='" & Me.TextBox内容.Text & "'"
            strSQL &= ", BIKOU = '" & Me.TextBox備考.Text & "'"
            strSQL &= ", UPDATE_DAY = " & classSQLite.GetTimeSQL & ""
            strSQL &= ", UPDATE_NAM = '" & UserID & "'"
            strSQL &= " WHERE KBN ='" & Me.TextBox区分.Text & "'"

        Else
            strSQL = ""
            strSQL &= "INSERT INTO M_SYSTEM"
            strSQL &= "( KBN, NAIYOU, BIKOU, ENTRY_DAY, ENTRY_NAM, UPDATE_DAY, UPDATE_NAM) VALUES("
            strSQL &= "" & Me.TextBox区分.Text & ""
            strSQL &= ",'" & Me.TextBox内容.Text.Trim & "'"
            strSQL &= ",'" & Me.TextBox備考.Text.Trim & "'"
            strSQL &= "," & classSQLite.GetTimeSQL & ""
            strSQL &= ",'" & UserID & "'"
            strSQL &= "," & classSQLite.GetTimeSQL & ""
            strSQL &= ",'" & UserID & "'"
            strSQL &= ")"
        End If
        If classSQLite.EXEC(strSQL) Then
            Clear()
        End If

        disp()

    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        Dim dt As DataTable

        strSQL = "SELECT KBN, NAIYOU, BIKOU  FROM M_SYSTEM WHERE  KBN ='" & Me.TextBox区分.Text.Trim & "'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then

            strSQL = ""
            strSQL &= "DELETE FROM M_SYSTEM"
            strSQL &= " WHERE KBN ='" & Me.TextBox区分.Text.Trim & "'"
            If classSQLite.EXEC(strSQL) Then
                Clear()
                disp()
            End If
        End If

    End Sub

    Private Sub FormMSTsystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ClassLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If

        Me.ToolStripStatusLabel1.Text = classLIB.Get会社情報
        Me.ToolStripStatusLabel1.BackColor = Color.LightGray

        Clear()
        disp()

    End Sub
    Private Sub disp()

        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim ro As Integer = 0


        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        strSQL = "SELECT KBN, NAIYOU, BIKOU  FROM M_SYSTEM ORDER BY KBN"
        dt = classSQLite.SetDataTable(strSQL)


        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "KBN", "区分", 80, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "NAIYOU", "内容", 400, True)
        ro = classLIB.SettextColumn(Me.DataGridView1, ro, "BIKOU", "備考", 500, True)

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)
    End Sub
    Private Sub Clear()

        Me.TextBox区分.Text = ""
        Me.TextBox内容.Text = ""
        Me.TextBox備考.Text = ""

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

        Dim ro As Integer
        ro = e.RowIndex
        If ro < 0 Then
            Return
        End If
        If e.Button = MouseButtons.Left Then

            Me.TextBox区分.Text = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
            Me.TextBox内容.Text = Me.DataGridView1.Rows(ro).Cells(1).Value.ToString
            Me.TextBox備考.Text = Me.DataGridView1.Rows(ro).Cells(2).Value.ToString

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

    Private Sub Buttonフォルダー_Click(sender As Object, e As EventArgs) Handles Buttonフォルダー.Click
        If Me.TextBox区分.Text = "50" Then


            Dim ofd As New OpenFileDialog()

            'はじめのファイル名を指定する
            'はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = ""
            'はじめに表示されるフォルダを指定する
            '指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = ""
            '[ファイルの種類]に表示される選択肢を指定する
            '指定しないとすべてのファイルが表示される
            ofd.Filter = "HTMLファイル(*.jpgl;*.jpg)|*.jpg;*.jpg|すべてのファイル(*.*)|*.*"
            '[ファイルの種類]ではじめに選択されるものを指定する
            '2番目の「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 2
            'タイトルを設定する
            ofd.Title = "画像ファイルを選択してください"
            ofd.RestoreDirectory = True
            ofd.CheckFileExists = True
            ofd.CheckPathExists = True

            'ダイアログを表示する
            If ofd.ShowDialog() = DialogResult.OK Then
                'OKボタンがクリックされたとき、選択されたファイル名を表示する
                Me.TextBox内容.Text = ofd.FileName
            End If
        Else
            Dim fbd As New FolderBrowserDialog
            fbd.Description = "フォルダを指定してください。"
            fbd.RootFolder = Environment.SpecialFolder.Desktop
            fbd.SelectedPath = ""
            fbd.ShowNewFolderButton = True
            If fbd.ShowDialog(Me) = DialogResult.OK Then
                '選択されたフォルダを表示する
                Me.TextBox内容.Text = fbd.SelectedPath
            Else
                'Me.TextBox内容.Text = ""
            End If

        End If

    End Sub

    Private Sub Buttonクリア_Click(sender As Object, e As EventArgs) Handles Buttonクリア.Click
        Clear()
    End Sub


End Class