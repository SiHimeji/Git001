Public Class FormMSTnayose
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

    Private Sub FormMSTnayose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        strSQL = "SELECT NAYOSE_ID, FULLNAM, KANA, ADMIN, CITY, TOWN, TEL, MAIL FROM M_NAYOSE WHERE NAYOSE_ID ='1'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then
            If dt.Rows(0).Item("FULLNAM").ToString = "" Then
                Me.ComboBox名前.SelectedIndex = -1
            Else
                Me.ComboBox名前.SelectedIndex = dt.Rows(0).Item("FULLNAM").ToString
            End If

            If dt.Rows(0).Item("KANA").ToString = "" Then
                Me.ComboBoxフリガナ.SelectedIndex = -1
            Else
                Me.ComboBoxフリガナ.SelectedIndex = dt.Rows(0).Item("KANA").ToString
            End If

            If dt.Rows(0).Item("ADMIN").ToString = "" Then
                Me.ComboBox都道府県.SelectedIndex = -1
            Else
                Me.ComboBox都道府県.SelectedIndex = dt.Rows(0).Item("ADMIN").ToString
            End If

            If dt.Rows(0).Item("CITY").ToString = "" Then
                Me.ComboBox市区町村.SelectedItem = -1
            Else
                Me.ComboBox市区町村.SelectedIndex = dt.Rows(0).Item("CITY").ToString
            End If

            If dt.Rows(0).Item("TOWN").ToString = "" Then
                Me.ComboBox番地マンション名.SelectedItem = -1
            Else
                Me.ComboBox番地マンション名.SelectedIndex = dt.Rows(0).Item("TOWN").ToString
            End If

            If dt.Rows(0).Item("TEL").ToString = "" Then
                Me.ComboBox電話番号.SelectedItem = -1
            Else
                Me.ComboBox電話番号.SelectedIndex = dt.Rows(0).Item("TEL").ToString
            End If

            If dt.Rows(0).Item("MAIL").ToString = "" Then
                Me.ComboBoxメール.SelectedItem = -1
            Else
                Me.ComboBoxメール.SelectedIndex = dt.Rows(0).Item("MAIL").ToString
            End If
        Else
            Clear()
        End If

    End Sub
    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click

        If ChkJun() = False Then
            Return
        End If

        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        strSQL = "SELECT NAYOSE_ID, FULLNAM, KANA, ADMIN, CITY, TOWN, TEL, MAIL FROM M_NAYOSE WHERE NAYOSE_ID ='1'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then
            strSQL = ""
            strSQL &= "UPDATE M_NAYOSE"
            If Me.ComboBox名前.Text = "" Then
                strSQL &= "  SET FULLNAM=  '0'"
            Else
                strSQL &= " SET FULLNAM= '" & Me.ComboBox名前.Text & "'"
            End If
            If Me.ComboBoxフリガナ.Text = "" Then
                strSQL &= ", KANA='0'"
            Else
                strSQL &= ", KANA='" & Me.ComboBoxフリガナ.Text & "'"
            End If

            If Me.ComboBox都道府県.Text = "" Then
                strSQL &= ", ADMIN='0'"
            Else
                strSQL &= ", ADMIN= '" & Me.ComboBox都道府県.Text & "'"

            End If
            If Me.ComboBox市区町村.Text = "" Then
                strSQL &= ", CITY='0'"
            Else
                strSQL &= ", CITY='" & Me.ComboBox市区町村.Text & "'"
            End If
            If Me.ComboBox番地マンション名.Text = "" Then
                strSQL &= ", TOWN='0'"
            Else
                strSQL &= ", TOWN='" & Me.ComboBox番地マンション名.Text & "'"
            End If

            If Me.ComboBox電話番号.Text = "" Then
                strSQL &= ",TEL= '0'"
            Else
                strSQL &= ",TEL= '" & Me.ComboBox電話番号.Text & "'"
            End If
            If Me.ComboBoxメール.Text = "" Then
                strSQL &= ",MAIL= '0'"
            Else
                strSQL &= ",MAIL= '" & Me.ComboBoxメール.Text & "'"
            End If

            strSQL &= " , UPDATE_DAY = " & classSQLite.GetTimeSQL & ""
            strSQL &= " , UPDATE_NAM = '" & UserID & "'"
            strSQL &= " WHERE NAYOSE_ID='1';"

        Else
            strSQL = ""
            strSQL &= "INSERT INTO M_NAYOSE"
            strSQL &= "(NAYOSE_ID, FULLNAM, KANA, ADMIN, CITY, TOWN, TEL, MAIL, ENTRY_DAY, ENTRY_NAM, UPDATE_DAY, UPDATE_NAM)VALUES("
            strSQL &= "'1'"
            If Me.ComboBox名前.Text = "" Then
                strSQL &= ", '0'"
            Else
                strSQL &= ", '" & Me.ComboBox名前.Text & "'"
            End If
            If Me.ComboBoxフリガナ.Text = "" Then
                strSQL &= ", '0'"
            Else
                strSQL &= ", '" & Me.ComboBoxフリガナ.Text & "'"
            End If
            If Me.ComboBox都道府県.Text = "" Then
                strSQL &= ", '0'"
            Else
                strSQL &= ", '" & Me.ComboBox都道府県.Text & "'"
            End If
            If Me.ComboBox市区町村.Text = "" Then
                strSQL &= ", '0'"
            Else
                strSQL &= ", '" & Me.ComboBox市区町村.Text & "'"
            End If
            If Me.ComboBox番地マンション名.Text = "" Then
                strSQL &= ", '0'"
            Else
                strSQL &= ", '" & Me.ComboBox番地マンション名.Text & "'"
            End If

            If Me.ComboBox電話番号.Text = "" Then
                strSQL &= ", '0'"
            Else
                strSQL &= ", '" & Me.ComboBox電話番号.Text & "'"
            End If
            If Me.ComboBoxメール.Text = "" Then
                strSQL &= ", '0'"
            Else
                strSQL &= ", '" & Me.ComboBoxメール.Text & "'"
            End If

            strSQL &= " ," & classSQLite.GetTimeSQL & ""
            strSQL &= " ,'" & UserID & "'"
            strSQL &= " ," & classSQLite.GetTimeSQL & ""
            strSQL &= " ,'" & UserID & "'"
            strSQL &= ")"
        End If

        If classSQLite.EXEC(strSQL) Then
            Clear()
        End If

        Disp()

        MessageBox.Show("更新しました")

    End Sub
    Private Sub Clear()

        Me.ComboBox名前.SelectedIndex = -1
        Me.ComboBoxフリガナ.SelectedIndex = -1
        Me.ComboBox都道府県.SelectedIndex = -1
        Me.ComboBox市区町村.SelectedIndex = -1
        Me.ComboBox番地マンション名.SelectedIndex = -1
        Me.ComboBox電話番号.SelectedIndex = -1
        Me.ComboBoxメール.SelectedIndex = -1

    End Sub

    Private Function ChkJun() As Boolean
        Dim jun() = {"", "", "", "", "", "", "", "", "", "", "", ""}

        If Me.ComboBox名前.Text <> "" Then
            If jun(Me.ComboBox名前.SelectedIndex) = "" Then
                jun(Me.ComboBox名前.SelectedIndex) = Me.ComboBox名前.SelectedIndex.ToString
            Else
                MessageBox.Show("名前と同じ順が存在します")
                Return False
            End If
        End If
        If Me.ComboBoxフリガナ.Text <> "" Then
            If jun(Me.ComboBoxフリガナ.SelectedIndex) = "" Then
                jun(Me.ComboBoxフリガナ.SelectedIndex) = Me.ComboBoxフリガナ.SelectedIndex.ToString
            Else
                MessageBox.Show("フリガナと同じ順が存在します")
                Return False
            End If
        End If

        If Me.ComboBox都道府県.Text <> "" Then
            If jun(Me.ComboBox都道府県.SelectedIndex) = "" Then
                jun(Me.ComboBox都道府県.SelectedIndex) = Me.ComboBox都道府県.SelectedIndex.ToString
            Else
                MessageBox.Show("都道府県と同じ順が存在します")
                Return False
            End If
        End If

        If Me.ComboBox市区町村.Text <> "" Then
            If jun(Me.ComboBox市区町村.SelectedIndex) = "" Then
                jun(Me.ComboBox市区町村.SelectedIndex) = Me.ComboBox市区町村.SelectedIndex.ToString
            Else
                MessageBox.Show("市区町村と同じ順が存在します")
                Return False
            End If
        End If

        If Me.ComboBox番地マンション名.Text <> "" Then
            If jun(Me.ComboBox番地マンション名.SelectedIndex) = "" Then
                jun(Me.ComboBox番地マンション名.SelectedIndex) = Me.ComboBox番地マンション名.SelectedIndex.ToString
            Else
                MessageBox.Show("番地マンション名と同じ順が存在します")
                Return False
            End If
        End If

        If Me.ComboBox電話番号.Text <> "" Then
            If jun(Me.ComboBox電話番号.SelectedIndex) = "" Then
                jun(Me.ComboBox電話番号.SelectedIndex) = Me.ComboBox電話番号.SelectedIndex.ToString
            Else
                MessageBox.Show("電話番号と同じ順が存在します")
                Return False
            End If
        End If

        If Me.ComboBoxメール.Text <> "" Then
            If jun(Me.ComboBoxメール.SelectedIndex) = "" Then
                jun(Me.ComboBoxメール.SelectedIndex) = Me.ComboBoxメール.SelectedIndex.ToString
            Else
                MessageBox.Show("メールと同じ順が存在します")
                Return False
            End If
        End If

        If Me.ComboBox名前.Text.Trim = "" And Me.ComboBoxフリガナ.Text.Trim = "" And Me.ComboBox都道府県.Text.Trim = "" And
           Me.ComboBox市区町村.Text.Trim = "" And Me.ComboBox番地マンション名.Text.Trim = "" And Me.ComboBox電話番号.Text.Trim = "" And
           Me.ComboBoxメール.Text.Trim = "" Then
            MessageBox.Show("名寄せ順を入力してください")
            Return False
        End If

        Return True
    End Function






End Class