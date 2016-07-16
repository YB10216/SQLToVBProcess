Imports System.Text
Imports System.Text.RegularExpressions

Public Class VBWithNoteFactory
    Implements IFactory(Of CodeText)
    'Dynamic的寫法 另外寫
    'Private factories = New List(Of IFactory(Of String)) From
    '                        {New SQLParaTextFactory(), New SDTextFactory()}

    Private sqlParaFactory As IFactory(Of String) = New SQLParaWithNoteFactory()
    Private sdFactory As IFactory(Of String) = New SDTextFactory()

    Public Sub AddMaterial(sqlLine As String) Implements IFactory(Of CodeText).AddMaterial
        sqlParaFactory.AddMaterial(sqlLine)
        sdFactory.AddMaterial(sqlLine)
    End Sub

    Public Function Produce() As CodeText Implements IFactory(Of CodeText).Produce
        Return New CodeText With {
            .VBText = sqlParaFactory.Produce(),
            .SDText = sdFactory.Produce()
        }
    End Function
End Class

Public Class SQLParaWithNoteFactory
    Implements IFactory(Of String)

    Private sqlParaBuilder As New StringBuilder()

    '小心Format不對
    Private ReadOnly SQL_FORMAT As String = VBFormat.SQLFormat
    Private ReadOnly PARA_FORMAT As String = VBFormat.ParasFormat
    Private ReadOnly NOTE_FORMAT As String = VBFormat.VBNoteFormat

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
        Dim note = NoteMatch(sqlLine)
        Me.sqlParaBuilder.AppendLine(sql & para & note)
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

    Private Function NoteMatch(sqlLine As String) As String
        Dim reg = New Regex(NOTE_PATTERN)
        If reg.IsMatch(sqlLine) Then
            Dim match = reg.Matches(sqlLine).Cast(Of Match)().Select(Function(x) x.Value).FirstOrDefault()
            Dim note = String.Format(NOTE_FORMAT, match.Substring(2)) 'match的前二個字元是/
            Return note
        End If
        Return String.Empty
    End Function

    Private Function IsExceptMatch(sqlLine As String) As Boolean
        Dim reg = New Regex(EXCEPT_PATTERN, RegexOptions.IgnoreCase)
        If reg.IsMatch(sqlLine) Then
            Return True
        End If
        Return False
    End Function
End Class

Public Class SDTextFactory
    Implements IFactory(Of String)

    'Private tmpSDSet As New SortedSet(Of String) '若用此容器,則無法用AddRange
    Private tmpSDs As New List(Of String)(16)
    Private sdNoteDic As New Dictionary(Of String, String)

    Private ReadOnly SQL_FORMAT As String = VBFormat.SQLFormat
    Private ReadOnly SD_FORMAT As String = VBFormat.SDFormat
    Private ReadOnly NOTE_FORMAT As String = VBFormat.VBNoteFormat

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
        Dim reg = New Regex(NOTE_PATTERN)
        If reg.IsMatch(sqlLine) Then
            Dim match = reg.Matches(sqlLine).Cast(Of Match)().Select(Function(x) x.Value).FirstOrDefault()
            Dim notes = match.Substring(2).Split(New Char() {vbTab, " "c}) 'match的前二個字元是/
            Return notes
        End If
        Return Nothing

    End Function
End Class



