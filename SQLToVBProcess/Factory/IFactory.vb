Public Interface IFactory(Of T)
    '底層容器可能是Set List Dictionary StringBuilder
    Sub AddMaterial(sqlLine As String)
    Function Produce() As T
End Interface
