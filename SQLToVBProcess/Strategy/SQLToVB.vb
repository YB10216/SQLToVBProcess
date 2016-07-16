Imports System.IO

Public Class SQLToVB
    Implements ISQLToVB

    Private factory As IFactory(Of CodeText) '預設,另外還有VBWithNoteFactory可選

    Public Sub New(trans As TransType, note As NoteType)
        If trans = TransType.SQLToVB AndAlso note = NoteType.WithNote Then
            Me.factory = New VBWithNoteFactory()

        End If
        If trans = TransType.SQLToVB AndAlso note = NoteType.WithoutNote Then
            Me.factory = New VBWithoutNoteFactory

        End If
        If trans = TransType.VBToSQL AndAlso note = NoteType.WithNote Then
            Me.factory = New SQLWithNoteFactory()

        End If
        If trans = TransType.VBToSQL AndAlso note = NoteType.WithoutNote Then
            Me.factory = New SQLWithoutNoteFactory
        End If
    End Sub

    Public Function Transfer(sqlBefore As String) As CodeText Implements ISQLToVB.Transfer
        Dim sqlLine = String.Empty
        Using sr = New StringReader(sqlBefore)
            Do
                sqlLine = sr.ReadLine() '讀取txtBefore
                If sqlLine Is Nothing Then
                    Exit Do
                End If
                If String.IsNullOrWhiteSpace(sqlLine) Then
                    Continue Do
                End If
                factory.AddMaterial(sqlLine.Trim())
            Loop
        End Using
        Return factory.Produce()
    End Function
    
End Class

Public Enum TransType As Integer
    VBToSQL = 0
    SQLToVB = 1
End Enum

Public Enum NoteType As Integer
    WithoutNote = 0
    WithNote = 1
End Enum