Public Class FormKey


    Private mfrmMain1 As FormMeisai
    Private mfrmMain2 As FormCSV
    Private mfrmMain3 As FormMeisaiMain
    Private FmNo As Integer
    Public wNID As String
    Private nNID As String = String.Empty


    'Sub New(ByVal afrm As FormMeisai)
    Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        'メインフォームオブジェクトの退避
    End Sub

    Public Sub SetFormMeisai(ByVal afrm As FormMeisai)
        Me.mfrmMain1 = afrm
        FmNo = 1
    End Sub
    Public Sub SetFormCSV(ByVal afrm As FormCSV)
        Me.mfrmMain2 = afrm
        FmNo = 2
    End Sub
    Public Sub SetFormMeisaiMain(ByVal afrm As FormMeisaiMain)
        Me.mfrmMain3 = afrm
        FmNo = 3
    End Sub


    Private Sub Button0_Click(sender As Object, e As EventArgs) Handles Button0.Click
        Me.TextBoxNo.Text = Me.TextBoxNo.Text & "0"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.TextBoxNo.Text = Me.TextBoxNo.Text & "1"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.TextBoxNo.Text = Me.TextBoxNo.Text & "2"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.TextBoxNo.Text = Me.TextBoxNo.Text & "3"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.TextBoxNo.Text = Me.TextBoxNo.Text & "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.TextBoxNo.Text = Me.TextBoxNo.Text & "5"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.TextBoxNo.Text = Me.TextBoxNo.Text & "6"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.TextBoxNo.Text = Me.TextBoxNo.Text & "7"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.TextBoxNo.Text = Me.TextBoxNo.Text & "8"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.TextBoxNo.Text = Me.TextBoxNo.Text & "9"
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Me.TextBoxNo.Text = ""
    End Sub

    Private Sub ButtonENT_Click(sender As Object, e As EventArgs) Handles ButtonENT.Click
        nNID = Me.TextBoxNo.Text
        Owari()
    End Sub

    Private Sub TextBoxNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            nNID = Me.TextBoxNo.Text
            Owari()
        End If
    End Sub

    Private Sub FormKey_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.IDToolStripMenuItem.Text = wNID
    End Sub
    Private Sub Owari()
        If Me.TextBoxNo.Text = "" Then
            Me.TextBoxNo.Text = wNID
        End If
        Me.Close()
    End Sub

    Private Sub FormKey_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If nNID = "" Then
            Me.TextBoxNo.Text = wNID
        End If
        If Me.TextBoxNo.Text = "" Then
            Me.TextBoxNo.Text = wNID
        End If

        If FmNo = 1 Then
            Me.mfrmMain1.SetTextBox(Me.TextBoxNo.Text)
            'Me.Close()
        ElseIf FmNo = 2 Then
            Me.mfrmMain2.SetTextBox(Me.TextBoxNo.Text)
            'Me.Close()
        ElseIf FmNo = 3 Then
            Me.mfrmMain3.SetTextBox(Me.TextBoxNo.Text)
            'Me.Close()
        End If

    End Sub

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Me.TextBoxNo.Text = wNID
        Me.Close()
    End Sub
End Class