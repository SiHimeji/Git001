Imports System.IO.Compression
Imports System.Net
Imports System.IO
Imports System
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions


Public Class ClassLIB
    Declare Function GetDesktopWindow Lib "user32" () As Integer
    Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" _
    (ByVal hWnd As Integer, ByVal lpOperation As String, ByVal lpFile As String,
    ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer


    Public Const gcstrRegKeyDb As String = "Software\himeji\dbfile"  'DBのレジストリキー
    Public gstrdbPath As String                'DBのパス
    Public gstrdbFile As String                'DBのファイル名
    Public gblndbOKflg As Boolean              'DB設定済フラグ

    Public Function GetFordir(txtFolder As String) As String
        Dim fbd As New FolderBrowserDialog
        'fbd. = FormStartPosition.CenterScreen
        fbd.Description = "フォルダを指定してください。"
        fbd.RootFolder = Environment.SpecialFolder.Desktop
        fbd.SelectedPath = txtFolder
        fbd.ShowNewFolderButton = True
        If fbd.ShowDialog() = DialogResult.OK Then
            '選択されたフォルダを表示する
            Return (fbd.SelectedPath.ToString())
        Else
            Return ("")
        End If
    End Function
    '//////////////////  DataGridView 使用方法  ///////
    '  
    '   Me.DataGridView1.RowHeadersVisible = False
    '   Me.DataGridView1.AutoGenerateColumns = False
    '   Me.DataGridView1.DataSource = dt
    '                               DataGridView , 行(連番) , DB名 , ﾍｯﾀﾞｰ名 , 幅 , ReadOnly
    ' ro = clasLIB.SettextButton(Me.DataGridView1, ro, "", "詳細", 60, False)
    '
    '
    '　　Me.DataGridView1.AllowUserToAddRows = False
    '//////////////////////////////////////////
    Public Function SettextColumn(dgv As DataGridView, ro As Integer, DataPropertyName As String, HeaderText As String, wid As Integer, rdonry As Boolean, midol As DataGridViewContentAlignment) As Integer
        Dim textColumn As New DataGridViewTextBoxColumn()
        textColumn.DataPropertyName = DataPropertyName
        textColumn.Name = "Column" & ro.ToString
        textColumn.HeaderText = HeaderText
        dgv.Columns.Add(textColumn)
        dgv.Columns(ro).DefaultCellStyle.Alignment = midol '

        dgv.Columns(ro).Width = wid
        dgv.Columns(ro).ReadOnly = rdonry
        If wid = 0 Then
            dgv.Columns(ro).Visible = False
        End If

        ro = ro + 1
        Return ro
    End Function
    Public Function SettextColumn(dgv As DataGridView, ro As Integer, DataPropertyName As String, HeaderText As String, wid As Integer, rdonry As Boolean) As Integer
        Dim textColumn As New DataGridViewTextBoxColumn()
        textColumn.DataPropertyName = DataPropertyName
        textColumn.Name = "Column" & ro.ToString
        textColumn.HeaderText = HeaderText
        dgv.Columns.Add(textColumn)
        dgv.Columns(ro).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        dgv.Columns(ro).Width = wid
        dgv.Columns(ro).ReadOnly = rdonry
        If wid = 0 Then
            dgv.Columns(ro).Visible = False
        End If

        ro = ro + 1
        Return ro
    End Function

    Public Function SettextButton(dgv As DataGridView, ro As Integer, DataPropertyName As String, HeaderText As String, wid As Integer, rdonry As Boolean) As Integer
        Dim textColumn As New DataGridViewButtonColumn
        textColumn.DataPropertyName = DataPropertyName
        textColumn.Name = "Button" & ro.ToString
        textColumn.HeaderText = ""
        textColumn.UseColumnTextForButtonValue = True
        textColumn.FlatStyle = FlatStyle.Popup

        textColumn.Text = HeaderText

        dgv.Columns.Add(textColumn)
        dgv.Columns(ro).Width = wid
        dgv.Columns(ro).ReadOnly = rdonry
        ro = ro + 1
        Return ro
    End Function
    Public Function SettextChkBox(dgv As DataGridView, ro As Integer, DataPropertyName As String, HeaderText As String, wid As Integer, rdonry As Boolean) As Integer
        Dim textColumn As New DataGridViewCheckBoxColumn
        textColumn.DataPropertyName = DataPropertyName
        textColumn.Name = "Button" & ro.ToString
        textColumn.HeaderText = ""
        'textColumn. = True
        textColumn.FlatStyle = FlatStyle.Popup

        textColumn.HeaderText = HeaderText

        dgv.Columns.Add(textColumn)
        dgv.Columns(ro).Width = wid
        dgv.Columns(ro).ReadOnly = rdonry
        ro = ro + 1
        Return ro
    End Function

    Public Function GetDataGridViewValue(dgv As DataGridView, rol As Integer, col As Integer) As String
        Try
            If dgv.Rows(rol).Cells(col).Value Is Nothing Then
                Return ""
            Else
                Return dgv.Rows(rol).Cells(col).Value.ToString
            End If
        Catch ex As Exception
            Return ""

        End Try
    End Function



    '/// <summary>
    '/// 文字列が英数字かどうかを判定します
    '/// </summary>
    '/// <remarks>大文字・小文字を区別しません</remarks>
    '/// <param name="target">対象の文字列</param>
    '/// <returns>文字列が英数字の場合はtrue、それ以外はfalse</returns>
    Public Function IsAlphanumeric(target As String)
        Return New Regex("^[0-9a-zA-Z]+$").IsMatch(target)
    End Function

    Public Function Kakutyousi(filename As String) As String
        Dim ext As String = System.IO.Path.GetExtension(filename).Replace(".", "")
        Return ext
    End Function

    Public Function ChkFIle(filePath As String) As Boolean
        If File.Exists(filePath) Then
            Return True  '存在
        Else
            Return False
        End If
    End Function
    Public Function ChkDirectory(dirpath As String)
        If System.IO.Directory.Exists(dirpath) Then
            Return True  '存在
        Else
            Return False
        End If
    End Function

    Public Sub SetCombox(cmb As ComboBox, txt As String)
        Dim i As Integer = 1
        For i = 0 To cmb.Items.Count - 1
            cmb.SelectedIndex = i
            If cmb.Text.Trim = txt.Trim Then
                Return
            End If
        Next
    End Sub
    '---------------------　PDF関連  ---------------------
    Public Sub OpenPDF(FileName As String)
        Try
            Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(FileName)
        Catch ex As Exception
            Dim Msg As String
            Msg = "pdfファイルに関連づけられたアプリケーションが見つかりません"
            MsgBox(Msg, vbOKOnly + vbExclamation)
        End Try
    End Sub
    '---------------------　データベース関連  ---------------------
    '
    '
    '
    Public Function ChkDatabaseFile() As Boolean


        If GetRegDbFile() = False Then
            If SetDatabaseFile() = False Then
                MessageBox.Show("データベースファイルの設定が出来ませんでした")
                Return False
            Else
                If GetRegDbFile() = False Then
                    MessageBox.Show("データベースファイルの設定・環境を確認して下さい")
                    Return False
                End If
            End If
        End If
        Return True
    End Function


    Public Function SetDatabaseFile()

        Dim strMdbPathFile As String
        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()

        '1.レジストリの存在確認
        Dim regkey As Microsoft.Win32.RegistryKey =
        Microsoft.Win32.Registry.CurrentUser.CreateSubKey(gcstrRegKeyDb)
        '2.レジストリキーがない場で作成する
        strMdbPathFile = DirectCast(regkey.GetValue("PathFile"), String)
        If strMdbPathFile = "" Then
            gstrdbPath = "c:\"
            gstrdbFile = "HIMEJI.DB"
        Else
            'フォルダー
            gstrdbPath = System.IO.Path.GetDirectoryName(strMdbPathFile)
            'ファイル名
            gstrdbFile = System.IO.Path.GetFileName(strMdbPathFile)
        End If
        '3.ファイルを開くを実行
        ofd.FileName = gstrdbFile
        ofd.InitialDirectory = gstrdbPath
        '[ファイルの種類]に表示される選択肢を指定する
        ofd.Filter = "ＤＢファイル(*.db)|*.db|すべてのファイル(*.*)|*.*"
        '[ファイルの種類]ではじめに選択されるものを指定する
        ofd.FilterIndex = 1
        'タイトルを設定する
        ofd.Title = "DBファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True
        '存在しないファイルの名前が指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckFileExists = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckPathExists = True

        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            '4.OKでファイルのフォルダー+ファイル名をレジストリに保存する
            'MDB設定済フラグ
            gblndbOKflg = True
            '文字列を書き込む（REG_SZで書き込まれる）
            regkey.SetValue("PathFile", ofd.FileName)
            'フォルダー
            gstrdbPath = System.IO.Path.GetDirectoryName(ofd.FileName)
            'ファイル名
            gstrdbFile = System.IO.Path.GetFileName(ofd.FileName)
            SetDatabaseFile = True
        Else
            SetDatabaseFile = False
        End If

        '閉じる
        regkey.Close()
    End Function
    '-----------------------------------------------
    ' GetRegDbFile : レジストリにMDBパスの設定が済かどうかチェックする
    ' 引数
    ' 1 無し
    ' return TRUE:レジストリにDBパスの設定が済、False：:レジストリにDBパスの設定が未
    '
    Public Function GetRegDbFile() As Boolean
        'MDB設定が未設定の場合、設定を行う
        gblndbOKflg = False
        Dim strMdbPathFile As String

        '1.レジストリの存在確認
        Dim regkey As Microsoft.Win32.RegistryKey =
        Microsoft.Win32.Registry.CurrentUser.CreateSubKey(gcstrRegKeyDb)
        '2.レジストリキーがない場合
        strMdbPathFile = DirectCast(regkey.GetValue("PathFile"), String)
        If strMdbPathFile = "" Then
            Dim dialog As DialogResult = MessageBox.Show("DBファイルが未設定です。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '閉じる
            regkey.Close()
            GetRegDbFile = False
            Exit Function
        Else
            'MDB設定済フラグ
            gblndbOKflg = True
            'フォルダー
            gstrdbPath = System.IO.Path.GetDirectoryName(strMdbPathFile)
            'ファイル名
            gstrdbFile = System.IO.Path.GetFileName(strMdbPathFile)
            '閉じる
            regkey.Close()
            GetRegDbFile = True
        End If

    End Function
    '---------------------　アプリ情報  ---------------------
    Public Function GetFile(dir As String, ext As String)
        Dim ofd As New OpenFileDialog()
        ofd.FileName = "default." & ext & ""
        ofd.InitialDirectory = dir & "\"
        ofd.Filter = "ファイル(*." & ext & "l;*." & ext & ")|*." & ext & ";*." & ext & "|すべてのファイル(*.*)|*.*"
        ofd.FilterIndex = 1
        ofd.Title = "開くファイルを選択してください"
        ofd.RestoreDirectory = True
        ofd.CheckFileExists = True
        ofd.CheckPathExists = True
        If ofd.ShowDialog() = DialogResult.OK Then
            Return ofd.FileName
        End If
        Return ""
    End Function

    '---------------------　アプリ情報  ---------------------
    '
    '
    '
    Public Function Get製品()
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        Return Info.ProductName
    End Function

    Public Function ProductVersion()
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        Return (Info.ProductVersion)

        'タイトル = Info.LegalTrademarks
        '商標 = Info.FileDescription
        '著作権 = Info.LegalCopyright
        '説明 = Info.Comments
    End Function

    Public Function Get会社情報()
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        Return (Info.CompanyName)
    End Function
End Class
