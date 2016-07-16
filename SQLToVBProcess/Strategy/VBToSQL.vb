Public NotInheritable Class VBToSQL
    Inherits SQLToVB

    Public Sub New(Optional isWithNote As Boolean = False)
        MyBase.New(isWithNote)
    End Sub

    Protected Overrides WriteOnly Property IsWithNote As Boolean
        Set(value As Boolean)
            If value = True Then
                Me.factory = New SQLWithNoteFactory()
            Else
                Me.factory = New SQLWithoutNoteFactory
            End If
        End Set
    End Property

End Class
