Imports System.Text
Imports System.Text.RegularExpressions

Public Class VBWithoutNoteFactory
    Implements IFactory(Of CodeText)

    Private sqlParaFactory As IFactory(Of String) = New SQLParaWithOutNoteFactory()
    Private sdFactory As IFactory(Of String) = New SDTextFactory()

    Public Sub AddMaterial(sqlLine As String) Implements IFactory(Of CodeText).AddMaterial
        sqlParaFactory.AddMaterial(sqlLine)
        sdFactory.AddMaterial(sqlLine)
    End Sub

    Public Function Produce() As CodeText Implements IFactory(Of CodeText).Produce
        Return New CodeText With {
            .VBText = sqlParaFactory.Produce(),
            .SDText = sdFactory.Produce
        }
    End Function

End Class

Public Class SQLParaWithOutNoteFactory
    Implements IFactory(Of String)

    Private sqlParaBuilder As New StringBuilder()

    '小心Format不對
    Private ReadOnly SQL_FORMAT As String = VBFormat.SQLFormat
    Private ReadOnly PARA_FORMAT As String = VBFormat.ParasFormat
    'Private ReadOnly NOTE_FORMAT As String = VBFormat.NoteFormat

    Public Function Produce() As String Implements IFactory(Of String).Produce
        Return sqlParaBuilder.ToString()
    End Function

    Public Sub AddMaterial(sqlLine As String) Implements IFactory(Of String).AddMaterial
        If IsExceptMatch(sqlLine) Then
            Me.sqlParaBuilder.AppendLine(sqlLine)
            Return
        End If
        Dim sql = SQLMatch(sqlLine)
        Dim para = ParaMatch(sqlLine)
        'Dim note = NoteMatch(sqlLine)
        'Me.sqlParaBuilder.AppendLine(sql & para & note)
        Me.sqlParaBuilder.AppendLine(sql & para)
    End Sub

    ''' <summary>
    ''' 輸入sqlLine,回傳strSQL.AppendLine(sqlLine)
    ''' </summary>
    ''' <param name="sqlLine"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SQLMatch(sqlLine As String) As String
        Dim reg = New Regex(SQLEND_PATTERN)
        If reg.IsMatch(sqlLine) Then '如果有
            Dim index = reg.Match(sqlLine).Index
            Return String.Format(SQL_FORMAT, sqlLine.Substring(0, index))
        Else
            Return String.Format(SQL_FORMAT, sqlLine)
        End If
    End Function

    Private Function ParaMatch(sqlLine As String) As String
        Dim reg = New Regex(PARA_PATTERN)
        Dim matches = reg.Matches(sqlLine).Cast(Of Match)().Select(Function(x) x.Value) '複數 :XXX :YYY
        Dim paras = matches.Select(Function(x) String.Format(PARA_FORMAT, x.Substring(1))) 'x的第一個字元是冒號
        Return String.Join("", paras)
    End Function

    'Private Function NoteMatch(sqlLine As String) As String
    '    Dim reg = New Regex(NOTE_PATTERN)
    '    If reg.IsMatch(sqlLine) Then
    '        Dim match = reg.Matches(sqlLine).Cast(Of Match)().Select(Function(x) x.Value).FirstOrDefault()
    '        Dim note = String.Format(NOTE_FORMAT, match.Substring(2)) 'match的前二個字元是/
    '        Return note
    '    End If
    '    Return String.Empty
    'End Function

    Private Function IsExceptMatch(sqlLine As String) As Boolean
        Dim reg = New Regex(EXCEPT_PATTERN, RegexOptions.IgnoreCase)
        If reg.IsMatch(sqlLine) Then
            Return True
        End If
        Return False
    End Function
End Class

