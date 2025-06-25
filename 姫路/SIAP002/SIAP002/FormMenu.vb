Public Class FormMenu
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
    Dim PdfMenuDt As DataTable
    Dim PdfFolder As String

    Private Sub FormMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If

        Me.ToolStripStatusLabel1.Text = classLIB.Get会社情報
        Me.ToolStripStatusLabel1.BackColor = Color.LightGray
        Me.ToolStripStatusLabel2.Text = classLIB.ProductVersion
        Me.ToolStripStatusLabel2.BackColor = Color.LightGray
        Me.DB設定ToolStripMenuItem.Visible = True

        If Kengen = "9" Then
            Me.マスタToolStripMenuItem.Visible = True
            Me.DBバックアップToolStripMenuItem.Visible = True
            Me.過去データ削除ToolStripMenuItem.Visible = True
        Else
            Me.マスタToolStripMenuItem.Visible = False
            Me.過去データ削除ToolStripMenuItem.Visible = False
            Me.DBバックアップToolStripMenuItem.Visible = False
        End If
        GetPdfFolder()
        SetInIDataTabel()

    End Sub
#Region "説明"

    Private Sub GetPdfFolder()
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        strSQL = "SELECT NAIYOU FROM M_SYSTEM WHERE KBN = '70'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            PdfFolder = dt.Rows(0).Item(0).ToString
        End If




    End Sub


    '------------------------------------------------
    '　M_SYSTEM 
    '　KBN　　NAIYOU            BIKOU
    '  80 　　メニュー名　      PDFファイル名
    '  81
    '　8X
    Private Sub SetInIDataTabel()
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)

        PdfMenuDt = Nothing

        strSQL = "SELECT NAIYOU, BIKOU FROM M_SYSTEM WHERE KBN LIKE '8_' ORDER BY KBN"
        PdfMenuDt = classSQLite.SetDataTable(strSQL)
        Me.ツールTToolStripMenuItem.DropDownItems.Clear()

        For Each rows In PdfMenuDt.Rows
            PdfMenuAdd(rows("NAIYOU"))
        Next
        '----------------------

    End Sub

    Private Sub PdfMenuAdd(menuname As String)

        Dim openMenuItem0 As New ToolStripMenuItem()
        openMenuItem0.Text = menuname
        openMenuItem0.ShowShortcutKeys = True
        AddHandler openMenuItem0.Click, AddressOf openMenuItem_Click0
        Me.ツールTToolStripMenuItem.DropDownItems.Add(openMenuItem0)

    End Sub

    Private Sub openMenuItem_Click0(sender As Object, e As EventArgs) 'Handles ツールTToolStripMenuItem.Click
        Dim pdf As String = String.Empty

        For Each rows In PdfMenuDt.Rows
            If rows("NAIYOU") = sender.ToString Then
                pdf = PdfFolder & "\" & rows("BIKOU")
                classLIB.OpenPDF(pdf)
            End If
        Next
    End Sub
