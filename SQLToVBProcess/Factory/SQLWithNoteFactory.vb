Imports System.Text
Imports System.Text.RegularExpressions

Public Class SQLWithNoteFactory
    Implements IFactory(Of CodeText)

    Private sqlParaFactory As New InverseSQLParaWithNoteFactory()
    Private sdFactory As New InverseSDWithNoteFactory()

    Public Sub AddMaterial(sqlLine As String) Implements IFactory(Of CodeText).AddMaterial
        sqlParaFactory.AddMaterial(sqlLine)
        'sdFactory.AddMaterial(sqlLine)
    End Sub

    Public Function Produce() As CodeText Implements IFactory(Of CodeText).Produce
        Return New CodeText With {
            .VBText = sqlParaFactory.Produce(),
            .SDText = String.Empty
        } 'sdFactory.Produce()
    End Function
End Class

Public Class InverseSQLParaWithNoteFactory
    Implements IFactory(Of String)

    Private sqlBuilder As New StringBuilder()

    Private ReadOnly SQL_NOTE_FORMAT = VBFormat.SQLNoteFormat
    '小心Format不對


    Public Function Produce() As String Implements IFactory(Of String).Produce
        Return sqlBuilder.ToString()
    End Function

    Public Sub AddMaterial(sqlLine As String) Implements IFactory(Of String).AddMaterial
        If IsExceptMatch(sqlLine) Then
            Me.sqlBuilder.AppendLine(sqlLine)
            Return
        End If
        Dim sql = SQLMatch(sqlLine)
        Dim note = NoteMatch(sqlLine)
        Me.sqlBuilder.AppendLine(sql & note)
    End Sub

    ''' <summary>
    ''' 輸入sqlLine,回傳strSQL.AppendLine(sqlLine)
    ''' </summary>
    ''' <param name="sqlLine"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SQLMatch(sqlLine As String) As String

        Dim regBegin = New Regex(INVERSE_SQLBEGIN_PATTERN) '("XXXXX")
        Dim regEnd = New Regex(INVERSE_SQLEND_PATTERN) '("XXXXX")
        If regBegin.IsMatch(sqlLine) AndAlso regEnd.IsMatch(sqlLine) Then '如果有
            Dim indexBegin = regBegin.Match(sqlLine).Index + 2 '因為("兩個字元
            Dim indexEnd = regEnd.Match(sqlLine).Index
            Return sqlLine.Substring(indexBegin, indexEnd - indexBegin)
        Else
            Return sqlLine
        End If
    End Function

    Private Function NoteMatch(sqlLine As String) As String
        Dim reg = New Regex(INVERSE_NOTE_PATTERN)
        If reg.IsMatch(sqlLine) Then
            Dim match = reg.Match(sqlLine).Value
            Dim index = match.IndexOf("'")
            Dim note = match.Substring(index)
            Return String.Format(SQL_NOTE_FORMAT, note)
        End If
        Return Nothing

    End Function

    Private Function IsExceptMatch(sqlLine As String) As Boolean
        Dim reg = New Regex(EXCEPT_PATTERN, RegexOptions.IgnoreCase)
        If reg.IsMatch(sqlLine) Then
            Return True
        End If
        Return False
    End Function
End Class

Public Class InverseSDWithNoteFactory
    Implements IFactory(Of String)

    'Private tmpSDSet As New SortedSet(Of String) '若用此容器,則無法用AddRange
    Private tmpSDs As New List(Of String)(16)
    Private sdNoteDic As New Dictionary(Of String, String)

    Private SQL_FORMAT As String = VBFormat.SQLFormat
    Private SD_FORMAT As String = VBFormat.SDFormat
    Private NOTE_FORMAT As String = VBFormat.VBNoteFormat

    Public Function Produce() As String Implements IFactory(Of String).Produce
        Dim sdSet = New SortedSet(Of String)(tmpSDs)
        Dim sds = sdSet.AsEnumerable().Select(Function(x) getSDNote(x))
        Return String.Join(vbNewLine, sds)
    End Function

    Public Sub AddMaterial(sqlLine As String) Implements IFactory(Of String).AddMaterial
        Dim sds = SDMatch(sqlLine)
        Dim notes = NoteMatch(sqlLine) '有問題的一行
        tmpSDs.AddRange(sds)
        Combine(sds, notes, Sub(t1, t2) sdNoteDic.Add(t1, t2)) '有問題的一行
    End Sub

    Private Function getSDNote(sd As String) As String
        If sdNoteDic.ContainsKey(sd) Then
            Return sd & String.Format(NOTE_FORMAT, sdNoteDic(sd))
        End If
        Return sd
    End Function

    Private Sub Combine(Of T1, T2)(first As IEnumerable(Of T1), second As IEnumerable(Of T2), action As Action(Of T1, T2))
        If first Is Nothing OrElse second Is Nothing Then
            Return
        End If
        Using e1 = first.GetEnumerator, e2 = second.GetEnumerator
            While e1.MoveNext() AndAlso e2.MoveNext()
                action(e1.Current, e2.Current)
            End While
        End Using
    End Sub

    Private Function SDMatch(sqlLine As String) As IEnumerable(Of String)
        Dim reg = New Regex(PARA_PATTERN)
        Dim matches = reg.Matches(sqlLine).Cast(Of Match)().Select(Function(x) x.Value) '複數 :XXX :YYY
        Dim sds = matches.Select(Function(x) String.Format(SD_FORMAT, x.Substring(1))) 'x的第一個字元是冒號
        Return sds
    End Function

    Private Function NoteMatch(sqlLine As String) As IEnumerable(Of String)
        Dim reg = New Regex(INVERSE_NOTE_PATTERN)
        If reg.IsMatch(sqlLine) Then
            Dim match = reg.Match(sqlLine).Value
            Dim index = match.IndexOf("'")
            Dim notes = match.Substring(index).Split(New Char() {vbTab, " "c}) 'match的前二個字元是/
            Return notes
        End If
        Return Nothing

    End Function
End Class

