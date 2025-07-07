Public Class FormUriage002
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB

    Dim _kekka As String = String.Empty
    Dim _bunrui As String = String.Empty
    Dim _nentuki As String = String.Empty
    Dim _SinaCd As String = String.Empty
    Dim _kanryoutuki As String = String.Empty

    Public Property KanryouTuki As String
        Get
            KanryouTuki = _kanryoutuki
        End Get
        Set(value As String)
            _kanryoutuki = value
        End Set
    End Property


    Public Property SinaCd As String
        Get
            SinaCd = _SinaCd
        End Get
        Set(value As String)
            _SinaCd = value
        End Set
    End Property
    Public Property Nentuki As String
        Get
            Nentuki = _nentuki
        End Get
        Set(value As String)
            _nentuki = value
        End Set
    End Property
    Public Property Bunrui As String
        Get
            Bunrui = _bunrui
        End Get
        Set(value As String)
            _bunrui = value
        End Set
    End Property

    Public Property Kekka As String
        Get
            Kekka = _kekka
        End Get
        Set(value As String)
            _kekka = value
        End Set
    End Property

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

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

End Class