#End Region
    Private Sub Log()
        If UserID <> "SYSTEM" Then
            If classLIB.GetRegDbFile() = False Then
                'DBファイルが設定されていないのでここでは設定する
                classLIB.SetDatabaseFile()
            End If

            Dim strSQL As String
            Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
            strSQL = "INSERT INTO T_LOG(ID, USERNAME, LOG, ENTRY_DAY)VALUES('" & UserID & "', '" & UserName & "', 'ログアウト', " & classSQLite.GetTimeSQL & ")"
            If classSQLite.EXEC(strSQL) Then

            End If
        End If

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click

        If Application.OpenForms.Count = 2 Then
            Log()
            Application.Exit()
        Else
            MessageBox.Show("すべての画面を閉じてください")
        End If

    End Sub

    Private Sub パスワード変更ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles パスワード変更ToolStripMenuItem.Click
        If chkForm("FormPassWord") Then
            Exit Sub
        End If

        Dim Fm As New FormPassWord
        Fm.UserID = UserID
        Fm.UserName = UserName
        Fm.Kengen = Kengen
        Fm.ShowDialog()
    End Sub

    Private Sub ButtonCSV_Click(sender As Object, e As EventArgs) Handles ButtonCSV.Click

        If chkForm("FormCSV") Then
            Exit Sub
        End If

        Dim Fm As New FormCSV
        Fm.UserID = UserID
        Fm.UserName = UserName
        Fm.Kengen = Kengen
        Fm.Show()
    End Sub


    Private Sub Button寄附者検索_Click(sender As Object, e As EventArgs) Handles Button寄附者検索.Click
        If chkForm("FormKifuKensaku") Then
            Exit Sub
        End If

        Dim Fm = New FormKifuKensaku
        Fm.UserID = UserID
        Fm.UserName = UserName
        Fm.Kengen = Kengen
        Fm.Show()

    End Sub
    '以下マスタ
    Private Sub CSVふぉまっとToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVふぉまっとToolStripMenuItem.Click
        If chkForm("FormMSTcsv") Then
            Exit Sub
        End If
        Dim Fm As New FormMSTcsv
        Fm.UserID = UserID
        Fm.UserName = UserName
        Fm.Kengen = Kengen
        Fm.ShowDialog()
    End Sub


    Private Sub 名寄せToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 名寄せToolStripMenuItem.Click
        If chkForm("FormMSTnayose") Then
            Exit Sub
        End If
        Dim Fm As New FormMSTnayose
        Fm.UserID = UserID
        Fm.UserName = UserName
        Fm.Kengen = Kengen
        Fm.ShowDialog()

    End Sub

    Private Sub ユーザーToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ユーザーToolStripMenuItem.Click
        If chkForm("FormMSTuser") Then
            Exit Sub
        End If
        Dim Fm As New FormMSTuser
        Fm.UserID = UserID
        Fm.UserName = UserName
        Fm.Kengen = Kengen
        Fm.ShowDialog()

    End Sub

    Private Sub システムToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles システムToolStripMenuItem.Click
        If chkForm("FormMSTsystem") Then
            Exit Sub
        End If
        Dim Fm As New FormMSTsystem
        Fm.UserID = UserID
        Fm.UserName = UserName
        Fm.Kengen = Kengen
        Fm.ShowDialog()

        '初期化
        GetPdfFolder()
        SetInIDataTabel()

    End Sub

    Private Sub ポイントToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ポイントToolStripMenuItem1.Click
        If chkForm("FormMSTpoint") Then
            Exit Sub
        End If
        Dim Fm As New FormMSTpoint
        Fm.UserID = UserID
        Fm.UserName = UserName
        Fm.Kengen = Kengen
        Fm.ShowDialog()

    End Sub

    Private Sub ランクToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ランクToolStripMenuItem.Click
        If chkForm("FormMSTrank") Then
            Exit Sub
        End If
        Dim Fm As New FormMSTrank
        Fm.UserID = UserID
        Fm.UserName = UserName
        Fm.Kengen = Kengen
        Fm.ShowDialog()

    End Sub

    Private Sub 記念品ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 記念品ToolStripMenuItem.Click

        If chkForm("FormMSTkinen") Then
            Exit Sub
        End If
        Dim Fm As New FormMSTkinen
        Fm.UserID = UserID
        Fm.UserName = UserName
        Fm.Kengen = Kengen
        Fm.ShowDialog()

    End Sub

    Private Sub ログ表示ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ログ表示ToolStripMenuItem.Click
        If chkForm("FormLog") Then
            Exit Sub
        End If
        Dim Fm As New FormLog
        Fm.ShowDialog()
    End Sub

    Private Function chkForm(frm As String)
        Dim fm As String
        Dim i As Integer

        Dim message As String = "既に起動しています"
        Dim caption As String = ""
        Dim buttons As MessageBoxButtons = MessageBoxButtons.OK
        Dim icon As MessageBoxIcon = MessageBoxIcon.Exclamation
        Dim defaultBtn As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1

        For i = 0 To Application.OpenForms.Count - 1
            fm = Application.OpenForms.Item(i).Name
            If fm = frm Then
                MessageBox.Show(message, caption, buttons, icon, defaultBtn)
                Return True
            End If
        Next
        Return False

    End Function

    Private Sub DB指定ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DB指定ToolStripMenuItem1.Click
        Dim ret As DialogResult

        ret = MessageBox.Show("DB ファイル 【 " & classLIB.gstrdbPath & "\" & classLIB.gstrdbFile & " 】", "再設定しますか", MessageBoxButtons.YesNo)

        If ret = DialogResult.Yes Then
            If classLIB.SetDatabaseFile() Then

            Else
                MessageBox.Show("ＤＢファイルが設定出来ていません")
            End If
        End If

    End Sub

    Private Sub DBバックアップToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DBバックアップToolStripMenuItem.Click
        If chkForm("FormBackUp") Then
            Exit Sub
        End If

        Dim Fm As New FormBackUp
        Fm.UserID = UserID
        Fm.UserName = UserName
        Fm.Kengen = Kengen
        Fm.ShowDialog()

    End Sub

    Private Sub Button明細検索_Click(sender As Object, e As EventArgs) Handles Button明細検索.Click
        If chkForm("FormMeisaiMain") Then
            Exit Sub
        End If

        Dim Fm As New FormMeisaiMain
        Fm.UserID = UserID
        Fm.UserName = UserName
        Fm.Kengen = Kengen
        Fm.Show()

    End Sub

    Private Sub 過去データ削除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 過去データ削除ToolStripMenuItem.Click
        Dim ClassOldDataDelete As New ClassOldDataDelete(UserName)
        ClassOldDataDelete.OldTRenDelete()
    End Sub
End Class
