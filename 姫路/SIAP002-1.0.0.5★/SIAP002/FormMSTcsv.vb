Imports System
Imports System.Reflection
Public Class FormMSTcsv
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

    Private Sub FormMSTcsv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If classLIB.GetRegDbFile() = False Then
            MessageBox.Show("データベースファイルの設定が読めません")
            Exit Sub
        End If

        Me.ToolStripStatusLabel1.Text = classLIB.Get会社情報
        Me.ToolStripStatusLabel1.BackColor = Color.LightGray

        Me.DataGridView1.ColumnCount = 1
        Me.DataGridView1.Rows.Add(51)   '商品名の最大Rows+1


        Me.DataGridView1.Columns(0).HeaderText = "設定値"
        'Me.DataGridView1.

        Me.DataGridView1.Rows(0).HeaderCell.Value = "名前"
        Me.DataGridView1.Rows(1).HeaderCell.Value = "フリガナ"
        Me.DataGridView1.Rows(2).HeaderCell.Value = "郵便番号"
        Me.DataGridView1.Rows(3).HeaderCell.Value = "都道府県"
        Me.DataGridView1.Rows(4).HeaderCell.Value = "市区町村"
        Me.DataGridView1.Rows(5).HeaderCell.Value = "番地マンション名"
        Me.DataGridView1.Rows(6).HeaderCell.Value = "電話番号"
        Me.DataGridView1.Rows(7).HeaderCell.Value = "e-mailアドレス"
        Me.DataGridView1.Rows(8).HeaderCell.Value = "寄附金額"

        Me.DataGridView1.Rows(9).HeaderCell.Value = "入金処理日"

        Me.DataGridView1.Rows(10).HeaderCell.Value = "商品1_番号"
        Me.DataGridView1.Rows(11).HeaderCell.Value = "商品1_商品名"
        Me.DataGridView1.Rows(12).HeaderCell.Value = "商品2_番号"
        Me.DataGridView1.Rows(13).HeaderCell.Value = "商品2_商品名"
        Me.DataGridView1.Rows(14).HeaderCell.Value = "商品3_番号"
        Me.DataGridView1.Rows(15).HeaderCell.Value = "商品3_商品名"
        Me.DataGridView1.Rows(16).HeaderCell.Value = "商品4_番号"
        Me.DataGridView1.Rows(17).HeaderCell.Value = "商品4_商品名"
        Me.DataGridView1.Rows(18).HeaderCell.Value = "商品5_番号"
        Me.DataGridView1.Rows(19).HeaderCell.Value = "商品5_商品名"
        Me.DataGridView1.Rows(20).HeaderCell.Value = "商品6_番号"
        Me.DataGridView1.Rows(21).HeaderCell.Value = "商品6_商品名"
        Me.DataGridView1.Rows(22).HeaderCell.Value = "商品7_番号"
        Me.DataGridView1.Rows(23).HeaderCell.Value = "商品7_商品名"
        Me.DataGridView1.Rows(24).HeaderCell.Value = "商品8_番号"
        Me.DataGridView1.Rows(25).HeaderCell.Value = "商品8_商品名"
        Me.DataGridView1.Rows(26).HeaderCell.Value = "商品9_番号"
        Me.DataGridView1.Rows(27).HeaderCell.Value = "商品9_商品名"
        Me.DataGridView1.Rows(28).HeaderCell.Value = "商品10_番号"
        Me.DataGridView1.Rows(29).HeaderCell.Value = "商品10_商品名"

        Me.DataGridView1.Rows(30).HeaderCell.Value = "商品11_番号"
        Me.DataGridView1.Rows(31).HeaderCell.Value = "商品11_商品名"
        Me.DataGridView1.Rows(32).HeaderCell.Value = "商品12_番号"
        Me.DataGridView1.Rows(33).HeaderCell.Value = "商品12_商品名"
        Me.DataGridView1.Rows(34).HeaderCell.Value = "商品13_番号"
        Me.DataGridView1.Rows(35).HeaderCell.Value = "商品13_商品名"
        Me.DataGridView1.Rows(36).HeaderCell.Value = "商品14_番号"
        Me.DataGridView1.Rows(37).HeaderCell.Value = "商品14_商品名"
        Me.DataGridView1.Rows(38).HeaderCell.Value = "商品15_番号"
        Me.DataGridView1.Rows(39).HeaderCell.Value = "商品15_商品名"
        Me.DataGridView1.Rows(40).HeaderCell.Value = "商品16_番号"
        Me.DataGridView1.Rows(41).HeaderCell.Value = "商品16_商品名"
        Me.DataGridView1.Rows(42).HeaderCell.Value = "商品17_番号"
        Me.DataGridView1.Rows(43).HeaderCell.Value = "商品17_商品名"
        Me.DataGridView1.Rows(44).HeaderCell.Value = "商品18_番号"
        Me.DataGridView1.Rows(45).HeaderCell.Value = "商品18_商品名"
        Me.DataGridView1.Rows(46).HeaderCell.Value = "商品19_番号"
        Me.DataGridView1.Rows(47).HeaderCell.Value = "商品19_商品名"
        Me.DataGridView1.Rows(48).HeaderCell.Value = "商品20_番号"
        Me.DataGridView1.Rows(49).HeaderCell.Value = "商品20_商品名"
        Me.DataGridView1.Rows(50).HeaderCell.Value = "申込番号"


        Me.DataGridView1.RowHeadersWidth = 200
        Me.DataGridView1.Columns(0).Width = 200
        Me.DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing


        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c


        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.AllowDrop = False
        Me.DataGridView1.AllowDrop = True

        Disp(-1)

    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        Me.TextBox検索.Text = classLIB.GetFile("", "csv")
        If Me.TextBox検索.Text <> "" Then
            'CSVチェック


            Me.DataGridView2.DataSource = Nothing
            Me.DataGridView2.Rows.Clear()
            Me.DataGridView2.Columns.Clear()

            Dim viewColumn = New DataGridViewColumn()
            viewColumn.Name = ""
            viewColumn.HeaderText = ""
            viewColumn.Width = 400
            'viewColumn.ReadOnly = True
            viewColumn.CellTemplate = New DataGridViewTextBoxCell()
            DataGridView2.Columns.Add(viewColumn)

            Dim sr As System.IO.StreamReader = Nothing
            If System.IO.File.Exists(Me.TextBox検索.Text) Then
                sr = New System.IO.StreamReader(Me.TextBox検索.Text, System.Text.Encoding.GetEncoding("Shift_JIS"))
                Dim line As String() = sr.ReadLine.Split(","c)
                For Each item As String In line
                    Me.DataGridView2.Rows.Add(item.Replace("""", "").Replace("=", ""))
                Next item
            End If

            'Dim parser As New Microsoft.VisualBasic.FileIO.TextFieldParser(Me.TextBox検索.Text, System.Text.Encoding.GetEncoding("Shift_JIS"))
            'parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            'parser.SetDelimiters(",")

            'CSV設定済の色を塗る
            For iRow As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                If Not IsNothing(Me.DataGridView1.Rows(iRow).Cells(0).Value) Then
                    sbCellColor(True, , Me.DataGridView1.Rows(iRow).Cells(0).Value.ToString)   '背景色を塗る
                End If
            Next

            Me.DataGridView2.AllowUserToAddRows = False

        End If
    End Sub
    Private dragBox As Rectangle
    Private Sub DataGridView2_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridView2.MouseDown
        Dim sz As Size = SystemInformation.DragSize
        dragBox = New Rectangle(e.X - sz.Width \ 2, e.Y - sz.Height \ 2, sz.Width, sz.Height)
    End Sub

    Private Sub DataGridView2_MouseUp(sender As Object, e As MouseEventArgs) Handles DataGridView2.MouseUp
        dragBox = Rectangle.Empty
    End Sub

    Private Sub DataGridView2_MouseMove(sender As Object, e As MouseEventArgs) Handles DataGridView2.MouseMove
        If e.Button = MouseButtons.Left AndAlso Not dragBox.IsEmpty AndAlso dragBox.Contains(e.X, e.Y) Then
            dragBox = Rectangle.Empty
            Dim ht As DataGridView.HitTestInfo = DataGridView2.HitTest(e.X, e.Y)
            If ht.RowIndex >= 0 Then
                Dim row As DataGridViewRow = DataGridView2.Rows(ht.RowIndex)
                Dim data As New ArrayList()
                For Each cell As DataGridViewCell In row.Cells
                    data.Add(cell.Value)
                Next
                Dim effect As DragDropEffects = DataGridView2.DoDragDrop(
                    data.ToArray(),
                    DragDropEffects.Copy Or DragDropEffects.Move)

                If CBool(effect And DragDropEffects.Move) Then
                    'DataGridView2.Rows.Remove(row)   '移動が行われた場合は元データを削除する 
                    Call sbCellColor(True, ht.RowIndex)   'CSV設定済の背景色を塗る
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_DragOver(sender As Object, e As DragEventArgs) Handles DataGridView1.DragOver
        If Not e.Data.GetDataPresent(GetType(Object())) Then
            Return
        End If

        'ドラッグ中に Ctrl キーが押された場合は、コピー動作として扱う 
        Dim isCopy As Boolean = CBool(e.AllowedEffect And DragDropEffects.Copy) AndAlso CBool(e.KeyState And &H8)
        Dim isMove As Boolean = Not isCopy AndAlso CBool(e.AllowedEffect And DragDropEffects.Move)
        If isCopy Then
            e.Effect = DragDropEffects.Copy
        ElseIf isMove Then
            e.Effect = DragDropEffects.Move
        Else
            Return
        End If

        'ドラッグ先を選択状態にして、どこにドロップされるのかが分かるようにする 
        DataGridView1.ClearSelection()
        Dim pt As Point = DataGridView1.PointToClient(New Point(e.X, e.Y))
        Dim ht As DataGridView.HitTestInfo = DataGridView1.HitTest(pt.X, pt.Y)
        If ht.RowIndex >= 0 Then
            'データ部のセルまたは行ヘッダ上にいる場合 
            DataGridView1.Rows(ht.RowIndex).Selected = True
        Else
            '領域外にいる場合はドロップ禁止 
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub DataGridView1_DragDrop(sender As Object, e As DragEventArgs) Handles DataGridView1.DragDrop
        Dim data() As Object = e.Data.GetData(GetType(Object()))
        If data Is Nothing Then
            Return  '意図しないデータなので無視 
        End If

        Dim pt As Point = DataGridView1.PointToClient(New Point(e.X, e.Y))
        Dim ht As DataGridView.HitTestInfo = DataGridView1.HitTest(pt.X, pt.Y)
        Me.DataGridView1.ClearSelection()

        'ドロップ先のひとつ上の行に挿入し、挿入した新規行を選択状態にする 
        '(一番下に追加したい場合にはどうする?) 
        Dim newRowIndex As Integer = ht.RowIndex
        Me.DataGridView1.Rows(newRowIndex).Cells(0).Value = data(0).ToString
        Me.DataGridView1.Rows(newRowIndex).Selected = True
    End Sub

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click

        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim strSQL As String = String.Empty
        Dim dt As DataTable

        If Me.TextBoxひな形名.Text.Trim = "" Then
            MessageBox.Show("ひな形名が入力されていません")
            Exit Sub
        ElseIf Me.NumericUpDown番号.Text.Trim = "" Then
            MessageBox.Show("番号が入力されていません")
            Exit Sub
        End If

        strSQL = "SELECT HINE_NO, CSVNAME FROM M_HINAGATA WHERE HINE_NO = '" & Me.NumericUpDown番号.Text.Trim & "'"
        dt = classSQLite.SetDataTable(strSQL)
        If dt.Rows.Count = 1 Then
            strSQL = ""
            strSQL &= "UPDATE M_HINAGATA"
            strSQL &= " SET CSVNAME='" & Me.TextBoxひな形名.Text & "'"
            If Me.CheckBox使用.Checked Then
                strSQL &= ", SWON='1'"
            Else
                strSQL &= ", SWON='0'"
            End If

            strSQL &= ", FULLNAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 0, 0) & "'"
            strSQL &= ", KANA='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 1, 0) & "'"
            strSQL &= ", ZIPCD='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 2, 0) & "'"
            strSQL &= ", ADMIN='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 3, 0) & "'"
            strSQL &= ", CITY='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 4, 0) & "'"
            strSQL &= ", TOWN='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 5, 0) & "'"
            strSQL &= ", TEL='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 6, 0) & "'"
            strSQL &= ", MAIL='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 7, 0) & "'"
            strSQL &= ", KIFUKIN='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 8, 0) & "'"

            strSQL &= ", NYUKINHI='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 9, 0) & "'"

            strSQL &= ", SYOU01='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 10, 0) & "'"
            strSQL &= ", SYOU01NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 11, 0) & "'"
            strSQL &= ", SYOU02='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 12, 0) & "'"
            strSQL &= ", SYOU02NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 13, 0) & "'"
            strSQL &= ", SYOU03='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 14, 0) & "'"
            strSQL &= ", SYOU03NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 15, 0) & "'"
            strSQL &= ", SYOU04='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 16, 0) & "'"
            strSQL &= ", SYOU04NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 17, 0) & "'"
            strSQL &= ", SYOU05='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 18, 0) & "'"
            strSQL &= ", SYOU05NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 19, 0) & "'"
            strSQL &= ", SYOU06='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 20, 0) & "'"
            strSQL &= ", SYOU06NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 21, 0) & "'"
            strSQL &= ", SYOU07='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 22, 0) & "'"
            strSQL &= ", SYOU07NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 23, 0) & "'"
            strSQL &= ", SYOU08='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 24, 0) & "'"
            strSQL &= ", SYOU08NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 25, 0) & "'"
            strSQL &= ", SYOU09='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 26, 0) & "'"
            strSQL &= ", SYOU09NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 27, 0) & "'"
            strSQL &= ", SYOU10='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 28, 0) & "'"
            strSQL &= ", SYOU10NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 29, 0) & "'"

            strSQL &= ", SYOU11='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 30, 0) & "'"
            strSQL &= ", SYOU11NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 31, 0) & "'"
            strSQL &= ", SYOU12='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 32, 0) & "'"
            strSQL &= ", SYOU12NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 33, 0) & "'"
            strSQL &= ", SYOU13='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 34, 0) & "'"
            strSQL &= ", SYOU13NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 35, 0) & "'"
            strSQL &= ", SYOU14='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 36, 0) & "'"
            strSQL &= ", SYOU14NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 37, 0) & "'"
            strSQL &= ", SYOU15='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 38, 0) & "'"
            strSQL &= ", SYOU15NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 39, 0) & "'"
            strSQL &= ", SYOU16='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 40, 0) & "'"
            strSQL &= ", SYOU16NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 41, 0) & "'"
            strSQL &= ", SYOU17='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 42, 0) & "'"
            strSQL &= ", SYOU17NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 43, 0) & "'"
            strSQL &= ", SYOU18='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 44, 0) & "'"
            strSQL &= ", SYOU18NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 45, 0) & "'"
            strSQL &= ", SYOU19='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 46, 0) & "'"
            strSQL &= ", SYOU19NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 47, 0) & "'"
            strSQL &= ", SYOU20='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 48, 0) & "'"
            strSQL &= ", SYOU20NAM='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 49, 0) & "'"
            strSQL &= ", MOSHIKOMINO='" & classLIB.GetDataGridViewValue(Me.DataGridView1, 50, 0) & "'"

            strSQL &= " , UPDATE_DAY = " & classSQLite.GetTimeSQL & ""
            strSQL &= " , UPDATE_NAM = '" & UserID & "'"
            strSQL &= " WHERE HINE_NO= '" & Me.NumericUpDown番号.Text.Trim & "'"

        Else
            strSQL = ""
            strSQL &= "INSERT INTO M_HINAGATA"
            strSQL &= "(HINE_NO, CSVNAME, SWON,  FULLNAM, KANA, ZIPCD, ADMIN, CITY, TOWN, TEL, MAIL, KIFUKIN, NYUKINHI, SYOU01, SYOU01NAM, SYOU02, SYOU02NAM, SYOU03, SYOU03NAM, SYOU04, SYOU04NAM,"
            strSQL &= " SYOU05, SYOU05NAM, SYOU06, SYOU06NAM, SYOU07, SYOU07NAM, SYOU08, SYOU08NAM, SYOU09, SYOU09NAM, SYOU10, SYOU10NAM, SYOU11, SYOU11NAM, SYOU12, SYOU12NAM,"
            strSQL &= " SYOU13, SYOU13NAM, SYOU14, SYOU14NAM, SYOU15, SYOU15NAM, SYOU16, SYOU16NAM, SYOU17, SYOU17NAM, SYOU18, SYOU18NAM, SYOU19, SYOU19NAM, SYOU20, SYOU20NAM, MOSHIKOMINO, ENTRY_DAY, ENTRY_NAM, UPDATE_DAY, UPDATE_NAM)VALUES("

            strSQL &= "'" & Me.NumericUpDown番号.Text.Trim & "'"
            strSQL &= ", '" & Me.TextBoxひな形名.Text & "'"
            If Me.CheckBox使用.Checked Then
                strSQL &= ", '1'"
            Else
                strSQL &= ", '0'"
            End If
            For ro As Integer = 0 To 50     '商品名の最大Rows
                strSQL &= ", '" & classLIB.GetDataGridViewValue(Me.DataGridView1, ro, 0) & "'"
            Next

            strSQL &= " ," & classSQLite.GetTimeSQL & ""
            strSQL &= " ,'" & UserID & "'"
            strSQL &= " ," & classSQLite.GetTimeSQL & ""
            strSQL &= " ,'" & UserID & "'"
            strSQL &= ")"

        End If
        If Me.CheckBox使用.Checked Then
            If classSQLite.EXEC("UPDATE M_HINAGATA SET SWON='0'") Then

            End If
        End If

        If classSQLite.EXEC(strSQL) Then
            Clear()
        End If

        Disp(Me.NumericUpDown番号.Text.Trim)
        MessageBox.Show("更新しました")
    End Sub

    Private Sub Disp(NO As Integer)
        Dim strSQL As String = String.Empty
        Dim classSQLite As New ClassSQLite(classLIB.gstrdbPath & "\" & classLIB.gstrdbFile)
        Dim dt As DataTable
        Dim ro As Integer

        For iRow As Integer = 0 To Me.DataGridView2.Rows.Count - 1
            Call sbCellColor(False, iRow)   'CSV設定済の背景色を消す
        Next

        strSQL = "SELECT FULLNAM, KANA, ZIPCD, ADMIN, CITY, TOWN, TEL, MAIL, KIFUKIN, NYUKINHI, SYOU01, SYOU01NAM, SYOU02, SYOU02NAM, SYOU03, SYOU03NAM, SYOU04, SYOU04NAM, SYOU05, SYOU05NAM, SYOU06, SYOU06NAM, SYOU07, SYOU07NAM, SYOU08, SYOU08NAM, SYOU09, SYOU09NAM, SYOU10, SYOU10NAM, SYOU11, SYOU11NAM, SYOU12, SYOU12NAM, SYOU13, SYOU13NAM, SYOU14, SYOU14NAM, SYOU15, SYOU15NAM, SYOU16, SYOU16NAM, SYOU17, SYOU17NAM, SYOU18, SYOU18NAM, SYOU19, SYOU19NAM, SYOU20, SYOU20NAM"
        'strSQL &= ",HINE_NO ,CSVNAME, SWON ,HINE_NO  FROM  M_HINAGATA"
        strSQL &= ", MOSHIKOMINO, HINE_NO , CSVNAME, SWON FROM  M_HINAGATA"
        If NO = -1 Then
            strSQL &= " WHERE SWON ='1'"

        Else
            strSQL &= " WHERE HINE_NO ='" & NO & "'"

        End If

        dt = classSQLite.SetDataTable(strSQL)

        If dt.Rows.Count = 1 Then
            For ro = 0 To 50    '申込№の最大Rows
                Me.DataGridView1.Rows(ro).Cells(0).Value = dt.Rows(0).Item(ro).ToString()

                Call sbCellColor(True, , dt.Rows(0).Item(ro).ToString())   'CSV設定済の背景色を塗る
            Next

            Me.NumericUpDown番号.Value = dt.Rows(0).Item(51).ToString()
            Me.TextBoxひな形名.Text = dt.Rows(0).Item(52).ToString()
            If dt.Rows(0).Item(53).ToString() = "1" Then
                Me.CheckBox使用.Checked = True
            Else
                Me.CheckBox使用.Checked = False
            End If
            'Me.NumericUpDown番号.Value = dt.Rows(0).Item(53).ToString()   '重複

        Else
            Clear()
        End If
    End Sub
    Private Sub Clear()
        Dim ro As Integer = 0
        For ro = 0 To 50    '申込№の最大Rows
            Me.DataGridView1.Rows(ro).Cells(0).Value = ""
        Next
        Me.TextBoxひな形名.Text = ""
        Me.CheckBox使用.Checked = False

        For iRow As Integer = 0 To Me.DataGridView2.Rows.Count - 1
            Call sbCellColor(False, iRow)   'CSV設定済の背景色を消す
        Next

    End Sub

    Private Sub NumericUpDown番号_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown番号.ValueChanged
        Disp(NumericUpDown番号.Value)
    End Sub
    '設定済のCSVの背景色を塗る(DataGridView2)
    ' 引数
    ' 1 true塗る、False塗らない
    ' 2 行の指定(オプション)
    ' 3 項目値の指定(オプション)
    '
    Private Sub sbCellColor(ByVal blnColor As Boolean, Optional ByVal intRow As Integer = 99999, Optional ByVal strText As String = "")
        If intRow <> 99999 Then
            If blnColor Then
                Me.DataGridView2(0, intRow).Style.BackColor = Color.LightBlue
            Else
                Me.DataGridView2(0, intRow).Style.BackColor = Color.Empty
            End If
        Else
            If strText <> "" Then
                intRow = fnintRowSearch(strText)
                If intRow <> 99999 Then
                    If blnColor Then
                        Me.DataGridView2(0, intRow).Style.BackColor = Color.LightBlue
                    Else
                        Me.DataGridView2(0, intRow).Style.BackColor = Color.Empty
                    End If
                End If
            End If
        End If
    End Sub
    '項目値の行を取得する(DataGridView2)
    ' 引数
    ' 1 項目値
    ' return 行番号
    '
    Private Function fnintRowSearch(ByVal strTest As String) As Integer
        fnintRowSearch = 99999
        For iRow As Integer = 0 To Me.DataGridView2.Rows.Count - 1
            If Me.DataGridView2.Rows(iRow).Cells(0).Value = strTest Then
                fnintRowSearch = iRow
                Exit For
            End If
        Next
    End Function

End Class