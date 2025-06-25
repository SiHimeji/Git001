Imports System.Text.RegularExpressions
Imports System.Windows.Forms.AxHost

Public Class ClassNayose
    Public Function Nayose_Name(ByVal strName As String) As String
        'スペース削除
        strName = ReplaceSpace(strName)
        '全角変換
        strName = StrConv(strName, vbWide)

        'ハイフン系削除
        strName = ReplaceHaihun(strName)

        '拗音変換
        strName = ReplaceYoOn(strName)

        '英数字削除
        'strName = ReplaceEisu(strName)

        '括弧削除
        strName = ReplaceKakko(strName)
        If strName = "" Then strName = "-"

        Return strName

    End Function

    'カナ変更
    Public Function Nayose_Kana(ByVal strKana As String) As String
        'スペース削除
        strKana = ReplaceSpace(strKana)
        '全角変換
        strKana = StrConv(strKana, vbWide)

        'ハイフン系削除
        strKana = ReplaceHaihun(strKana)

        '拗音変換
        strKana = ReplaceYoOn(strKana)

        '英数字削除
        'strKana = ReplaceEisu(strKana)

        '括弧削除
        strKana = ReplaceKakko(strKana)
        If strKana = "" Then strKana = "-"

        Return strKana
    End Function

    '都道府県変更
    Public Function Nayose_Admin(ByVal strAdmin As String) As String
        'スペース削除
        strAdmin = ReplaceSpace(strAdmin)
        '全角変換
        strAdmin = StrConv(strAdmin, vbWide)

        If strAdmin = "" Then strAdmin = "-"
        Return strAdmin
    End Function

    '市区町村変更
    Public Function Nayose_City(ByVal strCity As String) As String
        'スペース削除
        strCity = ReplaceSpace(strCity)
        '全角変換
        strCity = StrConv(strCity, vbWide)

        If strCity = "" Then strCity = "-"

        Return strCity
    End Function

    '番地変更
    Public Function Nayose_Banti(ByVal strBanti As String) As String
        'スペース削除
        strBanti = ReplaceSpace(strBanti)

        '全角変換
        strBanti = StrConv(strBanti, vbWide)

        '拗音変換
        strBanti = ReplaceYoOn(strBanti)

        '漢数字
        strBanti = ReplaceKanSuuji(strBanti)
        '
        strBanti = Replace(strBanti, "の", "ノ")
        strBanti = Replace(strBanti, "が", "カ")
        strBanti = Replace(strBanti, "ガ", "カ")
        strBanti = Replace(strBanti, "ヶ", "カ")
        strBanti = Replace(strBanti, "ケ", "カ")
        strBanti = Replace(strBanti, "ｶﾞ", "カ")
        strBanti = Replace(strBanti, "ｹ", "カ")

        '
        strBanti = Replace(strBanti, "丁目", "－")
        strBanti = Replace(strBanti, "番地", "－")
        strBanti = Replace(strBanti, "番", "－")
        strBanti = Replace(strBanti, "号", "－")
        strBanti = Replace(strBanti, "丁", "－")
        strBanti = Replace(strBanti, "ノ", "－")
        strBanti = Replace(strBanti, "ﾉ", "－")

        If strBanti = "" Then strBanti = "-"

        Return strBanti
    End Function

    '電話番号変更
    Public Function Nayose_TEL(ByVal strTel As String) As String
        'スペース削除
        strTel = ReplaceSpace(strTel)

        'ハイフン系削除
        strTel = ReplaceHaihun(strTel)

        '全角を半角に変更
        strTel = StrConv(strTel, vbNarrow)

        '数字以外削除
        Dim reg As New Regex("[^\d]")   '--- [^0-9]でもよい

        Dim ret As String = reg.Replace(strTel, "")
        If ret = "" Then ret = "-"
        Return ret

    End Function

    'Email変更
    Public Function Nayose_Mail(ByVal strMail As String) As String
        'スペース削除
        strMail = ReplaceSpace(strMail)

        '全角を半角に変更
        strMail = StrConv(strMail, vbNarrow).ToLower


        'Email用正規表現
        'Dim reg As New Regex("^[a-zA-Z0-9_+-]+(\.[a-zA-Z0-9_+-]+)*@([a-zA-Z0-9][a-zA-Z0-9-]*[a-zA-Z0-9]*\.)+[a-zA-Z]{2,}$", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        Dim reg As New Regex("[^a-zA-Z0-9@]", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        Dim ret As String = reg.Replace(strMail, "")

        If ret = "" Then ret = "-"
        Return ret

    End Function

    Private Function ReplaceSpace(ByRef strBuff As String) As String
        'スペース削除
        strBuff = Trim(strBuff)
        strBuff = Replace(strBuff, " ", "")
        strBuff = Replace(strBuff, "　", "")

        Return strBuff
    End Function


    Private Function ReplaceHaihun(ByRef strBuff As String) As String
        '-系削除
        strBuff = Replace(strBuff, "-", "")
        strBuff = Replace(strBuff, "‐", "")
        strBuff = Replace(strBuff, "ー", "")
        strBuff = Replace(strBuff, "－", "")
        strBuff = Replace(strBuff, "―", "")
        strBuff = Replace(strBuff, "ｰ", "")
        strBuff = Replace(strBuff, "─", "")
        strBuff = Replace(strBuff, "━", "")

        Return strBuff
    End Function

    Private Function ReplaceYoOn(ByRef strBuff As String) As String

        '全角変換
        strBuff = StrConv(strBuff, vbWide)

        '拗音変換
        strBuff = Replace(strBuff, "ぁ", "あ")
        strBuff = Replace(strBuff, "ぃ", "い")
        strBuff = Replace(strBuff, "ぅ", "う")
        strBuff = Replace(strBuff, "ぇ", "え")
        strBuff = Replace(strBuff, "ぉ", "お")
        strBuff = Replace(strBuff, "ゃ", "や")
        strBuff = Replace(strBuff, "ゅ", "ゆ")
        strBuff = Replace(strBuff, "ょ", "よ")
        strBuff = Replace(strBuff, "ァ", "ア")
        strBuff = Replace(strBuff, "ィ", "イ")
        strBuff = Replace(strBuff, "ゥ", "ウ")
        strBuff = Replace(strBuff, "ェ", "エ")
        strBuff = Replace(strBuff, "ォ", "オ")
        strBuff = Replace(strBuff, "ャ", "ヤ")
        strBuff = Replace(strBuff, "ュ", "ユ")
        strBuff = Replace(strBuff, "ョ", "ヨ")
        strBuff = Replace(strBuff, "っ", "つ")
        strBuff = Replace(strBuff, "ッ", "ツ")
        strBuff = Replace(strBuff, "ヵ", "カ")
        strBuff = Replace(strBuff, "ヶ", "ケ")
        strBuff = Replace(strBuff, "ヮ", "ワ")
        strBuff = Replace(strBuff, "ゎ", "わ")


        strBuff = Replace(strBuff, "ａ", "Ａ")
        strBuff = Replace(strBuff, "ｂ", "Ｂ")
        strBuff = Replace(strBuff, "ｃ", "Ｃ")
        strBuff = Replace(strBuff, "ｄ", "Ｄ")
        strBuff = Replace(strBuff, "ｅ", "Ｅ")
        strBuff = Replace(strBuff, "ｆ", "Ｆ")
        strBuff = Replace(strBuff, "ｇ", "Ｇ")
        strBuff = Replace(strBuff, "ｈ", "Ｈ")
        strBuff = Replace(strBuff, "ｉ", "Ｉ")
        strBuff = Replace(strBuff, "ｊ", "Ｊ")
        strBuff = Replace(strBuff, "ｋ", "Ｋ")
        strBuff = Replace(strBuff, "ｌ", "Ｌ")
        strBuff = Replace(strBuff, "ｍ", "Ｍ")
        strBuff = Replace(strBuff, "ｎ", "Ｎ")
        strBuff = Replace(strBuff, "ｏ", "Ｏ")
        strBuff = Replace(strBuff, "ｐ", "Ｐ")
        strBuff = Replace(strBuff, "ｑ", "Ｑ")
        strBuff = Replace(strBuff, "ｒ", "Ｒ")
        strBuff = Replace(strBuff, "ｓ", "Ｓ")
        strBuff = Replace(strBuff, "ｔ", "Ｔ")
        strBuff = Replace(strBuff, "ｕ", "Ｕ")
        strBuff = Replace(strBuff, "ｖ", "Ｖ")
        strBuff = Replace(strBuff, "ｗ", "Ｗ")
        strBuff = Replace(strBuff, "ｘ", "Ｘ")
        strBuff = Replace(strBuff, "ｙ", "Ｙ")
        strBuff = Replace(strBuff, "ｚ", "Ｚ")

        Return strBuff
    End Function

    Private Function ReplaceEisu(ByRef strBuff As String) As String
        '英数字削除
        'RegExpオブジェクトの作成

        Dim reg As New Regex("[0-9a-zA-Z０-９ａ-ｚＡ-Ｚ]")   '--- [^0-9]でもよい
        strBuff = reg.Replace(strBuff, "")

        Return strBuff
    End Function

    Private Function ReplaceKakko(ByRef strBuff As String) As String
        '括弧削除
        strBuff = Replace(strBuff, "(", "")
        strBuff = Replace(strBuff, ")", "")
        strBuff = Replace(strBuff, "[", "")
        strBuff = Replace(strBuff, "]", "")
        strBuff = Replace(strBuff, "{", "")
        strBuff = Replace(strBuff, "}", "")
        strBuff = Replace(strBuff, "【", "")
        strBuff = Replace(strBuff, "】", "")
        strBuff = Replace(strBuff, "「", "")
        strBuff = Replace(strBuff, "」", "")
        strBuff = Replace(strBuff, "<", "")
        strBuff = Replace(strBuff, ">", "")
        strBuff = Replace(strBuff, "＜", "")
        strBuff = Replace(strBuff, "＞", "")
        strBuff = Replace(strBuff, "〈", "")
        strBuff = Replace(strBuff, "〉", "")
        strBuff = Replace(strBuff, "『", "")
        strBuff = Replace(strBuff, "』", "")
        strBuff = Replace(strBuff, "≪", "")
        strBuff = Replace(strBuff, "≫", "")
        strBuff = Replace(strBuff, "〔", "")
        strBuff = Replace(strBuff, "〕", "")
        strBuff = Replace(strBuff, "［", "")
        strBuff = Replace(strBuff, "］", "")
        strBuff = Replace(strBuff, "｛", "")
        strBuff = Replace(strBuff, "｝", "")
        strBuff = Replace(strBuff, "（", "")
        strBuff = Replace(strBuff, "）", "")


        Return strBuff
    End Function

    Private Function ReplaceKanSuuji(ByRef strBuff As String) As String

        strBuff = Replace(strBuff, "一", "１")
        strBuff = Replace(strBuff, "二", "２")
        strBuff = Replace(strBuff, "三", "３")
        strBuff = Replace(strBuff, "四", "４")
        strBuff = Replace(strBuff, "五", "５")
        strBuff = Replace(strBuff, "六", "６")
        strBuff = Replace(strBuff, "七", "７")
        strBuff = Replace(strBuff, "八", "８")
        strBuff = Replace(strBuff, "九", "９")
        strBuff = Replace(strBuff, "十", "１")

        strBuff = Replace(strBuff, "百", "１")
        strBuff = Replace(strBuff, "千", "１")
        strBuff = Replace(strBuff, "万", "１")

        strBuff = Replace(strBuff, "弐", "２")
        strBuff = Replace(strBuff, "参", "３")
        strBuff = Replace(strBuff, "零", "０")

        Return strBuff
    End Function




End Class
