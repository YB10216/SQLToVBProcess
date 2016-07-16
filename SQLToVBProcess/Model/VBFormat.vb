Public Module VBFormat
    '要改用Singleton, 將XXXFormat改成 readonly, 建構子設定XXXFormat初始值

    Public Const StrSQLDefault As String = "strSQL"
    Public Const ParasDefault As String = "paras"
    Public Const SDDefault As String = "sd"

    ''' <summary>
    ''' 字尾Format,代表可做一次StringFormat,替換參數名稱,有些Format是從Prototype來的
    ''' </summary>
    ''' <remarks></remarks>
    Public SQLFormat As String = "strSQL.AppendLine(""{0}"")" 'strSQL.AppendLine("AND SEQ_NO = decode(:SEQ_NO,null,1, :SEQ_NO)")
    Public ParasFormat As String = " : paras.Add(sd(""{0}""))" ' : paras.Add(sd("{0}"))
    Public SDFormat As String = "sd(""{0}"") = """"" 'sd("{0}") = ""
    Public VBNoteFormat As String = " '{0}"
    Public SQLNoteFormat As String = " --" ' -- or //


    ''' <summary>
    ''' 字尾Prototype,代表可做兩次StringFormat,第一次替換物件名稱,第二次替換參數名稱
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ParasPrototype As String = " : {0}.Add(sd(""{{0}}""))" ' : paras.Add(sd("{0}"))
    Public Const SDPrototype As String = "{0}(""{{0}}"") = """"" 'sd("{0}") = ""

    Public Sub SetCustomFormat(Optional parasCustom As String = ParasDefault, Optional sdCustom As String = SDDefault)
        If String.IsNullOrWhiteSpace(parasCustom) AndAlso parasCustom <> ParasDefault Then
            ParasFormat = String.Format(ParasPrototype, parasCustom)
        End If
        If String.IsNullOrWhiteSpace(sdCustom) AndAlso sdCustom <> SDDefault Then
            SDFormat = String.Format(SDPrototype, sdCustom)
        End If
    End Sub
    Public Sub SetDefaultFormat()
        ParasFormat = String.Format(ParasPrototype, ParasDefault)
        SDFormat = String.Format(SDPrototype, SDDefault)
    End Sub
End Module
